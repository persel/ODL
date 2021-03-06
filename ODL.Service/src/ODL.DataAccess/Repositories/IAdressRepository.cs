﻿using System.Collections.Generic;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Repositories
{
    public interface IAdressRepository
    {
        void Add(Adress nyAdress);

        void Update();

        Adress GetByAdressId(int adressId);
        IEnumerable<Adress> GetAdresserPerPersonId(int personId);

        IEnumerable<Adress> GetAdresserPerOrganisationsId(int organisationsId);

        IEnumerable<Adress> GetAdresserPerPersonummer(string personnummer);

        Adress GetAdressPerAdressInnehavareAndAdressvariant(Adressinnehavare adressinnehavare, Adressvariant variant);

        Adress GetAdressPerPersonIdAndAdressvariant(int personId, Adressvariant variant);
        
        Adress GetAdressPerOrganisationsIdAndAdressvariant(int organisationsId, Adressvariant variant);
    }
}