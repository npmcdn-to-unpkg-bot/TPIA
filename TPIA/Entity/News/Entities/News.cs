namespace TPIA.Entity.News.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class News
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }

        [Required]
        public string NewsContent { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsEnable { get; set; }
    }
}
