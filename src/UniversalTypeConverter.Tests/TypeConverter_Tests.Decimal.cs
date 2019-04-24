using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests
{

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_Decimal_To_String_Should_Use_Given_Format() {
            var converter = new TypeConverter();
            var dec = 1234.56m;

            converter.ConvertTo<string>(dec).Should().Be(dec.ToString());

            converter.Options.DecimalFormat = "C";
            converter.ConvertTo<string>(dec).Should().Be(dec.ToString("C"));
        }

        [TestMethod]
        public void Convert_Decimal_To_String_Should_Use_The_Given_Culture() {
            var converter = new TypeConverter();
            var dec = 1234.56m;

            converter.DefaultCulture = new CultureInfo("de-DE");
            converter.ConvertTo<string>(dec).Should().Be(dec.ToString(new CultureInfo("de-DE")));

            converter.DefaultCulture = new CultureInfo("en-US");
            converter.ConvertTo<string>(dec).Should().Be(dec.ToString(new CultureInfo("en-US")));
        }
    }
}
