// project  : UniversalTypeConverter
// file     : IConversionOptions.cs
// author   : Thorsten Bruning
// date     : 2019-02-21     

using System.Collections.ObjectModel;
using System.Globalization;

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the options of a conversion.
    /// </summary>
    public interface IConversionOptions {

        /// <summary>
        /// If true, <see cref="System.DBNull.Value"/> is handled the same way as null.
        /// </summary>
        bool HandleDBNullAsNull { get; }

        /// <summary>
        /// If true, conversion returns the destination's default value if the given value is null and the type of destination doesn't support null.
        /// </summary>
        bool AllowDefaultValueIfNull { get; }

        /// <summary>
        /// Defines the NumberStyles used when converting a string to its integer (byte/int/long/sbyte/short/uint/ulong/ushort) equivalent.
        /// </summary>
        NumberStyles IntegerNumberStyle { get; }

        /// <summary>
        /// Defines the format used when converting an integer to its equivalent string representation.
        /// </summary>
        string IntegerFormat { get; }

        /// <summary>
        /// Defines the NumberStyle used when converting a string to its decimal equivalent.
        /// </summary>
        NumberStyles DecimalNumberStyle { get; }

        /// <summary>
        /// Defines the format used when converting a decimal to its equivalent string representation.
        /// </summary>
        string DecimalFormat { get; }

        /// <summary>
        /// Defines the NumberStyle used when converting a string to its float (float/double) equivalent.
        /// </summary>
        NumberStyles FloatNumberStyle { get; }

        /// <summary>
        /// Defines the format used when converting a float to its equivalent string representation.
        /// </summary>
        string FloatFormat { get; }

        /// <summary>
        /// Defines the DateTimeStyles used when converting a string to its DateTime equivalent.
        /// </summary>
        DateTimeStyles DateTimeStyle { get; }

        /// <summary>
        /// Gets the list of patterns used when converting a string to its DateTime equivalent.
        ///  E.g., these patterns are used as formats when calling DateTime.TryParseExact.
        /// </summary>
        ReadOnlyCollection<string> DateTimePatterns { get; }

        /// <summary>
        /// Defines the format used when converting a date/time to its equivalent string representation.
        /// </summary>
        string DateTimeFormat { get; }

        /// <summary>
        /// Defines the meaning of a Long value when converting to DateTime.
        /// </summary>
        DateTimeLongMeaning DateTimeLongMeaning { get; }

        /// <summary>
        /// Defines the format used when converting a guid to its equivalent string representation.
        /// </summary>
        string GuidFormat { get; }

        /// <summary>
        /// Defines the format used when converting an array of bytes to its equivalent string representation and vice versa.
        /// </summary>
        ByteArrayFormat ByteArrayFormat { get; }

        /// <summary>
        /// Defines if and how conversion will try to use a public constructor with it's only parameter beeing of the type of the given source value.
        /// </summary>
        ConstructorResolvingMode ConstructorResolvingMode { get; }

        /// <summary>
        /// Defines if and how conversion will try to use a public property which matches the given type and whos name is identically to a constructor parameter.
        /// </summary>
        PropertyResolvingMode PropertyResolvingMode { get; }

        /// <summary>
        /// If true, conversion returns the destination's default value if the given value is an empty string and otherwise not convertible.
        /// </summary>
        bool AllowDefaultValueIfWhitespace { get; }

        /// <summary>
        /// If true, conversion returns the destination's default value if the given value is not convertible to the given type.
        /// </summary>
        bool AllowDefaultValueIfNotConvertible { get; }
    }

}
