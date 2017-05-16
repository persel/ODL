
using System.Collections.Generic;

using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Repositories
{
    public interface IOrganisationRepository
    {
        Organisation GetByOrgId(string orgId);

        IList<Organisation> GetAll();
        void Update();
        void Add(Organisation organisation);
        Organisation GetOrganisationByKstnr(string kstNr);
        
    }
}
