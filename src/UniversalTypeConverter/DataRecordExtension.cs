// project  : UniversalTypeConverter
// file     : DataRecordExtension.cs
// author   : Thorsten Bruning
// date     : 2019-04-02 

using System;
using System.Collections.Generic;
using System.Data;

namespace TB.ComponentModel {

    /// <summary>
    /// Provides extension methods for DataRows and DataRowViews.
    /// </summary>
    public static class DataRecordExtension {

        /// <summary>
        /// Creates a new dictionary whose key value pairs represent the fields of the given IDataRecord together with their values.
        ///  If the record is null, an empty dictionary is created.
        /// </summary>
        /// <param name="record">The IDataRecord whose fields are added to the new dictionary.</param>
        /// <returns>
        /// A new dictionary which contains the fields of <paramref name="record"/> together with their values.
        ///  If <paramref name="record"/> is null, an empty dictionary is returned.
        /// </returns>
        public static Dictionary<string, object> ToDictionary(this IDataRecord record) {
            var dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (record == null) {
                return dictionary;
            }

            for (var i = 0; i < record.FieldCount; i++) {
                dictionary.Add(record.GetName(i), record.GetValue(i));
            }

            return dictionary;
        }

    }

}