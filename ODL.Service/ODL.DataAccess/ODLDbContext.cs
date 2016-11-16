
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.DataAccess
{
    using System.Data.Entity;

    public partial class ODLDbContext : DbContext
    {

        public ODLDbContext()
            : base("name=ODLDbContext")
        {
        }

        public ODLDbContext(string connString) : base(connString)
        {
        }

        // Person:

        public virtual DbSet<Anstalld> Anstalld { get; set; }
        public virtual DbSet<AnstallningsAvtal> AnstallningsAvtal { get; set; }
        public virtual DbSet<Konsult> Konsult { get; set; }
        public virtual DbSet<KonsultAvtal> KonsultAvtal { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        // Organisation:

        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Resultatenhet> Resultatenhet { get; set; }
        public virtual DbSet<OrganisationsAvtal> OrganisationAvtal { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Person:

            modelBuilder.Entity<Anstalld>()
                .HasMany(e => e.AnstallningsAvtal)
                .WithRequired(e => e.Anstalld)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Konsult>()
                .HasMany(e => e.KonsultAvtal)
                .WithRequired(e => e.Konsult)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Anstalld)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Konsult)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Avtal>()
                .Property(e => e.DeltidFranvaro)
                .IsFixedLength();

            modelBuilder.Entity<Avtal>()
                .Property(e => e.SjukP)
                .IsFixedLength();

            modelBuilder.Entity<Avtal>()
                .Property(e => e.LoneTyp)
                .IsFixedLength();


            // Organisation:

            modelBuilder.Entity<Organisation>()
                .Property(e => e.OrganisationsId)
                .IsUnicode(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Underliggande)
                .WithOptional(e => e.Overordnad)
                .HasForeignKey(e => e.IngarIOrganisationFKId);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.OrganisationsAvtal)
                .WithRequired(e => e.Organisation)
                .HasForeignKey(e => e.OrganisationFKId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasOptional(e => e.Resultatenhet)
                .WithRequired(e => e.Organisation);

        }
    }
}
