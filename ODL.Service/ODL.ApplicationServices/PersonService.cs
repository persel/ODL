using System.Collections.Generic;
using System.Linq;
using ODL.DataAccess;
using ODL.DataAccess.Models;
using ODL.DataAccess.Repositories;

namespace ODL.ApplicationServices
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;
        
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> GetByResultatenhetId(int resultatenhetId)
        {
            return _personRepository.GetByResultatenhetId(resultatenhetId);
        }

    }
}
