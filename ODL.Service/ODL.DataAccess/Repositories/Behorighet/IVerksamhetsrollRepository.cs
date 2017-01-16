using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.DomainModel.Behorighet.Verksamhetsroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public interface IVerksamhetsrollRepository
    {
        int SparaVerksamhetsroll(Verksamhetsroll verksamhetsroll);
    }
}
