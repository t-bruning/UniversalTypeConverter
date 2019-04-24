// project  : UniversalTypeConverter
// file     : ObjectExtension.cs
// author   : Thorsten Bruning
// date     : 2018-09-18 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using TB.ComponentModel.Reflection;

namespace TB.ComponentModel {

    /// <summary>
    /// Provides extension methods for converting object instances.
    /// </summary>
    public static partial class ObjectExtension {

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
        public static ConversionResult<T> As<T>(this object value, CultureInfo culture = null) {
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
        public static bool IsConvertibleTo<T>(this object value, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.CanConvertTo<T>(value, culture);
        }

        /// <summary>
        /// Determines whether the given value can be converted to the specified type using the <see cref="UniversalTypeConverter">default converter</see>.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="destinationType">The type to test.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>true if <paramref name="value"/> can be converted to <paramref name="destinationType"/>; otherwise, false.</returns>
        public static bool IsConvertibleTo(this object value, Type destinationType, CultureInfo culture = null) {
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
        public static bool IsConvertibleTo<T>(this object value, out T result, CultureInfo culture = null) {
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
        public static bool IsConvertibleTo(this object value, Type destinationType, out object result, CultureInfo culture = null) {
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
        public static T To<T>(this object value, CultureInfo culture = null) {
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
        public static object To(this object value, Type destinationType, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.Convert(value, destinationType, culture);
        }

        /// <summary>
        /// Creates a new dictionary whose key value pairs represent all non static public values of the given source.
        ///  If source is null, an empty dictionary is created.
        ///  If source has no non static public properties or fields (eg. int), the dictionary contains only one key named "Value" representing the given value itself.
        /// </summary>
        /// <param name="obj">The object whose non static public properties and fields are added to the new dictionary.</param>
        /// <returns>
        /// A dictionary which contains the non static public values of <paramref name="obj"/>.
        /// </returns>
        /// <remarks>
        /// If <paramref name="obj"/> is a Dictionary{string, object}, <paramref name="obj"/> is returned.
        ///  If <paramref name="obj"/> implements IDictionary, an new Dictionary{string, object} is returned, which keys are build by using ToString() on the source keys and keeping their original values.
        ///  If <paramref name="obj"/> is a DataRow, <see cref="DataRowExtension.ToDictionary(DataRow)"/> is returned.
        ///  If <paramref name="obj"/> is a DataRowView, <see cref="DataRowExtension.ToDictionary(DataRowView)"/> is returned.
        ///  If <paramref name="obj"/> is a IDataRecord, <see cref="DataRecordExtension.ToDictionary(IDataRecord)"/> is returned.
        ///  If <paramref name="obj"/> is null, an empty dictionary is returned.
        ///  If <paramref name="obj"/> has no non static public properties or fields (eg. int), an dictionary with its only key named "Value" is returned.
        /// </remarks>
        public static Dictionary<string, object> ToDictionary(this object obj) {
            switch (obj) {
                case Dictionary<string, object> dic:
                    return dic;
                case IDictionary dic:
                    return dic.ToDictionary();
                case DataRow row:
                    return row.ToDictionary();
                case DataRowView rowView:
                    return rowView.ToDictionary();
                case IDataRecord record:
                    return record.ToDictionary();
            }

            var dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (obj == null) {
                return dictionary;
            }

            foreach (var getter in obj.GetType().GetGetters()) {
                dictionary.Add(getter.Name, getter.GetValue(obj).OrNullIfDBNull());
            }

            if (dictionary.Count == 0) {
                dictionary.Add("Value", obj.OrNullIfDBNull());
            }

            return dictionary;
        }

        private static Dictionary<string, object> ToDictionary(this IDictionary dictionary) {
            var result = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (dictionary == null) {
                return result;
            }

            foreach (var key in dictionary.Keys) {
                try {
                    result.Add(key.ToString(), dictionary[key]);
                } catch {
                }
            }

            return result;
        }

        internal static object OrNullIfDBNull(this object value) {
            if (value == DBNull.Value) {
                return null;
            }

            return value;
        }

    }

}