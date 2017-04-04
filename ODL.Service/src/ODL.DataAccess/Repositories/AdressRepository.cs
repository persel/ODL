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
            return _internalGenericRepository.Find(adress => adress.PersonAdress.PersonId == personId);
        }

        public IEnumerable<Adress> GetAdresserPerPersonummer(string personnummer)
        {
            var person = DbContext.Person.Single(p => p.Personnummer == personnummer);
            return _internalGenericRepository.Find(adress => adress.PersonAdress.PersonId == person.Id);
        }

        public IEnumerable<Adress> GetAdresserPerOrganisationsId(int organisationsId)
        {
            return
                _internalGenericRepository.Find(adress => adress.OrganisationAdress.OrganisationId == organisationsId);
        }

        public Adress GetAdressPerPersonIdAndVariantId(int personId, int variantId)
        {
            return
                _internalGenericRepository.FindSingle(a => a.PersonAdress.PersonId == personId && a.AdressVariantFKId == variantId);
        }

        public Adress GetAdressPerOrganisationsIdAndVariantId(int orgId, int variantId)
        {
            return
                _internalGenericRepository.FindSingle(
                    a => a.OrganisationAdress.OrganisationId == orgId && a.AdressVariantFKId == variantId);
        }


        public IEnumerable<Adress> GetAdressPerOrganisationsIdAndVariantIdList(int orgId, int variantId)
        {
            return
                _internalGenericRepository.Find(
                    a => a.OrganisationAdress.OrganisationId == orgId && a.AdressVariantFKId == variantId).ToList();
        }

    }
}