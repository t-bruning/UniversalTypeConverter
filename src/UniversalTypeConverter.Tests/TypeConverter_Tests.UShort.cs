using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_UShort_To_String_Should_Use_Given_Format() {
            var converter = new TypeConverter();
            ushort value = 1234;

            converter.ConvertTo<string>(value).Should().Be(value.ToString());

            converter.Options.IntegerFormat = "N2";
            converter.ConvertTo<string>(value).Should().Be(value.ToString("N2"));
        }

        [TestMethod]
        public void Convert_UShort_To_String_Should_Use_The_Given_Culture() {
            var converter = new TypeConverter();
            ushort value = 1234;

            converter.Options.IntegerFormat = "N2";
            converter.DefaultCulture = new CultureInfo("de-DE");
            converter.ConvertTo<string>(value).Should().Be(value.ToString("N2", new CultureInfo("de-DE")));

            converter.DefaultCulture = new CultureInfo("en-US");
            converter.ConvertTo<string>(value).Should().Be(value.ToString("N2", new CultureInfo("en-US")));
        }

    }

}
