using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Person
{

    public class AnstalldAvtal
    {      
        public int AvtalId { get; private set; }

        public int PersonId { get; internal set; }

        public virtual Avtal Avtal { get; private set; }

    }
}
