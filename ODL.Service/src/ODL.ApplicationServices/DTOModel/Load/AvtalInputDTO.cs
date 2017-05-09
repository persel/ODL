using System.Collections.Generic;

namespace ODL.ApplicationServices.DTOModel.Load
{

    public class AvtalInputDTO : InputDTO
    {
        public List<OrganisationAvtalInputDTO> Kostnadsstallen { get; set; }

        public string AnstalldPersonnummer { get; set; }

        public string KonsultPersonnummer { get; set; }

        public string Avtalskod { get; set; }

        public string Avtalstext { get; set; }

        public int? ArbetstidVecka { get; set; }

        public int? Befkod { get; set; }

        public string BefText { get; set; }

        public bool? Aktiv { get; set; }

        public bool Ansvarig { get; set; }

        public bool? Chef { get; set; }

        public string TjledigFran { get; set; }

        public string TjledigTom { get; set; }

        public decimal? Fproc { get; set; }

        public string DeltidFranvaro { get; set; }

        public decimal? FranvaroProcent { get; set; }

        public string SjukP { get; set; }

        public decimal? GrundArbtidVecka { get; set; }

        public int AvtalsTyp { get; set; }

        public int? Lon { get; set; }

        public string LonDatum { get; set; }

        public string LoneTyp { get; set; }

        public int? LoneTillagg { get; set; }

        public int? TimLon { get; set; }

        public string Anstallningsdatum { get; set; }

        public string Avgangsdatum { get; set; }
        public string Personnummer => AnstalldPersonnummer ?? KonsultPersonnummer;
    }

}