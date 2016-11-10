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
        public virtual DbSet<Anställd> Anställd { get; set; }
        public virtual DbSet<Konsult> Konsult { get; set; }
        public virtual DbSet<Person> Person { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Person:

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Anställd)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Konsult)
                .WithRequired(e => e.Person);

            // Organisation:

            modelBuilder.Entity<Organisation>()
                .Property(e => e.OrganisationsId)
                .IsUnicode(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Underliggande)
                .WithOptional(e => e.Överordnad)
                .HasForeignKey(e => e.OrganisationFKId);

            modelBuilder.Entity<Organisation>()
                .HasOptional(e => e.Resultatenhet)
                .WithRequired(e => e.Organisation);

            modelBuilder.Entity<Resultatenhet>()
                .Property(e => e.Typ)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
