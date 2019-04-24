using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    partial class TypeConverter_Tests {

        [TestMethod]
        public void ConvertTo_String_From_Enum_Should_Return_String() {
            new TypeConverter().ConvertTo<string>(SimpleTestEnum.Value1).Should().Be("Value1");
        }

        [TestMethod]
        public void ConvertTo_Enum_From_String_Should_Return_Enum() {
            new TypeConverter().ConvertTo<SimpleTestEnum>("Value1").Should().Be(SimpleTestEnum.Value1);
        }

        [TestMethod]
        public void ConvertTo_Int_From_Enum_Should_Return_Int() {
            new TypeConverter().ConvertTo<int>(SimpleTestEnum.Value1).Should().Be(1);
        }

        [TestMethod]
        public void ConvertTo_Enum_From_Int_Should_Return_Enum() {
            new TypeConverter().ConvertTo<SimpleTestEnum>(1).Should().Be(SimpleTestEnum.Value1);
        }

        [TestMethod]
        public void ConvertTo_Enum_From_Invalid_Value_Should_Throw_InvalidConversionException() {
            Action action = () => new TypeConverter().ConvertTo<SimpleTestEnum>(DateTime.Now);
            action.Should().Throw<InvalidConversionException>();
        }

    }
}
