using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 产品线试验主表
    /// </summary>
    public class ProductTestModel : BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid test_guid { get; set; }
        /// <summary>
        /// 产品生产（组装、检修）主表GUID，follow_production.fp_guid
        /// </summary>
        public Guid? fp_guid { get; set; }
        /// <summary>
        /// 生产编号
        /// </summary>
        public string prod_no { get; set; }
        /// <summary>
        /// 产品信息ID，productInfo.pf_ID，冗余
        /// </summary>
        public int? pInfo_ID { get; set; }
        /// <summary>
        /// 组件编号
        /// </summary>
        public string stampNo { get; set; }
        /// <summary>
        /// 实验台编号
        /// </summary>
        public string labNo { get; set; }
        /// <summary>
        /// 实验台类型
        /// </summary>
        public string labType { get; set; }
        /// <summary>
        /// 试验编号
        /// </summary>
        public string testNo { get; set; }
        /// <summary>
        /// 二维码
        /// </summary>
        public string QRcode { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public int? gwId { get; set; }
        /// <summary>
        /// 工位IP
        /// </summary>
        public string gwIP { get; set; }
        /// <summary>
        /// 组件ID
        /// </summary>
        public int? componentId { get; set; }
        /// <summary>
        /// 组件名称
        /// </summary>
        public string componentName { get; set; }
        /// <summary>
        /// 铭牌编号
        /// </summary>
        public string test_makeNo { get; set; }
        /// <summary>
        /// 操作员Id
        /// </summary>
        public int? test_operID { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string test_oper { get; set; }
        /// <summary>
        /// 负责人Id
        /// </summary>
        public int? test_ownerID { get; set; }
        /// <summary>
        /// 负责人姓名
        /// </summary>
        public string test_owner { get; set; }
        /// <summary>
        /// 审核人Id
        /// </summary>
        public int? test_checkID { get; set; }
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string test_checker { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? test_starttime { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? test_finishtime { get; set; }
        /// <summary>
        /// 产品试验结果，0:不合格；1：合格；必传	
        /// </summary>
        public int? test_resultIsOK { get; set; }
        /// <summary>
        /// 产品试验结果文本值
        /// </summary>
        public string ResultIsOK { get {
            if (test_resultIsOK == 0)
                return "不合格";
            if (test_resultIsOK == 1)
                return "合格";
        
            return "";
        } }
        /// <summary>
        /// 结果说明	，不合格；合格；  必传
        /// </summary>
        public string test_resultMemo { get; set; }
        /// <summary>
        /// 报表图片
        /// </summary>
        public byte[] test_reprtImg { get; set; }
        /// <summary>
        /// 报表文件
        /// </summary>
        public byte[] test_reprtFile { get; set; }
        /// <summary>
        /// 报表名称
        /// </summary>
        public string Test_reportName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string test_remark { get; set; }
        /// <summary>
        /// 上传标志
        /// </summary>
        public int? test_uploadFlag { get; set; }




        /// <summary>
        /// 试验标准编号
        /// </summary>
        public int? StandardID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProdName { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProdModel { get; set; }
        /// <summary>
        /// 标准描述
        /// </summary>
        public string StandardMemo { get; set; }

      

    }
}
