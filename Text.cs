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

        public static string EncryptToMD5(String stringToEncrypt)
        {
            try
            {
                Byte[] buffer;
                buffer = Encoding.Default.GetBytes(stringToEncrypt);
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
        public static string DecryptFromB64(String stringToDecrypt, String key)
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
        public static string EncryptToB64(String stringToEncrypt, String key)
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

        public static String EncryptToBinary(String stringToEncrypt)
        {
            try
            {
                StringBuilder stringBuild = new StringBuilder();
                foreach (char L in stringToEncrypt.ToCharArray())
                {
                    stringBuild.Append(Convert.ToString(L, 2).PadLeft(8, '0'));
                }

                return stringBuild.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DecryptFromBinary(String stringToDecrypt)
        {
            try
            {
                stringToDecrypt = stringToDecrypt.Replace(" ", "");
                List<Byte> list = new List<Byte>();

                for (int i = 0; i < stringToDecrypt.Length; i += 8)
                {
                    String t = stringToDecrypt.Substring(i, 8);

                    list.Add(Convert.ToByte(t, 2));
                }

                return Encoding.UTF8.GetString(list.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
