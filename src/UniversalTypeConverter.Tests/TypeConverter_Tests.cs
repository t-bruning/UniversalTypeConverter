using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public partial class TypeConverter_Tests {

        [TestMethod]
        public void AllowDefaultValueIfWhitespace_Option_Should_Work_As_Expected() {
            var converter = new TypeConverter();
            converter.Options.AllowDefaultValueIfWhitespace.Should().BeFalse();

            Action action = () => converter.ConvertTo<int>(string.Empty);
            action.Should().Throw<InvalidConversionException>();

            converter.Options.AllowDefaultValueIfWhitespace = true;
            converter.ConvertTo<int>(string.Empty).Should().Be(0);
        }

        [TestMethod]
        public void AllowDefaultValueIfNotConvertible_Option_Should_Work_As_Expected() {
            var converter = new TypeConverter();
            converter.Options.AllowDefaultValueIfNotConvertible.Should().BeFalse();

            Action action = () => converter.ConvertTo<int>("a");
            action.Should().Throw<InvalidConversionException>();

            converter.Options.AllowDefaultValueIfNotConvertible = true;
            converter.ConvertTo<int>(string.Empty).Should().Be(0);
        }

    }

}
