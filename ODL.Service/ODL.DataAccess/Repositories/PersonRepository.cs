using System.Collections.Generic;
using System.Data.SqlClient;
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


        public List<Person> GetByResultatenhetId(IEnumerable<int> idn)
        {
            var test = _internalGenericRepository.GetById(7);
            // Hämta alla personer på dessa resultatenheter.

            // Vanlig SQL används eftersom vi inte vill skapa ett större "aggregat" med fler ingående entiteter
            // än vad vi behöver här. Om vi skapar ett aggregat som innehåller både Resultatenhet och Person kan vi här använda Linq istället.

            var parameters = idn.Select((id, index) => new SqlParameter($"p{index}", id));
            var parameterString = string.Join(",", parameters.Select(param => "@" + param.ParameterName));
        
            var personIdn = DbContext.Database.SqlQuery<int>(
                RepositoryHelper.GetPersonToOrganisationSql("Person.Id", $"Resultatenhet.OrganisationFKId IN({parameterString})"),
                parameters.ToArray());

            // Går via en lista av idn istället för Person direkt eftersom SqlQuery inte klarar mappning (t.ex. Fornamn -> Förnamn)
            return DbContext.Person.Where(person => personIdn.Contains(person.Id)).ToList();
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
