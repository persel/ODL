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
            // Hämta alla resultatenheter som denna person har avtal med, både som konsult och anställd.
            // Vanlig SQL används eftersom vi inte vill skapa ett större "aggregat" med fler ingående entiteter
            // än vad vi behöver här. Om vi skapar ett aggregat som innehåller både Resultatenhet och Person kan vi här använda Linq istället.
            
            var resultatenheter = DbContext.Resultatenhet.SqlQuery(
                RepositoryHelper.GetPersonToOrganisationSql("Resultatenhet.*", "Person.Personnummer = @p0"),
                new SqlParameter("p0", personnummer));

            return resultatenheter.ToList();

        }

        public Resultatenhet GetById(int id)
        {
            return _internalGenericRepository.GetById(id);
        }
    }
}
