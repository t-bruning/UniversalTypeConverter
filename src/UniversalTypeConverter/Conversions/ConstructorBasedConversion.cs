// project  : UniversalTypeConverter
// file     : ConstructorBasedConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-17 

using System;
using System.Linq;
using System.Reflection;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for types which provide a constructor with its only parameter beeing compatible to the value to convert from.
    /// </summary>
    public class ConstructorBasedConversion : ITypeConversion {

        /// <inheritdoc />
        public bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            if (args.Options.ConstructorResolvingMode == ConstructorResolvingMode.None || value == null) {
                result = null;
                return false;
            }

            //TODO zz Perfomance improvement on reflection.

            var sourceType = value.GetType();
            var constructor = destinationType.GetConstructors().FirstOrDefault(c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == sourceType);
            if (constructor == null && args.Options.ConstructorResolvingMode == ConstructorResolvingMode.Lax) {
                constructor = destinationType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new[] {sourceType}, null);
            }

            if (constructor != null) {
                try {
                    result = constructor.Invoke(new[] {value});
                    return true;
                } catch {
                }
            }

            result = null;
            return false;
        }

    }

}