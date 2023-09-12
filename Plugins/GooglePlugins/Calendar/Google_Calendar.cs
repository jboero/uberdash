using System;
using System.Collections.Generic;
using System.Text;
using Mawenzy.Plugins;
using System.Windows.Forms;
using Mawenzy.Plugins.Google_Plugs.Calendar;
using System.Drawing;
using Mawenzy.Util;
using Tao.OpenGl;
using ShellDll;
using Mawenzy.UI;
using Google.GData.Calendar;
using System.Net;
using Google.GData.Extensions;
using Mawenzy.Properties;
using System.Threading;
using Google.GData.Client;
using System.Globalization;
using Mawenzy.Plugins.GooglePlugins;

namespace Mawenzy.Plugins.Google_Plugs
{
    public class Google_Calendar : PluginBase
    {
        #region Fields
        /// JLB <summary>
        /// JumpGrad for smooth camera motions.
        /// Helix: [0] = angle [1] = height [2] = distance
        /// </summary>
        private Jumper cam;

        private List<JumpRect> jumpers;

        private List<Image> calImages = null;

        static Font evFont = new Font(SystemFonts.MenuFont.FontFamily, 12, FontStyle.Bold);

        private int activeSide = 0;

        private System.Windows.Forms.Timer loader;
        
        private bool moving = false;

        private CalendarLayout cl;
        #endregion

        #region Core
        public Google_Calendar()
        {
        }

        /// JLB <summary>
        /// Loads events from Google Calendar of configured user and password.
        /// </summary>
        /// <remarks>
        /// This is run in its own thread, so standard exception handling doesn't apply.
        /// </remarks> 
        private void RefreshCalendar(object sender, EventArgs e)
        {
            // Don't bother if we haven't specified credentials.

            if (String.IsNullOrEmpty(GoogleSettings.Default.GoogleID)
                || String.IsNullOrEmpty(GoogleSettings.Default.GooglePW))
                return;

            // Kick off loading in a low-priority IO thread.
            Thread loadThread = new Thread(new ThreadStart(Reload));
            loadThread.Priority = ThreadPriority.Lowest;
            loadThread.IsBackground = true;
            loadThread.Start();
        }

        private void Reload()
        {
            loader.Stop();
            try
            {
                Uri calendarURI = new Uri(GoogleSettings.Default.CalendarURL);
                string userName = GoogleSettings.Default.GoogleID;
                string passWord = Mawenzy.Util.Encoder.Decrypt(
                    GoogleSettings.Default.GooglePW,
                    GlobalSettings.Default.MasterKey);
                EventQuery query = new EventQuery();
                CalendarService service = new CalendarService("Personal");

                // Credentials already validated not null or empty.
                service.setUserCredentials(userName, passWord);

                // Get events for today - 1 month until today + 1 month
                query.Uri = calendarURI;
                query.StartTime = DateTime.Today.AddMonths(-2);
                query.EndTime = DateTime.Today.AddMonths(2);
                query.NumberToRetrieve = 100;

                // Don't forget the crazy .NET Proxy bug...
                WebRequest.DefaultWebProxy = null;
                EventFeed calFeed = service.Query(query) as EventFeed;

                /** /
                while (calFeed != null && calFeed.NextChunk != null)
                {
                    // Query the same query again.
                    // This has not been necessary.
                    query.Uri = new Uri(calFeed.NextChunk);
                    calFeed = service.Query(query) as EventFeed;
                }
                /**/

                BuildCalendar(calFeed);
                
                // Now rejoin render thread and create display lists.
                if (Parent != null && !Parent.IsDisposed)
                    Parent.Invoke(new JoinRenderThread(BuildTex));
            }
            catch (LoggedException ex)
            {
                // If we haven't told 
                if (!AwareOfErr)
                    Parent.Invoke(new JoinRenderThreadEx(ErrForm.RethrowJoinThread), 
                        new ApplicationException(
                            String.Format(Mawenzy.Plugins.Properties.Resources.CalendarCredErr, ex.Message), ex));

                AwareOfErr = true;
                return;
            }
            catch (Exception ex)
            {
                Parent.Invoke(new JoinRenderThreadEx(ErrForm.RethrowJoinThread), 
                    new ApplicationException(String.Format(
                        Mawenzy.Plugins.Properties.Resources.CalendarFatalErr, ex.Message), ex));
                Deactivate();
            }

            if (loader != null && !loader.Enabled)
                loader.Start();
            AwareOfErr = false;
        }

