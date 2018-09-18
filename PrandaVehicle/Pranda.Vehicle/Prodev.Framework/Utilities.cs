using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Prodev.Framework
{
    public class Utilities
    {
        public static string RemoveXmlReservedChars(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                return input.Replace("&", "&#x26;").Replace("<", "&#x3c;").Replace(">", "&#x3e;").Replace("\r", "").Replace("\n", "").Replace("'", "").Replace("''", "").Replace("\"", "");
            }

            return String.Empty;

        }

        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        public static string RemoveXmlReservedCharsXML(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                return input.Replace("&", "&#x26;").Replace("\r", "").Replace("\n", "").Replace("'", "").Replace("''", "").Replace("\"", "");
            }

            return String.Empty;

        }

        public static bool isHasDataColumn(DataColumn column)
        {
            return column != null;
        }

        public static bool isHasDataColumn(DataTable dataTable, string column)
        {
            return dataTable.Columns[column] != null;
        }

        public static bool isDataRowNullValue(DataRow row, string column)
        {
            return row[column] == null;
        }

        public static bool isDataRowEmptyValue(DataTable dataTable, int rowIndex, string column)
        {

            if (dataTable.Columns[column] == null) return true;

            if (dataTable.Rows[rowIndex][column] == null || dataTable.Rows[rowIndex][column].ToString() == "" || dataTable.Rows[rowIndex][column].ToString() == "0")
            {
                return true;
            }
            return false;

        }

        public string getHMAC(string signatureString, string secretKey)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            HMACSHA1 hmac = new HMACSHA1(keyByte);
            byte[] messageBytes = encoding.GetBytes(signatureString);
            byte[] hashmessage = hmac.ComputeHash(messageBytes);
            return ByteArrayToHexString(hashmessage);
        }

        public string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Result = new StringBuilder();
            string HexAlphabet = "0123456789ABCDEF";
            foreach (byte B in Bytes)
            {
                Result.Append(HexAlphabet[(int)(B >> 4)]);
                Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }
            return Result.ToString();
        }

        public static bool isDataRowEmptyValue(DataRow row, string column)
        {
            bool result;
            result = row[column] == null || row[column].ToString() == "";
            return result;
        }

        /// <summary>
        /// Get Country list
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="useflag"></param>
        /// <returns></returns>



        public static string formatAlertMessage(string message)
        {
            return String.Format("<span class='alert-message'>{0}</span>", message);
        }
        public static string formatAlertMessage(string message, string cssClass)
        {
            return String.Format("<span class='{0}'>{1}</span>", cssClass, message);
        }
        public static string formatErrorMessage(string message)
        {
            return formatAlertMessage(message, "error-message");
        }

        public static string getStringValue(string value)
        {
            return _getStringValue(value, null);
        }

        private static string _getStringValue(string value, string defaultValue)
        {
            if (!String.IsNullOrEmpty(value))
            {
                value = value.Replace("andtype2", "&");
                return value.ToString();
            }
            else
            {
                if (defaultValue != null) return defaultValue.ToString();
            }
            return "";
        }
        public static string getStringValue(string value, string defaultValue)
        {
            return _getStringValue(value, defaultValue);
        }

        public static string getSessionTimeOutMessage()
        {
            return String.Format("<span class='alert-message'>{0}</span>", ConfigurationManager.AppSettings["SessionTimeOutMsg"]);
        }

        private static readonly DateTime Jan1st1970 = new DateTime
    (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Encode(Guid guid)
        {
            return System.Convert.ToBase64String(guid.ToByteArray());
        }

        public static DateTime ddMMyyyyHHmmToDateTime(string ddMMyyHHmm)
        {
            DateTime d = new DateTime(Convert.ToInt32(ddMMyyHHmm.Substring(4, 2)) + 2000, Convert.ToInt32(ddMMyyHHmm.Substring(2, 2)), Convert.ToInt32(ddMMyyHHmm.Substring(0, 2)), Convert.ToInt32(ddMMyyHHmm.Substring(6, 2)), Convert.ToInt32(ddMMyyHHmm.Substring(8, 2)), 0);
            return d;
        }

        public static string NumberToThaiBahtText(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            decimal amount;
            try { amount = Convert.ToDecimal(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDecimal(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            if (Convert.ToDecimal(bahtTxt) < 10)
                            {
                                bahtTH = "หนึ่ง";
                            }
                            else
                            {
                                bahtTH += "เอ็ด";
                            }

                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }

        private static string[] ones = { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        private static string[] tens = { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
        private static string[] thous = { "HUNDRED", "THOUSAND", "MILLION", "BILLION", "TRILLION", "QUADRILLION" };
        public static string ToWords(decimal number)
        {
            if (number < 0) return "negative " + ToWords(Math.Abs(number));

            int intPortion = (int)number;
            int decPortion = (int)((number - intPortion) * (decimal)100);
            string _txtReturn = "ZERO BAHT";
            if (ToWords(intPortion) != "") _txtReturn = ToWords(intPortion) + " BAHT";
            if (decPortion > 0) _txtReturn = _txtReturn + " AND " + ToWords(decPortion) + " SATANG";
            string.Format("{0} BAHT and {1} SATANG", ToWords(intPortion), ToWords(decPortion));
            return _txtReturn;
        }
        private static string ToWords(int number, string appendScale = "")
        {
            string numString = "";
            if (number < 100)
            {
                if (number == 0)
                {

                }
                else if (number < 20)
                    numString = ones[number];
                //if (number == 0) numString = "";
                else
                {
                    numString = tens[number / 10];
                    if ((number % 10) > 0)
                        numString += "-" + ones[number % 10];
                }
            }
            else
            {
                int pow = 0;
                string powStr = "";

                if (number < 1000) // number is between 100 and 1000
                {
                    pow = 100;
                    powStr = thous[0];
                }
                else // find the scale of the number
                {
                    int log = (int)Math.Log(number, 1000);
                    pow = (int)Math.Pow(1000, log);
                    powStr = thous[log];
                }

                numString = string.Format("{0} {1}", ToWords(number / pow, powStr), ToWords(number % pow)).Trim();
            }

            return string.Format("{0} {1}", numString, appendScale).Trim();

        }
    }
}
