using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prodev.Framework.Security
{
    public class Cryptography
    {
        private byte[] key = { };
        private byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
        private static string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];

        //log4net logger.
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);




        public static string Key
        {
            set
            {
                EncryptionKey = value;
            }
        }

        public string Decrypt(string stringToDecrypt)
        {
            return Decrypt(stringToDecrypt, EncryptionKey);
        }

        public string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            if (stringToDecrypt == null)
            {
                return "";
            }

            byte[] inputByteArray = new byte[stringToDecrypt.Length];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                throw new UrlCryptoException(string.Format("Unable to Decrypt({0})", stringToDecrypt), e);
            }
        }

        public string Encrypt(string stringToEncrypt)
        {
            return Encrypt(stringToEncrypt, EncryptionKey);
        }

        public string Encrypt(string stringToEncrypt, string SEncryptionKey)
        {
            if (stringToEncrypt == null) return "";
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                log.Warn(string.Format("Encrypt::Exception {0}/{1}", stringToEncrypt, SEncryptionKey), e);
                return e.Message;
            }

        }

        private string ByteArray2Hex(byte[] src)
        {
            string hex = "";
            for (int i = 0; i < src.Length; i++)
            {
                hex += src[i].ToString("X");
            }
            return hex;
        }

        public string EncryptSHA(string strToEncrypt)
        {
            return EncryptSHA(strToEncrypt, DateTime.Now.ToString("#dd#yyyy#MM#"));
        }

        public string EncryptSHA(string strToEncrypt, string strDateTime)
        {
            string result = "";

            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                HMACSHA1 h = new HMACSHA1(encoding.GetBytes(EncryptionKey + strDateTime));
                byte[] tmInput = encoding.GetBytes(strToEncrypt);
                byte[] tmResult = h.ComputeHash(tmInput);
                result = ByteArray2Hex(tmResult);
            }
            catch (Exception ex)
            {
                //log.Warn(string.Format("EncryptSHA::Exception {0}/{1}",strToEncrypt, strDateTime), ex);
                result = ex.Message;
            }

            return result;
        }

        public string[] EncryptSHAAntiFraud(string strToEncrypt, string strDateTime)
        {
            ArrayList resultList = new ArrayList();
            string totHour = ConfigurationManager.AppSettings["NokAir.AntiFraudHour"];
            int nHour = 0;
            int tmHour = 0;
            if ((totHour != null) && (totHour.Trim().Length > 0))
            {
                try
                {
                    nHour = Convert.ToInt32(totHour);
                }
                catch (Exception)
                {
                    nHour = 3;
                }
            }
            else
            {
                nHour = 3; // Default 3
            }
            for (int i = 0; i < nHour; i++)
            {
                tmHour = DateTime.Now.Hour + i;
                resultList.Add(EncryptSHA(strToEncrypt, DateTime.Now.ToString("#dd#yyyy#MM#") + Convert.ToString(tmHour) + "#"));
            }

            string[] tmArr = new string[resultList.Count];
            return (string[])resultList.ToArray(tmArr.GetType());
        }

        /// <summary>
        /// Compute the hash value by MD5
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string MD5ComputeHash(string text)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            ASCIIEncoding encoder = new ASCIIEncoding();
            hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(text));
            byte[] datas = System.Text.ASCIIEncoding.ASCII.GetBytes(encoder.GetString(hashedDataBytes));
            return Convert.ToBase64String(datas);


        }

        public Cryptography()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
