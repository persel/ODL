using ODL.DomainModel.Person;

namespace ODL.DataAccess.Repositories
{
    public class AvtalRepository : IAvtalRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Avtal, ODLDbContext> _internalGenericRepository;


        public AvtalRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Avtal, ODLDbContext>(DbContext);
        }

        public Avtal GetByKallsystemId(string systemId)
        {
            return _internalGenericRepository.FindSingle(avtal => avtal.KallsystemId == systemId);
        }

        public void Add(Avtal nyttAvtal)
        {
            _internalGenericRepository.Add(nyttAvtal);
        }

        public void Update()
        {
            _internalGenericRepository.Update();
        }
    }
}
