// project  : UniversalTypeConverter
// file     : ConversionBase.cs
// author   : Thorsten Bruning
// date     : 2018-09-22 

using System;
using System.Collections.Generic;
using System.Reflection;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a base class for conversions.
    /// </summary>
    public abstract class ConversionBase : ITypeConversion {

        /// <inheritdoc />
        public abstract bool TryConvert(object value, Type destinationType, out object result, ConversionArgs args);

        /// <summary>
        /// Determines if the given type is is assignable from another type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="fromType"></param>
        /// <returns></returns>
        protected static bool IsAssignable(Type type, Type fromType) {
            return type.GetTypeInfo().IsAssignableFrom(fromType.GetTypeInfo());
        }

        /// <summary>
        /// Gets the collection of methods for the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static IEnumerable<MethodInfo> GetMethodsOf(Type type) {
            return type.GetTypeInfo().DeclaredMethods;
        }

        /// <summary>
        /// Determines if the given type is an Enum.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static bool IsEnum(Type type) {
            return type.GetTypeInfo().IsEnum;
        }

        /// <summary>
        /// Determines if the given type is an integer type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static bool IsInteger(Type type) {
            return type == typeof(byte)
                   || type == typeof(int)
                   || type == typeof(long)
                   || type == typeof(sbyte)
                   || type == typeof(short)
                   || type == typeof(uint)
                   || type == typeof(ulong)
                   || type == typeof(ushort);
        }

        /// <summary>
        /// Determines if the given type is an float type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static bool IsFloat(Type type) {
            return type == typeof(float)
                   || type == typeof(double);
        }
    }

}
