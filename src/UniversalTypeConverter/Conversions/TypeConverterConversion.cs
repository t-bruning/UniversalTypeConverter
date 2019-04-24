// project  : UniversalTypeConverter
// file     : TypeConverterConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-20 

using System;
using System.ComponentModel;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion with associated System.ComponentModel.TypeConverters.
    /// </summary>
    public class TypeConverterConversion : ConversionBase {

        /// <inheritdoc />
        public override bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            System.ComponentModel.TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
            if (converter.GetType() != typeof(System.ComponentModel.TypeConverter) && converter.CanConvertFrom(value.GetType())) {
                try {
                    result = converter.ConvertFrom(null, args.Culture, value);
                    return true;
                }
                catch {
                }
            }

            converter = TypeDescriptor.GetConverter(value.GetType());
            if (converter.GetType() != typeof(System.ComponentModel.TypeConverter) && converter.CanConvertTo(destinationType)) {
                try {
                    result = converter.ConvertTo(null, args.Culture, value, destinationType);
                    return true;
                }
                catch {
                }
            }

            result = null;
            return false;
        }

    }

}