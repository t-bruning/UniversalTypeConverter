using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    public partial class UniversalTypeConverter_Tests {

        [TestMethod]
        public void ConvertTo_DateTime_From_Bool_WithValueFalse_ShouldThrowInvalidConversionException() {
            var value = false;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Bool_WithValueTrue_ShouldThrowInvalidConversionException() {
            var value = true;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableBool_WithValueFalse_ShouldThrowInvalidConversionException() {
            bool? value = false;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableBool_WithValueNull_ShouldThrowInvalidConversionException() {
            bool? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableBool_WithValueTrue_ShouldThrowInvalidConversionException() {
            bool? value = true;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Byte_WithValue1_ShouldThrowInvalidConversionException() {
            byte value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableByte_WithValue1_ShouldThrowInvalidConversionException() {
            byte? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableByte_WithValueNull_ShouldThrowInvalidConversionException() {
            byte? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Char_WithValue100_ShouldThrowInvalidConversionException() {
            var value = (char)100;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableChar_WithValue100_ShouldThrowInvalidConversionException() {
            char? value = (char)100;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableChar_WithValueNull_ShouldThrowInvalidConversionException() {
            char? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableDateTime_WithValueNull_ShouldThrowInvalidConversionException() {
            DateTime? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Decimal_WithValue1_ShouldThrowInvalidConversionException() {
            decimal value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableDecimal_WithValue1_ShouldThrowInvalidConversionException() {
            decimal? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableDecimal_WithValueNull_ShouldThrowInvalidConversionException() {
            decimal? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableDouble_WithValueNull_ShouldThrowInvalidConversionException() {
            double? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Float_WithValue1_ShouldThrowInvalidConversionException() {
            float value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableFloat_WithValue1_ShouldThrowInvalidConversionException() {
            float? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableFloat_WithValueNull_ShouldThrowInvalidConversionException() {
            float? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Int_WithValue1_ShouldThrowInvalidConversionException() {
            var value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableInt_WithValue1_ShouldThrowInvalidConversionException() {
            int? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableInt_WithValueNull_ShouldThrowInvalidConversionException() {
            int? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableLong_WithValueNull_ShouldThrowInvalidConversionException() {
            long? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Object_WithValue1_ShouldThrowInvalidConversionException() {
            object value = "1";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Object_WithValueNull_ShouldThrowInvalidConversionException() {
            object value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_SByte_WithValue1_ShouldThrowInvalidConversionException() {
            sbyte value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableSByte_WithValue1_ShouldThrowInvalidConversionException() {
            sbyte? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableSByte_WithValueNull_ShouldThrowInvalidConversionException() {
            sbyte? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_Short_WithValue1_ShouldThrowInvalidConversionException() {
            short value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableShort_WithValue1_ShouldThrowInvalidConversionException() {
            short? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableShort_WithValueNull_ShouldThrowInvalidConversionException() {
            short? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_String_WithValue1_ShouldThrowInvalidConversionException() {
            var value = "1";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_String_WithValueAbc_ShouldThrowInvalidConversionException() {
            var value = "abc";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_String_WithValueNull_ShouldThrowInvalidConversionException() {
            string value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_UInt_WithValue1_ShouldThrowInvalidConversionException() {
            uint value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableUInt_WithValue1_ShouldThrowInvalidConversionException() {
            uint? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableUInt_WithValueNull_ShouldThrowInvalidConversionException() {
            uint? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_ULong_WithValue1_ShouldThrowInvalidConversionException() {
            ulong value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableULong_WithValue1_ShouldThrowInvalidConversionException() {
            ulong? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableULong_WithValueNull_ShouldThrowInvalidConversionException() {
            ulong? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_UShort_WithValue1_ShouldThrowInvalidConversionException() {
            ushort value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableUShort_WithValue1_ShouldThrowInvalidConversionException() {
            ushort? value = 1;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_DateTime_From_NullableUShort_WithValueNull_ShouldThrowInvalidConversionException() {
            ushort? value = null;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<DateTime>(value);
            action.Should().Throw<InvalidConversionException>();
        }

    }
}
