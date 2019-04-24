using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public class EnumerableExtension_Tests {

        [TestMethod]
        public void ToEnumerableT_With_Enumerable_Should_Execute() {
            var input = new object[] {"1", "2"};
            input.ToEnumerable<int>().Count().Should().Be(2);
        }

        [TestMethod]
        public void ToEnumerable_With_Enumerable_Should_Execute() {
            var input = new object[] {"1", "2"};
            input.ToEnumerable(typeof(int)).Count().Should().Be(2);
        }

        [TestMethod]
        public void ToCollection_Should_Return_Equivalent_Collection() {
            var list = new List<int> {1, 2, 3};
            var collection = list.ToCollection();
            collection.Should().BeOfType<Collection<int>>();
            collection.Count.Should().Be(3);
            collection[0].Should().Be(1);
            collection[1].Should().Be(2);
            collection[2].Should().Be(3);
        }

        [TestMethod]
        public void ToDataTable_With_Null_Should_Return_Empty_DataTable() {
            List<DataTableNullTestDummy> list = null;
            var dataTable = list.ToDataTable();
            dataTable.Rows.Count.Should().Be(0);
            dataTable.Columns["StringValue"].Should().NotBeNull();
            dataTable.Columns["IntValue"].Should().NotBeNull();
        }

        [TestMethod]
        public void ToDataTable_Should_Return_Equivalent_DataTable() {
            var list = new List<DataTableItem>();
            var item1 = new DataTableItem("1");
            list.Add(item1);
            list.Add(new DataTableItem("2"));

            var dataTable = list.ToDataTable();
            dataTable.Rows.Count.Should().Be(2);
            dataTable.Rows[0]["Id"].Should().Be("1");
            dataTable.Rows[1]["Id"].Should().Be("2");

            dataTable.Rows[0]["StringValue"].Should().Be(item1.StringValue);
            dataTable.Rows[0]["NullString"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["BoolValue"].Should().Be(item1.BoolValue);
            dataTable.Rows[0]["NullBool"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["ByteValue"].Should().Be(item1.ByteValue);
            dataTable.Rows[0]["NullByte"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["CharValue"].Should().Be(item1.CharValue);
            dataTable.Rows[0]["NullChar"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["DateTimeValue"].Should().Be(item1.DateTimeValue);
            dataTable.Rows[0]["NullDateTime"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["DecimalValue"].Should().Be(item1.DecimalValue);
            dataTable.Rows[0]["NullDecimal"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["DoubleValue"].Should().Be(item1.DoubleValue);
            dataTable.Rows[0]["NullDouble"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["GuidValue"].Should().Be(item1.GuidValue);
            dataTable.Rows[0]["NullGuid"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["ShortValue"].Should().Be(item1.ShortValue);
            dataTable.Rows[0]["NullShort"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["IntValue"].Should().Be(item1.IntValue);
            dataTable.Rows[0]["NullInt"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["LongValue"].Should().Be(item1.LongValue);
            dataTable.Rows[0]["NullLong"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["SByteValue"].Should().Be(item1.SByteValue);
            dataTable.Rows[0]["NullSByte"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["FloatValue"].Should().Be(item1.FloatValue);
            dataTable.Rows[0]["NullFloat"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["TimeSpanValue"].Should().Be(item1.TimeSpanValue);
            dataTable.Rows[0]["NullTimeSpan"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["UShortValue"].Should().Be(item1.UShortValue);
            dataTable.Rows[0]["NullUShort"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["UIntValue"].Should().Be(item1.UIntValue);
            dataTable.Rows[0]["NullUInt"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["ULongValue"].Should().Be(item1.ULongValue);
            dataTable.Rows[0]["NullULong"].Should().Be(DBNull.Value);
            (dataTable.Rows[0]["ByteArrayValue"] as byte[])[0].Should().Be(item1.ByteArrayValue[0]);
            dataTable.Rows[0]["NullByteArray"].Should().Be(DBNull.Value);
            dataTable.Rows[0]["NullableIntNotNull"].Should().Be(item1.NullableIntNotNull);
        }

        [TestMethod]
        public void ToDataTable_Should_Try_To_Convert_Incompatible_Types_ToString() {
            var list = new List<DataTableItem>();
            var item1 = new DataTableItem("1");
            list.Add(item1);

            var dataTable = list.ToDataTable();
            dataTable.Rows[0]["FormattableValue"].Should().Be("IsFormattable");
        }

        [TestMethod]
        public void ToDataTable_Should_Use_ToString_On_Incompatible_Types_By_Default() {
            var list = new List<DataTableItem>();
            var item1 = new DataTableItem("1");
            list.Add(item1);

            var dataTable = list.ToDataTable();
            dataTable.Rows[0]["IncompatibleValue"].Should().Be("ToStringWasUsed");
        }

        [TestMethod]
        public void ToDataTable_Overload_Should_Use_ToString_On_Incompatible_Types() {
            var list = new List<DataTableItem>();
            var item1 = new DataTableItem("1");
            list.Add(item1);

            var dataTable = list.ToDataTable(CultureInfo.CurrentCulture);
            dataTable.Rows[0]["IncompatibleValue"].Should().Be("ToStringWasUsed");
        }

        [TestMethod]
        public void ToDataTable_Should_Use_ToString_On_Incompatible_If_Specified() {
            var list = new List<DataTableItem>();
            var item1 = new DataTableItem("1");
            list.Add(item1);

            var dataTable = list.ToDataTable(IncompatibleDataColumnTypeHandling.ToString);
            dataTable.Rows[0]["IncompatibleValue"].Should().Be("ToStringWasUsed");
        }

        [TestMethod]
        public void ToDataTable_Should_Use_AsString_On_Incompatible_Types_If_Specified() {
            var list = new List<DataTableItem>();
            var item1 = new DataTableItem("1");
            list.Add(item1);

            var dataTable = list.ToDataTable(IncompatibleDataColumnTypeHandling.AsString);
            dataTable.Rows[0]["IncompatibleValue"].Should().Be(DBNull.Value);
        }

        [TestMethod]
        public void ToDataTable_Should_Ignore_Incompatible_Types_If_Specified() {
            var list = new List<DataTableItem>();
            var item1 = new DataTableItem("1");
            list.Add(item1);

            var dataTable = list.ToDataTable(IncompatibleDataColumnTypeHandling.Ignore);
            dataTable.Columns.Contains("IncompatibleValue").Should().BeFalse();
        }

        [TestMethod]
        public void ToDataTable_Should_Ignore_Elements_Beeing_Null() {
            var list = new List<DataTableItem>();
            list.Add(new DataTableItem("1"));
            list.Add(null);
            list.Add(new DataTableItem("2"));

            var dataTable = list.ToDataTable();
            dataTable.Rows.Count.Should().Be(2);
            dataTable.Rows[0]["Id"].Should().Be("1");
            dataTable.Rows[1]["Id"].Should().Be("2");
        }

        private class DataTableItem {

            public string Id { get; }

            public string StringValue => "Value";
            public string NullString => null;
            public bool BoolValue => true;
            public bool? NullBool => null;
            public byte ByteValue => 1;
            public byte? NullByte => null;
            public char CharValue => 'c';
            public char? NullChar => null;
            public DateTime DateTimeValue => new DateTime(2019, 3, 21);
            public DateTime? NullDateTime => null;
            public decimal DecimalValue => 2;
            public decimal? NullDecimal => null;
            public double DoubleValue => 3;
            public double? NullDouble => null;
            public Guid GuidValue => Guid.Empty;
            public Guid? NullGuid => null;
            public short ShortValue => 4;
            public short? NullShort => null;
            public int IntValue => 5;
            public int? NullInt => null;
            public long LongValue => 6;
            public long? NullLong => null;
            public sbyte SByteValue => 7;
            public sbyte? NullSByte => null;
            public float FloatValue => 8;
            public float? NullFloat => null;
            public TimeSpan TimeSpanValue => new TimeSpan(1);
            public TimeSpan? NullTimeSpan => null;
            public ushort UShortValue => 9;
            public ushort? NullUShort => null;
            public uint UIntValue => 10;
            public uint? NullUInt => null;
            public ulong ULongValue => 11;
            public ulong? NullULong => null;
            public byte[] ByteArrayValue => new byte[] {1};
            public byte[] NullByteArray => null;

            public int? NullableIntNotNull => 12;

            public IncompatibleType IncompatibleValue { get; }

            public FormattableType FormattableValue { get; }

            public DataTableItem(string id) {
                Id = id;
                IncompatibleValue = new IncompatibleType();
                FormattableValue = new FormattableType();
            }
        }

        private class IncompatibleType {

            public IncompatibleType() {
            }

            /// <inheritdoc />
            public override string ToString() {
                return "ToStringWasUsed";
            }

        }

        private class FormattableType : IFormattable {

            /// <inheritdoc />
            public string ToString(string format, IFormatProvider formatProvider) {
                return "IsFormattable";
            }

        }

        private class DataTableNullTestDummy {

            public string StringValue { get; set; }
            public string IntValue { get; set; }
        }
    }

}
