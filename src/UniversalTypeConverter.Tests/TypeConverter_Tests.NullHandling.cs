using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Conversion_Of_Null_Should_Throw_InvalidConversionException_If_DestinationType_Is_Not_Nullable() {
            Action action = () => new TypeConverter().ConvertTo<int>(null);
            action.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void Conversion_Of_Null_Should_Return_Default_Value_If_Allowed() {
            var converter = new TypeConverter();
            converter.Options.AllowDefaultValueIfNull = true;
            converter.ConvertTo<int>(null).Should().Be(0);
        }

        [TestMethod]
        public void Conversion_Should_Return_Null_By_Default() {
            var converter = new TypeConverter();
            converter.ConvertTo<string>(null).Should().BeNull();
        }

        [TestMethod]
        public void DBNull_Should_Be_Treated_As_Null_By_Default() {
            var converter = new TypeConverter();
            converter.ConvertTo<string>(DBNull.Value).Should().BeNull();
        }

        [TestMethod]
        public void HandleDBNullAsNull_Option_Should_Be_Respected() {
            var converter = new TypeConverter();
            converter.NullValues.Add(1);
            converter.ConvertTo<int>(DBNull.Value).Should().Be(1);

            converter.Options.HandleDBNullAsNull = false;
            Action a = () => converter.ConvertTo<int>(DBNull.Value);
            a.Should().Throw<InvalidConversionException>();
        }

        [TestMethod]
        public void Conversion_Should_Return_Null_Value_If_Specified() {
            var converter = new TypeConverter();
            var nullValue = new NullValue();
            converter.NullValues.Add(".null.");
            converter.NullValues.Add(nullValue);

            converter.ConvertTo<string>(null).Should().Be(".null.");
            converter.ConvertTo<NullValue>(null).Should().Be(nullValue);
            converter.ConvertTo<StringBuilder>(null).Should().BeNull();
        }

        private class NullValue {
        }
    }

}
