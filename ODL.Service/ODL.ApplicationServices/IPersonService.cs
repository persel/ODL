using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.ApplicationServices.Models;
using ODL.DataAccess.Models.Person;

namespace ODL.ApplicationServices
{
    public interface IPersonService
    {
        /// <summary>
        /// Hämtar alla Personer som har avtal med angiven resultatenhet eller andra resultatenheter i samma
        /// organisationshierarki
        /// </summary>
        List<PersonDTO> GetByResultatenhetId(int resultatenhetId);

        //IEnumerable<Anstalld> GetAllAnställda();
        //Anstalld GetAnställdById(int id);
        
    }
}
