// project  : UniversalTypeConverter
// file     : DataRowExtension.cs
// author   : Thorsten Bruning
// date     : 2019-04-02 

using System;
using System.Collections.Generic;
using System.Data;

namespace TB.ComponentModel {

    /// <summary>
    /// Provides extension methods for DataRows and DataRowViews.
    /// </summary>
    public static class DataRowExtension {

        /// <summary>
        /// Creates a new dictionary whose key value pairs represent the columns of the given DataRow together with their values.
        ///  If the row is null, an empty dictionary is created.
        /// </summary>
        /// <param name="row">The DataRow whose columns are added to the new dictionary.</param>
        /// <returns>
        /// A new dictionary which contains the columns of <paramref name="row"/> together with their values.
        ///  If <paramref name="row"/> is null, an empty dictionary is returned.
        /// </returns>
        public static Dictionary<string, object> ToDictionary(this DataRow row) {
            var dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (row == null) {
                return dictionary;
            }

            foreach (DataColumn column in row.Table.Columns) {
                dictionary.Add(column.ColumnName, row[column].OrNullIfDBNull());
            }

            return dictionary;
        }

        /// <summary>
        /// Creates a new dictionary whose key value pairs represent the columns of the given DataRowView together with their values.
        ///  If the row is null, an empty dictionary is created.
        /// </summary>
        /// <param name="rowView">The DataRowView whose columns are added to the new dictionary.</param>
        /// <returns>
        /// A new dictionary which contains the columns of <paramref name="rowView"/> together with their values.
        ///  If <paramref name="rowView"/> is null, an empty dictionary is returned.
        /// </returns>
        public static Dictionary<string, object> ToDictionary(this DataRowView rowView) {
            var dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (rowView == null) {
                return dictionary;
            }

            foreach (DataColumn column in rowView.DataView.Table.Columns) {
                dictionary.Add(column.ColumnName, rowView[column.ColumnName].OrNullIfDBNull());
            }

            return dictionary;
        }

    }

}