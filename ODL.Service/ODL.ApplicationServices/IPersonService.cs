using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.DataAccess.Models;

namespace ODL.ApplicationServices
{
    public interface IPersonService
    {
        /// <summary>
        /// Hämtar alla Personer som har avtal med angiven resultatenhet eller andra resultatenheter i samma
        /// organisationshierarki
        /// </summary>
        List<Person> GetByResultatenhetId(int resultatenhetId);

        //IEnumerable<Anställd> GetAllAnställda();
        //Anställd GetAnställdById(int id);
        
    }
}
