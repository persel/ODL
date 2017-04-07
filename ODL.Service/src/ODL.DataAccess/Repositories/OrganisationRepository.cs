using System;
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
            throw new NotImplementedException("Metoden ej anpassad efter ändrad domänmodell - skriv om alt. ta bort.");

            //return DbContext.Organisation.Where(organisation => organisation.OrganisationsAvtal.Any(
            //        avtal => avtalIdn.Contains(avtal.AvtalId))).ToList();
        }

        public IList<Organisation> GetWhereAnsvarigByAvtalIdn(IEnumerable<int> avtalIdn)
        {
            throw new NotImplementedException("Metoden ej anpassad efter ändrad domänmodell - skriv om alt. ta bort.");

            //var avtalAnsvarig = DbContext.Avtal.Where(a => a.Ansvarig == true && avtalIdn.Contains(a.Id));

            //var avtalAnsvarigIdn = avtalAnsvarig.Select(avtal => avtal.Id);

            //return DbContext.Organisation.Where(organisation => organisation.OrganisationsAvtal.Any(
            //        avtal => avtalAnsvarigIdn.Contains(avtal.AvtalId))).ToList();
        }

        public IList<Organisation> GetByKstNr(List<string> kstNrList)
        {
            throw new NotImplementedException("Metoden ej anpassad efter ändrad domänmodell - skriv om alt. ta bort.");
            //return DbContext.Organisation.Where(organisation => kostnadsstalleNr.Contains(organisation.Resultatenhet.KstNr)).ToList();
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

        public Organisation GetOrganisationByKstnr(string kstnr)
        {
            return _internalGenericRepository.FindSingle(org => org.Resultatenhet.KstNr == kstnr);
        }

        public List<Organisation> GetOrganisationerByKstnr(IEnumerable<string> kstNrList)
        {
            // TODO: Om vi bara har ett kstnr borde man inte behöva köra Contains...
            return _internalGenericRepository.Find(org => kstNrList.Contains(org.Resultatenhet.KstNr)).ToList();
        }
    }
}
