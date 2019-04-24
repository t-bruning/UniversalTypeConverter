// project  : UniversalTypeConverter
// file     : DateTimeConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-09

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for DateTimes.
    /// </summary>
    public class DateTimeConversion : TypeConversion<DateTime> {

        /// <inheritdoc />
        protected override bool TryConvert(DateTime value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.DateTimeFormat, args.Culture);
                return true;
            }

            if (destinationType == typeof(double)) {
                try {
                    result = value.ToOADate();
                    return true;
                } catch {
                }
            }

            if (destinationType == typeof(long)) {
                switch (args.Options.DateTimeLongMeaning) {
                    case DateTimeLongMeaning.None:
                        args.Break = true;
                        result = null;
                        return false;
                    case DateTimeLongMeaning.Ticks:
                        result = value.Ticks;
                        return true;
                    case DateTimeLongMeaning.Binary:
                        try {
                            result = value.ToBinary();
                            return true;
                        } catch {
                            result = null;
                            return false;
                        }
                    case DateTimeLongMeaning.FileTime:
                        try {
                            result = value.ToFileTime();
                            return true;
                        } catch {
                            result = null;
                            return false;
                        }
                    case DateTimeLongMeaning.FileTimeUtc:
                        try {
                            result = value.ToFileTimeUtc();
                            return true;
                        } catch {
                            result = null;
                            return false;
                        }
                }
            }

            result = null;
            return false;
        }

    }

}
