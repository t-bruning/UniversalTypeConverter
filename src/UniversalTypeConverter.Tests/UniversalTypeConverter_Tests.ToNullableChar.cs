using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    public partial class UniversalTypeConverter_Tests {

        #region [ ConvertTo<char?>() ]
        [TestMethod]
        public void ConvertTo_NullableChar_From_Bool_WithValueFalse_ShouldReturn_F() {
            var value = false;
            char? expectedValue = 'F';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Bool_WithValueTrue_ShouldReturn_T() {
            var value = true;
            char? expectedValue = 'T';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableBool_WithValueFalse_ShouldReturn_F() {
            bool? value = false;
            char? expectedValue = 'F';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableBool_WithValueNull_ShouldReturn_Null() {
            bool? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableBool_WithValueTrue_ShouldReturn_T() {
            bool? value = true;
            char? expectedValue = 'T';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Byte_WithValue1_ShouldReturn_1() {
            byte value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableByte_WithValue1_ShouldReturn_1() {
            byte? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableByte_WithValueNull_ShouldReturn_Null() {
            byte? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Char_WithValue100_ShouldReturn_100() {
            var value = (char)100;
            char? expectedValue = (char)100;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableChar_WithValue100_ShouldReturn_100() {
            char? value = (char)100;
            char? expectedValue = (char)100;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableChar_WithValueNull_ShouldReturn_Null() {
            char? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableDateTime_WithValueNull_ShouldReturn_Null() {
            DateTime? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Decimal_WithValue1_ShouldReturn_1() {
            decimal value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableDecimal_WithValue1_ShouldReturn_1() {
            decimal? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableDecimal_WithValueNull_ShouldReturn_Null() {
            decimal? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Double_WithValue1_ShouldReturn_1() {
            double value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableDouble_WithValue1_ShouldReturn_1() {
            double? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableDouble_WithValueNull_ShouldReturn_Null() {
            double? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Float_WithValue1_ShouldReturn_1() {
            float value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableFloat_WithValue1_ShouldReturn_1() {
            float? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableFloat_WithValueNull_ShouldReturn_Null() {
            float? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Int_WithValue1_ShouldReturn_1() {
            var value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableInt_WithValue1_ShouldReturn_1() {
            int? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableInt_WithValueNull_ShouldReturn_Null() {
            int? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Long_WithValue1_ShouldReturn_1() {
            long value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableLong_WithValue1_ShouldReturn_1() {
            long? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableLong_WithValueNull_ShouldReturn_Null() {
            long? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Object_WithValue1_ShouldReturn_1() {
            object value = "1";
            char? expectedValue = '1';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Object_WithValueNull_ShouldReturn_Null() {
            object value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_SByte_WithValue1_ShouldReturn_1() {
            sbyte value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableSByte_WithValue1_ShouldReturn_1() {
            sbyte? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableSByte_WithValueNull_ShouldReturn_Null() {
            sbyte? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_Short_WithValue1_ShouldReturn_1() {
            short value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableShort_WithValue1_ShouldReturn_1() {
            short? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableShort_WithValueNull_ShouldReturn_Null() {
            short? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_String_WithValue1_ShouldReturn_1() {
            var value = "1";
            char? expectedValue = '1';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_String_WithValueAbc_ShouldThrowInvalidConversionException() {
            var value = "abc";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_String_WithValueNull_ShouldReturn_Null() {
            string value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_UInt_WithValue1_ShouldReturn_1() {
            uint value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableUInt_WithValue1_ShouldReturn_1() {
            uint? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableUInt_WithValueNull_ShouldReturn_Null() {
            uint? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_ULong_WithValue1_ShouldReturn_1() {
            ulong value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableULong_WithValue1_ShouldReturn_1() {
            ulong? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableULong_WithValueNull_ShouldReturn_Null() {
            ulong? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_UShort_WithValue1_ShouldReturn_1() {
            ushort value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableUShort_WithValue1_ShouldReturn_1() {
            ushort? value = 1;
            char? expectedValue = (char)1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_NullableChar_From_NullableUShort_WithValueNull_ShouldReturn_Null() {
            ushort? value = null;
            char? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<char?>(value).HasValue.Should().BeFalse();
        }

        #endregion

    }
}
