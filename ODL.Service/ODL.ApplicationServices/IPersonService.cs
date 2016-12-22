using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel;
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
        List<PersonDTO> GetByResultatenhetId(int resultatenhetId);
        
        void SparaAvtal(AvtalInputDTO avtal);
    }
}
