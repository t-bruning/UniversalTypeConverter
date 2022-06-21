using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_DateOnly_To_String_Should_Use_Given_Format() {
            var converter = new TypeConverter();
            var date = DateOnly.FromDateTime(DateTime.Today);

            converter.ConvertTo<string>(date).Should().Be(date.ToString());

            converter.Options.DateOnlyFormat = "D";
            converter.ConvertTo<string>(date).Should().Be(date.ToString("D"));
        }

        [TestMethod]
        public void Convert_DateOnly_To_String_Should_Use_The_Given_Culture() {
            var converter = new TypeConverter();
            var date = DateOnly.FromDateTime(DateTime.Today);

            converter.DefaultCulture = new CultureInfo("de-DE");
            converter.ConvertTo<string>(date).Should().Be(date.ToString(new CultureInfo("de-DE")));

            converter.DefaultCulture = new CultureInfo("en-US");
            converter.ConvertTo<string>(date).Should().Be(date.ToString(new CultureInfo("en-US")));
        }

        [TestMethod]
        public void Convert_DateOnly_To_DateTime_Should_Work_By_Default_Using_Midnight() {
            var converter = new TypeConverter();
            var date = DateOnly.FromDateTime(DateTime.Today);
            var dateTime = date.ToDateTime(new TimeOnly(0, 0, 0, 0));

            converter.ConvertTo<DateTime>(date).Should().Be(dateTime);
        }

        [TestMethod]
        public void Convert_DateOnly_To_DateTime_Should_Use_The_Given_DateOnlyDefaultTime() {
            var converter = new TypeConverter();
            var date = DateOnly.FromDateTime(DateTime.Today);

            converter.Options.DateOnlyDefaultTime = new TimeOnly(12, 0, 0);
            converter.ConvertTo<DateTime>(date).Should().Be(date.ToDateTime(new TimeOnly(12, 0, 0)));

            converter.Options.DateOnlyDefaultTime = new TimeOnly(18, 30, 0);
            converter.ConvertTo<DateTime>(date).Should().Be(date.ToDateTime(new TimeOnly(18, 30, 0)));
        }

    }
}
