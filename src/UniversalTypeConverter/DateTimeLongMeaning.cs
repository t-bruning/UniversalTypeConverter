// project  : UniversalTypeConverter
// file     : DateTimeLongMeaning.cs
// author   : Thorsten Bruning
// date     : 2018-10-16 

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the meaning of a Long value when converting to DateTime.
    /// </summary>
    public enum DateTimeLongMeaning {

        /// <summary>
        /// No meaning -> no special conversion.
        /// </summary>
        None = 0,

        /// <summary>
        /// Long values are handled as DateTime.Ticks.
        /// </summary>
        Ticks,

        /// <summary>
        /// Long values are handled by DateTime.FromBinary().
        /// </summary>
        Binary,

        /// <summary>
        /// Long values are handled by DateTime.FromFileTime().
        /// </summary>
        FileTime,

        /// <summary>
        /// Long values are handled by DateTime.FromFileTimeUtc().
        /// </summary>
        FileTimeUtc

    }

}