using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RW.PMS.DAL;

namespace RW.PMS.Model.Sys
{
    public class LoginInfoModel : BaseModel
    {
        /// <summary>
        /// 登录信息表  LHR
        /// </summary>
        //public LoginInfoModel() { }

        //public LoginInfoModel(sys_loginInfo model)
        //{
        //    this.ID = model.ID;
        //    this.EmpID = model.empID;
        //    this.EmpName = model.empName;
        //    this.Logintime = model.logintime;
        //    this.Unregisttime = model.unregisttime;
        //    this.HostName = model.hostName;
        //    this.Remark = model.remark;
        //}

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 人员编号
        /// </summary>
        public int? empID { get; set; }

        /// <summary>
        /// 人员姓名
        /// </summary>
        public string empName { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? logintime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? unregisttime { get; set; }

        /// <summary>
        /// 计算机名
        /// </summary>
        public string hostName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 时间差
        /// </summary>
        public int? TimeCount { get; set; }


        /// <summary>
        /// 查询类型 - 按当年当月当日等于0 ， 按时间段等于1
        /// </summary>
        public string queryType { get; set; }


        /// <summary>
        /// 当日=day , 当月=month , 当年=year
        /// </summary>
        public string ddldate { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string starttime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string endtime { get; set; }

        public int? dateYear { get; set; }

        public int? dateMonth { get; set; }

        public int? dateDay { get; set; }


        public string empNo { get; set; }
    }
}
