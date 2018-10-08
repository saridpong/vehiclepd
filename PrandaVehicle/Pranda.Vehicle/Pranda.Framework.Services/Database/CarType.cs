namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarType")]
    public partial class CarType
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal CarTypeID { get; set; }

    
        [StringLength(20)]
        public string CarTypeCode { get; set; }

    
        [StringLength(80)]
        public string CarTypeName { get; set; }

      
        [Column(TypeName = "numeric")]
        public decimal Status { get; set; }

        [StringLength(20)]
        public string UpdateBy { get; set; }


        public DateTime UpdateDate { get; set; }
    }
}
