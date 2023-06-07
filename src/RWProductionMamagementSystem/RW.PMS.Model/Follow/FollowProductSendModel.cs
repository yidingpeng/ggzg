using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 发货区查询实体
    /// </summary>
    public class FollowProductSendModel
    {

        #region follow_main 检修追溯主表

        /// <summary>
        /// 检修业务产品GUID
        /// </summary>
        public Guid fm_guid { get; set; }

        /// <summary>
        /// 产品生产（组装、检修）主表GUID，follow_production.fp_guid
        /// </summary>
        public Guid fp_guid { get; set; }

        /// <summary>
        /// 产品信息ID，productInfo.pf_ID，冗余
        /// </summary>
        public int? pInfo_ID { get; set; }

        /// <summary>
        /// 入场时间
        /// </summary>
        public DateTime? fm_inHouseTime { get; set; }

        /// <summary>
        /// 开始检修时间
        /// </summary>
        public DateTime? fm_starttime { get; set; }

        /// <summary>
        /// 完成检修时间
        /// </summary>
        public DateTime? fm_finishtime { get; set; }

        /// <summary>
        /// 追溯状态:0:未完成；1:已完成,未发货，2:异常下线；3：重新装配; 4:已发货；5：已入场（未开始检修）
        /// </summary>
        public int? fm_finishStatus { get; set; }

        /// <summary>
        /// 追溯状态文本值
        /// </summary>
        public string fmStatus
        {
            get
            {
                if (fm_finishStatus == 0) { return "未完成"; }
                if (fm_finishStatus == 1) { return "已完成,未发货"; }
                if (fm_finishStatus == 2) { return "异常下线"; }
                if (fm_finishStatus == 3) { return "重新装配"; }
                if (fm_finishStatus == 4) { return "已发货"; }
                if (fm_finishStatus == 5) { return "已入场"; }
                return "";
            }
        }

        /// <summary>
        /// 成品缓存区的仓库工位
        /// </summary>
        public string fm_warehouse { get; set; }

        /// <summary>
        /// 当前生产区域，数据字典区域ID
        /// </summary>
        public int? fm_curAreaID { get; set; }

        /// <summary>
        /// 当前生产区域名称
        /// </summary>
        public string curAreaText { get; set; }

        /// <summary>
        /// 当前生产工位ID
        /// </summary>
        public int? fm_curGwID { get; set; }

        /// <summary>
        /// 当前生产工位
        /// </summary>
        public string fm_curGw { get; set; }

        /// <summary>
        /// 信息创建人，employee.ID
        /// </summary>
        public int? fm_creatorID { get; set; }

        /// <summary>
        /// 信息创建人，employee.ID
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

        #endregion


        #region productInfo 生产产品基础表

        /// <summary>
        /// 生产信息
        /// </summary>
        public int pf_ID { get; set; }

        /// <summary>
        /// 产品编号,二次生产时可重复 电机编号
        /// </summary>
        public string pf_prodNo { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? pf_prodID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Pname { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? pf_prodModelID { get; set; }

        /// <summary>
        /// 型号名称
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 地铁信息ID，subwayInfo.ID
        /// </summary>
        public int? pf_subwayInfoID { get; set; }

        /// <summary>
        /// 产品订单号
        /// </summary>
        public string pf_orderNo { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pf_bogieNo { get; set; }

        /// <summary>
        /// 厂商, 取数据字典表
        /// </summary>
        public int? pf_factoryID { get; set; }

        /// <summary>
        /// 厂商名称
        /// </summary>
        public string factoryText { get; set; }

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
        /// 备注
        /// </summary>
        public string pf_remark { get; set; }

        #endregion


        #region follow_production 生产主表

        /// <summary>
        /// 生产GUID
        /// </summary>
        //public Guid fp_guid { get; set; }

        /// <summary>
        /// 产品生产计划表GUID
        /// </summary>
        public Guid pp_guid { get; set; }

        /// <summary>
        /// 产品信息ID，productInfo.pf_ID
        /// </summary>
        public int? fp_pInfo_ID { get; set; }

        /// <summary>
        /// 系统产品编号，不可重复，系统自动生成（规则：产品编号_2位编码），用于二次检修或组装
        /// </summary>
        public string fp_prodNo_sys { get; set; }

        /// <summary>
        /// 检修类型（大修、小修），取数据字典,字典编码:repairType
        /// </summary>
        public int? fp_repairTypeID { get; set; }

        /// <summary>
        /// 检修类型名称
        /// </summary>
        public string repairTypeText { get; set; }

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
        public int? fp_finishStatus { get; set; }

        /// <summary>
        /// 质量结果
        /// </summary>
        public int? fp_resultIsOK { get; set; }

        /// <summary>
        /// 结果说明
        /// </summary>
        public string fp_resultMemo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string fp_remark { get; set; }

        /// <summary>
        /// 上传标志
        /// </summary>
        public int? fp_uploadFlag { get; set; }


        #endregion

        #region subwayInfo 车辆表

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public int carNo { get; set; }

        /// <summary>
        /// 车号系统编号
        /// </summary>
        public int carNo_sys { get; set; }

        /// <summary>
        /// 地铁线路
        /// </summary>
        public int subwayNo { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public int subwayType { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string subwayTypeText { get; set; }

        /// <summary>
        /// 编组
        /// </summary>
        public int groups { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int prodModelID { get; set; }

        /// <summary>
        /// 电机数量
        /// </summary>
        public int motorCnt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public int remark { get; set; }

        #endregion


        #region follow_send 发货表

        /// <summary>
        /// 检修主GUID	
        /// </summary>
        //public Guid fm_guid { get; set; }

        /// <summary>
        /// 产品生产（组装、检修）主表GUID，follow_production.fp_guid
        /// </summary>
        //public Guid fp_guid { get; set; }

        /// <summary>
        /// 产品信息ID，productInfo.pf_ID，冗余
        /// </summary>
        //public int? pInfo_ID { get; set; }

        /// <summary>
        /// 检修完成后安装的车辆信息，取subwayInfo.ID，若各个字段比较后有变化则新增，否则直接取出数据
        /// </summary>
        public int? send_subwayInfoID { get; set; }

        /// <summary>
        /// 检修完成后安装的转向架号
        /// </summary>
        public string send_compartNo { get; set; }

        /// <summary>
        /// 检修完成后安装的车厢号
        /// </summary>
        public string send_bogieNo { get; set; }

        /// <summary>
        /// 是否发货
        /// </summary>
        public int? isSend { get; set; }


        /// <summary>
        /// 是否发货，0 未发货，1，已发货
        /// </summary>
        public string IsSendText
        {
            get
            {
                if (isSend == 1) { return "已发货"; }
                if (isSend == 0) { return "未发货"; }
                return "";
            }
        }

        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime? sendTime { get; set; }

        /// <summary>
        /// 发货人
        /// </summary>
        public int? sender { get; set; }

        /// <summary>
        /// 发货人名称
        /// </summary>
        public string sendText { get; set; }

        #endregion


    }
}
