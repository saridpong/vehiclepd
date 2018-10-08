using Pranda.Framework.Services.Model.CarType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Vehicle
{
    public class VehicleItem
    {
   
        public decimal VehicleID { get; set; }

       
        public string VehicleCode { get; set; }

        public string VehicleBrand { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleEngine { get; set; }
        public string VehicleFuelType { get; set; }


        public string VehicleDate { get; set; }


        public decimal? VehicleCost { get; set; }


        public string VehicleTypeCode { get; set; }
        public string VehicleTypeName { get; set; }

        public int? VehicleYear { get; set; }

   
        public string VehicleAsset { get; set; }

      
        public string VehicleInsurance { get; set; }

  
        public string VehicleInsuranceType { get; set; }

        public DateTime? UpdateDate { get; set; }


        public string UpdateBy { get; set; }

      
        public decimal Status { get; set; }
        public CarTypeItem CarType { get; set; }
    }
}
