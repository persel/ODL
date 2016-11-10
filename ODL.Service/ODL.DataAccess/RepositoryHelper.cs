using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODL.DataAccess
{
    internal class RepositoryHelper
    {
        internal static string GetPersonToOrganisationSql(string selectClause, string whereClause)
        {
            return $@"SELECT {selectClause} FROM Person.Person
                INNER JOIN
                    (SELECT Konsult.PersonFKId PersonId, AvtalFKId
                FROM Person.Konsult Konsult JOIN Person.KonsultAvtal KonsultAvtal ON KonsultAvtal.PersonFKId = Konsult.PersonFKId
                    UNION ALL
                SELECT Anstalld.PersonFKId PersonId, AvtalFKId
                FROM Person.Anstalld Anstalld JOIN Person.AnstalldAvtal AnstalldAvtal ON AnstalldAvtal.PersonFKId = Anstalld.PersonFKId
                ) PersonAvtal
                ON Person.Id = PersonAvtal.PersonId
                JOIN Person.Avtal Avtal ON Avtal.Id = PersonAvtal.AvtalFKId
                JOIN Person.OrganisationAvtal OrganisationAvtal ON OrganisationAvtal.AvtalFKId = Avtal.Id
                JOIN Organisation.Organisation Organisation ON Organisation.Id = OrganisationAvtal.OrganisationFKId
                JOIN Organisation.Resultatenhet Resultatenhet ON Resultatenhet.OrganisationFKId = Organisation.Id
                WHERE {whereClause}";
        }
    }
}
