using ODL.DataAccess.Models;

namespace ODL.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ODLDbContext : DbContext
    {

        public ODLDbContext()
            : base("name=ODLDbContext")
        {
        }

        public ODLDbContext(string connString) : base(connString)
        {
        }

        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Resultatenhet> Resultatenhet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisation>()
                .Property(e => e.OrganisationsId)
                .IsUnicode(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Resultatenhet)
                .WithOptional(e => e.Organisation)
                .HasForeignKey(e => e.OrganisationFKId);

            modelBuilder.Entity<Resultatenhet>()
                .Property(e => e.Typ)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
