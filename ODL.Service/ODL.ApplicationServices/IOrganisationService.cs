using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel;

namespace ODL.ApplicationServices
{
    public interface IOrganisationService
    {
        /// <summary>
        /// Hämtar alla resultatenheter med vilka angiven person har ett avtal.
        /// </summary>
        IEnumerable<ResultatenhetDTO> GetResultatenhetByPersonnummer(string personnummer);
    }
}
