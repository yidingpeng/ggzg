using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Torque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.BLL
{
    internal class BLL_Torque: IBLL_Torque
    {
        private IDAL_Torque _DAl = null;
        public BLL_Torque()
        {
            _DAl = DIService.GetService<IDAL_Torque>();
        }

        /// <summary>
        /// 扭矩基础信息分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TorqueTool> GetTorquePageList(TorqueTool model, out int totalCount)
        {
            return _DAl.GetTorquePageList(model,out totalCount);
        }

        /// <summary>
        /// 保存扭矩基础信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTorqueTool(TorqueTool model)
        {
            return _DAl.SaveTorqueTool(model);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id">用户ID</param>
        public void TorqueToolDelete(string id)
        {
            _DAl.TorqueToolDelete(id);
        }

        /// <summary>
        ///查询当天的试验台测试数据
        /// </summary>
        /// <returns></returns>
        public List<torque_jianding> JDListTo_Days()
        {
            return _DAl.JDListTo_Days();
        }

        /// <summary>
        /// 保存扭矩校验信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTorqueTestInfo(torque_jianding model)
        {
            return _DAl.SaveTorqueTestInfo(model);
        }

        /// <summary>
        ///查询所有校验工具数据
        /// </summary>
        /// <returns></returns>
        public List<TorqueTool> JDListAll()
        {
            return _DAl.JDListAll();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<torque_jianding> GetPagingBaseJD(torque_jianding model, out int totalCount)
        {
            return _DAl.GetPagingBaseJD(model,out totalCount);
        }

        /// <summary>
        /// 根据ID查询校验工具信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        public TorqueTool GetTorqueToolId(int Id)
        {
            return _DAl.GetTorqueToolId(Id);
        }
        /// <summary>
        ///根据工具编码查询当天的试验台测试数据
        /// </summary>
        /// <returns></returns>
        public torque_jianding JDListTo_DaysByCode(string ID)
        {
            return _DAl.JDListTo_DaysByCode(ID);
        }
    }
}
