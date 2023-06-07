using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace RW.PMS.Utils.Data
{
    public static class SQLiteHelper
    {
        public static string SqlDirectory;
        public static string DataPath;

        [Obsolete("请使用CreaetDB")]
        public static string Genator(string sqlDirectory)
        {
            return CreateDB(sqlDirectory);
        }

        [Obsolete("请使用CreateDBBySql")]
        public static string GenatorSingle(string dbFilename, string txtFile)
        {
            return CreateDBBySql(dbFilename, txtFile);
        }

        [Obsolete("请使用CreaetDB")]
        public static string Genator()
        {
            //string connectionString = Application.StartupPath + "\\" + connectionString;
            return Genator(Application.StartupPath + "\\dbTemplate");
        }

        public static string CreateDBBySql(string filename, string sql)
        {
            StringBuilder sb = new StringBuilder();

            SQLiteDB db = new SQLiteDB();
            if (!File.Exists(filename))
                db.CreateDatabase(filename);
            db.ConnectionString = "Data Source=" + filename + ";Version=3;";

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
            return CreateDBBySql("rw.db", sql);
        }

        public static string CreateDB(string directory)
        {
            if (!Directory.Exists(directory))
                return null;
            StringBuilder sb = new StringBuilder();
            string[] dirs = Directory.GetDirectories(directory, "*.db");
            foreach (string dir in dirs)
            {
                string[] files = Directory.GetFiles(dir, "*.sql");
                string filename = dir.Substring(dir.LastIndexOf('\\') + 1);

                foreach (string f in files)
                {
                    try
                    {
                        if (File.Exists(f + ".tmp"))//说明某一次的SQL升级文件已经执行过{
                        {
                            Debug.WriteLine("已经执行过的SQL文件" + f);
                        }
                        string txt = File.ReadAllText(f);

                        CreateDBBySql(filename, txt);

                        File.Copy(f, f + ".tmp");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine(ex.ToString());
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public static string CreateDB()
        {
            return CreateDB(Application.StartupPath + "\\dbTemplate");
        }
    }
}
