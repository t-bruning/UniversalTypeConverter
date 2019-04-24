using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_Long_To_String_Should_Use_Given_Format() {
            var converter = new TypeConverter();
            long value = 1234;

            converter.ConvertTo<string>(value).Should().Be(value.ToString());

            converter.Options.IntegerFormat = "N2";
            converter.ConvertTo<string>(value).Should().Be(value.ToString("N2"));
        }

        [TestMethod]
        public void Convert_Long_To_String_Should_Use_The_Given_Culture() {
            var converter = new TypeConverter();
            long value = 1234;

            converter.Options.IntegerFormat = "N2";
            converter.DefaultCulture = new CultureInfo("de-DE");
            converter.ConvertTo<string>(value).Should().Be(value.ToString("N2", new CultureInfo("de-DE")));

            converter.DefaultCulture = new CultureInfo("en-US");
            converter.ConvertTo<string>(value).Should().Be(value.ToString("N2", new CultureInfo("en-US")));
        }

        [TestMethod]
        public void Convert_Long_To_DateTime_Should_Assume_Ticks_By_Default() {
            var converter = new TypeConverter();
            var date = DateTime.Now;

            converter.Options.DateTimeLongMeaning.Should().Be(DateTimeLongMeaning.Ticks);
            converter.ConvertTo<DateTime>(date.Ticks).Should().Be(date);
        }

        [TestMethod]
        public void Convert_Long_To_DateTime_Should_Use_Given_DateTimeLongMeaning() {
            var converter = new TypeConverter();
            var date = DateTime.Now;

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.Ticks;
            converter.ConvertTo<DateTime>(date.Ticks).Should().Be(date);

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.Binary;
            converter.ConvertTo<DateTime>(date.ToBinary()).Should().Be(date);

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.FileTime;
            converter.ConvertTo<DateTime>(date.ToFileTime()).Should().Be(date);

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.FileTimeUtc;
            converter.ConvertTo<DateTime>(date.ToFileTimeUtc()).Should().Be(date.ToUniversalTime());

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.None;
            Action action = () => converter.ConvertTo<DateTime>(date.Ticks);
            action.Should().Throw<InvalidConversionException>();
        }
    }

}
