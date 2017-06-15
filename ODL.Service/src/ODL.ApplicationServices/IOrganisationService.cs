using System.Collections;
using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;

namespace ODL.ApplicationServices
{
    public interface IOrganisationService
    {
        /// <summary>
        /// Hämtar alla resultatenheter med vilka angiven person har ett avtal.
        /// </summary>
        IEnumerable<ResultatenhetDTO> GetResultatenheterForPersonnummer(string personnummer);
        IEnumerable<ResultatenhetDTO> GetResultatenheter();

        ResultatenhetDTO GetResultatenhetForKstNr(string kostnadsstalleNr);
        void SparaResultatenheter(IList<ResultatenhetInputDTO> resultatenheter);
    }
}
