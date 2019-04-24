using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    
    public partial class UniversalTypeConverter_Tests {

        [TestMethod]
        public void ConvertTo_NullableInt_From_Bool_WithValueFalse_ShouldReturn_0() {
            var value = false;
            int? expectedValue = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Bool_WithValueTrue_ShouldReturn_1() {
            var value = true;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableBool_WithValueFalse_ShouldReturn_0() {
            bool? value = false;
            int? expectedValue = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableBool_WithValueNull_ShouldReturn_Null() {
            bool? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableBool_WithValueTrue_ShouldReturn_1() {
            bool? value = true;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Byte_WithValue1_ShouldReturn_1() {
            byte value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableByte_WithValue1_ShouldReturn_1() {
            byte? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableByte_WithValueNull_ShouldReturn_Null() {
            byte? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Char_WithValue100_ShouldReturn_100() {
            var value = (char)100;
            int? expectedValue = 100;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableChar_WithValue100_ShouldReturn_100() {
            char? value = (char)100;
            int? expectedValue = 100;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableChar_WithValueNull_ShouldReturn_Null() {
            char? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableDateTime_WithValueNull_ShouldReturn_Null() {
            DateTime? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Decimal_WithValue1_ShouldReturn_1() {
            decimal value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableDecimal_WithValue1_ShouldReturn_1() {
            decimal? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableDecimal_WithValueNull_ShouldReturn_Null() {
            decimal? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Double_WithValue1_ShouldReturn_1() {
            double value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableDouble_WithValue1_ShouldReturn_1() {
            double? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableDouble_WithValueNull_ShouldReturn_Null() {
            double? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Float_WithValue1_ShouldReturn_1() {
            float value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableFloat_WithValue1_ShouldReturn_1() {
            float? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableFloat_WithValueNull_ShouldReturn_Null() {
            float? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Int_WithValue1_ShouldReturn_1() {
            var value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableInt_WithValue1_ShouldReturn_1() {
            int? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableInt_WithValueNull_ShouldReturn_Null() {
            int? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Long_WithValue1_ShouldReturn_1() {
            long value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableLong_WithValue1_ShouldReturn_1() {
            long? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableLong_WithValueNull_ShouldReturn_Null() {
            long? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Object_WithValue1_ShouldReturn_1() {
            object value = "1";
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Object_WithValueNull_ShouldReturn_Null() {
            object value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_SByte_WithValue1_ShouldReturn_1() {
            sbyte value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableSByte_WithValue1_ShouldReturn_1() {
            sbyte? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableSByte_WithValueNull_ShouldReturn_Null() {
            sbyte? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_Short_WithValue1_ShouldReturn_1() {
            short value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableShort_WithValue1_ShouldReturn_1() {
            short? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableShort_WithValueNull_ShouldReturn_Null() {
            short? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_String_WithValue1_ShouldReturn_1() {
            var value = "1";
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_String_WithValueAbc_ShouldThrowInvalidConversionException() {
            var value = "abc";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_String_WithValueNull_ShouldReturn_Null() {
            string value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_UInt_WithValue1_ShouldReturn_1() {
            uint value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableUInt_WithValue1_ShouldReturn_1() {
            uint? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableUInt_WithValueNull_ShouldReturn_Null() {
            uint? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_ULong_WithValue1_ShouldReturn_1() {
            ulong value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableULong_WithValue1_ShouldReturn_1() {
            ulong? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableULong_WithValueNull_ShouldReturn_Null() {
            ulong? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_UShort_WithValue1_ShouldReturn_1() {
            ushort value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableUShort_WithValue1_ShouldReturn_1() {
            ushort? value = 1;
            int? expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableInt_From_NullableUShort_WithValueNull_ShouldReturn_Null() {
            ushort? value = null;
            int? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<int?>(value).HasValue.Should().BeFalse();
        }
    }
}
