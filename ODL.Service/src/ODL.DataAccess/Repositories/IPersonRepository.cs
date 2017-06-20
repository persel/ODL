using System.Collections.Generic;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Repositories
{
    // Repository-interfacen kan också placeras i ett annat projekt med mer lös koppling till implementationen (se hexagonal architecture etc)
    // Här väljer vi dock att förenkla och lägga både interface och implementationer i DataAccess-projektet.

    public interface IPersonRepository
    {
        
        Person GetByPersonnummer(string personnummer);

        bool Exists(string personnummer);

        void Update();

        void Add(Person person);

    }
}