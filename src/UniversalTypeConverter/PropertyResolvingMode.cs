// project  : UniversalTypeConverter
// file     : PropertyResolvingMode.cs
// author   : Thorsten Bruning
// date     : 2019-03-06 

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the mode used when resolving a property by a given type.
    /// </summary>
    public enum PropertyResolvingMode {

        /// <summary>
        /// No use of property resolving.
        /// </summary>
        None = 0,

        /// <summary>
        /// A property is used only if it's type is exact of the given type.
        /// </summary>
        Strict,

        /// <summary>
        /// A property is used if it's type is convertible to the given type.
        /// </summary>
        Lax

    }

}