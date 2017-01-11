using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{
    [Table("Person.Avtal")]
    public partial class Avtal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Avtal()
        {
            OrganisationAvtal = new HashSet<OrganisationAvtal>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string KallsystemId { get; set; }

        [StringLength(50)]
        public string Avtalskod { get; set; }

        [StringLength(50)]
        public string Avtalstext { get; set; }

        public int? ArbetstidVecka { get; set; }

        public int? Befkod { get; set; }

        [StringLength(50)]
        public string BefText { get; set; }

        public bool? Aktiv { get; set; }

        public bool? Ansvarig { get; set; }

        public bool? Chef { get; set; }

        public DateTime? TjledigFran { get; set; }

        public DateTime? TjledigTom { get; set; }

        public decimal? Fproc { get; set; }

        [StringLength(10)]
        public string DeltidFranvaro { get; set; }

        public decimal? FranvaroProcent { get; set; }

        [StringLength(10)]
        public string SjukP { get; set; }

        public decimal? GrundArbtidVecka { get; set; }

        public byte? Avtalstyp { get; set; }

        public int? Lon { get; set; }

        public DateTime? LonDatum { get; set; }

        [StringLength(10)]
        public string LoneTyp { get; set; }

        public int? LoneTillagg { get; set; }

        public int? TimLon { get; set; }

        public DateTime? Anstallningsdatum { get; set; }

        public DateTime? Avgangsdatum { get; set; }
        public Metadata Metadata { get; set; }
        public bool IsNew => Id == default(int);

        public virtual AnstalldAvtal AnstalldAvtal { get; set; }

        public virtual KonsultAvtal KonsultAvtal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganisationAvtal> OrganisationAvtal { get; set; }
    }
}
