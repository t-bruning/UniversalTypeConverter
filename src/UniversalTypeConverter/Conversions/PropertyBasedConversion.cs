// project  : UniversalTypeConverter
// file     : PropertyBasedConversion.cs
// author   : Thorsten Bruning
// date     : 2019-03-06 

using System;
using System.Linq;
using System.Reflection;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for types which provide a public property/field of the type to convert to whose name is identical to the parameter of an constructor.
    /// </summary>
    public class PropertyBasedConversion : ITypeConversion {

        /// <inheritdoc />
        public bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            if (args.Options.PropertyResolvingMode == PropertyResolvingMode.None || value == null) {
                result = null;
                return false;
            }

            //TODO zz Perfomance improvement on reflection.

            var sourceType = value.GetType();
            var constructor = sourceType.GetConstructors().FirstOrDefault(c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == destinationType);
            if (constructor == null) {
                constructor = sourceType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new[] {destinationType}, null);
            }

            if (constructor == null) {
                result = null;
                return false;
            }

            var parameterName = constructor.GetParameters()[0].Name;
            var property = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                     .FirstOrDefault(p => p.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

            if (property == null) {
                result = null;
                return false;
            }

            if (property.PropertyType == destinationType) {
                try {
                    result = property.GetValue(value);
                    return true;
                } catch {
                    result = null;
                    return false;
                }
            }

            if (args.Options.PropertyResolvingMode == PropertyResolvingMode.Strict) {
                result = null;
                return false;
            }

            object propertyValue;
            try {
                propertyValue = property.GetValue(value);
            } catch {
                result = null;
                return false;
            }

            return args.Caller.TryConvert(propertyValue, destinationType, out result, args);
        }

    }

}