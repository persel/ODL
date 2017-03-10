using ODL.ApplicationServices.DTOModel.Behorighet;
namespace ODL.ApplicationServices
{
    public interface IBehorighetService
    {
        int SparaPersonal(PersonalDTO personalDTO);
        int SparaAnvandare(AnvandareDTO anvandareDTO);
        int SparaSystem(SystemDTO systemDTO);
        int SparaSystemattribut(SystemattributDTO systemattributDTO);
        int SparaVerksamhetsdimension(VerksamhetsdimensionDTO verksamhetsdimensionDTO);
        int SparaVerksamhetsroll(VerksamhetsrollDTO verksamhetsrollDTO);
    }
}