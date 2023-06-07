using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RW.PMS.DAL;

namespace RW.PMS.Model.BaseInfo
{
    public class GongweiModel : BaseModel
    {
        /// <summary>
        /// 工位信息
        /// LHR
        /// </summary>
        //public GongweiModel() { }

        //public GongweiModel(base_gongwei gongwei)
        //{
        //    Init(gongwei);
        //}

        //void Init(base_gongwei gongwei)
        //{
        //    ID = gongwei.ID;
        //    Gwcode = gongwei.gwcode;
        //    Gwname = gongwei.gwname;
        //    GwStatus = gongwei.gwStatus ?? 0;
        //    IP = gongwei.IP;
        //    AreaID = gongwei.areaID ?? 0;
        //    GwOrder = gongwei.gwOrder ?? 0;
        //    IsFinishGW = gongwei.isFinishGW ?? 0;
        //    IsHasFollow = gongwei.isHasFollow ?? 0;
        //    IsHasAms = gongwei.isHasAms ?? 0;
        //    opcDeviceName = gongwei.opcDeviceName;
        //    Opc_Red = gongwei.Opc_Red;
        //    Opc_Green = gongwei.Opc_Green;
        //    Opc_Yellow = gongwei.Opc_Yellow;
        //    Opc_OK = gongwei.Opc_OK;
        //    OPC_NG = gongwei.OPC_NG;
        //    Opc_ErrRang = gongwei.Opc_ErrRang;
        //    Opc_CameraEnter = gongwei.Opc_CameraEnter;
        //    Opc_CameraOK = gongwei.Opc_CameraOK;
        //    OPC_CameraNG = gongwei.OPC_CameraNG;
        //    Remark = gongwei.remark;
        //}

        //主键ID
        public int ID { get; set; }

        //工位编码
        public string Gwcode { get; set; }

        //工位名称
        public string Gwname { get; set; }

        //状态
        public int GwStatus { get; set; }

        //IP地址
        public string IP { get; set; }

        //区域
        public int AreaID { get; set; }

        //排序
        public int GwOrder { get; set; }

        //
        public int IsFinishGW { get; set; }

        public int IsHasFollow { get; set; }

        public int IsHasAms { get; set; }

        public string opcDeviceName { get; set; }

        //OPC红点
        public string Opc_Red { get; set; }

        //OPC绿点
        public string Opc_Green { get; set; }

        //OPC黄点
        public string Opc_Yellow { get; set; }

        //OPC OK
        public string Opc_OK { get; set; }

        //OPC失败
        public string OPC_NG { get; set; }

        //OPC错误
        public string Opc_ErrRang { get; set; }

        //
        public string Opc_CameraEnter { get; set; }

        //
        public string Opc_CameraOK { get; set; }

        //
        public string OPC_CameraNG { get; set; }

        //备注
        public string Remark { get; set; }

    }
}
