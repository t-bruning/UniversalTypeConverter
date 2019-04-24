using System;
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

    partial class TypeConverter_Tests {

        [TestMethod]
        public void Convert_DataRecord_To_T_Should_Create_New_Instance_Of_T() {
            var converter = new TypeConverter();
            IDataRecord record = new RecordDummy("Test", 11);
            var poco = converter.ConvertTo<DataRecordPoco>(record);
            poco.F0.Should().Be("Test");
            poco.F1.Should().Be(11);
        }

        public class DataRecordPoco {

            public string F0 { get; }
            public int F1 { get; set; }

            public DataRecordPoco(string f0) {
                F0 = f0;
            }
        }
    }
}
