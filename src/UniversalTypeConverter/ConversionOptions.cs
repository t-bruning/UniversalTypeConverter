// project  : UniversalTypeConverter
// file     : IConversionOptions.cs
// author   : Thorsten Bruning
// date     : 2019-02-21

using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the options of a conversion.
    /// </summary>
    public class ConversionOptions : IConversionOptions {

        private readonly ReadOnlyCollection<string> mDateTimePatterns;
        private readonly ReadOnlyCollection<string> mTimeOnlyPatterns;

        /// <summary>
        /// Gets the list of patterns used when converting a string to its DateTime equivalent.
        ///  E.g., these patterns are used as formats when calling DateTime.TryParseExact.
        /// </summary>
        public Collection<string> DateTimePatterns { get; }

        /// <summary>
        /// If true, <see cref="System.DBNull.Value"/> is handled the same way as null.
        ///  This option is true by default.
        /// </summary>
        public bool HandleDBNullAsNull { get; set; } = true;

        /// <summary>
        /// If true, conversion returns the destination's default value if the given value is null and the type of destination doesn't support null.
        ///  This option is false by default.
        /// </summary>
        public bool AllowDefaultValueIfNull { get; set; }

        /// <summary>
        /// Defines the NumberStyles used when converting a string to its integer (byte/int/long/sbyte/short/uint/ulong/ushort) equivalent.
        ///  The default is the combination of: NumberStyles.Integer | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowTrailingSign | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowExponent.
        /// </summary>
        public NumberStyles IntegerNumberStyle { get; set; } = NumberStyles.Integer | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowTrailingSign | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowExponent;

        /// <summary>
        /// Defines the format used when converting an integer to its equivalent string representation.
        ///  The default format is "G".
        /// </summary>
        public string IntegerFormat { get; set; } = "G";

        /// <summary>
        /// Defines the NumberStyles used when converting a string to its decimal equivalent.
        ///  The default is the combination of: NumberStyles.Number | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowExponent.
        /// </summary>
        public NumberStyles DecimalNumberStyle { get; set; } = NumberStyles.Number | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowExponent;

        /// <summary>
        /// Defines the format used when converting a decimal to its equivalent string representation.
        ///  The default format is "G".
        /// </summary>
        public string DecimalFormat { get; set; } = "G";

        /// <summary>
        /// Defines the NumberStyles used when converting a string to its float (float/double) equivalent.
        ///  The default is the combination of: NumberStyles.Float | NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowExponent.
        /// </summary>
        public NumberStyles FloatNumberStyle { get; set; } = NumberStyles.Float | NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowExponent;

        /// <summary>
        /// Defines the format used when converting a float to its equivalent string representation.
        ///  The default format is "G".
        /// </summary>
        public string FloatFormat { get; set; } = "G";

        /// <summary>
        /// Defines the DateTimeStyles used when converting a string to its DateTime equivalent.
        ///  The default is the combination of: DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite.
        /// </summary>
        public DateTimeStyles DateTimeStyle { get; set; } = DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite;

        /// <summary>
        /// Defines the format used when converting a date/time to its equivalent string representation.
        ///  The default format is "G".
        /// </summary>
        public string DateTimeFormat { get; set; } = "G";

        /// <summary>
        /// Defines the meaning of a Long value when converting to DateTime.
        ///  The default meaning is <see cref="ComponentModel.DateTimeLongMeaning.Ticks"/>.
        /// </summary>
        public DateTimeLongMeaning DateTimeLongMeaning { get; set; } = DateTimeLongMeaning.Ticks;

        /// <summary>
        /// Defines the format used when converting a guid to its equivalent string representation.
        ///  The default format is "D".
        /// </summary>
        public string GuidFormat { get; set; } = "D";

        /// <summary>
        /// Defines the format used when converting an array of bytes to its equivalent string representation and vice versa.
        ///  The default format is <see cref="ComponentModel.ByteArrayFormat.Base64"/>.
        /// </summary>
        public ByteArrayFormat ByteArrayFormat { get; set; } = ByteArrayFormat.Base64;

        /// <summary>
        /// Defines if and how conversion will try to use a public constructor with it's only parameter beeing of the type of the given source value.
        ///  The default mode is <see cref="ComponentModel.ConstructorResolvingMode.Strict"/>.
        /// </summary>
        public ConstructorResolvingMode ConstructorResolvingMode { get; set; } = ConstructorResolvingMode.Strict;

        /// <summary>
        /// Defines if and how conversion will try to use a public property which matches the given type and whos name is identically to a constructor parameter.
        ///  The default mode is <see cref="ComponentModel.PropertyResolvingMode.Strict"/>.
        /// </summary>
        public PropertyResolvingMode PropertyResolvingMode { get; set; } = PropertyResolvingMode.Strict;

        /// <summary>
        /// If true, conversion returns the destination's default value if the given value is an empty string and otherwise not convertible.
        ///  This option is false by default.
        /// </summary>
        public bool AllowDefaultValueIfWhitespace { get; set; }

        /// <summary>
        /// If true, conversion returns the destination's default value if the given value is not convertible to the given type.
        ///  This option is false by default.
        /// </summary>
        public bool AllowDefaultValueIfNotConvertible { get; set; }

#if NET6_0_OR_GREATER
        /// <summary>
        /// If true, conversion will try to convert the string representation of a ReadOnlySpan&lt;char&gt; if the span is not convertible by itself.
        ///  This option is false by default as performance is preferred in this case.
        /// </summary>
        public bool AllowRetryWithStringIfCharSpanNotConvertible { get; set; }
#endif

        ReadOnlyCollection<string> IConversionOptions.DateTimePatterns => mDateTimePatterns;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ConversionOptions() {
            DateTimePatterns = new Collection<string>();
            mDateTimePatterns = new ReadOnlyCollection<string>(DateTimePatterns);
            AddDefaultDateTimePatterns();

#if NET6_0_OR_GREATER
            TimeOnlyPatterns = new Collection<string>();
            mTimeOnlyPatterns = new ReadOnlyCollection<string>(TimeOnlyPatterns);
            AddFefaultTimeOnlyPatterns();
#endif
        }

        private void AddDefaultDateTimePatterns() {
            DateTimePatterns.Add("yyyyMMdd");
            DateTimePatterns.Add("yyyyMMddHHmm");
            DateTimePatterns.Add("yyyyMMddHHmmss");

            DateTimePatterns.Add("yyyyMMdd HH:mm");
            DateTimePatterns.Add("yyyyMMdd HH:mm:ss");
            DateTimePatterns.Add("yyyyMMdd HH:mm:ss.fff");

            DateTimePatterns.Add("yyyy-MM-dd");
            DateTimePatterns.Add("yyyy-MM-dd HH:mm");
            DateTimePatterns.Add("yyyy-MM-dd HH:mm:ss");
            DateTimePatterns.Add("yyyy-MM-dd HH:mm:ss.fff");
        }

#if NET6_0_OR_GREATER
        private void AddFefaultTimeOnlyPatterns() {
            TimeOnlyPatterns.Add("HH:mm");
            TimeOnlyPatterns.Add("HH:mm:ss");
            TimeOnlyPatterns.Add("HH:mm:ss.fff");

            TimeOnlyPatterns.Add(@"HH\h mm");
            TimeOnlyPatterns.Add(@"HH \h mm");
            TimeOnlyPatterns.Add(@"HH\hmm");
            TimeOnlyPatterns.Add(@"HH\hmm\m");
            TimeOnlyPatterns.Add(@"HH\hmm\mss");
            TimeOnlyPatterns.Add(@"HH\hmm\mss\s");
            TimeOnlyPatterns.Add(@"HH\hmm\mss.fff");
            TimeOnlyPatterns.Add(@"HH\hmm\mss.fff\s");

            TimeOnlyPatterns.Add("HH.mm");
        }
#endif

#if NET6_0_OR_GREATER
        /// <summary>
        /// Defines the format used when converting a DateOnly to its equivalent string representation.
        ///  The default format is "d".
        /// </summary>
        public string DateOnlyFormat { get; set; } = "d";

        /// <summary>
        /// Defines the default time used when converting a DateOnly to DateTime.
        ///  The default time is '00:00:00'.
        /// </summary>
        public TimeOnly DateOnlyDefaultTime { get; set; } = new TimeOnly(0, 0, 0);

        /// <summary>
        /// Gets the list of patterns used when converting a string to its TimeOnly equivalent.
        ///  E.g., these patterns are used as formats when calling TimeOnly.TryParseExact.
        /// </summary>
        public Collection<string> TimeOnlyPatterns { get; }

        ReadOnlyCollection<string> IConversionOptions.TimeOnlyPatterns => mTimeOnlyPatterns;

        /// <summary>
        /// Defines the format used when converting a TimeOnly to its equivalent string representation.
        ///  The default format is "t".
        /// </summary>
        public string TimeOnlyFormat { get; set; } = "t";
#endif

    }

}