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

        private String RasuPath { get; set; }
        private String RasuFileContent { get; set; }
        private Boolean IsFile { get; set; }

        /// <summary>
        /// You must instantiate this object to gain access to the methods
        /// You can put a file or text RASU
        /// </summary>
        /// <param name="RasuFilePath">RASU file or text</param>
        public Rasu(String RasuFileOrRasuText)
        {
            if (File.Exists(RasuFileOrRasuText)) { this.RasuPath = RasuFileOrRasuText; this.IsFile = true; } else { this.RasuFileContent = RasuFileOrRasuText; this.IsFile = false; }
            this.ReloadFile();
        }

        /// <summary>
        /// Returns the path of the RASU file (which was specified when setting the RASU variable)
        /// If the RASU object does not use a file, this function will return: "This RASU object do not use a file"
        /// </summary>
        /// <returns>String (RASU File path)</returns>
        public String GetFilePath()
        {
            if (IsFile == true)
            {
                return this.RasuPath;
            }
            else
            {
                return "This RASU object don't use a file";
            }
        }

        /// <summary>
        /// Returns the contents of the RASU file or text (which was specified when setting the RASU variable)
        /// </summary>
        /// <returns>String (RASU File content</returns>
        public String GetFileContent()
        {
            return this.RasuFileContent;
        }

        /// <summary>
        /// Reload the contents of the file in the rasu variable (required to access file changes)
        /// This function only works if the value specified when creating the object was a file.
        /// If it was not a file, but text, you must reinstate the object
        /// </summary>
        public void ReloadFile()
        {
            if (this.IsFile == true)
            {
                RasuFileContent = File.ReadAllText(RasuPath);
            }
        }

        /// <summary>
        /// Apply changes to the file (writes the changes to the file)
        /// This function only works if the value specified when creating the object was a file.
        /// If it was not a file, but text, you must reinstate the object
        /// </summary>
        public void SaveFile()
        {
            if (this.IsFile == true)
            {
                File.WriteAllText(this.RasuPath, this.RasuFileContent);
            }
        }

        #region "Rasu functions"

        /// <summary>
        /// Returns a RASU value from the RASU file or text (which was specified when setting the RASU variable)
        /// </summary>
        /// <param name="valueName">RASU Value name</param>
        /// <returns>String RASU value</returns>
        public String Get(String valueName)
        {
            String[] lines = this.RasuFileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
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
            return String.Format("Error RASU Value {0} don't exist", valueName);
        }

        /// <summary>
        /// Replace a RASU value with a string (or other)
        /// If the RASU object uses a file, you will need to use the Rasu.SaveFile() method
        /// after using this function (for the changes to be made in the file)
        /// 
        /// If the RASU object is text, you can use the Rasu.GetFileContent() method to get the new RASU text
        /// </summary>
        /// <param name="valueName">RASU Value name</param>
        /// <param name="valueReplacement">Value replacement for RASU Value</param>
        public void Set(String valueName, String valueReplacement)
        {
            String[] lines = this.RasuFileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int count = 0;
            foreach (var theLine in lines)
            {
                if (theLine.StartsWith(valueName))
                {
                    String[] value = theLine.Split(new char[] { ':' }, 2);
                    lines[count] = value[0] + ": " + valueReplacement;
                    break;
                }
                count++;
            }
            this.RasuFileContent = String.Join(Environment.NewLine, lines);
        }


        /// <summary>
        /// Check if the RASU value exists
        /// </summary>
        /// <param name="valueName">RASU Value name</param>
        /// <returns>
        /// Returns true if the value exists, and false if the value does not exist
        /// </returns>
        public Boolean Check(String valueName)
        {
            String[] lines = this.RasuFileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var theLine in lines)
            {
                if (theLine.StartsWith(valueName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Deletes a RASU value
        /// 
        /// If the RASU object uses a file, you will need to use the Rasu.SaveFile() method
        /// after using this function (for the changes to be made in the file)
        /// </summary>
        /// <param name="valueName">RASU Value name</param>
        public void Delete(String valueName)
        {
            String[] lines = this.RasuFileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int count = 0;
            foreach (var theLine in lines)
            {
                if (theLine.StartsWith(valueName))
                {
                    var list = lines.ToList();
                    list.RemoveAt(count);
                    this.RasuFileContent = String.Join(Environment.NewLine, list.ToArray());
                    break;
                }
                count++;
            }
        }

        /// <summary>
        /// This function will copy the values of the object, to transfer them to a rasu file
        /// 
        /// If the targeted RASU object uses a file, you will need to use the Rasu.SaveFile() method
        /// after using this function (for the changes to be made in the file)
        /// </summary>
        /// <param name="RasuFile">File(or text) where values will be copied</param>
        public void MergeFile(Rasu RasuFile)
        {
            String[] lines = this.RasuFileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var theLine in lines)
            {
                if (!theLine.StartsWith("//") && theLine != "")
                {
                    String[] value = theLine.Split(new char[] { ':' }, 2);
                    value[1] = value[1].Remove(0, value[1].IndexOf(' ') + 1);
                    RasuFile.Set(value[0], value[1]);
                }
            }
        }

        #endregion

        // THIS FUNCTION WILL BE REACTIVATED WITH THE NEXT UPDATE
        //
        //public static List<String> GetList(String pathOrText, String valueName)
        //{
        //    String[] lines = null;
        //    if (File.Exists(pathOrText)) { lines = File.ReadAllLines(pathOrText); }
        //    else { lines = pathOrText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries); }

        //    List<String> returnValue = new List<String>();
        //    if (valueName.Substring(valueName.Length - 1, 1) != ":") { valueName = valueName + ":"; }
        //    foreach (var theLine in lines)
        //    {
        //        if (theLine.StartsWith(valueName))
        //        {
        //            String line = theLine.Replace("\u0009", "").TrimStart();
        //            if (line.StartsWith("-"))
        //            {
        //                returnValue.Add(line.Substring(1).TrimStart());
        //            }
        //            else { break; }
        //        }
        //    }
        //    return returnValue;
        //}
    }
}
