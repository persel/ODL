using System;
using System.Collections.Generic;
using System.Linq;
using ODL.DomainModel.Adress;

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

        public Adress GetAdressPerAdressInnehavareAndAdressvariant(Adressinnehavare adressinnehavare, Adressvariant variant)
        {
            if (adressinnehavare.IsPerson)
                return _internalGenericRepository.FindSingle( a => a.PersonAdress.PersonId == adressinnehavare.Id && a.Adressvariant == variant);
            if (adressinnehavare.IsOrganisation)
                return _internalGenericRepository.FindSingle( a => a.OrganisationAdress.OrganisationId == adressinnehavare.Id && a.Adressvariant == variant);
            throw new ArgumentException($"Ogiltig typ: {adressinnehavare}");
        }

    public Adress GetAdressPerPersonIdAndAdressvariant(int personId, Adressvariant variant)
        {
            return
                _internalGenericRepository.FindSingle(a => a.PersonAdress.PersonId == personId && a.Adressvariant == variant);
        }
        
        public Adress GetAdressPerOrganisationsIdAndAdressvariant(int orgId, Adressvariant variant)
        {
            return
                _internalGenericRepository.FindSingle(
                    a => a.OrganisationAdress.OrganisationId == orgId && a.Adressvariant == variant);
        }

    }
}