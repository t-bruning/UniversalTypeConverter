using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_TimeOnly_To_String_Should_Use_Given_Format() {
            var converter = new TypeConverter();
            var time = TimeOnly.FromDateTime(DateTime.Now);

            converter.ConvertTo<string>(time).Should().Be(time.ToString());

            converter.Options.TimeOnlyFormat = "T";
            converter.ConvertTo<string>(time).Should().Be(time.ToString("T"));
        }

        [TestMethod]
        public void Convert_TimeOnly_To_String_Should_Use_The_Given_Culture() {
            var converter = new TypeConverter();
            var time = TimeOnly.FromDateTime(DateTime.Now);

            converter.DefaultCulture = new CultureInfo("de-DE");
            converter.ConvertTo<string>(time).Should().Be(time.ToString(new CultureInfo("de-DE")));

            converter.DefaultCulture = new CultureInfo("en-US");
            converter.ConvertTo<string>(time).Should().Be(time.ToString(new CultureInfo("en-US")));

            converter.DefaultCulture = new CultureInfo("fi-FI");
            converter.ConvertTo<string>(time).Should().Be(time.ToString(new CultureInfo("fi-FI")));
        }

    }
}
