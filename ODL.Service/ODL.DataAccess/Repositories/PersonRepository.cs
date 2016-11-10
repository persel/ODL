using System.Collections.Generic;
using System.Linq;
using ODL.DataAccess.Models;


namespace ODL.DataAccess.Repositories
{

    public class PersonRepository : IPersonRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Person, ODLDbContext> _internalGenericRepository;


        public PersonRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Person, ODLDbContext>(DbContext);
        }

        public List<Person> GetByResultatenhetId(int resultatenhetId)
        {
            // Hämta alla personer kopplade till angiven resultatenhet.

            // Vanlig SQL används eftersom vi inte vill skapa ett större "aggregat" med fler ingående entiteter
            // än vad vi behöver här. Om vi skapar ett aggregat som innehåller både Resultatenhet och Person kan vi använda här linq istället.

            var personIds = new int[1];
            
            return DbContext.Person.Where(person => personIds.Contains(person.Id)).ToList();
            
        }

        /*
        
        // Här kan man implementera mer specialiserade metoder för att hämta Person, direkt genom context eller genom att använda den generiska Repository<T>
        
        public IEnumerable<Person> GetAll()
        {
            return _internalGenericRepository.GetAll();
        }

        public Person GetById(int id)
        {
            return _internalGenericRepository.GetById(id);
        }

        public IEnumerable<Person> GetByPersonnummer(string personnummer)
        {
            return _internalGenericRepository.Find(person => person.Personnummer == personnummer);
        }

        public void Update()
        {
            _internalGenericRepository.Update(); // alt. dbContext.SaveChanges();
        }
        */
    }
}
