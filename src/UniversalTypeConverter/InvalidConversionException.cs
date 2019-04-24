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
        /// <param name="valueToConvert"></param>
        /// <param name="destinationType"></param>
        public InvalidConversionException(object valueToConvert, Type destinationType)
            : base($"'{valueToConvert}' ({valueToConvert?.GetType()}) is not convertible to '{destinationType}'.") {
        }

    }

}