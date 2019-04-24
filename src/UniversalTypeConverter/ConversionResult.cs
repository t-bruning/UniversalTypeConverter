// project  : UniversalTypeConverter
// file     : ConversionResult.cs
// author   : Thorsten Bruning
// date     : 2019-03-12

using System;

namespace TB.ComponentModel {

    /// <summary>
    /// Represents the result of a conversion. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConversionResult<T> {

        private readonly T mValue;

        /// <summary>
        /// Indicates whether this result has a valid value.
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Gets the value of the conversion if succeeded.
        /// </summary>
        /// <exception cref="InvalidOperationException">The <see cref="HasValue"/> property is false.</exception>
        public T Value {
            get {
                if (HasValue) {
                    return mValue;
                }

                throw new InvalidOperationException("Conversion failed. Check HasValue before using getter.");
            }
        }

        /// <summary>
        /// Initializes a new instance that does not contain a value as a result of an unsuccessful conversion.
        /// </summary>
        public ConversionResult() {
        }

        /// <summary>
        /// Initializes a new instance that contains the specified value as the result of a successful conversion.
        /// </summary>
        /// <param name="value">The result of the conversion.</param>
        public ConversionResult(T value) {
            mValue = value;
            HasValue = true;
        }

        /// <summary>
        /// Returns <see cref="Value"/> if <see cref="HasValue"/> is true; otherwise the default value of the underlying type.
        /// </summary>
        /// <returns></returns>
        public T OrDefault() {
            return HasValue ? Value : default(T);
        }

        /// <summary>
        /// Returns <see cref="Value"/> if <see cref="HasValue"/> is true; otherwise the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Or(T value) {
            return HasValue ? Value : value;
        }

        /// <inheritdoc />
        public override string ToString() {
            return HasValue ? Value.ToString() : string.Empty;
        }

    }

}
