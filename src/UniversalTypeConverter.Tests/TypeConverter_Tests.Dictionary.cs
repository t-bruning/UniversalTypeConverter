using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests
{
    public partial class TypeConverter_Tests {

        [TestMethod]
        public void TryCreate_With_Dictionary_Should_Create_New_Instance_Of_Given_Type() {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("StringValue", "V1");
            dictionary.Add("IntValue", 2);

            var converter = new TypeConverter();
            converter.TryCreate<CreationDummy01>(dictionary, out var newInstance).Should().BeTrue();
            newInstance.StringValue.Should().Be("V1");
            newInstance.IntValue.Should().Be(2);
        }

        [TestMethod]
        public void TryCreate_With_Dictionary_Should_Create_New_Instance_Of_Given_Type_Only_If_One_KeyValuePair_Is_Used_At_Least() {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("SValue", "V1");
            dictionary.Add("IValue", 2);

            var converter = new TypeConverter();
            converter.TryCreate<CreationDummy01>(dictionary, out var newInstance).Should().BeFalse();
        }

        [TestMethod]
        public void TryCreate_With_Dictionary_Should_Use_Constructor_With_Most_Suitable_Parameters() {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("StringValue", "V1");
            dictionary.Add("IntValue", 2);

            var converter = new TypeConverter();
            converter.TryCreate<CreationDummy02>(dictionary, out var newInstance).Should().BeTrue();
            newInstance.ParameterCount.Should().Be(2);
        }

        [TestMethod]
        public void TryCreate_With_Dictionary_Should_Convert_Constructor_Parameters() {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("StringValue", "V1");
            dictionary.Add("IntValue", "3");

            var converter = new TypeConverter();
            converter.TryCreate<CreationDummy02>(dictionary, out var newInstance).Should().BeTrue();
            newInstance.ParameterCount.Should().Be(2);
            newInstance.GivenIntValue.Should().Be(3);
        }

        [TestMethod]
        public void TryCreate_With_Dictionary_Should_Convert_Property_Values() {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("StringValue", "V1");
            dictionary.Add("IntValue", "3");

            var converter = new TypeConverter();
            converter.TryCreate<CreationDummy01>(dictionary, out var newInstance).Should().BeTrue();
            newInstance.IntValue.Should().Be(3);
        }

        [TestMethod]
        public void TryCreate_With_Dictionary_Beeing_Null_Should_Return_False() {
            Dictionary<string, object> dictionary = null;
            var converter = new TypeConverter();
            converter.TryCreate<CreationDummy01>(dictionary, out _).Should().BeFalse();
        }

        [TestMethod]
        public void TryCreate_With_Empty_Dictionary_Should_Return_False() {
            var dictionary = new Dictionary<string, object>();

            var converter = new TypeConverter();
            converter.TryCreate<CreationDummy01>(dictionary, out _).Should().BeFalse();
        }

        [TestMethod]
        public void TryCreate_Primitive_With_Dictionary_Should_Return_Value_If_Dictionary_Has_Only_One_Item() {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("V", 11);

            var converter = new TypeConverter();
            converter.TryCreate<int>(dictionary, out var newInstance).Should().BeTrue();
            newInstance.Should().Be(11);
        }

        [TestMethod]
        public void TryCreate_Primitive_With_Dictionary_Should_Return_False_If_Dictionary_Has_More_Than_One_Item() {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("V", 11);
            dictionary.Add("V2", 12);

            var converter = new TypeConverter();
            converter.TryCreate<int>(dictionary, out _).Should().BeFalse();
        }

        [TestMethod]
        public void TryCreate_Should_Return_Value_If_Dictionarys_Only_Item_Is_Of_Same_Type() {
            var dictionary = new Dictionary<string, object>();
            var date = new DateTime(2019, 4, 7);
            dictionary.Add("V", date);

            var converter = new TypeConverter();
            converter.TryCreate<DateTime>(dictionary, out var newInstance).Should().BeTrue();
            newInstance.Should().Be(date);
        }

        private class CreationDummy01 {

            public string StringValue { get; set; }
            public int IntValue { get; set; }

        }

        private class CreationDummy02 {

            public int ParameterCount { get; }

            public int GivenIntValue { get; }

            public CreationDummy02() {
                ParameterCount = 0;
            }

            public CreationDummy02(string stringValue, int intValue) {
                ParameterCount = 2;
                GivenIntValue = intValue;
            }

            public CreationDummy02(string stringValue, int intValue, bool boolValue) {
                ParameterCount = 3;
                GivenIntValue = intValue;
            }
        }
    }
}
