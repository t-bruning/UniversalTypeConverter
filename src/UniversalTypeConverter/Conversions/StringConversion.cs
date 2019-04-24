// project  : UniversalTypeConverter
// file     : StringConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-24 

using System;
using System.Globalization;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines conversions from strings to their requested equivalent.
    /// </summary>
    public class StringConversion : TypeConversion<string> {

        /// <inheritdoc />
        protected override bool TryConvert(string value, Type destinationType, out object result, ConversionArgs args) {
            if (string.IsNullOrWhiteSpace(value)) {
                result = null;
                return false;
            }

            if (IsInteger(destinationType)) {
                return TryParseInteger(value, destinationType, out result, args);
            }

            if (destinationType == typeof(decimal)) {
                return TryParseDecimal(value, out result, args);
            }

            if (IsFloat(destinationType)) {
                return TryParseFloat(value, destinationType, out result, args);
            }

            if (destinationType == typeof(DateTime)) {
                return TryParseDateTime(value, out result, args);
            }

            if (destinationType == typeof(Guid)) {
                return TryParseGuid(value, out result);
            }

            if (destinationType == typeof(byte[]) && args.Options.ByteArrayFormat != ByteArrayFormat.None) {
                try {
                    result = Convert.FromBase64String(value);
                    return true;
                } catch {
                    result = null;
                    return false;
                }
            }

            result = null;
            return false;
        }

        private bool TryParseInteger(string value, Type destinationType, out object result, ConversionArgs args) {
            var style = args.Options.IntegerNumberStyle;
            if (IsHex(value)) {
                style = NumberStyles.AllowHexSpecifier;
            }

            if (destinationType == typeof(byte)) {
                var succeeded = byte.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            if (destinationType == typeof(int)) {
                var succeeded = int.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            if (destinationType == typeof(long)) {
                var succeeded = long.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            if (destinationType == typeof(sbyte)) {
                var succeeded = sbyte.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            if (destinationType == typeof(short)) {
                var succeeded = short.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            if (destinationType == typeof(uint)) {
                var succeeded = uint.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            if (destinationType == typeof(ulong)) {
                var succeeded = ulong.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            if (destinationType == typeof(ushort)) {
                var succeeded = ushort.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            result = null;
            return false;
        }

        private bool IsHex(string value) {
            if (value.Length < 3) {
                return false;
            }

            return value.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                   || value.StartsWith("&h", StringComparison.OrdinalIgnoreCase);
        }

        private bool TryParseDecimal(string value, out object result, ConversionArgs args) {
            var style = args.Options.DecimalNumberStyle;
            var succeeded = decimal.TryParse(value, style, args.Culture, out var parseResult);
            result = parseResult;
            return succeeded;
        }

        private bool TryParseFloat(string value, Type destinationType, out object result, ConversionArgs args) {
            var style = args.Options.FloatNumberStyle;
            if (destinationType == typeof(float)) {
                var succeeded = float.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            if (destinationType == typeof(double)) {
                var succeeded = double.TryParse(value, style, args.Culture, out var parseResult);
                result = parseResult;
                return succeeded;
            }

            result = null;
            return false;
        }

        private bool TryParseDateTime(string value, out object result, ConversionArgs args) {
            if (DateTime.TryParse(value, args.Culture, args.Options.DateTimeStyle, out var parseResult)) {
                result = parseResult;
                return true;
            }

            foreach (var pattern in args.Options.DateTimePatterns) {
                if (DateTime.TryParseExact(value, pattern, args.Culture, args.Options.DateTimeStyle, out parseResult)) {
                    result = parseResult;
                    return true;
                }
            }

            result = DateTime.MinValue;
            return false;
        }

        private bool TryParseGuid(string value, out object result) {
            if (Guid.TryParse(value, out var guid)) {
                result = guid;
                return true;
            }

            result = null;
            return false;
        }
    }

}
