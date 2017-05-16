using System;
using System.Linq;
using System.Reflection;
using ODL.DomainModel.Adress;

namespace ODL.DomainModel.Common
{
    public static class EnumExtensions
    {
        public static string Visningstext(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<VisningstextAttribute>()
                            ?.Text;
        }

        /// <summary>
        /// Denna metod kastar exception om strängen inte kan matchas mot angiven Enum.
        /// </summary>
        public static T TillEnum<T>(this string enumString) where T:struct
        {
            return (T)Enum.Parse(typeof(T), enumString); 
        }

    }
}
