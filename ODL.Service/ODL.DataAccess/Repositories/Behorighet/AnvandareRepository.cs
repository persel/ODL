using ODL.DomainModel.Behorighet.Systemroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public class AnvandareRepository : IAnvandareRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Anvandare, ODLDbContext> _internalGenericRepository;


        public AnvandareRepository(ODLDbContext dbContext)
        {

            DbContext = dbContext;
            _internalGenericRepository = new Repository<Anvandare, ODLDbContext>(DbContext);
        }

        public int SparaAnvandare(Anvandare anvandare)
        {
            throw new System.NotImplementedException();
        }
    }
}