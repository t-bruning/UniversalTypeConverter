// project  : UniversalTypeConverter
// file     : TypeConverter.cs
// author   : Thorsten Bruning
// date     : 2018-09-12 

using System;
using System.Collections;
using System.Globalization;
using TB.ComponentModel.Conversions;
using TB.ComponentModel.Reflection;

namespace TB.ComponentModel {

    /// <summary>
    /// Defines a type converter.
    /// </summary>
    public partial class TypeConverter : ITypeConverter {

        private CultureInfo mDefaultCulture;

        /// <summary>
        /// Gets the collection of return values for conversions that convert from null.
        /// </summary>
        public TypeValueDictionary NullValues { get; } = new TypeValueDictionary();

        /// <summary>
        /// Gets the list of mappings of specific source values to specific return values.
        ///  The list is implemented as 'Last In – First Out' (LIFO).
        /// </summary>
        public ValueMappingCollection ValueMappings { get; } = new ValueMappingCollection();

        /// <summary>
        /// Gets the list of conversions used by this converter.
        /// </summary>
        public ConversionCollection Conversions { get; } = new ConversionCollection();

        /// <summary>
        /// Gets the conversion options.
        /// </summary>
        public ConversionOptions Options { get; } = new ConversionOptions();

        /// <summary>
        /// Defines the culture which should be used for conversion by default.
        ///  Returns <see cref="CultureInfo.CurrentCulture"/> if not set or null.
        /// </summary>
        public CultureInfo DefaultCulture {
            get => mDefaultCulture ?? CultureInfo.CurrentCulture;
            set => mDefaultCulture = value;
        }

        /// <summary>
        /// Gets the converion options.
        /// </summary>
        IConversionOptions ITypeConverter.Options => Options;

