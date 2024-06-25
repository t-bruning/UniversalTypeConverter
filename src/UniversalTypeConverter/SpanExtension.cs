// project  : UniversalTypeConverter
// file     : SpanExtension.cs
// author   : Thorsten Bruning
// date     : 2024-06-25 

#if NET6_0_OR_GREATER
using System;
using System.Globalization;

namespace TB.ComponentModel {

    /// <summary>
    /// Provides extension methods for converting spans.
    /// </summary>
    public static class SpanExtension {

        /// <summary>
        /// Converts the given value to the given type using the <see cref="UniversalTypeConverter">default converter</see>.
        ///  The result provides access to the converted value if conversion succeeded and simplifies access to default values if conversion failed.
        /// </summary>
        /// <typeparam name="T">The type to which the given value is converted.</typeparam>
        /// <param name="value">The value which is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static ConversionResult<T> As<T>(this ReadOnlySpan<char> value, CultureInfo culture = null) {
            if (value.IsConvertibleTo<T>(out var result, culture)) {
                return new ConversionResult<T>(result);
            }

            return new ConversionResult<T>();
        }

        /// <summary>
        /// Determines whether the given value can be converted to the specified type using the <see cref="UniversalTypeConverter">default converter</see>.
        /// </summary>
        /// <typeparam name="T">The type to test.</typeparam>
        /// <param name="value">The value to test.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> can be converted to <typeparamref name="T"/>; otherwise, false.</returns>
        public static bool IsConvertibleTo<T>(this ReadOnlySpan<char> value, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.CanConvertTo<T>(value, culture);
        }

        /// <summary>
        /// Determines whether the given value can be converted to the specified type using the <see cref="UniversalTypeConverter">default converter</see>.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="destinationType">The type to test.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> can be converted to <paramref name="destinationType"/>; otherwise, false.</returns>
        public static bool IsConvertibleTo(this ReadOnlySpan<char> value, Type destinationType, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.CanConvert(value, destinationType, culture);
        }

        /// <summary>
        /// Converts the given value to the given type using the <see cref="UniversalTypeConverter">default converter</see>.
        ///  A return value indicates whether the operation succeeded.
        /// </summary>
        /// <typeparam name="T">The type to which the given value is converted.</typeparam>
        /// <param name="value">The value which is converted.</param>
        /// <param name="result">An instance of type <typeparamref name="T">T</typeparamref> whose value is equivalent to the given <paramref name="value">value</paramref> if the operation succeeded.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> was converted successfully; otherwise, false.</returns>
        public static bool IsConvertibleTo<T>(this ReadOnlySpan<char> value, out T result, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.TryConvertTo(value, out result, culture);
        }

        /// <summary>
        /// Converts the given value to the given type using the <see cref="UniversalTypeConverter">default converter</see>.
        ///  A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <param name="result">An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref> if the operation succeeded.</param>
        /// <returns>true, if <paramref name="value"/> was converted successfully; otherwise, false.</returns>
        public static bool IsConvertibleTo(this ReadOnlySpan<char> value, Type destinationType, out object result, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.TryConvert(value, destinationType, out result, culture);
        }

        /// <summary>
        /// Converts the given value to the given type using the <see cref="UniversalTypeConverter">default converter</see>.
        /// </summary>
        /// <typeparam name="T">The type to which the given value is converted.</typeparam>
        /// <param name="value">The value which is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>An instance of type <typeparamref name="T">T</typeparamref> whose value is equivalent to the given <paramref name="value">value</paramref>.</returns>
        /// <exception cref="InvalidConversionException">InvalidConversionException if the value is not convertible to the given type.</exception>
        public static T To<T>(this ReadOnlySpan<char> value, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.ConvertTo<T>(value, culture);
        }

        /// <summary>
        /// Converts the given value to the given type using the <see cref="UniversalTypeConverter">default converter</see>.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref>.</returns>
        /// <exception cref="InvalidConversionException">InvalidConversionException if the value is not convertible to the given type.</exception>
        public static object To(this ReadOnlySpan<char> value, Type destinationType, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.Convert(value, destinationType, culture);
        }

    }

}
#endif