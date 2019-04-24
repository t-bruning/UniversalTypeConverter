using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniversalTypeConverter.Tests {
    public partial class UniversalTypeConverter_Tests {

        [TestMethod]
        public void Convert_A_Guid_To_String_And_Back_Should_Convert() {
            var guid = Guid.NewGuid();
            var guidString = TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<string>(guid);
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<Guid>(guidString).Should().Be(guid);
        }

        [TestMethod]
        public void Convert_An_Empty_Guid_To_String_And_Back_Should_Convert() {
            var guid = Guid.Empty;
            var guidString = TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<string>(guid);
            TB.ComponentModel.UniversalTypeConverter.Instance.ConvertTo<Guid>(guidString).Should().Be(guid);
        }
    }
}
