// project  : UniversalTypeConverter
// file     : GuidConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-11 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines conversions from guids.
    /// </summary>
    public class GuidConversion : TypeConversion<Guid> {

        /// <inheritdoc />
        protected override bool TryConvert(Guid value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.GuidFormat, args.Culture);
                return true;
            }

            result = null;
            return false;
        }

    }

}