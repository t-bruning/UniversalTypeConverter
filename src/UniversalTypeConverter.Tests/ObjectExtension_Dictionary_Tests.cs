using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TB.ComponentModel;

namespace UniversalTypeConverter.Tests {

    [TestClass]
    public class ObjectExtension_Dictionary_Tests {

        [TestMethod]
        public void ToDictionary_With_Null_Should_Return_An_Empty_Dictionary() {
            object o = null;
            o.ToDictionary().Count.Should().Be(0);
        }

        [TestMethod]
        public void ToDictionary_Should_Return_Case_Insensitive_Dictionary() {
            var dic = new DummyClass().ToDictionary();
            dic.ContainsKey("ReadOnlyProperty").Should().BeTrue();
            dic.ContainsKey("rEAdOnlYproperty").Should().BeTrue();
        }

        [TestMethod]
        public void ToDictionary_With_Dictionary_Should_Return_Same_Dictionary() {
            var dic = new Dictionary<string, object>();
            dic.Add("K1", 1);
            dic.Add("K2", 2);

            object o = dic;
            o.ToDictionary().Should().BeSameAs(dic);
        }

        [TestMethod]
        public void ToDictionary_With_IDictionary_Should_Contain_Equivalent_Key_Value_Pairs() {
            var dic = new Dictionary<int, string>();    // implements IDictionary
            dic.Add(1, "K1");
            dic.Add(2, "K2");
            var dic2 = dic.ToDictionary();
            dic2.Count.Should().Be(2);
            dic2["1"].Should().Be("K1");
            dic2["2"].Should().Be("K2");
        }

        [TestMethod]
        public void ToDictionary_With_IDictionary_Beeing_Null_Should_Return_Empty_Dictionary() {
            IDictionary dic = null;
            var dic2 = dic.ToDictionary();
            dic2.Count.Should().Be(0);
        }

        [TestMethod]
        public void ToDictionary_With_Primitive_ValueType_Should_Return_An_Dictionary_Just_Containig_The_Given_Value() {
            var dic = 2.ToDictionary();
            dic.Count.Should().Be(1);
            dic["Value"].Should().Be(2);
        }

        [TestMethod]
        public void ToDictionary_Should_Only_Contain_Instance_Public_Readable_Properties_And_Fields() {
            var dic = new DummyClass().ToDictionary();
            dic.Count.Should().Be(3);
            dic["Field"].Should().Be(2);
            dic["ReadOnlyProperty"].Should().Be("ReadOnly");
            dic["ReadWriteProperty"].Should().Be("ReadWrite");
        }

        [TestMethod]
        public void ToDictionary_With_DataRow_Should_Contain_Columns_of_Row() {
            object obj = NewDataRow("a", 1);
            var dic = obj.ToDictionary();
            dic.Count.Should().Be(2);
            dic["sValue"].Should().Be("a");
            dic["iValue"].Should().Be(1);
        }

        [TestMethod]
        public void ToDictionary_With_DataRowView_Should_Contain_Columns_of_RowView() {
            object obj = NewDataRowView("a", 1);
            var dic = obj.ToDictionary();
            dic.Count.Should().Be(2);
            dic["sValue"].Should().Be("a");
            dic["iValue"].Should().Be(1);
        }

        [TestMethod]
        public void ToDictionary_With_IDataRecord_Should_Contain_Fields_of_Record() {
            object obj = new RecordDummy("a", 1);
            var dic = obj.ToDictionary();
            dic.Count.Should().Be(2);
            dic["F0"].Should().Be("a");
            dic["F1"].Should().Be(1);
        }


        private class DummyClass {

            private string mWriteOnlyProperty;

            public static int StaticField;
            public static int StaticProperty { get; set; }

            public int Field = 2;
            public string ReadOnlyProperty { get; } = "ReadOnly";
            public string ReadWriteProperty { get; set; } = "ReadWrite";
            public string WriteOnlyProperty { set => mWriteOnlyProperty = value; }

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

        private class RecordDummy : IDataRecord {

            private readonly object[] mValues;

            public RecordDummy(params object[] values) {
                mValues = values ?? new object[0];
            }

            /// <inheritdoc />
            public string GetName(int i) {
                return "F" + i;
            }

            /// <inheritdoc />
            public string GetDataTypeName(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public Type GetFieldType(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public object GetValue(int i) {
                return mValues[i];
            }

            /// <inheritdoc />
            public int GetValues(object[] values) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public int GetOrdinal(string name) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public bool GetBoolean(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public byte GetByte(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public char GetChar(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public Guid GetGuid(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public short GetInt16(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public int GetInt32(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public long GetInt64(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public float GetFloat(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public double GetDouble(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public string GetString(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public decimal GetDecimal(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public DateTime GetDateTime(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public IDataReader GetData(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public bool IsDBNull(int i) {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            public int FieldCount {
                get => mValues.Length;
                set => throw new NotImplementedException();
            }

            /// <inheritdoc />
            public object this[int i] {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }

            /// <inheritdoc />
            public object this[string name] {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }

        }
    }

}
