using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RW.PMS.Web.Remind
{
    /// <summary>
    /// 人员岗位资质自动提醒
    /// </summary>
    internal static class EmployeePostTimeTask
    {
        /// <summary>
        /// 锁
        /// </summary>
        static object _objLock = new object();

        /// <summary>
        /// 是否运行
        /// </summary>
        static bool _isRun = false;

        /// <summary>
        /// 运行
        /// </summary>
        public static void Run()
        {
            lock (_objLock)
            {
                if (!_isRun)
                {
                    AutoRun();

                    _isRun = true;
                }
            }
        }

        /// <summary>
        /// 自动运行
        /// </summary>
        private static void AutoRun()
        {
            Task.Run(() =>
           {
               var systemBLL = DIService.GetService<IBLL_System>();
               var baseBLL = DIService.GetService<IBLL_BaseInfo>();
               //获取所有人员信息
               List<UserModel> userlist = systemBLL.GetUserList(null);
               //获取人员资质提醒ID
               BaseDataModel bdModel = systemBLL.GetbaseData().Where(x => x.bdcode == "UserAptitudeRemind").FirstOrDefault();

               if (bdModel == null) return;

               //获取服务器时间
               DateTime serTime = baseBLL.GetServerDateTime();

               foreach (UserModel item in userlist)
               {
                   if (item.postTime != null)
                   {
                       int ExpireDay = 0;//获取人员资质有效期天数
                       DateTime postTime = item.postTime.Value;
                       TimeSpan sp = Convert.ToDateTime(postTime.ToShortDateString()) - Convert.ToDateTime(serTime.ToShortDateString());
                       ExpireDay = sp.Days;
                       if (ExpireDay < 31)
                       {
                           BaseMsgContentModel model = new BaseMsgContentModel();
                           model.mcTitle = "人员资质有效期提醒";
                           model.mcContent = item.empName + "的岗位资质有效期已到期";
                           model.mcTypeID = bdModel.ID;
                           model.mcLevel = 2;
                           model.mcUrl = "/System/Users?empName=" + item.empName;
                           systemBLL.AddMsgContent(model);
                       }
                   }
               }
           });
        }

    }
}