using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;

namespace ODL.ApplicationServices
{
    public interface IPersonService
    {
        /// <summary>
        /// Hämtar alla Personer som har avtal med angiven resultatenhet eller andra resultatenheter i samma
        /// organisationshierarki
        /// </summary>

        void SparaAvtal(AvtalInputDTO avtal);

        void SparaPerson(PersonInputDTO person);

        PersonDTO GetPersonByPersonnummer(string personnummer);
        IEnumerable<PersonPerResultatenhetDTO> GetPersonerPerResultatenhet(string kstNr);
    }
}
