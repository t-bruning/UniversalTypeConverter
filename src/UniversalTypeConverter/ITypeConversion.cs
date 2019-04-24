// project  : UniversalTypeConverter
// file     : ITypeConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-12 

using System;

namespace TB.ComponentModel {

    /// <summary>
    /// Defines a conversion.
    /// </summary>
    public interface ITypeConversion {

        /// <summary>
        /// Converts the given value to the given type.
        ///  A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="value">The value which is converted.</param>
        /// <param name="destinationType">The type to which the given value is converted.</param>
        /// <param name="result">An instance of type <paramref name="destinationType">destinationType</paramref> whose value is equivalent to the given <paramref name="value">value</paramref> if the operation succeeded.</param>
        /// <param name="args">Arguments for conversion.</param>
        /// <returns>true, if <paramref name="value"/> was converted successfully; otherwise, false.</returns>
        bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args);

    }

}