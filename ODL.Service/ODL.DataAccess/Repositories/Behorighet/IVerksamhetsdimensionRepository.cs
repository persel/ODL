using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.DomainModel.Behorighet.Verksamhetsdimension;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public interface IVerksamhetsdimensionRepository
    {
        int SparaVerksamhetsdimension(Verksamhetsdimension verksamhetsdimension);
    }
}
