// project  : UniversalTypeConverter
// file     : EnumerableExtension.cs
// author   : Thorsten Bruning
// date     : 2019-03-07 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;

namespace TB.ComponentModel {

    /// <summary>
    /// Provides extension methods for converting enumerables.
    /// </summary>
    public static class EnumerableExtension {

        /// <summary>
        /// Returns an iterator over the results of converting the given values to the given type.
        ///  The conversion is configurable further more before iteration.
        /// </summary>
        /// <typeparam name="T">The type to which the given values are converted.</typeparam>
        /// <param name="values">The list of values which are converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>List of converted values.</returns>
        public static EnumerableConversion<T> ToEnumerable<T>(this IEnumerable values, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.ConvertToEnumerable<T>(values, culture);
        }

        /// <summary>
        /// Returns an iterator over the results of converting the given values to the given type.
        ///  The conversion is configurable further more before iteration.
        /// </summary>
        /// <param name="values">The list of values which are converted.</param>
        /// <param name="destinationType">The type to which the given values are converted.</param>
        /// <param name="culture">The culture to use. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>List of converted values.</returns>
        public static EnumerableConversion<object> ToEnumerable(this IEnumerable values, Type destinationType, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.ConvertToEnumerable(values, destinationType, culture);
        }

        /// <summary>
        /// Creates a Collection{T} from an IEnumerable{T}.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The IEnumerable{T} to create a Collection{T} from.</param>
        /// <returns>A Collection{T} that contains elements from the input sequence.</returns>
        public static Collection<T> ToCollection<T>(this IEnumerable<T> source) {
            if (source == null) {
                throw new ArgumentNullException(nameof(source));
            }

            var collection = new Collection<T>();
            foreach (var s in source) {
                collection.Add(s);
            }

            return collection;
        }

        /// <summary>
        /// Creates a DataTable from an IEnumerable{T}.
        ///  Each element of the  given source results in a row representing the properties of {T} as columns.
        ///  If conversion is needed, the <see cref="UniversalTypeConverter">default converter</see> is used.
        ///  <see cref="IncompatibleDataColumnTypeHandling.ToString"/> is used for types which are not valid for a DataColumn of a DataTable.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The IEnumerable{T} to create a DataTable from.</param>
        /// <param name="culture">The culture to use if conversion is needed. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>A DataTable representing each element of the given source as a row.</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source, CultureInfo culture) {
            return UniversalTypeConverter.Instance.CreateDataTable(source, IncompatibleDataColumnTypeHandling.ToString, culture);
        }

        /// <summary>
        /// Creates a DataTable from an IEnumerable{T}.
        ///  Each element of the  given source results in a row representing the properties of {T} as columns.
        ///  If conversion is needed, the <see cref="UniversalTypeConverter">default converter</see> is used.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The IEnumerable{T} to create a DataTable from.</param>
        /// <param name="incompatibleDataColumnTypeHandling">
        /// Defines how a type is handled if not valid for a DataColumn of a DataTable.
        ///  <see cref="IncompatibleDataColumnTypeHandling.ToString"/> is used by default.
        /// </param>
        /// <param name="culture">The culture to use if conversion is needed. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>A DataTable representing each element of the given source as a row.</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source, IncompatibleDataColumnTypeHandling incompatibleDataColumnTypeHandling = IncompatibleDataColumnTypeHandling.ToString, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.CreateDataTable(source, incompatibleDataColumnTypeHandling, culture);
        }

    }

}