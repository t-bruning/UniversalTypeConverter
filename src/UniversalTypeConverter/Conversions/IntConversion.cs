// project  : UniversalTypeConverter
// file     : IntConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-15 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for Int's.
    /// </summary>
    public class IntConversion : TypeConversion<int> {

        /// <inheritdoc />
        protected override bool TryConvert(int value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.IntegerFormat, args.Culture);
                return true;
            }

            result = null;
            return false;
        }

    }

}