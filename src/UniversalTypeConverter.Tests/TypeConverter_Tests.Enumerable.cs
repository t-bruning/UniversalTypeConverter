using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void ConvertToEnumerable_Should_Convert_All_Values_To_The_Given_DestinationType() {

            var values = new List<object>();
            values.Add(true);
            values.Add("11");
            values.Add(111);


            var result = new TypeConverter().ConvertToEnumerable(values, typeof(int)).ToArray();
            result.Length.Should().Be(3);
            result[0].Should().Be(1);
            result[1].Should().Be(11);
            result[2].Should().Be(111);

        }
    }
}
