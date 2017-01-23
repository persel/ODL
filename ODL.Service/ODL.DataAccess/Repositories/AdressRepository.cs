using System;
using System.Collections.Generic;
using System.Linq;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Repositories
{
    public class AdressRepository : IAdressRepository
    {
        private ODLDbContext DbContext { get; }
        private readonly Repository<Adress, ODLDbContext> _internalGenericRepository;


        public AdressRepository(ODLDbContext dbContext)
        {
            //TODO-Marie
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Adress, ODLDbContext>(DbContext);
        }

        public void Add(Adress nyAdress)
        {
            _internalGenericRepository.Add(nyAdress);
        }

        public void Update()
        {
            _internalGenericRepository.Update();
        }

        public Adress GetByAdressId(int adressId)
        {
            return _internalGenericRepository.FindSingle(adress => adress.Id == adressId);
        }

        public IEnumerable<Adress> GetAdresserPerPersonId(int personId)
        {
            return _internalGenericRepository.Find(adress => adress.PersonAdress.PersonFKId == personId);
        }

        public IEnumerable<Adress> GetAdresserPerPersonummer(string personnummer)
        {
            throw new NotImplementedException();
            //var person = DbContext.Person.Find(p => p.Personnummer == personnummer);
            //return _internalGenericRepository.Find(adress => adress.PersonAdress.PersonFKId == person.personId);
        }

        public Adress GetAdressPerPersonIdAndVariantId(int personId, int variantId)
        {
            return
                _internalGenericRepository.FindSingle(a => a.PersonAdress.PersonFKId == personId && a.AdressVariantFKId == variantId);
        }

        public Adress GetAdressPerOrganisationsIdAndVariantId(int orgId, int variantId)
        {
            return
                _internalGenericRepository.FindSingle(
                    a => a.OrganisationAdress.OrganisationFKId == orgId && a.AdressVariantFKId == variantId);
        }

    }
}