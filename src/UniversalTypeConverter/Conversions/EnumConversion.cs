// project  : UniversalTypeConverter
// file     : EnumConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-20 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for Enum-types.
    /// </summary>
    public class EnumConversion : ConversionBase {

        /// <inheritdoc />
        public override bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            if (IsEnum(destinationType)) {
                try {
                    result = Enum.ToObject(destinationType, value);
                    return true;
                } catch {
                }
            }

            result = null;
            return false;
        }

        
    }

}