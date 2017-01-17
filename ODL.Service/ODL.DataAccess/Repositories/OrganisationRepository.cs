using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Repositories
{
    public class OrganisationRepository : IOrganisationRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Organisation, ODLDbContext> _internalGenericRepository;


        public OrganisationRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Organisation, ODLDbContext>(DbContext);
        }

        public Organisation GetByOrgId(string orgId)
        {
            var obj = DbContext.Organisation.FirstOrDefault(x => x.OrganisationsId == orgId);
            return obj;
        }

         public IList<Organisation> GetByAvtalIdn(IEnumerable<int> avtalIdn)
        {
            return DbContext.Organisation.Where(organisation => organisation.OrganisationsAvtal.Any(
                    avtal => avtalIdn.Contains(avtal.AvtalFKId))).ToList();
        }

        public IList<Organisation> GetAll()
        {
            return DbContext.Set<Organisation>().ToList();
        }

        public void Update()
        {
            _internalGenericRepository.Update();
        }


        public void Add(Organisation nyOrganisation)
        {
            _internalGenericRepository.Add(nyOrganisation);
        }

        public Organisation GetOrganisationByKstnr(int kstnr)
        {
            return _internalGenericRepository.FindSingle(org => org.Resultatenhet.KstNr == kstnr);
        }

        public List<Organisation> GetOrganisationerByKstnr(IEnumerable<int> kstnrList)
        {
            // TODO: Om vi bara har ett kstnr borde man inte behöva köra Contains...
            return _internalGenericRepository.Find(org => kstnrList.Contains(org.Resultatenhet.KstNr)).ToList();
        }
    }
}
