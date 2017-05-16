using System;
using System.Collections.Generic;
using System.Linq;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{
    public class Avtal
    {
        public Avtal()
        {
            OrganisationAvtal = new HashSet<OrganisationAvtal>();
        }
        
       public Avtal(string kallsystemId, string avtalskod, string avtalstext, int? arbetstidVecka, int? befkod, string befText, bool? aktiv, bool ansvarig, bool? chef, decimal? grundArbtidVecka, int? lon, int? timLon, DateTime? anstallningsdatum, Metadata metadata)
        {
            KallsystemId = kallsystemId;
            Avtalskod = avtalskod;
            Avtalstext = avtalstext;
            ArbetstidVecka = arbetstidVecka;
            Befkod = befkod;
            BefText = befText;
            Aktiv = aktiv;
            Ansvarig = ansvarig;
            Chef = chef;
            GrundArbtidVecka = grundArbtidVecka;
            Lon = lon;
            TimLon = timLon;
            Anstallningsdatum = anstallningsdatum;
            Metadata = metadata;

            OrganisationAvtal = new HashSet<OrganisationAvtal>();
        }

        public int Id { get; set; }
        public string KallsystemId { get; set; }
        public string Avtalskod { get; set; }
        public string Avtalstext { get; set; }
        public int? ArbetstidVecka { get; set; }
        public int? Befkod { get; set; }
        public string BefText { get; set; }
        public bool? Aktiv { get; set; }
        public bool Ansvarig { get; set; }
        public bool? Chef { get; set; }
        public DateTime? TjledigFran { get; set; }
        public DateTime? TjledigTom { get; set; }
        public decimal? Fproc { get; set; }
        public string DeltidFranvaro { get; set; }
        public decimal? FranvaroProcent { get; set; }
        public string SjukP { get; set; }
        public decimal? GrundArbtidVecka { get; set; }
        public byte? Avtalstyp { get; set; }
        public int? Lon { get; set; }
        public DateTime? LonDatum { get; set; }
        public string LoneTyp { get; set; }
        public int? LoneTillagg { get; set; }
        public int? TimLon { get; set; }
        public DateTime? Anstallningsdatum { get; set; }
        public DateTime? Avgangsdatum { get; set; }
        public Metadata Metadata { get; set; }

        public bool Ny => Id == default(int);

        public virtual AnstalldAvtal AnstalldAvtal { get; private set; }
        public virtual KonsultAvtal KonsultAvtal { get; private set; }
        internal virtual ICollection<OrganisationAvtal> OrganisationAvtal { get; }

        public void KopplaTillKonsult(Person konsult)
        {
            if (AnstalldAvtal != null || KonsultAvtal != null)
                throw new BusinessLogicException(
                    $"Avtalet är redan kopplat till en person (Id: {AnstalldAvtal.PersonId})");

            KonsultAvtal = new KonsultAvtal{PersonId = konsult.Id};
        }

        public void KopplaTillAnstalld(Person anstalld)
        {

            if (AnstalldAvtal != null || KonsultAvtal != null)
                throw new BusinessLogicException(
                    $"Avtalet är redan kopplat till en person (Id: {AnstalldAvtal.PersonId})");

            AnstalldAvtal = new AnstalldAvtal { PersonId = anstalld.Id };
        }

        public void LaggTillOrganisation(Organisation.Organisation organisation, bool huvudkostnadsstalle = true, decimal? procentuellFordelning = 100m)
        {
            var orgAvtal = OrganisationAvtal.SingleOrDefault(orgAvt => orgAvt.OrganisationId == organisation.Id) ?? new OrganisationAvtal();

            orgAvtal.Huvudkostnadsstalle = huvudkostnadsstalle;
            orgAvtal.ProcentuellFordelning = procentuellFordelning;

            var redanHuvud = OrganisationAvtal.Any(org => org.Huvudkostnadsstalle);
           

            var organisationsAvtal = new OrganisationAvtal
            {
                OrganisationId = organisation.Id,
                Huvudkostnadsstalle = huvudkostnadsstalle,
                ProcentuellFordelning = procentuellFordelning
            };

            OrganisationAvtal.Add(organisationsAvtal);
        }
    }
}
