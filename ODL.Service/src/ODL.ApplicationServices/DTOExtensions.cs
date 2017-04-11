using System;
using System.Globalization;

namespace ODL.ApplicationServices
{

    public static class DTOExtensions
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm"; // TODO: Flytta denna till konfigurationsfil eller centraliserad plats!
        private const string DateFormat = "yyyy-MM-dd";
        public static DateTime? TillDatumOchTid(this string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return null;
            
            DateTime dateValue;
            if(DateTime.TryParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                return dateValue;

            return null;
        }

        public static DateTime? TillDatum(this string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return null;

            DateTime dateValue;
            if (DateTime.TryParseExact(dateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                return dateValue;

            return null;
        }

        public static string FormatteraSomDatum(this DateTime datum)
        {
            return datum.ToString(DateFormat, CultureInfo.InvariantCulture);
        }

        public static string FormatteraSomDatum(this DateTime? datum)
        {
            return datum?.ToString(DateFormat, CultureInfo.InvariantCulture);
        }
    }
}
