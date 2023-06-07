using System;
using System.Collections.Generic;
using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;

namespace RW.PMS.IDAL
{
    public interface IDAL_ProgramInfo : IDependence
    {

        /// <summary>
        /// 程序名称是否重复
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        bool IsProgramNameDouble(string programName, int id = 0);

        /// <summary>
        /// 获取程序配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Program GetBaseProgramDeatil(int id);

        Program GetBaseProgramDeatilByDef(int gw_prod_def_Id);

        /// <summary>
        /// 获取程序配置信息列表
        /// </summary>
        /// <param name="programName"></param>
        /// <param name="gwID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PageModel<List<Program>> GetBaseProgramList(string programName, int gwID, int PmodelId, int pageIndex, int pageSize);

        /// <summary>
        /// 添加程序配置信息
        /// </summary>
        /// <param name="program"></param>
        void AddBaseProgram(BaseProgram program);

        /// <summary>
        /// 复制添加程序信息
        /// </summary>
        /// <param name="copyID">复制ID</param>
        /// <param name="program"></param>
        void CopyBaseProgram(int copyID, BaseProgram program);

        /// <summary>
        /// 编辑程序配置信息
        /// </summary>
        /// <param name="program"></param>
        void EditBaseProgram(BaseProgram program);

        /// <summary>
        /// 删除程序配置信息   加一个参数，同时删除关联表
        /// </summary>
        /// <param name="id"></param>
        void DeleteBaseProgram(int gw_prod_defid);

        /// <summary>
        /// 获取程序工序工步列表
        /// </summary>
        /// <param name="programID"></param>
        List<ProGXGBModel> ProgGXGBList(int programID);

        /// <summary>
        /// 用于导出工序工步Excel
        /// </summary>
        /// <param name="programID"></param>
        /// <returns></returns>
        List<ProGXGBExportModel> ProgGXGBExportList(int programID);

        /// <summary>
        /// 获取程序工具列表
        /// </summary>
        /// <param name="programID"></param>
        List<ProGJValModel> ProgGJValList(int programID);

        // <summary>
        /// 获取工步图片
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        Byte[] GetGBImage(int gbID);

        List<VideoModel> GetVideoByIP(string ipAddress);

        /// <summary>
        /// 条件查询工艺(精确到工步)
        /// Add By Leon 20191010
        /// </summary>
        /// <param name="model">包含产品型号ID,部件ID等查询条件</param>
        /// <returns>实体类数据集合</returns>
        List<ProGXGBModel> GetWorkStepList(ProGXGBModel model);
    }
}
