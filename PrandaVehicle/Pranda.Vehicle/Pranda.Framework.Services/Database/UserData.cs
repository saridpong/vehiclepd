namespace Pranda.Framework.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserData")]
    public partial class UserData
    {
        [Key]
        [StringLength(20)]
        public string UserCode { get; set; }

        [Column(TypeName = "text")]
        public string UserPassword { get; set; }

        [StringLength(20)]
        public string UserTitleName { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string UserSurname { get; set; }

        [StringLength(100)]
        public string UserPosition { get; set; }

        [StringLength(20)]
        public string UserSectionCode { get; set; }

        [StringLength(100)]
        public string UserSectionName { get; set; }

        [StringLength(20)]
        public string UserDepartmentCode { get; set; }

        [StringLength(100)]
        public string UserDepartmentName { get; set; }

        [StringLength(20)]
        public string UserPhone { get; set; }

        public int? UserPermission { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Status { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(20)]
        public string UpdateBy { get; set; }
    }
}
