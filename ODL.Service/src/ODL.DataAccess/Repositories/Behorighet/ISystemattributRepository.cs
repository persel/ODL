using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.DomainModel.Behorighet.Systemattribut;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public interface ISystemattributRepository
    {
        int SparaSystemattribut(Systemattribut systemattribut);
    }
}
