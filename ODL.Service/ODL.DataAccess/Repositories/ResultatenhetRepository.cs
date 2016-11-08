using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // än vad vi behöver här.
            
            var resultatenheter = DbContext.Resultatenhet.SqlQuery(
                @"SELECT Resultatenhet.* FROM Person.Person
                INNER JOIN
                    (SELECT Konsult.PersonFKId PersonId, AvtalFKId FROM Person.Konsult Konsult JOIN Person.KonsultAvtal ON KonsultFKId = Konsult.Id
                    UNION ALL
                    SELECT Anstalld.PersonFKId PersonId, AvtalFKId FROM Person.Anstalld Anstalld JOIN Person.AnstalldAvtal ON AnstalldFKId = Anstalld.Id
                ) PersonAvtal
                ON Person.Id = PersonAvtal.PersonId
                JOIN Person.Avtal Avtal ON Avtal.Id = PersonAvtal.AvtalFKId
                JOIN Person.ResultatenhetAvtal ResultatenhetAvtal ON ResultatenhetAvtal.AvtalFKId = Avtal.Id
                JOIN Organisation.Resultatenhet Resultatenhet ON Resultatenhet.Id = ResultatenhetAvtal.ResultatenhetFKId
                WHERE Person.Personnummer = @p0", new SqlParameter("p0", personnummer));

            return resultatenheter.ToList();

        }
    }
}
