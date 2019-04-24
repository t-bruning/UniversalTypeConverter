using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_ByteArray_To_String_Should_Use_Given_ByteArayFormat() {
            var array = new byte[] {12, 123, 0};
            var converter = new TypeConverter();
            converter.Options.ByteArrayFormat.Should().Be(ByteArrayFormat.Base64);

            converter.Options.ByteArrayFormat = ByteArrayFormat.Base64;
            converter.ConvertTo<string>(array).Should().Be(Convert.ToBase64String(array, Base64FormattingOptions.None));

            converter.Options.ByteArrayFormat = ByteArrayFormat.Base64WithLineBreaks;
            converter.ConvertTo<string>(array).Should().Be(Convert.ToBase64String(array, Base64FormattingOptions.InsertLineBreaks));

            converter.Options.ByteArrayFormat = ByteArrayFormat.None;
            Action action = () => converter.ConvertTo<string>(array);
            action.Should().Throw<InvalidConversionException>();
        }
    }

}
