using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    public partial class UniversalTypeConverter_Tests {

        [TestMethod]
        public void ConvertTo_ULong_From_Bool_WithValueFalse_ShouldReturn_0() {
            var value = false;
            ulong expectedValue = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Bool_WithValueTrue_ShouldReturn_1() {
            var value = true;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableBool_WithValueFalse_ShouldReturn_0() {
            bool? value = false;
            ulong expectedValue = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableBool_WithValueNull_ShouldThrowInvalidConversionException() {
            bool? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableBool_WithValueTrue_ShouldReturn_1() {
            bool? value = true;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Byte_WithValue1_ShouldReturn_1() {
            byte value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableByte_WithValue1_ShouldReturn_1() {
            byte? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableByte_WithValueNull_ShouldThrowInvalidConversionException() {
            byte? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Char_WithValue100_ShouldReturn_100() {
            var value = (char)100;
            ulong expectedValue = 100;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableChar_WithValue100_ShouldReturn_100() {
            char? value = (char)100;
            ulong expectedValue = 100;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableChar_WithValueNull_ShouldThrowInvalidConversionException() {
            char? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableDateTime_WithValueNull_ShouldThrowInvalidConversionException() {
            DateTime? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Decimal_WithValue1_ShouldReturn_1() {
            decimal value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableDecimal_WithValue1_ShouldReturn_1() {
            decimal? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableDecimal_WithValueNull_ShouldThrowInvalidConversionException() {
            decimal? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Double_WithValue1_ShouldReturn_1() {
            double value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableDouble_WithValue1_ShouldReturn_1() {
            double? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableDouble_WithValueNull_ShouldThrowInvalidConversionException() {
            double? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Float_WithValue1_ShouldReturn_1() {
            float value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableFloat_WithValue1_ShouldReturn_1() {
            float? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableFloat_WithValueNull_ShouldThrowInvalidConversionException() {
            float? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Int_WithValue1_ShouldReturn_1() {
            var value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableInt_WithValue1_ShouldReturn_1() {
            int? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableInt_WithValueNull_ShouldThrowInvalidConversionException() {
            int? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Long_WithValue1_ShouldReturn_1() {
            long value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableLong_WithValue1_ShouldReturn_1() {
            long? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableLong_WithValueNull_ShouldThrowInvalidConversionException() {
            long? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Object_WithValue1_ShouldReturn_1() {
            object value = "1";
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Object_WithValueNull_ShouldThrowInvalidConversionException() {
            object value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_SByte_WithValue1_ShouldReturn_1() {
            sbyte value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableSByte_WithValue1_ShouldReturn_1() {
            sbyte? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableSByte_WithValueNull_ShouldThrowInvalidConversionException() {
            sbyte? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_Short_WithValue1_ShouldReturn_1() {
            short value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableShort_WithValue1_ShouldReturn_1() {
            short? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableShort_WithValueNull_ShouldThrowInvalidConversionException() {
            short? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_String_WithValue1_ShouldReturn_1() {
            var value = "1";
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_String_WithValueAbc_ShouldThrowInvalidConversionException() {
            var value = "abc";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_String_WithValueNull_ShouldThrowInvalidConversionException() {
            string value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_UInt_WithValue1_ShouldReturn_1() {
            uint value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableUInt_WithValue1_ShouldReturn_1() {
            uint? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableUInt_WithValueNull_ShouldThrowInvalidConversionException() {
            uint? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_ULong_WithValue1_ShouldReturn_1() {
            ulong value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableULong_WithValue1_ShouldReturn_1() {
            ulong? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableULong_WithValueNull_ShouldThrowInvalidConversionException() {
            ulong? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_ULong_From_UShort_WithValue1_ShouldReturn_1() {
            ushort value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableUShort_WithValue1_ShouldReturn_1() {
            ushort? value = 1;
            ulong expectedValue = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value).Should().Be(expectedValue);
        }

        [TestMethod]
        public void ConvertTo_ULong_From_NullableUShort_WithValueNull_ShouldThrowInvalidConversionException() {
            ushort? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<ulong>(value);
            action.Should().Throw<InvalidConversionException>();
        }

    }
}
