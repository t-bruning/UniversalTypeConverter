// project  : UniversalTypeConverter
// file     : InvalidConversionException.cs
// author   : Thorsten Bruning
// date     : 2018-09-12 

using System;

namespace TB.ComponentModel {

    /// <summary>
    /// The exception that is thrown when a conversion is invalid.
    /// </summary>
    public class InvalidConversionException : InvalidOperationException {

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConversionException">InvalidConversionException</see> class.
        /// </summary>
        public InvalidConversionException(object valueToConvert, Type destinationType)
            : base($"'{valueToConvert}' ({valueToConvert?.GetType()}) is not convertible to '{destinationType}'.") {
        }

#if NET6_0_OR_GREATER
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConversionException">InvalidConversionException</see> class.
        /// </summary>
        public InvalidConversionException(ReadOnlySpan<char> valueToConvert, Type destinationType)
            : base($"'{valueToConvert}' (ReadOnlySpan<char>) is not convertible to '{destinationType}'.") {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConversionException">InvalidConversionException</see> class.
        /// </summary>
        public InvalidConversionException(string valueToConvert, Type destinationType)
            : base($"'{valueToConvert}' ({valueToConvert?.GetType()}) is not convertible to '{destinationType}'.") {
            // Overload with string needed because of compiler error CS0121:
            // The call is ambiguous between the following methods or properties: 'InvalidConversionException.InvalidConversionException(object, Type)' and 'InvalidConversionException.InvalidConversionException(ReadOnlySpan<char>, Type)'
        }
#endif

    }

}