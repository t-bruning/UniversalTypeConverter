// project  : UniversalTypeConverter
// file     : DataRowConversion.cs
// author   : Thorsten Bruning
// date     : 2019-04-08 

using System;
using System.Data;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for DataRows.
    /// </summary>
    public class DataRowConversion : TypeConversion<DataRow> {

        private readonly TypeConverter mConverter;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="converter"></param>
        public DataRowConversion(TypeConverter converter) {
            mConverter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        /// <inheritdoc />
        protected override bool TryConvert(DataRow row, Type destinationType, out object result, ConversionArgs args) {
            if (row == null) {
                result = null;
                return false;
            }

            var properties = row.ToDictionary();
            return mConverter.TryCreate(destinationType, properties, out result, args.Culture);
        }

    }

}