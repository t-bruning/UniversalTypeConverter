// project  : UniversalTypeConverter
// file     : ConvertibleConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-18 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for source values which implement <see cref="IConvertible"/>.
    /// </summary>
    public class ConvertibleConversion : TypeConversion<IConvertible> {

        /// <inheritdoc />
        protected override bool TryConvert(IConvertible value, Type destinationType, out object result, ConversionArgs args) {
            try {
                if (destinationType == typeof(string)) {
                    result = value.ToString(args.Culture);
                    return true;
                }

                if (destinationType == typeof(int)) {
                    result = value.ToInt32(args.Culture);
                    return true;
                }

                if (destinationType == typeof(bool)) {
                    result = value.ToBoolean(args.Culture);
                    return true;
                }

                if (destinationType == typeof(decimal)) {
                    result = value.ToDecimal(args.Culture);
                    return true;
                }

                if (destinationType == typeof(DateTime)) {
                    result = value.ToDateTime(args.Culture);
                    return true;
                }

                if (destinationType == typeof(byte)) {
                    result = value.ToByte(args.Culture);
                    return true;
                }

                if (destinationType == typeof(char)) {
                    result = value.ToChar(args.Culture);
                    return true;
                }

                if (destinationType == typeof(double)) {
                    result = value.ToDouble(args.Culture);
                    return true;
                }

                if (destinationType == typeof(short)) {
                    result = value.ToInt16(args.Culture);
                    return true;
                }

                if (destinationType == typeof(long)) {
                    result = value.ToInt64(args.Culture);
                    return true;
                }

                if (destinationType == typeof(sbyte)) {
                    result = value.ToSByte(args.Culture);
                    return true;
                }

                if (destinationType == typeof(float)) {
                    result = value.ToSingle(args.Culture);
                    return true;
                }

                if (destinationType == typeof(ushort)) {
                    result = value.ToUInt16(args.Culture);
                    return true;
                }

                if (destinationType == typeof(uint)) {
                    result = value.ToUInt32(args.Culture);
                    return true;
                }

                if (destinationType == typeof(ulong)) {
                    result = value.ToUInt64(args.Culture);
                    return true;
                }
            } catch {
            }

            try {
                result = value.ToType(destinationType, args.Culture);
                return true;
            } catch {
            }

            result = null;
            return false;
        }

    }

}