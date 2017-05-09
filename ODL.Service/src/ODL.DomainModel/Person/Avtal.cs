using System;
using System.Collections.Generic;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{
    public class Avtal
    {
        
        public Avtal()
        {
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

        public bool IsNew => Id == default(int);

        public virtual AnstalldAvtal AnstalldAvtal { get; set; }

        public virtual KonsultAvtal KonsultAvtal { get; set; }

        public virtual ICollection<OrganisationAvtal> OrganisationAvtal { get; set; }

        public void AddOrganisationAvtal(OrganisationAvtal orgAvtal)
        {
            OrganisationAvtal.Add(orgAvtal);
        }
    }
}
