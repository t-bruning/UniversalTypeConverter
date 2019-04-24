// project  : UniversalTypeConverter
// file     : DataRecordConversion.cs
// author   : Thorsten Bruning
// date     : 2019-04-08 

using System;
using System.Data;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for IDataRecords.
    /// </summary>
    public class DataRecordConversion : TypeConversion<IDataRecord> {

        private readonly TypeConverter mConverter;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="converter"></param>
        public DataRecordConversion(TypeConverter converter) {
            mConverter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        /// <inheritdoc />
        protected override bool TryConvert(IDataRecord record, Type destinationType, out object result, ConversionArgs args) {
            if (record == null) {
                result = null;
                return false;
            }

            var properties = record.ToDictionary();
            return mConverter.TryCreate(destinationType, properties, out result, args.Culture);
        }

    }

}