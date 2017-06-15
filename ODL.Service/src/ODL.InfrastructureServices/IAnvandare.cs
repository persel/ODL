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
        bool IsBehorig();
    }
}
