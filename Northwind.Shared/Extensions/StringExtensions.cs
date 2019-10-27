using System;

namespace Northwind.Shared
{
    public static class StringExtensions
    {
        /// <summary>
        /// Throws ArgumentOutOfRangeException if parameter is null or whitespace.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="parameterName">Parameter name used for exception message.</param>
        public static void ThrowIfParameterIsNullOrWhiteSpace(this string parameter, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new ArgumentOutOfRangeException(parameterName, "Cannot be null or whitespace.");
            }
        }
    }
}
