using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfLib
{
    /// <summary>
    /// Reading and simple use CLASS
    /// </summary>
    public class Rasu
    {

        /**
          *  Developed by NaolShow (Loan.J)
          *  Sources and DLL on github.com
          *  https://github.com/NaolShow/WolfLib
          *  WebSite:
          *  http://towolf.livehost.fr/wolflib/
          *  
          *  Reading
          *  And
          *  Simple
          *  Use
          *  
          **/

        /// <summary>
        /// Get all values from a list from a file
        /// </summary>
        /// <returns>
        /// Return List<String>
        /// </returns>
        public static List<String> GetList(String path, String valueName)
        {
            var lines = File.ReadAllLines(path);
            Boolean check = false;
            List<String> returnValue = new List<String>();
            if (valueName.Substring(valueName.Length - 1, 1) != ":") { valueName = valueName + ":"; }
            foreach (var theLine in lines)
            {
                if (theLine.StartsWith(valueName)) { check = true; }
                else if (check == true)
                {
                    String line = theLine.Replace("\u0009", "").TrimStart();
                    if (line.StartsWith("-"))
                    {
                        returnValue.Add(line.Substring(1).TrimStart());
                    }
                    else { break; }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Get a value from a file
        /// </summary>
        /// <returns>
        /// Return String
        /// </returns>
        public static String Get(String path, String valueName)
        {
            var lines = File.ReadAllLines(path);
            if (valueName.Substring(valueName.Length - 1, 1) != ":") { valueName = valueName + ":"; }
            foreach (var theLine in lines)
            {
                if (theLine.StartsWith(valueName))
                {
                    String[] value = theLine.Split(new char[] { ':' }, 2);
                    value[1] = value[1].Remove(0, value[1].IndexOf(' ') + 1);
                    return value[1].TrimStart();
                }
            }
            return "error";
        }

        /// <summary>
        /// Set a value from a file
        /// </summary>
        public static void Set(String path, String valueName, String valueReplacement)
        {
            if (valueName.Substring(valueName.Length - 1, 1) != ":") { valueName = valueName + ":"; }
            int count = 0;
            foreach (var theLine in File.ReadAllLines(path))
            {
                if (theLine.StartsWith(valueName))
                {
                    String[] value = theLine.Split(new char[] { ':' }, 2);
                    WolfLib.Files.WriteLine(path, value[0] + ": " + valueReplacement, count);
                    break;
                }
                count++;
            }
        }

        /// <summary>
        /// Check if a value exist from a file
        /// Return true of false
        /// </summary>
        /// <returns>
        /// Return Boolean
        /// </returns>
        public static Boolean Check(String path, String valueName)
        {
            var lines = File.ReadAllLines(path);
            int count = 0;
            if (valueName.Substring(valueName.Length - 1, 1) != ":") { valueName = valueName + ":"; }
            foreach (var theLine in lines) { if (!theLine.StartsWith(valueName)) { count++; } else { break; } }
            if (File.ReadLines(path).Count() != count) { return true; } else { return false; }
        }

        /// <summary>
        /// Delete a value from a file
        /// </summary>
        public static void Delete(String path, String valueName)
        {
            var lines = File.ReadAllLines(path);
            int count = 0;
            if (valueName.Substring(valueName.Length - 1, 1) != ":") { valueName = valueName + ":"; }
            foreach (var theLine in lines) { if (!theLine.StartsWith(valueName)) { count++; } else { WolfLib.Files.DeleteLine(path, count); } }
        }

        /// <summary>
        /// Merge value file
        /// Check wiki for more informations
        /// </summary>
        public static void MergeFile(String oldfile, String newfile)
        {
            var oldfilelines = File.ReadAllLines(oldfile);
            var newfilelines = File.ReadAllLines(newfile);
            foreach (var theLine in oldfilelines)
            {
                if (!theLine.StartsWith("//") && theLine != "")
                {
                    String[] value = theLine.Split(new char[] { ':' }, 2);
                    value[1] = value[1].Remove(0, value[1].IndexOf(' ') + 1);
                    if (Check(newfile, value[0])) { Set(newfile, value[0], value[1]); }
                }
            }
        }
    }
}
