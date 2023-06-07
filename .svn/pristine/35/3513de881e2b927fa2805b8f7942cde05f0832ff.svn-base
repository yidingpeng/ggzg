using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace RW.PMS.Utils.Data
{

    /// <summary>
    /// 数据库帮助类的接口
    /// </summary>
    public interface IDbBase
    {
        //DbConnection Connection { get;set; }
        //DbCommand Command { get;set; }
        //DbDataAdapter DataAdapter { get;set;}
        //ConnectionState State { get; }
        string ConnectionString { get; set; }
        //void Connect();
        //void Connect(string source);
        //void Disconnect();
        int ExecuteNonQuery(string sql);
        int ExecuteNonQuery(string sql, params DbParameter[] parameters);
        DbDataReader ExecuteReader(string cmdText);
        object ExecuteScalar(string cmdText);
        DataSet GetDataSet(string select);
        DataTable GetDataTable(string select);
        void Connect();
    }

    /// <summary>
    /// 数据库帮助类的基类
    /// </summary>
    public class DbBase<TConnection, TCommand, TDataAdapter> : IDbBase
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TDataAdapter : DbDataAdapter, new()
    {
        //DbConnection conn = new TConnection();
        //public DbConnection Connection
        //{
        //    get { return conn; }
        //    set { conn = value; }
        //}
        //DbCommand cmd = new TCommand();
        //public DbCommand Command
        //{
        //    get { return cmd; }
        //    set { cmd = value; }
        //}
        //DbDataAdapter da = new TDataAdapter();
        //public DbDataAdapter DataAdapter
        //{
        //    get { return da; }
        //    set { da = value; }
        //}
        //DbCommandBuilder CommandBuilder = new TCommandBuilder();
        private string connectionString;
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public DbBase()
        {

        }

        public DbBase(string source)
        {
            this.ConnectionString = source;
        }

        //public ConnectionState State
        //{
        //    get { return conn.State; }
        //}

        //public virtual void Connect()
        //{
        //    Connect(this.ConnectionString);
        //}

        //public virtual void Connect(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //    conn.ConnectionString = connectionString;
        //    conn.Open();
        //}

        //public virtual void Disconnect()
        //{
        //    try
        //    {
        //        this.conn.Close();
        //    }
        //    catch { }
        //}

        public virtual int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(cmdText, null);
        }

        public virtual int ExecuteNonQuery(string cmdText, params DbParameter[] parameters)
        {
            using (TConnection conn = GetConnection())
            {
                using (TCommand cmd = GetDbCommand(conn, cmdText, parameters))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public virtual DbDataReader ExecuteReader(string cmdText)
        {
            using (TConnection conn = GetConnection())
            {
                using (TCommand cmd = GetDbCommand(conn, cmdText))
                {
                    DbDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
            }
        }

        public virtual object ExecuteScalar(string cmdText)
        {
            using (TConnection conn = GetConnection())
            {
                using (TCommand cmd = GetDbCommand(conn, cmdText))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

        public virtual DataSet GetDataSet(string cmdText)
        {
            using (TConnection conn = GetConnection())
            {
                using (TCommand cmd = GetDbCommand(conn, cmdText))
                {
                    TDataAdapter da = new TDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public virtual DataTable GetDataTable(string select)
        {
            DataSet ds = GetDataSet(select);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public TCommand GetDbCommand(TConnection conn, string sql, params DbParameter[] parameters)
        {
            TCommand cmd = new TCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd;
        }

        public TConnection GetConnection()
        {
            TConnection conn = new TConnection();
            conn.ConnectionString = ConnectionString;
            conn.Open();
            return conn;
        }

        public void Connect()
        {
            GetConnection();
        }

        //public virtual void Dispose()
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //}


    }
}
