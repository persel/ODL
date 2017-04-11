using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess;
using ODL.DomainModel;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices.Queries
{
    internal class ResultatenhetsansvarigaPostombudQuery
    {
        public IContext DbContext { get; set; }

        public ResultatenhetsansvarigaPostombudQuery(IContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<PostombudDTO> Execute()
        {
            var allaAvtal = DbContext.DbSet<Avtal>();
            var allaAnstalldAvtal = DbContext.DbSet<AnstalldAvtal>(); // Denna kan utelämnas och joinas mha navigation property, men det komplicerar det genrerade SQL-scriptet
            var personer = DbContext.DbSet<Person>();
            var organisationer = DbContext.DbSet<Organisation>();
            var adresser = DbContext.DbSet<Adress>();
            var allaOrganisationsAvtal = DbContext.DbSet<OrganisationAvtal>(); 
            var allaOrganisationsAdresser = DbContext.DbSet<OrganisationAdress>();// Denna kan utelämnas och joinas mha navigation property, men det komplicerar det genrerade SQL-scriptet

            var datumOmFemAr = DateTime.Now.AddYears(5).FormatteraSomDatum();

            var projektion = from person in personer
                             join anstalldAvtal in allaAnstalldAvtal on person.Id equals anstalldAvtal.PersonId
                             join avtal in allaAvtal on anstalldAvtal.AvtalId equals avtal.Id
                             join organisationsAvtal in allaOrganisationsAvtal on avtal.Id equals organisationsAvtal.AvtalId
                             join organisation in organisationer on organisationsAvtal.OrganisationId equals organisation.Id
                             join organisationsAdress in allaOrganisationsAdresser on organisation.Id equals organisationsAdress.OrganisationId
                             join adress in adresser on organisationsAdress.AdressId equals adress.Id
                             
                             where avtal.Ansvarig == true &&
                             adress.AdressVariant.Namn == "Leveransadress" // TODO: Peka ut på annat sätt!
                             select new {Fornamn = person.Fornamn, Efternamn = person.Efternamn, Personnummer = person.Personnummer, Arbetsstalle = organisation.Namn, Leveransadress = adress.Gatuadress, FranDatum = avtal.Anstallningsdatum, TillDatum = avtal.Avgangsdatum};

            // Här hade vi gärna skapat PostombudDTO:er direkt i frågan ovan, men null propagating operator (?.) får inte användas i en expression tree lambda, därav användning av anonymous type som mellansteg.

            var verksamhetsansvariga = 
                projektion.ToList().Select(rad => 
                new PostombudDTO{
                    Fornamn = rad.Fornamn,
                    Efternamn = rad.Efternamn,
                    Personnummer = rad.Personnummer,
                    Arbetsstalle = rad.Arbetsstalle,
                    GataBox = rad.Leveransadress?.AdressRad1 ?? "Praktikertjänst", // Konfigurera?
                    Postnummer = rad.Leveransadress?.Postnummer,
                    Postort = rad.Leveransadress?.Stad,
                    FranDatum = rad.FranDatum.FormatteraSomDatum(),
                    TillDatum = rad.TillDatum.FormatteraSomDatum() ?? datumOmFemAr});

            return verksamhetsansvariga.Distinct().ToList(); // Ta bort dubletter

        }
    }
}
