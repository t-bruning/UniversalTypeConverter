// project  : UniversalTypeConverter
// file     : ConversionArgs.cs
// author   : Thorsten Bruning
// date     : 2018-09-12 

using System;
using System.Globalization;

namespace TB.ComponentModel {

    /// <summary>
    /// Provides arguments for a type conversion.
    /// </summary>
    public class ConversionArgs {

        /// <summary>
        /// Gets the culture which should be used for conversion.
        /// </summary>
        public CultureInfo Culture { get; }

        /// <summary>
        /// Gets the <see cref="ITypeConverter"/> who initiated the conversion.
        /// </summary>
        public ITypeConverter Caller { get; }

        /// <summary>
        /// Gets the <see cref="IConversionOptions"/>.
        /// </summary>
        public IConversionOptions Options => Caller.Options;

        /// <summary>
        /// Instructs the <see cref="Caller"/> to ignore any following <see cref="ITypeConversion"/> by continuing with the result of the last call of <see cref="ITypeConversion.TryConvert"/>.
        ///  If the last call returned false, this means that conversion fails if no fallback option is set.
        /// </summary>
        public bool Break { get; set; }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="caller">The <see cref="ITypeConverter"/> who initiated the conversion.</param>
        /// <param name="culture">The culture which should be used for conversion.</param>
        public ConversionArgs(ITypeConverter caller, CultureInfo culture) {
            Caller = caller ?? throw new ArgumentNullException(nameof(caller));
            Culture = culture ?? throw new ArgumentNullException(nameof(culture));
        }

    }

}