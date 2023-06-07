using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RW.PMS.Web.Remind
{
    internal static class InventoryExpirationRemind
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
            //Task.Run(() =>
            //{
            //    var systemBLL = DIService.GetService<IBLL_System>();
            //    var baseBLL = DIService.GetService<IBLL_BaseInfo>();
            //    //获取所有人员信息
            //    //List<UserModel> userlist = systemBLL.GetUserList(null);
            //    //获取及时库存提醒ID
            //    BaseDataModel bdModel = systemBLL.GetbaseData().Where(x => x.bdcode == "InventoryRemind").FirstOrDefault();
            //    //获得导入库存的最后更新时间
            //    List<BaseInventoryLogModel> list = baseBLL.GetInventoryLogTime(new BaseInventoryLogModel { remark = "Excel导入库存操作" });
            //    //获取服务器时间
            //    DateTime serTime = baseBLL.GetServerDateTime();
            //    //获取有效库存到期提醒天数
            //    SysconfigModel sysConfigmodel = systemBLL.GetConfigByCode("InventoryReminderDay");
            //    int TimeNumber = Convert.ToInt32(sysConfigmodel.cfg_value);

            //    if (bdModel == null) return;
            //    if (list == null) return;

            //    int ExpireDay = 0;//获取库存数据有效期天数
            //    DateTime logTime = list[0].logTime ?? DateTime.MinValue;
            //    //TimeSpan sp = (Convert.ToDateTime(serTime.ToShortDateString()) - Convert.ToDateTime(logTime.ToShortDateString()));
            //    //ExpireDay = sp.Days;
            //    ExpireDay = (Convert.ToDateTime(serTime.ToShortDateString()) - Convert.ToDateTime(logTime.ToShortDateString())).Days;
            //    if (ExpireDay > TimeNumber)
            //    {
            //        BaseMsgContentModel model = new BaseMsgContentModel();
            //        model.mcTitle = "库存更新提醒";
            //        model.mcContent = "当前库存信息已过期！";
            //        model.mcTypeID = bdModel.ID;
            //        model.mcLevel = 2;
            //        model.mcUrl = "/Material/Inventory";
            //        model.mcRemark = "库存更新提醒";
            //        model.mcDeleteFlag = 0;
            //        systemBLL.AddMsgContent(model);
            //    }
            //});
        }


    }
}