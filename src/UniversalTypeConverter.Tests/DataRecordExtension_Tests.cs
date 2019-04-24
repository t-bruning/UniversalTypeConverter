using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests
{
    [TestClass]
    public class DataRecordExtension_Tests {

        [TestMethod]
        public void ToDictionary_With_Null_Should_Return_An_Empty_Dictionary() {
            IDataRecord record = null;
            record.ToDictionary().Count.Should().Be(0);
        }

        [TestMethod]
        public void ToDictionary_Should_Return_Case_Insensitive_Dictionary() {
            var dic = new RecordDummy("a", 1).ToDictionary();
            dic.ContainsKey("F0").Should().BeTrue();
            dic.ContainsKey("f0").Should().BeTrue();
        }

        [TestMethod]
        public void ToDictionary_Should_Contain_Fields_of_Record() {
            var dic = new RecordDummy("a", 1).ToDictionary();
            dic.Count.Should().Be(2);
            dic["F0"].Should().Be("a");
            dic["F1"].Should().Be(1);
        }
    }

}
