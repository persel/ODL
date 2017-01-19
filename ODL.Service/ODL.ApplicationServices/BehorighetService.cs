
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel.Behorighet;
using ODL.DataAccess.Repositories.Behorighet;
using ODL.DomainModel.Behorighet.Verksamhetsroll;

namespace ODL.ApplicationServices
{
    public class BehorighetService : IBehorighetService
    {
        private readonly IPersonalRepository personalRepository;
        private readonly IAnvandareRepository anvandareRepository;
        private readonly ISystemRepository systemRepository;
        private readonly IVerksamhetsrollRepository verksamhetsrollRepository;
        private readonly ISystemattributRepository systemattributRepository;
        private readonly IVerksamhetsdimensionRepository verksamhetsdimensionRepository;
        private readonly ILogger<BehorighetService> logger;

        public BehorighetService(
            IPersonalRepository personalRepository, 
            IAnvandareRepository anvandareRepository, 
            ISystemRepository systemRepository, 
            IVerksamhetsrollRepository verksamhetsrollRepository,
            ISystemattributRepository systemattributRepository,
            IVerksamhetsdimensionRepository verksamhetsdimensionRepository, 
            ILogger<BehorighetService> logger)
        {
            this.personalRepository = personalRepository;
            this.anvandareRepository = anvandareRepository;
            this.systemRepository = systemRepository;
            this.verksamhetsrollRepository = verksamhetsrollRepository;
            this.systemattributRepository = systemattributRepository;
            this.verksamhetsdimensionRepository = verksamhetsdimensionRepository;
            this.logger = logger;
    }
        public int SparaPersonal(PersonalDTO personalDTO)
        {
            var personal = personalRepository.GetPersonalByPersonnummer(personalDTO.Personnummer) ?? new Personal();
            if (personal.IsNew)
                personal.Personnummer = personalDTO.Personnummer;
            personal.Fornamn = personalDTO.Fornamn;
            personal.Efternamn = personalDTO.Efternamn;

            personalRepository.SparaPersonal(personal);

            return personal.Id;
        }

        public int SparaPersonalVerksamhetsroll(PersonalDTO personalDTO)
        {
            return 0;
        }

        public int SparaAnvandare(AnvandareDTO anvandareDTO)
        {
            return 0;
        }

        public int SparaSystem(SystemDTO systemDTO)
        {
            return 0;
        }

        public int SparaVerksamhetsroll(VerksamhetsrollDTO verksamhetsrollDTO)
        {
            return 0;
        }

        public int SparaVerksamhetsdimension(VerksamhetsdimensionDTO verksamhetsdimensionDTO)
        {
            return 0;
        }

        public int SparaSystemattribut(SystemattributDTO ystemattributDTO)
        {
            return 0;
        }

    }
}
