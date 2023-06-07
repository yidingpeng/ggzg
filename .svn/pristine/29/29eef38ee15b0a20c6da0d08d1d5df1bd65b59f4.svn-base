using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Collections;
using System.Data;
using System.Reflection;

namespace RW.PMS.WinForm
{
    public static class AccessHelper
    {
        //用于缓存参数的HASH表
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        private static OleDbConnection Conn;
        #region 连接关闭数据库

        private static string _DBPath;

        public static string DBPath
        {
            get { return _DBPath; }
            set { _DBPath = value; }
        }

        /// <summary>   
        /// 打开数据源链接   
        /// </summary>   
        /// <returns></returns>   
        public static OleDbConnection DBConn()
        {
            string ConnString = "Provider = Microsoft.Ace.OLEDB.12.0;Data Source = G:\\RWAMS_CS_ym\\RWAMS.accdb";
            Conn = new OleDbConnection(ConnString);
            Conn.Open();
            return Conn;
        }

        /// <summary>   
        /// 请在数据传递完毕后调用该函数，关闭数据链接。   
        /// </summary>   
        public static void Close()
        {
            Conn.Close();
        }
        #endregion

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {

            if (string.IsNullOrEmpty(DBPath))
            {
                return "Provider = Microsoft.Ace.OLEDB.12.0;Data Source = E:\\RWAMS\\装配管理系统\\RWAMS\\RWAMS\\bin\\Debug\\RWAMS.accdb";
            }
            else
            {
                return "Provider = Microsoft.Ace.OLEDB.12.0;Data Source = E:\\RWAMS\\装配管理系统\\RWAMS\\RWAMS\\bin\\Debug\\RWAMS.accdb";
            }

        }

