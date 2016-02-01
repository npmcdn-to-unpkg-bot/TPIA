namespace TPIA.Entity.ShareLink.Contexts
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TPIA.Entity.ShareLink.Entities;


    public partial class ShareLinkContext : DbContext
    {
        public ShareLinkContext()
            : base("name=TPAIConn")
        {
        }

        public virtual DbSet<ShareLink> ShareLink { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShareLink>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<ShareLink>()
                .Property(e => e.ImgUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ShareLink>()
                .Property(e => e.LinkUrl)
                .IsUnicode(false);
        }
    }
}
