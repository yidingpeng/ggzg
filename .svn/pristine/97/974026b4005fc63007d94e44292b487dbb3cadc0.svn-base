using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RW.PMS.Common;
using RW.PMS.Common.Auth;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;

namespace RW.PMS.Web.Controllers.Program
{
    internal class ProgramTables
    {
        private long _authVal = 0;
        public ProgramTables(long authVal)
        {
            this._authVal = authVal;
        }
        public CollapseTable<List<BaseProgram>> GetProTable()
        {
            var table = new CollapseTable<List<BaseProgram>>();
            table.Title.AddRange(new TableColumn[]
                {
                    //new TableColumn("ProgName","程序名称"),
                    //new TableColumn("GWName","工位名称"),
                    //new TableColumn("FileNo","文件编号"),
                    //new TableColumn("StartTime","时间"),
                    //new TableColumn("CopyRight","版本"),
                    //new TableColumn("Descript","程序描述"),
                    //new TableColumn("ProgStatus","状态",ColumnFormat.IsEnable),
                    //new TableColumn("Remark","备注"),

                    new TableColumn("Pmodel","产品型号"),  //加一列产品型号
                    new TableColumn("GWName","工位名称"),
                    new TableColumn("ProgName","程序名称"),
                    new TableColumn("FileNo","文件编号"),
                    new TableColumn("StartTime","时间"),
                    new TableColumn("CopyRight","版本"),
                    //new TableColumn("Descript","程序描述"),
                    new TableColumn("ProgStatus","状态",ColumnFormat.IsEnable),
                    new TableColumn("Remark","备注"),
                });

            var commands = new List<Command>();
            var cmdAdd = new List<Command>();

            if (SystemAuth.IsHasAuth(AuthType.Edit, _authVal))
            {
                commands.Add(new Command { Name = "修改", Url = "/Program/GetDetail" });
                commands.Add(new Command { Name = "保存", Url = "/Program/EditPro", IsShow = false });
                commands.Add(new Command { Name = "取消", Url = "/Program/GetDetail", IsShow = false });
            }

            if (SystemAuth.IsHasAuth(AuthType.Delete, _authVal))
            {
                commands.Add(new Command { Name = "删除", Url = "/Program/Delete" });
            }

            if (SystemAuth.IsHasAuth(AuthType.Add, _authVal))
            {
                cmdAdd.Add(new Command { Name = "工序配置", Url = "/Program/Add" });
            }

            table.Opertions = new List<KeyValuePair<string, List<Command>>>();
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("操作", commands.ToList()));
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("配置", cmdAdd.ToList()));

