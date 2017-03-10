using ODL.DomainModel.Behorighet.Verksamhetsroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public interface IPersonalRepository
    {
        int SparaPersonal(Personal personal);
        Personal GetPersonalByPersonnummer(string personnummer);
    }
}
