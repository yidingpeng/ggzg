using RW.PMS.Common;
using RW.PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RW.PMS.IBLL
{
    public interface IBLL_ReportTemplate : IDependence
    {
        /// <summary>
        /// 获取生产记录报告模板列表
        /// </summary>
        /// <returns></returns>
        PageModel<List<RepTemplateModel>> GetRepTemplateList(int? pModelID, int pageSize = 10, int pageIndex = 1);

        // <summary>
        /// 获取生产记录报告模板明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        RepTemplateModel GetRepTemplateDetail(int ID);

        /// <summary>
        /// 获取生产记录报告模板明细 根据产品型号ID
        /// </summary>
        /// <param name="pModelID"></param>
        /// <returns></returns>
        RepTemplateModel GetRepTemplateDetailByProdModelID(int pModelID);

        /// <summary>
        /// 更新生产记录报告模板
        /// </summary>
        /// <param name="model"></param>
        void UpdateRepTemplate(RepTemplateModel model);

        /// <summary>
        /// 删除生产记录报告模板
        /// </summary>
        /// <param name="ID"></param>
        void DeleteRepTemplate(int ID);

        /// <summary>
        /// 删除报告模板
        /// </summary>
        /// <param name="ID"></param>
        void DeleteRepTemplBindSource(int ID);

        /// <summary>
        /// 获取获取报告模板 明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        RepTemplBindSourceModel GetRepTemplBindSourceDetail(int ID);

        /// <summary>
        /// 获取报告模板 
        /// </summary>
        /// <param name="pmodelID"></param>
        /// <returns></returns>
        PageModel<List<RepTemplBindSourceModel>> GetRepTemplBindSourceList(int? pmodelID, int? typeID, int pageSize = 10, int pageIndex = 1);

        /// <summary>
        /// 获取绑定类型列表
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetBindTypes(int ID);

        /// <summary>
        /// 更新报告模板
        /// </summary>
        /// <param name="models"></param>
        void UpdateRepTemplBindSource(RepTemplBindSourceModel models);
        
        
    }
}