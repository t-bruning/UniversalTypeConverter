using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {
    public partial class UniversalTypeConverter_Tests {

        [TestMethod]
        public void ConvertTo_NullableBool_From_Bool_WithValueFalse_ShouldReturn_False() {
            var value = false;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Bool_WithValueTrue_ShouldReturn_True() {
            var value = true;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableBool_WithValueFalse_ShouldReturn_False() {
            bool? value = false;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableBool_WithValueNull_ShouldReturn_Null() {
            bool? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableBool_WithValueTrue_ShouldReturn_True() {
            bool? value = true;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Byte_WithValue0_ShouldReturn_False() {
            byte value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Byte_WithValue1_ShouldReturn_True() {
            byte value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableByte_WithValue0_ShouldReturn_False() {
            byte? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableByte_WithValue1_ShouldReturn_True() {
            byte? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableByte_WithValueNull_ShouldReturn_Null() {
            byte? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Char_WithValue0_ShouldReturn_False() {
            var value = '0';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Char_WithValue1_ShouldReturn_True() {
            var value = '1';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Char_WithValueF_ShouldReturn_False() {
            var value = 'F';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Char_WithValueJ_ShouldReturn_True() {
            var value = 'j';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Char_WithValueN_ShouldReturn_False() {
            var value = 'n';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Char_WithValueT_ShouldReturn_True() {
            var value = 'T';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Char_WithValueX_ShouldThrowInvalidConversionException() {
            var value = 'x';
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Char_WithValueY_ShouldReturn_True() {
            var value = 'y';
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableChar_WithValue100_ShouldThrowInvalidConversionException() {
            char? value = (char)100;
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableChar_WithValueNull_ShouldReturn_Null() {
            char? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableDateTime_WithValueNull_ShouldReturn_Null() {
            DateTime? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Decimal_WithValue0_ShouldReturn_False() {
            decimal value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Decimal_WithValue1_ShouldReturn_True() {
            decimal value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableDecimal_WithValue0_ShouldReturn_False() {
            decimal? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableDecimal_WithValue1_ShouldReturn_True() {
            decimal? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableDecimal_WithValueNull_ShouldReturn_Null() {
            decimal? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Double_WithValue0_ShouldReturn_False() {
            double value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Double_WithValue1_ShouldReturn_True() {
            double value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableDouble_WithValue0_ShouldReturn_False() {
            double? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableDouble_WithValue1_ShouldReturn_True() {
            double? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableDouble_WithValueNull_ShouldReturn_Null() {
            double? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Float_WithValue0_ShouldReturn_False() {
            float value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Float_WithValue1_ShouldReturn_True() {
            float value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableFloat_WithValue0_ShouldReturn_False() {
            float? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableFloat_WithValue1_ShouldReturn_True() {
            float? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableFloat_WithValueNull_ShouldReturn_Null() {
            float? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Int_WithValue0_ShouldReturn_False() {
            var value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Int_WithValue1_ShouldReturn_True() {
            var value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableInt_WithValue0_ShouldReturn_False() {
            int? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableInt_WithValue1_ShouldReturn_True() {
            int? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableInt_WithValueNull_ShouldReturn_Null() {
            int? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Long_WithValue0_ShouldReturn_False() {
            long value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Long_WithValue1_ShouldReturn_True() {
            long value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableLong_WithValue0_ShouldReturn_False() {
            long? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableLong_WithValue1_ShouldReturn_True() {
            long? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableLong_WithValueNull_ShouldReturn_Null() {
            long? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Object_WithValue1_ShouldReturn_True() {
            object value = "1";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Object_WithValueNull_ShouldReturn_Null() {
            object value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_SByte_WithValue0_ShouldReturn_False() {
            sbyte value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_SByte_WithValue1_ShouldReturn_True() {
            sbyte value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableSByte_WithValue0_ShouldReturn_False() {
            sbyte? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableSByte_WithValue1_ShouldReturn_True() {
            sbyte? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableSByte_WithValueNull_ShouldReturn_Null() {
            sbyte? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Short_WithValue0_ShouldReturn_False() {
            short value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_Short_WithValue1_ShouldReturn_True() {
            short value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableShort_WithValue0_ShouldReturn_False() {
            short? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableShort_WithValue1_ShouldReturn_True() {
            short? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableShort_WithValueNull_ShouldReturn_Null() {
            short? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValuePointfPoint_ShouldReturn_False() {
            var value = ".f.";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValuePointtPoint_ShouldReturn_True() {
            var value = ".t.";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValue0_ShouldReturn_False() {
            var value = "0";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValue1_ShouldReturn_True() {
            var value = "1";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueAbc_ShouldThrowInvalidConversionException() {
            var value = "abc";
            Action action = () => TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueF_ShouldReturn_False() {
            var value = "f";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueFalse_ShouldReturn_False() {
            var value = "false";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueJ_ShouldReturn_True() {
            var value = "j";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueJa_ShouldReturn_True() {
            var value = "ja";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueN_ShouldReturn_False() {
            var value = "n";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueNein_ShouldReturn_False() {
            var value = "nein";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueNo_ShouldReturn_False() {
            var value = "no";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueT_ShouldReturn_True() {
            var value = "t";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueTrue_ShouldReturn_True() {
            var value = "true";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueY_ShouldReturn_True() {
            var value = "y";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueYes_ShouldReturn_True() {
            var value = "yes";
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_String_WithValueNull_ShouldReturn_Null() {
            string value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_UInt_WithValue0_ShouldReturn_False() {
            uint value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_UInt_WithValue1_ShouldReturn_True() {
            uint value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableUInt_WithValue0_ShouldReturn_False() {
            uint? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableUInt_WithValue1_ShouldReturn_True() {
            uint? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableUInt_WithValueNull_ShouldReturn_Null() {
            uint? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_ULong_WithValue0_ShouldReturn_False() {
            ulong value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_ULong_WithValue1_ShouldReturn_True() {
            ulong value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableULong_WithValue0_ShouldReturn_False() {
            ulong? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableULong_WithValue1_ShouldReturn_True() {
            ulong? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableULong_WithValueNull_ShouldReturn_Null() {
            ulong? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_UShort_WithValue0_ShouldReturn_False() {
            ushort value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_UShort_WithValue1_ShouldReturn_True() {
            ushort value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableUShort_WithValue0_ShouldReturn_False() {
            ushort? value = 0;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableUShort_WithValue1_ShouldReturn_True() {
            ushort? value = 1;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).Should().BeTrue();
        }

        [TestMethod]
        public void ConvertTo_NullableBool_From_NullableUShort_WithValueNull_ShouldReturn_Null() {
            ushort? value = null;
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<bool?>(value).HasValue.Should().BeFalse();
        }

    }
}
