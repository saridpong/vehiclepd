namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InformationLogin")]
    public partial class InformationLogin
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal InformationLoginID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2000)]
        public string InformationLoginData { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Status { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string UpdateBy { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime UpdateDate { get; set; }
    }
}
