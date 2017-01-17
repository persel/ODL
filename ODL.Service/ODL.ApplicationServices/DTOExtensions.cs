using System;
using System.Globalization;

namespace ODL.ApplicationServices
{

    // Extension methods används för implementation av logik i domain model, så att ev. omskapande av modellen via "EF database first" inte 
    // skriver över egenskriven kod i modellklasserna. Kan flyttas till resp. klass när vi inte längre genererar från databasen.

    public static class DTOExtensions
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm"; // TODO: Flytta denna till konfigurationsfil eller centraliserad plats!
        private const string DateFormat = "yyyy-MM-dd";
        public static DateTime? ToDateTime(this string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return null;
            
            DateTime dateValue;
            if(DateTime.TryParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                return dateValue;

            return null;
        }

        public static DateTime? ToDate(this string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return null;

            DateTime dateValue;
            if (DateTime.TryParseExact(dateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                return dateValue;

            return null;
        }
    }
}
