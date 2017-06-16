using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ODL.InfrastructureServices
{
    public interface IAnvandare
    {
       string Personnummer { get; }

        string AnvandarNamn { get; }

        string Namn { get; }

        string Email { get; }

        IEnumerable<string> Roler { get; }
        IEnumerable<string> Rbac { get; }

        string Applikation { get; }

        bool IsBehorig();
    }
}
