using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public class ConversionResult_Tests {

        [TestMethod]
        public void Result_With_Value_Should_Contain_Value() {
            var result = new ConversionResult<int>(1);
            result.HasValue.Should().BeTrue();
            result.Value.Should().Be(1);
        }

        [TestMethod]
        public void Result_With_Value_Should_Return_Value_Instead_Of_Default() {
            var result = new ConversionResult<int>(1);
            result.OrDefault().Should().Be(1);
            result.Or(2).Should().Be(1);
        }

        [TestMethod]
        public void Result_With_Value_Should_Be_Convertible_To_Underlying_Type() {
            var result = new ConversionResult<int>(1);
            result.To<int>().Should().Be(1);
        }

        [TestMethod]
        public void Result_Without_Value_Should_Not_Contain_Value() {
            var result = new ConversionResult<int>();
            result.HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void Result_Without_Value_Should_Throw_InvalidOperationException_On_Value_Access() {
            var result = new ConversionResult<int>();
            Action a = () => {
                var b = result.Value;
            };
            a.Should().Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void Result_Without_Value_Should_Return_Default() {
            var result = new ConversionResult<int>();
            result.OrDefault().Should().Be(0);
            result.Or(2).Should().Be(2);
        }

        [TestMethod]
        public void Result_Without_Value_Should_Not_Be_Convertible_To_Underlying_Type() {
            var result = new ConversionResult<int>();
            Action a = () => {
                var x = result.To<int>();
            };
            a.Should().Throw<InvalidConversionException>();
        }
    }

}
