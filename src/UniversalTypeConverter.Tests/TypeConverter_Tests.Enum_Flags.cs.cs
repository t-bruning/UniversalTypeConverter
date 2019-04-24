using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    partial class TypeConverter_Tests {

        [TestMethod]
        public void ConvertTo_String_From_FlagsEnum_Should_Return_String() {
            new TypeConverter().ConvertTo<string>(FlagsTestEnum.Value1 | FlagsTestEnum.Value4).Should().Be("Value1, Value4");
        }

        [TestMethod]
        public void ConvertTo_FlagsEnum_From_String_Should_Return_Enum() {
            new TypeConverter().ConvertTo<FlagsTestEnum>("Value1, Value4").Should().Be(FlagsTestEnum.Value1 | FlagsTestEnum.Value4);
        }

        [TestMethod]
        public void ConvertTo_Int_From_FlagsEnum_Should_Return_Int() {
            new TypeConverter().ConvertTo<int>(FlagsTestEnum.Value1 | FlagsTestEnum.Value4).Should().Be(5);
        }

        [TestMethod]
        public void ConvertTo_FlagsEnum_From_Int_Should_Return_Enum() {
            new TypeConverter().ConvertTo<FlagsTestEnum>(5).Should().Be(FlagsTestEnum.Value1 | FlagsTestEnum.Value4);
        }

    }
}
