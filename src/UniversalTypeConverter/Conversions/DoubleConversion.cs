// project  : UniversalTypeConverter
// file     : DoubleConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-11 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for Doubles.
    /// </summary>
    public class DoubleConversion : TypeConversion<double> {

        /// <inheritdoc />
        protected override bool TryConvert(double value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.IntegerFormat, args.Culture);
                return true;
            }

            if (destinationType == typeof(DateTime)) {
                try {
                    result = DateTime.FromOADate(value);
                    return true;
                } catch {
                }
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