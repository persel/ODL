using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Diagnostics;
using ODL.DomainModel;
using ODL.DomainModel.Adress;
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
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Avtal> Avtal { get; set; }
        public virtual DbSet<AnstalldAvtal> AnstallningsAvtal { get; set; }
        public virtual DbSet<KonsultAvtal> KonsultAvtal { get; set; }
        public virtual DbSet<OrganisationAvtal> OrganisationAvtal { get; set; }


        // Organisation:

        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Resultatenhet> Resultatenhet { get; set; }

        // Adress:

        public virtual DbSet<Adress> Adress { get; set; }
        //public virtual DbSet<AdressTyp> AdressTyp { get; set; }
        public virtual DbSet<AdressVariant> AdressVariant { get; set; }
        public virtual DbSet<GatuAdress> GatuAdress { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<OrganisationAdress> OrganisationAdress { get; set; }
        public virtual DbSet<PersonAdress> PersonAdress { get; set; }
        public virtual DbSet<Telefon> Telefon { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Person:

            modelBuilder.Entity<Person>()
                .HasMany(e => e.AnstalldAvtal)
                .WithRequired(e => e.Anstalld).HasForeignKey(k => k.PersonFKId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.KonsultAvtal)
                .WithRequired(e => e.Konsult).HasForeignKey(k => k.PersonFKId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<AnstalldAvtal>()
                .HasRequired(p => p.Avtal)
                .WithOptional(p => p.AnstalldAvtal);

            modelBuilder
                .Entity<KonsultAvtal>()
                .HasRequired(p => p.Avtal)
                .WithOptional(p => p.KonsultAvtal);

            
            modelBuilder.Entity<Avtal>()
                .HasMany(e => e.OrganisationAvtal)
                .WithRequired(e => e.Avtal)
                .HasForeignKey(e => e.AvtalFKId)
                .WillCascadeOnDelete(false);
            

            modelBuilder.Entity<OrganisationAvtal>()
                .Property(e => e.ProcentuellFordelning)
                .HasPrecision(5, 2);

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
                .WithRequired(e => e.Organisation)// Ta bort denna nav prop!
                .HasForeignKey(e => e.OrganisationFKId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Organisation>()
                .HasOptional(e => e.Resultatenhet)
                .WithRequired(e => e.Organisation);

            // Adress: 
            
            modelBuilder.Entity<Adress>()
                .HasOptional(e => e.GatuAdress)
                .WithRequired(e => e.Adress);

            modelBuilder.Entity<Adress>()
                .HasOptional(e => e.Mail)
                .WithRequired(e => e.Adress);

            modelBuilder.Entity<Adress>()
                .HasOptional(e => e.OrganisationAdress)
                .WithRequired(e => e.Adress);

            modelBuilder.Entity<Adress>()
                .HasOptional(e => e.PersonAdress)
                .WithRequired(e => e.Adress);

            modelBuilder.Entity<Adress>()
                .HasOptional(e => e.Telefon)
                .WithRequired(e => e.Adress);

            //modelBuilder.Entity<AdressTyp>()
            //    .HasMany(e => e.AdressVariant)
            //    .WithRequired(e => e.AdressTyp)
            //    .HasForeignKey(e => e.AdressTypFKId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<AdressVariant>()
            //    .HasMany(e => e.Adress)
            //    .WithRequired(e => e.AdressVariant)
            //    .HasForeignKey(e => e.AdressVariantFKId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<GatuAdress>()
                .Property(e => e.Postnummer)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mail>()
                .Property(e => e.MailAdress)
                .IsUnicode(false);


        }
    }
}
