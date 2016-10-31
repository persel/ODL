using System.Data.Entity;
using ODL.DataAccess.Models;
using ODL.DataAccess.PersistenceModel;
using ODL.PersistenceModel;

namespace ODL.DataAccess
{

    public interface IApplicationDbContext
    {
      
    }


    public class ModelDbContext : DbContext //, IApplicationDbContext
    {
        
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public ModelDbContext(string connString) : base(connString)
        {
        }

        //public virtual DbSet<Adress> Adress { get; set; }
        //public virtual DbSet<AdressTyp> AdressTyp { get; set; }
        //public virtual DbSet<AdressVariant> AdressVariant { get; set; }
        //public virtual DbSet<GatuAdress> GatuAdress { get; set; }
        //public virtual DbSet<Mail> Mail { get; set; }
        //public virtual DbSet<Organisation> Organisation { get; set; }
        //public virtual DbSet<OrganisationAdress> OrganisationAdress { get; set; }
        //public virtual DbSet<Person> Person { get; set; }
        //public virtual DbSet<PersonAdress> PersonAdress { get; set; }
        //public virtual DbSet<PersonAnnanPerson> PersonAnnanPerson { get; set; }
        //public virtual DbSet<PersonAnstalld> PersonAnstalld { get; set; }
        //public virtual DbSet<PersonKonsult> PersonKonsult { get; set; }
        //public virtual DbSet<PersonPatient> PersonPatient { get; set; }
        //public virtual DbSet<PersonSjukHalsovardsPersonal> PersonSjukHalsovardsPersonal { get; set; }
        //public virtual DbSet<Telefon> Telefon { get; set; }

        //public virtual DbSet<AnstalldAvtal> AnstalldAvtal { get; set; }

        public virtual DbSet<Anstalld> Anstalld { get; set; }

        //public virtual DbSet<Avtal> Avtal { get; set; }

        //public virtual DbSet<Konsult> Konsult { get; set; }

        //public virtual DbSet<AvtalResultatEnhet> AvtalResultatEnhet { get; set; }

        public virtual DbSet<ResultatEnhet> ResultatEnhet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
