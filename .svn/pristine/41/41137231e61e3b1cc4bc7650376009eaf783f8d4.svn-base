using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Windows.Forms;
using System.Net;

namespace RW.PMS.Utils.Data
{
    [Obsolete("请使用DbManager")]
    public class DataBase
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand com = new SqlCommand();
        public SqlDataAdapter da = new SqlDataAdapter();
        public SqlCommandBuilder cb = new SqlCommandBuilder();
        int i;
        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <param name="strcon">连接字符串</param>
        private void SqlConnection(string strcon)
        {
            con.ConnectionString = strcon;
            //con.ConnectionTimeout = 3;
        }
        ///
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sqlstr">SQL语句</param>
        /// <returns>返回数据集ds</returns>
        private DataSet selectData(string sqlstr)
        {

            DataSet ds = new DataSet();
            com.CommandText = sqlstr;
            com.Connection = con;
            da.SelectCommand = com;
            try
            {
                ds.Clear();
                try
                {

                    con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("数据库连接失败，请检查服务器是否打开！", "服务器提示。。。。");
                }
                da.Fill(ds);
                cb = new SqlCommandBuilder(da);
                con.Close();
                return ds;
            }
            catch (Exception)
            {
                con.Close();
                // MessageBox.Show("查询失败！！！", "系统提示。。。。");
                return null;
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sqlstr">SQL语句</param>
        /// <returns>返回bool，数据更改是否成功</returns>
        private int updateData(string sqlstr)
        {
            com.CommandText = sqlstr;
            com.Connection = con;
            //com.CommandTimeout = 3;
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception)
            {
                con.Close();
                return 0;
            }

        }
        public static string GetIP()
        {

            IPAddress[] IP = Dns.GetHostAddresses(Dns.GetHostName());
            return IP[0].ToString();
        }


        #region 数据连接属性读取
        private void conn()
        {
            // GetIP();
            XmlDocument xmldoc = new XmlDocument();
            //xmldoc.Load(Server.MapPath("../DBCon.xml"));
            xmldoc.Load(@"./DBCon.xml");//Application.StartupPath +
            XmlElement root = xmldoc.DocumentElement;
            string server, serverhost, database, userid, pws;
            serverhost = GetIP();
            server = root.ChildNodes[0].ChildNodes[0].InnerText;
            if (server != serverhost && server != ".")
            {
                // MessageBox.Show("你连接服务器IP地址为：" + server + " ，是非本机的IP地址！", "服务器提示。。。。", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                DialogResult r = MessageBox.Show("你连接的数据库服务器IP地址为：" + server + " ，是非本机的IP地址！", "服务器提示。。。。", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); ;
                if (r == DialogResult.OK)
                {
                }
                else
                {
                    i = 10;
                }
            }
            database = root.ChildNodes[0].ChildNodes[1].InnerText;
            userid = root.ChildNodes[0].ChildNodes[2].InnerText;
            pws = root.ChildNodes[0].ChildNodes[3].InnerText;
            string strcon;
            //strcon = "server=" + server + ";database=" + database + ";integrated security=sspi";
            strcon = "Persist Security Info=False;Connection Timeout =2;User ID=" + userid + ";Password=" + pws + ";Connection Timeout = 2;Initial Catalog=" + database + ";Server=" + server;
            SqlConnection(strcon);
        }
        #endregion

        #region 数据查询
        /// <summary>
        /// 数据查询方法调用
        /// </summary>
        /// <param name="strsql">SQL语句</param>
        /// <returns></returns>
        public DataSet GetData(string strsql)
        {
            DataSet ds = null;
            conn();
            if (i == 10)
            {
            }
            else
            {
                ds = selectData(strsql);
            }
            i = 0;
            return ds;
        }
        #endregion

        #region 数据修改
        /// <summary>
        /// 数据修改方法
        /// </summary>
        /// <param name="strsql">SQL语句</param>
        /// <returns></returns>
        public int DbExecute(string strsql)
        {

            conn();
            int b = updateData(strsql);
            return b;

        }
        #endregion


    }
}
