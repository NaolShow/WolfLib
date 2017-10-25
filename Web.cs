using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WolfLib
{
    public class Web
    {

        /**
         *  Developed by NaolShow (Loan.J)
         *  Sources and DLL on github.com
         *  https://github.com/NaolShow/WolfLib
         *  
         **/

        public static string convertToEmbed(String URL)
        {
            try
            {
                Uri myUri = new Uri(URL);
                string host = myUri.Host;

                /**
                 * Contact me for more website
                 * 
                 * Youtube and Lives
                 * Twitch
                 * Dailymotion
                 * Vimeo
                 * 
                 **/
                if (host == "www.youtube.com")
                {
                    // And live** 
                    return URL.Replace("www.youtube.com/watch?v=", "www.youtube.com/embed/"); // Delete &t=
                }
                else if (host == "www.dailymotion.com")
                {
                    return URL.Replace("www.dailymotion.com/video", "www.dailymotion.com/embed/video");
                }
                else if (host == "vimeo.com")
                {
                    return URL.Replace("vimeo.com/", "player.vimeo.com/video/");
                }
                else if (host == "go.twitch.tv")
                {
                    string gotwitchreplace = URL.Replace("http://go.twitch.tv/", "");
                    return "player.twitch.tv/?channel=" + gotwitchreplace.Replace("https://go.twitch.tv/", "");
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string downloadString(String URL)
        {
            WebClient downloadString = new WebClient();
            return downloadString.DownloadString(URL);
        }

    }
}
