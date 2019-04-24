// project  : UniversalTypeConverter
// file     : InstantiationException.cs
// author   : Thorsten Bruning
// date     : 2019-04-09 

using System;

namespace TB.ComponentModel {

    /// <summary>
    /// The exception that is thrown when the instantiation of an object failed.
    /// </summary>
    public class InstantiationException : Exception {

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConversionException">InstantiationException</see> class.
        /// </summary>
        /// <param name="typeToInstantiate"></param>
        /// <param name="innerException"></param>
        public InstantiationException(Type typeToInstantiate, Exception innerException)
            : base($"Instantiation of {typeToInstantiate} failed:\n{innerException?.Message ?? "(no details)"}", innerException) {
        }

    }

}