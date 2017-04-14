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
    }
}
