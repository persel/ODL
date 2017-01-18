using ODL.DomainModel.Behorighet.Systemroll;
using ODL.DomainModel.Behorighet.Verksamhetsroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public class PersonalRepository : IPersonalRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Personal, ODLDbContext> _internalGenericRepository;

        public PersonalRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Personal, ODLDbContext>(DbContext);
        }

        public int SparaPersonal(Personal personal)
        {
            throw new System.NotImplementedException();
        }

        public Personal GetPersonalByPersonnummer(string personnummer)
        {
            return new Personal();
        }
    }
}