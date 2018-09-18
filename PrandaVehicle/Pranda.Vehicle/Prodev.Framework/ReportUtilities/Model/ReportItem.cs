using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Prodev.Framework.ReportUtilities.Model
{
    public class ReportItem
    {
        public static string BOOKACCOUNT_CONTROL_COMMISSION_REPORT_PATH = "/TADocument/BookAccountControlCommission";
        public static string BOOKACCOUNT_CONTROL_COMMISSION_REPORT_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\BookAccountControlCommission.rdlc");
        public static string CASHDEPOSIT_REPORT_PATH = "/TADocument/CashReceiptReport";
        public static string CASHDEPOSIT_REPORT_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\CashReceiptReport.rdlc");
        public static string WITHHOLDINGTAX_REPORT_PATH = "/TADocument/TAHDY";
        public static string WITHHOLDINGTAX_REPORT_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\TAHDY.rdlc");
        public static string WITHHOLDINGTAX1PAGE_REPORT_PATH = "/TADocument/TAHDY1";
        public static string WITHHOLDINGTAX1PAGE_REPORT_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\TAHDY1Page.rdlc");
        public static string BOOKING_PAYMENT_INTERFACE_REPORT_PATH = "/TADocument/BookingPaymentInterface";
        public static string BOOKING_PAYMENT_INTERFACE_REPORT_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\BookingPaymentInterface.rdlc");
        public static string BOOKING_ACCOUNT_TOTUP_INTERFACE_REPORT_PATH = "/TADocument/BookAccountTopupInterfaceReport";
        public static string BOOKING_ACCOUNT_TOTUP_INTERFACE_REPORT_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\BookAccountTopupInterfaceReport.rdlc");
        public static string BOOKING_DETAILS_PATH = "/TADocument/BookingDetails";
        public static string BOOKING_DETAILS_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\BookingDetails.rdlc");
        public static string CONFIRMED_PAYMENT_BOOKING_PATH = "/TADocument/ConfirmedPaymentBooking";
        public static string CONFIRMED_PAYMENT_BOOKING_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\ConfirmedPaymentBooking.rdlc");
        public static string THIRD_PARTY_PAYMENT_TRANSACTION_PATH = "/TADocument/ThirdPartyPaymentTransaction";
        public static string THIRD_PARTY_PAYMENT_TRANSACTION_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\ThirdPartyPaymentTransaction.rdlc");
        public static string BOOKING_SUMMARY_PATH = "/TADocument/BookingSummary";
        public static string BOOKING_SUMMARY_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\BookingSummary.rdlc");
        public static string BOOK_ACCOUNT_TRANSACTION_PATH = "/TADocument/BookAccountTransaction";
        public static string BOOK_ACCOUNT_TRANSACTION_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\BookAccountTransaction.rdlc");
        public static string BOOKING_PAYMENT_NUMBER_PATH = "/TADocument/BookingPaymentNumber";
        public static string BOOKING_PAYMENT_NUMBER_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\BookingPaymentNumber.rdlc");
        public static string BOOKING_METASEARCH_LOCAL_PATH = HttpContext.Current.Server.MapPath("~/" + @"Reports\MetaSearchReport.rdlc");

        public ReportItem()
        {
            this.ReportServerUrl = ConfigurationManager.AppSettings["ReportingServer"];
            this.ReportServerUserName = ConfigurationManager.AppSettings["ReportingUser"];
            this.ReportServerPassword = ConfigurationManager.AppSettings["ReportingPass"];
            this.ReportServerDomain = ConfigurationManager.AppSettings["ReportingDomain"];
            this.Credencials = new ReportCredencials
            {
                CredencialName = "Datasource1",
                CredencialUserName = ConfigurationManager.AppSettings["UserID"],
                CredencialPassword = ConfigurationManager.AppSettings["PWD"],
            };
            DataSources = new List<ReportDataSource>();
        }

        public string ReportServerUrl { get; set; }
        public string ReportServerUserName { get; set; }
        public string ReportServerPassword { get; set; }
        public string ReportServerDomain { get; set; }
        public string ReportPath { get; set; }
        public ReportOutputFormat OutputFormat { get; set; }
        public List<ReportParameterItem> Params { get; set; }
        public ReportCredencials Credencials { get; set; }
        public List<ReportDataSource> DataSources { get; set; }

        public string GetOutputFormat()
        {
            if (OutputFormat == ReportOutputFormat.HTML)
            {
                return "html";
            }
            else if (OutputFormat == ReportOutputFormat.PDF)
            {
                return "pdf";
            }
            else
            {
                return "excel";
            }
        }
        public string GetMediaTypeHeader()
        {
            if (OutputFormat == ReportOutputFormat.HTML)
            {
                return "text/html";
            }
            else if (OutputFormat == ReportOutputFormat.PDF)
            {
                return "application/pdf";
            }
            else
            {
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
        }
    }
    public enum ReportOutputFormat
    {
        EXCEL = 1,
        PDF = 2,
        HTML = 3
    }

    public class ReportParameterItem
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
    }

    public class ReportCredencials
    {
        public string CredencialName { get; set; }
        public string CredencialUserName { get; set; }
        public string CredencialPassword { get; set; }
    }
}
