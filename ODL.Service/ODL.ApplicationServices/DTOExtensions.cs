using System;
using System.Globalization;

namespace ODL.ApplicationServices
{

    // Extension methods används för implementation av logik i domain model, så att ev. omskapande av modellen via "EF database first" inte 
    // skriver över egenskriven kod i modellklasserna. Kan flyttas till resp. klass när vi inte längre genererar från databasen.

    public static class DTOExtensions
    {
        public const string DateFormat = "yyyy-MM-dd"; // TODO: Flytta denna till konfigurationsfil eller centraliserad plats!

        public static DateTime? ToDateTime(this string dateString)
        {
            if (dateString == null)
                return null;
            
            DateTime dateValue;
            if(DateTime.TryParseExact(dateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                return dateValue;

            return null;
        }
    }
}
