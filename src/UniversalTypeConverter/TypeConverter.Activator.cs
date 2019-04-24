// project  : UniversalTypeConverter
// file     : TypeConverterActivator.cs
// author   : Thorsten Bruning
// date     : 2019-04-03 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using TB.ComponentModel.Reflection;

namespace TB.ComponentModel {

    public partial class TypeConverter {

        /// <summary>
        /// Creates a new instance of the given type by mapping the key value pairs of the given dictionary to constructor parameters, public properties and public fields of the given type.
        ///  Throws an <see cref="InstantiationException"/> if creation failed.
        ///  For success, at least on key value pair must be used as a constructor parameter, public property or public field.
        ///  If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="propertyValues">
        /// Values which are mapped to constructor parameters, public properties and public fields of the same name as their key.
        ///  Names are compared case insensitive. The constructor with most of the resolvable parameters is used.
        /// </param>
        /// <param name="culture">The culture to use on conversion. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="InstantiationException">InstantiationException if creation failed.</exception>
        public T Create<T>(IDictionary<string, object> propertyValues, CultureInfo culture = null) {
            var typeOfT = typeof(T);
            if (TryCreate(typeOfT, propertyValues, culture, out var newInstance, out var exception)) {
                return (T) newInstance;
            }

            throw new InstantiationException(typeOfT, exception);
        }

        /// <summary>
        /// Creates a new instance of the given type by mapping the key value pairs of the given dictionary to constructor parameters, public properties and public fields of the given type.
        ///  Throws an <see cref="InstantiationException"/> if creation failed.
        ///  For success, at least on key value pair must be used as a constructor parameter, public property or public field.
        ///  If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type.
        /// </summary>
        /// <param name="destinationType">The type of the instance to create.</param>
        /// <param name="propertyValues">
        /// Values which are mapped to constructor parameters, public properties and public fields of the same name as their key.
        ///  Names are compared case insensitive. The constructor with most of the resolvable parameters is used.
        /// </param>
        /// <param name="culture">The culture to use on conversion. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="InstantiationException">InstantiationException if creation failed.</exception>
        public object Create(Type destinationType, IDictionary<string, object> propertyValues, CultureInfo culture = null) {
            if (TryCreate(destinationType, propertyValues, culture, out var newInstance, out var exception)) {
                return newInstance;
            }

            throw new InstantiationException(destinationType, exception);
        }

        /// <summary>
        /// Creates a new instance of the given type by mapping the key value pairs of the given dictionary to constructor parameters, public properties and public fields of the given type.
        ///  Returns true if creation succeeded. For success, at least on key value pair must be used as a constructor parameter, public property or public field.
        ///  If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="propertyValues">
        /// Values which are mapped to constructor parameters, public properties and public fields of the same name as their key.
        ///  Names are compared case insensitive. The constructor with most of the resolvable parameters is used.
        /// </param>
        /// <param name="newInstance">The created instance.</param>
        /// <param name="culture">The culture to use on conversion. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>True, if a new instance was created.</returns>
        public bool TryCreate<T>(IDictionary<string, object> propertyValues, out T newInstance, CultureInfo culture = null) {
            var typeOfT = typeof(T);
            if (TryCreate(typeOfT, propertyValues, out var result, culture)) {
                newInstance = (T) result;
                return true;
            }

            newInstance = (T) typeOfT.DefaultValue();
            return false;
        }

        /// <summary>
        /// Creates a new instance of the given type by mapping the key value pairs of the given dictionary to constructor parameters, public properties and public fields of the given type.
        ///  Returns true if creation succeeded. For success, at least on key value pair must be used as a constructor parameter, public property or public field.
        ///  If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type.
        /// </summary>
        /// <param name="destinationType">The type of the instance to create.</param>
        /// <param name="propertyValues">
        /// Values which are mapped to constructor parameters, public properties and public fields of the same name as their key.
        ///  Names are compared case insensitive. The constructor with most of the resolvable parameters is used.
        /// </param>
        /// <param name="newInstance">The created instance.</param>
        /// <param name="culture">The culture to use on conversion. If not given or null, the <see cref="DefaultCulture"/> is used.</param>
        /// <returns>True, if a new instance was created.</returns>
        public bool TryCreate(Type destinationType, IDictionary<string, object> propertyValues, out object newInstance, CultureInfo culture = null) {
            return TryCreate(destinationType, propertyValues, culture, out newInstance, out _);
        }

