using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Mawenzy;
using Mawenzy.Util;
using System.Windows.Forms;
using System.IO;
using Mawenzy.Plugins;
using System.Drawing;
using System.Threading;
using System.Xml;
using System.Net;
using Mawenzy.UI;
using Mawenzy.Plugins.Google_Plugs.Weather;
using Mawenzy.Plugins.Google_Plugs.Properties;
using Mawenzy.Properties;
using System.Diagnostics;
using Mawenzy.Config;

namespace Mawenzy.Plugins.Google_Plugs
{
    /// <summary>
    /// Uses Google weather API to show basic weather forecast.
    /// </summary>
    public class Google_Weather : TickerTock
    {
        #region Structs
        /// <summary>
        /// Static current condition.
        /// </summary>
        private struct ForecastHeader
        {
            public string City,
                DataDate,
                CurrentCondition,
                CurrentTemp,
                Humidity,
                IconName,
                Wind;
            public JumpRect jumper;
        }

        /// <summary>
        /// Conditions for a given day.
        /// </summary>
        private struct WeatherDay
        {
            public string DayOfWeek,
                ConditionType,
                HighTemp,
                LowTemp,
                Humidity,
                Wind,
                IconName;
            public JumpRect jumper;
        }
        #endregion

        /// <summary>
        /// Set our ticker container.
        /// </summary>
        public Google_Weather()
        {
        }

        public override void Activate()
        {
            base.ParentTicker = General_Options.MawenzyTicker;
            base.Activate();
        }

        #region PluginBase Members
        public override Image OptionsIcon
        {
            get
            {
                return Resources.weather;
            }
        }

        public override void ReadSettings()
        {
            GoogleSettings.Default.Reload();
        }

        public override void WriteSettings()
        {
            GoogleSettings.Default.Save();
        }

        /// <summary>
        /// Use GWConfig in Uberdash settings.
        /// </summary>
        public override Control ConfigControl
        {
            get { return new GWConfig(); }
        }
        #endregion

