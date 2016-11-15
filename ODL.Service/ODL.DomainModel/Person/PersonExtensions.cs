using System;
using System.Collections.Generic;
using System.Linq;

namespace ODL.DomainModel.Person
{
    // Extension methods används för implementation av logik i domain model, så att ev. omskapande av modellen via "EF database first" inte 
    // skriver över egenskriven kod i modellklasserna. Kan flyttas till resp. klass när vi inte längre genererar från databasen.

    public static class PersonExtensions
    {
        public static bool IsAnstalld(this Person person)
        {
            return person.Anstalld != null;
        }

        public static bool IsKonsult(this Person person)
        {
            return person.Konsult != null;
        }

        public static IEnumerable<int> AllaAvtalIdn(this Person person)
        {
            if (person.IsAnstalld() && person.IsKonsult())
                return person.Anstalld.AnstallningsAvtalIdn.Concat(person.Konsult.KonsultAvtalIdn);
            return person.IsAnstalld()
                ? person.Anstalld.AnstallningsAvtalIdn
                : (person.IsKonsult() ? person.Konsult.KonsultAvtalIdn : new List<int>()); // Tar hänsyn till om en person är varken konsult eller anställd...
        }

        /// <summary>
        /// Personen är kopplad till organisationen genom minst ett avtal 
        /// </summary>
        public static bool KoppladTill(this Person person, Organisation.Organisation organisation)
        {
            return person.AllaAvtalIdn().Intersect(organisation.AllaAvtalIdn).Any();
        }
    }
}
