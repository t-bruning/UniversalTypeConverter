using System;
using System.Collections.Generic;

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the mapping of a specific source value.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public class ValueMapping<TSource, TDestination> : IValueMapping {
        
        private readonly IEqualityComparer<TSource> mSourceValueComparer;
        private readonly TDestination mDestinationValue;

        /// <summary>
        /// Gets the source value.
        /// </summary>
        public TSource SourceValue { get; }

        /// <summary>
        /// Get the source type.
        /// </summary>
        public Type SourceType { get; } = typeof(TSource);

        /// <summary>
        /// Gets the destination type.
        /// </summary>
        public Type DestinationType { get; } = typeof(TDestination);

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <param name="sourceValueComparer">Null or the comparer with wich values are compared to the source value.</param>
        /// <param name="destinationValue">The mapped destination value.</param>
        public ValueMapping(TSource sourceValue, IEqualityComparer<TSource> sourceValueComparer, TDestination destinationValue) {
            if (sourceValue == null) {
                throw new ArgumentNullException(nameof(sourceValue));
            }

            SourceValue = sourceValue;
            mSourceValueComparer = sourceValueComparer;
            mDestinationValue = destinationValue;
        }

        /// <inheritdoc />
        public bool TryMap(object sourceValue, Type destinationType, out object destinationValue) {
            if (sourceValue == null || destinationType == null) {
                destinationValue = null;
                return false;
            }

            if (destinationType != DestinationType) {
                destinationValue = null;
                return false;
            }

            if (!(sourceValue is TSource)) {
                destinationValue = null;
                return false;
            }

            if (mSourceValueComparer == null) {
                if (sourceValue.Equals(SourceValue)) {
                    destinationValue = mDestinationValue;
                    return true;
                }
            } else {
                if (mSourceValueComparer.Equals((TSource) sourceValue, SourceValue)) {
                    destinationValue = mDestinationValue;
                    return true;
                }
            }

            destinationValue = null;
            return false;
        }

    }

}