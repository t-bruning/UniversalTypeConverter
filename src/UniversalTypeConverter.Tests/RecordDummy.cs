using System;
using System.Data;

namespace UniversalTypeConverter.Tests {

    public class RecordDummy : IDataRecord {

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