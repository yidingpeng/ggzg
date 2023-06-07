using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.BLL
{
    internal class BLL_ReportTemplate : IBLL_ReportTemplate
    {
        private IDAL_ReportTemplate _DAL = null;

        public BLL_ReportTemplate()
        {
            _DAL = DIService.GetService<IDAL_ReportTemplate>();
        }

        /// <summary>
        /// 获取生产记录报告模板列表
        /// </summary>
        /// <returns></returns>
        public PageModel<List<RepTemplateModel>> GetRepTemplateList(int? pModelID, int pageSize = 10, int pageIndex = 1)
        {
            return _DAL.GetRepTemplateList(pModelID, pageSize, pageIndex);
        }

        /// <summary>
        /// 获取生产记录报告模板明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public RepTemplateModel GetRepTemplateDetail(int ID)
        {
            return _DAL.GetRepTemplateDetail(ID);
        }
        /// <summary>
        /// 获取生产记录报告模板明细 根据产品型号ID
        /// </summary>
        /// <param name="pModelID"></param>
        /// <returns></returns>
        public RepTemplateModel GetRepTemplateDetailByProdModelID(int pModelID)
        {
            return _DAL.GetRepTemplateDetailByProdModelID(pModelID);
        }

        /// <summary>
        /// 更新生产记录报告模板
        /// </summary>
        /// <param name="model"></param>
        public void UpdateRepTemplate(RepTemplateModel model)
        {
            _DAL.UpdateRepTemplate(model);
        }

        /// <summary>
        /// 删除生产记录报告模板
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteRepTemplate(int ID)
        {
            _DAL.DeleteRepTemplate(ID);
        }

        /// <summary>
        /// 删除报告模板
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteRepTemplBindSource(int ID)
        {
            _DAL.DeleteRepTemplBindSource(ID);
        }

        /// <summary>
        /// 获取获取报告模板 明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public RepTemplBindSourceModel GetRepTemplBindSourceDetail(int ID)
        {
            return _DAL.GetRepTemplBindSourceDetail(ID);
        }

        /// <summary>
        /// 获取报告模板 
        /// </summary>
        /// <param name="pmodelID"></param>
        /// <returns></returns>
        public PageModel<List<RepTemplBindSourceModel>> GetRepTemplBindSourceList(int? pmodelID, int? typeID, int pageSize = 10, int pageIndex = 1)
        {
            return _DAL.GetRepTemplBindSourceList(pmodelID, typeID, pageSize, pageIndex);
        }
        
        /// <summary>
        /// 获取绑定类型列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetBindTypes(int ID)
        {
            return _DAL.GetBindTypes(ID);
        }

        /// <summary>
        /// 更新报告模板 
        /// </summary>
        /// <param name="models"></param>
        public void UpdateRepTemplBindSource(RepTemplBindSourceModel model)
        {
            _DAL.UpdateRepTemplBindSource(model);
        }
    }
}
