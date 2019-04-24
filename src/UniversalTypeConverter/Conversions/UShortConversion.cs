// project  : UniversalTypeConverter
// file     : UShortConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-15 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for UShorts's.
    /// </summary>
    public class UShortConversion : TypeConversion<ushort> {

        /// <inheritdoc />
        protected override bool TryConvert(ushort value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.IntegerFormat, args.Culture);
                return true;
            }

            result = null;
            return false;
        }

    }

}