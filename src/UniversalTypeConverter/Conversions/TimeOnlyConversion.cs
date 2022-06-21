// project  : UniversalTypeConverter
// file     : DateTimeConversion.cs
// author   : Thorsten Bruning
// date     : 2022-05-14

#if NET6_0_OR_GREATER

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for TimeOnly.
    /// </summary>
    public class TimeOnlyConversion : TypeConversion<TimeOnly> {

        /// <inheritdoc/>
        protected override bool TryConvert(TimeOnly value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.TimeOnlyFormat, args.Culture);
                return true;
            }

            result = null;
            return false;
        }
    }
}

#endif
