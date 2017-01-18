using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public Adress GetByAdressId(int adressId)
        {
            return _internalGenericRepository.FindSingle(adress => adress.Id == adressId);
        }

    }
}