using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public static string ConvertToEmbed(String URL)
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
                else if (host == "dropbox.com")
                {
                    return URL.Replace("www.dropbox.com", "dl.dropboxusercontent.com");
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

        public static string DownloadString(String URL)
        {
            try
            {
                WebClient downloadString = new WebClient();
                return downloadString.DownloadString(URL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
          * 
          * SMTP:
          * 
          * Yahoo: mail.yahoo.com
          * Wanadoo: smtp.wanadoo.fr
          * Outlook.com (former Hotmail): smtp.live.com
          * Orange: smtp.orange.fr
          * LaPoste: smtp.laposte.fr
          * Gmail: smtp.gmail.com
          * Free: smtp.free.fr
          * Bouygtel: smtp.bouygtel.fr
          * 
          **/
        public static void SendMail(String SMTP, int portDefault587, String senderEmail, String senderPassword, String destination, String subject, String mailText)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTP);
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(destination);
                mail.Subject = subject;
                mail.Body = mailText;
                SmtpServer.Port = portDefault587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
