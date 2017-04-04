using System.Collections.Generic;

namespace ODL.DomainModel.Adress
{
  
    public partial class AdressVariant
    {
        
        public int Id { get; set; }

        public string Namn { get; set; }

        public virtual ICollection<Adress> Adress { get; set; }

        // Detta är en tabell i databasen, för att vi ska få referensintegritet och "läsbarhet" i db
        public AdressTyp AdressTyp { get; set; } 
    }
}
