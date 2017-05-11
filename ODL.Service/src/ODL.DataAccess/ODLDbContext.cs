using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using ODL.DomainModel;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Common;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

/*
    Code-First anv�nds i detta projekt (utan automatic migrations). Vi har satt upp processen p� f�ljande s�tt:
    PM> enable-migrations  -StartUpProjectName ODL.DataAccess 
    PM> Add-Migration Initial -StartUpProjectName ODL.DataAccess (OBS: "Initial" �r bara namnet vi v�ljer att ge f�rsta migreringen)
    PM> update-database -StartUpProjectName ODL.DataAccess -Verbose (-Script kan anges om man vill ha ut ett script ist�llet)

    -SourceMigration: $InitialDatabase anges om man vill generera script fr�n initial db till senaste migreringen.
    Se:
    https://msdn.microsoft.com/en-us/library/jj591621(v=vs.113).aspx 
    https://msdn.microsoft.com/en-us/library/dn481501(v=vs.113).aspx
    http://www.itworld.com/article/2700195/development/3-reasons-to-use-code-first-design-with-entity-framework.html

*/
namespace ODL.DataAccess
{

    public partial class ODLDbContext : DbContext, IContext
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
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<AdressVariant> AdressVariant { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(ODLDbContext).Assembly); // Peka ut valfri klass i assembly d�r mappningarna finns! OBS att denna ska k�ras f�re 'strukturella' mappningarna nedan.
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}
