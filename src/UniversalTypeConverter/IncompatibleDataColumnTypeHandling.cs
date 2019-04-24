// project  : UniversalTypeConverter
// file     : IncompatibleDataColumnTypeHandling.cs
// author   : Thorsten Bruning
// date     : 2019-03-21 

namespace TB.ComponentModel {

    /// <summary>
    /// Defines how a type is handled if not valid for a DataColumn of a DataTable.
    /// </summary>
    public enum IncompatibleDataColumnTypeHandling {

        /// <summary>
        /// The type is handled as String.
        ///  Values are converted to string using the given TypeConverter. If conversion was not successful, ToString() is used at last.
        /// </summary>
        ToString = 0,

        /// <summary>
        /// The type is handled as String.
        ///  Values are converted to string using the given TypeConverter. If conversion was not successful, DBNull is used at last.
        /// </summary>
        AsString,

        /// <summary>
        /// The type is ignored.
        /// </summary>
        Ignore

    }

}