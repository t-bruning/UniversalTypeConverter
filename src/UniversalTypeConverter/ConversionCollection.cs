// project  : UniversalTypeConverter
// file     : ConversionCollection.cs
// author   : Thorsten Bruning
// date     : 2018-09-12 

using System;
using System.Collections;
using System.Collections.Generic;

namespace TB.ComponentModel {

    /// <summary>
    /// Defines a list of conversions.
    /// </summary>
    public class ConversionCollection : IEnumerable<ITypeConversion> {

        private readonly List<ITypeConversion> mConversions = new List<ITypeConversion>();

        /// <summary>
        /// Adds the given conversion with the given priority.
        /// </summary>
        /// <param name="conversion">Conversion to add.</param>
        /// <param name="priority">Priority of the conversion to add.</param>
        /// <returns>This instance as part of a fluent interface.</returns>
        public ConversionCollection Add(ITypeConversion conversion, ConversionPriority priority) {
            if (conversion == null) {
                throw new ArgumentNullException(nameof(conversion));
            }

            if (priority == ConversionPriority.High) {
                mConversions.Insert(0, conversion);
            } else {
                mConversions.Add(conversion);
            }

            return this;
        }

        /// <inheritdoc />
        public IEnumerator<ITypeConversion> GetEnumerator() {
            return mConversions.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }

}