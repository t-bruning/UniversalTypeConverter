// project  : UniversalTypeConverter
// file     : Getter.cs
// author   : Thorsten Bruning
// date     : 2019-03-20 

using System;

namespace TB.ComponentModel.Reflection {

    internal abstract class Getter {

        public string Name { get; }

        public Type ValueType { get; }

        protected Getter(string name, Type valueType) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentOutOfRangeException(nameof(name));
            }

            Name = name;
            ValueType = valueType ?? throw new ArgumentNullException(nameof(valueType));
        }

        public abstract object GetValue(object obj);

        /// <inheritdoc />
        public override string ToString() {
            return Name;
        }

    }
    
}