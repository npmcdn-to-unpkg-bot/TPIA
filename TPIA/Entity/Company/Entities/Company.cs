namespace TPIA.Entity.Company.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
            CompanyProduct = new HashSet<CompanyProduct>();
        }

        [Key]
        public int CID { get; set; }
        
        [Required]
        [StringLength(120)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Manager { get; set; }

        [Required]
        [StringLength(50)]
        public string Sales { get; set; }

        [Required]
        [StringLength(120)]
        public string AboutUs { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(20)]
        public string Tax { get; set; }

        [Required]
        [StringLength(120)]
        public string EMail { get; set; }

        [Required]
        [StringLength(120)]
        public string MainProducts { get; set; }

        [Required]
        [StringLength(300)]
        public string SiteURL { get; set; }
                
        public bool IsEnable { get; set; }

        public virtual ICollection<CompanyProduct> CompanyProduct { get; set; }
    }
}
