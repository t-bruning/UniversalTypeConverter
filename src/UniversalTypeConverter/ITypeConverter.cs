// project  : UniversalTypeConverter
// file     : ITypeConverter.cs
// author   : Thorsten Bruning
// date     : 2018-09-12 

namespace TB.ComponentModel {

    /// <summary>
    /// Defines a type converter.
    /// </summary>
    public interface ITypeConverter : ITypeConversion {

        /// <summary>
        /// Gets the converion options.
        /// </summary>
        IConversionOptions Options { get; }

    }

}