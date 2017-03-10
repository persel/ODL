using ODL.DomainModel.Behorighet.Systemattribut;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public class SystemattributRepository : ISystemattributRepository
    {
        private ODLDbContext DbContext { get; }
        private readonly Repository<Systemattribut, ODLDbContext> _internalGenericRepository;


        public SystemattributRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Systemattribut, ODLDbContext>(DbContext);
        }

        public int SparaSystemattribut(Systemattribut systemattribut)
        {
            throw new System.NotImplementedException();
        }
    }
}