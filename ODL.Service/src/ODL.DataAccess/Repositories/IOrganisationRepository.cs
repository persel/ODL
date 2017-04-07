﻿
using System.Collections.Generic;

using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Repositories
{
    public interface IOrganisationRepository
    {
        Organisation GetByOrgId(string orgId);

        /// <summary>
        /// Hämta alla Organisationer på dessa avtal.
        /// </summary>
        IList<Organisation> GetByAvtalIdn(IEnumerable<int> avtalIdn);

        IList<Organisation> GetWhereAnsvarigByAvtalIdn(IEnumerable<int> avtalIdn);

        IList<Organisation> GetByKstNr(List<string> kstNrList);
        IList<Organisation> GetAll();
        void Update();
        void Add(Organisation organisation);
        Organisation GetOrganisationByKstnr(string kstNr);
       List<Organisation> GetOrganisationerByKstnr(IEnumerable<string> kstNrList);
        
    }
}
