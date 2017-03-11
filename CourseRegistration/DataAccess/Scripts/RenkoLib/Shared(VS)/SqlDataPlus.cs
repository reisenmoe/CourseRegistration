using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Renko
{
    /// <summary>
    /// An easy way (for me) to execute and read data from the database.
    /// </summary>
    public class SqlDataPlus
    {
        private SqlCommand cCommand;

        private DataTable cDataTable;
        private SqlDataReader cReader;


        public SqlDataPlus(SqlCommand cmd)
        {
            cCommand = cmd;

            cDataTable = new DataTable();
        }


        /// <summary>
        /// Returns false if no rows exist.
        /// Otherwise, true is returned and prepares for data extraction
        /// </summary>
        public bool Execute()
        {
            cReader = cCommand.ExecuteReader();

            //There are rows
            if (cReader.HasRows)
            {
                //Load to data table
                cDataTable.Load(cReader);

                //Return true
                return true;
            }

            //No rows exist
            return false;
        }

        public int Count
        {
            get
            {
                return cDataTable.Rows.Count;
            }
        }

        public SqlDataRow this[int rowInx]
        {
            get
            {
                if (rowInx >= cDataTable.Rows.Count || rowInx < 0)
                    throw new IndexOutOfRangeException("rowIndex(" + rowInx + ") is out of bounds!");
                return new SqlDataRow(cDataTable.Rows[rowInx].ItemArray);
            }
        }
    }

    public struct SqlDataRow
    {

        public object[] RawData;

        public int Columns;


        public SqlDataRow(object[] row)
        {
            RawData = row;
            Columns = row.Length;
        }

        public string GetString(int inx)
        {
            return (string)RawData[inx];
        }

        public long GetLong(int inx)
        {
            return (long)RawData[inx];
        }
        public int GetInt(int inx)
        {
            return (int)RawData[inx];
        }
        public float GetFloat(int inx)
        {
            return (float)RawData[inx];
        }
        public decimal GetDecimal(int inx)
        {
            return (decimal)RawData[inx];
        }
        public short GetShort(int inx)
        {
            return (short)RawData[inx];
        }
        public byte GetByte(int inx)
        {
            return (byte)RawData[inx];
        }

        public object GetObject(int inx)
        {
            return RawData[inx];
        }
    }
}