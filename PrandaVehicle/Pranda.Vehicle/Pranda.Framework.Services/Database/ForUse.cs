namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ForUse")]
    public partial class ForUse
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal ForUseID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ForUseCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(80)]
        public string ForUseName { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal Status { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(20)]
        public string UpdateBy { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime UpdateDate { get; set; }
    }
}
