using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.DataAccess.Models;
using ODL.DataAccess.Repositories;

namespace ODL.ApplicationServices
{
    public class OrganisationService : IOrganisationService
    {

        private readonly IResultatenhetRepository _resultatenhetRepository;

        public OrganisationService(IResultatenhetRepository resultatenhetRepository)
        {
            _resultatenhetRepository = resultatenhetRepository;
        }

        public List<Resultatenhet> GetResultatenhetByPersonnummer(string personnummer)
        {
            return _resultatenhetRepository.GetByPersonnummer(personnummer);
        }
    }
}
