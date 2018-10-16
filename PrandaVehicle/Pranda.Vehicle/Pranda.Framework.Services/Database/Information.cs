

   
    namespace Pranda.Framework.Services.Database
    {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Information")]
    public partial class Information
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InformationID { get; set; }

        [StringLength(600)]
        public string InformationData { get; set; }

        [StringLength(20)]
        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
    }
