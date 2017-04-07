
namespace ODL.DomainModel.Adress
{
    // TODO: Denna bör refaktoreras till en Value Object - vi ska inte skapa nya poster i db vid persistering av Adress. 
    // TODO: Helst också kontrollera instansieringen, jfr. AdressTyp, som dock är en enum och har "fast antal" värden.
    public class AdressVariant
    {
        protected AdressVariant(){}

        public AdressVariant(string namn, AdressTyp adressTyp)
        {
            Namn = namn;
            AdressTyp = adressTyp;
        }
        public int Id { get; private set; }

        public string Namn { get; private set; }
        
        // Denna utgör egen tabell i databasen, för att vi ska få referensintegritet och "läsbarhet" i db
        public AdressTyp AdressTyp { get; private set; } 
    }
}
