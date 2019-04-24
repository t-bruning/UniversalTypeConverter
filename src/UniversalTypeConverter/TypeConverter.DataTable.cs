// project  : UniversalTypeConverter
// file     : TypeConverter.DataTable.cs
// author   : Thorsten Bruning
// date     : 2019-04-01 

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using TB.ComponentModel.Reflection;

namespace TB.ComponentModel {

    public partial class TypeConverter {

        /// <summary>
        /// Creates a DataTable from an IEnumerable{T}.
        ///  Each element of the  given source results in a row representing the properties of {T} as columns.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The IEnumerable{T} to create a DataTable from.</param>
        /// <param name="incompatibleDataColumnTypeHandling">
        /// Defines how a type is handled if not valid for a DataColumn of a DataTable.
        ///  <see cref="IncompatibleDataColumnTypeHandling.ToString"/> is used by default.
        /// </param>
        /// <param name="culture">The culture to use if conversion is needed. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>A DataTable representing each element of the given source as a row.</returns>
        public DataTable CreateDataTable<T>(IEnumerable<T> source, IncompatibleDataColumnTypeHandling incompatibleDataColumnTypeHandling = IncompatibleDataColumnTypeHandling.ToString, CultureInfo culture = null) {
            var dataTable = new DataTable();
            var getters = new List<Tuple<Getter, bool>>();  // bool indicates if Type is compatible.

            // Add columns
            foreach (var getter in typeof(T).GetGetters()) {
                if (getter.ValueType.IsDataTableCompatible(out var dataType, out var isNullable)) {
                    var column = dataTable.Columns.Add(getter.Name, dataType);
                    column.AllowDBNull = isNullable;
                    getters.Add(new Tuple<Getter, bool>(getter, true));
                    continue;
                }

                switch (incompatibleDataColumnTypeHandling) {
                    case IncompatibleDataColumnTypeHandling.Ignore:
                        continue;
                    case IncompatibleDataColumnTypeHandling.ToString:
                    case IncompatibleDataColumnTypeHandling.AsString:
                        var column = dataTable.Columns.Add(getter.Name, typeof(string));
                        column.AllowDBNull = true;
                        getters.Add(new Tuple<Getter, bool>(getter, false));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(incompatibleDataColumnTypeHandling), incompatibleDataColumnTypeHandling, null);
                }
            }

            if (source == null) {
                return dataTable;
            }

            // Add rows
            foreach (var item in source.Where(i => i != null)) {
                var row = dataTable.NewRow();
                foreach (var getter in getters) {
                    var value = getter.Item1.GetValue(item);
                    if (value == null || value == DBNull.Value) {
                        row[getter.Item1.Name] = DBNull.Value;
                        continue;
                    }

                    if (getter.Item2) {
                        // Type is compatible
                        row[getter.Item1.Name] = value;
                        continue;
                    }

                    if (TryConvertTo<string>(value, out var representation, culture)) {
                        row[getter.Item1.Name] = representation;
                        continue;
                    }

                    switch (incompatibleDataColumnTypeHandling) {
                        case IncompatibleDataColumnTypeHandling.ToString:
                            row[getter.Item1.Name] = value.ToString();
                            break;
                        case IncompatibleDataColumnTypeHandling.AsString:
                            row[getter.Item1.Name] = DBNull.Value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(incompatibleDataColumnTypeHandling), incompatibleDataColumnTypeHandling, null);
                    }
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

    }

}