namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vihicle")]
    public partial class Vihicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal VihicleID { get; set; }

     
        [StringLength(20)]
        public string VihicleCode { get; set; }

        [StringLength(50)]
        public string VihicleBrand { get; set; }

        [StringLength(50)]
        public string VihicleModel { get; set; }

        [StringLength(50)]
        public string VihicleFuelType { get; set; }

        [StringLength(50)]
        public string VihicleDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VihicleCost { get; set; }

        [StringLength(20)]
        public string VihicleTypeCode { get; set; }
        [StringLength(100)]
        public string VehicleTypeName { get; set; }

        public int? VihicleYear { get; set; }

        [StringLength(50)]
        public string VihicleAsset { get; set; }

        [StringLength(100)]
        public string VihicleInsurance { get; set; }

        [StringLength(100)]
        public string VihicleInsuranceType { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(20)]
        public string UpdateBy { get; set; }

       
        [Column(TypeName = "numeric")]
        public decimal Status { get; set; }
    }
}
