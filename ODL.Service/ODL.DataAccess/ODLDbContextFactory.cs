using System.Data.Entity.Infrastructure;

namespace ODL.DataAccess
{
    public class ODLDbContextFactory : IDbContextFactory<ODLDbContext>
    {
        public ODLDbContext Create()
        {
            // TODO: This constructor is used by the EF6 command line tools - Change this so that we use same connection string as the calling application
            // See: https://docs.asp.net/en/latest/data/entity-framework-6.html 

            return new ODLDbContext("Server=(localdb)\\mssqllocaldb;Database=EF6MVCCore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}