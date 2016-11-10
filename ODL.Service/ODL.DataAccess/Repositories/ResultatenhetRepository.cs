using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ODL.DataAccess.Models;

namespace ODL.DataAccess.Repositories
{
    public class ResultatenhetRepository : IResultatenhetRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Resultatenhet, ODLDbContext> _internalGenericRepository;


        public ResultatenhetRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Resultatenhet, ODLDbContext>(DbContext);
        }

        public List<Resultatenhet> GetByPersonnummer(string personnummer)
        {
            // Hämta alla resultatenheter kopplade till angiven person, både som konsult och anställd.
            // Vanlig SQL används eftersom vi inte vill skapa ett större "aggregat" med fler ingående entiteter
            // än vad vi behöver här. Om vi skapar ett aggregat som innehåller både Resultatenhet och Person kan vi använda här linq istället.
            
            var resultatenheter = DbContext.Resultatenhet.SqlQuery(
                @"SELECT Resultatenhet.* FROM Person.Person
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
                WHERE Person.Personnummer = @p0", new SqlParameter("p0", personnummer));

            return resultatenheter.ToList();

        }
    }
}
