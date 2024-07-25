// project  : UniversalTypeConverter
// file     : ByteArrayConversion.cs
// author   : Thorsten Bruning
// date     : 2018-10-16 

using System;

namespace TB.ComponentModel.Conversions {

    /// <summary>
    /// Defines a conversion for array of bytes.
    /// </summary>
    public class ByteArrayConversion : TypeConversion<byte[]> {

        /// <inheritdoc />
        protected override bool TryConvert(byte[] value, Type destinationType, out object result, ConversionArgs args) {
            if (destinationType == typeof(string)) {
                switch (args.Options.ByteArrayFormat) {
                    case ByteArrayFormat.Base64:
                        try {
                            result = Convert.ToBase64String(value, Base64FormattingOptions.None);
                            return true;
                        } catch {
                            result = null;
                            return false;
                        }
                    case ByteArrayFormat.Base64WithLineBreaks:
                        try {
                            result = Convert.ToBase64String(value, Base64FormattingOptions.InsertLineBreaks);
                            return true;
                        } catch {
                            result = null;
                            return false;
                        }
                    case ByteArrayFormat.None:
                        args.Break = true;
                        result = null;
                        return false;
                }
            }

            if (destinationType == typeof(Guid)) {
                try {
                    result = new Guid(value);
                    return true;
                } catch {
                    result = null;
                    return false;
                }
            }

            result = null;
            return false;
        }

    }

}