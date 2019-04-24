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

    partial class TypeConverter_Tests {

        [TestMethod]
        public void TryParse_Should_Prefer_FormatProvider_Overload() {
            var converter = new TypeConverter();
            var dummy = converter.ConvertTo<TryParseDummy>("1");

            dummy.Value.Should().Be("1");
            dummy.FormatProviderUsed.Should().BeTrue();
        }

        [TestMethod]
        public void TryParse_Should_Ignore_FormatProvider_As_Fallback() {
            var converter = new TypeConverter();
            var dummy = converter.ConvertTo<TryParseDummy2>("2");

            dummy.Value.Should().Be("2");
        }

        public class TryParseDummy {

            public string Value { get; }

            public bool FormatProviderUsed { get; }

            private TryParseDummy(string value, bool formatProviderUsed) {
                Value = value;
                FormatProviderUsed = formatProviderUsed;
            }

            public static bool TryParse(string value, IFormatProvider formatProvider, out TryParseDummy dummy) {
                dummy = new TryParseDummy(value, formatProviderUsed: true);
                return true;
            }

            public static bool TryParse(string value, out TryParseDummy dummy) {
                dummy = new TryParseDummy(value, formatProviderUsed: false);
                return true;
            }

        }

        public class TryParseDummy2 {

            public string Value { get; }


            private TryParseDummy2(string value) {
                Value = value;
            }

            public static bool TryParse(string value, out TryParseDummy2 dummy) {
                dummy = new TryParseDummy2(value);
                return true;
            }

        }

    }
}
