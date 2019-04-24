using System;

namespace TB.ComponentModel {

    /// <summary>
    /// Defines the mapping of specific source values to specific destination values.
    /// </summary>
    public interface IValueMapping {

        /// <summary>
        /// Get the source type.
        /// </summary>
        Type SourceType { get; }

        /// <summary>
        /// Gets the destination type.
        /// </summary>
        Type DestinationType { get; }

        /// <summary>
        /// Maps the specified source value to an instance of the specified destination type.
        /// </summary>
        /// <param name="sourceValue">The value to map.</param>
        /// <param name="destinationType">The destination type to map to.</param>
        /// <param name="destinationValue">An instance of the specified destination type if the mapping succeeded.</param>
        /// <returns>true if the mapping succeeded; otherwise, false.</returns>
        bool TryMap(object sourceValue, Type destinationType, out object destinationValue);

    }

}