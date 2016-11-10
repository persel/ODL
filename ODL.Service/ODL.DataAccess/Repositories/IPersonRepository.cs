using System.Collections.Generic;
using ODL.DataAccess.Models;

namespace ODL.DataAccess.Repositories
{
    // Repository-interfacen kan också placeras i ett annat projekt med mer lös koppling till implementationen (se hexagonal architecture etc)
    // Här väljer vi dock att förenkla och lägga både interface och implementationer i DataAccess-projektet.
    // För bättre testbarhet bör vi dock injecta implementationen via DI etc.

    public interface IPersonRepository
    {
        /*
        IEnumerable<Anställd> GetAll();
        IEnumerable<Anställd> GetByAlias(string alias);
        Anställd GetById(int id);
        void Update();
        */
        List<Person> GetByResultatenhetId(int resultatenhetId);
    }
}