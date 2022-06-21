using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_DateTime_To_String_Should_Use_Given_Format() {
            var converter = new TypeConverter();
            var dateTime = DateTime.Now;

            converter.ConvertTo<string>(dateTime).Should().Be(dateTime.ToString());

            converter.Options.DateTimeFormat = "D";
            converter.ConvertTo<string>(dateTime).Should().Be(dateTime.ToString("D"));
        }

        [TestMethod]
        public void Convert_DateTime_To_String_Should_Use_The_Given_Culture() {
            var converter = new TypeConverter();
            var dateTime = DateTime.Now;

            converter.DefaultCulture = new CultureInfo("de-DE");
            converter.ConvertTo<string>(dateTime).Should().Be(dateTime.ToString(new CultureInfo("de-DE")));

            converter.DefaultCulture = new CultureInfo("en-US");
            converter.ConvertTo<string>(dateTime).Should().Be(dateTime.ToString(new CultureInfo("en-US")));
        }

        [TestMethod]
        public void Convert_DateTime_To_Double_Should_Return_OADate() {
            var converter = new TypeConverter();
            var dateTime = DateTime.Now;
            converter.ConvertTo<double>(dateTime).Should().Be(dateTime.ToOADate());
        }

        [TestMethod]
        public void Convert_DateTime_To_Long_Should_Assume_Ticks_By_Default() {
            var converter = new TypeConverter();
            var date = DateTime.Now;

            converter.Options.DateTimeLongMeaning.Should().Be(DateTimeLongMeaning.Ticks);
            converter.ConvertTo<long>(date).Should().Be(date.Ticks);
        }

        [TestMethod]
        public void Convert_DateTime_To_Long_Should_Use_Given_DateTimeLongMeaning() {
            var converter = new TypeConverter();
            var date = DateTime.Now;

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.Ticks;
            converter.ConvertTo<long>(date).Should().Be(date.Ticks);

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.Binary;
            converter.ConvertTo<long>(date).Should().Be(date.ToBinary());

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.FileTime;
            converter.ConvertTo<long>(date).Should().Be(date.ToFileTime());

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.FileTimeUtc;
            converter.ConvertTo<long>(date).Should().Be(date.ToFileTimeUtc());

            converter.Options.DateTimeLongMeaning = DateTimeLongMeaning.None;
            Action action = () => converter.ConvertTo<long>(date);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void Convert_DateTime_To_DateOnly_Should_Work_By_Default() {
            var converter = new TypeConverter();
            var dateTime = DateTime.Now;
            converter.ConvertTo<DateOnly>(dateTime).Should().Be(DateOnly.FromDateTime(dateTime));
        }

        [TestMethod]
        public void Convert_DateTime_To_TimeOnly_Should_Work_By_Default() {
            var converter = new TypeConverter();
            var dateTime = DateTime.Now;
            converter.ConvertTo<TimeOnly>(dateTime).Should().Be(TimeOnly.FromDateTime(dateTime));
        }
    }

}
