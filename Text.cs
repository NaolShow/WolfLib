using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WolfLib
{
    public class Text
    {

        /**
         *  Developed by NaolShow (Loan.J)
         *  Sources and DLL on github.com
         *  https://github.com/NaolShow/WolfLib
         *  
         **/

        // Encryption
        public static string encryptToMD5(String strText)
        {
            try
            {
                Byte[] buffer;
                buffer = Encoding.Default.GetBytes(strText);
                MD5CryptoServiceProvider check = new MD5CryptoServiceProvider();
                Byte[] somme;
                somme = check.ComputeHash(buffer);
                string ret = "";

                foreach (byte a in somme)
                {
                    if (a < 16) ret += "0" + a.ToString("X");
                    else ret += a.ToString("X");
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // /!\ KEY WITH 8Chars !
        public static string decryptFromB64(String stringToDecrypt, string key)
        {
            try
            {
                byte[] ResultBytes = Convert.FromBase64String(stringToDecrypt);
                byte[] KeyBytes = Encoding.UTF8.GetBytes(key);
                DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();
                Crypto.Key = KeyBytes;
                Crypto.IV = KeyBytes;
                ICryptoTransform Icrypto = Crypto.CreateDecryptor();
                byte[] data = Icrypto.TransformFinalBlock(ResultBytes, 0, ResultBytes.Length);
                return Encoding.UTF8.GetString(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // /!\ KEY WITH 8Chars !
        public static string encryptToB64(String stringToEncrypt, string key)
        {
            try
            {
                byte[] TextBytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                byte[] KeyBytes = Encoding.UTF8.GetBytes(key);
                DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();
                Crypto.Key = KeyBytes;
                Crypto.IV = KeyBytes;
                ICryptoTransform Icrypto = Crypto.CreateEncryptor();
                byte[] ResultBytes = Icrypto.TransformFinalBlock(TextBytes, 0, TextBytes.Length);
                return Convert.ToBase64String(ResultBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
