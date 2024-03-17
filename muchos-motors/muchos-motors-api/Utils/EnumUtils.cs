using Microsoft.OpenApi.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace muchos_motors_api.Utils
{
    public class EnumUtils
    {
        //public static string GetDisplayNames(Enum value)
        //{
        //    var field = value.GetType().GetField(value.ToString());
        //    var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));

        //    return displayAttribute?.Name ?? value.ToString();
        //}

        //public static string GetDisplayName(this Enum value)
        //{
        //    var field = value.GetType().GetField(value.ToString());
        //    var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));

        //    return displayAttribute?.Name ?? value.ToString();
        //}

        public static TEnum GetEnumValue<TEnum>(string displayName)
        {
            var enumType = typeof(TEnum);

            foreach (var enumValue in Enum.GetValues(enumType))
            {
                if (((Enum)enumValue).GetDisplayName() == displayName)
                {
                    return (TEnum)enumValue;
                }
            }

            throw new ArgumentException($"No enum value with display name '{displayName}' found for {enumType.Name}.");
        }

    }
}
