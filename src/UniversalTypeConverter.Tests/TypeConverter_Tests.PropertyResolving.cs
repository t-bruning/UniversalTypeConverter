using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests
{

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Conversion_Should_Resolve_Property_By_Default() {
            var converter = new TypeConverter();
            converter.Options.PropertyResolvingMode.Should().Be(PropertyResolvingMode.Strict);

            var dummy = new PropertyResolvingDummy(4711);
            converter.ConvertTo<int>(dummy).Should().Be(4711);

            var timeSpan = new TimeSpan(200000);
            converter.ConvertTo<long>(timeSpan).Should().Be(200000);
        }

        [TestMethod]
        public void Conversion_Should_Not_Resolve_Property_If_Not_Allowed() {
            var converter = new TypeConverter();
            converter.Options.PropertyResolvingMode = PropertyResolvingMode.None;

            var dummy = new PropertyResolvingDummy(4711);
            Action action = () => converter.ConvertTo<int>(dummy);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void PropertyResolvingMode_Strict_Should_Be_Strict() {
            var converter = new TypeConverter();
            converter.Options.PropertyResolvingMode = PropertyResolvingMode.Strict;

            var dummy = new PropertyResolvingDummy(4711);
            converter.ConvertTo<int>(dummy).Should().Be(4711);

            Action action = () => converter.ConvertTo<long>(dummy);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void PropertyResolvingMode_Lax_Should_Be_Lax() {
            var converter = new TypeConverter();
            converter.Options.PropertyResolvingMode = PropertyResolvingMode.Lax;

            var dummy = new PropertyResolvingDummy(127);
            converter.ConvertTo<int>(dummy).Should().Be(127);

            converter.ConvertTo<byte>(dummy).Should().Be(127);
        }


        private class PropertyResolvingDummy {

            public int MyValue { get; }

            public PropertyResolvingDummy(int myValue) {
                MyValue = myValue;
            }

        }
    }
}
