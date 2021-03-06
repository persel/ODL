﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Repositories
{
    public class OrganisationRepository : IOrganisationRepository
    {

        private ODLDbContext DbContext { get; }
        private readonly Repository<Organisation, ODLDbContext> _internalGenericRepository;


        public OrganisationRepository(ODLDbContext dbContext)
        {
            DbContext = dbContext;
            _internalGenericRepository = new Repository<Organisation, ODLDbContext>(DbContext);
        }

        public Organisation GetByOrgId(string orgId)
        {
            var obj = DbContext.Organisation.FirstOrDefault(x => x.OrganisationsId == orgId);
            return obj;
        }

        public IList<Organisation> GetAll()
        {
            return DbContext.Set<Organisation>().ToList();
        }

        public void Update()
        {
            _internalGenericRepository.Update();
        }


        public void Add(Organisation nyOrganisation)
        {
            _internalGenericRepository.Add(nyOrganisation);
        }

        public Organisation GetOrganisationByKstnr(string kstnr)
        {
            return _internalGenericRepository.FindSingle(org => org.Resultatenhet.KstNr == kstnr);
        }
    }
}
