using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Globalization;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public class SystemTypeConverter_Tests {


        [TestMethod]
        public void Convert_By_TypeConverter_Should_Use_Underlying_Type_If_Destination_Is_Nullable() {
            var result = "1".To<TestEnum?>();
            result.Value.Should().Be(TestEnum.V1);
        }

        [TypeConverter(typeof(TestEnumTypeConverter))]
        private enum TestEnum {
            V1 = 0,
            V2
        }

        private class TestEnumTypeConverter : System.ComponentModel.TypeConverter {

            public override bool CanConvertFrom(ITypeDescriptorContext context, Type destinationType) {
                return destinationType == typeof(string);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
                switch ((string)value) {
                    case "1":
                        return TestEnum.V1;
                    case "2":
                        return TestEnum.V2;
                }

                throw new NotImplementedException();
            }

        }
    }
}
