namespace TPIA.Entity.Company.Contexts
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TPIA.Entity.Company.Entities;

    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("name=TPAIConn")
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyProduct> CompanyProduct { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Tax)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyProduct)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
        }
    }
}
