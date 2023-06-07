using RW.PMS.Model.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    public class ReplacementBarcodeModel : BaseBarcodeModel
    {
        /// <summary>
        /// 追溯明细GUID
        /// </summary>
        public Guid Fd_guid { get; set; }
        /// <summary>
        /// 追溯工位GUID
        /// </summary>
        public Guid? Fgw_guid { get; set; }
        /// <summary>
        /// 检修主表GUID
        /// </summary>
        public Guid? Fm_guid { get; set; }

        /// <summary>
        /// 产品生产主表GUID
        /// </summary>
        public Guid? Fp_guid { get; set; }

        /// <summary>
        /// 产品生产基础信息ID
        /// </summary>
        public int PInfo_ID { get; set; }

        /// <summary>
        /// 组件ID
        /// </summary>
        public int? Fd_componentId { get; set; }
        /// <summary>
        /// 组件名称
        /// </summary>
        public string Fd_componentName { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public int? Fd_gwID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string Fd_gwName { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? Fd_areaID { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Fd_areaName { get; set; }
        /// <summary>
        /// 条码卡号
        /// </summary>
        public string Fd_barcode { get; set; }
        /// <summary>
        /// 物料/零件
        /// </summary>
        public int? Fd_wuliaoLJid { get; set; }
        /// <summary>
        /// 物料/零件名称
        /// </summary>
        public string Fd_wuliaoLJName { get; set; }
        /// <summary>
        /// 是否为物料盒
        /// </summary>
        public int? Fd_isWuliaoBox { get; set; }
        /// <summary>
        /// 物料钢印号/二维码
        /// </summary>
        public string Fd_stampNo { get; set; }
        /// <summary>
        /// 操作员ID
        /// </summary>
        public int? Fd_operID { get; set; }
        /// <summary>
        /// 操作员名称
        /// </summary>
        public string Fd_oper { get; set; }
        /// <summary>
        /// 开始检修时间
        /// </summary>
        public DateTime? Fd_starttime { get; set; }
        /// <summary>
        /// 完成检修时间
        /// </summary>
        public DateTime? Fd_finishtime { get; set; }
        /// <summary>
        /// 追溯状态:0:未完成；1:完成，2:异常下线；3：重新装配
        /// </summary>
        public int? Fd_followStatus { get; set; }
        /// <summary>
        /// 检验结果:-1:空；0:不合格；1：合格；
        /// </summary>
        public int? Fd_checkResult { get; set; }
        /// <summary>
        /// 检验数量
        /// </summary>
        public int? Fd_resultQty { get; set; }
        /// <summary>
        /// 结果说明
        /// </summary>
        public string Fd_resultMemo { get; set; }
        /// <summary>
        /// 下一区域扫码状态：0未到；1已到
        /// </summary>
        public int? Fd_isNextScan { get; set; }
        /// <summary>
        /// 是否撤销，0：不撤销；1：已撤销
        /// </summary>
        public int? Fd_isCancel { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Fd_remark { get; set; }
        /// <summary>
        /// 上传标志
        /// </summary>
        public int? Fd_uploadFlag { get; set; }

    }
}
