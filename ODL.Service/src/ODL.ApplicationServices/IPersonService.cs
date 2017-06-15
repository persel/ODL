using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;

namespace ODL.ApplicationServices
{
    public interface IPersonService
    {
        void SparaPerson(PersonInputDTO person);
        PersonDTO GetPersonByPersonnummer(string personnummer);
        IEnumerable<PersonPerResultatenhetDTO> GetPersonerPerResultatenhet(string kstNr);
    }
}
