using System.Collections.Generic;
using System.Linq;
using ODL.DataAccess;
using ODL.DataAccess.Models;
using ODL.DataAccess.Repositories;

namespace ODL.ApplicationServices
{
    public class PersonService : IPersonService
    {

        private readonly IAnstalldRepository _anstalldRepository;

        public PersonService(IAnstalldRepository anstalldRepository)
        {
            _anstalldRepository = anstalldRepository;
        }

        public IEnumerable<Anstalld> GetAllAnstallda()
        {
            return _anstalldRepository.GetAll();
        }

        public Anstalld GetAnstalldById(int id)
        {
            return _anstalldRepository.GetById(id);
        }
    }
}
