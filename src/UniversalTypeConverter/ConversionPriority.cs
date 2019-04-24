// project  : UniversalTypeConverter
// file     : ConversionPriority.cs
// author   : Thorsten Bruning
// date     : 2018-09-12 

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the priority of a conversion.
    /// </summary>
    public enum ConversionPriority {

        /// <summary>
        /// High priority.
        ///  Adds a conversion before all other conversions so that the conversion is tried before the built-in conversions.
        /// </summary>
        High = 0,

        /// <summary>
        /// Low priority.
        ///  Adds a conversion after all other conversions so that the conversion is tried after all high priority conversions and built-in conversions failed.
        /// </summary>
        Low

    }

}