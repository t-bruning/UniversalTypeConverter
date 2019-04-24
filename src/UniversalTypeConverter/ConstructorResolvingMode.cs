// project  : UniversalTypeConverter
// file     : ConstructorResolvingMode.cs
// author   : Thorsten Bruning
// date     : 2018-10-18 

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the mode used when resolving a constructor by a given parameter type.
    /// </summary>
    public enum ConstructorResolvingMode {

        /// <summary>
        /// No use of constructor resolving.
        /// </summary>
        None = 0,

        /// <summary>
        /// A constructor is used only if it's parameter is exact of the given type.
        /// </summary>
        Strict,

        /// <summary>
        /// A constructor is used if it's parameter is compatible to the the given type an no data is lost.
        ///  An example of a widening conversion is converting a value that is a 32-bit signed integer to a value that is a 64-bit signed integer.
        /// </summary>
        Lax

    }

}