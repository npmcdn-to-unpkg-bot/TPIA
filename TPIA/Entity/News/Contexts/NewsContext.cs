namespace TPIA.Entity.News.Contexts
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TPIA.Entity.News.Entities;

    public partial class NewsContext : DbContext
    {
        public NewsContext()
            : base("name=TPAIConn")
        {
        }

        public virtual DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(e => e.Category)
                .IsUnicode(false);
        }
    }
}