        /// <summary>
        /// 给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, params OleDbParameter[] commandParameters)
        {
            //判断连接的状态。如果是关闭状态，则打开
            try
            {
                using (OleDbConnection connection = new OleDbConnection(GetConnectionString()))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    PrepareCommand(connection, cmd, cmdText, commandParameters);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("由于将在索引、 主关键字、或关系中创建重复的值，请求对表的改变没有成功。"))
                    return -5;
                else
                    return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OleDbConnection con, OleDbTransaction trans, string cmdText, params OleDbParameter[] commandParameters)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(con, cmd, trans, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <remarks>
        /// 举例: 
        /// OleDbDataReader r = ExecuteReader(connString, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static OleDbDataReader ExecuteReader(string cmdText, params OleDbParameter[] commandParameters)
        {
            //判断连接的状态。如果是关闭状态，则打开
            using (OleDbConnection connection = new OleDbConnection(GetConnectionString()))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                //创建一个SqlCommand对象
                OleDbCommand cmd = new OleDbCommand();
                //创建一个SqlConnection对象
                OleDbConnection conn = new OleDbConnection(GetConnectionString());
                //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
                //因此commandBehaviour.CloseConnection 就不会执行
                try
                {
                    //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数
                    PrepareCommand(connection, cmd, cmdText, commandParameters);
                    //调用 SqlCommand 的 ExecuteReader 方法
                    OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    //清除参数
                    cmd.Parameters.Clear();
                    return reader;
                }
                catch
                {
                    //关闭连接，抛出异常
                    conn.Close();
                    throw;
                }
            }
        }
        /// <summary>
        /// 返回一个DataSet数据集
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的数据集</returns>
        public static DataSet ExecuteDataSet(string cmdText, params OleDbParameter[] commandParameters)
        {
            //创建一个SqlCommand对象，并对其进行初始化
            OleDbCommand cmd = new OleDbCommand();
            using (OleDbConnection connection = new OleDbConnection(GetConnectionString()))
            {
                PrepareCommand(connection, cmd, cmdText, commandParameters);
                //创建SqlDataAdapter对象以及DataSet
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    //填充ds
                    da.Fill(ds);
                    // 清除cmd的参数集合 
                    cmd.Parameters.Clear();
                    //返回ds
                    return ds;
                }
                catch
                {
                    //关闭连接，抛出异常
                    connection.Close();
                    return null;
                }
            }
        }

        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        ///例如: 
        /// Object obj = ExecuteScalar(connString, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        ///<param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(string cmdText, params OleDbParameter[] commandParameters)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(GetConnectionString()))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    PrepareCommand(connection, cmd, cmdText, commandParameters);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                    return val;
                }
            }
            catch (Exception)
            {

                return "";
            }
        }
        /// <summary>
        /// 用指定的数据库连接执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        /// 例如: 
        /// Object obj = ExecuteScalar(connString, "PublishOrders", new OleDbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">一个存在的数据库连接</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(OleDbConnection connection, OleDbTransaction trans, string cmdText, params OleDbParameter[] commandParameters)
        {

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(connection, cmd, trans, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                return val;
            }
            catch (Exception)
            {

                return "";
            }
        }
        /// <summary>
        /// 将参数集合添加到缓存
        /// </summary>
        /// <param name="cacheKey">添加到缓存的变量</param>
        /// <param name="cmdParms">一个将要添加到缓存的sql参数集合</param>
        public static void CacheParameters(string cacheKey, params OleDbParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
        /// <summary>
        /// 找回缓存参数集合
        /// </summary>
        /// <param name="cacheKey">用于找回参数的关键字</param>
        /// <returns>缓存的参数集合</returns>
        public static OleDbParameter[] GetCachedParameters(string cacheKey)
        {
            OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];
            if (cachedParms == null)
                return null;
            OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms = (OleDbParameter[])((ICloneable)cachedParms).Clone();
            return clonedParms;
        }
        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(OleDbConnection connection, OleDbCommand cmd, string cmdText, OleDbParameter[] cmdParms)
        {


            //cmd属性赋值
            cmd.Connection = connection;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            //添加cmd需要的存储过程参数
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                {
                    cmd.Parameters.AddWithValue(parm.ParameterName, parm.Value);
                }
            }
        }
        private static void PrepareCommand(OleDbConnection connection, OleDbCommand cmd, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            //判断连接的状态。如果是关闭状态，则打开
            if (connection.State != ConnectionState.Open)
                connection.Open();
            //cmd属性赋值
            cmd.Connection = connection;
            cmd.CommandText = cmdText;
            //是否需要用到事务处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            //添加cmd需要的存储过程参数
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.AddWithValue(parm.ParameterName, parm.Value);
            }
        }

        #region 数据库基本操作
        /// <summary>
        /// 处理新增后获取自增长ID
        /// </summary>
        /// <param name="strConnectionString"></param>
        /// <param name="strSqls"></param>
        /// <returns></returns>
        public static object ExecuteScalar(String[] strSqls)
        {
            using (OleDbConnection Oleconn = new OleDbConnection(GetConnectionString()))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Oleconn;
                try
                {
                    Oleconn.Open();
                    int i = 0;
                    foreach (String strSql in strSqls)
                    {
                        cmd.CommandText = strSql;
                        if (i < strSqls.Length - 1)
                            cmd.ExecuteNonQuery();
                        else
                        {
                            return cmd.ExecuteScalar();
                        }
                        i++;
                    }
                    //永远不会执行到的语句。
                    return null;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    if (Oleconn.State == ConnectionState.Open)
                        Oleconn.Close();
                }
            }
        }
        /**/
        /// <summary>   
        /// 根据SQL命令返回数据DataTable数据表,   
        /// 可直接作为dataGridView的数据源   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <returns></returns>   
        public static DataTable SelectToDataTable(string SQL)
        {
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command = new OleDbCommand(SQL, conn);
                adapter.SelectCommand = command;
                DataTable Dt = new DataTable();
                adapter.Fill(Dt);
                return Dt;
            }
        }

        #region 纪录存在
        /// <summary>
        /// 纪录存在
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool Exist(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                bool result = false;
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                try
                {
                    result = cmd.ExecuteReader().HasRows;
                }
                catch (Exception ex) { throw ex; }
                return result;
            }
        }
        #endregion

        /**/
        /// <summary>   
        /// 根据SQL命令返回数据DataSet数据集，其中的表可直接作为dataGridView的数据源。   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <param name="subtableName">在返回的数据集中所添加的表的名称</param>   
        /// <returns></returns>   
        public static DataSet SelectToDataSet(string SQL, string subtableName)
        {
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command = new OleDbCommand(SQL, conn);
                adapter.SelectCommand = command;
                DataSet Ds = new DataSet();
                // Ds.Tables.Add(subtableName);
                // adapter.Fill(Ds, subtableName);
                adapter.Fill(Ds);
                return Ds;
            }
        }

        /**/
        /// <summary>   
        /// 在指定的数据集中添加带有指定名称的表，由于存在覆盖已有名称表的危险，返回操作之前的数据集。   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <param name="subtableName">添加的表名</param>   
        /// <param name="DataSetName">被添加的数据集名</param>   
        /// <returns></returns>   
        public static DataSet SelectToDataSet(string SQL, string subtableName, DataSet DataSetName)
        {
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command = new OleDbCommand(SQL, conn);
                adapter.SelectCommand = command;
                DataTable Dt = new DataTable();
                DataSet Ds = new DataSet();
                Ds = DataSetName;
                adapter.Fill(DataSetName, subtableName);
                return Ds;
            }
        }

        /**/
        /// <summary>   
        /// 根据SQL命令返回OleDbDataAdapter，   
        /// 使用前请在主程序中添加命名空间System.Data.OleDb   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <returns></returns>   
        public static OleDbDataAdapter SelectToOleDbDataAdapter(string SQL)
        {
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command = new OleDbCommand(SQL, conn);
                adapter.SelectCommand = command;
                return adapter;
            }
        }

        /**/
        /// <summary>   
        /// 执行SQL命令，不需要返回数据的修改，删除可以使用本函数   
        /// </summary>   
        /// <param name="SQL"></param>   
        /// <returns></returns>   
        public static bool ExecuteSQLNonquery(string SQL)
        {
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(SQL, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public static int InsertAccess<T>(T entity, string tableName) where T : new()
        {
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                int r = 0;
                try
                {


                    StringBuilder sbName = new StringBuilder();
                    StringBuilder sbValue = new StringBuilder();
                    Type type = typeof(T);
                    PropertyInfo[] ps = type.GetProperties();
                    foreach (PropertyInfo p in ps)
                    {
                        object value = p.GetValue(entity, null);
                        if (value != null)
                        {
                            sbName.Append("[" + p.Name + "]");

                            sbName.Append(",");
                            Type t = p.PropertyType;
                            if (t.ToString() == "System.String" || t.ToString() == "System.DateTime")
                            {
                                sbValue.Append("'" + value + "'");
                            }
                            else
                            {
                                sbValue.Append(value);
                            }

                            sbValue.Append(",");
                        }
                    }

                    string sql = "insert into " + tableName + @" (" + sbName.ToString().TrimEnd(',') + ") values" + @"(" + sbValue.ToString().TrimEnd(',') + ")";
                    // Conn.Open();
                    OleDbCommand command = new OleDbCommand(sql, conn);
                    // Conn.Close();
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                        r = command.ExecuteNonQuery();
                    }
                    else
                    {
                        r = command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }
                return r;
            }
        }
        #endregion
    }
}
