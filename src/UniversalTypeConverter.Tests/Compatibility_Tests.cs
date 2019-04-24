using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public class Compatibility_Tests {

        [TestMethod]
        public void CanConvertToT_Should_Execute() {
            "1".CanConvertTo<int>(CultureInfo.InvariantCulture).Should().BeTrue();
        }

        [TestMethod]
        public void TryConvertToT_With_Out_Parameter_Should_Execute() {
            "1".TryConvertTo(out int result, CultureInfo.InvariantCulture).Should().BeTrue();
            result.Should().Be(1);
        }

        [TestMethod]
        public void ConvertToT_With_CultureInfo_Should_Execute() {
            1.23M.ConvertTo<string>(CultureInfo.InvariantCulture).Should().Be("1.23");
        }

        [TestMethod]
        public void CanConvert_Should_Execute() {
            "1".CanConvert(typeof(int)).Should().BeTrue();
        }

        [TestMethod]
        public void TryConvert_With_Out_Parameter_Should_Execute() {
            "1".TryConvert(typeof(int), out var result).Should().BeTrue();
            result.Should().Be(1);
        }

        [TestMethod]
        public void Convert_With_CultureInfo_Should_Execute() {
            1.23M.Convert(typeof(string), CultureInfo.InvariantCulture).Should().Be("1.23");
        }

        [TestMethod]
        public void ConvertToEnumerableT_With_Enumerable_Should_Execute() {
            var input = new object[] {"1", "2"};
            input.ConvertToEnumerable<int>().Count().Should().Be(2);
        }

        [TestMethod]
        public void ConvertToEnumerable_With_Enumerable_Should_Execute() {
            var input = new object[] {"1", "2"};
            input.ConvertToEnumerable(typeof(int)).Count().Should().Be(2);
        }
    }

}