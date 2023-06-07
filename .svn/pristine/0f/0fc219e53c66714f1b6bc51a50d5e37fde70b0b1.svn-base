using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace RW.PMS.Utils.Data
{
    public static class OleDBHelper
    {
        public static string SqlDirectory;
        public static string DataPath;

        [Obsolete("请使用CreateDB")]
        public static string Genator(string sqlDirectory, string connectionString)
        {
            return CreateDB(sqlDirectory, connectionString);
        }

        [Obsolete("请使用CreateDB")]
        public static string Genator()
        {
            return CreateDB();
        }

        public static string CreateDB()
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\{0};jet oledb:database password=ok";
            return CreateDB(Application.StartupPath + "\\dbTemplate", connectionString);
        }

        public static string CreateDB(string sqlDirectory, string connectionString)
        {
            if (!Directory.Exists(sqlDirectory))
                return null;
            //string[] files = Directory.GetFiles(sqlDirectory, "*.sql");
            StringBuilder sb = new StringBuilder();
            string[] dirs = Directory.GetDirectories(sqlDirectory, "*.mdb");
            foreach (string dir in dirs)
            {
                string[] files = Directory.GetFiles(dir, "*.sql");
                string filename = dir.Substring(dir.LastIndexOf('\\') + 1);

                foreach (string f in files)
                {
                    if (File.Exists(f + ".tmp"))//说明某一次的SQL升级文件已经执行过{
                    {
                        Debug.WriteLine("已经执行过的SQL文件" + f);
                        //File.Delete(f);
                        continue;
                    }

                    string[] lines = File.ReadAllLines(f);
                    //string filename = f.Substring(f.LastIndexOf('\\') + 1, f.LastIndexOf('.') - f.LastIndexOf('\\') - 1);
                    //string connect ionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\" + filename + ";jet oledb:database password=ok";

                    string temp = string.Format(connectionString, filename);
                    OleDB db = new OleDB();
                    db.ConnectionString = temp;
                    db.CreateDatabase(temp);
                    //db.ConnectionString = 
                    db.ConnectionString = temp;
                    foreach (string line in lines)
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(line)) continue;
                            db.ExecuteNonQuery(line);
                        }
                        catch (Exception ex)
                        {
                            sb.AppendLine(ex.Message);
                        }
                    }
                    File.Copy(f, f + ".tmp");
                }
            }
            System.Diagnostics.Debug.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public static string CreateDBBySql(string filename, string sql)
        {
            StringBuilder sb = new StringBuilder();

            OleDB db = new OleDB();
            if (!File.Exists(filename))
                db.CreateDatabase(filename);
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\{0};jet oledb:database password=ok";

            db.ConnectionString = string.Format(connectionString, filename);
            db.CreateDatabase();
            string[] lines = sql.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                try
                {
                    if (string.IsNullOrEmpty(line)) continue;
                    db.ExecuteNonQuery(line);
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ex.Message);
                }
            }
            Debug.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public static string CreateDBBySql(string sql)
        {
            return CreateDBBySql("db.mdb", sql);
        }
    }
}
