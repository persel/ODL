using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{

    [Table("Person.Person")]
    public partial class Person
    {

        public Person()
        {
            AnstalldAvtal = new HashSet<AnstalldAvtal>();
            KonsultAvtal = new HashSet<KonsultAvtal>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public string KallsystemId { get; set; }

        public string Fornamn { get; set; }

        public string Mellannamn { get; set; }

        public string Efternamn { get; set; }

        public string Personnummer { get; set; }

        public Metadata Metadata { get; set; }


        // TODO: Person har listor av konsultavtal och anställningsavtal - Praktiskt men inte helt optimalt eftersom Avtal har samma referenser (genom 1:1-relationer) och 
        // man därigenom kan uppdatera samma tabeller via två olika aggregat (Person och Avtal), vilket kan ge concurrency issues etc. Vore bra om Person inte hade konsultavtal och anställningsavtal,
        // vilket dock ger mer logik i Servicen, utanför modellen.
        

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnstalldAvtal> AnstalldAvtal { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonsultAvtal> KonsultAvtal { get; set; }
        

        [NotMapped]
        public IEnumerable<int> AnstallningsAvtalIdn => AnstalldAvtal.Select(anstallningsAvtal => anstallningsAvtal.Avtal.Id);

        [NotMapped]
        public IEnumerable<int> KonsultAvtalIdn => KonsultAvtal.Select(konsultAvtal => konsultAvtal.Avtal.Id);

        [NotMapped]
        public bool IsNew => Id == 0;

        public bool IsAnstalld()
        {
            return AnstalldAvtal.Any();
        }

        public bool IsKonsult()
        {
            return KonsultAvtal.Any();
        }

        public IEnumerable<int> AllaAvtalIdn()
        {
            if (IsAnstalld() && IsKonsult())
                return AnstallningsAvtalIdn.Concat(KonsultAvtalIdn);
            return IsAnstalld()
                ? AnstallningsAvtalIdn
                : (IsKonsult() ? KonsultAvtalIdn : new List<int>()); // Tar hänsyn till om en person är varken konsult eller anställd...
        }

        /// <summary>
        /// Personen är kopplad till organisationen genom minst ett avtal 
        /// </summary>
        public bool KoppladTill(Organisation.Organisation organisation)
        {
            return AllaAvtalIdn().Intersect(organisation.AllaAvtalIdn).Any();
        }

    }
}
