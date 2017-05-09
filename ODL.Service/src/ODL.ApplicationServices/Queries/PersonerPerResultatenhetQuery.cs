using System.Collections.Generic;
using System.Linq;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess;
using ODL.DomainModel;
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

        public IEnumerable<PersonPerResultatenhetDTO> Execute(string kstNr)
        {
            var allaAvtal = DbContext.DbSet<Avtal>();
            var personer = DbContext.DbSet<Person>();
            var organisationer = DbContext.DbSet<Organisation>();
            var allaOrganisationsAvtal = DbContext.DbSet<OrganisationAvtal>();

            // Vi delar upp frågan i två separata delar för enkelhets skull:

            var projektionAnstallda = from person in personer
                join avtal in allaAvtal on person.Id equals avtal.AnstalldAvtal.PersonId
                join organisationsAvtal in allaOrganisationsAvtal on avtal.Id equals organisationsAvtal.AvtalId
                join organisation in organisationer on organisationsAvtal.OrganisationId equals organisation.Id
                where organisation.Resultatenhet.KstNr == kstNr
                select new PersonPerResultatenhetDTO { Id = person.Id, KostnadsstalleNr = kstNr, Personnummer = person.Personnummer, Namn = person.Fornamn + " " + person.Efternamn, Resultatenhetansvarig = avtal.Ansvarig};

            var projektionKonsulter = from person in personer
                                      join avtal in allaAvtal on person.Id equals avtal.KonsultAvtal.PersonId
                                      join organisationsAvtal in allaOrganisationsAvtal on avtal.Id equals organisationsAvtal.AvtalId
                                      join organisation in organisationer on organisationsAvtal.OrganisationId equals organisation.Id
                                      where organisation.Resultatenhet.KstNr == kstNr
                                      select new PersonPerResultatenhetDTO { Id = person.Id, KostnadsstalleNr = kstNr, Personnummer = person.Personnummer, Namn = person.Fornamn + " " + person.Efternamn, Resultatenhetansvarig = avtal.Ansvarig };


            var anstallda = projektionAnstallda.ToList();
            var konsulter = projektionKonsulter.ToList();


            anstallda.AddRange(konsulter); // TODO: Ta bort dubletter, ansvarig = true om både true/false finns

            var personPerResultatenhet = anstallda.GroupBy(a => a.Personnummer)
                .Select(g => g.OrderByDescending(p => p.Resultatenhetansvarig).First()); // OrderBy bool: false (0) först, därefter true (1)

            return personPerResultatenhet;


        }
    }
}
