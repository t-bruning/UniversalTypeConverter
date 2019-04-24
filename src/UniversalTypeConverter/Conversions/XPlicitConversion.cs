// project  : UniversalTypeConverter
// file     : XPlicitConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-22 

using System;
using System.Linq;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines explicit and implicit conversion.
    /// </summary>
    public class XPlicitConversion : ConversionBase {

        private const string ImplicitOperatorMethodName = "op_Implicit";
        private const string ExplicitOperatorMethodName = "op_Explicit";

        /// <inheritdoc />
        public override bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args) {
            if (TryConvertXPlicit(value, destinationType, ExplicitOperatorMethodName, out result)) {
                return true;
            }

            if (TryConvertXPlicit(value, destinationType, ImplicitOperatorMethodName, out result)) {
                return true;
            }

            result = null;
            return false;
        }

        private static bool TryConvertXPlicit(object value, Type destinationType, string operatorMethodName, out object result) {
            if (TryConvertXPlicit(value, value.GetType(), destinationType, operatorMethodName, out result)) {
                return true;
            }

            if (TryConvertXPlicit(value, destinationType, destinationType, operatorMethodName, out result)) {
                return true;
            }

            return false;
        }

        private static bool TryConvertXPlicit(object value, Type invokerType, Type destinationType, string xPlicitMethodName, out object result) {
            var methods = GetMethodsOf(invokerType).Where(method => method.IsPublic && method.IsStatic);
            foreach (var method in methods.Where(m => m.Name == xPlicitMethodName)) {
                if (IsAssignable(destinationType, method.ReturnType)) {
                    var parameters = method.GetParameters();
                    if (parameters.Length == 1 && parameters[0].ParameterType == value.GetType()) {
                        try {
                            result = method.Invoke(null, new[] {value});
                            return true;
                        } catch {
                        }
                    }
                }
            }

            result = null;
            return false;
        }

    }

}