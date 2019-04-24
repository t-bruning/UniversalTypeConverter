// project  : UniversalTypeConverter
// file     : TypeExtension.cs
// author   : Thorsten Bruning
// date     : 2019-03-21 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TB.ComponentModel.Reflection {

    internal static class TypeExtension {

        private static readonly Dictionary<Type, bool> DataTableCompatibleTypes;

        static TypeExtension() {
            DataTableCompatibleTypes = new Dictionary<Type, bool> {
                {typeof(bool), false},
                {typeof(bool?), true},
                {typeof(byte), false},
                {typeof(byte?), true},
                {typeof(char), false},
                {typeof(char?), true},
                {typeof(DateTime), false},
                {typeof(DateTime?), true},
                {typeof(decimal), false},
                {typeof(decimal?), true},
                {typeof(double), false},
                {typeof(double?), true},
                {typeof(Guid), false},
                {typeof(Guid?), true},
                {typeof(short), false},
                {typeof(short?), true},
                {typeof(int), false},
                {typeof(int?), true},
                {typeof(long), false},
                {typeof(long?), true},
                {typeof(sbyte), false},
                {typeof(sbyte?), true},
                {typeof(float), false},
                {typeof(float?), true},
                {typeof(string), true},
                {typeof(TimeSpan), false},
                {typeof(TimeSpan?), true},
                {typeof(ushort), false},
                {typeof(ushort?), true},
                {typeof(uint), false},
                {typeof(uint?), true},
                {typeof(ulong), false},
                {typeof(ulong?), true},
                {typeof(byte[]), true}
            };
        }

        public static object DefaultValue(this Type type) {
            // ValueTypes always have a parameterless constructor.
            // The default value of other types is always null.
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsValueType ? Activator.CreateInstance(typeInfo.AsType()) : null;
        }

        public static List<Getter> GetGetters(this Type type) {
            var getters = new List<Getter>();
            if (type == null) {
                return getters;
            }

            foreach (var fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public)) {
                getters.Add(new FieldGetter(fieldInfo));
            }

            foreach (var propertyInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanRead)) {
                var getter = propertyInfo.GetGetMethod();
                if (getter != null) {
                    getters.Add(new PropertyGetter(propertyInfo));
                }
            }

            return getters;
        }

        public static bool IsDataTableCompatible(this Type type, out Type columnDataType, out bool allowDBNull) {
            if (type == null) {
                throw new ArgumentNullException(nameof(type));
            }

            if (DataTableCompatibleTypes.TryGetValue(type, out allowDBNull)) {
                if (allowDBNull && type.IsGenericNullable()) {
                    columnDataType = type.GetUnderlyingType();
                } else {
                    columnDataType = type;
                }

                return true;
            }

            columnDataType = null;
            allowDBNull = true;
            return false;
        }

        public static bool IsGenericNullable(this Type type) {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>).GetGenericTypeDefinition();
        }

        public static Type GetUnderlyingType(this Type type) {
            return Nullable.GetUnderlyingType(type);
        }

        private class FieldGetter : Getter {

            private readonly FieldInfo mFieldInfo;

            /// <inheritdoc />
            public FieldGetter(FieldInfo fieldInfo)
                : base(fieldInfo.Name, fieldInfo.FieldType) {
                mFieldInfo = fieldInfo;
            }

            /// <inheritdoc />
            public override object GetValue(object obj) {
                return mFieldInfo.GetValue(obj);
            }

        }

        private class PropertyGetter : Getter {

            private readonly PropertyInfo mPropertyInfo;

            /// <inheritdoc />
            public PropertyGetter(PropertyInfo propertyInfo)
                : base(propertyInfo.Name, propertyInfo.PropertyType) {
                mPropertyInfo = propertyInfo;
            }

            /// <inheritdoc />
            public override object GetValue(object obj) {
                return mPropertyInfo.GetValue(obj);
            }

        }
    }

}