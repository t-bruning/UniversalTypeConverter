// project  : UniversalTypeConverter
// file     : EnumerableConversion.cs
// author   : Thorsten Bruning
// date     : 2018-09-22 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace TB.ComponentModel {


    /// <summary>
    /// Controls the iteration over the result of converting a list of values.
    /// </summary>
    /// <typeparam name="T">The type to which the elements of the source are converted.</typeparam>
    public class EnumerableConversion<T> : IEnumerable<T> {

        private readonly IEnumerable mValuesToConvert;
        private readonly Type mDestinationType = typeof(T);
        private readonly TypeConverter mConverter;
        private readonly CultureInfo mCulture;
        private bool mIgnoreNullElements;
        private bool mIgnoreNonConvertibleElements;

        internal EnumerableConversion(IEnumerable values, Type destinationType, TypeConverter converter, CultureInfo culture)
            : this(values, converter, culture) {
            mDestinationType = destinationType;
        }

        internal EnumerableConversion(IEnumerable values, TypeConverter converter, CultureInfo culture) {
            mValuesToConvert = values;
            mConverter = converter;
            mCulture = culture;
        }

        /// <summary>
        /// Instructs the enumerator to ignore non convertible values without throwing an exception.
        /// </summary>
        /// <returns>This instance as part of a fluent interface.</returns>
        public EnumerableConversion<T> IgnoringNonConvertibleElements() {
            mIgnoreNonConvertibleElements = true;
            return this;
        }

        /// <summary>
        /// Instructs the enumerator to ignore null values.
        /// </summary>
        /// <returns>This instance as part of a fluent interface.</returns>
        public EnumerableConversion<T> IgnoringNullElements() {
            mIgnoreNullElements = true;
            return this;
        }

        /// <summary>
        /// Returns the collection of converted values.
        ///  A return value indicates whether conversion of all values succeeded.
        /// </summary>
        /// <param name="result">The collection of converted values if conversion of all values succeeded.</param>
        /// <returns>true if conversion of all values succeeded; otherwise, false.</returns>
        public bool Try(out Collection<T> result) {
            result = new Collection<T>();
            try {
                foreach (var value in this) {
                    result.Add(value);
                }

                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of converted values.
        /// </summary>
        /// <returns>Enumerator that iterates through the collection of converted values.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of converted values.
        /// </summary>
        /// <returns>Enumerator that iterates through the collection of converted values.</returns>
        public IEnumerator<T> GetEnumerator() {
            foreach (var value in mValuesToConvert) {
                if (value == null && mIgnoreNullElements) {
                    continue;
                }

                if (!mConverter.TryConvert(value, mDestinationType, out var convertedValue, mCulture)) {
                    if (mIgnoreNonConvertibleElements) {
                        continue;
                    }

                    throw new InvalidConversionException(value, mDestinationType);
                }

                yield return (T) convertedValue;
            }
        }

    }

}
