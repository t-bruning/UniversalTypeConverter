using System;
using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests
{

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Conversion_Should_Use_IFormattable() {
            var converter = new TypeConverter();
            converter.DefaultCulture = new CultureInfo("de-DE");

            var formattable = new FormattableDummy();
            converter.ConvertTo<string>(formattable).Should().Be("de-DE");

            converter.DefaultCulture = new CultureInfo("en-US");
            converter.ConvertTo<string>(formattable).Should().Be("en-US");
        }

        private class FormattableDummy : IFormattable {

            /// <inheritdoc />
            public string ToString(string format, IFormatProvider formatProvider) {
                if (format != null) {
                    throw new ArgumentOutOfRangeException(nameof(format), "format should be null");
                }

                return formatProvider.ToString();
            }

        }
    }
}
