using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prodev.Framework
{
    public enum DateInterval
    {
        Year,
        Month,
        Weekday,
        Day,
        Hour,
        Minute,
        Second
    }
    public enum DateFormat
    {
        EN, TH
    }
    public enum DateFormatInfo
    {
        DDMMYYYY,
        MMDDYYYY,
        DDDDMMMMYYYY,
        DDMMMMYYYY,
        MMMMDDYYYY,
        YYYYMMDD,
        DDMMMYYYY,
        DDMMMYY
    }

    public class DateTimeUtil
    {
        private static string[] MonthFormat3 = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

        public static string getMothFormat3(int month)
        {
            return MonthFormat3[month - 1];
        }
        public static int getMonthNumber(string month3Char)
        {
            return Array.IndexOf(MonthFormat3, month3Char.ToString()) + 1;
        }

        /// <summary>
        /// Get Current day format DD-MM-YYYY
        /// Modified on:25-07-2011
        /// </summary>
        /// <param name="cultureFormat"></param>
        /// <returns></returns>
        public static string getCurrentDDMMYYYY(DateFormat cultureFormat)
        {
            string year = DateTime.Today.Year.ToString();
            if (cultureFormat == DateFormat.EN)
            {
                DateTimeUtil.getYearEN(DateTime.Today.Year);
            }
            else
            {
                DateTimeUtil.getYearTH(DateTime.Today.Year);
            }

            return (DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + year);
        }
        /// <summary>
        /// Get current day and format
        /// Create On:25-07-2011
        /// </summary>
        /// <param name="format"></param>
        /// <param name="cultureFormat"></param>
        /// <returns></returns>
        public static string getCurrentDay(DateFormatInfo format, DateFormat cultureFormat)
        {
            string test = "aaa";
            return DateTimeUtil.convertDateFormat(DateTimeUtil.getCurrentDDMMYYYY(cultureFormat), DateFormatInfo.DDMMYYYY, format);
        }
        /// <summary>
        /// function for calculate diff date
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {

            TimeSpan ts = ts = date2 - date1;

            switch (interval)
            {
                case DateInterval.Year:
                    return date2.Year - date1.Year;
                case DateInterval.Month:
                    return (date2.Month - date1.Month) + (12 * (date2.Year - date1.Year));
                case DateInterval.Weekday:
                    return Fix(ts.TotalDays) / 7;
                case DateInterval.Day:
                    return Fix(ts.TotalDays);
                case DateInterval.Hour:
                    return Fix(ts.TotalHours);
                case DateInterval.Minute:
                    return Fix(ts.TotalMinutes);
                default:
                    return Fix(ts.TotalSeconds);
            }
        }

        private static long Fix(double Number)
        {
            if (Number >= 0)
            {
                return (long)Math.Floor(Number);
            }
            return (long)Math.Ceiling(Number);
        }

        public static DateTime getDateTime(string value)
        {
            string day = "";
            string month = "";
            string year = "";

            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(value);

            day = thisDay[0];
            month = thisDay[1];
            year = thisDay[2];

            if (int.Parse(year) > 2500)
            {
                year = getYearEN(int.Parse(year));
            }

            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));

        }

        public static string getDateYYYYMMDD(string value)
        {
            return getDateYYYYMMDD(value, "/");
        }

        public static string getDateYYYYMMDD(string value, string splitValue)
        {
            string day = "";
            string month = "";
            string year = "";

            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(value);

            day = thisDay[0];
            month = thisDay[1];
            year = thisDay[2];

            if (int.Parse(year) > 2500)
            {
                year = getYearEN(int.Parse(year));
            }

            return (year + splitValue + month + splitValue + day);
        }


        public static string getDateDDMMYYYY(string value)
        {
            string day = "";
            string month = "";
            string year = "";
            if (value == "")
            {
                return "";
            }

            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(value);

            day = thisDay[1];
            month = thisDay[0];
            year = thisDay[2];

            if (int.Parse(year) > 2500)
            {
                year = getYearEN(int.Parse(year));
            }
            if (int.Parse(day) < 10 && day.Length == 1)
                day = "0" + day;
            if (int.Parse(month) < 10 && day.Length == 1)
                month = "0" + month;

            return day + "/" + month + "/" + year;
        }

        public static string formatDDMMYYYYEN(string value)
        {
            string day = "";
            string month = "";
            string year = "";
            if (value == "")
            {
                return "";
            }

            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(value);

            day = thisDay[0];
            month = thisDay[1];
            year = thisDay[2];

            if (int.Parse(year) > 2500)
            {
                year = getYearEN(int.Parse(year));
            }

            return day + "/" + month + "/" + year;

        }


        public static string formatDDMMYYYY(string value)
        {
            string day = "";
            string month = "";
            string year = "";
            if (value == "")
            {
                return "";
            }
            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(value);

            day = thisDay[0];
            month = thisDay[1];
            year = thisDay[2];

            return day + "/" + month + "/" + year;

        }
        public static string convertDateFormat(string value, DateFormatInfo inputFormat, DateFormatInfo convertTo)
        {
            if (value == "")
            {
                return "";
            }
            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(value);
            string[] tempDay = { "", "", "" };

            switch (inputFormat)
            {

                case DateFormatInfo.MMDDYYYY:
                    tempDay[0] = thisDay[1];
                    tempDay[1] = thisDay[0];
                    tempDay[2] = thisDay[2];
                    return DateTimeUtil.setConvertDate(tempDay, convertTo);
                case DateFormatInfo.DDMMYYYY:
                    return DateTimeUtil.setConvertDate(thisDay, convertTo);
                case DateFormatInfo.DDMMMYYYY:
                    return DateTimeUtil.setConvertDate(thisDay, convertTo);
                case DateFormatInfo.DDMMMYY:
                    tempDay[0] = value.Substring(0, 2);//Day
                    tempDay[1] = getMonthNumber(value.Substring(2, 3)).ToString(); //Month
                    tempDay[2] = String.Format("20{0}", value.Substring(5, 2));
                    return DateTimeUtil.setConvertDate(tempDay, convertTo);
                case DateFormatInfo.YYYYMMDD:
                    tempDay[0] = thisDay[2];
                    tempDay[1] = thisDay[1];
                    tempDay[2] = thisDay[0];
                    return DateTimeUtil.setConvertDate(tempDay, convertTo);

            }

            return DateTimeUtil.setConvertDate(thisDay, convertTo);


        }
        public static string setConvertDate(string[] dateInput, DateFormatInfo outputFormat)
        {

            if (int.Parse(dateInput[2]) > 2500)
            {
                dateInput[2] = getYearEN(int.Parse(dateInput[2]));
            }
            switch (outputFormat)
            {
                case DateFormatInfo.DDMMYYYY:
                    return dateInput[0] + "/" + dateInput[1] + "/" + dateInput[2];
                case DateFormatInfo.MMDDYYYY:
                    return dateInput[1] + "/" + dateInput[0] + "/" + dateInput[2];
                case DateFormatInfo.DDMMMYYYY:
                    return dateInput[0] + " " + getMothFormat3(int.Parse(dateInput[1])) + " " + dateInput[2];
                case DateFormatInfo.DDMMMYY:
                    return dateInput[0] + " " + getMothFormat3(int.Parse(dateInput[1])) + " " + dateInput[2].Substring(2, 2);
            }
            return dateInput[0] + "/" + dateInput[1] + "/" + dateInput[2];
        }

        private static string formatFirstZero(string input)
        {
            if (input.Length <= 1)
            {
                input = "0" + input;
            }
            return input;
        }
        private static string formatFirstZero(int input)
        {
            if (input < 10)
            {
                return "0" + input.ToString();
            }
            return input.ToString();
        }

        public static string getDateMMDDYYYY(string value)
        {
            string day = "";
            string month = "";
            string year = "";

            if (value == "")
            {
                return "";
            }

            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(value);

            day = formatFirstZero(thisDay[0]);
            month = formatFirstZero(thisDay[1]);
            year = thisDay[2];

            if (int.Parse(year) > 2500)
            {
                year = getYearEN(int.Parse(year));
            }

            return month + "/" + day + "/" + year;
        }
        /// <summary>
        /// Get current year (Englist format)
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string getCurrentYear(DateFormat format)
        {
            if (format == DateFormat.EN)
            {
                return getYearEN(DateTime.Now.Year);
            }
            else
            {
                return getYearTH(DateTime.Now.Year);
            }
        }
        /// <summary>
        /// Get year enlish format
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string getYearEN(int year)
        {

            if (year > 2500)
            {
                return (year - 543).ToString();
            }
            else
            {
                return year.ToString();
            }
        }
        /// <summary>
        /// Get year enlish format
        /// </summary>
        /// <param name="DateDDMMYYYY"></param>
        /// <returns></returns>
        public static string getYearEN(string DateDDMMYYYY)
        {
            string year = "";

            if (DateDDMMYYYY == "")
            {
                return "";
            }

            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(DateDDMMYYYY);
            year = getYearEN(int.Parse(thisDay[2]));

            return year;

        }
        /// <summary>
        /// Get year enlish format
        /// </summary>
        /// <param name="DateDDMMYYYY"></param>
        /// <returns></returns>
        public static string getYearTH(int year)
        {

            if (year < 2500)
            {
                return (year + 543).ToString();
            }
            else
            {
                return year.ToString();
            }
        }
        /// <summary>
        /// Get month name(English format)
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string getMonthName(string month)
        {
            switch (month)
            {
                case "01":
                case "1":
                    return "January";

                case "02":
                case "2":
                    return "February";
                case "03":
                case "3":
                    return "March";
                case "04":
                case "4":
                    return "April";
                case "05":
                case "5":
                    return "May";
                case "06":
                case "6":
                    return "June";
                case "07":
                case "7":
                    return "July";
                case "08":
                case "8":
                    return "August";
                case "09":
                case "9":
                    return "September";
                case "10":
                    return "October";
                case "11":
                    return "November";
                case "12":
                    return "December";
            }
            return "error";

        }
        /// <summary>
        /// Get month name (Thai format)
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string getMonthThaiName(string month)
        {
            switch (month)
            {
                case "01":
                case "1":
                    return "มกราคม";
                case "02":
                case "2":
                    return "กุมภาพันธ์";
                case "03":
                case "3":
                    return "มีนาคม";
                case "04":
                case "4":
                    return "เมษายน";
                case "05":
                case "5":
                    return "พฤษภาคม";
                case "06":
                case "6":
                    return "มิถุนายน";
                case "07":
                case "7":
                    return "กรกฎาคม";
                case "08":
                case "8":
                    return "สิงหาคม";
                case "09":
                case "9":
                    return "กันยายน";
                case "10":
                    return "ตุลาคม";
                case "11":
                    return "พฤศจิกายน";
                case "12":
                    return "ธันวาคม";
            }
            return "error";

        }

        /// <summary>
        /// Get day count with out holiday
        /// </summary>
        /// <param name="dtStartDate"></param>
        /// <param name="dtEndDate"></param>
        /// <returns></returns>
        public static int getDayCountWithOutHoliday(DateTime dtStartDate, DateTime dtEndDate)
        {
            int intCnt = 0;

            while (dtStartDate <= dtEndDate)
            {
                if (dtStartDate.DayOfWeek != DayOfWeek.Saturday && dtStartDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    intCnt += 1;
                }

                dtStartDate = dtStartDate.AddDays(1);
            }


            return intCnt;
        }

        /// <summary>
        /// Get day count
        /// </summary>
        /// <param name="dtStartDate"></param>
        /// <param name="dtEndDate"></param>
        /// <returns></returns>
        public static int getDayCount(DateTime dtStartDate, DateTime dtEndDate)
        {
            int intCnt = 0;
            while (dtStartDate <= dtEndDate)
            {
                intCnt += 1;
                dtStartDate = dtStartDate.AddDays(1);
            }

            return intCnt;
        }
        /// <summary>
        /// format date
        /// </summary>
        /// <param name="date_DDMMYYYY"></param>
        /// <param name="convertformat"></param>
        /// <param name="convertformatinfo"></param>
        /// <param name="spaceformat"></param>
        /// <returns></returns>
        public static string getDateFormat(string date_DDMMYYYY, DateFormat convertformat, DateFormatInfo convertformatinfo, string spaceformat)
        {

            if (String.IsNullOrEmpty(date_DDMMYYYY)) return "";

            Regex mychar = new Regex("/");
            string[] thisDay = mychar.Split(date_DDMMYYYY);

            string result = "";

            if (String.IsNullOrEmpty(spaceformat)) spaceformat = "/";

            string yearTH = getYearTH(int.Parse(thisDay[2]));

            if (thisDay[0].Length > 1)
            {
                if (thisDay[0].Substring(0, 1) == "0")
                {
                    thisDay[0] = thisDay[0].Substring(1, 1);
                }
            }

            switch (convertformatinfo)
            {
                case DateFormatInfo.DDMMYYYY:
                    if (convertformat == DateFormat.EN)
                    {
                        result = String.Format("{0}{3}{1}{3}{2}", thisDay[0], thisDay[1], thisDay[2], spaceformat);
                    }
                    else
                    {
                        result = String.Format("{0}{3}{1}{3}{2}", thisDay[0], thisDay[1], yearTH, spaceformat);
                    }
                    break;
                case DateFormatInfo.DDMMMMYYYY:
                    if (convertformat == DateFormat.EN)
                    {
                        result = String.Format("{0}{3}{1}{3}{2}", thisDay[0], getMonthName(thisDay[1].ToString()), thisDay[2], spaceformat);
                    }
                    else
                    {
                        result = String.Format("{0}{3}{1}{3}{2}", thisDay[0], getMonthThaiName(thisDay[1].ToString()), yearTH, spaceformat);
                    }
                    break;
                case DateFormatInfo.MMMMDDYYYY:
                    if (convertformat == DateFormat.EN)
                    {
                        result = String.Format("{1}{3}{0}, {2}", thisDay[0], getMonthName(thisDay[1].ToString()), thisDay[2], spaceformat);
                    }
                    else
                    {
                        result = String.Format("{1}{3}{0}{3}{2}", thisDay[0], getMonthThaiName(thisDay[1].ToString()), yearTH, spaceformat);
                    }
                    break;

            }

            return result;

        }
    }
}