        public override List<Image> Fetch()
        {
            List<Image> results = new List<Image>();
            WeatherLayout wControl = new WeatherLayout();
            ForecastHeader currCond = new ForecastHeader();
            List<string> imgPaths = new List<string>();
            Dictionary<string, Image> imageMap = new Dictionary<string, Image>();
            XmlDocument weatherMilwaukee = new XmlDocument();
            List<WeatherDay> dayList = new List<WeatherDay>();

            try
            {
                string fetchAddr = String.Format(
                    GoogleSettings.Default.GoogleWeatherURL,
                    GlobalSettings.Default.Region);
                WebRequest webReq = HttpWebRequest.Create(fetchAddr);
                WebRequest.DefaultWebProxy = null;

                Stream webStream = webReq.GetResponse().GetResponseStream();
                weatherMilwaukee.Load(webStream);

                #region Regional Summary
                foreach (XmlNode regionSummary in weatherMilwaukee.GetElementsByTagName("forecast_information"))
                {
                    foreach (XmlElement attrib in regionSummary)
                    {
                        switch (attrib.Name)
                        {
                            case "city":
                                currCond.City = attrib.GetAttribute("data");
                                break;
                            case "forecast_date":
                                currCond.DataDate = attrib.GetAttribute("data");
                                break;
                        }
                    }
                }
                #endregion
                #region Current Conditions
                foreach (XmlNode currConditions in weatherMilwaukee.GetElementsByTagName("current_conditions"))
                {
                    foreach (XmlElement attrib in currConditions)
                    {
                        switch (attrib.Name)
                        {
                            case "condition":
                                currCond.CurrentCondition = attrib.GetAttribute("data");
                                break;
                            case "temp_f":
                                if (GoogleSettings.Default.TempUnits == 'f')
                                    currCond.CurrentTemp = attrib.GetAttribute("data");
                                break;
                            case "temp_c":
                                if (GoogleSettings.Default.TempUnits == 'c')
                                    currCond.CurrentTemp = attrib.GetAttribute("data");
                                break;
                            case "humidity":
                                currCond.Humidity = attrib.GetAttribute("data");
                                break;
                            case "icon":
                                currCond.IconName = attrib.GetAttribute("data");
                                if (!imgPaths.Contains(currCond.IconName))
                                    imgPaths.Add(currCond.IconName);
                                break;
                            case "wind_condition":
                                currCond.Wind = attrib.GetAttribute("data");
                                break;
                        }
                    }
                }
                #endregion
                #region Daily Forecast
                foreach (XmlNode forecast in weatherMilwaukee.GetElementsByTagName("forecast_conditions"))
                {
                    WeatherDay wDay = new WeatherDay();

                    foreach (XmlElement condition in forecast)
                    {
                        switch (condition.Name)
                        {
                            case "day_of_week":
                                wDay.DayOfWeek = condition.GetAttribute("data");
                                break;
                            case "condition":
                                wDay.ConditionType = condition.GetAttribute("data");
                                break;
                            case "high":
                                wDay.HighTemp = (condition.GetAttribute("data") + " °" + GoogleSettings.Default.TempUnits).ToUpper();
                                break;
                            case "low":
                                wDay.LowTemp = (condition.GetAttribute("data") + " °" + GoogleSettings.Default.TempUnits).ToUpper();
                                break;
                            case "icon":
                                wDay.IconName = condition.GetAttribute("data");
                                if (!imgPaths.Contains(wDay.IconName))
                                    imgPaths.Add(wDay.IconName);
                                break;
                            case "humidity":
                                wDay.Humidity = condition.GetAttribute("data");
                                break;
                            case "wind_condition":
                                wDay.Wind = condition.GetAttribute("data");
                                break;
                        }
                    }

                    dayList.Add(wDay);
                }
                #endregion
                #region Load images from web
                foreach (string imPath in imgPaths)
                {
                    try
                    {
                        fetchAddr = GoogleSettings.Default.WeatherImagePath + imPath;
                        webReq = HttpWebRequest.Create(fetchAddr);
                        WebRequest.DefaultWebProxy = null;

                        webStream = webReq.GetResponse().GetResponseStream();
                        Image wicon = Image.FromStream(webStream);
                        imageMap[imPath] = wicon;
                        wControl.pbCurrent.Image = (Image)wicon.Clone();
                    }
                    catch (WebException)
                    {
                        imageMap[imPath] = Resources.Crystal_Clear_not_found;
                        wControl.pbCurrent.Image = Resources.Crystal_Clear_not_found;
                    }
                }
                wControl.Update();
                #endregion

                #region Set controls
                wControl.labLocation.Text = currCond.City;
                wControl.labKDate.Text = currCond.DataDate;
                wControl.labCond.Text = currCond.CurrentCondition;
                wControl.labTemp.Text = currCond.CurrentTemp + "º " + Char.ToUpper(GoogleSettings.Default.TempUnits);
                wControl.labHumidity.Text = currCond.Humidity;
                wControl.labWind.Text = currCond.Wind;

                results.Add(RenderState.DrawControl(wControl));

                foreach (WeatherDay day in dayList)
                {
                    DayLayout layout = new DayLayout();
                    layout.labCond.Text = day.ConditionType;
                    layout.labHighTemp.Text = "High " + day.HighTemp;
                    layout.labLowTemp.Text = "Low " + day.LowTemp;
                    //layout.labWind.Text = day.Wind;
                    //layout.labHumidity.Text = day.Humidity;
                    layout.labDay.Text = day.DayOfWeek;
                    layout.pbCurrent.Image = imageMap[day.IconName].Clone() as Image;

                    results.Add(RenderState.DrawControl(layout));
                }
                #endregion
            }
            catch (Exception ex)
            {
                ErrForm.Show(new PluginException(this,
                    Resources.ERR_GWeather, ex));
            }

            return results;
        }

        public override ContextMenuStrip Menu
        {
            get
            {
                return base.Menu;
            }
        }
    }
}
