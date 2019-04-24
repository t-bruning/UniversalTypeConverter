// project  : UniversalTypeConverter
// file     : NullValueDictionary.cs
// author   : Thorsten Bruning
// date     : 2018-09-19 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TB.ComponentModel {

    /// <summary>
    /// Represents a list of mappings of specific source values to specific return values.
    ///  The list is implemented as 'Last In – First Out' (LIFO).
    /// </summary>
    public class ValueMappingCollection : IEnumerable<IValueMapping> {

        private readonly List<IValueMapping> mMappings = new List<IValueMapping>();

        /// <summary>
        /// Removes all mappings.
        /// </summary>
        public void Clear() {
            mMappings.Clear();
        }

        /// <summary>
        /// Adds a new mapping for a value not null.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="sourceValue"></param>
        /// <param name="destinationValue"></param>
        /// <param name="sourceValueComparer"></param>
        /// <returns></returns>
        public IValueMapping Add<TSource, TDestination>(TSource sourceValue, TDestination destinationValue, IEqualityComparer<TSource> sourceValueComparer = null) {
            if (sourceValue == null) {
                throw new ArgumentNullException(nameof(sourceValue));
            }

            var mapping = new ValueMapping<TSource, TDestination>(sourceValue, sourceValueComparer, destinationValue);
            mMappings.Insert(0, mapping);
            return mapping;
        }

        //TODO Add overload with Func<TDestination> (for lazy loading)

        /// <summary>
        /// Removes all mappings with the given source type.
        /// </summary>
        public void RemoveSourceType<T>() {
            var mappings = mMappings.Where(m => m.SourceType == typeof(T)).ToList();
            mappings.ForEach(m => mMappings.Remove(m));
        }

        /// <summary>
        /// Removes all mappings with the given destination type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveDestinationType<T>() {
            var mappings = mMappings.Where(m => m.DestinationType == typeof(T)).ToList();
            mappings.ForEach(m => mMappings.Remove(m));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list of <see cref="IValueMapping"/>s.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IValueMapping> GetEnumerator() {
            return mMappings.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list of <see cref="IValueMapping"/>s.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Maps the specified source value to an instance of the specified destination type.
        /// </summary>
        /// <param name="sourceValue">The value to map.</param>
        /// <param name="destinationType">The destination type to map to.</param>
        /// <param name="destinationValue">An instance of the specified destination type if the mapping succeeded.</param>
        /// <returns>true if the mapping succeeded; otherwise, false.</returns>
        public bool TryMap(object sourceValue, Type destinationType, out object destinationValue) {
            foreach (var mapping in mMappings) {
                if (mapping.TryMap(sourceValue, destinationType, out destinationValue)) {
                    return true;
                }
            }

            destinationValue = null;
            return false;
        }
    }

}
