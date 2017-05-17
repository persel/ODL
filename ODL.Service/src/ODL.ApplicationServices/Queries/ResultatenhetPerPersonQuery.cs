using System.Collections.Generic;
using System.Linq;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess;
using ODL.DomainModel;
using ODL.DomainModel.Avtal;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices.Queries
{
    internal class ResultatenhetPerPersonQuery
    {
        public IContext DbContext { get; set; }

        public ResultatenhetPerPersonQuery(IContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<ResultatenhetDTO> Execute(int personId)
        {
            var allaAvtal = DbContext.DbSet<Avtal>();
            var organisationer = DbContext.DbSet<Organisation>();
            var allaOrganisationsAvtal = DbContext.DbSet<OrganisationAvtal>();
            
            var projektionResultatenheter = from avtal in allaAvtal 
                join organisationsAvtal in allaOrganisationsAvtal on avtal.Id equals organisationsAvtal.AvtalId
                join organisation in organisationer on organisationsAvtal.OrganisationId equals organisation.Id
                where avtal.KonsultAvtal.PersonId == personId || avtal.AnstalldAvtal.PersonId == personId
                select new ResultatenhetDTO { Id = organisation.Id, KostnadsstalleNr = organisation.Resultatenhet.KstNr, Typ = organisation.Resultatenhet.Typ, Namn = organisation.Namn};

            return projektionResultatenheter.Distinct();

        }
    }
}
