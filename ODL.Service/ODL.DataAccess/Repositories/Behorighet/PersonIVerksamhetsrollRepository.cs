
using ODL.DomainModel.Behorighet.Verksamhetsroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public interface PersonIVerksamhetsrollRepository
    {
        int SparaPersonIVerksamhetsroll(PersonIVerksamhetsroll personIVerksamhetsroll);
    }
}
