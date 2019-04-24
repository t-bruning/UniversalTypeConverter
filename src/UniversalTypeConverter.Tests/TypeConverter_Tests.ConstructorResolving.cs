using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests
{

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Conversion_Should_Resolve_Constructor_By_Default() {
            var converter = new TypeConverter();
            converter.Options.ConstructorResolvingMode.Should().Be(ConstructorResolvingMode.Strict);
            converter.ConvertTo<ConstructorResolvingDummy>(123).MyValue.Should().Be(123);
        }

        [TestMethod]
        public void Conversion_Should_Not_Resolve_Constructor_If_Not_Allowed() {
            var converter = new TypeConverter();
            converter.Options.ConstructorResolvingMode = ConstructorResolvingMode.None;
            Action action = () => converter.ConvertTo<ConstructorResolvingDummy>(123);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConstructorResolvingMode_Strict_Should_Be_Strict() {
            var converter = new TypeConverter();
            converter.Options.ConstructorResolvingMode = ConstructorResolvingMode.Strict;

            converter.ConvertTo<ConstructorResolvingDummy>(123).MyValue.Should().Be(123);

            byte b = 123;
            Action action = () => converter.ConvertTo<ConstructorResolvingDummy>(b);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConstructorResolvingMode_Lax_Should_Be_Lax() {
            var converter = new TypeConverter();
            converter.Options.ConstructorResolvingMode = ConstructorResolvingMode.Lax;

            converter.ConvertTo<ConstructorResolvingDummy>(123).MyValue.Should().Be(123);

            byte b = 123;
            converter.ConvertTo<ConstructorResolvingDummy>(b).MyValue.Should().Be(123);
        }
        

        private class ConstructorResolvingDummy {

            public int MyValue { get; }

            public ConstructorResolvingDummy(int myValue) {
                MyValue = myValue;
            }

        }
    }
}
