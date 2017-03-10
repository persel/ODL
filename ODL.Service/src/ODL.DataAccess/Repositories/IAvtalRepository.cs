using ODL.DomainModel.Person;

namespace ODL.DataAccess.Repositories
{
    public interface IAvtalRepository
    {
        Avtal GetByKallsystemId(string systemId);
        void Add(Avtal nyttAvtal);

        void Update();
    }
}