using System.Collections.Generic;
using ODL.DataAccess.Models;


namespace ODL.DataAccess.Repositories
{

    public class AnstalldRepository : IAnstalldRepository
    {
        private ModelDbContext DbContext { get; }
        private readonly Repository<Anstalld, ModelDbContext> _internalGenericRepository;

        public AnstalldRepository(ModelDbContext dbContext)
        {
            // Skapa DbContext genom dependency injection. Använd en DbContext per tjänsteanrop. Återanvänd i de olika Repositories. Se http://mehdi.me/ambient-dbcontext-in-ef6/

            DbContext = dbContext;
            _internalGenericRepository = new Repository<Anstalld, ModelDbContext>(DbContext);
        }
        
        // Här kan man implementera mer specialiserade metoder för att hämta Anstalld, direkt genom context eller genom att använda den generiska Repository<T>
        
        public IEnumerable<Anstalld> GetAll()
        {
            return _internalGenericRepository.GetAll();
        }

        public Anstalld GetById(int id)
        {
            return _internalGenericRepository.GetById(id);
        }

        public IEnumerable<Anstalld> GetByAlias(string alias)
        {
            return _internalGenericRepository.Find(candidate => candidate.Alias == alias);
        }

        public void Update()
        {
            _internalGenericRepository.Update(); // alt. dbContext.SaveChanges();
        }
    }
}
