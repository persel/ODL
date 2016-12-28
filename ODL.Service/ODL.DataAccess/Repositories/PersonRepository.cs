using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Repositories
{

    public class PersonRepository : IPersonRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Person, ODLDbContext> _internalGenericRepository;


        public PersonRepository(ODLDbContext dbContext)
        {
            //TODO-Marie
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Person, ODLDbContext>(DbContext);
        }

        public IEnumerable<int> GetAllaAvtalIdnPerPerson(string personnummer)
        {
            var person = _internalGenericRepository.FindSingle(p => p.Personnummer == personnummer);
            var allaAvtalIdn = person.AllaAvtalIdn();
            return allaAvtalIdn;
        }

        public List<Person> GetByAvtalIdn(IEnumerable<int> avtalIdn)
        {
            return DbContext.Person.Where(
                person => person.Anstalld.AnstallningsAvtal.Any(avtal => avtalIdn.Contains(avtal.AvtalFKId)) ||
                          person.Konsult.KonsultAvtal.Any(avtal => avtalIdn.Contains(avtal.AvtalFKId))).ToList();
        }
        
        public Person GetByPersonnummer(string personnummer)
        {
            var obj = DbContext.Person.FirstOrDefault(x => x.Personnummer == personnummer);

            return obj;

            //if (DbContext.Person.Any(p => p.Personnummer == personnummer))
            //{
            //    return p;
            //}
            //else
            //{
            //    return null;
            //}
            //return DbContext.Set<Person>()
            //    .Include(a => a.Anstalld.AnstallningsAvtal)
            //    .Include(k => k.Konsult.KonsultAvtal).Single(person => person.Personnummer == personnummer);
            //return _internalGenericRepository.FindSingle(person => person.Personnummer == personnummer);
            //return _internalGenericRepository.Find(person => person.Personnummer == personnummer);
        }

        public Anstalld GetAnstalld(int personId)
        {
            var obj = DbContext.Anstalld.FirstOrDefault(x => x.PersonFKId == personId);
            return obj;
        }

        public Konsult GetKonsult(int personId)
        {
            var obj = DbContext.Konsult.FirstOrDefault(x => x.PersonFKId == personId);
            return obj;
        }


        public Avtal GetByKallsystemId(string systemId)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            _internalGenericRepository.Update();
        }


        public void Add(Person nyPerson)
        {
            _internalGenericRepository.Add(nyPerson);
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
        
        public void Update()
        {
            _internalGenericRepository.Update(); // alt. dbContext.SaveChanges();
        }
        */
    }
}