            return table;

        }

        public CollapseTable<List<GXInfo>> GetProGXTable()
        {
            var table = new CollapseTable<List<GXInfo>>();
            table.Title.AddRange(new TableColumn[]
                {
                    new TableColumn("ID","ID"),
                    //new TableColumn("ProgName","程序名称"),
                    //new TableColumn("GWName","工位名称"),
                    new TableColumn("GXName","工序名称"),
                    //new TableColumn("GXDesc","工序描述"),
                    new TableColumn("GXVedio","工序视频",ColumnFormat.Video),
                    new TableColumn("GXOrder","工序排序"),
                    new TableColumn("PGXInfoStatus","状态",ColumnFormat.IsEnable),
                    new TableColumn("Remark","备注"),
                });


            var cmdOrders = new List<Command>();
            var cmds = new List<Command>();
            var cmdAdd = new List<Command>();

            if (SystemAuth.IsHasAuth(AuthType.Edit, _authVal))
            {
                cmdOrders.Add(new Command { Name = "上移", Url = "/Program/OrderSet?type=Up" });
                cmdOrders.Add(new Command { Name = "下移", Url = "/Program/OrderSet?type=Down" });
                cmds.Add(new Command { Name = "修改", Url = "/Program/GetDetail" });
                cmds.Add(new Command { Name = "保存", Url = "/Program/EditProGX", IsShow = false });
                cmds.Add(new Command { Name = "取消", Url = "/Program/GetDetail", IsShow = false });
            }

            if (SystemAuth.IsHasAuth(AuthType.Delete, _authVal))
            {
                cmds.Add(new Command { Name = "删除", Url = "/Program/Delete" });
            }

            if (SystemAuth.IsHasAuth(AuthType.Add, _authVal))
            {
                cmdAdd.Add(new Command { Name = "工步配置", Url = "/Program/Add" });
            }
            table.Opertions = new List<KeyValuePair<string, List<Command>>>();
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("排序", cmdOrders.ToList()));
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("操作", cmds.ToList()));
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("配置", cmdAdd.ToList()));

            return table;
        }

        public CollapseTable<List<GBInfo>> GetProGBTable()
        {
            var table = new CollapseTable<List<GBInfo>>();

            table.Title.AddRange(new TableColumn[]
                {
                    new TableColumn("ID","ID"),
                    new TableColumn("GBName","工步名称"),
                    new TableColumn("GBDesc","工步描述"),
                    new TableColumn("GBOrder","工步排序"),
                    new TableColumn("ControlTypeName","管控方式"),
                    new TableColumn("GBDelayTime","工步延长时间"),
                    new TableColumn("GBImage","图片"),
                    new TableColumn("IsScan","是否要扫码",ColumnFormat.IsOK),
                    //new TableColumn("IsInputPInfo","是否要录入产品信息",ColumnFormat.IsOK),
                    //new TableColumn("IsScanOrderNo","是否要录入产品订单号",ColumnFormat.IsOK),
                    //new TableColumn("IsEmpCheck","是否要人工自检确认",ColumnFormat.IsOK),
                    //new TableColumn("ErrTypeName","工步异常类型"),
                    new TableColumn("PGBInfoStatus","状态",ColumnFormat.IsEnable),
                    new TableColumn("Remark","备注"),
                });

            var cmdOrders = new List<Command>();
            var cmds = new List<Command>();
            var cmdAdd = new List<Command>();

            if (SystemAuth.IsHasAuth(AuthType.Edit, _authVal))
            {
                cmdOrders.Add(new Command { Name = "上移", Url = "/Program/OrderSet?type=Up" });
                cmdOrders.Add(new Command { Name = "下移", Url = "/Program/OrderSet?type=Down" });
                cmds.Add(new Command { Name = "修改", Url = "/Program/GetDetail" });
                cmds.Add(new Command { Name = "保存", Url = "/Program/EditProGB", IsShow = false });
                cmds.Add(new Command { Name = "取消", Url = "/Program/GetDetail", IsShow = false });
            }

            if (SystemAuth.IsHasAuth(AuthType.Delete, _authVal))
            {
                cmds.Add(new Command { Name = "删除", Url = "/Program/Delete" });
            }

            if (SystemAuth.IsHasAuth(AuthType.Add, _authVal))
            {
                cmdAdd.Add(new Command { Name = "工具配置", Url = "/Program/Add" });
            }
            table.Opertions = new List<KeyValuePair<string, List<Command>>>();
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("排序", cmdOrders.ToList()));
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("操作", cmds.ToList()));
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("配置", cmdAdd.ToList()));
            return table;
        }

        public CollapseTable<List<GJInfo>> GetProGJTable()
        {
            var table = new CollapseTable<List<GJInfo>>();
            table.Title.AddRange(new TableColumn[]
                {
                    new TableColumn("ID","ID"),
                    new TableColumn("GJName","工具名称"),
                    new TableColumn("GJOrder","工具排序"),
                    new TableColumn("WLName","物料名称"),
                    new TableColumn("WLOrder","物料排序"),
                    //new TableColumn("GJImage","图片"),
                    new TableColumn("PGJInfoStatus","状态",ColumnFormat.IsEnable),
                    new TableColumn("Remark","备注"),
                });
            //添加工具物料点位信息
            var opcTypes = DIService.GetService<IBLL_GJInfo>().GetGJOPCTypes();
            var opcColumns = new List<TableColumn>();

            opcTypes.ForEach(item =>
            {
                var format = ColumnFormat.None;
                if (item.Code == "gjwlGet" || item.Code == "gjwlPut")
                {
                    format = ColumnFormat.Light;
                }
                if (item.Code == "materialConfrom")
                {
                    format = ColumnFormat.IsOK;
                }
                opcColumns.Add(new TableColumn(item.Code, item.Name, format, "auto"));
            });
            table.Title.InsertRange(table.Title.Count - 2, opcColumns);

            var cmdOrders = new List<Command>();
            var cmds = new List<Command>();
            var cmdAdd = new List<Command>();

            if (SystemAuth.IsHasAuth(AuthType.Edit, _authVal))
            {
                cmdOrders.Add(new Command { Name = "上移", Url = "/Program/OrderSet?type=Up" });
                cmdOrders.Add(new Command { Name = "下移", Url = "/Program/OrderSet?type=Down" });
                cmds.Add(new Command { Name = "修改", Url = "/Program/GetDetail" });
                cmds.Add(new Command { Name = "保存", Url = "/Program/EditProGJ", IsShow = false });
                cmds.Add(new Command { Name = "取消", Url = "/Program/GetDetail", IsShow = false });
            }

            if (SystemAuth.IsHasAuth(AuthType.Delete, _authVal))
            {
                cmds.Add(new Command { Name = "删除", Url = "/Program/Delete" });
            }

            if (SystemAuth.IsHasAuth(AuthType.Add, _authVal))
            {
                cmdAdd.Add(new Command { Name = "检测项配置", Url = "/Program/Add" });
            }
            table.Opertions = new List<KeyValuePair<string, List<Command>>>();
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("排序", cmdOrders.ToList()));
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("操作", cmds.ToList()));
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("配置", cmdAdd.ToList()));

            return table;
        }

        public CollapseTable<List<ValueInfo>> GetProValTable()
        {
            var table = new CollapseTable<List<ValueInfo>>();
            table.Title.AddRange(new TableColumn[]
                {
                    new TableColumn("ID","ID"),
                    new TableColumn("ProgGjInfoID","工具配置ID"),
                    new TableColumn("ValueTypeName","检测项类型"),
                    new TableColumn("EqualTypeName","值比较类型"),
                    new TableColumn("StandardValue","目标值"),
                    new TableColumn("MinValue","最小值"),
                    new TableColumn("MaxValue","最大值"),
                    //new TableColumn("PixelPoint","相机换算像素点"),
                    new TableColumn("PVInfoStatus","状态",ColumnFormat.IsEnable),
                    new TableColumn("Remark","备注"),
                });

            var cmds = new List<Command>();

            if (SystemAuth.IsHasAuth(AuthType.Edit, _authVal))
            {
                cmds.Add(new Command { Name = "修改", Url = "/Program/GetDetail" });
                cmds.Add(new Command { Name = "保存", Url = "/Program/EditProVal", IsShow = false });
                cmds.Add(new Command { Name = "取消", Url = "/Program/GetDetail", IsShow = false });
            }

            if (SystemAuth.IsHasAuth(AuthType.Delete, _authVal))
            {
                cmds.Add(new Command { Name = "删除", Url = "/Program/Delete" });
            }
            table.Opertions = new List<KeyValuePair<string, List<Command>>>();
            table.Opertions.Add(new KeyValuePair<string, List<Command>>("操作", cmds.ToList()));

            return table;
        }
    }
}