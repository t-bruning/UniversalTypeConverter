// project  : UniversalTypeConverter
// file     : ByteArrayFormat.cs
// author   : Thorsten Bruning
// date     : 2018-10-16 

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the format used when converting an array of bytes to its equivalent string representation and vice versa.
    /// </summary>
    public enum ByteArrayFormat {

        /// <summary>
        /// No format -> no special conversion.
        /// </summary>
        None = 0,

        /// <summary>
        /// Base64 without line breaks.
        /// </summary>
        Base64,

        /// <summary>
        /// Base64 with line breaks after every 76 characters in the string representation.
        /// </summary>
        Base64WithLineBreaks

    }

}