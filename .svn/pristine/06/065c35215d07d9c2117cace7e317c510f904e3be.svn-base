using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Diagnostics;

namespace RW.PMS.Utils.Data
{
    /// <summary>
    /// 使用OleDbConnection连接字符串，主要用于Access数据库。
    /// </summary>
    public class OleDB : DbBase<OleDbConnection, OleDbCommand, OleDbDataAdapter>, IDbBase
    {
        public OleDB()
        {

        }

        public OleDB(string source)
            : base(source)
        {

        }

        public void CreateDatabase()
        {
            this.CreateDatabase(this.ConnectionString);
        }

        public void  CreateDatabase(string connectionString)
        {
            try
            {
                ADOX.Catalog c = new ADOX.Catalog();
                c.Create(connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
