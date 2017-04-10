using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<int> GetAvtalIdnByPersonId(int personId)
        {
            return _internalGenericRepository.Find(a => a.AnstalldAvtal.PersonId == personId || a.KonsultAvtal.PersonId == personId).Select(a => a.Id);
        }
    }
}
