// project  : UniversalTypeConverter
// file     : FloatConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-15 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for Floates.
    /// </summary>
    public class FloatConversion : TypeConversion<float> {

        /// <inheritdoc />
        protected override bool TryConvert(float value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.FloatFormat, args.Culture);
                return true;
            }

            if (destinationType == typeof(char)) {
                try {
                    var i = Convert.ToInt16(value);
                    result = Convert.ToChar(i);
                    return true;
                } catch {
                }
            }

            result = null;
            return false;
        }

    }

}