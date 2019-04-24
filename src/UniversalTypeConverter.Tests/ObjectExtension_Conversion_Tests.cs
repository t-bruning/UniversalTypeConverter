using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    [TestClass]
    public class ObjectExtension_Conversion_Tests {

        [TestMethod]
        public void As_Result_Should_Contain_Converted_Value_On_Success() {
            var result = "1".As<int>(CultureInfo.CurrentCulture);
            result.HasValue.Should().BeTrue();
            result.Value.Should().Be(1);
        }

        [TestMethod]
        public void As_Result_Should_Not_Have_Value_If_Failed() {
            "x".As<int>(CultureInfo.CurrentCulture).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void IsConvertibleToT_Should_Execute() {
            "1".IsConvertibleTo<int>().Should().BeTrue();
        }

        [TestMethod]
        public void IsConvertibleToT_With_CultureInfo_Should_Execute() {
            1.23M.IsConvertibleTo<string>(CultureInfo.InvariantCulture).Should().BeTrue();
        }

        [TestMethod]
        public void ToT_Without_Parameters_Should_Execute() {
            "1".To<int>().Should().Be(1);
        }

        [TestMethod]
        public void ToT_With_CultureInfo_Should_Execute() {
            1.23M.To<string>(CultureInfo.InvariantCulture).Should().Be("1.23");
        }



        [TestMethod]
        public void IsConvertibleToT_With_Out_Parameter_Should_Execute() {
            "1".IsConvertibleTo(out int result).Should().BeTrue();
            result.Should().Be(1);
        }

        [TestMethod]
        public void IsConvertibleToT_With_Out_Parameter_And_With_CultureInfo_Should_Execute() {
            1.23M.IsConvertibleTo(out string result, CultureInfo.InvariantCulture).Should().BeTrue();
            result.Should().Be("1.23");
        }



        [TestMethod]
        public void To_Without_Parameters_Should_Execute() {
            "1".To(typeof(int)).Should().Be(1);
        }

        [TestMethod]
        public void To_With_CultureInfo_Should_Execute() {
            1.23M.To(typeof(string), CultureInfo.InvariantCulture).Should().Be("1.23");
        }



        [TestMethod]
        public void IsConvertibleTo_With_Out_Parameter_Should_Execute() {
            "1".IsConvertibleTo(typeof(int), out var result).Should().BeTrue();
            result.Should().Be(1);
        }

        [TestMethod]
        public void IsConvertibleTo_With_Out_Parameter_And_With_CultureInfo_Should_Execute() {
            1.23M.IsConvertibleTo(typeof(string), out var result, CultureInfo.InvariantCulture).Should().BeTrue();
            result.Should().Be("1.23");
        }



        [TestMethod]
        public void IsConvertibleTo_Should_Execute() {
            "1".IsConvertibleTo(typeof(int)).Should().BeTrue();
        }

        [TestMethod]
        public void IsConvertibleTo_With_CultureInfo_Should_Execute() {
            1.23M.IsConvertibleTo(typeof(string), CultureInfo.InvariantCulture).Should().BeTrue();
        }

        
    }
}
