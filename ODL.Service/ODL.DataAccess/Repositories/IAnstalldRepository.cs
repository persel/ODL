using System.Collections.Generic;
using ODL.DataAccess.Models;

namespace ODL.DataAccess.Repositories
{
    // Repository-interfacen kan också placeras i ett annat projekt med mer lös koppling till implementationen (se hexagonal architecture etc)
    // Här väljer vi dock att förenkla och lägga både interface och implementationer i DataAccess-projektet.
    // För bättre testbarhet bör vi dock injecta implementationen via DI etc.

    public interface IAnstalldRepository
    {
        IEnumerable<Anstalld> GetAll();
        IEnumerable<Anstalld> GetByAlias(string alias);
        Anstalld GetById(int id);
        void Update();
    }
}