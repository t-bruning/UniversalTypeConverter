using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    public partial class UniversalTypeConverter_Tests {

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Bool_WithValueFalse_ShouldThrowInvalidConversionException() {
            var value = false;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Bool_WithValueTrue_ShouldThrowInvalidConversionException() {
            var value = true;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableBool_WithValueFalse_ShouldThrowInvalidConversionException() {
            bool? value = false;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableBool_WithValueNull_ShouldReturn_Null() {
            bool? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableBool_WithValueTrue_ShouldThrowInvalidConversionException() {
            bool? value = true;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Byte_WithValue1_ShouldThrowInvalidConversionException() {
            byte value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableByte_WithValue1_ShouldThrowInvalidConversionException() {
            byte? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableByte_WithValueNull_ShouldReturn_Null() {
            byte? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Char_WithValue100_ShouldThrowInvalidConversionException() {
            var value = (char)100;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableChar_WithValue100_ShouldThrowInvalidConversionException() {
            char? value = (char)100;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableChar_WithValueNull_ShouldReturn_Null() {
            char? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableDateTime_WithValueNull_ShouldReturn_Null() {
            DateTime? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Decimal_WithValue1_ShouldThrowInvalidConversionException() {
            decimal value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableDecimal_WithValue1_ShouldThrowInvalidConversionException() {
            decimal? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableDecimal_WithValueNull_ShouldReturn_Null() {
            decimal? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableDouble_WithValueNull_ShouldReturn_Null() {
            double? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Float_WithValue1_ShouldThrowInvalidConversionException() {
            float value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableFloat_WithValue1_ShouldThrowInvalidConversionException() {
            float? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableFloat_WithValueNull_ShouldReturn_Null() {
            float? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Int_WithValue1_ShouldThrowInvalidConversionException() {
            var value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableInt_WithValue1_ShouldThrowInvalidConversionException() {
            int? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableInt_WithValueNull_ShouldReturn_Null() {
            int? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableLong_WithValueNull_ShouldReturn_Null() {
            long? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Object_WithValue1_ShouldThrowInvalidConversionException() {
            object value = "1";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Object_WithValueNull_ShouldReturn_Null() {
            object value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_SByte_WithValue1_ShouldThrowInvalidConversionException() {
            sbyte value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableSByte_WithValue1_ShouldThrowInvalidConversionException() {
            sbyte? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableSByte_WithValueNull_ShouldReturn_Null() {
            sbyte? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_Short_WithValue1_ShouldThrowInvalidConversionException() {
            short value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableShort_WithValue1_ShouldThrowInvalidConversionException() {
            short? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableShort_WithValueNull_ShouldReturn_Null() {
            short? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_String_WithValue1_ShouldThrowInvalidConversionException() {
            var value = "1";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_String_WithValueAbc_ShouldThrowInvalidConversionException() {
            var value = "abc";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_String_WithValueNull_ShouldReturn_Null() {
            string value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_UInt_WithValue1_ShouldThrowInvalidConversionException() {
            uint value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableUInt_WithValue1_ShouldThrowInvalidConversionException() {
            uint? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableUInt_WithValueNull_ShouldReturn_Null() {
            uint? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_ULong_WithValue1_ShouldThrowInvalidConversionException() {
            ulong value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableULong_WithValue1_ShouldThrowInvalidConversionException() {
            ulong? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableULong_WithValueNull_ShouldReturn_Null() {
            ulong? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_UShort_WithValue1_ShouldThrowInvalidConversionException() {
            ushort value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableUShort_WithValue1_ShouldThrowInvalidConversionException() {
            ushort? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_From_NullableUShort_WithValueNull_ShouldReturn_Null() {
            ushort? value = null;
            DateTime? expectedValue = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime?>(value).HasValue.Should().BeFalse();
        }

    }
}
