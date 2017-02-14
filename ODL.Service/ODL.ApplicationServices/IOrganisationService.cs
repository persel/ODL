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
        IEnumerable<ResultatenhetDTO> GetResultatenhetByPersonnummer(string personnummer);
        IEnumerable<ResultatenhetDTO> GetResultatenheter();
        IEnumerable<ResultatenhetDTO> GetResultatenheterByKstNr(List<int> kostnadsstalleNr);
        void SparaResultatenhet(ResultatenhetInputDTO resEnhet);
    }
}
