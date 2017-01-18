
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel.Behorighet;
using ODL.DataAccess.Repositories.Behorighet;

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
        public int SparaPersonal(PersonalDTO personal)
        {
            return 0;
        }

        public int SparaPersonalVerksamhetsroll(PersonalDTO personal)
        {
            return 0;
        }

        public int SparaAnvandare(AnvandareDTO anvandare)
        {
            return 0;
        }

        public int SparaSystem(SystemDTO system)
        {
            return 0;
        }

        public int SparaVerksamhetsroll(VerksamhetsrollDTO verksamhetsroll)
        {
            return 0;
        }

        public int SparaVerksamhetsdimension(VerksamhetsdimensionDTO verksamhetsdimension)
        {
            return 0;
        }

        public int SparaSystemattribut(SystemattributDTO ystemattribut)
        {
            return 0;
        }

    }
}
