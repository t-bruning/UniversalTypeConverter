using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_Guid_To_String_Should_Use_Given_Format() {
            var converter = new TypeConverter();
            var guid = Guid.NewGuid();

            converter.ConvertTo<string>(guid).Should().Be(guid.ToString());

            converter.Options.GuidFormat = "N";
            converter.ConvertTo<string>(guid).Should().Be(guid.ToString("N"));

            converter.Options.GuidFormat = "D";
            converter.ConvertTo<string>(guid).Should().Be(guid.ToString("D"));
        }

        [TestMethod]
        public void Convert_Guid_To_ByteArray_Should_Work() {
            var converter = new TypeConverter();
            var guid = Guid.NewGuid();
            var bytes = guid.ToByteArray();

            converter.ConvertTo<byte[]>(guid).Should().Equal(bytes);
        }

    }

}