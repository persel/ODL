using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using ODL.DomainModel;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

/*
    Code-First används i detta projekt (utan automatic migrations). Vi har satt upp processen på följande sätt:
    PM> enable-migrations  -StartUpProjectName ODL.DataAccess 
    PM> Add-Migration Initial -StartUpProjectName ODL.DataAccess (OBS: "Initial" är bara namnet vi väljer att ge första migreringen)
    PM> update-database -StartUpProjectName ODL.DataAccess -Verbose (-Script kan anges om man vill ha ut ett script istället)

    -SourceMigration: $InitialDatabase anges om man vill generera script från initial db till senaste migreringen.
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

            


            // Person:

            modelBuilder.Entity<Person>()
                .HasMany(e => e.AnstalldAvtal)
                .WithRequired(e => e.Anstalld).HasForeignKey(k => k.PersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.KonsultAvtal)
                .WithRequired(e => e.Konsult).HasForeignKey(k => k.PersonId)
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
                .HasForeignKey(e => e.AvtalId)
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
                .HasForeignKey(e => e.IngarIOrganisationId);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.OrganisationsAvtal)
                .WithRequired(e => e.Organisation)// Ta bort denna nav prop!
                .HasForeignKey(e => e.OrganisationId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Organisation>()
                .HasOptional(e => e.Resultatenhet)
                .WithRequired(e => e.Organisation);

            // Adress: 

            modelBuilder.Entity<Adress>()
                .HasOptional(e => e.Gatuadress)
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

            modelBuilder.Entity<AdressVariant>()
                .HasMany(e => e.Adress)
                .WithRequired(e => e.AdressVariant)
                .HasForeignKey(e => e.AdressVariantFKId)
                .WillCascadeOnDelete(false);


        }
    }
}
