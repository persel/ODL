using ODL.ApplicationServices.DTOModel.Behorighet;
namespace ODL.ApplicationServices
{
    public interface IBehorighetService
    {
        int SparaPersonal(PersonalDTO personal);
        int SparaAnvandare(AnvandareDTO anvandare);
        int SparaSystem(SystemDTO system);
        int SparaSystemattribut(SystemattributDTO ystemattribut);
        int SparaVerksamhetsdimension(VerksamhetsdimensionDTO verksamhetsdimension);
        int SparaVerksamhetsroll(VerksamhetsrollDTO verksamhetsroll);
    }
}