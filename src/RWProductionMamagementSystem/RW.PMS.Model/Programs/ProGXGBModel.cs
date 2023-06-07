using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model.Follow;
using RW.PMS.Model.BaseInfo;

namespace RW.PMS.Model
{
    public partial class ProGXGBModel
    {
        public int RowID { get; set; }

        public string GXNameGroup {get; set; }

        /// <summary>
        /// 工序ID
        /// </summary>
       // public int gxID { get; set; }

        /// <summary>
        /// 工步ID
        /// </summary>
      //  public int? gbID { get; set; }

        /// <summary>
        /// 配置程序工序ID
        /// </summary>
        public int? progGXID { get; set; }

        /// <summary>
        /// 配置程序工步ID
        /// </summary>
        public int? progGBID { get; set; }

        /// <summary>
        /// 工步名称
        /// </summary>
        public string gbname { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string gxname { get; set; }

        public string Descript { get; set; }

        /// <summary>
        /// 工步描述
        /// </summary>
        public string gbdesc { get; set; }

        public byte[] gbimg { get; set; }

        public string GXVedio { get; set; }

        public string GxvedioFilename { get; set; }

        public int? IsScan { get; set; }

        /// <summary>
        /// 要录产品信息标识 0：不需要录 1：要录 (是否要弹出录入产品线详细信息)
        /// </summary>
        public int? IsInputPInfo { get; set; }

        public int? IsScanOrderNo { get; set; }

        /// <summary>
        /// 是否需要人工检查是否合格标识
        /// </summary>
        public int? IsEmpCheck { get; set; }

        /// <summary>
        /// 异常类型ID
        /// </summary>
        public int? ErrTypeID { get; set; }

        public string ErrTypeName { get; set; }

        /// <summary>
        /// 管控方式ID
        /// </summary>
        public int? ControlTypeID { get; set; }

        public string ControlTypeName { get; set; }

        public int? PGBInfoStatus { get; set; }

        public int? IfZhuanXu { get; set; }

        /// <summary>
        /// 工位ID
        /// </summary>
        public int? gwID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string gwname { get; set; }

        /// <summary>
        /// 工序序号
        /// </summary>
        public int? gxOrder { get; set; }

        /// <summary>
        /// 工步序号
        /// </summary>
        public int? gbOrder { get; set; }

        /// <summary>
        /// 总装工位标识
        /// </summary>
        public int? IsFinishGW { get; set; }

        /// <summary>
        /// 工步延长时间
        /// </summary>
        public int? GBDelayTime { get; set; }

        public IEnumerable<BaseGongweiOpcModel> OPC { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? prodModelID { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string Pmodel { get;set;}

        /// <summary>
        /// 部件ID
        /// </summary>
        public int? componentID { get; set; }

        /// <summary>
        /// 部件名称
        /// </summary>
        public string partName { get; set; }

        /// <summary>
        /// 程序ID
        /// </summary>
        public int? progID { get; set; }

        /// <summary>
        /// 程序名
        /// </summary>
        public string progName { get; set; }

        public IEnumerable<ProGJValModel> GJWLModels { get; set; }


    }
}
