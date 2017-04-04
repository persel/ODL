using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Diagnostics;
using ODL.DomainModel;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

/*
    Code-First används i detta projekt (utan automatic migrations). Vi har satt upp processen på följande sätt:
    PM> enable-migrations  -StartUpProjectName ODL.DataAccess 
    PM> Add-Migration Initial -StartUpProjectName ODL.DataAccess (OBS: "Initial" är bara namnet vi väljer att ge första migreringen)
    PM> update-database -StartUpProjectName ODL.DataAccess -Verbose 

    SQL
    PM> update-database -StartUpProjectName ODL.DataAccess -Script

    Sql script initial DB
    PM>update-Database -Script -SourceMigration: $InitialDatabase

    Se:
    https://msdn.microsoft.com/en-us/library/jj591621(v=vs.113).aspx 
    https://msdn.microsoft.com/en-us/library/dn481501(v=vs.113).aspx
    http://www.itworld.com/article/2700195/development/3-reasons-to-use-code-first-design-with-entity-framework.html

*/
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

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           // modelBuilder.Conventions.Add(new DataTypePropertyAttributeConvention());

            modelBuilder.Configurations.AddFromAssembly(typeof(ODLDbContext).Assembly); // Peka ut valfri klass i assembly där mappningarna finns! OBS att denna ska köras före 'strukturella' mappningarna nedan.

  

            modelBuilder.Entity<OrganisationAvtal>()
                .Property(e => e.ProcentuellFordelning)
                .HasPrecision(5, 2);

            // Organisation:

            modelBuilder.Entity<Organisation>()
                .Property(e => e.OrganisationsId)
                .IsUnicode(false);

          
            modelBuilder.Entity<GatuAdress>()
                .Property(e => e.Postnummer)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mail>()
                .Property(e => e.MailAdress)
                .IsUnicode(false);

            MapRelationsobjekt(modelBuilder);


        }

        private static void MapRelationsobjekt(DbModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<GatuAdress>()
                .HasKey(t => t.AdressFKId);

            modelBuilder.Entity<Adress>()
                .HasRequired(t => t.Gatuadress)
                .WithRequiredPrincipal(e => e.Adress);

            modelBuilder.Entity<Mail>()
                .HasKey(t => t.AdressFKId);

            modelBuilder.Entity<Adress>()
                .HasRequired(t => t.Mail)
                .WithRequiredPrincipal(e => e.Adress);


            modelBuilder.Entity<OrganisationAdress>()
              .HasKey(t => t.AdressFKId);

            modelBuilder.Entity<OrganisationAdress>()
             .HasKey(t => t.OrganisationFKId);

            modelBuilder.Entity<Adress>()
                .HasRequired(t => t.OrganisationAdress)
                .WithRequiredPrincipal(e => e.Adress);

            //modelBuilder.Entity<Organisation>()
            //    .HasRequired(t => t.OrganisationsId);


            //modelBuilder.Entity<PersonAdress>()
            //    .HasKey(t => t.AdressFKId);


            modelBuilder.Entity<Adress>()
                .HasRequired(t => t.PersonAdress)
                .WithRequiredPrincipal(e => e.Adress);


            modelBuilder.Entity<Telefon>()
            .HasKey(t => t.AdressFKId);

            modelBuilder.Entity<Adress>()
                .HasRequired(t => t.Telefon)
                .WithRequiredPrincipal(e => e.Adress);

         
            modelBuilder.Entity<Adress>()
                .HasKey(t => t.AdressVariantFKId);




        }
    }
}