        private bool TryCreate(Type destinationType, IDictionary<string, object> propertyValues, CultureInfo culture, out object newInstance, out Exception exception) {
            if (propertyValues == null || propertyValues.Count == 0) {
                newInstance = destinationType.DefaultValue();
                exception = new InvalidOperationException("The property value dictionary is null or empty.");
                return false;
            }

            if (destinationType.IsPrimitive) {
                if (propertyValues.Count == 1) {
                    if (TryConvert(propertyValues.Values.First(), destinationType, out newInstance, culture)) {
                        exception = null;
                        return true;
                    }

                    exception = new InvalidConversionException(propertyValues.Values.First(), destinationType);
                    return false;
                }

                newInstance = destinationType.DefaultValue();
                exception = new InvalidOperationException($"More than one value was given but {destinationType} is primitive and needs exactly one property value.");
                return false;
            }

            Dictionary<string, object> ciDictionary;
            if (propertyValues is Dictionary<string, object> pvDic
                &&
                (Equals(pvDic.Comparer, StringComparer.OrdinalIgnoreCase)
                 || Equals(pvDic.Comparer, StringComparer.CurrentCultureIgnoreCase)
                 || Equals(pvDic.Comparer, StringComparer.InvariantCultureIgnoreCase))) {
                ciDictionary = pvDic;
            } else {
                ciDictionary = new Dictionary<string, object>(propertyValues, StringComparer.OrdinalIgnoreCase);
            }

            foreach (var constructor in destinationType.GetConstructors().OrderByDescending(c => c.GetParameters().Length)) {
                if (!TryFitPropertiesToConstructorParameters(ciDictionary, constructor, culture, out var parameterValues)) {
                    continue;
                }

                try {
                    newInstance = InvokeConstructor(constructor, parameterValues);
                } catch (Exception e) {
                    newInstance = destinationType.DefaultValue();
                    exception = e;
                    return false;
                }

                if (!TrySetFields(newInstance, destinationType, ciDictionary, culture, out var usedFieldCount, out var ex)) {
                    exception = ex;
                    return false;
                }

                if (!TrySetProperties(newInstance, destinationType, ciDictionary, culture, out var usedPropertyCount, out ex)) {
                    exception = ex;
                    return false;
                }

                if (parameterValues.Length > 0 || usedFieldCount > 0 || usedPropertyCount > 0) {
                    exception = null;
                    return true;
                }
            }

            if (ciDictionary.Count > 1) {
                newInstance = destinationType.DefaultValue();
                exception = new InvalidOperationException("No constructor parameter, field or property corresponds to any of the given key value pairs.");
                return false;
            }

            var value = ciDictionary.Values.First();
            if (value == null) {
                newInstance = destinationType.DefaultValue();
                exception = new InvalidOperationException("No constructor parameter, field or property corresponds to any of the given key value pairs.");
                return false;
            }

            if (value.GetType() == destinationType) {
                newInstance = value;
                exception = null;
                return true;
            }

            newInstance = destinationType.DefaultValue();
            exception = new InvalidOperationException("No constructor parameter, field or property corresponds to any of the given key value pairs.");
            return false;
        }

        private bool TryFitPropertiesToConstructorParameters(IReadOnlyDictionary<string, object> propertyValues, ConstructorInfo constructor, CultureInfo culture, out object[] parameterValues) {
            var parameters = constructor.GetParameters();
            parameterValues = new object[parameters.Length];
            if (parameters.Length == 0) {
                return true;
            }

            var index = 0;
            foreach (var parameter in parameters) {
                if (!propertyValues.TryGetValue(parameter.Name, out var value)) {
                    return false;
                }

                if (!TryConvert(value, parameter.ParameterType, out var result, culture)) {
                    return false;
                }

                parameterValues[index] = result;
                index++;
            }

            return true;
        }

        private static object InvokeConstructor(ConstructorInfo constructor, object[] parameterValues) {
            if (parameterValues.Length == 0) {
                return constructor.Invoke(null);
            }

            return constructor.Invoke(parameterValues);
        }

        private bool TrySetFields(object entity, IReflect entityType, IReadOnlyDictionary<string, object> fieldValues, CultureInfo culture, out int usedCount, out Exception exception) {
            usedCount = 0;
            foreach (var field in entityType.GetFields(BindingFlags.Instance | BindingFlags.Public)) {
                if (!fieldValues.TryGetValue(field.Name, out var propertyValue)) {
                    continue;
                }

                if (!TryConvert(propertyValue, field.FieldType, out var result, culture)) {
                    continue;
                }

                try {
                    field.SetValue(entity, result);
                } catch (Exception e) {
                    exception = e;
                    return false;
                }

                usedCount++;
            }

            exception = null;
            return true;
        }

        private bool TrySetProperties(object entity, IReflect entityType, IReadOnlyDictionary<string, object> propertyValues, CultureInfo culture, out int usedCount, out Exception exception) {
            usedCount = 0;
            foreach (var property in entityType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanWrite)) {
                if (!propertyValues.TryGetValue(property.Name, out var propertyValue)) {
                    continue;
                }

                if (!TryConvert(propertyValue, property.PropertyType, out var result, culture)) {
                    continue;
                }

                if (property.GetSetMethod() == null) {
                    // read only
                    continue;
                }

                try {
                    property.SetValue(entity, result, null);
                } catch (Exception e) {
                    exception = e;
                    return false;
                }

                usedCount++;
            }

            exception = null;
            return true;
        }

    }

}