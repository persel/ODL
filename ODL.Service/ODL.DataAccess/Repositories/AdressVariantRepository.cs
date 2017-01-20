using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Repositories
{
    public class AdressVariantRepository : IAdressVariantRepository
    {
        private ODLDbContext DbContext { get; }
        private readonly Repository<AdressVariant, ODLDbContext> _internalGenericRepository;


        public AdressVariantRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<AdressVariant, ODLDbContext>(DbContext);
        }


        public void Update()
        {
            _internalGenericRepository.Update();
        }


        public void Add(AdressVariant nyAdressVariant)
        {
            _internalGenericRepository.Add(nyAdressVariant);
        }

        public AdressVariant GetVariantByVariantName(string adressVariant)
        {
            return _internalGenericRepository.FindSingle(av => av.Namn == adressVariant);
        }
    }
}
