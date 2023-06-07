using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Home
{
    /// <summary>
    /// 人员工时
    /// </summary>
    public class PeopleHourModel
    {
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 工位起始时间
        /// </summary>
        public DateTime? Gw_starttime { get; set; }


        public string Gw_starttimeText
        {
            get
            {
                if (Gw_starttime == null)
                    return "";
                return Gw_starttime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) Gw_starttime = dt;
            }
        }


        /// <summary>
        /// 工位完成时间
        /// </summary>
        public DateTime? Gw_finishtime { get; set; }

        public string Gw_finishtimeText
        {
            get
            {
                if (Gw_finishtime == null)
                    return "";
                return Gw_finishtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) Gw_finishtime = dt;
            }
        }

        /// <summary>
        /// 人员工时
        /// </summary>
        public int? EmpHour { get; set; }
        /// <summary>
        /// 职位状态
        /// </summary>
        public string ZwStatus { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        /// 人员工时 显示具体小时分秒
        /// </summary>
        public string WorkingHours { get; set; }


    }
}
