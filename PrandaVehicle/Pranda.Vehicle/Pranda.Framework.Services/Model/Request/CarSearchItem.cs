using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Request
{
    public class CarSearchItem
    {
        public decimal Status { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentNo { get; set; }
        public string Priority { get; set; }
        public string Department { get; set; }
        public string JobType { get; set; }
        public decimal RequestHeaderID { get; set; }
        public decimal? MilesIn { get; set; }
        public decimal? MilesOut { get; set; }
        public DateTime? VehicleTimeIn { get; set; }
        public DateTime? VehicleTimeOut { get; set; }
        public string VehicleCode { get; set; }
        public string DriverName { get; set; }
        public string DriverCode { get; set; }
    }
}
