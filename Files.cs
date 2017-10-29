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

        // /!\ KEY WITH 8Chars !
        public static void encryptFile(string inputFile, string outputFile, string key)
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
        public static void decryptFile(string inputFile, string outputFile, string key)
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

    }
}
