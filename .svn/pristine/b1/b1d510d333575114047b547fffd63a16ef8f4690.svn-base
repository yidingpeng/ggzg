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
    /// 设备到期提醒
    /// </summary>
    internal static class DeviceExpirationRemind
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
               var baseBLL = DIService.GetService<IBLL_BaseInfo>();
               var systemBLL = DIService.GetService<IBLL_System>();
               var devBLL = DIService.GetService<IBLL_Device>();

               //获取设备器具到期提醒ID
               BaseDataModel bdModel = systemBLL.GetbaseData().Where(x => x.bdcode == "DeviceRemind").FirstOrDefault();
               if (bdModel == null) return;

               //获取服务器时间
               DateTime serTime = systemBLL.GetDateTime();

               //每次登录自动更新设备器具到期状态
               baseBLL.LoadToolsStatus();

               //获取设备到期提醒数据
               List<BaseToolsModel> ToolsList = devBLL.GetToolsRemindCount();
               if(ToolsList.Count>0)
               {
                   foreach (BaseToolsModel item in ToolsList)
                   {
                       BaseMsgContentModel model = new BaseMsgContentModel();
                       model.mcTitle = "设备器具到期提醒";
                       model.mcContent = string.Format("系统编号[{0}]设备名称[{1}]器具[{2}]{3},请及时送检",item.ID,item.DevName,item.ToolName,item.Status);
                       model.mcTypeID = bdModel.ID;
                       model.mcLevel = 2;
                       model.mcUrl = "/BaseInfo/EditBaseTools?id=" + item.ID;
                       systemBLL.AddMsgContent(model);
                   }
               }

           });
        }
    }
}