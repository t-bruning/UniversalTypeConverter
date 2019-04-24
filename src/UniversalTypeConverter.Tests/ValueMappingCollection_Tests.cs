using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public class ValueMappingCollection_Tests {

        [TestMethod]
        public void TryMap_Should_Return_False_If_Mapping_Not_Defined() {
            var mappings = new ValueMappingCollection();
            mappings.TryMap(1, typeof(string), out var destinationValue).Should().BeFalse();

            mappings.Add(2, "two");
            mappings.TryMap(1, typeof(string), out destinationValue).Should().BeFalse();
        }

        [TestMethod]
        public void TryMap_Should_Return_True_If_Mapping_Defined() {
            var mappings = new ValueMappingCollection();
            mappings.Add(1, "one");
            mappings.Add(2, "two");
            mappings.TryMap(2, typeof(string), out var destinationValue).Should().BeTrue();
            destinationValue.Should().Be("two");
        }

        [TestMethod]
        public void TryMap_Should_Use_Last_Defined_Mapping() {
            var mappings = new ValueMappingCollection();
            mappings.Add(1, "one");
            mappings.Add(1, "uno");
            mappings.TryMap(1, typeof(string), out var destinationValue).Should().BeTrue();
            destinationValue.Should().Be("uno");
        }

        [TestMethod]
        public void TryMap_Should_Use_The_Given_Comparer() {
            var mappings = new ValueMappingCollection();
            mappings.Add("a", 1);
            mappings.Add("A", 101);
            mappings.Add("b", 2, StringComparer.OrdinalIgnoreCase);

            mappings.TryMap("a", typeof(int), out var destinationValue).Should().BeTrue();
            destinationValue.Should().Be(1);
            mappings.TryMap("A", typeof(int), out destinationValue).Should().BeTrue();
            destinationValue.Should().Be(101);
            mappings.TryMap("b", typeof(int), out destinationValue).Should().BeTrue();
            destinationValue.Should().Be(2);
            mappings.TryMap("B", typeof(int), out destinationValue).Should().BeTrue();
            destinationValue.Should().Be(2);
        }

        [TestMethod]
        public void Adding_Source_Value_Of_Null_Should_Throw_ArgumentNullException() {
            var mappings = new ValueMappingCollection();
            Action action = () => mappings.Add<string, int>(null, 1);
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void RemoveSourceType_Should_Remove_Mappings_With_The_Given_Source_Type() {
            var mappings = new ValueMappingCollection();
            mappings.Add(1, "one");
            mappings.Add(2, "two");
            mappings.Add(true, "yes");
            mappings.Count().Should().Be(3);

            mappings.RemoveSourceType<int>();
            mappings.Count().Should().Be(1);
            mappings.RemoveSourceType<bool>();
            mappings.Count().Should().Be(0);
        }

        [TestMethod]
        public void RemoveDestinationType_Should_Remove_Mappings_With_The_Given_Destination_Type() {
            var mappings = new ValueMappingCollection();
            mappings.Add(1, "one");
            mappings.Add(2, "two");
            mappings.Add(true, 1);
            mappings.Count().Should().Be(3);

            mappings.RemoveDestinationType<int>();
            mappings.Count().Should().Be(2);
            mappings.RemoveDestinationType<string>();
            mappings.Count().Should().Be(0);
        }

        [TestMethod]
        public void Clear_Should_Clear_The_Collection() {
            var mappings = new ValueMappingCollection();
            mappings.Add(1, "one");
            mappings.TryMap(1, typeof(string), out var destinationValue).Should().BeTrue();
            destinationValue.Should().Be("one");

            mappings.Clear();
            mappings.TryMap(1, typeof(string), out destinationValue).Should().BeFalse();
        }
    }

}
