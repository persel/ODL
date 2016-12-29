using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Repositories
{
    public class ResultatenhetRepository : IResultatenhetRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Resultatenhet, ODLDbContext> _internalGenericRepository;


        public ResultatenhetRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Resultatenhet, ODLDbContext>(DbContext);
        }

        public Resultatenhet GetById(int id)
        {

            // Vi eager-laddar Organisation och OrganisationsAvtal, dock ej på (rekursivt) relaterade Organisationer
            // Include på Overordnad och Underliggande organisationer kräver ett specificerat djup i hierarkin, därav ej implementerat
            return DbContext.Set<Resultatenhet>().Include(r => r.Organisation.OrganisationsAvtal).SingleOrDefault(resEnhet => resEnhet.OrganisationFKId == id);
        }

        public Resultatenhet GetResultatenhetByKstnr(int kstnr)
        {
            var obj = DbContext.Resultatenhet.FirstOrDefault(x => x.KstNr == kstnr);
            return obj;
        }


        public IList<Resultatenhet> GetByAvtalIdn(IEnumerable<int> avtalIdn)
        {
            return DbContext.Resultatenhet.Include(re => re.Organisation).Where(
                resultatEnhet => resultatEnhet.Organisation.OrganisationsAvtal.Any(
                    avtal => avtalIdn.Contains(avtal.AvtalFKId))).ToList();
        }

        public IList<Resultatenhet> GetAll()
        {
            return DbContext.Set<Resultatenhet>().Include(r => r.Organisation).ToList();
        }

        public void Update()
        {
            _internalGenericRepository.Update();
        }


        public void Add(Resultatenhet nyResultatenhet)
        {
            _internalGenericRepository.Add(nyResultatenhet);
        }
    }
}