        /// <summary>
        /// Initializes a new instance with the given default culture.
        /// </summary>
        /// <param name="defaultCulture"></param>
        public TypeConverter(CultureInfo defaultCulture)
            : this() {
            DefaultCulture = defaultCulture;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TypeConverter() {
            AddDefaultValueMappings();
            AddDefaultConversions();
        }

        /// <summary>
        /// Determines whether the given value can be converted to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to test.</typeparam>
        /// <param name="value">The value to test.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> can be converted to <typeparamref name="T"/>; otherwise, false.</returns>
        public bool CanConvertTo<T>(object value, CultureInfo culture = null) {
            return TryConvertTo(value, out T _, culture);
        }

#if NET6_0_OR_GREATER
        /// <summary>
        /// Determines whether the given <see cref="ReadOnlySpan{T}" /> can be converted to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to test.</typeparam>
        /// <param name="value">The value to test.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> can be converted to <typeparamref name="T"/>; otherwise, false.</returns>
        public bool CanConvertTo<T>(ReadOnlySpan<char> value, CultureInfo culture = null) {
            return TryConvertTo(value, out T _, culture);
        }
#endif

        /// <summary>
        /// Determines whether the given value can be converted to the specified type.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="destinationType">The type to test.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> can be converted to <paramref name="destinationType"/>; otherwise, false.</returns>
        public bool CanConvert(object value, Type destinationType, CultureInfo culture = null) {
            return TryConvert(value, destinationType, out _, culture);
        }

#if NET6_0_OR_GREATER
        /// <summary>
        /// Determines whether the given <see cref="ReadOnlySpan{T}" /> can be converted to the specified type.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="destinationType">The type to test.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> can be converted to <paramref name="destinationType"/>; otherwise, false.</returns>
        public bool CanConvert(ReadOnlySpan<char> value, Type destinationType, CultureInfo culture = null) {
            return TryConvert(value, destinationType, out _, culture);
        }
#endif

        /// <summary>
        /// Converts the given value to the given type.
        /// </summary>
        /// <typeparam name="T">The type to which the given value is converted.</typeparam>
        /// <param name="value">The value which is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>An instance of type <typeparamref name="T">T</typeparamref> whose value is equivalent to the given <paramref name="value">value</paramref>.</returns>
        /// <exception cref="InvalidConversionException">InvalidConversionException if the value is not convertible to the given type.</exception>
        public T ConvertTo<T>(object value, CultureInfo culture = null) {
            return (T)Convert(value, typeof(T), culture);
        }

        /// <summary>
        /// Converts the given value to the given type.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref>.</returns>
        /// <exception cref="InvalidConversionException">InvalidConversionException if the value is not convertible to the given type.</exception>
        public object Convert(object value, Type destinationType, CultureInfo culture = null) {
            if (TryConvert(value, destinationType, out var result, culture)) {
                return result;
            }

            throw new InvalidConversionException(value, destinationType);
        }

        /// <summary>
        /// Returns an iterator over the results of converting the given values to the given type.
        ///  The conversion is configurable further more before iteration.
        /// </summary>
        /// <typeparam name="T">The type to which the given values are converted.</typeparam>
        /// <param name="values">The list of values which are converted.</param>
        /// /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>List of converted values.</returns>
        public EnumerableConversion<T> ConvertToEnumerable<T>(IEnumerable values, CultureInfo culture = null) {
            return new EnumerableConversion<T>(values, this, culture ?? DefaultCulture);
        }

        /// <summary>
        /// Returns an iterator over the results of converting the given values to the given type.
        ///  The conversion is configurable further more before iteration.
        /// </summary>
        /// <param name="values">The list of values which are converted.</param>
        /// <param name="destinationType">The type to which the given values are converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>List of converted values.</returns>
        public EnumerableConversion<object> ConvertToEnumerable(IEnumerable values, Type destinationType, CultureInfo culture = null) {
            return new EnumerableConversion<object>(values, destinationType, this, culture ?? DefaultCulture);
        }

        /// <summary>
        /// Converts the given value to the given type.
        ///  A return value indicates whether the operation succeeded.
        /// </summary>
        /// <typeparam name="T">The type to which the given value is converted.</typeparam>
        /// <param name="value">The value which is converted.</param>
        /// <param name="result">An instance of type <typeparamref name="T">T</typeparamref> whose value is equivalent to the given <paramref name="value">value</paramref> if the operation succeeded.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> was converted successfully; otherwise, false.</returns>
        public bool TryConvertTo<T>(object value, out T result, CultureInfo culture = null) {
            if (TryConvert(value, typeof(T), out var tmpResult, culture)) {
                result = (T)tmpResult;
                return true;
            }

            result = default;
            return false;
        }

#if NET6_0_OR_GREATER
        /// <summary>
        /// Converts the given <see cref="ReadOnlySpan{T}" /> to the given type.
        ///  A return value indicates whether the operation succeeded.
        /// </summary>
        /// <typeparam name="T">The type to which the given value is converted.</typeparam>
        /// <param name="value">The value which is converted.</param>
        /// <param name="result">An instance of type <typeparamref name="T">T</typeparamref> whose value is equivalent to the given <paramref name="value">value</paramref> if the operation succeeded.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> was converted successfully; otherwise, false.</returns>
        public bool TryConvertTo<T>(ReadOnlySpan<char> value, out T result, CultureInfo culture = null) {
            if (TryConvert(value, typeof(T), out var tmpResult, culture)) {
                result = (T)tmpResult;
                return true;
            }

            result = default;
            return false;
        }
#endif

        /// <summary>
        /// Converts the given value to the given type.
        ///  A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <param name="result">An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref> if the operation succeeded.</param>
        /// <returns>true, if <paramref name="value"/> was converted successfully; otherwise, false.</returns>
        public bool TryConvert(object value, Type destinationType, out object result, CultureInfo culture = null) {
            var args = new ConversionArgs(this, culture ?? DefaultCulture);
            return TryConvertObject(value, destinationType, out result, args);
        }

        private bool TryConvertObject(object value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == null) {
                result = null;
                return false;
            }

            // null is handled before anything else:
            if (ValueRepresentsNull(value)) {
                return TryConvertNull(destinationType, out result);
            }

            // a specified value has priority:
            if (ValueMappings.TryMap(value, destinationType, out result)) {
                return true;
            }

            // try conversions by their defined priority:
            foreach (var conversion in Conversions) {
                if (conversion.TryConvert(value, destinationType, out result, args)) {
                    return true;
                }

                if (args.Break) {
                    break;
                }
            }

            // if nullable -> try again with the underlying type:
            if (destinationType.IsGenericNullable()) {
                var coreDestinationType = destinationType.GetUnderlyingType();
                return TryConvertObject(value, coreDestinationType, out result, args);
            }

            // check fallback options:
            if (Options.AllowDefaultValueIfWhitespace && value is string s && string.IsNullOrWhiteSpace(s)) {
                result = destinationType.DefaultValue();
                return true;
            }

            if (Options.AllowDefaultValueIfNotConvertible) {
                result = destinationType.DefaultValue();
                return true;
            }

            result = null;
            return false;
        }

#if NET6_0_OR_GREATER
        private bool TryConvertReadOnlySpanOfChar(ReadOnlySpan<char> value, Type destinationType, out object result, ConversionArgs args) {
            // for now, ReadOnlySpan<char> has special treatment without configuration options:
            if (ReadOnlySpanOfCharConversion.TryConvert(value, destinationType, out result, args)) {
                return true;
            }

            // check fallback options:
            if (Options.AllowDefaultValueIfWhitespace && value.IsWhiteSpace()) {
                result = destinationType.DefaultValue();
                return true;
            }

            if (Options.AllowRetryWithStringIfCharSpanNotConvertible) {
                if (TryConvertObject(value.ToString(), destinationType, out var fromStringResult, args)) {
                    result = fromStringResult;
                    return true;
                }
            }

            if (Options.AllowDefaultValueIfNotConvertible) {
                result = destinationType.DefaultValue();
                return true;
            }

            result = null;
            return false;
        }
#endif

