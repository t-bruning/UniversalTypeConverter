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
    [TestClass]
    public class DataRowExtension_Tests {

        [TestMethod]
        public void ToDictionary_With_DataRow_Beeing_Null_Should_Return_An_Empty_Dictionary() {
            DataRow row = null;
            row.ToDictionary().Count.Should().Be(0);
        }

        [TestMethod]
        public void ToDictionary_With_DataRow_Should_Return_Case_Insensitive_Dictionary() {
            var dic = NewDataRow("a", 1).ToDictionary();
            dic.Should().ContainKey("sValue");
            dic.Should().ContainKey("SvALue");
        }

        [TestMethod]
        public void ToDictionary_With_DataRow_Should_Contain_Columns_of_Row() {
            var dic = NewDataRow("a", 1).ToDictionary();
            dic.Count.Should().Be(2);
            dic["sValue"].Should().Be("a");
            dic["iValue"].Should().Be(1);
        }

        [TestMethod]
        public void ToDictionary_With_DataRowView_Beeing_Null_Should_Return_An_Empty_Dictionary() {
            DataRowView rowView = null;
            rowView.ToDictionary().Count.Should().Be(0);
        }

        [TestMethod]
        public void ToDictionary_With_DataRowView_Should_Return_Case_Insensitive_Dictionary() {
            var dic = NewDataRowView("a", 1).ToDictionary();
            dic.Count.Should().Be(2);
            dic.Should().ContainKey("sValue");
            dic.Should().ContainKey("SvALue");
        }

        [TestMethod]
        public void ToDictionary_With_DataRowView_Should_Contain_Columns_of_RowView() {
            var dic = NewDataRowView("a", 1).ToDictionary();
            dic.Count.Should().Be(2);
            dic["sValue"].Should().Be("a");
            dic["iValue"].Should().Be(1);
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
    }
}
