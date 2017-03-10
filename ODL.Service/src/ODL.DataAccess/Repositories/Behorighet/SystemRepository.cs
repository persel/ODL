
namespace ODL.DataAccess.Repositories.Behorighet
{
    public class SystemRepository : ISystemRepository
    {
        private ODLDbContext DbContext { get; }
        private readonly Repository<DomainModel.Behorighet.Systemroll.System, ODLDbContext> _internalGenericRepository;
        
        public SystemRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<DomainModel.Behorighet.Systemroll.System, ODLDbContext>(DbContext);
        }

        public int SparaSystem(DomainModel.Behorighet.Systemroll.System system)
        {
            throw new System.NotImplementedException();
        }
    }
}