using System;
using System.Globalization;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_String_To_Integers_Should_Use_Default_IntegerNumberStyle() {
            var converter = new TypeConverter();
            converter.ConvertTo<byte>("0").Should().Be(0);
            converter.ConvertTo<byte>(" 128 ").Should().Be(128);
            converter.ConvertTo<byte>("+255 €", new CultureInfo("de-de")).Should().Be(255);

            converter.ConvertTo<int>(" -2.147.483.648,00 ", new CultureInfo("de-de")).Should().Be(-2147483648);
            converter.ConvertTo<int>("2147483647 €", new CultureInfo("de-de")).Should().Be(2147483647);
            converter.ConvertTo<int>("0").Should().Be(0);

            converter.ConvertTo<long>("-9.223.372.036.854.775.808 ", new CultureInfo("de-de")).Should().Be(-9223372036854775808);
            converter.ConvertTo<long>("   9.223.372.036.854.775.807,0 €", new CultureInfo("de-de")).Should().Be(9223372036854775807);

            converter.ConvertTo<sbyte>("-128").Should().Be(-128);
            converter.ConvertTo<sbyte>("127 ").Should().Be(127);

            converter.ConvertTo<short>("-32768,0  ", new CultureInfo("de-de")).Should().Be(-32768);
            converter.ConvertTo<short>("32767,00 €", new CultureInfo("de-de")).Should().Be(32767);

            converter.ConvertTo<uint>(" 45678 ", new CultureInfo("de-de")).Should().Be(45678);
            converter.ConvertTo<uint>("4.294.967.295,0 €", new CultureInfo("de-de")).Should().Be(4294967295);

            converter.ConvertTo<ulong>(" 45678 ", new CultureInfo("de-de")).Should().Be(45678);
            converter.ConvertTo<ulong>("18.446.744.073.709.551.615,0 €", new CultureInfo("de-de")).Should().Be(18446744073709551615);

            converter.ConvertTo<ushort>(" 10.999 ", new CultureInfo("de-de")).Should().Be(10999);
            converter.ConvertTo<ushort>("65535,0 €", new CultureInfo("de-de")).Should().Be(65535);
        }

        [TestMethod]
        public void Convert_String_To_Decimal_Should_Use_Default_DecimalNumberStyle() {
            var converter = new TypeConverter();
            converter.ConvertTo<decimal>("0,986-", new CultureInfo("de-de")).Should().Be(-0.986m);
            converter.ConvertTo<decimal>(" 128.645 ", new CultureInfo("de-de")).Should().Be(128645m);
            converter.ConvertTo<decimal>("+255 €", new CultureInfo("de-de")).Should().Be(255);
        }

        [TestMethod]
        public void Convert_String_To_Floats_Should_Use_Default_FloatNumberStyle() {
            var converter = new TypeConverter();
            converter.ConvertTo<float>("-3,402823E38", new CultureInfo("de-de")).Should().Be(-3.402823E38f);
            converter.ConvertTo<float>(" 3,402823E38 ", new CultureInfo("de-de")).Should().Be(3.402823E38f);
            converter.ConvertTo<float>("+46 €", new CultureInfo("de-de")).Should().Be(46);

            converter.ConvertTo<double>("-500.000.000", new CultureInfo("de-de")).Should().Be(-500000000);
            converter.ConvertTo<double>(" 500.000.000,00   ", new CultureInfo("de-de")).Should().Be(500000000);
            converter.ConvertTo<double>("+46 €", new CultureInfo("de-de")).Should().Be(46);
        }

        [TestMethod]
        public void Convert_HexString_To_Integer_Should_Work_By_Default() {
            var converter = new TypeConverter();
            converter.ConvertTo<int>("0xF").Should().Be(15);
            converter.ConvertTo<byte>("&h7A").Should().Be(122);
        }

        [TestMethod]
        public void Convert_String_To_DateTime_Should_Parse_Given_Culture() {
            var dateTime = new DateTime(2018, 10, 8, 19, 22, 3);
            var stringValue = dateTime.ToString(new CultureInfo("en-GB"));

            var converter = new TypeConverter(new CultureInfo("en-GB"));
            converter.ConvertTo<DateTime>(stringValue).Should().Be(dateTime);

            stringValue = dateTime.ToString(new CultureInfo("en-us"));
            converter.DefaultCulture = new CultureInfo("en-us");
            converter.ConvertTo<DateTime>(stringValue).Should().Be(dateTime);
        }

        [TestMethod]
        public void Convert_String_To_DateTime_Should_Parse_Given_Patterns() {
            var converter = new TypeConverter();

            converter.ConvertTo<DateTime>("20181011").Should().Be(new DateTime(2018, 10, 11));
            converter.ConvertTo<DateTime>("201810112312").Should().Be(new DateTime(2018, 10, 11, 23, 12, 0));
            converter.ConvertTo<DateTime>("20181011231206").Should().Be(new DateTime(2018, 10, 11, 23, 12, 6));
            converter.ConvertTo<DateTime>("20181011 23:12").Should().Be(new DateTime(2018, 10, 11, 23, 12, 0));
            converter.ConvertTo<DateTime>("20181011 23:12:06").Should().Be(new DateTime(2018, 10, 11, 23, 12, 6));

            converter.ConvertTo<DateTime>("2018-10-11").Should().Be(new DateTime(2018, 10, 11));
            converter.ConvertTo<DateTime>("2018-10-11 23:12").Should().Be(new DateTime(2018, 10, 11, 23, 12, 0));
            converter.ConvertTo<DateTime>("2018-10-11 23:12:06").Should().Be(new DateTime(2018, 10, 11, 23, 12, 6));

            converter.ConvertTo<DateTime>("2018-10-11").Should().Be(new DateTime(2018, 10, 11));
            converter.ConvertTo<DateTime>("2018-10-11 23:12").Should().Be(new DateTime(2018, 10, 11, 23, 12, 0));
            converter.ConvertTo<DateTime>("2018-10-11 23:12:06").Should().Be(new DateTime(2018, 10, 11, 23, 12, 6));
        }

        [TestMethod]
        public void Convert_String_To_Guid_Should_Parse_All_Default_Formats() {
            var guid = Guid.NewGuid();
            var converter = new TypeConverter();

            converter.ConvertTo<Guid>(guid.ToString("N")).Should().Be(guid);
            converter.ConvertTo<Guid>(guid.ToString("D")).Should().Be(guid);
            converter.ConvertTo<Guid>(guid.ToString("B")).Should().Be(guid);
            converter.ConvertTo<Guid>(guid.ToString("P")).Should().Be(guid);
            converter.ConvertTo<Guid>(guid.ToString("X")).Should().Be(guid);
        }

        [TestMethod]
        public void Convert_String_To_ByteArray_Should_Use_Given_ByteArayFormat() {
            var array = new byte[] {12, 123, 0};
            var converter = new TypeConverter();
            converter.Options.ByteArrayFormat.Should().Be(ByteArrayFormat.Base64);

            converter.Options.ByteArrayFormat = ByteArrayFormat.Base64;
            converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.None)).Should().BeEquivalentTo(array);
            converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.InsertLineBreaks)).Should().BeEquivalentTo(array);

            converter.Options.ByteArrayFormat = ByteArrayFormat.Base64WithLineBreaks;
            converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.None)).Should().BeEquivalentTo(array);
            converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.InsertLineBreaks)).Should().BeEquivalentTo(array);

            converter.Options.ByteArrayFormat = ByteArrayFormat.None;
            Action action = () => converter.ConvertTo<byte[]>(Convert.ToBase64String(array, Base64FormattingOptions.None));
            action.Should().Throw<InvalidConversionException>();
        }
    }

}
