using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODL.DataAccess.Models.Extensions
{
    // Extension methods används för viss logik i EF-modellen, så ev. omskapande av modellen via "EF database first" inte 
    // skriver över egenskriven kod i modellklasserna

    public static class PersonExtensions
    {
        public static bool IsAnställd(this Person person)
        {
            return person.Anställd != null;
        }

        public static bool IsKonsult(this Person person)
        {
            return person.Konsult != null;
        }
    }
}
