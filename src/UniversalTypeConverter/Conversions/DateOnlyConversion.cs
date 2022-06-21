// project  : UniversalTypeConverter
// file     : DateTimeConversion.cs
// author   : Thorsten Bruning
// date     : 2022-05-14

#if NET6_0_OR_GREATER

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for DateOnly.
    /// </summary>
    public class DateOnlyConversion : TypeConversion<DateOnly> {

        /// <inheritdoc/>
        protected override bool TryConvert(DateOnly value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.DateOnlyFormat, args.Culture);
                return true;
            }

            if (destinationType == typeof(DateTime)) {
                result = value.ToDateTime(args.Options.DateOnlyDefaultTime);
                return true;
            }

            result = null;
            return false;
        }
    }
}

#endif
