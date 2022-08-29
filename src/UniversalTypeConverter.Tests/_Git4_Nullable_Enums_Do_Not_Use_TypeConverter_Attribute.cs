using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace UniversalTypeConverter.Tests;

[TestClass]
public class _Git4_Nullable_Enums_Do_Not_Use_TypeConverter_Attribute {

    // Test/demo related to: https://github.com/t-bruning/UniversalTypeConverter/issues/4

    [TestMethod]
    public void _Git4_Nullable_Enums_Do_Not_Use_TypeConverter_Attribute_Solution() {
        "OTHER".To(typeof(TestEnum?)).Should().Be(TestEnum.Other); // works as expected

        "".To(typeof(TestEnum?)).Should().BeNull(); // returns null because of the default NullableConverter (https://source.dot.net/#System.ComponentModel.TypeConverter/System/ComponentModel/NullableConverter.cs,0107a64f3a234d90)

        // use your own value mapping in order to handle the empty string:
        TestEnum? myDefault = TestEnum.General;
        var converter = new TB.ComponentModel.TypeConverter();
        converter.ValueMappings.Add(string.Empty, myDefault);
        converter.Convert("", typeof(TestEnum?)).Should().Be(TestEnum.General);

        // remarks: you don't have to instantiate a new converter, you can add your mapping in general:
        // TB.ComponentModel.UniversalTypeConverter.ValueMappings.Add(string.Empty, myDefault);
    }

    [TypeConverter(typeof(StringEnumTypeConverter))]
    private enum TestEnum {

        [System.ComponentModel.Description("")]
        General = 1,

        [System.ComponentModel.Description("OTHER")]
        Other = 2

    }

    private class StringEnumTypeConverter : EnumConverter {

        public StringEnumTypeConverter(Type type)
            : base(type) {
        }

        /// <inheritdoc />
        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) {
            if (destinationType != typeof(string)) {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            var fieldInfo = value?.GetType().GetField(value.ToString() ?? throw new InvalidOperationException());
            var attribute = fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault() as DescriptionAttribute;

            return attribute is null || string.IsNullOrEmpty(attribute.Description)
                ? value?.ToString()
                : attribute.Description;
        }

        /// <inheritdoc />
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) {
            return value is string stringValue ? EnumFromDescription.GetEnum(stringValue, EnumType) : base.ConvertFrom(context, culture, value);
        }

        private static class EnumFromDescription {

            public static TEnum? GetEnum<TEnum>(string? description) {
                return (TEnum?)GetEnum(description, typeof(TEnum));
            }

            public static object? GetEnum(string? description, Type enumType) {
                if (description == null) {
                    return null;
                }

                if (!enumType.IsEnum) {
                    throw new InvalidOperationException("Type must be an enum");
                }

                var values = Enum.GetValues(enumType);

                foreach (var value in values) {
                    var enumName = Enum.GetName(enumType, value);
                    if (enumName == null) {
                        throw new NullReferenceException("Could not get enum name");
                    }

                    var memberinfos = enumType.GetMember(enumName);
                    var memberinfo = memberinfos?.FirstOrDefault(m => m.DeclaringType == enumType);
                    var attributes = memberinfo?.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    var attributedescription = ((DescriptionAttribute?)attributes?[0])?.Description;

                    if (attributedescription == null) {
                        throw new NullReferenceException("Unable to get description from enum");
                    }

                    if (attributedescription.Equals(description, StringComparison.OrdinalIgnoreCase)) {
                        return value;
                    }
                }

                return default;
            }

        }

    }

}