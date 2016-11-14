using System;
using System.Collections.Generic;
using System.Linq;

namespace ODL.DataAccess.Models.Extensions
{
    // Extension methods används för viss logik i EF-modellen, så ev. omskapande av modellen via "EF database first" inte 
    // skriver över egenskriven kod i modellklasserna

    public static class PersonExtensions
    {
        public static bool IsAnstalld(this Person.Person person)
        {
            return person.Anstalld != null;
        }

        public static bool IsKonsult(this Person.Person person)
        {
            return person.Konsult != null;
        }

        public static IEnumerable<int> AllaAvtalIdn(this Person.Person person)
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
        public static bool KoppladTill(this Person.Person person, Organisation.Organisation organisation)
        {
            return person.AllaAvtalIdn().Intersect(organisation.AllaAvtalIdn).Any();
        }
    }
}
