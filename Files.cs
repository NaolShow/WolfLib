using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WolfLib
{
    public class Files
    {

        /**
         *  Developed by NaolShow (Loan.J)
         *  Sources and DLL on github.com
         *  https://github.com/NaolShow/WolfLib
         *  WebSite:
         *  http://towolf.livehost.fr/wolflib/
         *  
         **/

        // Files
        public static string GetLine(String path, int line)
        {
            try
            {
                return File.ReadLines(path).Skip(line).Take(1).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WriteLine(String path, String text, int line)
        {
            try
            {
                string[] arrLine = File.ReadAllLines(path);
                arrLine[line] = text;
                File.WriteAllLines(path, arrLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteLine(String path, int line)
        {
            try
            {
                List<String> file = new List<String>(File.ReadAllLines(path));
                file.RemoveAt(line);
                File.WriteAllLines(path, file);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertLine(String path, String text, int line)
        {
            try
            {
                List<String> file = new List<String>(File.ReadAllLines(path));
                file.Insert(line, text);
                File.WriteAllLines(path, file);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
