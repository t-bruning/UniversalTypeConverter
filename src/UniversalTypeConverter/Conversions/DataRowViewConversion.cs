// project  : UniversalTypeConverter
// file     : DataRowViewConversion.cs
// author   : Thorsten Bruning
// date     : 2019-04-08 

using System;
using System.Data;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for DataRowViews.
    /// </summary>
    public class DataRowViewConversion : TypeConversion<DataRowView> {

        private readonly TypeConverter mConverter;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="converter"></param>
        public DataRowViewConversion(TypeConverter converter) {
            mConverter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        /// <inheritdoc />
        protected override bool TryConvert(DataRowView rowView, Type destinationType, out object result, ConversionArgs args) {
            if (rowView == null) {
                result = null;
                return false;
            }

            var properties = rowView.ToDictionary();
            return mConverter.TryCreate(destinationType, properties, out result, args.Culture);
        }

    }

}