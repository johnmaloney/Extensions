using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class Strings
    {
        /// <summary>
        /// Are the two strings equal irregardless of case and localization.
        /// </summary>
        /// <param name="leftItem"></param>
        /// <param name="rightItem"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this string comparor, string comparee, StringComparison comparisonOptions = StringComparison.InvariantCultureIgnoreCase)
        {
            return string.Equals(comparor, comparee, comparisonOptions);
        }

        /// <summary>
        /// Simpler way to create a formatted string
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formattables"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params string[] formattables)
        {
            return string.Format(format, formattables);
        }
                
        /// <summary>
        /// Attempts to convert the string representation of the Enum to a Enum Type.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumString"></param>
        /// <returns></returns>
        public static TEnum AsEnumOf<TEnum>(this string enumString)
        {
            Type t = typeof(TEnum);
            return (TEnum)Enum.Parse(t, enumString, true);
        }
        
        /// <summary>
        /// Used to cast a string or object to a known type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueToConvert"></param>
        /// <returns></returns>
        public static T As<T>(this object valueToConvert)
        {
            Type conversionType = typeof(T);

            if (valueToConvert == null |
                string.IsNullOrEmpty(valueToConvert.ToString()))
                return default(T);

            if (conversionType.IsValueType && Nullable.GetUnderlyingType(conversionType) == null)
            {
                return (T)Convert.ChangeType(valueToConvert, conversionType);
            }
            else
            {
                return (T)valueToConvert;
            }
        }
    }
}
