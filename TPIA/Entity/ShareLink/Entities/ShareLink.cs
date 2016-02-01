namespace TPIA.Entity.ShareLink.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ShareLink")]
    public partial class ShareLink
    {
        [Key]
        public int LID { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(300)]
        public string ImgUrl { get; set; }

        [Required]
        [StringLength(300)]
        public string LinkUrl { get; set; }
    }
}
