using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    public partial class UniversalTypeConverter_Tests {

        [TestMethod]
        public void ConvertTo_Bool_From_Bool_WithValueFalse_ShouldReturn_False() {
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(false).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Bool_WithValueTrue_ShouldReturn_True() {
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(true).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableBool_WithValueFalse_ShouldReturn_False() {
            bool? value = false;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableBool_WithValueNull_ShouldThrowInvalidConversionException() {
            bool? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableBool_WithValueTrue_ShouldReturn_True() {
            bool? value = true;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Byte_WithValue0_ShouldReturn_False() {
            byte value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Byte_WithValue1_ShouldReturn_True() {
            byte value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableByte_WithValue0_ShouldReturn_False() {
            byte? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableByte_WithValue1_ShouldReturn_True() {
            byte? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableByte_WithValueNull_ShouldThrowInvalidConversionException() {
            byte? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Char_WithValueX_ShouldThrowInvalidConversionException() {
            var value = 'x';
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableChar_WithValue100_ShouldThrowInvalidConversionException() {
            char? value = (char)100;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableChar_WithValueNull_ShouldThrowInvalidConversionException() {
            char? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableDateTime_WithValueNull_ShouldThrowInvalidConversionException() {
            DateTime? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Decimal_WithValue0_ShouldReturn_False() {
            decimal value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Decimal_WithValue1_ShouldReturn_True() {
            decimal value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableDecimal_WithValue0_ShouldReturn_False() {
            decimal? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableDecimal_WithValue1_ShouldReturn_True() {
            decimal? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableDecimal_WithValueNull_ShouldThrowInvalidConversionException() {
            decimal? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Double_WithValue0_ShouldReturn_False() {
            double value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Double_WithValue1_ShouldReturn_True() {
            double value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableDouble_WithValue0_ShouldReturn_False() {
            double? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableDouble_WithValue1_ShouldReturn_True() {
            double? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableDouble_WithValueNull_ShouldThrowInvalidConversionException() {
            double? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Float_WithValue0_ShouldReturn_False() {
            float value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Float_WithValue1_ShouldReturn_True() {
            float value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableFloat_WithValue0_ShouldReturn_False() {
            float? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableFloat_WithValue1_ShouldReturn_True() {
            float? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableFloat_WithValueNull_ShouldThrowInvalidConversionException() {
            float? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Int_WithValue0_ShouldReturn_False() {
            var value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Int_WithValue1_ShouldReturn_True() {
            var value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Int_Should_Return_True_If_Not_0() {
            var value = 2;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableInt_WithValue0_ShouldReturn_False() {
            int? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableInt_WithValue1_ShouldReturn_True() {
            int? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableInt_WithValueNull_ShouldThrowInvalidConversionException() {
            int? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Long_WithValue0_ShouldReturn_False() {
            long value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Long_WithValue1_ShouldReturn_True() {
            long value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableLong_WithValue0_ShouldReturn_False() {
            long? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableLong_WithValue1_ShouldReturn_True() {
            long? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableLong_WithValueNull_ShouldThrowInvalidConversionException() {
            long? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Object_WithValueNull_ShouldThrowInvalidConversionException() {
            object value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_SByte_WithValue0_ShouldReturn_False() {
            sbyte value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_SByte_WithValue1_ShouldReturn_True() {
            sbyte value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableSByte_WithValue0_ShouldReturn_False() {
            sbyte? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableSByte_WithValue1_ShouldReturn_True() {
            sbyte? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableSByte_WithValueNull_ShouldThrowInvalidConversionException() {
            sbyte? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Short_WithValue0_ShouldReturn_False() {
            short value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_Short_WithValue1_ShouldReturn_True() {
            short value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableShort_WithValue0_ShouldReturn_False() {
            short? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableShort_WithValue1_ShouldReturn_True() {
            short? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableShort_WithValueNull_ShouldThrowInvalidConversionException() {
            short? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_String_WithValueAbc_ShouldThrowInvalidConversionException() {
            var value = "abc";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_String_WithValueNull_ShouldThrowInvalidConversionException() {
            string value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_UInt_WithValue0_ShouldReturn_False() {
            uint value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_UInt_WithValue1_ShouldReturn_True() {
            uint value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableUInt_WithValue0_ShouldReturn_False() {
            uint? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableUInt_WithValue1_ShouldReturn_True() {
            uint? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableUInt_WithValueNull_ShouldThrowInvalidConversionException() {
            uint? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_ULong_WithValue0_ShouldReturn_False() {
            ulong value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_ULong_WithValue1_ShouldReturn_True() {
            ulong value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableULong_WithValue0_ShouldReturn_False() {
            ulong? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableULong_WithValue1_ShouldReturn_True() {
            ulong? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableULong_WithValueNull_ShouldThrowInvalidConversionException() {
            ulong? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_UShort_WithValue0_ShouldReturn_False() {
            ushort value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_UShort_WithValue1_ShouldReturn_True() {
            ushort value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableUShort_WithValue0_ShouldReturn_False() {
            ushort? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableUShort_WithValue1_ShouldReturn_True() {
            ushort? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_Bool_From_NullableUShort_WithValueNull_ShouldThrowInvalidConversionException() {
            ushort? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool>(value);
            action.Should().Throw<InvalidConversionException>();
        }

    }
}
