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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ForUseID { get; set; }


        [StringLength(20)]
        public string ForUseCode { get; set; }


        [StringLength(80)]
        public string ForUseName { get; set; }


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
