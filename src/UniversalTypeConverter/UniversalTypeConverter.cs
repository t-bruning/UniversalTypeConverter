// project  : UniversalTypeConverter
// file     : UniversalTypeConverter.cs
// author   : Thorsten Bruning
// date     : 2018-09-13 

using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UniversalTypeConverter.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100af0c32add957055314ccbee44e614656eb37656681e3fc572de6459dd386f682c33437ce0a5d073b089705a40bd9020fc1eda214e3368ff0f126aaa970c68bd0eda23d0b251fd91815155b6859bd069963528aa449a23fe9f7e33123b43f594113197ef02b0ec1fad21622f604340836c5e6f11088961cac0da8e83e73a1bf9d")]
namespace TB.ComponentModel {

    /// <summary>
    /// Defines the default type converter.
    /// </summary>
    public static class UniversalTypeConverter {

        internal static readonly TypeConverter Instance;

        /// <summary>
        /// Defines the culture which should be used for conversion by default.
        ///  Returns <see cref="CultureInfo.CurrentCulture"/> if not set or null.
        /// </summary>
        public static CultureInfo DefaultCulture {
            get => Instance.DefaultCulture;
            set => Instance.DefaultCulture = value;
        }

        /// <summary>
        /// Gets the
        /// collection of return values for conversions that convert from null.
        /// </summary>
        public static TypeValueDictionary NullValues => Instance.NullValues;

        /// <summary>
        /// Gets the list of mappings of specific source values to specific return values.
        ///  The list is implemented as 'Last In – First Out' (LIFO).
        /// </summary>
        public static ValueMappingCollection ValueMappings => Instance.ValueMappings;

        /// <summary>
        /// Gets the list of conversions used by this converter.
        /// </summary>
        public static ConversionCollection Conversions => Instance.Conversions;

        /// <summary>
        /// Gets the conversion options.
        /// </summary>
        public static ConversionOptions Options => Instance.Options;

        static UniversalTypeConverter() {
            Instance = new TypeConverter();
        }
        
    }

}