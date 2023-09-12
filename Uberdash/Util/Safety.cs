using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using Mawenzy.UI;
using Mawenzy.Properties;
using Microsoft.Win32;

namespace Mawenzy.Util
{
    /// JLB <summary>
    /// A static collection of safety and security helper methods.
    /// </summary>
    public class Safety
    {
        /// JLB <summary>
        /// Used for creating temp files.
        /// </summary>
        private static Random randPaths = new Random();
        
        /// JLB <summary>
        /// Launches a URL as a process to be handled by default web browser.
        /// Checks to make sure a URL hasn't been replaced with a malicious file.
        /// </summary>
        /// <param name="link"></param>
        public static void LaunchURL(string link)
        {
            if (link == null)
                return;

            try
            {
                Uri uri = new Uri(link);
                if (File.Exists(link))
                    throw new UriFormatException(Resources.ERR_UrlMalicious.Replace("{FILE}", link));
                else
                    // JLB BOGUS - GetDefaultBrowserPath always gives ie...
                    //Process.Start(GetDefaultBrowserPath(), link);
                    Process.Start(uri.AbsoluteUri);
            }
            catch (UriFormatException ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.ERR_UrlMalicious.Replace("{FILE}", link), ex));
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.ERR_UrlFailure.Replace("{URL}", link), ex));
            }
        }

        /// JLB <summary>
        /// Launches a URL with ads in frame.  Launches locally to 
        /// reduce web server load.  Probably controversial.
        /// </summary>
        /// <remarks>Be extra careful creating and launching a temp file...</remarks>
        /// <param name="link"></param>
        public static void LaunchURLwAds(string link)
        {
            // TODO: Arrange for some unobtrusive form of advertising.
            LaunchURL(link);

            /** /
            try
            {

                if (link != null)
                {
                    if (File.Exists(link))
                        throw new UriFormatException(Resources.ERR_UrlMalicious.Replace("{FILE}", link));
                    else
                    {
                        Uri target = new Uri(link);
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)
                            + "/" + randPaths.Next().ToString() + ".html";
                        string page = Resources.SPN_AdLink.Replace("{PAGE}", target.ToString());
                        StreamWriter sw = new StreamWriter(path);

                        sw.Write(page);
                        sw.Close();

                        Process.Start(GetDefaultBrowserPath(), path);
                    }
                }
            }
            catch (UriFormatException ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.ERR_UrlMalicious.Replace("{FILE}", link), ex));
            }
            catch (Exception ex)
            {
                ErrForm.Show(new ApplicationException(
                    Resources.ERR_UrlFailure.Replace("{URL}", link), ex));
            }
            /**/
        }

        /// <summary>
        /// Deprecated. Get default browser. That's right - DEPRECATED.
        /// This official approved method is happy to stick IE up in your face no matter what.
        /// </summary>
        /// <returns>Path to default browser.</returns>
        private static string GetDefaultBrowserPath()
        {
            RegistryKey registryKey =
                Registry.ClassesRoot.OpenSubKey(@"htmlfile\shell\open\command", false);
            string res = registryKey.GetValue(null, null).ToString().Split('"')[1];

            return res;
        }
    }
}
