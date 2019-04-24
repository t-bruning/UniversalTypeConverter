using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public class DictionaryExtension_Tests {

        [TestMethod]
        public void CreateT_Should_Create_T() {
            var dic = new Dictionary<string, object>();
            dic.Add("Value1", "V1");
            dic.Add("Value2", "V2");
            var t = dic.Create<DtoDummy>();
            t.Value1.Should().Be("V1");
            t.Value2.Should().Be("V2");
        }

        [TestMethod]
        public void Create_With_Type_Should_Create_Instance_Of_Given_Type() {
            var dic = new Dictionary<string, object>();
            dic.Add("Value1", "V1");
            dic.Add("Value2", "V2");
            var t = dic.Create(typeof(DtoDummy)) as DtoDummy;
            t.Value1.Should().Be("V1");
            t.Value2.Should().Be("V2");
        }

        [TestMethod]
        public void TryCreateT_Should_Create_T() {
            var dic = new Dictionary<string, object>();
            dic.Add("Value1", "V1");
            dic.Add("Value2", "V2");
            dic.TryCreate<DtoDummy>(out var t).Should().BeTrue();
            t.Value1.Should().Be("V1");
            t.Value2.Should().Be("V2");
        }

        [TestMethod]
        public void TryCreate_With_Type_Should_Create_Instance_Of_Given_Type() {
            var dic = new Dictionary<string, object>();
            dic.Add("Value1", "V1");
            dic.Add("Value2", "V2");
            dic.TryCreate(typeof(DtoDummy), out var t).Should().BeTrue();
            ((DtoDummy) t).Value1.Should().Be("V1");
            ((DtoDummy) t).Value2.Should().Be("V2");
        }

        private class DtoDummy {

            public string Value1 { get; set; }
            public string Value2 { get; set; }

        }

    }

}
