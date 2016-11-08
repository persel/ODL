using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.DataAccess.Models;

namespace ODL.DataAccess.Repositories
{
    public interface IResultatenhetRepository
    {
        List<Resultatenhet> GetByPersonnummer(string personnummer);
    }
}
