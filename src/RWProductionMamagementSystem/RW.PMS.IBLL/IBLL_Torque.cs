using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.Torque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.IBLL
{
    public interface IBLL_Torque: IDependence
    {
        /// <summary>
        /// 扭矩基础信息分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<TorqueTool> GetTorquePageList(TorqueTool model,out int totalCount);

        /// <summary>
        /// 保存扭矩基础信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveTorqueTool(TorqueTool model);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id">用户ID</param>
        void TorqueToolDelete(string id);

        /// <summary>
        ///查询当天的试验台测试数据
        /// </summary>
        /// <returns></returns>
        List<torque_jianding> JDListTo_Days();

        /// <summary>
        /// 保存扭矩校验信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveTorqueTestInfo(torque_jianding model);
        /// <summary>
        ///查询所有校验工具数据
        /// </summary>
        /// <returns></returns>
        List<TorqueTool> JDListAll();
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<torque_jianding> GetPagingBaseJD(torque_jianding model, out int totalCount);

        /// <summary>
        /// 根据ID查询校验工具信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        TorqueTool GetTorqueToolId(int Id);
        /// <summary>
        ///根据工具编码查询当天的试验台测试数据
        /// </summary>
        /// <returns></returns>
        torque_jianding JDListTo_DaysByCode(string ID);
    }
}
