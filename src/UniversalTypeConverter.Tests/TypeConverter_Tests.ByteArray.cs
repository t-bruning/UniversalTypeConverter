using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_ByteArray_To_String_Should_Use_Given_ByteArrayFormat() {
            var bytes = new byte[] { 12, 123, 0 };
            var converter = new TypeConverter();
            converter.Options.ByteArrayFormat.Should().Be(ByteArrayFormat.Base64);

            converter.Options.ByteArrayFormat = ByteArrayFormat.Base64;
            converter.ConvertTo<string>(bytes).Should().Be(Convert.ToBase64String(bytes, Base64FormattingOptions.None));

            converter.Options.ByteArrayFormat = ByteArrayFormat.Base64WithLineBreaks;
            converter.ConvertTo<string>(bytes).Should().Be(Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks));

            converter.Options.ByteArrayFormat = ByteArrayFormat.None;
            Action action = () => converter.ConvertTo<string>(bytes);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void Convert_ByteArray_To_Guid_Should_Work() {
            var guid = Guid.NewGuid();
            var bytes = guid.ToByteArray();
            var converter = new TypeConverter();

            converter.ConvertTo<Guid>(bytes).Should().Be(guid);
        }

    }

}