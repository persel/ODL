using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODL.ApplicationServices.DTOModel.Load
{

    public class AvtalInputDTO : InputDTO
    {
        public string[] OrganisationId { get; set; }

        public string AnstalldPersonId { get; set; }

        public string KonsultPersonId { get; set; }

        public string Avtalskod { get; set; }

        public string Avtalstext { get; set; }

        public int? ArbetstidVecka { get; set; }

        public int? Befkod { get; set; }

        public string BefText { get; set; }

        public bool? Aktiv { get; set; }

        public bool? Ansvarig { get; set; }

        public bool? Chef { get; set; }

        public string TjledigFran { get; set; }

        public string TjledigTom { get; set; }

        public double? Fproc { get; set; }

        public string DeltidFranvaro { get; set; }

        public double? FranvaroProcent { get; set; }

        public string SjukP { get; set; }

        public double? GrundArbtidVecka { get; set; }

        public int AvtalsTyp { get; set; }

        public int? Lon { get; set; }

        public string LonDatum { get; set; }

        public string LoneTyp { get; set; }

        public int? LoneTillagg { get; set; }

        public int? TimLon { get; set; }

        public string Anstallningsdatum { get; set; }

        public string Avgangsdatum { get; set; }
        
    }
}