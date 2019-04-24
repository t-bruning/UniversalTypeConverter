// project  : UniversalTypeConverter
// file     : TypeConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-19 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion which is source type specific.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public abstract class TypeConversion<TSource> : ConversionBase {

        /// <inheritdoc />
        public override bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            if (!(value is TSource sourceValue)) {
                result = null;
                return false;
            }

            return TryConvert(sourceValue, destinationType, out result, args);
        }

        protected abstract bool TryConvert(TSource value, Type destinationType, out object result, ConversionArgs args);

    }

}