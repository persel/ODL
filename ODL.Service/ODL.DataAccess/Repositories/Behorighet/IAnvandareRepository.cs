using ODL.DomainModel.Behorighet.Systemroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public interface IAnvandareRepository
    {
        int SparaAnvandare(Anvandare anvandare);
    }
}
