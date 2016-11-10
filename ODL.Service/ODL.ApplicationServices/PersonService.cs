using System.Collections.Generic;
using System.Linq;
using ODL.DataAccess;
using ODL.DataAccess.Models;
using ODL.DataAccess.Models.Extensions;
using ODL.DataAccess.Repositories;

namespace ODL.ApplicationServices
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;
        private readonly IResultatenhetRepository _resultatenhetRepository;

        public PersonService(IPersonRepository personRepository, IResultatenhetRepository resultatenhetRepository)
        {
            _personRepository = personRepository;
            _resultatenhetRepository = resultatenhetRepository;
        }

        public List<Person> GetByResultatenhetId(int id)
        {
            var resultatenhet = _resultatenhetRepository.GetById(id);

            var allaResultatenhetersId = GetAllaRelateradeResultatenhetersIdn(resultatenhet);

            return _personRepository.GetByResultatenhetId(allaResultatenhetersId.ToArray());
        }

        private IEnumerable<int> GetAllaRelateradeResultatenhetersIdn(Resultatenhet resultatenhet)
        {
            var organisation = resultatenhet.Organisation;
            
            var allaIngåendeOrganisationer = organisation.Root().Flatten();

            return allaIngåendeOrganisationer.Select(org => org.Id);
        }
        
    }
}
