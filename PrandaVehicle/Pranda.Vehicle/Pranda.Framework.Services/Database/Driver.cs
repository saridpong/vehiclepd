namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Driver")]
    public partial class Driver
    {
        [Key]
        [Column(TypeName = "numeric")]
        public int DriverID { get; set; }
       // public int ForUseID { get; set; }

        [StringLength(20)]
        public string DriverCode { get; set; }

     
        [StringLength(80)]
        public string DriverName { get; set; }

        [StringLength(40)]
        public string DriverMobile { get; set; }

      
        [Column( TypeName = "numeric")]
        public decimal Status { get; set; }

    
        [StringLength(20)]
        public string UpdateBy { get; set; }

     
        public DateTime? UpdateDate { get; set; }
        [StringLength(20)]
        public string CreateBy { get; set; }


        public DateTime? CreateDate { get; set; }
    }
}
