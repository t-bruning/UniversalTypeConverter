using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_ToImplemetedInterface_ShouldConvert() {
            var value = 1;
            var convertible = new TypeConverter().ConvertTo<IConvertible>(value);
            convertible.Should().Be(value);
        }

        [TestMethod]
        public void Convert_FromBaseToDerivedClass_ShouldConvert() {
            TestClassBase derived = new DerivedTestClass();
            var result = new TypeConverter().ConvertTo<DerivedTestClass>(derived);
            result.Should().BeSameAs(derived);
        }

        [TestMethod]
        public void Convert_FromDerivedToBase_ShouldConvert() {
            var derived = new DerivedTestClass();
            var result = new TypeConverter().ConvertTo<TestClassBase>(derived);
            result.Should().BeSameAs(derived);
        }

    }

    public class TestClassBase {

    }

    public class DerivedTestClass : TestClassBase {

    }

}
