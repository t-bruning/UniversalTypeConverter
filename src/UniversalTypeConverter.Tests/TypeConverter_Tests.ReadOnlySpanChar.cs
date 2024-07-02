using System;
using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_String_Should_Work() {
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<string>("Hello".AsSpan(0)).Should().Be("Hello");
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_Integers_Should_Use_Default_IntegerNumberStyle() {
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<byte>("0".AsSpan(0)).Should().Be(0);
            converter.ConvertTo<byte>(" 128 ".AsSpan(0)).Should().Be(128);
            converter.ConvertTo<byte>("+255 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(255);

            converter.ConvertTo<int>(" -2.147.483.648,00 ".AsSpan(0), new CultureInfo("de-de")).Should().Be(-2147483648);
            converter.ConvertTo<int>("2147483647 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(2147483647);
            converter.ConvertTo<int>("0".AsSpan(0)).Should().Be(0);

            converter.ConvertTo<long>("-9.223.372.036.854.775.808 ".AsSpan(0), new CultureInfo("de-de")).Should().Be(-9223372036854775808);
            converter.ConvertTo<long>("   9.223.372.036.854.775.807,0 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(9223372036854775807);

            converter.ConvertTo<sbyte>("-128".AsSpan(0)).Should().Be(-128);
            converter.ConvertTo<sbyte>("127 ".AsSpan(0)).Should().Be(127);

            converter.ConvertTo<short>("-32768,0  ".AsSpan(0), new CultureInfo("de-de")).Should().Be(-32768);
            converter.ConvertTo<short>("32767,00 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(32767);

            converter.ConvertTo<uint>(" 45678 ".AsSpan(0), new CultureInfo("de-de")).Should().Be(45678);
            converter.ConvertTo<uint>("4.294.967.295,0 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(4294967295);

            converter.ConvertTo<ulong>(" 45678 ".AsSpan(0), new CultureInfo("de-de")).Should().Be(45678);
            converter.ConvertTo<ulong>("18.446.744.073.709.551.615,0 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(18446744073709551615);

            converter.ConvertTo<ushort>(" 10.999 ".AsSpan(0), new CultureInfo("de-de")).Should().Be(10999);
            converter.ConvertTo<ushort>("65535,0 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(65535);
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_Decimal_Should_Use_Default_DecimalNumberStyle() {
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<decimal>("0,986-".AsSpan(0), new CultureInfo("de-de")).Should().Be(-0.986m);
            converter.ConvertTo<decimal>(" 128.645 ".AsSpan(0), new CultureInfo("de-de")).Should().Be(128645m);
            converter.ConvertTo<decimal>("+255 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(255);
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_Floats_Should_Use_Default_FloatNumberStyle() {
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<float>("-3,402823E38".AsSpan(0), new CultureInfo("de-de")).Should().Be(-3.402823E38f);
            converter.ConvertTo<float>(" 3,402823E38 ".AsSpan(0), new CultureInfo("de-de")).Should().Be(3.402823E38f);
            converter.ConvertTo<float>("+46 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(46);

            converter.ConvertTo<double>("-500.000.000".AsSpan(0), new CultureInfo("de-de")).Should().Be(-500000000);
            converter.ConvertTo<double>(" 500.000.000,00   ".AsSpan(0), new CultureInfo("de-de")).Should().Be(500000000);
            converter.ConvertTo<double>("+46 €".AsSpan(0), new CultureInfo("de-de")).Should().Be(46);
        }

        [TestMethod]
        public void Convert_HexReadOnlySpanChar_To_Integer_Should_Work_With_String_Fallback() {
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = true;
            converter.ConvertTo<int>("0xF".AsSpan(0)).Should().Be(15);
            converter.ConvertTo<byte>("&h7A".AsSpan(0)).Should().Be(122);
        }

        [TestMethod]
        public void Convert_HexReadOnlySpanChar_To_Integer_Should_Not_Work_Without_String_Fallback() {
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;
            Action action = () => converter.ConvertTo<int>("0xF".AsSpan(0));
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_DateTime_Should_Parse_Given_Culture() {
            var dateTime = new DateTime(2018, 10, 8, 19, 22, 3);
            var stringValue = dateTime.ToString(new CultureInfo("en-GB"));

            var converter = new TypeConverter(new CultureInfo("en-GB"));
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<DateTime>(stringValue.AsSpan(0)).Should().Be(dateTime);

            stringValue = dateTime.ToString(new CultureInfo("en-us"));
            converter.DefaultCulture = new CultureInfo("en-us");
            converter.ConvertTo<DateTime>(stringValue.AsSpan(0)).Should().Be(dateTime);
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_DateTime_Should_Parse_Given_Patterns() {
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<DateTime>("20181011".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11));
            converter.ConvertTo<DateTime>("201810112312".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11, 23, 12, 0));
            converter.ConvertTo<DateTime>("20181011231206".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11, 23, 12, 6));

            converter.ConvertTo<DateTime>("20181011 23:12".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11, 23, 12, 0));
            converter.ConvertTo<DateTime>("20181011 23:12:06".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11, 23, 12, 6));
            converter.ConvertTo<DateTime>("20181011 23:12:06.123".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11, 23, 12, 6, 123));

            converter.ConvertTo<DateTime>("2018-10-11".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11));
            converter.ConvertTo<DateTime>("2018-10-11 23:12".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11, 23, 12, 0));
            converter.ConvertTo<DateTime>("2018-10-11 23:12:06".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11, 23, 12, 6));
            converter.ConvertTo<DateTime>("2018-10-11 23:12:06.123".AsSpan(0)).Should().Be(new DateTime(2018, 10, 11, 23, 12, 6, 123));
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_DateOnly_Should_Parse_Given_Culture() {
            var date = new DateOnly(2018, 10, 8);

            var stringValue = date.ToString(new CultureInfo("en-GB"));
            var converter = new TypeConverter(new CultureInfo("en-GB"));
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<DateOnly>(stringValue.AsSpan(0)).Should().Be(date);

            stringValue = date.ToString(new CultureInfo("en-us"));
            converter.DefaultCulture = new CultureInfo("en-us");
            converter.ConvertTo<DateOnly>(stringValue.AsSpan(0)).Should().Be(date);
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_DateOnly_Should_Parse_Given_Patterns() {
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<DateOnly>("20181011".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));
            converter.ConvertTo<DateOnly>("201810112312".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));
            converter.ConvertTo<DateOnly>("20181011231206".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));

            converter.ConvertTo<DateOnly>("20181011 23:12".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));
            converter.ConvertTo<DateOnly>("20181011 23:12:06".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));
            converter.ConvertTo<DateOnly>("20181011 23:12:06.123".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));

            converter.ConvertTo<DateOnly>("2018-10-11".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));
            converter.ConvertTo<DateOnly>("2018-10-11 23:12".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));
            converter.ConvertTo<DateOnly>("2018-10-11 23:12:06".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));
            converter.ConvertTo<DateOnly>("2018-10-11 23:12:06.123".AsSpan(0)).Should().Be(new DateOnly(2018, 10, 11));
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_TimeOnly_Should_Parse_Given_Culture() {
            var time = new TimeOnly(12, 30);

            var stringValue = time.ToString(new CultureInfo("fi-FI"));
            var converter = new TypeConverter(new CultureInfo("fi-FI"));
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<TimeOnly>(stringValue.AsSpan(0)).Should().Be(time);

            stringValue = time.ToString(new CultureInfo("en-us"));
            converter.DefaultCulture = new CultureInfo("en-us");
            converter.ConvertTo<TimeOnly>(stringValue.AsSpan(0)).Should().Be(time);
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_TimeOnly_Should_Parse_Given_Patterns() {
            var converter = new TypeConverter();
            converter.DefaultCulture = new CultureInfo("fi-FI");
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<TimeOnly>("23:12".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 0));
            converter.ConvertTo<TimeOnly>("23:12:06".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 6));
            converter.ConvertTo<TimeOnly>("23:12:06.123".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 6, 123));

            converter.ConvertTo<TimeOnly>("23h 12".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 0));
            converter.ConvertTo<TimeOnly>("23 h 12".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 0));
            converter.ConvertTo<TimeOnly>("23h12".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 0));
            converter.ConvertTo<TimeOnly>("23h12m".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 0));
            converter.ConvertTo<TimeOnly>("23h12m24".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 24));
            converter.ConvertTo<TimeOnly>("23h12m24s".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 24));
            converter.ConvertTo<TimeOnly>("23h12m24.123".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 24, 123));
            converter.ConvertTo<TimeOnly>("23h12m24.123s".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 24, 123));


            converter.ConvertTo<TimeOnly>("23.12".AsSpan(0)).Should().Be(new TimeOnly(23, 12, 0));
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_Guid_Should_Parse_All_Default_Formats() {
            var guid = Guid.NewGuid();
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = false;

            converter.ConvertTo<Guid>(guid.ToString("N").AsSpan(0)).Should().Be(guid);
            converter.ConvertTo<Guid>(guid.ToString("D").AsSpan(0)).Should().Be(guid);
            converter.ConvertTo<Guid>(guid.ToString("B").AsSpan(0)).Should().Be(guid);
            converter.ConvertTo<Guid>(guid.ToString("P").AsSpan(0)).Should().Be(guid);
            converter.ConvertTo<Guid>(guid.ToString("X").AsSpan(0)).Should().Be(guid);
        }

        [TestMethod]
        public void Convert_ReadOnlySpanChar_To_ByteArray_Should_Use_Given_ByteArrayFormat_With_String_Fallback() {
            var array = new byte[] { 12, 123, 0 };
            var converter = new TypeConverter();
            converter.Options.AllowRetryWithStringIfCharSpanNotConvertible = true;

            converter.Options.ByteArrayFormat.Should().Be(ByteArrayFormat.Base64);

            converter.Options.ByteArrayFormat = ByteArrayFormat.Base64;
            converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.None).AsSpan(0)).Should().BeEquivalentTo(array);
            converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.InsertLineBreaks).AsSpan(0)).Should().BeEquivalentTo(array);

            converter.Options.ByteArrayFormat = ByteArrayFormat.Base64WithLineBreaks;
            converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.None).AsSpan(0)).Should().BeEquivalentTo(array);
            converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.InsertLineBreaks).AsSpan(0)).Should().BeEquivalentTo(array);

            converter.Options.ByteArrayFormat = ByteArrayFormat.None;
            Action action = () => converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.None).AsSpan(0));
            action.Should().Throw<InvalidConversionException>();
        }

    }

}