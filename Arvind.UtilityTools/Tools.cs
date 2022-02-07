using System;
using System.Security.Cryptography;
using System.Text;

namespace Arvind.UtilityTools
{
    public static class Tools
    {
        #region(ENCRIPTION/DECRYPTION/HASHED TOOLS)       
        public static string Encrypt(string normalvalue)
        {
            string res = null;
            try
            {
                string passVal = "SeCureD132@#$456@#*%mI";
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                byte[] pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passVal));
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.Key = pwdhash;
                des.Mode = CipherMode.ECB;
                byte[] buff = ASCIIEncoding.ASCII.GetBytes(normalvalue);
                res = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));
            }
            catch { }
            return res;
        }
        public static string Decrypt(string encryptedvalue)
        {
            string res = null;
            try
            {
                string passVal = "SeCureD132@#$456@#*%mI";
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                byte[] pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passVal));
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.Key = pwdhash;
                des.Mode = CipherMode.ECB;
                byte[] buff = Convert.FromBase64String(encryptedvalue);
                res = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));
            }
            catch { }
            return res;
        }
        public static string GetMD5Hash(string name)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(name);
            byte[] ba = md5.ComputeHash(inputBytes);
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        #endregion           

        #region (GET LOCAL DATETIME CLIENT/BROWSER-WISE)

        public static string GetDateTimeLocal(DateTime dDate)
        {
            //Return local datetime
            return TimeZoneInfo.ConvertTime(dDate.AddHours(5).AddMinutes(30), TimeZoneInfo.Local).ToString("dd-MMM-yyyy hh:mm tt");
        }

        public static DateTime GetIndiaStandardTime()
        {
            DateTime dt = new DateTime();
            dt = DateTime.UtcNow;
            TimeSpan ts = new TimeSpan(5, 30, 0);
            return dt + ts;
        }
        #endregion
    }
}
