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

        public static void RemoveLine(String path, int line)
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

        // Get a value (myvaluename: myvalue)
        public static String GetValue(String path, String valueName)
        {
            var lines = File.ReadAllLines(path);
            if (valueName.Substring(valueName.Length - 1, 1) != ":")
            {
                valueName = valueName + ":";
            }
            foreach (var theLine in lines)
            {
                if (theLine.StartsWith(valueName))
                {
                    String[] value = theLine.Split(new char[] { ':' }, 2);
                    value[1] = value[1].Remove(0, value[1].IndexOf(' ') + 1);
                    return value[1];
                }
            }
            return "error";
        }

        // Replace value (myvaluename: myvalue)
        public static void SetValue(String path, String valueName, String valueReplacement)
        {
            if (valueName.Substring(valueName.Length - 1, 1) != ":")
            {
                valueName = valueName + ":";
            }
            int count = 0;
            foreach (var theLine in File.ReadAllLines(path))
            {
                if (theLine.StartsWith(valueName))
                {
                    String[] value = theLine.Split(new char[] { ':' }, 2);
                    WolfLib.Files.WriteLine(path, value[0] + ": " + valueReplacement, count);
                }
                count++;
            }
        }

        // /!\ KEY WITH 8Chars !
        public static void EncryptFile(String inputFile, String outputFile, String key)
        {

            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] byteKey = UE.GetBytes(key);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(byteKey, byteKey),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // /!\ KEY WITH 8Chars !
        public static void DecryptFile(String inputFile, String outputFile, String key)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] byteKey = UE.GetBytes(key);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(byteKey, byteKey),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // /!\ KEY WITH 8Chars !
        public void EncryptFolder(String inputFolder, String outputFolder, String key)
        {
            try
            {
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }
                foreach (String file in Directory.GetFiles(inputFolder, "*", SearchOption.AllDirectories))
                {
                    String fileName = file.Replace(inputFolder, "");
                    EncryptFile(inputFolder + fileName, outputFolder + fileName, key);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // /!\ KEY WITH 8Chars !
        public void DecryptFolder(String inputFolder, String outputFolder, String key)
        {
            try
            {
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }
                foreach (String file in Directory.GetFiles(inputFolder, "*", SearchOption.AllDirectories))
                {
                    String fileName = file.Replace(inputFolder, "");
                    DecryptFile(inputFolder + fileName, outputFolder + fileName, key);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
