using System.Collections.Generic;
using System.Linq;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess.Repositories;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices
{
    public class OrganisationService : IOrganisationService
    {

        private readonly IResultatenhetRepository _resultatenhetRepository;
        private readonly IPersonRepository _personRepository;
        
        public OrganisationService(IResultatenhetRepository resultatenhetRepository, IPersonRepository personRepository)
        {
            _resultatenhetRepository = resultatenhetRepository;
            _personRepository = personRepository;
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenhetByPersonnummer(string personnummer)
        {
            var person = _personRepository.GetByPersonnummer(personnummer);

            var resultatenheter =  _resultatenhetRepository.GetByAvtalIdn(person.AllaAvtalIdn());

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationFKId,
                    KostnadsstalleNr = enhet.KstNr,
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenheter()
        {
            var resultatenheter = _resultatenhetRepository.GetAll();

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationFKId,
                    KostnadsstalleNr = enhet.KstNr,
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }
    }
}
