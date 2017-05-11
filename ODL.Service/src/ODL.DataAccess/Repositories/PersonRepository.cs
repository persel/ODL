using System;
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
        
        public Person GetByPersonnummer(string personnummer)
        {
            return DbContext.Person.SingleOrDefault(person => person.Personnummer == personnummer);
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
