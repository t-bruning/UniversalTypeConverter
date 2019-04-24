// project  : UniversalTypeConverter
// file     : AssignableConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-20 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion where the destination type is assignable from the source type.
    /// </summary>
    public class AssignableConversion : ConversionBase {

        /// <inheritdoc />
        public override bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            if (IsAssignable(destinationType, value.GetType())) {
                result = value;
                return true;
            }

            result = null;
            return false;
        }

    }

}