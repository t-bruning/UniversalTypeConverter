// project  : UniversalTypeConverter
// file     : TypeValueDictionary.cs
// author   : Thorsten Bruning
// date     : 2018-09-19 

using System;
using System.Collections.Generic;

namespace TB.ComponentModel {

    /// <summary>
    /// Represents a collection of pairs of types and their default return values.
    /// </summary>
    public class TypeValueDictionary {

        private readonly Dictionary<Type, Func<object>> mValues = new Dictionary<Type, Func<object>>();

        /// <summary>
        /// Adds the <paramref name="value">specified value</paramref> as a return value for <typeparamref name="TDestination"/>.
        ///  This operation overwrites previous declarations for this type, if any.
        /// </summary>
        /// <typeparam name="TDestination">The destination type of conversion.</typeparam>
        /// <param name="value">The value.</param>
        public void Add<TDestination>(TDestination value) {
            mValues[typeof(TDestination)] = () => value;
        }

        /// <summary>
        /// Adds the <paramref name="getValue">specified function</paramref> as the provider for a return value for conversions that convert to <typeparamref name="TDestination"/>.
        ///  This operation overwrites previous declarations for this type, if any.
        /// </summary>
        /// <typeparam name="TDestination">The destination type of conversion.</typeparam>
        /// <param name="getValue">The func to get the value.</param>
        public void Add<TDestination>(Func<TDestination> getValue) {
            if (getValue == null) {
                throw new ArgumentNullException(nameof(getValue));
            }

            mValues[typeof(TDestination)] = () => getValue();
        }

        /// <summary>
        /// Adds the <paramref name="value">specified value</paramref> as a return value for conversions that convert to <paramref name="destinationType"/>.
        ///  This operation overwrites previous declarations for this type, if any.
        /// </summary>
        /// <param name="destinationType">The destination type of conversion.</param>
        /// <param name="value">The value.</param>
        public void Add(Type destinationType, object value) {
            if (destinationType == null) {
                throw new ArgumentNullException(nameof(destinationType));
            }

            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.GetType() != destinationType) {
                throw new ArgumentOutOfRangeException(nameof(value), "nullValue.GetType() != destinationType");
            }

            mValues[destinationType] = () => value;
        }

        /// <summary>
        /// Gets the value associated with the specified destination type. 
        /// </summary>
        /// <param name="destinationType"></param>
        /// <param name="value">Contains the value associated with the specified destination type, if defined.</param>
        /// <returns>true if a value is defined; otherwise, false.</returns>
        public bool TryGet(Type destinationType, out object value) {
            if (mValues.TryGetValue(destinationType, out var get)) {
                value = get();
                return true;
            }

            value = null;
            return false;
        }

    }

}
