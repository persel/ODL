namespace ODL.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Organisation.Organisation")]
    public partial class Organisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organisation()
        {
            Underliggande = new HashSet<Organisation>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrganisationsId { get; set; }

        [StringLength(100)]
        public string Namn { get; set; }

        public int? OrganisationFKId { get; set; }

        public DateTime UppdateradDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Organisation> Underliggande { get; set; }

        public virtual Organisation Överordnad { get; set; }

        public virtual Resultatenhet Resultatenhet { get; set; }
    }
}
