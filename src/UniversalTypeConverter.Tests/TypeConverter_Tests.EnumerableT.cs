using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void ConvertToEnumerableT_Should_Convert_All_Values_To_T() {
            var values = new List<object>();
            values.Add(true);
            values.Add("11");
            values.Add(111);

            var result = new TypeConverter().ConvertToEnumerable<int>(values).ToArray();
            result.Length.Should().Be(3);
            result[0].Should().Be(1);
            result[1].Should().Be(11);
            result[2].Should().Be(111);
        }

        [TestMethod]
        public void ConvertToEnumerableT_Should_Not_Ignore_NullElements_By_Default() {
            var values = new List<object>();
            values.Add(true);
            values.Add(null);
            values.Add(111);

            var result = new TypeConverter().ConvertToEnumerable<int?>(values).ToArray();
            result.Length.Should().Be(3);
            result[0].Should().Be(1);
            result[1].Should().Be(null);
            result[2].Should().Be(111);
        }

        [TestMethod]
        public void ConvertToEnumerableT_Should_Ignore_NullElements_On_Demand() {
            var values = new List<object>();
            values.Add(true);
            values.Add(null);
            values.Add(111);

            var result = new TypeConverter().ConvertToEnumerable<int?>(values).IgnoringNullElements().ToArray();
            result.Length.Should().Be(2);
            result[0].Should().Be(1);
            result[1].Should().Be(111);
        }

        [TestMethod]
        public void ConvertToEnumerableT_Should_Not_Ignore_NonConvertibleElements_By_Default() {
            var values = new List<object>();
            values.Add(1);
            values.Add(DateTime.Now);

            Action action = () => new TypeConverter().ConvertToEnumerable<int?>(values).ToArray();
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void ConvertToEnumerableT_Should_Ignore_NonConvertibleElements_On_Demand() {
            var values = new List<object>();
            values.Add(1);
            values.Add(DateTime.Now);
            values.Add(2);

            var result = new TypeConverter().ConvertToEnumerable<int?>(values).IgnoringNonConvertibleElements().ToArray();
            result.Length.Should().Be(2);
            result[0].Should().Be(1);
            result[1].Should().Be(2);
        }

        [TestMethod]
        public void ConvertToEnumerableT_Try_With_Valid_Input_Should_Return_True_And_Converted_Values() {
            List<object> values = new List<object>();
            values.Add(true);
            values.Add("11");
            values.Add(111);

            Collection<int> result;
            new TypeConverter().ConvertToEnumerable<int>(values).Try(out result).Should().BeTrue();
            var resultAsArray = result.ToArray();
            resultAsArray.Length.Should().Be(3);
            resultAsArray[0].Should().Be(1);
            resultAsArray[1].Should().Be(11);
            resultAsArray[2].Should().Be(111);
        }

        [TestMethod]
        public void ConvertToEnumerableT_Try_With_Invalid_Input_Should_Return_False() {
            List<object> values = new List<object>();
            values.Add(true);
            values.Add(DateTime.Now);

            Collection<int> result;
            new TypeConverter().ConvertToEnumerable<int>(values).Try(out result).Should().BeFalse();
        }

        [TestMethod]
        public void ConvertToEnumerableT_Should_Convert_Deferred() {
            var values = new List<object>();
            values.Add(1);
            values.Add(DateTime.Now);

            var iterator = new TypeConverter().ConvertToEnumerable<int?>(values).GetEnumerator();
            iterator.MoveNext().Should().BeTrue();
            iterator.Current.Value.Should().Be(1);

            Action action = () => iterator.MoveNext();
            action.Should().Throw<InvalidConversionException>();
        }
    }
}