        private bool ValueRepresentsNull(object value) {
            if (value == null) {
                return true;
            }

            if (value == DBNull.Value) {
                return Options.HandleDBNullAsNull;
            }

            return false;
        }

        private bool TryConvertNull(Type destinationType, out object result) {
            if (NullValues.TryGet(destinationType, out result)) {
                return true;
            }

            result = destinationType.DefaultValue();
            if (result == null) {
                return true;
            }

            return Options.AllowDefaultValueIfNull;
        }

        bool ITypeConversion.TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            return TryConvertObject(value, destinationType, out result, args);
        }

        private void AddDefaultValueMappings() {
            ValueMappings.Add('1', true);
            ValueMappings.Add('t', true);
            ValueMappings.Add('T', true);
            ValueMappings.Add('y', true);
            ValueMappings.Add('Y', true);
            ValueMappings.Add('j', true);
            ValueMappings.Add('J', true);

            ValueMappings.Add('0', false);
            ValueMappings.Add('n', false);
            ValueMappings.Add('N', false);
            ValueMappings.Add('f', false);
            ValueMappings.Add('F', false);

            ValueMappings.Add("1", true);
            ValueMappings.Add("t", true, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("true", true, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add(".t.", true, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("y", true, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("yes", true, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("j", true, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("ja", true, StringComparer.OrdinalIgnoreCase);

            ValueMappings.Add("0", false);
            ValueMappings.Add("-1", false);
            ValueMappings.Add("f", false, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("false", false, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add(".f.", false, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("n", false, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("no", false, StringComparer.OrdinalIgnoreCase);
            ValueMappings.Add("nein", false, StringComparer.OrdinalIgnoreCase);

            ValueMappings.Add(true, 'T');
            ValueMappings.Add(false, 'F');
        }

        private void AddDefaultConversions() {
            Conversions.Add(new AssignableConversion(), ConversionPriority.Low);

            Conversions.Add(new StringConversion(), ConversionPriority.Low);
            Conversions.Add(new IntConversion(), ConversionPriority.Low);
            Conversions.Add(new DecimalConversion(), ConversionPriority.Low);
            Conversions.Add(new LongConversion(), ConversionPriority.Low);
            Conversions.Add(new DateTimeConversion(), ConversionPriority.Low);

#if NET6_0_OR_GREATER
            Conversions.Add(new DateOnlyConversion(), ConversionPriority.Low);
            Conversions.Add(new TimeOnlyConversion(), ConversionPriority.Low);
#endif

            Conversions.Add(new GuidConversion(), ConversionPriority.Low);
            Conversions.Add(new DoubleConversion(), ConversionPriority.Low);
            Conversions.Add(new ByteConversion(), ConversionPriority.Low);
            Conversions.Add(new CharConversion(), ConversionPriority.Low);
            Conversions.Add(new ShortConversion(), ConversionPriority.Low);
            Conversions.Add(new FloatConversion(), ConversionPriority.Low);
            Conversions.Add(new UIntConversion(), ConversionPriority.Low);
            Conversions.Add(new ULongConversion(), ConversionPriority.Low);
            Conversions.Add(new UShortConversion(), ConversionPriority.Low);
            Conversions.Add(new SByteConversion(), ConversionPriority.Low);
            Conversions.Add(new ByteArrayConversion(), ConversionPriority.Low);
            Conversions.Add(new EnumConversion(), ConversionPriority.Low);

            Conversions.Add(new DataRowConversion(this), ConversionPriority.Low);
            Conversions.Add(new DataRowViewConversion(this), ConversionPriority.Low);
            Conversions.Add(new DataRecordConversion(this), ConversionPriority.Low);

            Conversions.Add(new ConvertibleConversion(), ConversionPriority.Low);
            Conversions.Add(new FormattableConversion(), ConversionPriority.Low);
            Conversions.Add(new TypeConverterConversion(), ConversionPriority.Low);
            Conversions.Add(new XPlicitConversion(), ConversionPriority.Low);

            Conversions.Add(new TryParseConversion(), ConversionPriority.Low);
            Conversions.Add(new ConstructorBasedConversion(), ConversionPriority.Low);
            Conversions.Add(new PropertyBasedConversion(), ConversionPriority.Low);
        }

#if NET6_0_OR_GREATER
        /// <summary>
        /// Converts the given <see cref="ReadOnlySpan{T}" /> to the given type.
        /// </summary>
        /// <typeparam name="T">The type to which the given value is converted.</typeparam>
        /// <param name="value">The value which is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>An instance of type <typeparamref name="T">T</typeparamref> whose value is equivalent to the given <paramref name="value">value</paramref>.</returns>
        /// <exception cref="InvalidConversionException">InvalidConversionException if the value is not convertible to the given type.</exception>
        public T ConvertTo<T>(ReadOnlySpan<char> value, CultureInfo culture = null) {
            return (T)Convert(value, typeof(T), culture);
        }

        /// <summary>
        /// Converts the given string to the given type.
        /// </summary>
        /// <typeparam name="T">The type to which the given value is converted.</typeparam>
        /// <param name="value">The value which is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>An instance of type <typeparamref name="T">T</typeparamref> whose value is equivalent to the given <paramref name="value">value</paramref>.</returns>
        /// <exception cref="InvalidConversionException">InvalidConversionException if the value is not convertible to the given type.</exception>
        public T ConvertTo<T>(string value, CultureInfo culture = null) {
            // Overload with string needed because of compiler error CS0121:
            // The call is ambiguous between the following methods or properties: 'TypeConverter.ConvertTo<T>(object, CultureInfo)' and 'TypeConverter.ConvertTo<T>(ReadOnlySpan<char>, CultureInfo)'
            return (T)Convert(value, typeof(T), culture);
        }
#endif

#if NET6_0_OR_GREATER
        /// <summary>
        /// Converts the given <see cref="ReadOnlySpan{T}" /> to the given type.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref>.</returns>
        /// <exception cref="InvalidConversionException">InvalidConversionException if the value is not convertible to the given type.</exception>
        public object Convert(ReadOnlySpan<char> value, Type destinationType, CultureInfo culture = null) {
            if (TryConvert(value, destinationType, out var result, culture)) {
                return result;
            }

            throw new InvalidConversionException(value, destinationType);
        }

        /// <summary>
        /// Converts the given string to the given type.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref>.</returns>
        /// <exception cref="InvalidConversionException">InvalidConversionException if the value is not convertible to the given type.</exception>
        public object Convert(string value, Type destinationType, CultureInfo culture = null) {
            // Overload with string needed because of compiler error CS0121:
            // The call is ambiguous between the following methods or properties: 'TypeConverter.Convert(object, Type, CultureInfo)' and 'TypeConverter.Convert(ReadOnlySpan<char>, Type, CultureInfo)'
            if (TryConvert(value, destinationType, out var result, culture)) {
                return result;
            }

            throw new InvalidConversionException(value, destinationType);
        }
#endif

#if NET6_0_OR_GREATER
        /// <summary>
        /// Converts the given <see cref="ReadOnlySpan{T}" /> to the given type.
        ///  A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <param name="result">An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref> if the operation succeeded.</param>
        /// <returns>true, if <paramref name="value"/> was converted successfully; otherwise, false.</returns>
        public bool TryConvert(ReadOnlySpan<char> value, Type destinationType, out object result, CultureInfo culture = null) {
            if (destinationType == null) {
                result = null;
                return false;
            }

            var args = new ConversionArgs(this, culture ?? DefaultCulture);
            return TryConvertReadOnlySpanOfChar(value, destinationType, out result, args);
        }

        /// <summary>
        /// Converts the given string to the given type.
        ///  A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <param name="result">An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref> if the operation succeeded.</param>
        /// <returns>true, if <paramref name="value"/> was converted successfully; otherwise, false.</returns>
        public bool TryConvert(string value, Type destinationType, out object result, CultureInfo culture = null) {
            // Overload with string needed because of compiler error CS0121:
            // The call is ambiguous between the following methods or properties: 'TypeConverter.TryConvert(object, Type, out object, CultureInfo)' and 'TypeConverter.TryConvert(ReadOnlySpan<char>, Type, out object, CultureInfo)'
            var args = new ConversionArgs(this, culture ?? DefaultCulture);
            return TryConvertObject(value, destinationType, out result, args);
        }
#endif

    }

}