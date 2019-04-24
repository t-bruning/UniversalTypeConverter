// project  : UniversalTypeConverter
// file     : SByteConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-15 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for SBytes's.
    /// </summary>
    public class SByteConversion : TypeConversion<sbyte> {

        /// <inheritdoc />
        protected override bool TryConvert(sbyte value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.IntegerFormat, args.Culture);
                return true;
            }

            result = null;
            return false;
        }

    }

}