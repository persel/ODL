using System;
using System.Collections.Generic;
using System.Linq;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess;
using ODL.DomainModel;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices.Queries
{
    internal class PersonerPerResultatenhetQuery
    {
        public IContext DbContext { get; set; }

        public PersonerPerResultatenhetQuery(IContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<PersonPerResultatenhetDTO> Execute(string kstNr)
        {
            var allaAvtal = DbContext.DbSet<Avtal>();
            var allaAnstalldAvtal = DbContext.DbSet<AnstalldAvtal>(); // Denna kan utelämnas och joinas mha navigation property, men det komplicerar det genrerade SQL-scriptet
            var allaKonsultAvtal = DbContext.DbSet<KonsultAvtal>();
            var personer = DbContext.DbSet<Person>();
            var organisationer = DbContext.DbSet<Organisation>();
            var allaOrganisationsAvtal = DbContext.DbSet<OrganisationAvtal>();
            
            var projektion = from person in personer

                from anstalldAvtal in allaAnstalldAvtal
                from konsultAvtal in allaKonsultAvtal
                from avtal in allaAvtal

                //join anstalldAvtal in allaAnstalldAvtal on person.Id equals anstalldAvtal.PersonId
                //join avtal in allaAvtal on anstalldAvtal.AvtalId equals avtal.Id
                join organisationsAvtal in allaOrganisationsAvtal on avtal.Id equals organisationsAvtal.AvtalId
                join organisation in organisationer on organisationsAvtal.OrganisationId equals organisation.Id
                where organisation.Resultatenhet.KstNr == kstNr && (avtal.Id == anstalldAvtal.AvtalId || avtal.Id == konsultAvtal.AvtalId)
                             select new PersonPerResultatenhetDTO { Id = person.Id, KostnadsstalleNr = kstNr, Personnummer = person.Personnummer, Namn = $"{person.Fornamn} {person.Efternamn}", Resultatenhetansvarig = avtal.Ansvarig};


            return projektion.ToList(); // Ta bort dubletter

        }
    }
}
