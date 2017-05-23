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
                select new { Id = person.Id, KostnadsstalleNr = kstNr, Personnummer = person.Personnummer, Fornamn = person.Fornamn, Efternamn = person.Efternamn, Resultatenhetansvarig = avtal.Ansvarig, Anstallningsdatum = avtal.Anstallningsdatum, Avgangsdatum = avtal.Avgangsdatum };

            var projektionKonsulter = from person in personer
                                      join avtal in allaAvtal on person.Id equals avtal.KonsultAvtal.PersonId
                                      join organisationsAvtal in allaOrganisationsAvtal on avtal.Id equals organisationsAvtal.AvtalId
                                      join organisation in organisationer on organisationsAvtal.OrganisationId equals organisation.Id
                                      where organisation.Resultatenhet.KstNr == kstNr
                                      select new { Id = person.Id, KostnadsstalleNr = kstNr, Personnummer = person.Personnummer, Fornamn = person.Fornamn, Efternamn = person.Efternamn, Resultatenhetansvarig = avtal.Ansvarig, Anstallningsdatum = avtal.Anstallningsdatum, Avgangsdatum = avtal.Avgangsdatum};


            var anstallda = projektionAnstallda.ToList();
            var konsulter = projektionKonsulter.ToList();
			
            anstallda.AddRange(konsulter);

			var groups = anstallda.GroupBy(a => new { a.Id, a.Personnummer, a.Fornamn, a.Efternamn });
			
			var personPerResultatenhet = groups.Select(group =>
			new PersonPerResultatenhetDTO {
				Id = group.Key.Id,
				Personnummer = group.Key.Personnummer,
				KostnadsstalleNr = kstNr,
				Fornamn = group.Key.Fornamn,
				Efternamn = group.Key.Efternamn,
				Resultatenhetansvarig = group.Any(item => item.Resultatenhetansvarig), // true om minst ett av avtalen har true!
				Anstallningsdatum = group.Min(item => item.Anstallningsdatum).FormatteraSomDatum(), // tidigaste anställningsdatumet används
				Avgangsdatum = group.Any(item => item.Avgangsdatum == null) ? null : group.Max(item => item.Avgangsdatum).FormatteraSomDatum() }); // Om något av avgångsdatumen är null, returnera då detta, annars det senaste!
			return personPerResultatenhet;
        }
    }
}
