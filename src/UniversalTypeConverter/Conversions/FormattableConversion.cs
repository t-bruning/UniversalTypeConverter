// project  : UniversalTypeConverter
// file     : FormattableConversion.cs
// author   : Thorsten Bruning
// date     : 2019-03-06 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for source values which implement <see cref="IFormattable"/>.
    /// </summary>
    public class FormattableConversion : TypeConversion<IFormattable> {

        /// <inheritdoc />
        protected override bool TryConvert(IFormattable value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType != typeof(string)) {
                result = null;
                return false;
            }

            try {
                result = value.ToString(null, args.Culture);
                return true;
            } catch {
            }

            result = null;
            return false;
        }

    }

}