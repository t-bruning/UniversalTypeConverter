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
        public void Convert_DataRow_To_T_Should_Create_New_Instance_Of_T() {
            var converter = new TypeConverter();
            var row = NewDataRow("Test", 11);
            var poco = converter.ConvertTo<DataRowPoco>(row);
            poco.SValue.Should().Be("Test");
            poco.IValue.Should().Be(11);
        }

        [TestMethod]
        public void Convert_DataRowView_To_T_Should_Create_New_Instance_Of_T() {
            var converter = new TypeConverter();
            var row = NewDataRowView("Test", 11);
            var poco = converter.ConvertTo<DataRowPoco>(row);
            poco.SValue.Should().Be("Test");
            poco.IValue.Should().Be(11);
        }

        private DataRow NewDataRow(string sValue, int iValue) {
            var table = new DataTable();
            table.Columns.Add("sValue", typeof(string));
            table.Columns.Add("iValue", typeof(int));
            var row = table.NewRow();
            row[0] = sValue;
            row[1] = iValue;
            table.Rows.Add(row);
            return row;
        }

        private DataRowView NewDataRowView(string sValue, int iValue) {
            return NewDataRow(sValue, iValue).Table.DefaultView[0];
        }

        private class DataRowPoco {

            public string SValue { get; }
            public int IValue { get; set; }

            public DataRowPoco(string sValue) {
                SValue = sValue;
            }
        }
    }
}
