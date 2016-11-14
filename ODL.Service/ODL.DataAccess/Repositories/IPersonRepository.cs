﻿using System.Collections.Generic;
using ODL.DataAccess.Models.Person;

namespace ODL.DataAccess.Repositories
{
    // Repository-interfacen kan också placeras i ett annat projekt med mer lös koppling till implementationen (se hexagonal architecture etc)
    // Här väljer vi dock att förenkla och lägga både interface och implementationer i DataAccess-projektet.

    public interface IPersonRepository
    {
        /// <summary>
        /// Hämta alla personer på dessa avtal.
        /// </summary>
        List<Person> GetByAvtalIdn(IEnumerable<int> avtalIdn);

        Person GetByPersonnummer(string personnummer);
    }
}