using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.DomainModel.Behorighet.Systemroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public interface ISystemanvandargruppRepository
    {
        int SparaSystemanvandargrupp(Systemanvandargrupp systemanvandargrupp);
    }
}
