using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Model.Assign
{
    public class AssignSearchItem
    {
        public decimal AssignHeaderID { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocumentNo { get; set; }
        public decimal Status { get; set; }
        public string Department { get; set; }
    }
}
