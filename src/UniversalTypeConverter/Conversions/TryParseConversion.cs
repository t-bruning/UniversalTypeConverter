// project  : UniversalTypeConverter
// file     : TryParseConversion.cs
// author   : Thorsten Bruning
// date     : 2019-03-06 

using System;
using System.Linq;
using System.Reflection;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines conversions from strings to their requested equivalent by using a static TryParse-Method - if provided.
    /// </summary>
    public class TryParseConversion : ITypeConversion {

        /// <inheritdoc />
        public bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            if (value == null || destinationType == null || !(value is string s)) {
                result = null;
                return false;
            }

            // Prefer IFormatProvider-Overload:
            var methods = destinationType.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name.Equals("TryParse", StringComparison.OrdinalIgnoreCase) && m.ReturnType == typeof(bool)).ToList();
            foreach (var method in methods) {
                var parameters = method.GetParameters();
                if (parameters.Length != 3) {
                    continue;
                }

                if (parameters[0].ParameterType != typeof(string)
                    || parameters[1].ParameterType != typeof(IFormatProvider)
                    || !parameters[2].IsOut) {
                    continue;
                }

                bool succeeded;
                var paramValues = new object[] {s, args.Culture, null};
                try {
                    succeeded = (bool) method.Invoke(null, paramValues);
                } catch {
                    succeeded = false;
                }

                if (succeeded && paramValues[2] != null && paramValues[2].GetType() == destinationType) {
                    result = paramValues[2];
                    return true;
                }
            }


            // Fallback withou IFormatProvider:
            foreach (var method in methods) {
                var parameters = method.GetParameters();
                if (parameters.Length != 2) {
                    continue;
                }

                if (parameters[0].ParameterType != typeof(string)
                    || !parameters[1].IsOut) {
                    continue;
                }

                bool succeeded;
                var paramValues = new object[] {s, null};
                try {
                    succeeded = (bool) method.Invoke(null, paramValues);
                } catch {
                    succeeded = false;
                }

                if (succeeded && paramValues[1] != null && paramValues[1].GetType() == destinationType) {
                    result = paramValues[1];
                    return true;
                }
            }

            result = null;
            return false;
        }

    }

}