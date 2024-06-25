// project  : UniversalTypeConverter
// file     : ReadOnlySpanOfCharConversion.cs
// author   : Thorsten Bruning
// date     : 2024-06-25 

#if NET6_0_OR_GREATER
using System;
using TB.ComponentModel.Reflection;

namespace TB.ComponentModel.Conversions {

    internal static class ReadOnlySpanOfCharConversion {

        public static bool TryConvert(ReadOnlySpan<char> value, Type destinationType, out object result, ConversionArgs args) {
            if (value.IsWhiteSpace()) {
                result = null;
                return false;
            }

            if (destinationType.IsInteger()) {
                return TryParseInteger(value, destinationType, out result, args);
            }

            if (destinationType == typeof(decimal)) {
                return TryParseDecimal(value, out result, args);
            }

            if (destinationType.IsFloat()) {
                return TryParseFloat(value, destinationType, out result, args);
            }

            if (destinationType == typeof(DateTime)) {
                return TryParseDateTime(value, out result, args);
            }

            if (destinationType == typeof(DateOnly)) {
                return TryParseDateOnly(value, out result, args);
            }

            if (destinationType == typeof(TimeOnly)) {
                return TryParseTimeOnly(value, out result, args);
            }

            if (destinationType == typeof(Guid)) {
                return TryParseGuid(value, out result);
            }

            result = null;
            return false;
        }

        private static bool TryParseInteger(ReadOnlySpan<char> value, Type destinationType, out object result, ConversionArgs args) {
            var style = args.Options.IntegerNumberStyle;

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

        private static bool TryParseDecimal(ReadOnlySpan<char> value, out object result, ConversionArgs args) {
            var style = args.Options.DecimalNumberStyle;
            var succeeded = decimal.TryParse(value, style, args.Culture, out var parseResult);
            result = parseResult;
            return succeeded;
        }

        private static bool TryParseFloat(ReadOnlySpan<char> value, Type destinationType, out object result, ConversionArgs args) {
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

        private static bool TryParseDateTime(ReadOnlySpan<char> value, out object result, ConversionArgs args) {
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

        private static bool TryParseDateOnly(ReadOnlySpan<char> value, out object result, ConversionArgs args) {
            if (DateOnly.TryParse(value, args.Culture, args.Options.DateTimeStyle, out var parseResult)) {
                result = parseResult;
                return true;
            }

            foreach (var pattern in args.Options.DateTimePatterns) {
                if (DateOnly.TryParseExact(value, pattern, args.Culture, args.Options.DateTimeStyle, out parseResult)) {
                    result = parseResult;
                    return true;
                }
            }

            result = DateOnly.MinValue;
            return false;
        }

        private static bool TryParseTimeOnly(ReadOnlySpan<char> value, out object result, ConversionArgs args) {
            if (TimeOnly.TryParse(value, args.Culture, args.Options.DateTimeStyle, out var parseResult)) {
                result = parseResult;
                return true;
            }

            foreach (var pattern in args.Options.TimeOnlyPatterns) {
                if (TimeOnly.TryParseExact(value, pattern, args.Culture, args.Options.DateTimeStyle, out parseResult)) {
                    result = parseResult;
                    return true;
                }
            }

            result = DateOnly.MinValue;
            return false;
        }

        private static bool TryParseGuid(ReadOnlySpan<char> value, out object result) {
            if (Guid.TryParse(value, out var guid)) {
                result = guid;
                return true;
            }

            result = null;
            return false;
        }

    }

}
#endif