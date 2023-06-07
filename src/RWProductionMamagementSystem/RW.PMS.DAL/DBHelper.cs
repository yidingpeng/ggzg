using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.DAL
{
    /// <summary>
    /// 系统级别的数据库帮助类
    /// </summary>
    public class DBHelper
    {
        //static TDMDBDataContext context = new TDMDBDataContext();
        //static RWPMS_DBDataContext context = new RWPMS_DBDataContext();


        static string DBName = "RWAMS";

        /// <summary>
        /// 备份数据库，传入备份文件的绝对路径
        /// </summary>
        /// <param name="path"></param>
        public static void Backup(string path)
        {
            string sql = "use master;";
            sql += "backup database " + DBName + " to disk={0};";
            //context.Database.ExecuteSqlCommand(sql, path);
        }

        /// <summary>
        /// 恢复数据库，传入恢复文件的绝对路径
        /// </summary>
        /// <param name="path"></param>
        public static void Restore(string path)
        {
            string sql = @"USE master;
                    DECLARE @Sql NVARCHAR(max);
                    SET @Sql='';
                    select @Sql=@Sql+'kill '+cast(spid as varchar(50))+';' from sys.sysprocesses where dbid=DB_ID('{1}');
                    EXEC(@Sql);";
            sql += "restore database {1} from disk='{0}' WITH REPLACE;";
            //context.Database.ExecuteSqlCommand(string.Format(sql, path, DBName));
        }
    }
}
