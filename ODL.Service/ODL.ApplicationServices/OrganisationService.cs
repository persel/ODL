using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.ApplicationServices.Models;
using ODL.DataAccess.Models;
using ODL.DataAccess.Models.Extensions;
using ODL.DataAccess.Models.Organisation;
using ODL.DataAccess.Repositories;

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
                    KostnadsstalleNr = enhet.Kstnr,
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }
    }
}
