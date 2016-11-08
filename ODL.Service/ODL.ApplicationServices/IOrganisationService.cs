using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ODL.DataAccess.Models;

namespace ODL.ApplicationServices
{
    public interface IOrganisationService
    {
        List<Resultatenhet> GetResultatenhetByPersonnummer(string personnummer);
    }
}
