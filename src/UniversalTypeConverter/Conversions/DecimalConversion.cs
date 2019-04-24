// project  : UniversalTypeConverter
// file     : DecimalConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-15 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for Decimales.
    /// </summary>
    public class DecimalConversion : TypeConversion<decimal> {

        /// <inheritdoc />
        protected override bool TryConvert(decimal value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.DecimalFormat, args.Culture);
                return true;
            }

            result = null;
            return false;
        }

    }

}