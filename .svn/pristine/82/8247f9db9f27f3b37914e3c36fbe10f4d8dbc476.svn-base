using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.InComming
{
    public class InCommingModel : BaseModel
    {
        //检修记录表 产品生产主表 产品生产基础表

        #region follow_main	--检修追溯主表

        /// <summary>
        /// 生产GUID
        /// </summary>
        public Guid fm_guid { get; set; }

        /// <summary>
        /// 产品生产主表GUID
        /// </summary>
        public Guid? fp_guid { get; set; }

        /// <summary>
        /// 产品生产基础表ID
        /// </summary>
        public int? pInfo_ID { get; set; }

        /// <summary>
        /// 开始检修时间
        /// </summary>
        public DateTime? fm_starttime { get; set; }

        /// <summary>
        /// 完成检修时间
        /// </summary>
        public DateTime? fm_finishtime { get; set; }

        /// <summary>
        /// 追溯状态 0:未完成；1:已完成,未发货，2:异常下线；3：重新装配; 4:已发货；
        /// </summary>
        public int? fm_finishStatus { get; set; }

        /// <summary>
        /// 成品缓存区的仓库工位
        /// </summary>
        public string fm_warehouse { get; set; }

        /// <summary>
        /// 是否发货
        /// </summary>
        public int? fm_isSend { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime? fm_sendTime { get; set; }

        /// <summary>
        /// 发货人
        /// </summary>
        public int? fm_sender { get; set; }

        /// <summary>
        /// 当前生产区域，数据字典区域ID
        /// </summary>
        public int? fm_curAreaID { get; set; }

        /// <summary>
        /// 查询当前区域和上一个区域集合
        /// </summary>
        public string AreaArrID { get; set; }

        /// <summary>
        /// 当前生产工位ID
        /// </summary>
        public int? fm_curGwID { get; set; }

        /// <summary>
        /// 当前生产工位
        /// </summary>
        public string fm_curGw { get; set; }

        /// <summary>
        /// 信息创建人ID
        /// </summary>
        public int? fm_creatorID { get; set; }

        /// <summary>
        /// 信息创建人
        /// </summary>
        public string fm_creator { get; set; }

        /// <summary>
        /// 质量结果
        /// </summary>
        public int? fm_resultIsOK { get; set; }

        /// <summary>
        /// 结果说明
        /// </summary>
        public string fm_resultMemo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string fm_remark { get; set; }

        /// <summary>
        /// 上传标志
        /// </summary>
        public int? fm_uploadFlag { get; set; }

        #endregion

        #region follow_detail 检修追溯明细表

        /// <summary>
        /// 生产GUID
        /// </summary>
        public Guid fd_guid { get; set; }

        /// <summary>
        /// 工位生产GUID
        /// </summary>
        public Guid fgw_guid { get; set; }

        /// <summary>
        /// 组件ID
        /// </summary>
        public int fd_componentId { get; set; }

        /// <summary>
        /// 组件名称
        /// </summary>
        public string fd_componentName { get; set; }

        /// <summary>
        /// 工位ID
        /// </summary>
        public int fd_gwID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string fd_gwName { get; set; }

        /// <summary>
        /// 区域ID
        /// </summary>
        public int fd_areaID { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string fd_areaName { get; set; }

        /// <summary>
        /// 条码卡号
        /// </summary>
        public string fd_barcode { get; set; }

        /// <summary>
        /// 物料/零件ID
        /// </summary>
        public int fd_wuliaoLJid { get; set; }

        /// <summary>
        /// 物料/零件名称
        /// </summary>
        public string fd_wuliaoLJName { get; set; }

        /// <summary>
        /// 是否为物料盒
        /// </summary>
        public int fd_isWuliaoBox { get; set; }

        /// <summary>
        /// 物料钢印号/二维码
        /// </summary>
        public string fd_stampNo { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        public int fd_operID { get; set; }

        /// <summary>
        /// 操作员名称
        /// </summary>
        public string fd_oper { get; set; }

        /// <summary>
        /// 开始检修时间
        /// </summary>
        public DateTime? fd_starttime { get; set; }

        /// <summary>
        /// 完成检修时间
        /// </summary>
        public DateTime? fd_finishtime { get; set; }

        /// <summary>
        /// 追溯状态:0:未完成；1:完成，2:异常下线；3：重新装配
        /// </summary>
        public int fd_followStatus { get; set; }

        /// <summary>
        /// 检验结果:-1:空；0:不合格；1：合格；
        /// </summary>
        public int fd_checkResult { get; set; }

        /// <summary>
        /// 检验数量
        /// </summary>
        public int fd_resultQty { get; set; }

        /// <summary>
        /// 结果说明,结果原因	
        /// </summary>
        public string fd_resultMemo { get; set; }

        /// <summary>
        /// 下一区域扫码状态：0未扫；1已扫
        /// </summary>
        public int fd_isNextScan { get; set; }

        /// <summary>
        /// 是否撤销，0：不撤销；1：已撤销
        /// </summary>
        public int fd_isCancel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string fd_remark { get; set; }

        /// <summary>
        /// 上传标志
        /// </summary>
        public int fd_uploadFlag { get; set; }

        #endregion

        #region follow_production --产品生产主表

        /// <summary>
        /// 产品生产基础表ID
        /// </summary>
        public int fp_pInfo_ID { get; set; }

        /// <summary>
        /// 系统产品编号，不可重复，系统自动生成（规则：产品编号_2位编码），用于二次检修或组装
        /// </summary>
        public string fp_prodNo_sys { get; set; }


        /// <summary>
        /// 检修类型
        /// </summary>
        public int? fp_repairTypeID { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? fp_startTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? fp_finishTime { get; set; }

        /// <summary>
        /// 产品完成状态：0：未完成，1：已完成，2：异常下线，3：重新装配 4：返回上一步; 5:例外转序
        /// </summary>
        public int fp_finishStatus { get; set; }

        /// <summary>
        /// 质量结果
        /// </summary>
        public int fp_resultIsOK { get; set; }

        /// <summary>
        /// 结果说明
        /// </summary>
        public string fp_resultMemo { get; set; }

        /// <summary>
        /// 产品生产线完成情况报表存放路径
        /// </summary>
        public byte[] fp_report { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string fp_remark { get; set; }

        /// <summary>
        /// 上传标志
        /// </summary>
        public int fp_uploadFlag { get; set; }


        #endregion

        #region productInfo	--产品生产基础表

        /// <summary>
        /// 产品生产基础ID
        /// </summary>
        public int pf_ID { get; set; }

        /// <summary>
        /// 产品编号,二次生产时可重复	
        /// </summary>
        public string pf_prodNo { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int pf_prodID { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? pf_prodModelID { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public int? pf_carModelID { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string pf_carNo { get; set; }

        /// <summary>
        /// 产品订单号
        /// </summary>
        public string pf_orderNo { get; set; }

        /// <summary>
        /// 编组
        /// </summary>
        public string pf_groupNo { get; set; }

        /// <summary>
        /// 厂商
        /// </summary>
        public int? pf_factoryID { get; set; }

        /// <summary>
        /// 主部件钢印号
        /// </summary>
        public string pf_stampNo { get; set; }

        /// <summary>
        /// 产品日期
        /// </summary>
        public DateTime? pf_date { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public string pf_weight { get; set; }

        /// <summary>
        /// 压缩机的出厂编号
        /// </summary>
        public string pf_compressor { get; set; }

        /// <summary>
        /// 转向架编号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_bogieNo { get; set; }

        /// <summary>
        /// 缓存区标识: 0.未在缓存区 1.已在缓存区
        /// </summary>
        public int? pf_cacheFlag { get; set; }

        /// <summary>
        /// 缓存区标识: 0.未在缓存区 1.已在缓存区
        /// </summary>
        public string pf_cacheText
        {
            get
            {
                if (this.pf_cacheFlag == 1)
                    return "已入缓存区";
                else
                    return "未入缓存区";
            }
        }

        /// <summary>
        /// 地铁线路ID,取数据字典表
        /// </summary>
        public int? pf_metroLineID { get; set; }

        /// <summary>
        /// 地铁线路 取数据字典表
        /// </summary>
        public string pf_metroLine { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string pf_remark { get; set; }

        #endregion

        #region plan_prod 计划主表

        /// <summary>
        /// 产品计划表GUID
        /// </summary>
        public Guid? pp_guid { get; set; }

        /// <summary>
        /// 是否已开始检修或生产,0：未开始；1：已开始；如已开始就不显示在来料区的计划列表中
        /// </summary>
        public int? pp_isStart { get; set; }

        /// <summary>
        /// 是否已开始检修或生产,0：未开始；1：已开始；如已开始就不显示在来料区的计划列表中
        /// </summary>
        public string pp_isStartText
        {
            get
            {
                if (this.pp_isStart == 1) return "已开始";
                else return "未开始";
            }
        }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? pp_startDate { get; set; }

        /// <summary>
        /// 计划开始时间(文本)
        /// </summary>
        public string pp_startDateText
        {
            get
            {
                if (this.pp_startDate.HasValue)
                {
                    return this.pp_startDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return "";
            }
        }

        /// <summary>
        /// 计划完成日期
        /// </summary>
        public DateTime? pp_finishDate { get; set; }

        /// <summary>
        /// 计划完成日期(文本)
        /// </summary>
        public string pp_finishDateText
        {
            get
            {
                if (this.pp_finishDate.HasValue)
                {
                    return this.pp_finishDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return "";
            }
        }

        /// <summary>
        /// 计划表备注
        /// </summary>
        public string pp_remark { get; set; }
        #endregion

        /// <summary>
        /// 型号
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public string Pname { get; set; }

        /// <summary>
        /// 检修类型
        /// </summary>
        public string fp_repairTypeName { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string fm_curAreaName { get; set; }

        /// <summary>
        /// 发货人
        /// </summary>
        public string fm_senderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string isSend
        {
            get
            {
                if (fm_isSend != 0)
                {
                    return "已发货";
                }
                return "未发货";
            }
        }

        /// <summary>
        /// 厂商
        /// </summary>
        public string factory { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string carModel { get; set; }

        /// <summary>
        /// 产品完成状态
        /// </summary>
        public string finishStatus
        {
            get
            {
                if (fm_finishStatus == 1)
                {
                    return "已完成";
                }
                if (fm_finishStatus == 2)
                {
                    return "异常下线";
                }
                if (fm_finishStatus == 3)
                {
                    return "重新装配";
                }
                if (fm_finishStatus == 4)
                {
                    return "已发货";
                }
                if (fm_finishStatus == 5)
                {
                    return "已入场";
                }
                return "未完成";
            }
        }

        /// <summary>
        /// 检修结果
        /// </summary>
        public string fmresultIsOK
        {
            get
            {
                if (fm_resultIsOK == 1)
                {
                    return "合格";
                }
                if (fm_resultIsOK == 0)
                {
                    return "不合格";
                }
                return "";
            }
        }

        /// <summary>
        /// 区域ID
        /// </summary>
        public int? fgw_areaID { get; set; }


    }
}
