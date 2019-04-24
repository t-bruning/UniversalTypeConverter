// project  : UniversalTypeConverter
// file     : DictionaryExtension.cs
// author   : Thorsten Bruning
// date     : 2019-04-09 

using System;
using System.Collections.Generic;
using System.Globalization;

namespace TB.ComponentModel {

    /// <summary>
    /// Provides extension methods for dictionaries.
    /// </summary>
    public static class DictionaryExtension {

        /// <summary>
        /// Creates a new instance of the given type by mapping the key value pairs of the given dictionary to constructor parameters, public properties and public fields of the given type.
        ///  The <see cref="UniversalTypeConverter">default converter</see> is used for conversion if needed.
        ///  Throws an <see cref="InstantiationException"/> if creation failed.
        ///  For success, at least on key value pair must be used as a constructor parameter, public property or public field.
        ///  If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="propertyValues">
        /// Values which are mapped to constructor parameters, public properties and public fields of the same name as their key.
        ///  Names are compared case insensitive. The constructor with most of the resolvable parameters is used.
        /// </param>
        /// <param name="culture">The culture to use on conversion. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="InstantiationException">InstantiationException if creation failed.</exception>
        public static T Create<T>(this IDictionary<string, object> propertyValues, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.Create<T>(propertyValues, culture);
        }

        /// <summary>
        /// Creates a new instance of the given type by mapping the key value pairs of the given dictionary to constructor parameters, public properties and public fields of the given type.
        ///  The <see cref="UniversalTypeConverter">default converter</see> is used for conversion if needed.
        ///  Throws an <see cref="InstantiationException"/> if creation failed.
        ///  For success, at least on key value pair must be used as a constructor parameter, public property or public field.
        ///  If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type.
        /// </summary>
        /// <param name="propertyValues">
        /// Values which are mapped to constructor parameters, public properties and public fields of the same name as their key.
        ///  Names are compared case insensitive. The constructor with most of the resolvable parameters is used.
        /// </param>
        /// <param name="destinationType">The type of the instance to create.</param>
        /// <param name="culture">The culture to use on conversion. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>The created instance.</returns>
        /// <exception cref="InstantiationException">InstantiationException if creation failed.</exception>
        public static object Create(this IDictionary<string, object> propertyValues, Type destinationType, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.Create(destinationType, propertyValues, culture);
        }

        /// <summary>
        /// Creates a new instance of the given type by mapping the key value pairs of the dictionary to constructor parameters, public properties and public fields of the given type.
        ///  The <see cref="UniversalTypeConverter">default converter</see> is used for conversion if needed.
        ///  Returns true if creation succeeded. For success, at least on key value pair must be used as a constructor parameter, public property or public field.
        ///  If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="propertyValues">
        /// Values which are mapped to constructor parameters, public properties and public fields of the same name as their key.
        ///  Names are compared case insensitive.
        ///  The constructor with most of the resolvable parameters is used.
        /// </param>
        /// <param name="newInstance">The created instance.</param>
        /// <param name="culture">The culture to use on conversion. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>True, if a new instance was created.</returns>
        public static bool TryCreate<T>(this IDictionary<string, object> propertyValues, out T newInstance, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.TryCreate(propertyValues, out newInstance, culture);
        }

        /// <summary>
        /// Creates a new instance of the given type by mapping the key value pairs of the dictionary to constructor parameters, public properties and public fields of the given type.
        ///  The <see cref="UniversalTypeConverter">default converter</see> is used for conversion if needed.
        ///  Returns true if creation succeeded. For success, at least on key value pair must be used as a constructor parameter, public property or public field.
        ///  If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type.
        /// </summary>
        /// <param name="propertyValues">
        /// Values which are mapped to constructor parameters, public properties and public fields of the same name as their key.
        ///  Names are compared case insensitive.
        ///  The constructor with most of the resolvable parameters is used.
        /// </param>
        /// /// <param name="destinationType">The type of the instance to create.</param>
        /// <param name="newInstance">The created instance.</param>
        /// <param name="culture">The culture to use on conversion. If not given or null, the <see cref="UniversalTypeConverter.DefaultCulture"/> is used.</param>
        /// <returns>True, if a new instance was created.</returns>
        public static bool TryCreate(this IDictionary<string, object> propertyValues, Type destinationType, out object newInstance, CultureInfo culture = null) {
            return UniversalTypeConverter.Instance.TryCreate(destinationType, propertyValues, out newInstance, culture);
        }

    }

}