using System;
using ODL.DomainModel.Behorighet.Verksamhetsroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public class VerksamhetsrollRepository : IVerksamhetsrollRepository
    {
        private ODLDbContext DbContext { get; }
        private readonly Repository<Verksamhetsroll, ODLDbContext> _internalGenericRepository;


        public VerksamhetsrollRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Verksamhetsroll, ODLDbContext>(DbContext);
        }

        public int SparaVerksamhetsroll(Verksamhetsroll verksamhetsroll)
        {
            throw new NotImplementedException();
        }
    }
}