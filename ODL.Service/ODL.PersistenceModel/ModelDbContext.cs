using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PTJ.DataLayer.Models;

namespace PTJ.DataLayer.Models
{

    public interface IApplicationDbContext
    {
      
    }

    public class ModelDbContext : DbContext//, IApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=ds1ptjsql03;Database=PTJ_Operational_Db;Trusted_Connection=True;");
        }
        public ModelDbContext(DbContextOptions<ModelDbContext> options)
            : base(options)
        { }


        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<AdressTyp> AdressTyp { get; set; }
        public virtual DbSet<AdressVariant> AdressVariant { get; set; }
        public virtual DbSet<GatuAdress> GatuAdress { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<OrganisationAdress> OrganisationAdress { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAdress> PersonAdress { get; set; }
        public virtual DbSet<PersonAnnanPerson> PersonAnnanPerson { get; set; }
        public virtual DbSet<PersonAnstalld> PersonAnstalld { get; set; }
        public virtual DbSet<PersonKonsult> PersonKonsult { get; set; }
        public virtual DbSet<PersonPatient> PersonPatient { get; set; }
        public virtual DbSet<PersonSjukHalsovardsPersonal> PersonSjukHalsovardsPersonal { get; set; }
        public virtual DbSet<Telefon> Telefon { get; set; }

        public virtual DbSet<AnstalldAvtal> AnstalldAvtal { get; set; }

        public virtual DbSet<Anstalld> Anstalld { get; set; }

        public virtual DbSet<Avtal> Avtal { get; set; }

        public virtual DbSet<Konsult> Konsult { get; set; }

        public virtual DbSet<AvtalResultatEnhet> AvtalResultatEnhet { get; set; }

        public virtual DbSet<ResultatEnhet> ResultatEnhet { get; set; }
    }

  
}
