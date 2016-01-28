namespace TPIA.Entity.Company.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyProduct")]
    public partial class CompanyProduct
    {
        [Key]
        public int PID { get; set; }

        public int CID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductTitle { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductImgURL { get; set; }

        [Required]
        [StringLength(120)]
        public string ProductDesc { get; set; }

        public virtual Company Company { get; set; }
    }
}
