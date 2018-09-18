using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pranda.Framework.Services.Manager
{
    public class BaseManager
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["PrandaVehicleDB"].ConnectionString;
        public static string ERROR = "ERROR";
        public string BaseUrl
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                    HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
            }
        }
        public string SessionID
        {
            get
            {
                return HttpContext.Current.Session.SessionID;
            }
        }

        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
