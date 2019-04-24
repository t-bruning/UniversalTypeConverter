// project  : UniversalTypeConverter
// file     : CharConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-18 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for Chars.
    /// </summary>
    public class CharConversion : TypeConversion<char> {

        /// <inheritdoc />
        protected override bool TryConvert(char value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(double)) {
                try {
                    var i = Convert.ToInt16(value);
                    result = Convert.ToDouble(i);
                    return true;
                } catch {
                }
            }

            if (destinationType == typeof(float)) {
                try {
                    var i = Convert.ToInt16(value);
                    result = Convert.ToSingle(i);
                    return true;
                } catch {
                }
            }

            result = null;
            return false;
        }

    }

}