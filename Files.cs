using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
         *  
         **/

        // Files
        public static string getAtLine(String path, int line)
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

        public static void writeAtLine(String path, String text, int line)
        {
            try
            {
                List<string> lines = System.IO.File.ReadAllLines(path).ToList<string>();
                lines.Insert(line, text);
                System.IO.File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
