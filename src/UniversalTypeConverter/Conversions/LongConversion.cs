// project  : UniversalTypeConverter
// file     : LongConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-15 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for Long's.
    /// </summary>
    public class LongConversion : TypeConversion<long> {

        /// <inheritdoc />
        protected override bool TryConvert(long value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                result = value.ToString(args.Options.IntegerFormat, args.Culture);
                return true;
            }

            if (destinationType == typeof(DateTime)) {
                switch (args.Options.DateTimeLongMeaning) {
                    case DateTimeLongMeaning.None:
                        args.Break = true;
                        result = null;
                        return false;
                    case DateTimeLongMeaning.Ticks:
                        try {
                            result = new DateTime(value);
                            return true;
                        } catch {
                            result = null;
                            return false;
                        }
                    case DateTimeLongMeaning.Binary:
                        try {
                            result = DateTime.FromBinary(value);
                            return true;
                        } catch {
                            result = null;
                            return false;
                        }
                    case DateTimeLongMeaning.FileTime:
                        try {
                            result = DateTime.FromFileTime(value);
                            return true;
                        } catch {
                            result = null;
                            return false;
                        }
                    case DateTimeLongMeaning.FileTimeUtc:
                        try {
                            result = DateTime.FromFileTimeUtc(value);
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