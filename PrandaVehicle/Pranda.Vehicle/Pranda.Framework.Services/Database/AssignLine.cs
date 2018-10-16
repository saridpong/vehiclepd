using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranda.Framework.Services.Database
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssignLine")]
    public class AssignLine
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal AssignHeaderID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal AssignLineID { get; set; }

        [StringLength(100)]
        public string AssignLineDescription { get; set; }

        [StringLength(100)]
        public string Place { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        [StringLength(100)]
        public string Province { get; set; }
        public int? ForUseID { get; set; }

        [StringLength(200)]
        public string ForUseName { get; set; }
        [StringLength(20)]
        public string Priority { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DriverID { get; set; }
        [StringLength(20)]
        public string DriverCode { get; set; }
        [StringLength(80)]
        public string DriverName { get; set; }

        public decimal? RouteID { get; set; }
        [StringLength(50)]
        public string RouteCode { get; set; }
        [StringLength(100)]
        public string RouteName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }
        public int? Quantity { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }


        [StringLength(20)]
        public string UpdateBy { get; set; }


        public DateTime? UpdateDate { get; set; }
        [StringLength(20)]
        public string CreateBy { get; set; }


        public DateTime? CreateDate { get; set; }
    }
}
