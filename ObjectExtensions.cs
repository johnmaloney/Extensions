using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class Objects
    {
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
