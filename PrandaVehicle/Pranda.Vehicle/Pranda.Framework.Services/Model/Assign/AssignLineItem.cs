using Pranda.Framework.Services.Model.Driver;
using Pranda.Framework.Services.Model.ForUse;
using Pranda.Framework.Services.Model.Location;
using Pranda.Framework.Services.Model.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Assign
{
    public class AssignLineItem
    {
        public decimal AssignHeaderID { get; set; }
        public decimal AssignLineID { get; set; }
        public string AssignLineDescription { get; set; }
        public PlaceItem Place { get; set; }
        public ForUseItem ForUse { get; set; }
        public DriverItem Driver { get; set; }
        public LocationItem Route { get; set; }
        public string ContactName { get; set; }
        public decimal? Amount { get; set; }
        public int? Quantity { get; set; }
    }
}
