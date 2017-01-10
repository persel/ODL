using System.Data.Entity;
using System.Diagnostics;
using ODL.DomainModel.Behorighet;
using ODL.DomainModel.Behorighet.Systemattribut;
using ODL.DomainModel.Behorighet.Systemroll;
using Systemroll = ODL.DomainModel.Behorighet.Systemroll;
using ODL.DomainModel.Behorighet.Verksamhetsdimension;
using ODL.DomainModel.Behorighet.Verksamhetsroll;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.DataAccess
{

    public partial class ODLDbContext : DbContext
    {

        public ODLDbContext() : base("name=ODLDbContext")
        {
            #if DEBUG
            Database.Log = s => Debug.WriteLine(s);
            #endif
        }

        public ODLDbContext(string connString) : base(connString)
        {
            #if DEBUG
            Database.Log = s => Debug.WriteLine(s);
            #endif
        }

        // Person:

        public virtual DbSet<AnstallningsAvtal> AnstallningsAvtal { get; set; }
        public virtual DbSet<KonsultAvtal> KonsultAvtal { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        // Organisation:

        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Resultatenhet> Resultatenhet { get; set; }
        public virtual DbSet<OrganisationsAvtal> OrganisationAvtal { get; set; }

        // Behörighet.Systemroll:

        public virtual DbSet<Anvandare> Anvandare { get; set; }
        public virtual DbSet<Behorighetsniva> Behorighetsniva { get; set; }
        public virtual DbSet<Systemanvandargrupp> Systemanvandargrupp { get; set; }
        public virtual DbSet<Systembehorighet> Systembehorighet { get; set; }
        public virtual DbSet<Systemroll.System> System { get; set; }

        // Behörighet.Verksamhetsroll:

        public virtual DbSet<PersonIVerksamhetsroll> PersonIVerksamhetsroll { get; set; }
        public virtual DbSet<Verksamhetsroll> Verksamhetsroll { get; set; }

        // Behörighet.Systemattribut:

        public virtual DbSet<Systemattribut> Systemattribut { get; set; }
        public virtual DbSet<Systemattributvarde> Systemattributvarde { get; set; }

        // Behörighet.Verksamhetsdimension:

        public virtual DbSet<Verksamhetsdimension> Verksamhetsdimension { get; set; }
        public virtual DbSet<Verksamhetsdimensionsvarde> Verksamhetsdimensionvarde { get; set; }

        // Behörighet (Kopplingar mellan aggregaten)

        public virtual DbSet<PersonIVerksamhetsrollVerksamhetsdimensionsvarde> PersonIVerksamhetsrollVerksamhetsdimensionvarde { get; set; }
        public virtual DbSet<RelevantVerksamhetsdimension> RelevantVerksamhetsdimension { get; set; }
        public virtual DbSet<SystemattributVerksamhetsdimension> SystemattributVerksamhetsdimension { get; set; }
        public virtual DbSet<Systembegransning> Systembegransning { get; set; }
        public virtual DbSet<SystembehorighetAttributVarde> SystembehorighetAttributVarde { get; set; }
        public virtual DbSet<VerksamhetsdimensionsvardeSystemattributvarde> VerksamhetsdimensionsvardeSystemattributvarde { get; set; }
        public virtual DbSet<VerksamhetsrollAnvandargrupp> VerksamhetsrollAnvandargrupp { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Person:

            modelBuilder.Entity<Person>()
                .HasMany(e => e.AnstallningsAvtal)
                .WithRequired(e => e.Anstalld).HasForeignKey(k => k.PersonFKId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.KonsultAvtal)
                .WithRequired(e => e.Konsult).HasForeignKey(k => k.PersonFKId)
                .WillCascadeOnDelete(false);
            
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

            // Behörighet.Systemroll:

            modelBuilder.Entity<Behorighetsniva>()
                .HasMany(e => e.Systemanvandargrupp)
                .WithRequired(e => e.Behorighetsniva)
                .HasForeignKey(e => e.BehorighetsnivaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Systemanvandargrupp>()
                .HasMany(e => e.Systembehorighet)
                .WithRequired(e => e.Systemanvandargrupp)
                .HasForeignKey(e => e.SystemanvandargruppId)
                .WillCascadeOnDelete(false);

            // Behörighet.Verksamhetsroll:

            //modelBuilder.Entity<Verksamhetsroll>()
            //    .HasMany(e => e.PersonIVerksamhetsroll)
            //    .WithRequired(e => e.Verksamhetsroll)
            //    .HasForeignKey(e => e.VerksamhetsrollId)
            //    .WillCascadeOnDelete(false);

            // Behörighet.Systemattribut:

            modelBuilder.Entity<Systemattribut>()
                .HasMany(e => e.Systemattributvarden)
                .WithRequired(e => e.Systemattribut)
                .HasForeignKey(e => e.SystemattributId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Systemattributvarde>()
                .HasMany(e => e.Underliggande)
                .WithOptional(e => e.Overordnad)
                .HasForeignKey(e => e.SystemattributvardeId);

            // Behörighet.Verksamhetsdimension:

            modelBuilder.Entity<Verksamhetsdimension>()
                .HasMany(e => e.Verksamhetsdimensionvarde)
                .WithRequired(e => e.Verksamhetsdimension)
                .HasForeignKey(e => e.VerksamhetsdimensionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Verksamhetsdimensionsvarde>()
                .HasMany(e => e.Underliggande)
                .WithOptional(e => e.Overordnad)
                .HasForeignKey(e => e.VerksamhetsdimensionvardeId);

            // Behörighet (Kopplingar mellan aggregaten)

            modelBuilder.Entity<SystembehorighetAttributVarde>().
            HasRequired(m => m.Systembehorighet).WithMany().HasForeignKey(fk => fk.SystembehorighetId).WillCascadeOnDelete(false);

            modelBuilder.Entity<SystembehorighetAttributVarde>().
            HasRequired(m => m.Systemattributvarde).WithMany().HasForeignKey(fk => fk.SystemattributvardeFKId).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<VerksamhetsdimensionsvardeSystemattributvarde>().
            HasRequired(m => m.Verksamhetsdimensionsvarde).WithMany().HasForeignKey(fk => fk.VerksamhetsdimensionvardeId).WillCascadeOnDelete(false);

            modelBuilder.Entity<VerksamhetsdimensionsvardeSystemattributvarde>().
            HasRequired(m => m.Systemattributvarde).WithMany().HasForeignKey(fk => fk.SystemattributvardeId).WillCascadeOnDelete(false);

            modelBuilder.Entity<VerksamhetsrollAnvandargrupp>().
            HasRequired(m => m.Verksamhetsroll).WithMany().HasForeignKey(fk => fk.VerksamhetsrollId).WillCascadeOnDelete(false);

            modelBuilder.Entity<VerksamhetsrollAnvandargrupp>().
            HasRequired(m => m.Systemanvandargrupp).WithMany().HasForeignKey(fk => fk.SystemanvandargruppId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Systembegransning>().
            HasRequired(m => m.System).WithMany().HasForeignKey(fk => fk.SystemId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Systembegransning>().
            HasRequired(m => m.PersonIVerksamhetsroll).WithMany().HasForeignKey(fk => fk.PersonIVerksamhetsrollId).WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemattributVerksamhetsdimension>().
            HasRequired(m => m.Systemattribut).WithMany().HasForeignKey(fk => fk.SystemattributId).WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemattributVerksamhetsdimension>().
            HasRequired(m => m.Verksamhetsdimension).WithMany().HasForeignKey(fk => fk.VerksamhetsdimensionId).WillCascadeOnDelete(false);

            modelBuilder.Entity<RelevantVerksamhetsdimension>().
            HasRequired(m => m.Verksamhetsdimension).WithMany().HasForeignKey(fk => fk.VerksamhetsdimensionId).WillCascadeOnDelete(false);

            modelBuilder.Entity<RelevantVerksamhetsdimension>().
            HasRequired(m => m.Verksamhetsroll).WithMany().HasForeignKey(fk => fk.VerksamhetsrollId).WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonIVerksamhetsrollVerksamhetsdimensionsvarde>().
            HasRequired(m => m.PersonIVerksamhetsroll).WithMany().HasForeignKey(fk => fk.PersonIVerksamhetsrollId).WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonIVerksamhetsrollVerksamhetsdimensionsvarde>().
            HasRequired(m => m.Verksamhetsdimensionsvarde).WithMany().HasForeignKey(fk => fk.VerksamhetsdimensionsvardeId).WillCascadeOnDelete(false);

        }
    }
}
