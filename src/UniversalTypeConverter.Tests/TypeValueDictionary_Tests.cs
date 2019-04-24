using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public class TypeValueDictionary_Tests {

        [TestMethod]
        public void TryGet_Should_Return_False_If_Destination_Type_Not_Defined() {
            var dic = new TypeValueDictionary();
            dic.TryGet(typeof(string), out var nullValue).Should().BeFalse();

            dic.Add(1);
            dic.TryGet(typeof(string), out nullValue).Should().BeFalse();
        }

        [TestMethod]
        public void TryGet_Should_Return_The_Specified_Null_Value_If_Defined() {
            var dic = new TypeValueDictionary();
            dic.Add(1);
            dic.Add(typeof(string), ".null.");
            dic.Add(Get12Point3);

            dic.TryGet(typeof(int), out var nullValue).Should().BeTrue();
            nullValue.Should().Be(1);

            dic.TryGet(typeof(string), out nullValue).Should().BeTrue();
            nullValue.Should().Be(".null.");

            dic.TryGet(typeof(decimal), out nullValue).Should().BeTrue();
            nullValue.Should().Be(12.3m);
        }

        [TestMethod]
        public void Add_Should_Override_Prior_Definitions() {
            var dic = new TypeValueDictionary();
            dic.Add(1);
            dic.Add(2);

            dic.TryGet(typeof(int), out var nullValue).Should().BeTrue();
            nullValue.Should().Be(2);
        }

        [TestMethod]
        public void Add_NullFunc_Should_Throw_ArgumentNullException() {
            var dic = new TypeValueDictionary();
            Func<int> func = null;
            Action action = () => dic.Add(func);
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Add_NullType_Should_Throw_ArgumentNullException() {
            var dic = new TypeValueDictionary();
            Action action = () => dic.Add(null, 1);
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Add_NullValue_Should_Throw_ArgumentNullException() {
            var dic = new TypeValueDictionary();
            Action action = () => dic.Add(typeof(string), null);
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Add_Value_Not_Of_Given_Type_Should_Throw_ArgumentOutOfRangeException() {
            var dic = new TypeValueDictionary();
            Action action = () => dic.Add(typeof(string), 1);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        private static decimal Get12Point3() {
            return 12.3m;
        }
    }

}