        private void BuildCalendar(EventFeed calFeed)
        {
            // Find the first Sunday of this month.
            DateTime start = DateTime.Today;
            
            BuildMonth(calFeed, start.AddMonths(-1));
            BuildMonth(calFeed, start);
            BuildMonth(calFeed, start.AddMonths(1));
        }

        private void BuildMonth(EventFeed calFeed, DateTime calDay)
        {
            cl.labMonth.Text = calDay.ToString("MMMM");

            calDay = calDay.AddDays(-(calDay.Day - (calDay.Day % 7)));
            while (calDay.DayOfWeek != DayOfWeek.Sunday)
                calDay = calDay.AddDays(-1);

            cl.labMon.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Monday);
            cl.labTues.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Tuesday);
            cl.labWed.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Wednesday);
            cl.labThur.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Thursday);
            cl.labFriday.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Friday);
            cl.labSaturday.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Saturday);
            cl.labSunday.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Sunday);

            cl.DatesTable.Controls.Clear();

            for (int i = 0; i < 35; ++i)
            {
                DayLayout dl = new DayLayout();
                dl.labDate.Text = calDay.Day.ToString();
                if (calDay.Month != DateTime.Today.Month)
                    dl.labDate.ForeColor = Color.Gray;
                else if (calDay.DayOfWeek == DayOfWeek.Saturday || calDay.DayOfWeek == DayOfWeek.Sunday)
                    dl.labDate.ForeColor = Color.Cyan;

                foreach (EventEntry ent in calFeed.Entries)
                {
                    foreach (When when in ent.Times)
                    {
                        if (calDay < when.EndTime && when.StartTime < calDay.AddDays(1))
                        {
                            Label labby = new Label();
                            labby.ForeColor = Color.White;
                            labby.Font = evFont;
                            labby.Text = ent.Title.Text;
                            dl.flowPanel.Controls.Add(labby);
                        }
                    }
                }

                calDay = calDay.AddDays(1);
                cl.DatesTable.Controls.Add(dl);
            }

            calImages.Add(RenderState.DrawControl(cl));

            cl.DatesTable.Controls.Clear();
        }

        private void BuildTex()
        {
            JumpRect jr;

            if (calImages == null || calImages.Count < 3)
                return;

            // Prev month
            jr = new JumpRect(calImages[0], 15, 0, 100, 0, 0, 0, 0, 1, 1, 1, 0);
            jr[JumpRect.Z] = 0;
            jr[JumpRect.X] = -400;
            jr[JumpRect.Y] = Parent.Bounds.Height / 4;
            jr[JumpRect.S] = jr[JumpRect.U] = 0;
            jr[JumpRect.T] = 90;
            jumpers.Add(jr);

            // Curr month
            jr = new JumpRect(calImages[1], 15, 0, 100, 0, 0, 0, 0, 1, 1, 1, 0);
            jr[JumpRect.Z] = -400;
            jr[JumpRect.X] = 0;
            jr[JumpRect.Y] = Parent.Bounds.Height / 4;
            jr[JumpRect.S] = jr[JumpRect.T] = jr[JumpRect.U] = 0;
            jr[JumpRect.Alpha] = 1;
            jumpers.Add(jr);

            // Next month
            jr = new JumpRect(calImages[2], 15, 0, 100, 0, 0, 0, 0, 1, 1, 1, 0);
            jr[JumpRect.Z] = 0;
            jr[JumpRect.X] = 400;
            jr[JumpRect.Y] = Parent.Bounds.Height / 4;
            jr[JumpRect.S] = jr[JumpRect.U] = 0;
            jr[JumpRect.T] = -90;
            jumpers.Add(jr);

            calImages.Clear();
        }

        /// <summary>
        /// Draw function for "Flat Opaque" display mode.
        /// </summary>
        private void FlatDraw()
        {
            if (moving)
            {
                cam[0] = (Cursor.Position.X - Parent.Width / 2) * (-cam[2] / 1000f);
                cam[1] = (Cursor.Position.Y - Parent.Height / 2) * (-cam[2] / 1000f);
            }

            // Never leave a pushed matrix unpopped or you may funkify the next plugin's draw.
            Gl.glPushMatrix();
            RenderState.SetPerspective(60, Parent.Aspect, Parent.Bounds);
            Glu.gluLookAt(-cam[0], -cam[1], cam[2], -cam[0], -cam[1], 0, 0, -1, 0);
            Gl.glRotatef(cam[3], 0, 1, 0);

            //RenderState.SetupBasicLighting();
            
            //RenderState.SetOrtho(Parent.Bounds);
            Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            // Draw flat opaque.
            foreach (JumpRect jr in jumpers)
                jr.DrawWithAdvance();

            //Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);

            cam.Advance();
            Gl.glPopMatrix();
        }
        #endregion

        #region Overrides
        public override void Activate()
        {
            cl = new CalendarLayout();
            calImages = new List<Image>();
            jumpers = new List<JumpRect>();
            loader = new System.Windows.Forms.Timer();
            loader.Interval = GoogleSettings.Default.SwapInterval;
            loader.Tick += new EventHandler(RefreshCalendar);

            try
            {
                cam = Jumper.FromString(GoogleSettings.Default.CalendarCamPos);
            }
            catch (Exception)
            {
                cam = new Jumper(5, 0, 0, -1400, 0);
            }

            AwareOfErr = false;

            base.Activate();
            loader.Start();
            RefreshCalendar(null, EventArgs.Empty);
        }

        public override void Deactivate()
        {
            base.Deactivate();

            loader.Stop();
            loader.Dispose();
            loader = null;

            cl.Dispose();

            AwareOfErr = false;

            foreach (JumpRect jr in jumpers)
                jr.Dispose();

            jumpers.Clear();
            jumpers = null;
            calImages.Clear();
            calImages = null;

            GoogleSettings.Default.CalendarCamPos = cam.ToString();
            cam.Dispose();
            cam = null;

            GC.Collect();
        }

        public override void Draw()
        {
            FlatDraw();
        }

        public override System.Windows.Forms.Control ConfigControl
        {
            get
            {
                return new CalConfig();
            }
        }

        public override System.Drawing.Image OptionsIcon
        {
            get
            {
                return Mawenzy.Plugins.Properties.Resources.calendar;
            }
        }

        public override bool HandleMouseWheel(MouseEventArgs e)
        {
            if (moving)
            {
                cam[2] += e.Delta;
                Cursor.Current = Cursors.AppStarting;
                return true;
            }

            // Flip rotation of calendars 90 degrees.
            if (e.Delta > 0)
                ++activeSide;
            else if (e.Delta < 0)
                --activeSide;

            cam[3] = activeSide * 90;

            foreach (JumpRect jumper in jumpers)
                jumper[JumpRect.Alpha] = 0;

            int trueSide = (activeSide + 1) % 4;
            if (trueSide < 0)
                trueSide += 4;

            if (trueSide < 3)
                jumpers[trueSide][JumpRect.Alpha] = 1;

            return true;
        }

        public override bool HandleMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && e.Clicks == 1)
            {
                moving = !moving;

                if (moving)
                    Cursor.Current = Cursors.SizeAll;
                return true;
            }
            else if (e.Button == MouseButtons.Middle && e.Clicks == 2)
            {
                moving = false;
                cl.cmStrip.Show(e.Location);
                return true;
            }

            return moving = false;
        }

        public override void WriteSettings()
        {
            if (cam != null)
                GoogleSettings.Default.CalendarCamPos = cam.ToString();
            
            GoogleSettings.Default.Save();
            if (loader != null)
                loader.Interval = GoogleSettings.Default.SwapInterval;
        }

        public override void ReadSettings()
        {
            GoogleSettings.Default.Reload();
            if (loader != null)
                loader.Interval = GoogleSettings.Default.SwapInterval;
        }
        #endregion
    }
}
