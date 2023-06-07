using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.IDAL;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.Follow;
using RW.PMS.Common;
using RW.PMS.Model.BaseInfo;

namespace RW.PMS.BLL
{
    internal class BLL_ProgramInfo : IBLL_ProgramInfo
    {

        private IDAL_ProgramInfo _DAL = null;

        public BLL_ProgramInfo()
        {
            _DAL = DIService.GetService<IDAL_ProgramInfo>();
        }

        /// <summary>
        /// 程序名称是否重复
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public bool IsProgramNameDouble(string programName, int id = 0)
        {
            var returnVal = _DAL.IsProgramNameDouble(programName, id);
            return returnVal;
        }

        /// <summary>
        /// 查询程序信息列表
        /// </summary>
        /// <param name="programName">程序名称</param>
        /// <param name="gwID">工位ID</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<List<Program>> GetBaseProgramList(string programName, int gwID, int PmodelId, int pageIndex, int pageSize)
        {
            var list = _DAL.GetBaseProgramList(programName, gwID, PmodelId, pageIndex, pageSize);
            return list;
        }

        /// <summary>
        /// 查询程序信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Program GetBaseProgramDeatil(int id)
        {
            var detail = _DAL.GetBaseProgramDeatil(id);
            return detail;
        }

        public Program GetBaseProgramDeatilByDef(int gw_prod_def_Id)
        {
            var detail = _DAL.GetBaseProgramDeatilByDef(gw_prod_def_Id);
            return detail;
        }


        /// <summary>
        /// 添加程序信息 
        /// </summary>
        /// <param name="program"></param>
        public void AddBaseProgram(BaseProgram program)
        {
            _DAL.AddBaseProgram(program);
        }

        /// <summary>
        /// 复制添加程序信息 
        /// </summary>
        /// <param name="copyID">复制ID</param>
        /// <param name="program"></param>
        public void CopyBaseProgram(int copyID, BaseProgram program)
        {
            _DAL.CopyBaseProgram(copyID, program);
        }

        /// <summary>
        /// 修改程序信息 
        /// </summary>
        /// <param name="program"></param>
        public void EditBaseProgram(BaseProgram program)
        {
            _DAL.EditBaseProgram(program);
        }


        /// <summary>
        /// 删除程序信息  加一个参数，同时删除关联表id2019/05/25
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProgram(int gw_prod_defid)
        {
            _DAL.DeleteBaseProgram(gw_prod_defid);
        }
        /// <summary>
        /// 获取程序工序工步列表 
        /// </summary>
        /// <param name="programID"></param>
        public List<ProGXGBModel> ProgGXGBList(int programID)
        {
            return _DAL.ProgGXGBList(programID);
        }


        /// <summary>
        /// 用于导出工序工步Excel
        /// </summary>
        /// <param name="programID"></param>
        /// <returns></returns>
        public List<ProGXGBExportModel> ProgGXGBExportList(int programID)
        {
            return _DAL.ProgGXGBExportList(programID);
        }

        /// <summary>
        /// 获取程序工具列表
        /// </summary>
        /// <param name="programID"></param>
        public List<ProGJValModel> ProgGJValList(int programID)
        {
            return _DAL.ProgGJValList(programID);
        }

        public Byte[] GetGBImage(int gbID)
        {
            return _DAL.GetGBImage(gbID);
        }

        public List<VideoModel> GetVideoByIP(string IP)
        {
            return _DAL.GetVideoByIP(IP);
        }

        #region 工艺程序显示 Leon

        /// <summary>
        /// 条件查询工艺(精确到工步)
        /// Add By Leon 20191010
        /// </summary>
        /// <param name="model">包含产品型号ID,部件ID等查询条件</param>
        /// <returns>实体类数据集合</returns>
        public List<ProGXGBModel> GetWorkStepList(ProGXGBModel model)
        {
            return _DAL.GetWorkStepList(model);
        }

        #endregion
    }
}
