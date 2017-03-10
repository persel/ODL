using System;
using System.Linq;
using System.Reflection;

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
    }
}
