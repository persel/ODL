using ODL.DomainModel.Behorighet.Verksamhetsdimension;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public class VerksamhetsdimensionRepository : IVerksamhetsdimensionRepository
    {
        private ODLDbContext DbContext { get; }
        private readonly Repository<Verksamhetsdimension, ODLDbContext> _internalGenericRepository;


        public VerksamhetsdimensionRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Verksamhetsdimension, ODLDbContext>(DbContext);
        }
        public int SparaVerksamhetsdimension(Verksamhetsdimension verksamhetsdimension)
        {
            throw new System.NotImplementedException();
        }
    }
}