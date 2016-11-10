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
        List<Person> GetByResultatenhetId(int resultatenhetId);

        //IEnumerable<Anställd> GetAllAnställda();
        //Anställd GetAnställdById(int id);
        
    }
}
