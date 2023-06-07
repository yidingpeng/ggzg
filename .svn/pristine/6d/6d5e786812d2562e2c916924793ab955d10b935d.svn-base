using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Log;
using RW.PMS.Model.Plan;
using RW.PMS.Model.Sys;
using RW.PMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace RW.PMS.DAL
{
    internal class DAL_BaseInfo : IDAL_BaseInfo
    {
        /// <summary>
        /// 通用判断名称是否存在
        /// </summary>
        /// <param name="TabName">表名</param>
        /// <param name="FiledName">字段名称</param>
        /// <param name="Name">查询字段名称值</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public bool IsExistName(string TabName, string FiledName, string Name, int ID = 0)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = string.Format(@"select count(*) from {0} where {1}='{2}'", TabName, FiledName, Name);
            if (ID != 0)
            {
                sql += " and ID<>@ID ";
                pList.Add(new MySqlParameter("@ID", ID));
            }
            var ret = db.ExecuteScalar(sql, pList.ToArray());
            int rowcount = 0;
            int.TryParse(ret + "", out rowcount);
            return rowcount > 0 ? true : false;
        }

        #region 产品信息
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductModel> GetPagingBaseProduct(BaseProductModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (!string.IsNullOrEmpty(model.Pname))
            {
                para += " and Pname like CONCAT('%',@Pname,'%') ";

                pList.Add(new MySqlParameter("@Pname", model.Pname));
            }

            string sql = "select count(*) from base_product where 1=1 " + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select * from base_product where 1=1 " + para;

            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<BaseProductModel> list = db.ExecuteList<BaseProductModel>(sql, pList.ToArray());

            return list;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">产品信息实体类</param>
        public void AddBaseProduct(BaseProductModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into base_product(Pname,Pstatus,remark) values(@Pname,@Pstatus,@remark)";

            pList.Add(new MySqlParameter("@Pname", model.Pname));
            pList.Add(new MySqlParameter("@Pstatus", model.Pstatus));
            pList.Add(new MySqlParameter("@remark", model.remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">产品信息表Id</param>
        /// <returns></returns>
        public BaseProductModel GetBaseProductId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,Pname,Pstatus,remark from base_product where ID = @ID";
            pList.Add(new MySqlParameter("@ID", Id));

            List<BaseProductModel> list = db.ExecuteList<BaseProductModel>(sql, pList.ToArray());

            if (list.Count > 0)
                return list[0];

            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProduct(BaseProductModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_product set Pname=@Pname,Pstatus=@Pstatus,remark=@remark where ID = @ID";

            pList.Add(new MySqlParameter("@Pname", model.Pname));
            pList.Add(new MySqlParameter("@Pstatus", model.Pstatus));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@ID", model.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProduct(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_product where ID in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());

        }

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfoList(ProductInfoModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            if (!string.IsNullOrEmpty(model.pf_prodNo))
            {
                para += "and pf_prodNo=@pf_prodNo ";
                pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
            }
            // left join subwayinfo sw on sw.ID=pf.pf_subwayInfoID 
            string sql = @"SELECT * FROM base_product where 1=1 " + para;

            return db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());

        }
        #endregion

        #region 产品型号信息
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetPagingBaseProductModel(BaseProductModelModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            //pList.Add(new MySqlParameter("@PID", model.PID)); bpm.PID = @PID 

            if (!string.IsNullOrEmpty(model.Pmodel))
            {
                para += " and Pmodel like CONCAT('%',@Pmodel,'%')";
                pList.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            }
            string sql = @"select Count(*) from base_productmodel bpm
                                    left join base_product bp on bpm.PID = bp.ID
                                    where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select * from base_productmodel bpm
                                left join base_product bp on bpm.PID = bp.ID
                                where 1=1 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, pList.ToArray());

            return list;
        }


        public List<BaseProductModelModel> GetBaseProductModel()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from base_productmodel";
            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseOPCProductModel> GetOPCProductModelList(BaseOPCProductModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            //pList.Add(new MySqlParameter("@PID", model.PID)); bpm.PID = @PID

            if (!string.IsNullOrEmpty(model.Pmodel))
            {
                para += " and Pmodel like CONCAT('%',@Pmodel,'%')";
                pList.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            }
            string sql = @"select Count(*) from base_productmodel bpm
                                    left join base_product bp on bpm.PID = bp.ID
                                    where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select * from base_productmodel bpm
                                left join base_product bp on bpm.PID = bp.ID
                                where 1=1 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<BaseOPCProductModel> list = db.ExecuteList<BaseOPCProductModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取未禁用的所有产品型号(用于下拉框)
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetProductModelAll()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select pm.*, bf.formulaCode as formulaNo from base_productModel pm left join base_formula bf on pm.formulaCode = bf.ID where pm.Pstatus !=1 ORDER BY ID DESC";

            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="model">产品型号实体类</param>
        public void AddBaseProductModel(BaseProductModelModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "insert into base_productModel(PID,Pmodel,PmodelNo,DrawingNo,beatMinite,Pstatus,remark,tighteningTorque,formulaCode) values(@PID,@Pmodel,@PmodelNo,@DrawingNo,@beatMinite,@Pstatus,@remark,@tighteningTorque,@formulaCode)";

            pList.Add(new MySqlParameter("@PID", model.PID));
            pList.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            pList.Add(new MySqlParameter("@PmodelNo", model.PmodelNo));
            pList.Add(new MySqlParameter("@DrawingNo", model.DrawingNo));
            pList.Add(new MySqlParameter("@beatMinite", model.beatMinite));
            pList.Add(new MySqlParameter("@tighteningTorque", model.tighteningTorque));
            pList.Add(new MySqlParameter("@Pstatus", model.Pstatus));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@formulaCode", model.formulaCode));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary> 
        /// 修改绑定
        /// </summary>
        /// <param name="Id">产品型号信息表Id</param>
        /// <returns></returns>
        public BaseProductModelModel GetBaseProductModelId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> List = new List<MySqlParameter>();

            string sql = @"select pm.*, bf.formulaCode as formulaNo from base_productModel pm left join base_formula bf on pm.formulaCode = bf.ID where pm.ID=@ID";

            List.Add(new MySqlParameter("@ID", Id));

            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, List.ToArray());

            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        /// <summary>
        /// 修改 
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProductModel(BaseProductModelModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> List = new List<MySqlParameter>();

            string sql = "UPDATE base_productModel SET PID=@PID,PmodelNo=@PmodelNo,Pmodel=@Pmodel,DrawingNo=@DrawingNo,beatMinite=@beatMinite,Pstatus=@Pstatus,remark=@remark,tighteningTorque=@tighteningTorque,formulaCode=@formulaCode WHERE ID=@ID";

            List.Add(new MySqlParameter("@PID", model.PID));
            List.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            List.Add(new MySqlParameter("@PmodelNo", model.PmodelNo));
            List.Add(new MySqlParameter("@DrawingNo", model.DrawingNo));
            List.Add(new MySqlParameter("@beatMinite", model.beatMinite));
            List.Add(new MySqlParameter("@tighteningTorque", model.tighteningTorque));
            List.Add(new MySqlParameter("@Pstatus", model.Pstatus));
            List.Add(new MySqlParameter("@remark", model.remark));
            List.Add(new MySqlParameter("@ID", model.ID));
            List.Add(new MySqlParameter("@formulaCode", model.formulaCode));

            db.ExecuteNonQuery(sql, List.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProductModel(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_productModel where ID in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 维保信息设置

        /// <summary>
        /// 获取所有维保信息
        /// </summary>
        /// <returns></returns>
        public List<MaintenanceSettingModel> GetMaintenanceSettingAll()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ms.*, su.empName as PersonnelValue,bd.devName devName from MaintenanceSetting ms left join sys_user su on ms.Personnel = su.userID left join base_device bd on ms.MaintenanceItem=bd.ID";

            List<MaintenanceSettingModel> list = db.ExecuteList<MaintenanceSettingModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="model">维保信息实体类</param>
        public bool AddMaintenanceSetting(MaintenanceSettingModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "insert into MaintenanceSetting(MaintenanceItem,MaintenanceContent,RelatedPicture,Frequency,Remark,Personnel,UpdateTime,usedTimes) values(@MaintenanceItem,@MaintenanceContent,@RelatedPicture,@Frequency,@Remark,@Personnel,@UpdateTime,0)";
            pList.Add(new MySqlParameter("@MaintenanceItem", model.MaintenanceItem));
            pList.Add(new MySqlParameter("@MaintenanceContent", model.MaintenanceContent));
            pList.Add(new MySqlParameter("@RelatedPicture", model.RelatedPicture));
            pList.Add(new MySqlParameter("@Frequency", model.Frequency));
            pList.Add(new MySqlParameter("@Remark", model.Remark));
            pList.Add(new MySqlParameter("@Personnel", model.Personnel));
            pList.Add(new MySqlParameter("@UpdateTime", model.UpdateTime));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());

            return i > 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Id">维保信息表Id</param>
        /// <returns></returns>
        public MaintenanceSettingModel GetMaintenanceSettingId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> List = new List<MySqlParameter>();

            string sql = "select ms.*, su.empName as PersonnelValue from MaintenanceSetting ms left join sys_user su on ms.Personnel = su.userID where ms.ID=@ID";

            List.Add(new MySqlParameter("@ID", Id));

            List<MaintenanceSettingModel> list = db.ExecuteList<MaintenanceSettingModel>(sql, List.ToArray());

            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public bool EditMaintenanceSetting(MaintenanceSettingModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> List = new List<MySqlParameter>();

            string sql = "UPDATE MaintenanceSetting SET MaintenanceItem=@MaintenanceItem,MaintenanceContent=@MaintenanceContent,RelatedPicture=@RelatedPicture,Frequency=@Frequency,Remark=@Remark,Personnel=@Personnel,UpdateTime=@UpdateTime WHERE ID=@ID";

            List.Add(new MySqlParameter("@MaintenanceItem", model.MaintenanceItem));
            List.Add(new MySqlParameter("@MaintenanceContent", model.MaintenanceContent));
            List.Add(new MySqlParameter("@RelatedPicture", model.RelatedPicture));
            List.Add(new MySqlParameter("@Frequency", model.Frequency));
            List.Add(new MySqlParameter("@Remark", model.Remark));
            List.Add(new MySqlParameter("@Personnel", model.Personnel));
            List.Add(new MySqlParameter("@UpdateTime", model.UpdateTime));
            List.Add(new MySqlParameter("@ID", model.ID));
            int i = db.ExecuteNonQuery(sql, List.ToArray());
            return i > 0;
        }

        /// <summary>
        /// 使用次数恢复为0
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool EditmaintainUsedTime(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> List = new List<MySqlParameter>();

            string sql = "UPDATE MaintenanceSetting SET usedTimes=0 WHERE ID=@ID";

            List.Add(new MySqlParameter("@ID", Id));

            int i = db.ExecuteNonQuery(sql, List.ToArray());

            return i > 0;
        }

        /// <summary>
        /// 给拧紧设备使用次数+1
        /// </summary>
        public void AddUsedTimes()
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = "UPDATE MaintenanceSetting SET usedTimes=usedTimes+1 WHERE MaintenanceItem=1";
            db.ExecuteNonQuery(sql, List.ToArray());
        }
         
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteMaintenanceSetting(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from MaintenanceSetting where ID in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());

            return i > 0;
        }

        #endregion

        #region 拧紧数据管理

        /// <summary>
        /// 获取拧紧数据  
        /// </summary>
        /// <returns></returns>
        public List<TighteningRecordModel> GetTighteningRecord(TighteningRecordModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.PID > 0)
            {
                para += " and tr.PID = @Pmodel ";
                pList.Add(new MySqlParameter("@Pmodel", model.PID));
            }

            if (model.Operators > 0)
            {
                para += " and tr.Operators = @Operators ";
                pList.Add(new MySqlParameter("@Operators", model.Operators));
            }

            if (!string.IsNullOrEmpty(model.Pmodel))
            {
                para += " and Pmodel like CONCAT('%',@Pmodel,'%') ";

                pList.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            }
            if (!string.IsNullOrEmpty(model.prodNo))
            {
                para += " and pi.pf_prodNo LIKE CONCAT('%',@prodNo,'%') ";

                pList.Add(new MySqlParameter("@prodNo", model.prodNo));
            }

            if (!string.IsNullOrEmpty(model.starttime))//开始时间
            {
                var starttime = DateTime.Parse(model.starttime);
                para += " and TighteningDate>=@startTime ";
                pList.Add(new MySqlParameter("@startTime", starttime));

            }
            if (!string.IsNullOrEmpty(model.endtime))//完成时间
            {
                var endtime = DateTime.Parse(model.endtime).AddDays(+1).AddSeconds(-1);
                para += " and TighteningDate < @finishTime ";
                pList.Add(new MySqlParameter("@finishTime", endtime));
            }

            string sql = @"select tr.*, su.empName as OperatorValue,pi.pf_prodNo prodNo,bp.Pmodel Pmodel from TighteningRecord tr 
                            left join sys_user su on tr.Operators = su.userID
                            LEFT JOIN productinfo pi on tr.PID = pi.pf_ID
                            LEFT JOIN base_productmodel bp on pi.pf_prodModelID = bp.ID where 1 = 1 " + para;

            sql += @" order by TighteningDate desc ";
            List<TighteningRecordModel> list = db.ExecuteList<TighteningRecordModel>(sql, pList.ToArray());

            return list;
        }


        public List<TighteningRecordExcelModel> GetTighteningRecordExcel(TighteningRecordModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.PID > 0)
            {
                para += " and tr.PID = @Pmodel ";
                pList.Add(new MySqlParameter("@Pmodel", model.PID));
            }

            if (model.Operators > 0)
            {
                para += " and tr.Operators = @Operators ";
                pList.Add(new MySqlParameter("@Operators", model.Operators));
            }

            if (!string.IsNullOrEmpty(model.Pmodel))
            {
                para += " and Pmodel like CONCAT('%',@Pmodel,'%') ";

                pList.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            }
            if (!string.IsNullOrEmpty(model.prodNo))
            {
                para += " and pi.pf_prodNo LIKE CONCAT('%',@prodNo,'%') ";

                pList.Add(new MySqlParameter("@prodNo", model.prodNo));
            }
            if (!string.IsNullOrEmpty(model.starttime))//开始时间
            {
                var starttime = DateTime.Parse(model.starttime);
                para += " and TighteningDate>=@startTime ";
                pList.Add(new MySqlParameter("@startTime", starttime));

            }
            if (!string.IsNullOrEmpty(model.endtime))//完成时间
            {
                var endtime = DateTime.Parse(model.endtime).AddDays(+1).AddSeconds(-1);
                para += " and TighteningDate < @finishTime ";
                pList.Add(new MySqlParameter("@finishTime", endtime));
            }

            string sql = @"select tr.*, su.empName as OperatorValue,pi.pf_prodNo prodNo,bp.Pmodel Pmodel from TighteningRecord tr 
                            left join sys_user su on tr.Operators = su.userID
                            LEFT JOIN productinfo pi on tr.PID = pi.pf_ID
                            LEFT JOIN base_productmodel bp on pi.pf_prodModelID = bp.ID where 1 = 1 " + para;

            //sql += "limit " + 0 + "," + 1;

            List<TighteningRecordExcelModel> list = db.ExecuteList<TighteningRecordExcelModel>(sql, pList.ToArray());

            return list;
        }


        public List<TighteningRecordModel> GetTighteningRecord(TighteningRecordModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (!string.IsNullOrEmpty(model.Pmodel))
            {
                para += " and Pmodel like CONCAT('%',@Pmodel,'%') ";

                pList.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            }
            if (!string.IsNullOrEmpty(model.starttime))//开始时间
            {
                var starttime = DateTime.Parse(model.starttime);
                para += " and TighteningDate>=@startTime ";
                pList.Add(new MySqlParameter("@startTime", starttime));

            }
            if (!string.IsNullOrEmpty(model.endtime))//完成时间
            {
                var endtime = DateTime.Parse(model.endtime).AddDays(+1).AddSeconds(-1);
                para += " and TighteningDate < @finishTime ";
                pList.Add(new MySqlParameter("@finishTime", endtime));
            }

            string sql = "select count(*) from TighteningRecord tr left join sys_user su on tr.Operators = su.userID LEFT JOIN base_productmodel bp on tr.PID=bp.ID where 1=1 " + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select tr.*, su.empName as OperatorValue,bp.Pmodel Pmodel from TighteningRecord tr left join sys_user su on tr.Operators = su.userID LEFT JOIN base_productmodel bp on tr.PID=bp.ID where 1=1 " + para;

            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<TighteningRecordModel> list = db.ExecuteList<TighteningRecordModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="model">拧紧数据实体类</param>
        public int AddTighteningRecordModel(TighteningRecordModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "INSERT INTO TighteningRecord(PID,StandardValue,TorqueValue,TighteningDate,Operators,AngleValue,BoltNo) VALUE(@PID,@StandardValue,@TorqueValue,@TighteningDate,@Operators,@AngleValue,@BoltNo)";

            pList.Add(new MySqlParameter("@PID", model.PID));
            pList.Add(new MySqlParameter("@StandardValue", model.StandardValue));
            pList.Add(new MySqlParameter("@TorqueValue", model.TorqueValue));
            pList.Add(new MySqlParameter("@TighteningDate", model.TighteningDate));
            pList.Add(new MySqlParameter("@Operators", model.Operators));
            pList.Add(new MySqlParameter("@AngleValue", model.AngleValue));
            pList.Add(new MySqlParameter("@BoltNo", model.BoltNo));

            //int i = db.ExecuteNonQuery(sql, pList.ToArray());

            var objInfoId = db.ExecuteScalar(sql, pList.ToArray());
            return Convert.ToInt32(objInfoId);

            //return i > 0;
        }

        /// <summary>
        /// 编辑  
        /// </summary>
        /// <param name="model">拧紧数据实体类</param>
        public bool EditTighteningRecordModel(TighteningRecordModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "UPDATE TighteningRecord SET TorqueValue=@TorqueValue,TighteningDate=@TighteningDate,Operators=@Operators,AngleValue=@AngleValue WHERE ID=@ID";
            
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@TorqueValue", model.TorqueValue));
            pList.Add(new MySqlParameter("@TighteningDate", model.TighteningDate));
            pList.Add(new MySqlParameter("@Operators", model.Operators));
            pList.Add(new MySqlParameter("@AngleValue", model.AngleValue));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());

            return i > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteTighteningRecord(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from TighteningRecord where ID in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());

            return i > 0;
        }

        #endregion

        #region 工位信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseGongweiModel> GetWorkPositionList(BaseGongweiModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.gwname))
            {
                para += "and a.gwname=@gwname ";
                pList.Add(new MySqlParameter("@gwname", model.gwname));
            }
            if (!string.IsNullOrEmpty(model.IP))
            {
                para += "and a.IP like CONCAT('%',@IP,'%') ";
                pList.Add(new MySqlParameter("@IP", model.IP));
            }
            if (model.areaID != null && model.areaID != 0)
            {
                para += "and a.areaID=@areaID ";
                pList.Add(new MySqlParameter("@areaID", model.areaID));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select count(1) from base_gongwei a left join sys_basedata b on a.areaID=b.ID where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select a.*,b.bdcode areaCode,b.bdname areaName from base_gongwei a left join sys_basedata b on a.areaID=b.ID where 1=1 " + para;
            sql += " ORDER BY gwOrder ";
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray());

            //获取OPC 不循环访问数据库,以免降低系统效率
            return GetOPC(list);
        }

        /// <summary>
        /// 查询工位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseGongweiModel> GetWorkPositionList(BaseGongweiModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (!string.IsNullOrEmpty(model.IP))
            {
                para += "and gw.IP=@IP ";
                pList.Add(new MySqlParameter("@IP", model.IP));
            }
            if (model.ID != 0)
            {
                para += "and gw.ID=@ID ";
                pList.Add(new MySqlParameter("@ID", model.ID));
            }
            if (model.areaID.HasValue && model.areaID != 0)
            {
                para += "and gw.areaID=@areaID ";
                pList.Add(new MySqlParameter("@areaID", model.areaID));
            }
            if (model.gwStatus.HasValue && model.gwStatus != 0)
            {
                para += "and gw.gwStatus=@gwStatus ";
                pList.Add(new MySqlParameter("@gwStatus", model.gwStatus));
            }

            string sql = "select gw.*,b.bdcode areaCode,b.bdname areaName from base_gongwei gw left join sys_basedata b on gw.areaID=b.ID where 1=1 " + para;

            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray());

            //获取OPC 不循环访问数据库,以免降低系统效率 
            return GetOPC(list);
        }

        /// <summary>
        /// 根据工位集合获取集合中所有工位的OPC
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<BaseGongweiModel> GetOPC(List<BaseGongweiModel> list)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            var ID = list.Count > 0 ? string.Join(",", list.Select(_ => _.ID)) : "0";
            string sql = "select * from base_gongweiOPC where gwID in(" + ID + ")";
            List<BaseGongweiOpcModel> OPCList = db.ExecuteList<BaseGongweiOpcModel>(sql, pList.ToArray());
            foreach (var wp in list)
            {
                List<BaseGongweiOpcModel> tempList = wp.OPC.ToList();
                foreach (var item in OPCList)
                {
                    if (!item.gwID.HasValue) continue;
                    if (item.gwID.Value == wp.ID)
                        tempList.Add(item);
                }
                wp.OPC = tempList;
            }
            return list;
        }

        /// <summary>
        /// 根据区域ID获取该区域所有工位
        /// </summary>
        /// <returns></returns>
        public List<BaseGongweiModel> GetAllBaseGongWei(int areaID = 0)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (areaID != 0)
            {
                para += "and areaID=@areaID ";
                pList.Add(new MySqlParameter("@areaID", areaID));
            }
            string sql = "select * from base_gongwei where 1=1 " + para;
            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 查询OPC点位信息
        /// </summary>
        /// <param name="model">OPC查询条件Model</param>
        /// <returns>OPC点位集合</returns>
        public List<BaseGongweiOpcModel> GetGongWeiOPC(BaseGongweiOpcModel model = null)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select * from base_gongweiOPC where 1=1 ";

            if (model != null)
            {
                //可扩展查询条件
            }

            return db.ExecuteList<BaseGongweiOpcModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 工位OPC点位信息表【添加、修改】调用同一个方法
        /// 添加工位表 循环添加工位OPC点表
        /// </summary>
        /// <param name="models">实体</param>
        /// <param name="gwid">工位ID</param>
        public int EditBaseGongWeiOpc(List<BaseGongweiModel> models, int gwid)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                int ret = 0;
                try
                {
                    if (gwid == 0)
                    {
                        //新增
                        pList.Clear();
                        string sql = @"insert into base_gongwei(gwcode,gwname,gwStatus,IP,areaID,gwOrder,isFinishGW,isHasFollow,isHasAms,isOPC,remark,agvAddress) 
                                               values(@gwcode,@gwname,@gwStatus,@IP,@areaID,@gwOrder,@isFinishGW,@isHasFollow,@isHasAms,@isOPC,@remark,@agvAddress)";
                        pList.Add(new MySqlParameter("@gwcode", models[0].gwcode));
                        pList.Add(new MySqlParameter("@gwname", models[0].gwname));
                        pList.Add(new MySqlParameter("@gwStatus", models[0].gwStatus));
                        pList.Add(new MySqlParameter("@IP", models[0].IP));
                        pList.Add(new MySqlParameter("@areaID", models[0].areaID));
                        pList.Add(new MySqlParameter("@gwOrder", models[0].gwOrder));
                        pList.Add(new MySqlParameter("@isFinishGW", models[0].isFinishGW));
                        pList.Add(new MySqlParameter("@isHasFollow", models[0].isHasFollow));
                        pList.Add(new MySqlParameter("@isHasAms", models[0].isHasAms));
                        pList.Add(new MySqlParameter("@isOPC", models[0].isOPC));
                        pList.Add(new MySqlParameter("@remark", models[0].remark));
                        pList.Add(new MySqlParameter("@agvAddress", models[0].agvAddress));

                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        //获取自增长ID
                        int identity = 0;
                        pList.Clear();
                        sql = "select @@identity";
                        int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out identity);
                        //添加OPC点位信息
                        foreach (BaseGongweiOpcModel item in models[0].OPC)
                        {
                            sql = @"insert into base_gongweiopc(gwID,gwname,opcTypeID,opcTypeCode,opcValue,remark)
                                            values(@gwID,@gwname,@opcTypeID,@opcTypeCode,@opcValue,@remark)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@gwID", identity));
                            pList.Add(new MySqlParameter("@gwname", models[0].gwname));
                            pList.Add(new MySqlParameter("@opcTypeID", item.opcTypeID));
                            pList.Add(new MySqlParameter("@opcTypeCode", item.opcTypeCode));
                            pList.Add(new MySqlParameter("@opcValue", item.opcValue));
                            pList.Add(new MySqlParameter("@remark", item.remark));
                            ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        }

                    }
                    else
                    {
                        //编辑
                        string updateSql = @"update base_gongwei set gwcode=@gwcode,gwname=@gwname,gwStatus=@gwStatus,IP=@IP,areaID=@areaID,
                                                     gwOrder=@gwOrder,isFinishGW=@isFinishGW,isHasFollow=@isHasFollow,isHasAms=@isHasAms,isOPC=@isOPC,remark=@remark,agvAddress=@agvAddress where ID=@ID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@gwcode", models[0].gwcode));
                        pList.Add(new MySqlParameter("@gwname", models[0].gwname));
                        pList.Add(new MySqlParameter("@gwStatus", models[0].gwStatus));
                        pList.Add(new MySqlParameter("@IP", models[0].IP));
                        pList.Add(new MySqlParameter("@areaID", models[0].areaID));
                        pList.Add(new MySqlParameter("@gwOrder", models[0].gwOrder));
                        pList.Add(new MySqlParameter("@isFinishGW", models[0].isFinishGW));
                        pList.Add(new MySqlParameter("@isHasFollow", models[0].isHasFollow));
                        pList.Add(new MySqlParameter("@isHasAms", models[0].isHasAms));
                        pList.Add(new MySqlParameter("@isOPC", models[0].isOPC));
                        pList.Add(new MySqlParameter("@remark", models[0].remark));
                        pList.Add(new MySqlParameter("@agvAddress", models[0].agvAddress));
                        pList.Add(new MySqlParameter("@ID", models[0].ID));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, updateSql, pList.ToArray());

                        RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                        foreach (BaseGongweiOpcModel item in models[0].OPC)
                        {
                            if (!string.IsNullOrEmpty(item.opcValue))
                            {
                                pList.Clear();
                                string opcSql = "select * from base_gongweiopc where gwID=" + models[0].ID + " and ID=" + item.ID;
                                var opcModel = db.ExecuteList<BaseGongweiOpcModel>(opcSql, pList.ToArray());

                                if (opcModel.Count > 0)
                                {
                                    updateSql = "update base_gongweiopc set gwID=@gwID,gwname=@gwname,opcValue=@opcValue where ID=@ID";
                                    pList.Clear();
                                    pList.Add(new MySqlParameter("@gwID", models[0].ID));
                                    pList.Add(new MySqlParameter("@gwname", models[0].gwname));
                                    pList.Add(new MySqlParameter("@opcValue", item.opcValue));
                                    pList.Add(new MySqlParameter("@ID", item.ID));
                                    ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, updateSql, pList.ToArray());
                                }
                                else
                                {
                                    updateSql = @"insert into base_gongweiopc(gwID,gwname,opcTypeID,opcTypeCode,opcValue,remark)
                                                      values(@gwID,@gwname,@opcTypeID,@opcTypeCode,@opcValue,@remark)";
                                    pList.Clear();
                                    pList.Add(new MySqlParameter("@gwID", models[0].ID));
                                    pList.Add(new MySqlParameter("@gwname", models[0].gwname));
                                    pList.Add(new MySqlParameter("@opcTypeID", item.opcTypeID));
                                    pList.Add(new MySqlParameter("@opcTypeCode", item.opcTypeCode));
                                    pList.Add(new MySqlParameter("@opcValue", item.opcValue));
                                    pList.Add(new MySqlParameter("@remark", item.remark));
                                    ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, updateSql, pList.ToArray());
                                }
                            }
                            else
                            {
                                pList.Clear();
                                string delopcSql = "delete from base_gongweiopc where ID=" + item.ID;
                                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, delopcSql, pList.ToArray());

                            }
                        }

                    }
                    myTrans.Commit();
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;

            }
        }

        /// <summary>
        /// 判断工位名称是否有相同的
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public bool GetGongWeiNameCount(string GwName, int ID = 0)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = string.Format(@"select count(*) from base_gongwei where gwname='{0}'", GwName);
            if (ID != 0)
            {
                sql += " and ID!=@ID ";
                pList.Add(new MySqlParameter("@ID", ID));
            }
            var ret = db.ExecuteScalar(sql, pList.ToArray());

            int rowcount = 0;

            int.TryParse(ret + "", out rowcount);

            return rowcount > 0 ? true : false;
        }

        /// <summary>
        /// 判断IP地址是否有相同的
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public bool GetGongWeiIPCount(string IP, int ID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select * from base_gongwei where IP=@IP and ID<>@ID ";
            pList.Add(new MySqlParameter("@IP", IP));
            pList.Add(new MySqlParameter("@ID", ID));
            return db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray()).Count > 0;
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">工位信息表Id</param>
        /// <returns></returns>
        public BaseGongweiModel GetBaseGongWeiId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from base_gongwei where 1=1 and ID=@ID";
            pList.Add(new MySqlParameter("@ID", Id));
            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray());
            if (list.Count > 0)
            {
                BaseGongweiModel gwModel = list[0];
                sql = "select * from base_gongweiOPC where gwID=" + Id;
                pList.Clear();
                List<BaseGongweiOpcModel> OPCList = db.ExecuteList<BaseGongweiOpcModel>(sql, pList.ToArray());
                if (OPCList.Count > 0)
                {
                    list[0].OPC = OPCList;
                    return list[0];
                }
            }

            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        //public void EditBaseGongWei(BaseGongweiModel model)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var entity = context.base_gongwei.SingleOrDefault<base_gongwei>(s => s.ID == model.ID);
        //        if (model == null)
        //        {
        //            return;
        //        }
        //        entity.gwcode = model.gwcode;
        //        entity.gwname = model.gwname;
        //        entity.gwStatus = model.gwStatus;
        //        entity.IP = model.IP;
        //        entity.areaID = model.areaID;
        //        entity.gwOrder = model.gwOrder;
        //        entity.isFinishGW = model.isFinishGW;
        //        entity.isHasFollow = model.isHasFollow;
        //        entity.isHasAms = model.isHasAms;
        //        entity.remark = model.remark;
        //        context.SaveChanges();
        //    }
        //}

        /// <summary>
        /// 根据工位ID删除【工位OPC点位信息表】
        /// </summary>
        /// <param name="id"></param>
        //public void OpcDel(int id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var query = context.base_gongweiOPC.Where(x => x.gwID == id).ToList();
        //        if (query != null)
        //        {
        //            for (int i = 0; i < query.Count; i++)
        //            {
        //                var opcid = Convert.ToInt32(query[i].ID);
        //                var delopc = context.base_gongweiOPC.SingleOrDefault<base_gongweiOPC>(x => x.ID == opcid);
        //                if (delopc == null)
        //                {
        //                    throw new Exception("未找到该工位OPC信息！");
        //                }
        //                context.base_gongweiOPC.Remove(delopc);
        //            }
        //            context.SaveChanges();
        //        }
        //    }
        //}


        /// <summary>
        /// 根据工位ID删除【工位信息表】
        /// 删除：如果删除主表下面的子表也会被同时删除
        /// </summary>
        /// <param name="gwid"></param>
        public void GwDel(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from base_gongweiopc where gwID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());

            sql = sql = "delete from base_gongwei where ID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 根据IP地址获取 是否需要启动OPC驱动
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool GetGwByIP(string ip)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from base_gongwei where IP=@IP ";
            pList.Add(new MySqlParameter("@IP", ip));
            var list = db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray());
            var opc = list[0].isOPC;
            return opc == 1 ? true : false;
        }

        #endregion

        #region 工位权限信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseGongweiRightModel> GetPagingBaseGongweiRight(BaseGongweiRightModel model, out int totalCount)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"SELECT 
                                  detail.ID as ID,detail.gwID as gwID,gwname as GwName,detail.empID as empID
                                 ,empName as EmpName,detail.gwrStatus as gwrStatus,detail.rightTypeID as rightTypeID
                                 ,GetbdNameBybdID(rightTypeID) as rightTypeName,detail.remark as remark
                                 FROM base_gongweiRight as detail
                                 LEFT JOIN base_gongwei as main
                                 ON detail.gwID=main.ID
                                 LEFT JOIN sys_User as emp
                                 ON detail.empID=emp.userID where 0=0 ";

            if (model != null)
            {
                if (model.gwID != 0)
                    sql += " and detail.gwID=@gwID ";

                pList.Add(new MySqlParameter("@gwID", model.gwID));
            }

            List<BaseGongweiRightModel> BaseGongweiRightModellist = db.ExecuteList<BaseGongweiRightModel>(sql, pList.ToArray());

            totalCount = BaseGongweiRightModellist.Count();

            BaseGongweiRightModellist = BaseGongweiRightModellist.Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize).ToList();

            return BaseGongweiRightModellist;
        }

        /// <summary>
        /// 查询下拉工位信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseGongweiModel> GetGongWei()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,gwname,agvAddress from base_gongwei ";

            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 查询下拉用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<UserModel> GetUserlist()
        {

            //return context.sys_User.Where(p => p.deleted == 0).Select(x => new UserModel { userID = x.userID, empName = x.empName }).ToList();

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select userID,empName from sys_User where deleted=0";
            List<UserModel> list = db.ExecuteList<UserModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">工位权限信息实体类</param>
        public void AddBaseGongweiRight(BaseGongweiRightModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"INSERT into base_gongweiRight (gwID,empID,gwrStatus,rightTypeID,remark,)
                                   VALUES(@gwID,@empID,@gwrStatus,@rightTypeID,@remark)";

            pList.Add(new MySqlParameter("@gwID", model.gwID));
            pList.Add(new MySqlParameter("@empID", model.empID));
            pList.Add(new MySqlParameter("@gwrStatus", model.gwrStatus));
            pList.Add(new MySqlParameter("@rightTypeID", model.rightTypeID));
            pList.Add(new MySqlParameter("@remark", model.remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 工位权限信息修改绑定
        /// </summary>
        /// <param name="Id">信息表Id</param>
        /// <returns></returns>
        public BaseGongweiRightModel GetBaseGongweiRightId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"SELECT ID,gwID,empID,gwrStatus,rightTypeID,remark from base_gongweiRight WHERE ID=@ID";

            pList.Add(new MySqlParameter("@ID", Id));

            List<BaseGongweiRightModel> BaseGongweiRightModel = db.ExecuteList<BaseGongweiRightModel>(sql, pList.ToArray());

            return BaseGongweiRightModel[0];
        }

        /// <summary>
        /// 工位权限信息修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseGongweiRight(BaseGongweiRightModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            if (model == null)
            {
                return;
            }
            string sql = @"UPDATE  base_gongweiRight SET gwID=@gwID,empID=@empID,gwrStatus=@gwrStatus,rightTypeID=@rightTypeID,remark=@remark WHERE ID=@ID";

            pList.Add(new MySqlParameter("@gwID", model.gwID));
            pList.Add(new MySqlParameter("@empID", model.empID));
            pList.Add(new MySqlParameter("@gwrStatus", model.gwrStatus));
            pList.Add(new MySqlParameter("@rightTypeID", model.rightTypeID));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@ID", model.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        //public void DeleteBaseGongweiRight(string id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        string[] ids = id.Split(',');
        //        for (int i = 0; i < ids.Length; i++)
        //        {
        //            var num = Convert.ToInt32(ids[i]);
        //            var items = context.base_gongweiRight.SingleOrDefault<base_gongweiRight>(s => s.ID == num);
        //            if (items == null)
        //            {
        //                throw new Exception("未找到该工位权限信息！");
        //            }
        //            context.base_gongweiRight.Remove(items);
        //        }
        //        context.SaveChanges(); ;
        //    }
        //}

        /// <summary>
        /// 获取员工工位权限
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        //public List<BaseGongweiRightModel> GetBaseGongweiRightModelByEmpID(int empID, int gwID)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var result = (from gwr in context.base_gongweiRight
        //                      join sbd in context.sys_baseData on gwr.rightTypeID equals sbd.ID
        //                      where gwr.empID == empID && gwr.gwID == gwID
        //                      select new BaseGongweiRightModel
        //                          {
        //                              ID = gwr.ID,
        //                              gwID = gwr.gwID,
        //                              empID = gwr.empID,
        //                              gwrStatus = gwr.gwrStatus,
        //                              rightTypeID = gwr.rightTypeID,
        //                              rightTypeName = sbd.bdname,
        //                              rightTypeCode = sbd.bdcode,
        //                              remark = gwr.remark
        //                          }).ToList();

        //        return result;
        //    }
        //}

        /// <summary>
        /// 获取工位权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseGongweiRightModel> GetRightList(BaseGongweiRightModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select a.*,b.bdname rightTypeName,b.bdcode rightTypeCode 
                                    from base_gongweiRight a 
                                    left join sys_baseData b on a.rightTypeID = b.ID 
                                    left join base_gongwei c on a.gwID=c.ID
                                    where a.empID=@empID and c.IP=@IP ";

            pList.Add(new MySqlParameter("@empID", model.empID));
            pList.Add(new MySqlParameter("@IP", model.IP));

            return db.ExecuteList<BaseGongweiRightModel>(sql, pList.ToArray());
        }
        #endregion

        #region 工具信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<GongjuModel> GetPagingBaseGongJu(GongjuModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            if (!string.IsNullOrEmpty(model.Gjname))
            {
                para += "and gjname like concat('%',@gjname,'%') ";
                pList.Add(new MySqlParameter("@gjname", model.Gjname.Trim()));
            }
            string sql = "select count(*) from base_gongju  where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select ID,Gjname,GjImg,GjTypeID,GetbdNameBybdID(gjTypeID) as GjTypeName,GjIsHasCode,GjStatus,
                           (case when gjStatus=0 then '启用' else '禁用' end) as `Status`,Remark,TorqueLocalIP,TorqueLocalPort from base_gongju where 1=1 ";
            sql += para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            return db.ExecuteList<GongjuModel>(sql, pList.ToArray());
        }
        /// <summary>
        /// 保存工具信息
        /// </summary>
        /// <param name="model">工具实体类</param>
        /// <returns></returns>
        public bool SaveBaseGongju(GongjuModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            if (model.ID == 0)
            {
                sql = @"insert into base_gongju(gjname,gjImg,gjTypeID,gjIsHasCode,gjStatus,remark,torqueLocalIP,torqueLocalPort)
                                   values(@gjname,@gjImg,@gjTypeID,@gjIsHasCode,@gjStatus,@remark,@torqueLocalIP,@torqueLocalPort)";
                pList.Add(new MySqlParameter("@gjname", model.Gjname));
                pList.Add(new MySqlParameter("@gjImg", model.GjImg));
                pList.Add(new MySqlParameter("@gjTypeID", model.GjTypeID ?? 0));
                pList.Add(new MySqlParameter("@gjIsHasCode", model.GjIsHasCode ?? 0));
                pList.Add(new MySqlParameter("@gjStatus", model.GjStatus ?? 0));
                pList.Add(new MySqlParameter("@remark", model.Remark ?? string.Empty));
                pList.Add(new MySqlParameter("@torqueLocalIP", model.TorqueLocalIP));
                pList.Add(new MySqlParameter("@torqueLocalPort", model.TorqueLocalPort));
            }
            else
            {
                sql = @"update base_gongju set gjname=@gjname,gjImg=@gjImg,gjTypeID=@gjTypeID,gjIsHasCode=@gjIsHasCode,
                            gjStatus=@gjStatus,remark=@remark,torqueLocalIP=@torqueLocalIP,torqueLocalPort=@torqueLocalPort where ID=@ID";
                pList.Add(new MySqlParameter("@gjname", model.Gjname));
                pList.Add(new MySqlParameter("@gjImg", model.GjImg));
                pList.Add(new MySqlParameter("@gjTypeID", model.GjTypeID ?? 0));
                pList.Add(new MySqlParameter("@gjIsHasCode", model.GjIsHasCode ?? 0));
                pList.Add(new MySqlParameter("@gjStatus", model.GjStatus ?? 0));
                pList.Add(new MySqlParameter("@remark", model.Remark ?? string.Empty));
                pList.Add(new MySqlParameter("@ID", model.ID));
                pList.Add(new MySqlParameter("@torqueLocalIP", model.TorqueLocalIP));
                pList.Add(new MySqlParameter("@torqueLocalPort", model.TorqueLocalPort));
            }
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }
        /// <summary>
        /// 获取所有工具信息下拉
        /// </summary>
        /// <returns></returns>
        public List<GongjuModel> GetAllBaseGongJu()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,Gjname,GjTypeID,TorqueLocalIP,TorqueLocalPort from base_gongju where gjStatus<>1 order by Gjname";

            List<GongjuModel> list = db.ExecuteList<GongjuModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取所有工具信息
        /// </summary>
        /// <returns></returns>
        public List<GongjuModel> GetGongju()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,Gjname,GjTypeID,GjImg,GjIsHasCode,GjStatus,Remark,TorqueLocalIP,TorqueLocalPort from base_gongju  where gjStatus<>1";

            List<GongjuModel> list = db.ExecuteList<GongjuModel>(sql, pList.ToArray());

            return list;
        }
        /// <summary>
        /// 工具类型下拉
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetGjType()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,bdname from sys_baseData where bdtypeCode='GongjuType' and isDeleted=0";

            List<BaseDataModel> list = db.ExecuteList<BaseDataModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">工具信息实体类</param>
        public void AddBaseGongju(GongjuModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into base_gongju(gjname,gjImg,gjTypeID,gjIsHasCode,gjStatus,remark,torqueLocalIP)
                                values(@gjname,@gjImg,@gjTypeID,@gjIsHasCode,@gjStatus,@remark,@torqueLocalIP)";

            pList.Add(new MySqlParameter("@gjname", model.Gjname));
            pList.Add(new MySqlParameter("@gjImg", model.GjImg));
            pList.Add(new MySqlParameter("@gjTypeID", model.GjTypeID ?? 0));
            pList.Add(new MySqlParameter("@gjIsHasCode", model.GjIsHasCode ?? 0));
            pList.Add(new MySqlParameter("@gjStatus", model.GjStatus ?? 0));
            pList.Add(new MySqlParameter("@remark", model.Remark ?? string.Empty));
            pList.Add(new MySqlParameter("@torqueLocalIP", model.TorqueLocalIP));
            pList.Add(new MySqlParameter("@torqueLocalPort", model.TorqueLocalPort));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 工具信息修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //public GongjuModel GetBaseGongJuId(int Id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        if (context.DBType == Common.EDAEnums.DataBaseType.MySql)
        //        {
        //            GongjuModel model = GetGongju().Where(x => x.ID == Id).FirstOrDefault();
        //            return model;
        //        }
        //        return context.base_gongju.Where(x => x.ID == Id).Select(x => new GongjuModel
        //        {
        //            ID = x.ID,
        //            Gjname = x.gjname,
        //            GjImg = x.gjImg,
        //            GjTypeID = x.gjTypeID,
        //            GjIsHasCode = x.gjIsHasCode,
        //            GjStatus = x.gjStatus,
        //            Remark = x.remark
        //        }).FirstOrDefault();
        //    }
        //}

        /// <summary>
        /// 工具信息修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseGongJu(GongjuModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_gongju set gjname=@gjname,gjImg=@gjImg,gjTypeID=@gjTypeID,gjIsHasCode=@gjIsHasCode,
                            gjStatus=@gjStatus,remark=@remark,torqueLocalIP=@torqueLocalIP,torqueLocalPort=@torqueLocalPort where ID=@ID";

            pList.Add(new MySqlParameter("@gjname", model.Gjname));
            pList.Add(new MySqlParameter("@gjImg", model.GjImg));
            pList.Add(new MySqlParameter("@gjTypeID", model.GjTypeID ?? 0));
            pList.Add(new MySqlParameter("@gjIsHasCode", model.GjIsHasCode ?? 0));
            pList.Add(new MySqlParameter("@gjStatus", model.GjStatus ?? 0));
            pList.Add(new MySqlParameter("@remark", model.Remark ?? string.Empty));
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@torqueLocalIP", model.TorqueLocalIP));
            pList.Add(new MySqlParameter("@torqueLocalPort", model.TorqueLocalPort));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseGongJu(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from  base_gongju  where ID in(" + id + ")";

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 物料/零件信息

        /// <summary>
        /// 分页查询 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<WuliaoModel> GetPagingBaseWuliao(WuliaoModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (!string.IsNullOrEmpty(model.wlname))
            {
                para += "and wlname like CONCAT('%',@wlname,'%') ";
                pList.Add(new MySqlParameter("@wlname", model.wlname));
            }

            if (!string.IsNullOrEmpty(model.wlcode))
            {
                para += "and wlcode like CONCAT('%',@wlcode,'%') ";
                pList.Add(new MySqlParameter("@wlcode", model.wlcode));
            }

            if (model.wlTypeID.HasValue && model.wlTypeID != 0)
            {
                para += "and wlTypeID = @wlTypeID ";
                pList.Add(new MySqlParameter("@wlTypeID", model.wlTypeID));
            }

            string sql = @"select Count(*) from base_wuliao where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select wl.ID,wlcode,wlname,wlTypeID,sb.bdname as wlTypeName,wlClass,wlImg,wlIsHasCode,wlStatus,
                            wl.remark from base_wuliao wl
                            left join sys_basedata sb on wl.wlTypeID = sb.ID
                            where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<WuliaoModel> list = db.ExecuteList<WuliaoModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取所有物料信息下拉
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModel> GetAllBaseWuliao()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,wlname from base_wuliao where wlStatus <>1";

            List<WuliaoModel> list = db.ExecuteList<WuliaoModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取所有物料/零件信息
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModel> GetWuliao()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,wlname,wlImg from base_wuliao";

            List<WuliaoModel> list = db.ExecuteList<WuliaoModel>(sql, pList.ToArray());

            return list;
        }
        /// <summary>
        /// 物料/零件类型下拉
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetWlType()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,bdname from sys_baseData where bdtypeCode = 'WuliaoType' ";

            List<BaseDataModel> list = db.ExecuteList<BaseDataModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 判断物料名称和规格是否存在
        /// </summary>
        /// <param name="wlname">物料名称</param>
        /// <param name="wlcode">物料规格</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public bool IsExistWuliaoNameANDCode(string wlname, string wlcode, int ID = 0)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            pList.Clear();
            string para = "";

            if (!string.IsNullOrEmpty(wlcode))
            {
                para = " and wlcode=@wlcode";
                pList.Add(new MySqlParameter("@wlcode", wlcode));
            }
            if (ID != 0)
            {
                para = " and ID<>@ID";
                pList.Add(new MySqlParameter("@ID", ID));
            }
            pList.Add(new MySqlParameter("@wlname", wlname));
            string sql = "select count(*) from base_wuliao where wlname=@wlname " + para;
            int rowcount = 0;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out rowcount);

            return rowcount > 0 ? true : false;
        }

        /// <summary>
        /// 批量添加物料
        /// </summary>
        /// <param name="model">物料实体类</param>
        /// <returns></returns>
        public void SaveWuliaoList(List<WuliaoModel> model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                try
                {
                    if (model.Count > 0)
                    {
                        foreach (WuliaoModel item in model)
                        {
                            string sql = "";
                            var result = IsExistWuliaoNameANDCode(item.wlname, item.wlcode, 0);
                            if (!result)
                            {
                                sql = @"insert into base_wuliao(wlcode,wlname,wlTypeID,wlIsHasCode,wlStatus) values(@wlcode,@wlname,@wlTypeID,@wlIsHasCode,@wlStatus)";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@wlcode", item.wlcode));
                                pList.Add(new MySqlParameter("@wlname", item.wlname));
                                pList.Add(new MySqlParameter("@wlTypeID", item.wlTypeID));
                                pList.Add(new MySqlParameter("@wlIsHasCode", item.wlIsHasCode));
                                pList.Add(new MySqlParameter("@wlStatus", item.wlStatus));
                                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                                int wlID = 0;
                                sql = "select @@identity;";
                                pList.Clear();
                                int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out wlID);

                                foreach (WuliaoModelModel dd in item.WuliaoSpecification)
                                {
                                    sql = @"insert into base_wuliaomodel(wlID,wlModels,wlUnit,isSetSafeInventory,safeInventory,wlModelStatus) 
                                                    values(@wlID,@wlModels,@wlUnit,@isSetSafeInventory,@safeInventory,@wlModelStatus)";
                                    pList.Clear();
                                    pList.Add(new MySqlParameter("@wlID", wlID));
                                    pList.Add(new MySqlParameter("@wlModels", dd.wlModels));
                                    pList.Add(new MySqlParameter("@wlUnit", dd.wlUnit));
                                    pList.Add(new MySqlParameter("@isSetSafeInventory", dd.isSetSafeInventory));
                                    pList.Add(new MySqlParameter("@safeInventory", dd.safeInventory));
                                    pList.Add(new MySqlParameter("@wlModelStatus", dd.wlModelStatus));
                                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                }

                            }
                        }
                    }
                    myTrans.Commit();
                }
                catch (Exception)
                {
                    myTrans.Rollback();

                    throw;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }

        /// <summary>
        /// 添加物料/零件信息
        /// </summary>
        /// <param name="model">物料/零件信息实体类</param>
        public void AddBaseWuliao(WuliaoModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into base_wuliao(wlcode,wlname,wlTypeID,wlClass,wlImg,wlIsHasCode,wlStatus,remark) values(@wlcode,@wlname,@wlTypeID,@wlClass,@wlImg,@wlIsHasCode,@wlStatus,@remark)";

            pList.Add(new MySqlParameter("@wlcode", model.wlcode));
            pList.Add(new MySqlParameter("@wlname", model.wlname));
            pList.Add(new MySqlParameter("@wlTypeID", model.wlTypeID));
            pList.Add(new MySqlParameter("@wlClass", model.wlClass));
            pList.Add(new MySqlParameter("@wlImg", model.wlImg));
            pList.Add(new MySqlParameter("@wlIsHasCode", model.wlIsHasCode));
            pList.Add(new MySqlParameter("@wlStatus", model.wlStatus));
            pList.Add(new MySqlParameter("@remark", model.remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        ///物料/零件信息修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public WuliaoModel GetBaseWuliaoId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,wlcode,wlname,wlTypeID,wlClass,wlImg,wlIsHasCode,wlStatus,remark from base_wuliao where ID = @ID";

            pList.Add(new MySqlParameter("@ID", Id));

            List<WuliaoModel> list = db.ExecuteList<WuliaoModel>(sql, pList.ToArray());

            if (list.Count > 0)
            {
                return list[0];
            }

            return null;

        }

        /// <summary>
        /// 修改物料/零件信息
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseWuliao(WuliaoModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_wuliao set wlcode=@wlcode,wlname=@wlname,wlTypeID=@wlTypeID,wlClass=@wlClass,wlImg=@wlImg,wlIsHasCode=@wlIsHasCode,wlStatus=@wlStatus,remark=@remark where ID = @ID";

            pList.Add(new MySqlParameter("@wlcode", model.wlcode));
            pList.Add(new MySqlParameter("@wlname", model.wlname));
            pList.Add(new MySqlParameter("@wlTypeID", model.wlTypeID));
            pList.Add(new MySqlParameter("@wlClass", model.wlClass));
            pList.Add(new MySqlParameter("@wlImg", model.wlImg));
            pList.Add(new MySqlParameter("@wlIsHasCode", model.wlIsHasCode));
            pList.Add(new MySqlParameter("@wlStatus", model.wlStatus));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@ID", model.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除物料/零件信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseWuliao(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_wuliao where id in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());

            sql = "delete from base_wuliaoModel where wlID in(" + id + ")";

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 物料/零件编码规格 LHR

        /// <summary>
        /// 物料/零件编码规格分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<WuliaoModelModel> GetPagingWuliaoCode(WuliaoModelModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            //if (!string.IsNullOrEmpty(model.wlcode))
            //{
            //    para += " and wlc.wlcode like CONCAT('%',@wlcode,'%') ";
            //    pList.Add(new MySqlParameter("@wlcode", model.wlcode));
            //}

            string sql = string.Format(@"select count(*) from base_wuliaomodel wlc
							                        left join base_wuliao wl on wlc.wlID = wl.ID
							                        where 1=1 and wlID ={0} ", model.wlID) + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            sql = string.Format(@"select wlmodelID,wlID,wl.wlname as wlText,wlModels,wlUnit,wlSupplierNo,wlFigureNo,wlBatchNo			
                            wlStandard,isSetSafeInventory,case when isSetSafeInventory = 0 then '不考虑' else '考虑' end as IsSetSafeInventoryText,
                            safeInventory,wlModelStatus,case when wlModelStatus = 1 then '启用' else '禁用' end as Status,wlc.remark	from base_wuliaomodel wlc
							left join base_wuliao wl on wlc.wlID = wl.ID
							where 1=1 and wlID ={0} ", model.wlID) + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<WuliaoModelModel> list = db.ExecuteList<WuliaoModelModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取所有物料规格信息下拉
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModelModel> GetAllBaseWuliaoCode()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select  bdCode.wlmodelID,CONCAT_WS('-',wl.wlname,bdCode.wlModels) wlModels from base_wuliaomodel bdCode LEFT JOIN base_wuliao wl
                                   on bdCode.wlID=wl.ID";

            List<WuliaoModelModel> list = db.ExecuteList<WuliaoModelModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 根据出勤模式名称查询是否有相同名称
        /// </summary>
        /// <param name="wmName"></param>
        /// <returns></returns>
        //public bool GetWorkModetWmName(string wmName)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        if (context.DBType == Common.EDAEnums.DataBaseType.MySql)
        //        {
        //            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
        //            List<MySqlParameter> pList = new List<MySqlParameter>();
        //            string sql = @"select count(*) from base_workmode where wmName = @wmName";
        //            pList.Add(new MySqlParameter("@wmName", wmName));
        //            int list = int.Parse(db.ExecuteScalar(sql, pList.ToArray()).ToString());
        //            if (list > 0)
        //                return true;
        //            return false;
        //        }

        //        var Count = context.base_workmode.Where(x => x.wmName == wmName).Count();
        //        if (Count > 0)
        //            return true;
        //        return false;

        //    }
        //}

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">出勤模式表</param>
        public void AddWuliaoCode(WuliaoModelModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into base_wuliaomodel(wlID,wlModels,wlUnit,wlSupplierNo,wlFigureNo,wlBatchNo,wlStandard,isSetSafeInventory,safeInventory,wlModelStatus,remark) 
                                    values(@wlID,@wlModels,@wlUnit,@wlSupplierNo,@wlFigureNo,@wlBatchNo,@wlStandard,@isSetSafeInventory,@safeInventory,@wlModelStatus,@remark)";

            pList.Add(new MySqlParameter("@wlID", model.wlID));
            pList.Add(new MySqlParameter("@wlModels", model.wlModels));
            pList.Add(new MySqlParameter("@wlUnit", model.wlUnit));
            pList.Add(new MySqlParameter("@wlSupplierNo", model.wlSupplierNo));
            pList.Add(new MySqlParameter("@wlFigureNo", model.wlFigureNo));
            pList.Add(new MySqlParameter("@wlBatchNo", model.wlBatchNo));
            pList.Add(new MySqlParameter("@wlStandard", model.wlStandard));
            pList.Add(new MySqlParameter("@isSetSafeInventory", model.isSetSafeInventory));
            pList.Add(new MySqlParameter("@safeInventory", model.safeInventory));
            pList.Add(new MySqlParameter("@wlModelStatus", model.wlModelStatus));
            pList.Add(new MySqlParameter("@remark", model.remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditWuliaoCode(WuliaoModelModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_wuliaomodel set wlID=@wlID,wlModels=@wlModels,wlUnit=@wlUnit,wlSupplierNo=@wlSupplierNo,wlFigureNo=@wlFigureNo,
                                    wlBatchNo=@wlBatchNo,wlStandard=@wlStandard,isSetSafeInventory=@isSetSafeInventory,safeInventory=@safeInventory,wlModelStatus=@wlModelStatus,remark=@remark
                                    where wlmodelID = @wlmodelID";

            pList.Add(new MySqlParameter("@wlID", model.wlID));
            pList.Add(new MySqlParameter("@wlModels", model.wlModels));
            pList.Add(new MySqlParameter("@wlUnit", model.wlUnit));
            pList.Add(new MySqlParameter("@wlSupplierNo", model.wlSupplierNo));
            pList.Add(new MySqlParameter("@wlFigureNo", model.wlFigureNo));
            pList.Add(new MySqlParameter("@wlBatchNo", model.wlBatchNo));
            pList.Add(new MySqlParameter("@wlStandard", model.wlStandard));
            pList.Add(new MySqlParameter("@isSetSafeInventory", model.isSetSafeInventory));
            pList.Add(new MySqlParameter("@safeInventory", model.safeInventory));
            pList.Add(new MySqlParameter("@wlModelStatus", model.wlModelStatus));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@wlmodelID", model.wlmodelID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWuliaoCode(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_wuliaomodel where wlmodelID in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 工位&产品型号关联配置 WZQ
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseGwProdDefModel> GetPagingBaseGwProdDef(BaseGwProdDefModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.gwID != 0 && model.gwID != null)
            {
                para += " and gpd.gwID = @gwID ";
                pList.Add(new MySqlParameter("@gwID", model.gwID));
            }

            if (model.prodModelID != 0 && model.prodModelID != null)
            {
                para += " and prodModelID = @prodModelID ";
                pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            }
            if (model.componentID != 0 && model.componentID != null)
            {
                para += " and componentID = @componentID ";
                pList.Add(new MySqlParameter("@componentID", model.componentID));
            }
            if (model.operationID.HasValue && model.operationID != 0)
            {
                para += " and operationID = @operationID ";
                pList.Add(new MySqlParameter("@operationID", model.operationID));
            }
            string sql = @"select Count(*)
							        from gw_prod_def gpd
							        left join base_productModel bpm on gpd.prodModelID = bpm.ID
							        left join base_program pg on gpd.progID = pg.ID
							        left join base_product bp on bpm.PID = bp.ID
							        left join base_gongwei gw on gpd.gwID = gw.ID
							        left join base_wuliao wl on gpd.componentID = wl.ID
							        where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            sql = @"select gpd.ID,gpd.gwID,GetGwNameByID(gpd.gwID) as GwName,prodModelID,CONCAT_WS('-',bpm.Pmodel,bpm.DrawingNo) as ProdModelName,
                    componentID,wl.wlname as ComponentName,progID,pg.progName as ProgName,gpd.operationID,GetPartGongxuByID(gpd.operationID) as operationName,gpd.beatMinite,gpd.remark
							from gw_prod_def gpd
							left join base_productModel bpm on gpd.prodModelID = bpm.ID
							left join base_wuliao wl on gpd.componentID = wl.ID
							left join base_program pg on gpd.progID = pg.ID
							where 1=1 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseGwProdDefModel> list = db.ExecuteList<BaseGwProdDefModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取工位产品关联信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseGwProdDefModel> GetGWProdDefList(BaseGwProdDefModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.gwID != 0 && model.gwID != null)
            {
                para += " and gpd.gwID = @gwID ";
                pList.Add(new MySqlParameter("@gwID", model.gwID));
            }

            if (model.prodModelID != 0 && model.prodModelID != null)
            {
                para += " and prodModelID = @prodModelID ";
                pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            }
            if (model.componentID != 0 && model.componentID != null)
            {
                para += " and componentID = @componentID ";
                pList.Add(new MySqlParameter("@componentID", model.componentID));
            }

            string sql = @"select gpd.ID,gpd.gwID,gw.gwname as GwName,prodModelID,CONCAT_WS('-',bp.Pname,bpm.Pmodel) as ProdModelName,componentID
,wl.wlname as ComponentName,progID,pg.progName as ProgName,gpd.beatMinite,gpd.remark
							from gw_prod_def gpd
							left join base_productModel bpm on gpd.prodModelID = bpm.ID
							left join base_product bp on bpm.PID = bp.ID
							left join base_gongwei gw on gpd.gwID = gw.ID
							left join base_wuliao wl on gpd.componentID = wl.ID
							left join base_program pg on gpd.progID = pg.ID 
							where 1=1 " + para;

            List<BaseGwProdDefModel> list = db.ExecuteList<BaseGwProdDefModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取产品型号下拉信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetProductModel()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select a.ID,CONCAT_WS('-',b.Pname,a.Pmodel) as Pmodel,a.PID
                                    from base_productModel a
                                    left join base_product b on a.PID = b.ID ";

            return db.ExecuteList<BaseProductModelModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 获取产品型号信息2019-05-15
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetAllBaseProModel()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select bpm.ID,bpm.Pmodel,bpm.PID,bp.Pname
							    from base_productModel bpm
							    left join base_product bp on bpm.PID = bp.ID";

            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, pList.ToArray());

            return list;
        }
        /// <summary>
        /// 获取物料组件下拉信息
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModel> GetWuliaoType()
        {
            int typeID = 61;
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,wlname from base_wuliao
                                   where wlTypeID = @wlTypeID ";
            pList.Add(new MySqlParameter("@wlTypeID", typeID));
            List<WuliaoModel> list = db.ExecuteList<WuliaoModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 获取程序下拉信息
        /// </summary>
        /// <returns></returns>
        public List<BaseProgram> GetBaseProgram()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,ProgName from base_program";

            List<BaseProgram> list = db.ExecuteList<BaseProgram>(sql, pList.ToArray());

            return list;
        }



        /// <summary>
        /// 获取程序下拉信息
        /// </summary>
        /// <returns></returns>
        public List<BaseProgram> GetBaseProgram(int p)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,ProgName from base_program";

            List<BaseProgram> list = db.ExecuteList<BaseProgram>(sql, pList.ToArray());

            return list;
        }



        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseGwProdDef(BaseGwProdDefModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into gw_prod_def(gwID,prodModelID,componentID,progID,operationID,beatMinite,remark) 
                                    values(@gwID,@prodModelID,@componentID,@progID,@operationID,@beatMinite,@remark)";

            pList.Add(new MySqlParameter("@gwID", model.gwID));
            pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            pList.Add(new MySqlParameter("@componentID", model.componentID));
            pList.Add(new MySqlParameter("@progID", model.progID));
            pList.Add(new MySqlParameter("@operationID", model.operationID));
            pList.Add(new MySqlParameter("@beatMinite", model.beatMinite));
            pList.Add(new MySqlParameter("@remark", model.remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseGwProdDefModel GetBaseGwProdDefId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,gwID,prodModelID,componentID,progID,beatMinite,remark from gw_prod_def
                                   where ID = @ID ";

            pList.Add(new MySqlParameter("@ID", Id));

            List<BaseGwProdDefModel> list = db.ExecuteList<BaseGwProdDefModel>(sql, pList.ToArray());

            if (list.Count > 0)
            {
                return list[0];
            }

            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseGwProdDef(BaseGwProdDefModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update gw_prod_def set gwID=@gwID,prodModelID=@prodModelID,componentID=@componentID,progID=@progID,operationID=@operationID,beatMinite=@beatMinite,remark=@remark
                                    where ID = @ID";

            pList.Add(new MySqlParameter("@gwID", model.gwID));
            pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            pList.Add(new MySqlParameter("@componentID", model.componentID));
            pList.Add(new MySqlParameter("@progID", model.progID));
            pList.Add(new MySqlParameter("@operationID", model.operationID));
            pList.Add(new MySqlParameter("@beatMinite", model.beatMinite));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@ID", model.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseGwProdDef(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from gw_prod_def where ID in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 产品bom信息

        /// <summary>
        /// 分页查询 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseBomModel> GetPagingBaseBOM(BaseBomModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.prodModelId != null && model.prodModelId != 0)
            {
                para += " and prodModelId = @prodModelId ";
                pList.Add(new MySqlParameter("@prodModelId", model.prodModelId));
            }

            if (model.replaceTypeID != null && model.replaceTypeID != -1)
            {
                para += " and replaceTypeID = @replaceTypeID ";
                pList.Add(new MySqlParameter("@replaceTypeID", model.replaceTypeID));
            }

            if (model.wuliaoLJid != null && model.wuliaoLJid != 0)
            {
                para += " and wuliaoLJid = @wuliaoLJid ";
                pList.Add(new MySqlParameter("@wuliaoLJid", model.wuliaoLJid));
            }

            string sql = @"select Count(*) 
							      from base_bom bom
                                  left join base_productModel pm on bom.prodModelId = pm.ID
                                  left join base_material wl on bom.wuliaoLJid = wl.ID
                                  left join base_gongwei Gw on bom.GwID = Gw.ID
                                  left join base_program Gy on bom.progID = Gy.ID
							      where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            sql = @"select bom.*,
                           pm.Pmodel as ProdModelName,
                           wl.mName as wuliaoLJName,
                           Gw.gwname as GwName,
                           Gy.progName as progName
                           from base_bom bom
                           left join base_productModel pm on bom.prodModelId = pm.ID
                           left join base_material wl on bom.wuliaoLJid = wl.ID
                           left join base_gongwei Gw on bom.GwID = Gw.ID
                           left join base_program Gy on bom.progID = Gy.ID
						   where 1=1 " + para;

            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<BaseBomModel> list = db.ExecuteList<BaseBomModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary> 
        /// 添加 
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseBom(BaseBomModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into base_bom(prodModelId,GwID,replaceTypeID,progID,wuliaoLJid,replaceQty) 
                                    values(@prodModelId,@GwID,@replaceTypeID,@progID,@wuliaoLJid,@replaceQty)";

            pList.Add(new MySqlParameter("@prodModelId", model.prodModelId));
            pList.Add(new MySqlParameter("@GwID", model.GwID));
            pList.Add(new MySqlParameter("@replaceTypeID", model.replaceTypeID));
            pList.Add(new MySqlParameter("@progID", model.progID));
            pList.Add(new MySqlParameter("@wuliaoLJid", model.wuliaoLJid));

            pList.Add(new MySqlParameter("@replaceQty", model.replaceQty));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改 
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseBom(BaseBomModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_productBOM set prodModelId=@prodModelId,GwID=@GwID,replaceTypeID=@replaceTypeID,progID=@progID,wuliaoLJid=@wuliaoLJid,
                                    replaceTypeID=@replaceTypeID,replaceQty=@replaceQty
                                    where ID = @ID";
            pList.Add(new MySqlParameter("@prodModelId", model.prodModelId));
            pList.Add(new MySqlParameter("@GwID", model.GwID));
            pList.Add(new MySqlParameter("@replaceTypeID", model.replaceTypeID));
            pList.Add(new MySqlParameter("@progID", model.progID));
            pList.Add(new MySqlParameter("@wuliaoLJid", model.wuliaoLJid));
            pList.Add(new MySqlParameter("@replaceTypeID", model.replaceTypeID));
            pList.Add(new MySqlParameter("@replaceQty", model.replaceQty));
            pList.Add(new MySqlParameter("@ID", model.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseBom(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_productBOM where ID in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 产品关键零部件信息(改名为 产品BOM) LHR 2019-09-24

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductBomModel> GetPagingBaseProductLingJian(BaseProductBomModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.prodModelId != null && model.prodModelId != 0)
            {
                para += " and prodModelId = @prodModelId ";
                pList.Add(new MySqlParameter("@prodModelId", model.prodModelId));
            }

            if (model.replaceTypeID != null && model.replaceTypeID != -1)
            {
                para += " and replaceTypeID = @replaceTypeID ";
                pList.Add(new MySqlParameter("@replaceTypeID", model.replaceTypeID));
            }

            if (model.wuliaoLJid != null && model.wuliaoLJid != 0)
            {
                para += " and wuliaoLJid = @wuliaoLJid ";
                pList.Add(new MySqlParameter("@wuliaoLJid", model.wuliaoLJid));
            }

            if (model.partId != null && model.partId != 0)
            {
                para += " and partId = @partId ";
                pList.Add(new MySqlParameter("@partId", model.partId));
            }

            string sql = @"select Count(*) 
							        from base_productBOM bom
                                    left join base_productModel pm on bom.prodModelId = pm.ID
                                    left join base_product pd on pm.PID = pd.ID
                                    left join base_wuliao wl on bom.wuliaoLJid = wl.ID
                                    left join base_gongwei AmsGw on bom.amsGwID = AmsGw.ID
                                    left join base_wuliao wlzj on bom.partId = wlzj.ID
                                    left join base_gongwei DisGw on bom.disGwID = DisGw.ID
							        left join base_wuliaoModel wlc on bom.wuliaoModelID = wlc.wlmodelID
							        left join program_gxinfo gx on bom.program_GxInfoID = gx.ID
							        where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            //wl.wlcode as Wlcode, 目前是有问题的 取物料表还是 物料code表  现在知道物料表就同时也知道wuliao的code
            sql = @"select 
                            bom.ID,
                            prodModelId,
                            CONCAT_WS('-',pd.Pname,pm.Pmodel) as ProdModelName,
                            partId,
                            wlzj.wlname as partName,
                            replaceTypeID,
                            case when replaceTypeID = 0 then '其他' when replaceTypeID = 1 then '必换件' when replaceTypeID = 2 then '偶换件' when replaceTypeID = 3 then '组件' else '' end as ReplaceType,
                            wuliaoLJid,
                            wl.wlname as wuliaoLJName,
                            wuliaoModelID,
							wlc.wlModels as Wlmodel,
                            isKeyLJ,
                            case when isKeyLJ = 0 then '否' else '是' end as IsKeyLJName,
                            isComingHang,
                            case when isComingHang = 0 then '否' else '是' end as IsComingHangName,
                            replaceQty,
                            replaceRate,
                            amsGwID,
                            AmsGw.gwname as AmsGwName,
                            disGwID,
                            DisGw.gwname as DisGwName,
                            program_GxInfoID,
							gx.Gxname as Gxname,
                            bom.remark
                            from base_productBOM bom
                            left join base_productModel pm on bom.prodModelId = pm.ID
                            left join base_product pd on pm.PID = pd.ID
                            left join base_wuliao wl on bom.wuliaoLJid = wl.ID
                            left join base_gongwei AmsGw on bom.amsGwID = AmsGw.ID
                            left join base_wuliao wlzj on bom.partId = wlzj.ID
                            left join base_gongwei DisGw on bom.disGwID = DisGw.ID
							left join base_wuliaoModel wlc on bom.wuliaoModelID = wlc.wlmodelID
							left join program_gxinfo gx on bom.program_GxInfoID = gx.ID
							where 1=1 " + para;

            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<BaseProductBomModel> list = db.ExecuteList<BaseProductBomModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// BOM数据通用查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseProductBomModel> GetBomList(BaseProductBomModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.prodModelId.HasValue && model.prodModelId != 0)
            {
                para += " and bom.prodModelId = @prodModelId";
                pList.Add(new MySqlParameter("@prodModelId", model.prodModelId));
            }
            if (model.partId.HasValue && model.partId != 0)
            {
                para += " and bom.partId = @partId ";
                pList.Add(new MySqlParameter("@partId", model.partId));
            }
            if (model.isKeyLJ.HasValue)
            {
                para += " and bom.isKeyLJ = @isKeyLJ ";
                pList.Add(new MySqlParameter("@isKeyLJ", model.isKeyLJ));
            }

            string sql = @"select pm.Pmodel,wl.wlname partName,lj.wlname wuliaoLJName,bom.* from base_productbom bom
                                    left join base_productmodel pm on pm.ID=bom.prodModelId
                                    left join base_wuliao wl on wl.ID=bom.partId
                                    left join base_wuliao lj on lj.ID=bom.wuliaoLJid
                                    where 1=1 " + para;

            List<BaseProductBomModel> list = db.ExecuteList<BaseProductBomModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取物料编码下拉
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<WuliaoModelModel> GetWuliaoCode(int wlID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (wlID != 0)
            {
                para += "and wlID = @wlID ";
                pList.Add(new MySqlParameter("@wlID", wlID));
            }

            string sql = @"select wlmodelID,wlModels from base_wuliaoModel where wlModelStatus <> 0 " + para;

            List<WuliaoModelModel> list = db.ExecuteList<WuliaoModelModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取工位区域 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<GongweiModel> GetGongWeiArea(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,Gwname from base_gongwei where areaID = @areaID";

            pList.Add(new MySqlParameter("@areaID", Id));

            List<GongweiModel> list = db.ExecuteList<GongweiModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary> 
        /// 添加 
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseProductLingJian(BaseProductBomModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into base_productBOM(prodModelId,partId,replaceTypeID,wuliaoLJid,wuliaoModelID,isKeyLJ,isComingHang,replaceQty,replaceRate,amsGwID,disGwID,program_GxInfoID,remark) 
                                    values(@prodModelId,@partId,@replaceTypeID,@wuliaoLJid,@wlmodelID,@isKeyLJ,@isComingHang,@replaceQty,@replaceRate,@amsGwID,@disGwID,@program_GxInfoID,@remark)";

            pList.Add(new MySqlParameter("@prodModelId", model.prodModelId));
            pList.Add(new MySqlParameter("@partId", model.partId));
            pList.Add(new MySqlParameter("@replaceTypeID", model.replaceTypeID));
            pList.Add(new MySqlParameter("@wuliaoLJid", model.wuliaoLJid));
            pList.Add(new MySqlParameter("@wuliaoModelID", model.wuliaoModelID));
            pList.Add(new MySqlParameter("@isKeyLJ", model.isKeyLJ));
            pList.Add(new MySqlParameter("@isComingHang", model.isComingHang));
            pList.Add(new MySqlParameter("@replaceQty", model.replaceQty));
            pList.Add(new MySqlParameter("@replaceRate", model.replaceRate));
            pList.Add(new MySqlParameter("@amsGwID", model.amsGwID));
            pList.Add(new MySqlParameter("@disGwID", model.disGwID));
            pList.Add(new MySqlParameter("@program_GxInfoID", model.program_GxInfoID));
            pList.Add(new MySqlParameter("@remark", model.remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //  public BaseProductBomModel GetBaseProductLingJian(int Id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        return context.base_productLingjian.Where(x => x.id == Id).Select(x => new BaseProductBomModel
        //        {
        //            ID = x.id,
        //            prodModelId = x.prodModelId,
        //            //componentId = x.componentId,
        //            replaceTypeID = x.replaceTypeID,
        //            wuliaoLJid = x.wuliaoLJid,
        //            isKeyLJ = x.isKeyLJ,
        //            isComingHang = x.isComingHang,
        //            replaceQty = x.replaceQty,
        //            replaceRate = x.replaceRate,
        //            //supplyNo = x.supplyNo,
        //            amsGwID = x.amsGwID,
        //            disGwID = x.disGwID,
        //            //CheckTipMemo = x.checkTipMemo,
        //            remark = x.remark
        //        }).FirstOrDefault();
        //    }
        //}

        /// <summary>
        /// 修改 
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProductLingJian(BaseProductBomModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_productBOM set prodModelId=@prodModelId,partId=@partId,replaceTypeID=@replaceTypeID,wuliaoLJid=@wuliaoLJid,wuliaoModelID=@wuliaoModelID,
                                    isKeyLJ=@isKeyLJ,isComingHang=@isComingHang,replaceQty=@replaceQty,replaceRate=@replaceRate,amsGwID=@amsGwID,disGwID=@disGwID,program_GxInfoID=@program_GxInfoID,remark=@remark
                                    where ID = @ID";

            pList.Add(new MySqlParameter("@prodModelId", model.prodModelId));
            pList.Add(new MySqlParameter("@partId", model.partId));
            pList.Add(new MySqlParameter("@replaceTypeID", model.replaceTypeID));
            pList.Add(new MySqlParameter("@wuliaoLJid", model.wuliaoLJid));
            pList.Add(new MySqlParameter("@wuliaoModelID", model.wuliaoModelID));
            pList.Add(new MySqlParameter("@isKeyLJ", model.isKeyLJ));
            pList.Add(new MySqlParameter("@isComingHang", model.isComingHang));
            pList.Add(new MySqlParameter("@replaceQty", model.replaceQty));
            pList.Add(new MySqlParameter("@replaceRate", model.replaceRate));
            pList.Add(new MySqlParameter("@amsGwID", model.amsGwID));
            pList.Add(new MySqlParameter("@disGwID", model.disGwID));
            pList.Add(new MySqlParameter("@program_GxInfoID", model.program_GxInfoID));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@ID", model.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        //public void DelProdLjCheckTip(int Id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var detail = context.base_prodLjCheckTip.Where(x => x.prodLjDefId == Id).ToList();
        //        if (detail != null)
        //        {
        //            var list = detail.ToList();
        //            for (int i = 0; i < list.Count; i++)
        //            {
        //                var nums = Convert.ToInt32(list[i].id);
        //                var items = context.base_prodLjCheckTip.SingleOrDefault<base_prodLjCheckTip>(s => s.id == nums);
        //                if (items != null)
        //                {
        //                    context.base_prodLjCheckTip.Remove(items);
        //                    context.SaveChanges();
        //                }
        //            }
        //        }
        //    }
        //}

        /// <summary>
        ///  删除：如果删除主表下面的子表也会被同时删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProductLingJian(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_productBOM where id in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 部件质检标准 Update By Leon 20191011

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BasePartCheckTipModel> GetPagingProdLjCheckTip(BasePartCheckTipModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.prodLjDefId != 0)
            {
                para += " and prodLjDefId = @prodLjDefId ";
                pList.Add(new MySqlParameter("@prodLjDefId", model.prodLjDefId));
            }

            if (!string.IsNullOrEmpty(model.stepName))
            {
                para += " and stepName like CONCAT('%',@stepName,'%') ";
                pList.Add(new MySqlParameter("@stepName", model.stepName));
            }

            string sql = @"select Count(*)
                                    from base_partCheckTip pct
                                    left join base_productbom bom on pct.prodLjDefId = bom.ID
                                    left join base_productModel pm on bom.prodModelId = pm.ID
                                    left join base_product pd on pm.PID = pd.ID
                                    left join base_wuliao wl on bom.wuliaoLJid = wl.ID
                                    left join base_wuliao wlzj on bom.partId = wlzj.ID
                                    left join base_wuliaoModel wlc on bom.wuliaoModelID = wlc.wlmodelID
                                    left join base_gongwei AmsGw on bom.amsGwID = AmsGw.ID
                                    left join base_gongwei DisGw on bom.disGwID = DisGw.ID
                                    left join base_gongxu gx on bom.program_GxInfoID = gx.ID
                                    where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            sql = @"select pct.ID,prodLjDefId,CONCAT_WS('-',pd.Pname,pm.Pmodel) as ProdModelName,stepNo,stepName,checkStandard,checkTipMemo,samplePicture,toolPicture,pct.remark
                                from base_partCheckTip pct
                                left join base_productbom bom on pct.prodLjDefId = bom.ID
                                left join base_productModel pm on bom.prodModelId = pm.ID
                                left join base_product pd on pm.PID = pd.ID
                                left join base_wuliao wl on bom.wuliaoLJid = wl.ID
                                left join base_wuliao wlzj on bom.partId = wlzj.ID
                                left join base_wuliaoModel wlc on bom.wuliaoModelID = wlc.wlmodelID
                                left join base_gongwei AmsGw on bom.amsGwID = AmsGw.ID
                                left join base_gongwei DisGw on bom.disGwID = DisGw.ID
                                left join base_gongxu gx on bom.program_GxInfoID = gx.ID
                                where 1=1 " + para;
            sql += " order by stepNo asc limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize + "";

            List<BasePartCheckTipModel> lists = db.ExecuteList<BasePartCheckTipModel>(sql, pList.ToArray());

            return lists;
        }

        /// <summary>
        /// 获取所有质检提示说明
        /// </summary>
        /// <returns></returns>
        public List<BasePartCheckTipModel> GetProdLjCheckTip()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,prodLjDefId,stepNo,stepName,checkStandard,checkTipMemo,samplePicture,toolPicture,remark from base_partCheckTip";

            List<BasePartCheckTipModel> list = db.ExecuteList<BasePartCheckTipModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseProdLjCheckTip(BasePartCheckTipModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into base_partCheckTip(prodLjDefId,stepNo,stepName,checkStandard,checkTipMemo,samplePicture,toolPicture,remark) 
                                    values(@prodLjDefId,@stepNo,@stepName,@checkStandard,@checkTipMemo,@samplePicture,@toolPicture,@remark)";

            pList.Add(new MySqlParameter("@prodLjDefId", model.prodLjDefId));
            pList.Add(new MySqlParameter("@stepNo", model.stepNo));
            pList.Add(new MySqlParameter("@stepName", model.stepName));
            pList.Add(new MySqlParameter("@checkStandard", model.checkStandard));
            pList.Add(new MySqlParameter("@checkTipMemo", model.checkTipMemo));
            pList.Add(new MySqlParameter("@samplePicture", model.samplePicture));
            pList.Add(new MySqlParameter("@toolPicture", model.toolPicture));
            pList.Add(new MySqlParameter("@remark", model.remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">质检提示说明Id</param>
        /// <returns></returns>
        public BasePartCheckTipModel GetBaseProdLjCheckTipId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,prodLjDefId,stepNo,stepName,checkStandard,checkTipMemo,samplePicture,toolPicture,remark from base_partCheckTip where id = @ID";
            pList.Add(new MySqlParameter("@ID", Id));
            List<BasePartCheckTipModel> list = db.ExecuteList<BasePartCheckTipModel>(sql, pList.ToArray());

            if (list.Count > 0)
                return list[0];

            return null;
        }

        /// <summary>
        /// 根据当前 产品关键零部件设置表ID 查询返回排序
        /// </summary>
        /// <param name="prodLjDefId"></param>
        /// <returns></returns>
        public int GetStepNo(int prodLjDefId)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select Count(*) from base_partCheckTip where prodLjDefId = @prodLjDefId ";

            pList.Add(new MySqlParameter("@prodLjDefId", prodLjDefId));

            int StepNo = int.Parse(db.ExecuteScalar(sql, pList.ToArray()).ToString());

            return StepNo;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProdLjCheckTip(BasePartCheckTipModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_partCheckTip set prodLjDefId=@prodLjDefId,stepNo=@stepNo,stepName=@stepName,
                                    checkStandard=@checkStandard,checkTipMemo=@checkTipMemo,samplePicture=@samplePicture,toolPicture=@toolPicture,remark=@remark
                                    where id = @ID";

            pList.Add(new MySqlParameter("@prodLjDefId", model.prodLjDefId));
            pList.Add(new MySqlParameter("@stepNo", model.stepNo));
            pList.Add(new MySqlParameter("@stepName", model.stepName));
            pList.Add(new MySqlParameter("@checkStandard", model.checkStandard));
            pList.Add(new MySqlParameter("@checkTipMemo", model.checkTipMemo));
            pList.Add(new MySqlParameter("@samplePicture", model.samplePicture));
            pList.Add(new MySqlParameter("@toolPicture", model.toolPicture));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@ID", model.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProdLjCheckTip(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_partCheckTip where id in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BasePartCheckValueModel> GetPartCheckValue(BasePartCheckValueModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.partCheck_ID != 0)
            {
                para += " and partCheck_ID = @partCheck_ID ";
                pList.Add(new MySqlParameter("@partCheck_ID", model.partCheck_ID));
            }

            string sql = @"select Count(*)
                                    from base_partCheckValue pcv
                                    left join base_partCheckTip pct on pcv.partCheck_ID = pct.id
                                    where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            sql = @"select  pcv.id,partCheck_ID,pct.stepName as stepName,valueTypeID,sb1.bdname as valueTypeText,EqualTypeID,
                                sb2.bdname as EqualTypeText,standardValue,minValue,`maxValue`,pcv.remark 
                                from base_partCheckValue pcv
                                left join base_partCheckTip pct on pcv.partCheck_ID = pct.id
                                left join sys_basedata sb1 on pcv.valueTypeID = sb1.ID
                                left join sys_basedata sb2 on pcv.EqualTypeID = sb2.ID
                                where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize + "";

            List<BasePartCheckValueModel> lists = db.ExecuteList<BasePartCheckValueModel>(sql, pList.ToArray());

            return lists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BasePartCheckValueModel> GetPartCheckValueList(BasePartCheckValueModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            if (model.partCheck_ID != 0)
            {
                para += " and partCheck_ID = @partCheck_ID ";
                pList.Add(new MySqlParameter("@partCheck_ID", model.partCheck_ID));
            }
            if (model.prodLjDefId.HasValue)
            {
                para += " and pct.prodLjDefId = @prodLjDefId ";
                pList.Add(new MySqlParameter("@prodLjDefId", model.prodLjDefId));
            }
            string sql = @"select  pcv.ID,partCheck_ID,pct.stepName as stepName,pct.checkTipMemo,pct.samplePicture,pct.toolPicture
,pct.checkStandard,pct.manuaFlag,valueTypeID,sb1.bdname as valueTypeText,EqualTypeID,sb2.bdname as EqualTypeText,standardValue,minValue
,`maxValue`,pcv.remark 
                                from base_partCheckValue pcv
                                left join base_partCheckTip pct on pcv.partCheck_ID = pct.id
                                left join sys_basedata sb1 on pcv.valueTypeID = sb1.ID
                                left join sys_basedata sb2 on pcv.EqualTypeID = sb2.ID
                                where 1=1 " + para;
            sql += " order by pct.stepNo ";

            List<BasePartCheckValueModel> lists = db.ExecuteList<BasePartCheckValueModel>(sql, pList.ToArray());

            return lists;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddPartCheckValue(BasePartCheckValueModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into base_partCheckValue(partCheck_ID,valueTypeID,EqualTypeID,standardValue,minValue,`maxValue`,remark) 
                                    values(@partCheck_ID,@valueTypeID,@EqualTypeID,@standardValue,@minValue,@maxValue,@remark)";

            pList.Add(new MySqlParameter("@partCheck_ID", model.partCheck_ID));
            pList.Add(new MySqlParameter("@valueTypeID", model.valueTypeID));
            pList.Add(new MySqlParameter("@EqualTypeID", model.EqualTypeID));
            pList.Add(new MySqlParameter("@standardValue", model.standardValue));
            pList.Add(new MySqlParameter("@minValue", model.minValue));
            pList.Add(new MySqlParameter("@maxValue", model.maxValue));
            pList.Add(new MySqlParameter("@remark", model.remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditPartCheckValue(BasePartCheckValueModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_partCheckValue set partCheck_ID=@partCheck_ID,valueTypeID=@valueTypeID,EqualTypeID=@EqualTypeID,standardValue=@standardValue,
                                    minValue=@minValue,`maxValue`=@maxValue,remark=@remark
                                    where id = @id";

            pList.Add(new MySqlParameter("@partCheck_ID", model.partCheck_ID));
            pList.Add(new MySqlParameter("@valueTypeID", model.valueTypeID));
            pList.Add(new MySqlParameter("@EqualTypeID", model.EqualTypeID));
            pList.Add(new MySqlParameter("@standardValue", model.standardValue));
            pList.Add(new MySqlParameter("@minValue", model.minValue));
            pList.Add(new MySqlParameter("@maxValue", model.maxValue));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@id", model.id));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeletePartCheckValue(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_partCheckValue where id in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        #endregion

        #region 器具、量具基础信息表

        /// <summary>
        /// 器具基础信息分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseToolsModel> GetPagingBaseTools(BaseToolsModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            if (model != null)
            {
                if (model.DevID != -1 && model.DevID.HasValue)
                {
                    para += " and bt.devID=@DevID";
                    pList.Add(new MySqlParameter("@DevID", model.DevID));
                }
                if (model.ToolId != -1 && model.ToolId.HasValue)
                {
                    para += " and bt.toolId=@ToolId";
                    pList.Add(new MySqlParameter("@ToolId", model.ToolId));
                }
                if (model.DevStatus != -1 && model.DevStatus.HasValue)
                {
                    para += " and bt.devStatus=@DevStatus";
                    pList.Add(new MySqlParameter("@DevStatus", model.DevStatus));
                }
            }
            string sql = @"SELECT count(*) from base_Tools as bt LEFT JOIN 
                                   base_Device as dev on bt.devID=dev.id where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"SELECT bt.id as ID,bt.devID as DevID
                                ,dev.devName as DevName,bt.devSubjectionIP as DevSubjectionIP
                                ,bt.toolId as ToolId
                                ,GetbdNameBybdID(toolId) as ToolName,bt.toolModels as ToolModels,bt.toolCode as ToolCode
                                ,bt.devPurchaseDate as DevPurchaseDate,bt.devExpireDate as DevExpireDate,datediff(now(),devExpireDate) as ExpireDay
                                ,bt.devStatus as DevStatus,bt.devInspectionCount as DevInspectionCount,bt.devremark as DevRemark
                                from base_Tools as bt LEFT JOIN 
                                base_Device as dev on bt.devID=dev.id where 1=1  " + para;

            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<BaseToolsModel> list = db.ExecuteList<BaseToolsModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 自动更新每天的状态
        /// </summary>
        public void LoadToolsStatus()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from base_Tools where devStatus <>3";
            var ToolsList = db.ExecuteList<base_Tools>(sql, pList.ToArray());
            if (ToolsList.Count != 0)
            {
                for (int i = 0; i < ToolsList.Count; i++)
                {
                    int ID = Convert.ToInt32(ToolsList[i].id);
                    int status = GetExpireStatus(Convert.ToDateTime(ToolsList[i].devExpireDate));
                    sql = "select *from base_Tools where id=@ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@ID", ID));
                    var entity = db.ExecuteList<base_Tools>(sql, pList.ToArray());
                    if (entity != null && entity.Count > 0)
                    {
                        sql = "update base_Tools set devStatus=@status WHERE id=@Id";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@status", status));
                        pList.Add(new MySqlParameter("@Id", ID));
                        db.ExecuteNonQuery(sql, pList.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// 获取到期状态
        /// </summary>
        /// <param name="ExpreDate"></param>
        /// <returns></returns>
        public int GetExpireStatus(DateTime ExpreDate)
        {
            /*思路：获取参数配置天数，在获取当前时间，要修改的到期提醒日期和当前时间得到到期天数,在得到提醒的状态*/
            int Day = 0;

            int ExpireDay = 0;//获取到期天数

            //获取服务器系统时间
            DateTime serTime = Convert.ToDateTime(GetServerDateTime());

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();

            string sql = "select *from sys_config where cfg_code='ExpireReminderDay'";
            List<sys_config> configlist = db.ExecuteList<sys_config>(sql, plist.ToArray());
            if (configlist.Count > 0)
            {
                Day = Convert.ToInt32(configlist[0].cfg_value);
            }

            TimeSpan spDay = Convert.ToDateTime(ExpreDate.ToShortDateString()) - Convert.ToDateTime(serTime.ToShortDateString());
            ExpireDay = spDay.Days;
            int RemindStatus = 0;
            if (ExpireDay > Day)
            {
                RemindStatus = 0;//未到期
            }
            else if (ExpireDay <= Day && ExpireDay > 0)
            {
                RemindStatus = 1;//将到期
            }
            else if (ExpireDay <= 0)
            {
                RemindStatus = 2;//已到期
            }

            return RemindStatus;
        }


        /// 添加器具基础信息
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public void AddBaseTools(BaseToolsModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = @"INSERT into base_Tools (devID,devName,devSubjectionIP,toolId,toolName,toolModels,toolCode,devPurchaseDate,devExpireDate,devStatus,devInspectionCount,devremark)
VALUES(@devID,@devName,@devSubjectionIP,@toolId,@toolName,@toolModels,@toolCode,@devPurchaseDate,@devExpireDate,@devStatus,0,@devremark)";
            plist.Add(new MySqlParameter("@devID", model.DevID));
            plist.Add(new MySqlParameter("@devName", model.DevName));
            plist.Add(new MySqlParameter("@devSubjectionIP", model.DevSubjectionIP));
            plist.Add(new MySqlParameter("@toolId", model.ToolId));
            plist.Add(new MySqlParameter("@toolName", model.ToolName));
            plist.Add(new MySqlParameter("@toolModels", model.ToolModels));
            plist.Add(new MySqlParameter("@toolCode", model.ToolCode));
            plist.Add(new MySqlParameter("@devPurchaseDate", model.DevPurchaseDate));
            plist.Add(new MySqlParameter("@devExpireDate", model.DevExpireDate));
            plist.Add(new MySqlParameter("@devStatus", model.DevStatus));
            plist.Add(new MySqlParameter("@devremark", model.DevRemark));
            db.ExecuteNonQuery(sql, plist.ToArray());
        }

        /// <summary>
        /// 器具基础信息修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseToolsModel GetBaseToolsId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            BaseToolsModel btm = new BaseToolsModel();
            string sql = @"SELECT bt.id as ID,bt.devID as DevID
                                ,dev.devName as DevName,bt.devSubjectionIP as DevSubjectionIP
                                ,bt.toolId as ToolId
                                ,GetbdNameBybdID(toolId) as ToolName,bt.toolModels as ToolModels,bt.toolCode as ToolCode
                                ,bt.devPurchaseDate as DevPurchaseDate,bt.devExpireDate as DevExpireDate,datediff(now(),devExpireDate) as ExpireDay
                                ,bt.devStatus as DevStatus,bt.devInspectionCount as DevInspectionCount,bt.devremark as DevRemark
                                from base_Tools as bt LEFT JOIN 
                                base_Device as dev on bt.devID=dev.id where bt.id=@id ";
            plist.Add(new MySqlParameter("@id", Id));
            List<BaseToolsModel> list = db.ExecuteList<BaseToolsModel>(sql, plist.ToArray());
            if (list.Count > 0)
                return list[0];
            return new BaseToolsModel();
        }
        /// <summary>
        /// 修改器具基础信息
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseTools(BaseToolsModel model)
        {
            BaseToolsModel mod = GetBaseToolsId(model.ID);
            if (mod == null)
            {
                throw new Exception(string.Format("没有找到名称为：{0} 器具信息！", model.ToolName));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> plist = new List<MySqlParameter>();

            string sql = @"UPDATE base_Tools set devID=@devID,devName=@devName,devSubjectionIP=@devSubjectionIP,toolId=@toolId,
                                   toolName=@toolName,toolModels=@toolModels,toolCode=@toolCode,devPurchaseDate=@devPurchaseDate,
                                   devExpireDate=@devExpireDate,devStatus=@devStatus,devremark=@devremark where id=@id";

            plist.Add(new MySqlParameter("@devID", model.DevID));
            plist.Add(new MySqlParameter("@devName", model.DevName));
            plist.Add(new MySqlParameter("@devSubjectionIP", model.DevSubjectionIP));
            plist.Add(new MySqlParameter("@toolId", model.ToolId));
            plist.Add(new MySqlParameter("@toolName", model.ToolName));
            plist.Add(new MySqlParameter("@toolModels", model.ToolModels));
            plist.Add(new MySqlParameter("@toolCode", model.ToolCode));
            plist.Add(new MySqlParameter("@devPurchaseDate", model.DevPurchaseDate));
            plist.Add(new MySqlParameter("@devExpireDate", model.DevExpireDate));
            plist.Add(new MySqlParameter("@devStatus", model.DevStatus));
            plist.Add(new MySqlParameter("@devremark", model.DevRemark));
            plist.Add(new MySqlParameter("@id", model.ID));

            db.ExecuteNonQuery(sql, plist.ToArray());

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseTools(string id)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            string sql = @"delete from base_Tools where id in(" + id + ")";

            int i = db.ExecuteNonQuery(commandText: sql, parms: null);
        }
        #endregion

        #region CS端

        /// <summary>
        /// 根据IP获取工位信息，包括工位ID，名称，区域
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public BaseGongweiModel getGwByIP(string ip)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select gw.*,bd.bdname areaName,bd.bdcode areaCode
                                    from base_gongwei gw
                                    left join sys_baseData bd on gw.areaID = bd.ID where 1=1 ";
            if (!string.IsNullOrEmpty(ip))
            {
                sql += "and IP=@IP ";
                //sql += "and IP like CONCAT('%',@IP,'%') ";
                pList.Add(new MySqlParameter("@IP", ip));
            }

            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray());
            if (list.Count > 0)
            {
                list = GetOPC(list);
                return list[0];
            }
            return null;
        }


        /// <summary>
        /// 获取总装工位最大排序号
        /// </summary>
        /// <returns></returns>
        public int getGwMaxOrder()
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select Max(gwOrder) as MaxGwOrder from base_gongwei gw
                            left join sys_baseData bd on gw.areaID = bd.ID where 1=1 and isFinishGW =1 ";
            return Convert.ToInt32(db.ExecuteScalar(sql, pList.ToArray()));
        }

        /// <summary>
        /// 根据ID获取工位实体信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseGongweiModel getEntyGwByID(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select gw.*,bd.bdname areaName,bd.bdcode areaCode
                                    from base_gongwei gw
                                    left join sys_baseData bd on gw.areaID = bd.ID where 1=1 ";

            if (Id != 0)
            {
                sql += "and gw.ID = @Id ";
                pList.Add(new MySqlParameter("@Id", Id));
            }

            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, pList.ToArray());
            if (list.Count > 0)
            {
                list = GetOPC(list);
                return list[0];
            }
            return null;
        }

        /// <summary>
        /// 获取检验区的偶换件列表 LHR
        /// </summary>
        /// <param name="fm_guid">生产编号GUID</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <param name="componentId"></param>
        /// <param name="curAreaID"></param>
        /// <param name="replaceTypeID"></param>
        /// <returns></returns>
        public List<BaseProductBomModel> GetWlLjBatch(Guid fm_guid, int pModelID, int componentId, int curAreaID, params int[] replaceTypeID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select CoupleChangeWl.*,(case when batch.fw_batchResult is null then 0 else 1 end) as isChecked,
                                    (case when batch.fw_batchQty is null then CoupleChangeWl.replaceQty else ifnull(batch.fw_batchQty,0) end) as batchQty  from 
                                    (select plj.*,wl.wlname,wl.wlImg from base_productLingjian plj
                                    left join base_wuliao wl on wl.ID=plj.wuliaoLJid
                                    where 1=1 and  ifnull(replaceTypeID,0) in (" + replaceTypeID + ") and ifnull(prodModelId,0) = @prodModelId"; //and isKeyLJ=0
            if (componentId != 0)
            {
                sql += " and componentId = @componentId";
                pList.Add(new MySqlParameter("@componentId", componentId));
            }
            sql += @")as CoupleChangeWl 
                                    left join 
                                    follow_WlLjBatching batch on CoupleChangeWl.wuliaoLJid=batch.fw_wuliaoLJid 
                                    and fm_guid='@fm_guid' and fw_areaID=@fw_areaID ";

            //pList.Add(new MySqlParameter("@replaceTypeID", replaceTypeID));
            pList.Add(new MySqlParameter("@prodModelId", pModelID));
            pList.Add(new MySqlParameter("@fm_guid", fm_guid));
            pList.Add(new MySqlParameter("@fw_areaID", curAreaID));

            List<BaseProductBomModel> list = db.ExecuteList<BaseProductBomModel>(sql, pList.ToArray());

            return list;
        }



        /// <summary>
        /// 获取物料盒信息
        /// </summary>
        /// <param name="wlBoxHasRFID">已有的物料编号，用逗号隔开的字符串</param>
        /// <returns></returns>
        public List<WuliaoModel> GetWlBox(params int[] wlBoxHasRFID)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select * from base_wuliao where wlTypeID in 
                                    (select id from sys_baseData where bdtypeCode='WuliaoType' and bdcode='wlBox' and isDeleted=0) ";

            if (wlBoxHasRFID != null && wlBoxHasRFID.Length > 0)
            {
                sql += " and wlBoxHasRFID NOT IN (" + wlBoxHasRFID + ")";
                //pList.Add(new MySqlParameter("@wlBoxHasRFID", wlBoxHasRFID));
            }
            sql += " order by ID ";

            List<WuliaoModel> list = db.ExecuteList<WuliaoModel>(sql, pList.ToArray());

            return list;

        }


        /// <summary>
        /// 获取产品型号+组件的质检提示
        /// </summary>
        /// <param name="pModelID"></param>
        /// <param name="gwID"></param>
        /// <returns></returns>
        public List<BaseProductBomModel> GetCheckTip(int pModelID, int componentId, int wlId)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select tipMemo,picture from base_productlingjian plj
                                    left join base_prodljchecktip pck on plj.id = pck.prodLjDefId
                                    where plj.prodModelId = @prodModelId ";

            pList.Add(new MySqlParameter("@prodModelId", pModelID));

            if (componentId != 0)
            {
                sql += "and componentId = @componentId ";
                pList.Add(new MySqlParameter("@componentId", componentId));
            }
            if (wlId != 0)
            {
                sql += "and wuliaoLJid = @wuliaoLJid ";
                pList.Add(new MySqlParameter("@wuliaoLJid", wlId));
            }

            List<BaseProductBomModel> list = db.ExecuteList<BaseProductBomModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 物料是否为来料区悬挂部件
        /// </summary>
        /// <param name="fm_guid">生产编号GUID</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <returns></returns>
        public bool WuliaoIsComingHang(int pModelID, int wuliaoID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select COUNT(*) from base_productlingjian 
                                    where prodModelId = @prodModelId and replaceTypeID = 1
                                    and isComingHang = 1 and wuliaoLJid = @wuliaoLJid";

            pList.Add(new MySqlParameter("@prodModelId", pModelID));
            pList.Add(new MySqlParameter("@wuliaoLJid", wuliaoID));

            int Count = (int)db.ExecuteScalar(sql, pList.ToArray());

            if (Count > 0)
                return true;
            else
                return false;
        }



        /// <summary>
        /// 获取工具备注信息（主要用于扭力扳手） 2020-07-04
        /// </summary>
        /// <param name="gjNames"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> GetGjRemarks(List<string> gjNames)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (gjNames != null && gjNames.Count > 0)
            {
                para += " and gjname in(" + string.Join(",", gjNames) + ")";
            }

            string sql = @"select gjname,remark from base_gongju where 1=1 ";

            List<KeyValuePair<string, string>> list = db.ExecuteList<KeyValuePair<string, string>>(sql, pList.ToArray());
            return list;

            //var result = context.base_gongju.Where(f => gjNames.Contains(f.gjname)).Select(f => new { f.gjname, f.remark }).ToList();

            //var res = result.Select(f => new KeyValuePair<string, string>(f.gjname, f.remark)).ToList();

            //return res;

        }


        #endregion

        #region 车辆信息

        public List<SubwayInfoModel> GetSubwayInfoList(SubwayInfoModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select a.*,b.Pmodel prodModelName from subwayInfo a left join base_productmodel b on a.prodModelID = b.ID where 1 = 1";

            //pList.Add(new MySqlParameter("@ID", Id));
            List<SubwayInfoModel> list = db.ExecuteList<SubwayInfoModel>(sql, pList.ToArray());

            return list;
        }
        #endregion

        #region 存放区信息管理

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseTempAreaModel> GetTempAreaList(BaseTempAreaModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model.ta_areaID.HasValue && model.ta_areaID != 0)
            {
                para += " and ta_areaID = @ta_areaID ";
                pList.Add(new MySqlParameter("@ta_areaID", model.ta_areaID));
            }
            if (model.ta_status.HasValue && model.ta_status != 0)
            {
                para += " and ta_status = @ta_status ";
                pList.Add(new MySqlParameter("@ta_status", model.ta_status));
            }
            if (model.ta_groupIndex.HasValue && model.ta_areaID != 0)
            {
                para += " and ta_groupIndex = @ta_groupIndex ";
                pList.Add(new MySqlParameter("@ta_groupIndex", model.ta_groupIndex));
            }


            string sql = @"select Count(*) from base_temparea ta
                                    left join sys_basedata sb on ta.ta_areaID=sb.ID 
                                    left join sys_basedata sbd on ta.ta_status=sbd.ID where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select ta_ID,ta_areaCode,ta_areaID,sb.bdname as ta_areaName,ta_groupIndex,ta_rowIndex,ta_colIndex,ta_defaultColor,
                            ta_stayPutColor,ta_inPutColor,ta_curFmGuid,ta_curSysProdNo,ta_status,ta_InspectionStatus,sbd.bdname as ta_statusText,ta.ta_opcStoreQ,ta.ta_opcStoreI,ta.ta_remark from base_temparea ta
                            left join sys_basedata sb on ta.ta_areaID=sb.ID 
                            left join sys_basedata sbd on ta.ta_status=sbd.ID where 1=1 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseTempAreaModel> list = db.ExecuteList<BaseTempAreaModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseTempAreaModel> GetTempAreaList(BaseTempAreaModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            if (model.ta_areaID.HasValue)
            {
                para += " and ta_areaID = @ta_areaID ";
                pList.Add(new MySqlParameter("@ta_areaID", model.ta_areaID));
            }
            if (model.ta_groupIndex.HasValue)
            {
                para += " and ta_groupIndex = @ta_groupIndex ";
                pList.Add(new MySqlParameter("@ta_groupIndex", model.ta_groupIndex));
            }
            if (model.hasSysProdNo)
            {
                para += " and ta_curSysProdNo is not null ";
            }
            if (model.ta_ID != 0)
            {
                para += " and ta_ID = @ta_ID ";
                pList.Add(new MySqlParameter("@ta_ID", model.ta_ID));
            }

            if (model.UNID != 0)
            {
                para += " and ta_ID<>@UNID ";
                pList.Add(new MySqlParameter("@UNID", model.UNID));
            }

            if (!string.IsNullOrEmpty(model.ta_curSysProdNo))
            {
                para += " and ta_curSysProdNo=@ta_curSysProdNo ";
                pList.Add(new MySqlParameter("@ta_curSysProdNo", model.ta_curSysProdNo));
            }

            //string sql = @"select ta.*,sb.bdname as ta_areaName,sbd.bdname as ta_statusText,ifnull(pf.pf_compartNo,'') pf_compartNo
            //                ,ifnull(pf.pf_bogieNo,'') pf_bogieNo,fp.fp_pInfo_ID,pf.pf_prodNo,GetPModelNameByID(pf.pf_prodModelID) as prodModelName,GetWLNameByWLID(ta.ta_remark) as ta_PartName 
            //                from base_temparea ta
            //                left join sys_basedata sb on ta.ta_areaID=sb.ID 
            //                left join sys_basedata sbd on ta.ta_status=sbd.ID 
            //                left join follow_production fp on ta.ta_curSysProdNo=fp.fp_prodNo_sys 
            //                left join productinfo pf on pf.pf_ID=fp.fp_pInfo_ID 
            //                where 1=1 " + para;
            //sql += " order by ta_ID ";

            string sql = @"select ta.*,sb.bdname as ta_areaName,sbd.bdname as ta_statusText
                           ,pf.pf_prodNo,GetPModelNameByID(pf.pf_prodModelID) as prodModelName,GetWLNameByWLID(ta.ta_remark) as ta_PartName
                            from base_temparea ta
                            left join sys_basedata sb on ta.ta_areaID = sb.ID
                            left join sys_basedata sbd on ta.ta_status = sbd.ID
                            left join productinfo pf on ta.ta_curSysProdNo = pf.pf_prodNo
                            where 1=1 " + para;
            sql += " order by ta_ID ";

            List<BaseTempAreaModel> list = db.ExecuteList<BaseTempAreaModel>(sql, pList.ToArray());

            return list;
        }


        /// <summary>
        ///  添加
        /// </summary>
        /// <param name="model">区域存放区</param>
        public void AddTempArea(BaseTempAreaModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            if (model.ta_defaultColor != null)
                model.ta_defaultColor = model.ta_defaultColor.ToUpper();
            if (model.ta_stayPutColor != null)
                model.ta_stayPutColor = model.ta_stayPutColor.ToUpper();
            if (model.ta_inPutColor != null)
                model.ta_inPutColor = model.ta_inPutColor.ToUpper();

            string sql = @"insert into base_temparea(ta_areaCode,ta_areaID,ta_groupIndex,ta_rowIndex,ta_colIndex,ta_defaultColor,
                            ta_stayPutColor,ta_inPutColor,ta_curFmGuid,ta_planGuid,ta_curSysProdNo,ta_status,ta_opcStoreQ,ta_opcStoreI,ta_remark) 
                            values(@ta_areaCode,@ta_areaID,@ta_groupIndex,@ta_rowIndex,@ta_colIndex,@ta_defaultColor,
                            @ta_stayPutColor,@ta_inPutColor,@ta_curFmGuid,@ta_planGuid,@ta_curSysProdNo,@ta_status,@ta_opcStoreQ,@ta_opcStoreI,@ta_remark)";

            pList.Add(new MySqlParameter("@ta_areaCode", model.ta_areaCode));
            pList.Add(new MySqlParameter("@ta_areaID", model.ta_areaID));
            pList.Add(new MySqlParameter("@ta_groupIndex", model.ta_groupIndex));
            pList.Add(new MySqlParameter("@ta_rowIndex", model.ta_rowIndex));
            pList.Add(new MySqlParameter("@ta_colIndex", model.ta_colIndex));
            pList.Add(new MySqlParameter("@ta_defaultColor", model.ta_defaultColor));
            pList.Add(new MySqlParameter("@ta_stayPutColor", model.ta_stayPutColor));
            pList.Add(new MySqlParameter("@ta_inPutColor", model.ta_inPutColor));
            pList.Add(new MySqlParameter("@ta_curFmGuid", model.ta_curFmGuid));
            pList.Add(new MySqlParameter("@ta_planGuid", model.ta_planGuid));
            pList.Add(new MySqlParameter("@ta_curSysProdNo", model.ta_curSysProdNo));
            pList.Add(new MySqlParameter("@ta_status", model.ta_status));
            pList.Add(new MySqlParameter("@ta_opcStoreQ", model.ta_opcStoreQ));
            pList.Add(new MySqlParameter("@ta_opcStoreI", model.ta_opcStoreI));
            pList.Add(new MySqlParameter("@ta_remark", model.ta_remark));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public int EditTempArea(BaseTempAreaModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            if (model.ta_defaultColor != null)
                model.ta_defaultColor = model.ta_defaultColor.ToUpper();
            if (model.ta_stayPutColor != null)
                model.ta_stayPutColor = model.ta_stayPutColor.ToUpper();
            if (model.ta_inPutColor != null)
                model.ta_inPutColor = model.ta_inPutColor.ToUpper();

            string sql = @"update base_temparea set ta_areaCode=@ta_areaCode,ta_areaID=@ta_areaID,ta_groupIndex=@ta_groupIndex,ta_rowIndex=@ta_rowIndex,ta_colIndex=@ta_colIndex,ta_defaultColor=@ta_defaultColor,
                           ta_stayPutColor=@ta_stayPutColor,ta_inPutColor=@ta_inPutColor,ta_curFmGuid=@ta_curFmGuid,ta_planGuid=@ta_planGuid,ta_curSysProdNo=@ta_curSysProdNo,
                           ta_status=@ta_status,ta_InspectionStatus=@ta_InspectionStatus,ta_opcStoreQ=@ta_opcStoreQ,ta_opcStoreI=@ta_opcStoreI,ta_remark=@ta_remark where ta_ID = @ta_ID";
            pList.Add(new MySqlParameter("@ta_areaCode", model.ta_areaCode));
            pList.Add(new MySqlParameter("@ta_areaID", model.ta_areaID));
            pList.Add(new MySqlParameter("@ta_groupIndex", model.ta_groupIndex));
            pList.Add(new MySqlParameter("@ta_rowIndex", model.ta_rowIndex));
            pList.Add(new MySqlParameter("@ta_colIndex", model.ta_colIndex));
            pList.Add(new MySqlParameter("@ta_defaultColor", model.ta_defaultColor));
            pList.Add(new MySqlParameter("@ta_stayPutColor", model.ta_stayPutColor));
            pList.Add(new MySqlParameter("@ta_inPutColor", model.ta_inPutColor));
            pList.Add(new MySqlParameter("@ta_curFmGuid", model.ta_curFmGuid));
            pList.Add(new MySqlParameter("@ta_planGuid", model.ta_planGuid));
            pList.Add(new MySqlParameter("@ta_curSysProdNo", model.ta_curSysProdNo));
            pList.Add(new MySqlParameter("@ta_status", model.ta_status));
            pList.Add(new MySqlParameter("@ta_InspectionStatus", model.ta_InspectionStatus));
            pList.Add(new MySqlParameter("@ta_opcStoreQ", model.ta_opcStoreQ));
            pList.Add(new MySqlParameter("@ta_opcStoreI", model.ta_opcStoreI));
            pList.Add(new MySqlParameter("@ta_remark", model.ta_remark));
            pList.Add(new MySqlParameter("@ta_ID", model.ta_ID));

            return db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTempArea(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from base_tempArea where ta_ID in(" + id + ")";

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 保存小风机
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveSmallFan(BaseTempAreaModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update base_temparea set ta_status=@ta_status where ta_ID = @ta_ID";

            pList.Add(new MySqlParameter("@ta_status", model.ta_status));
            pList.Add(new MySqlParameter("@ta_ID", model.ta_ID));

            return db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 入场存放区电机离场 开始拆卸
        /// </summary>
        /// <param name="pfGuid"></param>
        /// <returns></returns>
        public string LeaveInComming(Guid pfGuid)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";
                    int i = 0;
                    //获取存放区域表ID
                    sql = "select ta_ID from base_temparea where ta_status=194 and ta_areaID=190 and ta_curFmGuid=@ta_curFmGuid ";
                    pList.Add(new MySqlParameter("@ta_curFmGuid", pfGuid));
                    int taID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
                    if (taID == 0)
                        throw new Exception("此生产ID未找到已存放的入场存放区信息!");
                    //修改计划明细表数据
                    sql = "update plan_detail set pdStatus=5,pdTAID=null where pdStatus=4 and pdTAID=@pdTAID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pdTAID", taID));
                    i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
                    if (i == 0)
                        throw new Exception("修改计划明细表数据失败!");
                    //修改存放区域表
                    sql = "update base_temparea set ta_curFmGuid=null,ta_planGuid=null,ta_curSysProdNo=null,ta_status=192 where ta_areaID=190 and ta_curFmGuid=@ta_curFmGuid";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@ta_curFmGuid", pfGuid));
                    i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
                    if (i == 0)
                        throw new Exception("修改存放区域表失败!");

                    myTrans.Commit();
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    return ex.Message;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }

        #endregion

        #region 获取系统时间
        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDateTime()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"Select now()";

            string strNow = db.ExecuteScalar(sql, pList.ToArray()) + "";

            DateTime now = DateTime.Now;

            DateTime.TryParse(strNow, out now);

            return now;
        }
        #endregion

        #region 条码卡 Leon

        /// <summary>
        /// 获取条码卡集合
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseBarcodeModel> GetBarCodeList(BaseBarcodeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            if (model.id != 0)
            {
                para += " and id=@id ";
                pList.Add(new MySqlParameter("@id", model.id));
            }
            if (!string.IsNullOrEmpty(model.c_cardNo))
            {
                para += " and c_cardNo=@c_cardNo ";
                pList.Add(new MySqlParameter("@c_cardNo", model.c_cardNo));
            }
            if (!string.IsNullOrEmpty(model.c_curStampNo))
            {
                para += " and c_curStampNo=@c_curStampNo ";
                pList.Add(new MySqlParameter("@c_curStampNo", model.c_curStampNo));
            }
            if (model.c_curFmGuid.HasValue)
            {
                para += " and c_curFmGuid=@c_curFmGuid ";
                pList.Add(new MySqlParameter("@c_curFmGuid", model.c_curFmGuid));
            }
            if (model.c_curComponentId.HasValue)
            {
                para += " and c_curComponentId=@c_curComponentId ";
                pList.Add(new MySqlParameter("@c_curComponentId", model.c_curComponentId));
            }
            if (model.UnID != 0)
            {
                para += " and id<>@UnID ";
                pList.Add(new MySqlParameter("@UnID", model.UnID));
            }

            string sql = @"select bc.*,GetWLNameByWLID(bc.c_curComponentId) c_curComponentName,GetbdNameBybdID(bc.c_curAreaID) c_curAreaText,fp.pp_guid,fp.fp_prodNo_sys,fm.pInfo_ID c_pInfoID 
                            from base_barcode bc
                            left join follow_main fm on fm.fm_guid=bc.c_curFmGuid
                            left join follow_production fp on fp.fp_guid=fm.fp_guid
                            where 1=1 " + para;

            List<BaseBarcodeModel> list = db.ExecuteList<BaseBarcodeModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 绑定条形码 Leon
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public int BindBarCode(BaseBarcodeModel model)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        if (context.DBType == Common.EDAEnums.DataBaseType.MySql)
        //        {
        //            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
        //            {
        //                myConnection.Open();
        //                MySqlTransaction myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
        //                try
        //                {
        //                    int i = BindBarCode(model, myTrans);
        //                    myTrans.Commit();
        //                    return i;
        //                }
        //                catch
        //                {
        //                    myTrans.Rollback();
        //                    return 0;
        //                }
        //                finally
        //                {
        //                    myTrans.Dispose();
        //                }
        //            }
        //        }
        //        return 0;
        //    }
        //}

        /// <summary>
        /// 通用MySql绑码函数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="myTrans"></param>
        /// <returns></returns>
        public int BindBarCode(BaseBarcodeModel model, MySqlTransaction myTrans)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;//受影响的行数

            if (!string.IsNullOrEmpty(model.c_cardNo))
            {
                //修改条码卡表
                sql = @"update base_barcode set c_curAreaID=@c_curAreaID,c_curGwID=@c_curGwID,c_curFmGuid=@c_curFmGuid,c_curProdNo=@c_curProdNo
                    ,c_curComponentId=@c_curComponentId,c_curStampNo=@c_curStampNo,c_status=1 where c_cardNo=@c_cardNo ";
                pList.Clear();
                pList.Add(new MySqlParameter("@c_cardNo", model.c_cardNo));
                pList.Add(new MySqlParameter("@c_curAreaID", model.c_curAreaID));
                pList.Add(new MySqlParameter("@c_curGwID", model.c_curGwID));
                pList.Add(new MySqlParameter("@c_curFmGuid", model.c_curFmGuid));
                pList.Add(new MySqlParameter("@c_curProdNo", model.c_curProdNo));
                pList.Add(new MySqlParameter("@c_curComponentId", model.c_curComponentId));
                pList.Add(new MySqlParameter("@c_curStampNo", model.c_curStampNo));
                i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                //添加绑定记录表
                sql = @"insert follow_barcode_log(c_cardNo,c_pInfoID,c_partId,c_stampNo,c_operID,c_createtime) 
                        values(@c_cardNo,@c_pInfoID,@c_partId,@c_stampNo,@c_operID,now())";
                pList.Clear();
                pList.Add(new MySqlParameter("@c_cardNo", model.c_cardNo));
                pList.Add(new MySqlParameter("@c_pInfoID", model.c_pInfoID));
                pList.Add(new MySqlParameter("@c_partId", model.c_curComponentId));
                pList.Add(new MySqlParameter("@c_stampNo", model.c_curStampNo));
                pList.Add(new MySqlParameter("@c_operID", model.c_operID));
                i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
            }
            else
            {
                //解绑
                sql = @"update base_barcode set c_curAreaID=@c_curAreaID,c_curGwID=@c_curGwID,c_curFmGuid=@c_curFmGuid,c_curProdNo=@c_curProdNo
                    ,c_curComponentId=@c_curComponentId,c_curStampNo=@c_curStampNo,c_status=0 where id=@id ";
                pList.Clear();
                pList.Add(new MySqlParameter("@id", model.id));
                pList.Add(new MySqlParameter("@c_curAreaID", model.c_curAreaID));
                pList.Add(new MySqlParameter("@c_curGwID", model.c_curGwID));
                pList.Add(new MySqlParameter("@c_curFmGuid", model.c_curFmGuid));
                pList.Add(new MySqlParameter("@c_curProdNo", model.c_curProdNo));
                pList.Add(new MySqlParameter("@c_curComponentId", model.c_curComponentId));
                pList.Add(new MySqlParameter("@c_curStampNo", model.c_curStampNo));
                i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
            }
            return i;
        }
        #endregion

        #region 库存信息 WZQ

        /// <summary>
        /// 库存分页信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseInventoryModel> GetInventoryPage(BaseInventoryModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (model.wlID.HasValue && model.wlID != 0)
            {
                para += " and inve.wlID=@wlID ";
                pList.Add(new MySqlParameter("@wlID", model.wlID));
            }

            if (model.isExists.HasValue)
            {
                para += " and inve.isExists=@isExists ";
                pList.Add(new MySqlParameter("@isExists", model.isExists));
            }

            if (!string.IsNullOrEmpty(model.wlName))
            {
                para += " and ml.mName like CONCAT('%',@wlName,'%') ";
                pList.Add(new MySqlParameter("@wlName", model.wlName.Trim()));
            }
            if (!string.IsNullOrEmpty(model.wlCode))
            {
                para += " and ml.mDrawingNo like CONCAT('%',@wlCode,'%') ";
                pList.Add(new MySqlParameter("@wlCode", model.wlCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.wlModel))
            {
                para += " and ml.mSpec like CONCAT('%',@wlModel,'%') ";
                pList.Add(new MySqlParameter("@wlModel", model.wlModel.Trim()));
            }

            if (model.warehouseID.HasValue && model.warehouseID != 0)
            {
                para += " and inve.warehouseID=@warehouseID ";
                pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
            }

            if (model.inventoryTypeID.HasValue && model.inventoryTypeID != 0)
            {
                para += " and inve.inventoryTypeID=@inventoryTypeID ";
                pList.Add(new MySqlParameter("@inventoryTypeID", model.inventoryTypeID));
            }

            string sql = @"select count(*) from base_inventory inve
                           LEFT JOIN base_material ml ON inve.wlID = ml.ID 
                           WHERE 1 = 1 " + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            //       sql = @"SELECT
            //            inve.ID,
            //            ml.mDrawingNo as wlCode,
            //            inve.wlID,
            //               ml.mName as wlName,
            //ml.mSpec as wlModel,
            //            inve.batch,
            //            inve.unit,
            //            inve.projectNo,
            //            inve.qty,
            //            inve.lockQty,
            //            inve.inventoryTypeID,
            //            GetbdNameBybdID (inve.inventoryTypeID) AS inventoryTypeText,
            //            inve.InvOrgID,
            //            GetbdNameBybdID (inve.InvOrgID) AS InvOrgText,
            //            inve.warehouseID,
            //            GetbdNameBybdID (inve.warehouseID) AS warehouseText,
            //inve.remark,
            //inve.createTime,
            //inve.createMan,
            //inve.updateTime,
            //inve.updateMan
            //           FROM base_inventory inve
            //           LEFT JOIN base_material ml ON inve.wlID = ml.ID WHERE 1 = 1 " + para;

            sql = @"SELECT
	                inve.ID,
	                ml.mDrawingNo as wlCode,
	                inve.wlID,
                    ml.mName as wlName,
					ml.mSpec as wlModel,
	                inve.batch,
	                inve.unit,
	                inve.projectNo,
	                inve.qty,
	                inve.lockQty,
	                inve.inventoryTypeID,
	                inve.InvOrgID,
	                inve.warehouseID,
                    inve.isExists,
					inve.remark,
					inve.createTime,
					inve.createMan,
					inve.updateTime,
					inve.updateMan
                FROM base_inventory inve
                LEFT JOIN base_material ml ON inve.wlID = ml.ID WHERE 1 = 1 " + para;
            //sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            sql += " limit " + model.PageIndex + "," + model.PageSize;
            List<BaseInventoryModel> list = db.ExecuteList<BaseInventoryModel>(sql, pList.ToArray());

            return list;
        }



        /// <summary>
        /// 获取仓库信息（用于齐套分析）
        /// </summary>
        /// <returns></returns>
        public List<BundleAnalysisInventoryModel> GetInventoryList()
        {
            var db = new RW.PMS.Common.MySqlHelper();

            var pList = new List<MySqlParameter>();

            var inventoryModels = db.ExecuteList<BundleAnalysisInventoryModel>(@"SELECT

                    inve.ID,
                    ml.mDrawingNo as wlCode,
                    inve.wlID,
                    ml.mName as wlName,
                    ml.mSpec as wlModel,
                    inve.batch,
                    inve.unit,
                    inve.projectNo,
                    inve.qty,
                    inve.lockQty,
                    inve.inventoryTypeID,
                    inve.InvOrgID,
                    inve.warehouseID,
                    inve.remark,
                    inve.createTime,
                    inve.createMan,
                    inve.updateTime,
                    inve.updateMan
                FROM base_inventory inve
                LEFT JOIN base_material ml ON inve.wlID = ml.ID ");

            return inventoryModels;
        }

        /// <summary>
        /// 判断该规格和仓库是否存在
        /// </summary>
        /// <param name="wlID">物料规格ID</param>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        public bool IsExistInventory(int UNID, int wlID, int warehouseID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (wlID != 0)
            {
                para += " and wlID=@wlID ";
                pList.Add(new MySqlParameter("@wlID", wlID));
            }
            if (warehouseID != 0)
            {
                para += " and warehouseID=@warehouseID ";
                pList.Add(new MySqlParameter("@warehouseID", warehouseID));
            }
            //去重应该 排除当前ID
            if (UNID != 0)
            {
                para += " and ID <> @UNID ";
                pList.Add(new MySqlParameter("@UNID", UNID));
            }
            string sql = @"select count(*) from base_inventory  where 1=1 " + para;
            var obj = db.ExecuteScalar(sql, pList.ToArray());
            var count = 0;
            int.TryParse(obj + "", out count);
            if (count >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加/修改库存信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        public int SaveInventory(BaseInventoryModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    DateTime serverTime = GetServerDateTime();

                    if (model.ID == 0)
                    {
                        #region 新增

                        sql = @"INSERT INTO base_inventory(wlID,batch,unit,projectNo,qty,lockQty,InvOrgID,inventoryTypeID,warehouseID,remark,createTime,createMan,updateTime,updateMan) 
                                Values(@wlID,@batch,@unit,@projectNo,@qty,@lockQty,@InvOrgID,@inventoryTypeID,@warehouseID,@remark,@createTime,@createMan,@updateTime,@updateMan) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@wlID", model.wlID));
                        pList.Add(new MySqlParameter("@batch", model.batch));
                        pList.Add(new MySqlParameter("@unit", model.unit));
                        pList.Add(new MySqlParameter("@projectNo", model.projectNo));
                        pList.Add(new MySqlParameter("@qty", model.qty));
                        pList.Add(new MySqlParameter("@lockQty", model.lockqty));
                        pList.Add(new MySqlParameter("@InvOrgID", model.InvOrgID));
                        pList.Add(new MySqlParameter("@inventoryTypeID", model.inventoryTypeID));
                        pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
                        pList.Add(new MySqlParameter("@remark", model.remark));
                        pList.Add(new MySqlParameter("@createTime", serverTime));
                        pList.Add(new MySqlParameter("@createMan", model.createMan));
                        pList.Add(new MySqlParameter("@updateTime", serverTime));
                        pList.Add(new MySqlParameter("@updateMan", model.updateMan));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());


                        //string sql2 = @"insert into base_inventorylog(wlModelID,warehouseID,changeType,changeQty,beforeQty,afterQty,userID,gwID,logTime) 
                        //                    values(@wlModelID,@warehouseID,@changeType,@changeQty,@beforeQty,@afterQty,@userID,@gwID,@logTime)";
                        //pList.Clear();
                        //pList.Add(new MySqlParameter("@wlModelID", model.wlID));
                        //pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
                        //pList.Add(new MySqlParameter("@changeType", 1));
                        //pList.Add(new MySqlParameter("@changeQty", model.qty));
                        //pList.Add(new MySqlParameter("@beforeQty", 0));
                        //pList.Add(new MySqlParameter("@afterQty", model.actualInventory));
                        //pList.Add(new MySqlParameter("@userID", model.userID));
                        //pList.Add(new MySqlParameter("@gwID", 0));
                        //pList.Add(new MySqlParameter("@logTime", serverTime));
                        //ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql2, pList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 编辑

                        //没修改前原来实际数量
                        //int actualInventory = 0;
                        //var obj = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text
                        //    , "select actualInventory from base_inventory where ID=" + model.ID, null);

                        //int.TryParse(obj + "", out actualInventory);

                        sql = @"update base_inventory set wlID=@wlID,batch=@batch,unit=@unit,projectNo=@projectNo,qty=@qty,lockQty=@lockQty,InvOrgID=@InvOrgID,inventoryTypeID=@inventoryTypeID,
                                warehouseID=@warehouseID,remark=@remark,updateTime=@updateTime,updateMan=@updateMan  where ID=@ID ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@wlID", model.wlID));
                        pList.Add(new MySqlParameter("@batch", model.batch));
                        pList.Add(new MySqlParameter("@unit", model.unit));
                        pList.Add(new MySqlParameter("@projectNo", model.projectNo));
                        pList.Add(new MySqlParameter("@qty", model.qty));
                        pList.Add(new MySqlParameter("@lockQty", model.lockqty));
                        pList.Add(new MySqlParameter("@InvOrgID", model.InvOrgID));
                        pList.Add(new MySqlParameter("@inventoryTypeID", model.inventoryTypeID));
                        pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
                        pList.Add(new MySqlParameter("@remark", model.remark));
                        pList.Add(new MySqlParameter("@updateTime", serverTime));
                        pList.Add(new MySqlParameter("@updateMan", model.updateMan));
                        pList.Add(new MySqlParameter("@ID", model.ID));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        //string sql2 = @"insert into base_inventorylog(wlModelID,warehouseID,changeType,changeQty,beforeQty,afterQty,userID,gwID,logTime) 
                        //                        values(@wlModelID,@warehouseID,@changeType,@changeQty,@beforeQty,@afterQty,@userID,@gwID,@logTime)";

                        //int changeQty = 0;

                        //int qty = model.actualInventory ?? 0; //实际数量

                        //if (actualInventory == qty)
                        //{
                        //    actualInventory = qty;
                        //    changeQty = model.actualInventory ?? 0 - actualInventory;
                        //}

                        //if (qty > actualInventory || qty < actualInventory)
                        //{
                        //    changeQty = qty - actualInventory;
                        //}


                        //pList.Clear();
                        //pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
                        //pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
                        //pList.Add(new MySqlParameter("@changeType", 1));
                        //pList.Add(new MySqlParameter("@changeQty", changeQty));
                        //pList.Add(new MySqlParameter("@beforeQty", actualInventory));
                        //pList.Add(new MySqlParameter("@afterQty", model.actualInventory));
                        //pList.Add(new MySqlParameter("@userID", model.userID));
                        //pList.Add(new MySqlParameter("@gwID", 0));
                        //pList.Add(new MySqlParameter("@logTime", serverTime));
                        //ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql2, pList.ToArray());
                        #endregion
                    }
                    myTrans.Commit();
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }

        /// <summary>
        /// Excel导入仓库信息 全删全插
        /// </summary>
        /// <param name="InventoryList"></param>
        /// <returns></returns>
        public ResponseResult<string> ImportInventory(List<BaseInventoryModel> InventoryList, bool isDeleted)
        {
            //返回结果
            var result = new ResponseResult<string>();
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                string[] msgRepetition = null;//重复物料
                string[] msgInexistence = null;//不存在物料
                string msg = string.Empty;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";


                    DateTime serverTime = GetServerDateTime();

                    //判断是否需要清空所有数据在上传及时库存
                    if (isDeleted)
                    {
                        sql = @"delete from base_inventory";
                        pList.Clear();
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    #region 查询出重复的集合数据

                    var query = InventoryList.GroupBy(x => new { x.wlCode, x.wlName })
                                  .Where(g => g.Count() > 1)
                                  .Select(y => y.Key)
                                  .ToList();

                    //所有不重复的物料
                    var allUnique = InventoryList.GroupBy(x => new { x.wlCode, x.wlName }).Where(g => g.Count() == 1);

                    //所有物料 将系统物料合并
                    var sum = InventoryList.GroupBy(x => new { x.wlCode, x.wlName }).Select(x => new { qtyCount = x.Select(y => y.qty).Sum(), x.Key.wlCode, x.Key.wlName });

                    var QueryRepetition = InventoryList.GroupBy(x => new { x.wlCode, x.wlName }).Where(g => g.Count() > 1).Select(y => new { wlCode = y.Key.wlCode, wlName = y.Key.wlName, Counter = y.Count() }).ToList();
                    msgRepetition = new string[QueryRepetition.Count];
                    if (QueryRepetition.Count > 0)
                    {
                        for (int i = 0; i < QueryRepetition.Count; i++)
                        {
                            msgRepetition[i] = $"{QueryRepetition[i].wlName} - {QueryRepetition[i].wlCode} 重复:{QueryRepetition[i].Counter}次";
                        }
                    }

                    #region

                    //List<BaseInventoryModel> RemoveDuplicates = new List<BaseInventoryModel>();
                    //var aa = InventoryList.Select(_ => new { _.wlCode, _.wlName, _.wlModel, _.batch, _.projectNo, _.unit, _.qty, _.lockqty, _.InvOrgID, _.inventoryTypeID, _.warehouseID, _.createMan, _.updateMan, _.remark })
                    //    .GroupBy(x => new { x.wlCode, x.wlName });
                    //var RemoveDuplicates = aa.Select(y => new
                    //{
                    //    wlCode = y.Key.wlCode,
                    //    wlName = y.Key.wlName,
                    //    wlModel = y.Max(x => x.wlModel),
                    //    batch = y.Max(x => x.batch),
                    //    projectNo = y.Max(x => x.projectNo),
                    //    unit = y.Max(x => x.unit),
                    //    qty = y.Sum(o => o.qty),
                    //    lockqty = y.Sum(x => x.lockqty),
                    //    InvOrgID = y.Max(x => x.InvOrgID),
                    //    inventoryTypeID = y.Max(x => x.inventoryTypeID),
                    //    warehouseID = y.Max(x => x.warehouseID),
                    //    createMan = y.Max(x => x.createMan),
                    //    updateMan = y.Max(x => x.updateMan),
                    //    remark = y.Max(x => x.remark)
                    //}).ToList();
                    //foreach (var item in bb)
                    //{
                    //    System.Diagnostics.Debug.WriteLine(item);
                    //    BaseInventoryModel model = new BaseInventoryModel();
                    //    model.wlCode = item.wlCode;
                    //    model.wlName = item.wlName;
                    //    model.wlModel = item.wlModel;
                    //    model.batch = item.batch;
                    //    model.projectNo = item.projectNo;
                    //    model.unit = item.unit;
                    //    model.qty = item.qty;
                    //    model.lockqty = item.lockqty;
                    //    model.InvOrgID = item.InvOrgID;
                    //    model.inventoryTypeID = item.inventoryTypeID;
                    //    model.warehouseID = item.warehouseID;
                    //    model.createMan = item.createMan;
                    //    model.updateMan = item.updateMan;
                    //    RemoveDuplicates.Add(model);
                    //} 
                    #endregion

                    #endregion

                    #region 新增

                    for (int i = 0; i < InventoryList.Count; i++)
                    {
                        int isExists = 0;
                        //根据当前物料名称、编码获取信息
                        DataTable dtWL = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from base_material where mName = '" + InventoryList[i].wlName + "' and mDrawingNo = '" + InventoryList[i].wlCode + "' ", null);
                        List<BaseMaterialModel> MaterialList = db.ToList<BaseMaterialModel>(dtWL);

                        sql = @"INSERT INTO base_inventory(wlID,batch,unit,projectNo,qty,lockQty,InvOrgID,inventoryTypeID,warehouseID,isExists,remark,createTime,createMan,updateTime,updateMan) 
                                Values(@wlID,@batch,@unit,@projectNo,@qty,@lockQty,@InvOrgID,@inventoryTypeID,@warehouseID,@isExists,@remark,@createTime,@createMan,@updateTime,@updateMan) ";
                        pList.Clear();
                        if (MaterialList.Count > 0)
                        {
                            pList.Add(new MySqlParameter("@wlID", MaterialList[0].ID));//取查询到的物料ID
                            pList.Add(new MySqlParameter("@isExists", isExists));
                            pList.Add(new MySqlParameter("@remark", InventoryList[i].remark));
                        }
                        else
                        {
                            //改为不存在物料状态
                            isExists = 1;
                            pList.Add(new MySqlParameter("@wlID", 0));//取查询到的物料ID
                            pList.Add(new MySqlParameter("@isExists", isExists));
                            pList.Add(new MySqlParameter("@remark", $"【{InventoryList[i].wlCode}-{InventoryList[i].wlName}】不存在！将影响齐套分析数据准确性，请尽快完善此物料的基础信息并关联库存！"));
                            //不存在的物料
                            //msg += InventoryList[i].wlName + " - " + InventoryList[i].wlCode;
                            //if (!string.IsNullOrEmpty(InventoryList[i].wlModel))
                            //{
                            //    msg += " - " + InventoryList[i].wlModel;
                            //}
                            //msg += ";";
                        }
                        pList.Add(new MySqlParameter("@batch", InventoryList[i].batch));
                        pList.Add(new MySqlParameter("@unit", InventoryList[i].unit));
                        pList.Add(new MySqlParameter("@projectNo", InventoryList[i].projectNo));
                        pList.Add(new MySqlParameter("@qty", InventoryList[i].qty));
                        pList.Add(new MySqlParameter("@lockQty", InventoryList[i].lockqty));
                        pList.Add(new MySqlParameter("@InvOrgID", InventoryList[i].InvOrgID));
                        pList.Add(new MySqlParameter("@inventoryTypeID", InventoryList[i].inventoryTypeID));
                        pList.Add(new MySqlParameter("@warehouseID", InventoryList[i].warehouseID));
                        pList.Add(new MySqlParameter("@createTime", serverTime));
                        pList.Add(new MySqlParameter("@createMan", InventoryList[i].createMan));
                        pList.Add(new MySqlParameter("@updateTime", serverTime));
                        pList.Add(new MySqlParameter("@updateMan", InventoryList[i].updateMan));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    }
                    #endregion

                    //if (!string.IsNullOrEmpty(msg))
                    //{
                    //    msgInexistence = msg.Substring(0, msg.Length - 1).Split(';');
                    //}
                    //else
                    //{
                    //    msgInexistence = new string[0];
                    //}
                    //if (msgRepetition.Length <= 0 && msgInexistence.Length <= 0)
                    if (msgRepetition.Length <= 0)
                    {
                        sql = @"insert into base_inventorylog(userID,logTime,remark) values(@userID,@logTime,@remark)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@userID", InventoryList[0].createMan));
                        pList.Add(new MySqlParameter("@logTime", serverTime));
                        pList.Add(new MySqlParameter("@remark", "Excel导入库存操作"));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        myTrans.Commit();
                    }
                    else
                    {
                        if (msgRepetition.Length > 0)
                        {
                            result.repetitionMsg = msgRepetition;
                        }
                        //if (msgInexistence.Length > 0)
                        //{
                        //    result.inexistenceMsg = msgInexistence;
                        //}
                        myTrans.Rollback();
                        ret = 0;
                        result.ret = ret;
                        return result;
                    }

                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    ret = 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                result.ret = ret;
                return result;
            }
        }


        /// <summary>
        /// 将导入的Excel文件合并数量后进行保存
        /// </summary>
        /// <param name="InventoryList"></param>
        /// <returns></returns>
        public ResponseResult<string> ImportUniqInventory(List<BaseInventoryModel> InventoryList)
        {
            //返回结果
            var result = new ResponseResult<string>();
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                string msg = string.Empty;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    DateTime serverTime = GetServerDateTime();

                    #region 查询出重复的集合数据

                    //将所有物料去重后合并数量
                    var sum = InventoryList.GroupBy(x => new { x.wlCode, x.wlName }).Select(x => new { qtyCount = x.Select(y => y.qty).Sum(), x.Key.wlCode, x.Key.wlName });

                    foreach (var item in sum)
                    {
                        foreach (var Inventory in InventoryList)
                        {
                            int isExists = 0;
                            if (item.wlCode == Inventory.wlCode)
                            {
                                var dtWL = db.ExecuteDataTable(System.Data.CommandType.Text, $"select * from base_material where mName = '{item.wlName}' and mDrawingNo = '{item.wlCode }'", null);
                                List<BaseMaterialModel> MaterialList = db.ToList<BaseMaterialModel>(dtWL);
                                sql = @"INSERT INTO base_inventory(wlID,batch,unit,projectNo,qty,lockQty,InvOrgID,inventoryTypeID,warehouseID,isExists,remark,createTime,createMan,updateTime,updateMan) 
                                Values(@wlID,@batch,@unit,@projectNo,@qty,@lockQty,@InvOrgID,@inventoryTypeID,@warehouseID,@isExists,@remark,@createTime,@createMan,@updateTime,@updateMan) ";
                                pList.Clear();
                                if (MaterialList.Count > 0)
                                {
                                    pList.Add(new MySqlParameter("@wlID", MaterialList[0].ID));//取查询到的物料ID
                                    pList.Add(new MySqlParameter("@isExists", isExists));//存在物料状态
                                    pList.Add(new MySqlParameter("@remark", Inventory.remark));
                                }
                                else
                                {
                                    isExists = 1;
                                    pList.Add(new MySqlParameter("@wlID", 0));//取查询到的物料ID
                                    pList.Add(new MySqlParameter("@isExists", isExists));//改为不存在物料状态
                                    pList.Add(new MySqlParameter("@remark", $"【{Inventory.wlCode}-{Inventory.wlName}】不存在！将影响齐套分析数据准确性，请尽快完善此物料的基础信息并关联库存！"));
                                }
                                pList.Add(new MySqlParameter("@batch", Inventory.batch));
                                pList.Add(new MySqlParameter("@unit", Inventory.unit));
                                pList.Add(new MySqlParameter("@projectNo", Inventory.projectNo));
                                pList.Add(new MySqlParameter("@qty", item.qtyCount));
                                pList.Add(new MySqlParameter("@lockQty", Inventory.lockqty));
                                pList.Add(new MySqlParameter("@InvOrgID", Inventory.InvOrgID));
                                pList.Add(new MySqlParameter("@inventoryTypeID", Inventory.inventoryTypeID));
                                pList.Add(new MySqlParameter("@warehouseID", Inventory.warehouseID));
                                pList.Add(new MySqlParameter("@createTime", serverTime));
                                pList.Add(new MySqlParameter("@createMan", Inventory.createMan));
                                pList.Add(new MySqlParameter("@updateTime", serverTime));
                                pList.Add(new MySqlParameter("@updateMan", Inventory.updateMan));
                                ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                                break;
                            }
                        }
                    }

                    #endregion

                    #region 新增
                    //for (int i = 0; i < InventoryList.Count; i++)
                    //{
                    //    //根据当前物料名称、编码获取信息
                    //    var dtWL = db.ExecuteDataTable(System.Data.CommandType.Text, $"select * from base_material where mName = '{InventoryList[i].wlName}' and mDrawingNo = '{InventoryList[i].wlCode }'", null);
                    //    List<BaseMaterialModel> MaterialList = db.ToList<BaseMaterialModel>(dtWL);

                    //    sql = @"INSERT INTO base_inventory(wlID,batch,unit,projectNo,qty,lockQty,InvOrgID,inventoryTypeID,warehouseID,isExists,remark,createTime,createMan,updateTime,updateMan) 
                    //            Values(@wlID,@batch,@unit,@projectNo,@qty,@lockQty,@InvOrgID,@inventoryTypeID,@warehouseID,@isExists,@remark,@createTime,@createMan,@updateTime,@updateMan) ";
                    //    pList.Clear();
                    //    if (MaterialList.Count > 0)
                    //    {
                    //        pList.Add(new MySqlParameter("@wlID", MaterialList[0].ID));//取查询到的物料ID
                    //        pList.Add(new MySqlParameter("@isExists", 0));//存在物料状态
                    //        pList.Add(new MySqlParameter("@remark", InventoryList[i].remark));
                    //    }
                    //    else
                    //    {
                    //        pList.Add(new MySqlParameter("@wlID", 0));//取查询到的物料ID
                    //        pList.Add(new MySqlParameter("@isExists", 1));//改为不存在物料状态
                    //        pList.Add(new MySqlParameter("@remark", $"【{InventoryList[i].wlCode}-{InventoryList[i].wlName}】不存在！将影响齐套分析数据准确性，请尽快完善此物料的基础信息并关联库存！"));
                    //    }
                    //    pList.Add(new MySqlParameter("@batch", InventoryList[i].batch));
                    //    pList.Add(new MySqlParameter("@unit", InventoryList[i].unit));
                    //    pList.Add(new MySqlParameter("@projectNo", InventoryList[i].projectNo));
                    //    pList.Add(new MySqlParameter("@qty", InventoryList[i].qty));
                    //    pList.Add(new MySqlParameter("@lockQty", InventoryList[i].lockqty));
                    //    pList.Add(new MySqlParameter("@InvOrgID", InventoryList[i].InvOrgID));
                    //    pList.Add(new MySqlParameter("@inventoryTypeID", InventoryList[i].inventoryTypeID));
                    //    pList.Add(new MySqlParameter("@warehouseID", InventoryList[i].warehouseID));
                    //    pList.Add(new MySqlParameter("@createTime", serverTime));
                    //    pList.Add(new MySqlParameter("@createMan", InventoryList[i].createMan));
                    //    pList.Add(new MySqlParameter("@updateTime", serverTime));
                    //    pList.Add(new MySqlParameter("@updateMan", InventoryList[i].updateMan));
                    //    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    //}
                    #endregion

                    sql = @"insert into base_inventorylog(userID,logTime,remark) values(@userID,@logTime,@remark) ";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@userID", InventoryList[0].createMan));
                    pList.Add(new MySqlParameter("@logTime", serverTime));
                    pList.Add(new MySqlParameter("@remark", "Excel合并导入库存操作"));
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    myTrans.Commit();
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    ret = 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                result.ret = ret;
                return result;
            }
        }

        /// <summary>
        /// 获取库存操作最后时间 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseInventoryLogModel> GetInventoryLogTime(BaseInventoryLogModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select * from base_inventorylog where remark = @remark order by logTime desc";
            pList.Clear();
            pList.Add(new MySqlParameter("@remark", model.remark));
            List<BaseInventoryLogModel> list = db.ExecuteList<BaseInventoryLogModel>(sql, pList.ToArray());
            return list;
        }


        /*
        /// <summary>
        /// 通用库存操作方法
        /// </summary>
        /// <param name="model"></param>
        /// <param name="myTrans"></param>
        /// <returns></returns>
        public int EditInventory(BaseInventoryModel model, MySqlTransaction myTrans)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;//受影响的行数

            sql = @"select * from base_inventory where wlID=@wlID and warehouseID=@warehouseID";
            pList.Add(new MySqlParameter("@wlID", model.wlID));
            pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
            DataTable dtInv = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
            if (dtInv.Rows.Count > 1) return 0;
            if (dtInv.Rows.Count == 0 && model.changeInventory < 0) return 0;
            if (dtInv.Rows.Count == 1 && dtInv.Rows[0]["actualInventory"].ToInt() <= 0) return -1;
            if (dtInv.Rows.Count == 1 && (dtInv.Rows[0]["actualInventory"].ToInt() + model.changeInventory) < 0) return -1;

            int beforeQty = 0; //变化前数量
            if (dtInv.Rows.Count == 1)
                beforeQty = dtInv.Rows[0]["actualInventory"].ToInt();

            BaseInventoryLogModel logModel = new BaseInventoryLogModel();
            logModel.wlmodelID = model.wlmodelID;
            logModel.warehouseID = model.warehouseID;
            logModel.changeType = model.changeType;
            logModel.changeQty = model.changeInventory;
            logModel.beforeQty = beforeQty;
            logModel.afterQty = beforeQty + model.changeInventory;
            logModel.userID = model.userID;
            logModel.gwID = model.gwID;

            //若变化数量大于0且数据库内无库存数据
            if (model.changeInventory > 0 && dtInv.Rows.Count == 0)
                sql = @"insert into base_inventory(wlModelID,warehouseID,actualInventory) values(@wlModelID,@warehouseID,@actualInventory) ";
            else
                sql = @"update base_inventory set actualInventory=@actualInventory where wlmodelID=@wlmodelID and warehouseID=@warehouseID";
            pList.Clear();
            pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
            pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
            pList.Add(new MySqlParameter("@actualInventory", logModel.afterQty));
            i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

            #region 新增库存变更日志
            i += AddInventoryLog(logModel, myTrans);
            #endregion

            return i;
        }

        /// <summary>
        /// 通用库存记录Log操作方法
        /// </summary>
        /// <param name="model"></param>
        /// <param name="myTrans"></param>
        /// <returns></returns>
        public int AddInventoryLog(BaseInventoryLogModel model, MySqlTransaction myTrans)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int ret = 0;//受影响的行数

            sql = @"insert into base_inventorylog(wlModelID,warehouseID,changeType,changeQty,beforeQty,afterQty,userID,gwID,logTime) 
                                            values(@wlModelID,@warehouseID,@changeType,@changeQty,@beforeQty,@afterQty,@userID,@gwID,now())";
            pList.Clear();
            pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
            pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
            pList.Add(new MySqlParameter("@changeType", model.changeType));
            pList.Add(new MySqlParameter("@changeQty", model.changeQty));
            pList.Add(new MySqlParameter("@beforeQty", model.beforeQty));
            pList.Add(new MySqlParameter("@afterQty", model.afterQty));
            pList.Add(new MySqlParameter("@userID", model.userID));
            pList.Add(new MySqlParameter("@gwID", model.gwID));
            ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
            return ret;
        }

        */

        #endregion

        #region 物料基础信息 Add By Leon 20191012

        /// <summary>
        /// 物料管理分页 条件查询 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialList(BaseMaterialModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.mCode))
            {
                para += " and mCode=@mCode ";
                pList.Add(new MySqlParameter("@mCode", model.mCode));
            }
            if (!string.IsNullOrEmpty(model.mName))
            {
                para += " and mName=@mName ";
                pList.Add(new MySqlParameter("@mName", model.mName));
            }
            if (!string.IsNullOrEmpty(model.LIKECode))
            {
                para += " and mCode like CONCAT('%',@LIKECode,'%') ";
                pList.Add(new MySqlParameter("@LIKECode", model.LIKECode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEName))
            {
                para += " and mName like CONCAT('%',@LIKEName,'%') ";
                pList.Add(new MySqlParameter("@LIKEName", model.LIKEName.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEmDrawingNo))
            {
                para += " and mDrawingNo like CONCAT('%',@LIKEmDrawingNo,'%') ";
                pList.Add(new MySqlParameter("@LIKEmDrawingNo", model.LIKEmDrawingNo.Trim()));
            }
            if (model.mPTypeID.HasValue)
            {
                para += " and mPTypeID=@mPTypeID ";
                pList.Add(new MySqlParameter("@mPTypeID", model.mPTypeID));
            }
            if (model.UNID.HasValue)
            {
                para += " and m.ID<>@UNID ";
                pList.Add(new MySqlParameter("@UNID", model.UNID));
            }

            string sql = @"select Count(*) from base_material m
                            left join base_materialtype mt on mt.ID = m.mTypeID
                            left join base_supplier su on su.ID = m.mSupplierID
                            where 1=1 and mDeleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select m.*,mt.mtName,su.suName 
                            from base_material m
                            left join base_materialtype mt on mt.ID = m.mTypeID
                            left join base_supplier su on su.ID = m.mSupplierID
                            where 1=1 and mDeleteFlag=0 " + para;
            sql += " ORDER BY ID limit " + model.PageIndex + "," + model.PageSize;
            //sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<BaseMaterialModel> list = db.ExecuteList<BaseMaterialModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取所有物料信息 不带图片查询 加快查询速度
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialList()
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            string sql = @" select m.ID
                            ,m.mCode
                            ,m.mECode
                            ,m.mName
                            ,m.mAbbr
                            ,m.mPTypeID
                            ,m.mTypeID
                            ,m.mRTypeID
                            ,m.mUnit
                            ,m.mAMatchFlag
                            ,m.mSpec
                            ,m.mSupplierID
                            ,m.mSupplyNo
                            ,m.mDrawingNo
                            ,m.mBatchNo
                            ,m.mStandard
                            ,m.mSInvFlag
                            ,m.mSInvQty
                            ,m.mRemark
                            ,m.mDisableFlag
                            ,m.mDeleteFlag
                            ,m.mCreateTime
                            ,m.mCreaterID
                            ,m.mUpdateTime
                            ,m.mUpdaterID,mt.mtName,su.suName
                from base_material m
                left join base_materialtype mt on mt.ID = m.mTypeID
                left join base_supplier su on su.ID = m.mSupplierID
                where mDeleteFlag = 0";
            List<BaseMaterialModel> list = db.ExecuteList<BaseMaterialModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialList(BaseMaterialModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            string sql = "";

            if (model.ID != 0)
            {
                para += " and m.ID=@ID ";
                pList.Add(new MySqlParameter("@ID", model.ID));
            }
            if (!string.IsNullOrEmpty(model.mCode))
            {
                para += " and mCode=@mCode ";
                pList.Add(new MySqlParameter("@mCode", model.mCode));
            }
            if (!string.IsNullOrEmpty(model.mName))
            {
                para += " and mName=@mName ";
                pList.Add(new MySqlParameter("@mName", model.mName));
            }
            if (!string.IsNullOrEmpty(model.mDrawingNo))
            {
                para += " and mDrawingNo=@mDrawingNo ";
                pList.Add(new MySqlParameter("@mDrawingNo", model.mDrawingNo));
            }
            if (!string.IsNullOrEmpty(model.LIKECode))
            {
                para += " and mECode like CONCAT('%',@LIKEECode,'%') ";
                pList.Add(new MySqlParameter("@LIKEECode", model.LIKECode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEName))
            {
                para += " and mName like CONCAT('%',@LIKEName,'%') ";
                pList.Add(new MySqlParameter("@LIKEName", model.LIKEName.Trim()));
            }
            if (model.mPTypeID.HasValue)
            {
                para += " and mPTypeID=@mPTypeID ";
                pList.Add(new MySqlParameter("@mPTypeID", model.mPTypeID));
            }
            if (model.UNID.HasValue)
            {
                para += " and m.ID<>@UNID ";
                pList.Add(new MySqlParameter("@UNID", model.UNID));
            }

            sql = @"select m.*,mt.mtName,su.suName 
                            from base_material m
                            left join base_materialtype mt on mt.ID = m.mTypeID
                            left join base_supplier su on su.ID = m.mSupplierID
                            where mDeleteFlag=0 " + para;

            List<BaseMaterialModel> list = db.ExecuteList<BaseMaterialModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取物料数据
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialDict()
        {
            var db = new RW.PMS.Common.MySqlHelper();

            var list = db.ExecuteList<BaseMaterialModel>("select ID , mDrawingNo , mName  from base_material where mDeleteFlag = 0 order by mDrawingNo asc;");

            return list;
        }

        /// <summary>
        /// 获取物料数据
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialList(int progbID)
        {
            var db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select gpd.prodModelID from base_program pro
                                   left join program_gxinfo gx on pro.ID=gx.progID
                                   left join program_gbinfo gb on gx.ID=gb.progGxID
                                   left join gw_prod_def gpd on gpd.progID = pro.ID
                                   where gb.ID=" + progbID;
            int pmId = 0;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out pmId);
            pList.Clear();
            pList.Add(new MySqlParameter("@pmodelID", pmId));
            sql = "select bm.ID , bm.mDrawingNo , bm.mName  from base_gjwlopcpoint bg left join base_material bm on bm.ID=bg.wlID  where bm.mDeleteFlag = 0 and bg.pmodelID=@pmodelID GROUP BY bm.ID , bm.mDrawingNo , bm.mName;";

            var list = db.ExecuteList<BaseMaterialModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取物料条码标字典数据 2020-06-01
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialBarCodeModel> GetMaterialBarCodeDict()
        {
            var db = new RW.PMS.Common.MySqlHelper();

            var list = db.ExecuteList<BaseMaterialBarCodeModel>("select mb.ID,m_cardNo,m_MaterialID,mCode,mDrawingNo,mName as m_MaterialText from base_materialbarcode mb left join base_material m on mb.m_MaterialID = m.ID where m_status = 0 order by mName; ");

            return list;


        }


        /// <summary>
        /// 验证ID与图号是否属于同一物料
        /// </summary>
        /// <param name="mDrawingNo"></param>
        /// <returns></returns>
        public bool VerifyMaterial(int id, string mDrawingNo)
        {
            var db = new RW.PMS.Common.MySqlHelper();

            var sql = "select COUNT(*)  from base_material where mDeleteFlag = 0  AND ID=@ID  AND mDrawingNo=@mDrawingNo order by mName;";

            var count = db.ExecuteScalar<int>(sql, new MySqlParameter(@"mDrawingNo", mDrawingNo), new MySqlParameter(@"ID", id));

            return count > 0;
        }



        /// <summary>
        /// 验证条码ID 与条码卡号 是否关联的同一物料 2020-06-01
        /// </summary>
        /// <param name="mDrawingNo">图号</param>
        /// <param name="m_specificationmodels">型号</param>
        /// <returns></returns>
        public BaseMaterialBarCodeModel VerifyMaterialBarcode(string mDrawingNo, string m_specificationmodels)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            var sql = @"select mb.*,m.mName as m_MaterialText,su.suName as m_supplierText
            from base_materialbarcode mb
            left join base_material m on mb.m_MaterialID = m.ID
			left join base_supplier su on su.ID = mb.m_supplierID
            where m_status = 0 ";
            if (!string.IsNullOrEmpty(mDrawingNo))
            {
                sql += " and m.mDrawingNo = @mDrawingNo ";
                pList.Add(new MySqlParameter("@mDrawingNo", mDrawingNo));
            }
            if (!string.IsNullOrEmpty(m_specificationmodels) && !m_specificationmodels.Equals("/"))
            {
                sql += " and mb.m_specificationmodels = @m_specificationmodels ";
                pList.Add(new MySqlParameter("@m_specificationmodels", @m_specificationmodels));
            }
            var list = db.ExecuteList<BaseMaterialBarCodeModel>(sql, pList.ToArray());
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveMaterial(BaseMaterialModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            DateTime NowTime = db.GetServerTime();

            if (model.ID == 0)
            {
                sql = @"insert into base_material(mCode,mECode,mName,mAbbr,mPTypeID,mTypeID,mRTypeID,mUnit,mImg,mAMatchFlag,mSpec,mSupplierID,mSupplyNo,mDrawingNo,mBatchNo
                        ,mStandard,mSInvFlag,mSInvQty,mRemark,mDisableFlag,mDeleteFlag,mCreateTime,mCreaterID,mUpdateTime,mUpdaterID) values(@mCode,@mECode,@mName,@mAbbr,@mPTypeID,@mTypeID,@mRTypeID
                        ,@mUnit,@mImg,@mAMatchFlag,@mSpec,@mSupplierID,@mSupplyNo,@mDrawingNo,@mBatchNo,@mStandard,@mSInvFlag,@mSInvQty,@mRemark,0,0,@mCreateTime,@mCreaterID,@mUpdateTime,@mUpdaterID)";
                pList.Clear();
                pList.Add(new MySqlParameter("@mCode", model.mCode));
                pList.Add(new MySqlParameter("@mECode", model.mECode));
                pList.Add(new MySqlParameter("@mName", model.mName));
                pList.Add(new MySqlParameter("@mAbbr", model.mAbbr));
                pList.Add(new MySqlParameter("@mPTypeID", model.mPTypeID));
                pList.Add(new MySqlParameter("@mTypeID", model.mTypeID));
                pList.Add(new MySqlParameter("@mRTypeID", model.mRTypeID));
                pList.Add(new MySqlParameter("@mUnit", model.mUnit));
                pList.Add(new MySqlParameter("@mImg", model.mImg));
                pList.Add(new MySqlParameter("@mAMatchFlag", model.mAMatchFlag));
                pList.Add(new MySqlParameter("@mSpec", model.mSpec));
                pList.Add(new MySqlParameter("@mSupplierID", model.mSupplierID));
                pList.Add(new MySqlParameter("@mSupplyNo", model.mSupplyNo));
                pList.Add(new MySqlParameter("@mDrawingNo", model.mDrawingNo));
                pList.Add(new MySqlParameter("@mBatchNo", model.mBatchNo));
                pList.Add(new MySqlParameter("@mStandard", model.mStandard));
                pList.Add(new MySqlParameter("@mSInvFlag", model.mSInvFlag));
                pList.Add(new MySqlParameter("@mSInvQty", model.mSInvQty));
                pList.Add(new MySqlParameter("@mRemark", model.mRemark));
                pList.Add(new MySqlParameter("@mCreateTime", NowTime));
                pList.Add(new MySqlParameter("@mCreaterID", model.mUpdaterID));
                pList.Add(new MySqlParameter("@mUpdateTime", NowTime));
                pList.Add(new MySqlParameter("@mUpdaterID", model.mUpdaterID));
            }
            else
            {
                sql = @"update base_material set mCode=@mCode,mECode=@mECode,mName=@mName,mAbbr=@mAbbr,mPTypeID=@mPTypeID,mTypeID=@mTypeID,mRTypeID=@mRTypeID,
                        mUnit=@mUnit,mImg=@mImg,mAMatchFlag=@mAMatchFlag,mSpec=@mSpec,mSupplierID=@mSupplierID,mSupplyNo=@mSupplyNo,mDrawingNo=@mDrawingNo,
                        mBatchNo=@mBatchNo,mStandard=@mStandard,mSInvFlag=@mSInvFlag,mSInvQty=@mSInvQty,mRemark=@mRemark,mUpdateTime=@mUpdateTime,mUpdaterID=@mUpdaterID where ID=@ID";
                pList.Clear();
                pList.Add(new MySqlParameter("@ID", model.ID));
                pList.Add(new MySqlParameter("@mCode", model.mCode));
                pList.Add(new MySqlParameter("@mECode", model.mECode));
                pList.Add(new MySqlParameter("@mName", model.mName));
                pList.Add(new MySqlParameter("@mAbbr", model.mAbbr));
                pList.Add(new MySqlParameter("@mPTypeID", model.mPTypeID));
                pList.Add(new MySqlParameter("@mTypeID", model.mTypeID));
                pList.Add(new MySqlParameter("@mRTypeID", model.mRTypeID));
                pList.Add(new MySqlParameter("@mUnit", model.mUnit));
                pList.Add(new MySqlParameter("@mImg", model.mImg));
                pList.Add(new MySqlParameter("@mAMatchFlag", model.mAMatchFlag));
                pList.Add(new MySqlParameter("@mSpec", model.mSpec));
                pList.Add(new MySqlParameter("@mSupplierID", model.mSupplierID));
                pList.Add(new MySqlParameter("@mSupplyNo", model.mSupplyNo));
                pList.Add(new MySqlParameter("@mDrawingNo", model.mDrawingNo));
                pList.Add(new MySqlParameter("@mBatchNo", model.mBatchNo));
                pList.Add(new MySqlParameter("@mStandard", model.mStandard));
                pList.Add(new MySqlParameter("@mSInvFlag", model.mSInvFlag));
                pList.Add(new MySqlParameter("@mSInvQty", model.mSInvQty));
                pList.Add(new MySqlParameter("@mRemark", model.mRemark));
                pList.Add(new MySqlParameter("@mUpdateTime", NowTime));
                pList.Add(new MySqlParameter("@mUpdaterID", model.mUpdaterID));
            }

            i = db.ExecuteNonQuery(sql, pList.ToArray());

            return i > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteMaterial(BaseMaterialModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "";
            int i = 0;
            DateTime NowTime = db.GetServerTime();

            sql = @"update base_material set mDeleteFlag=1,mUpdateTime=@mUpdateTime,mUpdaterID=@mUpdaterID where ID=@ID";
            pList.Clear();
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@mUpdateTime", NowTime));
            pList.Add(new MySqlParameter("@mUpdaterID", model.mUpdaterID));

            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }

        #endregion

        #region 物料类型 Add By Leon 20191014

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseMaterialTypeModel> GetMaterialTypeList(BaseMaterialTypeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            string sql = "";

            sql = @"select mt.* from base_materialtype mt where mtDeleteFlag=0 " + para;
            List<BaseMaterialTypeModel> list = db.ExecuteList<BaseMaterialTypeModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 保存物料类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveMaterialType(BaseMaterialTypeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            DateTime NowTime = db.GetServerTime();

            if (model.ID == 0)
            {
                sql = @"insert into base_materialtype(mtName,mtRemark,mtDisableFlag,mtDeleteFlag,mtCreateTime,mtCreaterID,mtUpdateTime,mtUpdaterID) 
                                values(@mtName,@mtRemark,0,0,@mtCreateTime,@mtCreaterID,@mtUpdateTime,@mtUpdaterID)";
                pList.Clear();
                pList.Add(new MySqlParameter("@mtName", model.mtName));
                pList.Add(new MySqlParameter("@mtRemark", model.mtRemark));
                pList.Add(new MySqlParameter("@mtCreateTime", NowTime));
                pList.Add(new MySqlParameter("@mtCreaterID", model.mtUpdaterID));
                pList.Add(new MySqlParameter("@mtUpdateTime", NowTime));
                pList.Add(new MySqlParameter("@mtUpdaterID", model.mtUpdaterID));
            }
            else
            {
                sql = @"update base_materialtype set mtName=@mtName,mtRemark=@mtRemark,mtDisableFlag=@mtDisableFlag,mtUpdateTime=@mtUpdateTime,mtUpdaterID=@mtUpdaterID 
                                where ID=@ID";
                pList.Clear();
                pList.Add(new MySqlParameter("@ID", model.ID));
                pList.Add(new MySqlParameter("@mtName", model.mtName));
                pList.Add(new MySqlParameter("@mtRemark", model.mtRemark));
                pList.Add(new MySqlParameter("@mtDisableFlag", model.mtDisableFlag));
                pList.Add(new MySqlParameter("@mtUpdateTime", NowTime));
                pList.Add(new MySqlParameter("@mtUpdaterID", model.mtUpdaterID));
            }
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteMaterialType(BaseMaterialTypeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            DateTime NowTime = db.GetServerTime();

            sql = @"update base_materialtype set mtDeleteFlag=1,mtUpdateTime=@mtUpdateTime,mtUpdaterID=@mtUpdaterID where ID=@ID";
            pList.Clear();
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@mtUpdateTime", NowTime));
            pList.Add(new MySqlParameter("@mtUpdaterID", model.mtUpdaterID));

            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }
        #endregion

        #region 供应商 Add By Leon 20191026

        public List<BaseSupplierModel> GetSupplierList(BaseSupplierModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            string sql = "";

            if (!string.IsNullOrEmpty(model.suName))
            {
                para += " and suName = @suName ";
                pList.Add(new MySqlParameter("@suName", model.suName));
            }

            sql = @"select su.* from base_supplier su where suDeleteFlag=0 " + para;
            sql += " order by su.suName ";
            List<BaseSupplierModel> list = db.ExecuteList<BaseSupplierModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存供应商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveSupplier(BaseSupplierModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            DateTime NowTime = db.GetServerTime();

            if (model.ID == 0)
            {
                sql = @"insert into base_supplier(suName,suRemark,suDisableFlag,suDeleteFlag,suCreateTime,suCreaterID,suUpdateTime,suUpdaterID) 
                                values(@suName,@suRemark,0,0,@suCreateTime,@suCreaterID,@suUpdateTime,@suUpdaterID)";
                pList.Clear();
                pList.Add(new MySqlParameter("@suName", model.suName));
                pList.Add(new MySqlParameter("@suRemark", model.suRemark));
                pList.Add(new MySqlParameter("@suCreateTime", NowTime));
                pList.Add(new MySqlParameter("@suCreaterID", model.suUpdaterID));
                pList.Add(new MySqlParameter("@suUpdateTime", NowTime));
                pList.Add(new MySqlParameter("@suUpdaterID", model.suUpdaterID));
            }
            else
            {
                sql = @"update base_materialtype set suName=@suName,suRemark=@suRemark,suDisableFlag=@suDisableFlag,suUpdateTime=@suUpdateTime,suUpdaterID=@suUpdaterID 
                                where ID=@ID";
                pList.Clear();
                pList.Add(new MySqlParameter("@ID", model.ID));
                pList.Add(new MySqlParameter("@suName", model.suName));
                pList.Add(new MySqlParameter("@suRemark", model.suRemark));
                pList.Add(new MySqlParameter("@suDisableFlag", model.suDisableFlag));
                pList.Add(new MySqlParameter("@suUpdateTime", NowTime));
                pList.Add(new MySqlParameter("@suUpdaterID", model.suUpdaterID));
            }
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i;
        }

        #endregion

        #region EBOM Add By Leon 20191016

        /// <summary>
        /// 条件查询EBOM
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseEBOMModel> GetEBOMList(BaseEBOMModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            string sql = "";

            if (model.ebParentID.HasValue)
            {
                para += " and ebParentID = @ebParentID ";
                pList.Add(new MySqlParameter("@ebParentID", model.ebParentID));
            }
            if (model.ebChildID.HasValue)
            {
                para += " and ebChildID = @ebChildID ";
                pList.Add(new MySqlParameter("@ebChildID", model.ebChildID));
            }
            if (model.UNID.HasValue && model.UNID > 0)
            {
                para += " and eb.ID <> @UNID ";
                pList.Add(new MySqlParameter("@UNID", model.UNID));
            }

            if (model.ebProdModelID.HasValue && model.ebProdModelID != 0)
            {
                para += " and ebProdModelID = @ebProdModelID ";
                pList.Add(new MySqlParameter("@ebProdModelID", model.ebProdModelID));
            }

            if (model.ebOperationID.HasValue && model.ebOperationID != 0)
            {
                para += " and ebOperationID = @ebOperationID ";
                pList.Add(new MySqlParameter("@ebOperationID", model.ebOperationID));
            }

            sql = @"select eb.*,
                    pm.mName ebParentName,pm.mDrawingNo as ParentDrawingNo,CONCAT_WS(' - ',pm.mName,pm.mDrawingNo) as ParentName,
                    sm.mName ebChildName,sm.mDrawingNo as ChildDrawingNo,CONCAT_WS(' - ',sm.mName,sm.mDrawingNo) as ChildName,mt.mtName,GetbdNameBybdID(eb.ebMsource) as ebMsourceText,
                    CONCAT_WS('-',bpm.Pmodel,bpm.DrawingNo) as Pmodel,bpgx.operationName from base_ebom eb
					left join base_productmodel bpm on eb.ebProdModelID = bpm.ID
					left join base_partGongxu bpgx on eb.ebOperationID = bpgx.ID
                    left join base_material pm on pm.ID=eb.ebParentID
                    left join base_material sm on sm.ID=eb.ebChildID
					left join base_materialtype mt on mt.ID = sm.mTypeID
                    where ebDeleteFlag=0 " + para;
            List<BaseEBOMModel> list = db.ExecuteList<BaseEBOMModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存EBOM
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveEBOM(BaseEBOMModel model, out string Message)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                string msg = "";

                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";
                    DateTime NowTime = db.GetServerTime();

                    //判断所属物料是否为空为0，如果是为直接为1级物料
                    if (!model.ebParentID.HasValue || model.ebParentID == 0)
                    {
                        model.ebLevel = 1;
                        model.ebPath = "/" + model.ebChildID + "/";
                    }
                    else
                    {
                        //否则查询当前所属物料是几级物料
                        sql = @"select * from base_ebom where ebProdModelID=@ebProdModelID and ebOperationID=@ebOperationID and ebChildID=@ebChildID and ebDeleteFlag = 0";
                        pList.Add(new MySqlParameter("@ebProdModelID", model.ebProdModelID));
                        pList.Add(new MySqlParameter("@ebOperationID", model.ebOperationID));
                        pList.Add(new MySqlParameter("@ebChildID", model.ebParentID));
                        List<BaseEBOMModel> list = db.ExecuteList<BaseEBOMModel>(sql, pList.ToArray());
                        if (list != null)
                        {
                            if (list.Count > 0)
                            {
                                model.ebLevel = list[0].ebLevel + 1;
                                model.ebPath = "/" + list[0].ebChildID + "/" + model.ebChildID;
                            }
                            else
                            {
                                msg = "当前选中的所属物料还未添加，请先添加在进行关联！";
                            }
                        }
                    }

                    //如果ID为0（添加）否则修改
                    if (model.ID == 0)
                    {
                        sql = @"insert into base_ebom(ebProdModelID,ebOperationID,ebParentID,ebChildID,ebQty,ebMsource,ebLevel,ebPath,ebRemark,ebDisableFlag,ebDeleteFlag,
                                ebCreateTime,ebCreaterID,ebUpdateTime,ebUpdaterID) values(@ebProdModelID,@ebOperationID,@ebParentID,@ebChildID,@ebQty,@ebMsource,@ebLevel,@ebPath,
                                @ebRemark,0,0,@ebCreateTime,@ebCreaterID,@ebUpdateTime,@ebUpdaterID)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ebProdModelID", model.ebProdModelID));
                        pList.Add(new MySqlParameter("@ebOperationID", model.ebOperationID));
                        pList.Add(new MySqlParameter("@ebParentID", model.ebParentID));
                        pList.Add(new MySqlParameter("@ebChildID", model.ebChildID));
                        pList.Add(new MySqlParameter("@ebQty", model.ebQty));
                        pList.Add(new MySqlParameter("@ebMsource", model.ebMsource));
                        pList.Add(new MySqlParameter("@ebLevel", model.ebLevel));
                        pList.Add(new MySqlParameter("@ebPath", model.ebPath));
                        pList.Add(new MySqlParameter("@ebRemark", model.ebRemark));
                        pList.Add(new MySqlParameter("@ebCreateTime", NowTime));
                        pList.Add(new MySqlParameter("@ebCreaterID", model.ebUpdaterID));
                        pList.Add(new MySqlParameter("@ebUpdateTime", NowTime));
                        pList.Add(new MySqlParameter("@ebUpdaterID", model.ebUpdaterID));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }
                    else
                    {
                        sql = @"update base_ebom set ebProdModelID=@ebProdModelID,ebOperationID=@ebOperationID,ebParentID=@ebParentID,ebChildID=@ebChildID,
                                ebQty=@ebQty,ebMsource=@ebMsource,ebLevel=@ebLevel,ebPath=@ebPath,ebRemark=@ebRemark,ebDisableFlag=0,ebDeleteFlag=0,ebUpdateTime=@ebUpdateTime,
                                ebUpdaterID=@ebUpdaterID where ID=@ID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ID", model.ID));
                        pList.Add(new MySqlParameter("@ebProdModelID", model.ebProdModelID));
                        pList.Add(new MySqlParameter("@ebOperationID", model.ebOperationID));
                        pList.Add(new MySqlParameter("@ebParentID", model.ebParentID));
                        pList.Add(new MySqlParameter("@ebChildID", model.ebChildID));
                        pList.Add(new MySqlParameter("@ebQty", model.ebQty));
                        pList.Add(new MySqlParameter("@ebMsource", model.ebMsource));
                        pList.Add(new MySqlParameter("@ebLevel", model.ebLevel));
                        pList.Add(new MySqlParameter("@ebPath", model.ebPath));
                        pList.Add(new MySqlParameter("@ebRemark", model.ebRemark));
                        pList.Add(new MySqlParameter("@ebUpdateTime", NowTime));
                        pList.Add(new MySqlParameter("@ebUpdaterID", model.ebUpdaterID));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    myTrans.Commit();
                    Message = msg;
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    Message = msg;
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }





        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteEBOM(BaseEBOMModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            DateTime NowTime = db.GetServerTime();
            sql = @"update base_ebom set ebDeleteFlag=1,ebUpdateTime=@ebUpdateTime,ebUpdaterID=@ebUpdaterID where ID=@ID";
            pList.Clear();
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@ebUpdateTime", NowTime));
            pList.Add(new MySqlParameter("@ebUpdaterID", model.ebUpdaterID));

            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }


        /// <summary>
        /// 获取物料拼接图号 零件名称-零件号（图号）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialDrawingNoList(BaseMaterialModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            string sql = "";
            sql = @"select ID,mCode,mName,mDrawingNo,CONCAT_WS('-',mName,mDrawingNo) as mNameDrawingNo from base_material where mDeleteFlag = 0 " + para;
            List<BaseMaterialModel> list = db.ExecuteList<BaseMaterialModel>(sql, pList.ToArray());
            return list;
        }



        #endregion

        #region 领料单 LHR

        /// <summary>
        /// 分页查询领料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsRequisitionMainModel> GetWmsRequisitionMainList(WmsRequisitionMainModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (!string.IsNullOrEmpty(model.Iv_applyNo))
            {
                para += " and Iv_applyNo like CONCAT('%',@Iv_applyNo,'%') ";
                pList.Add(new MySqlParameter("@Iv_applyNo", model.Iv_applyNo));
            }
            if (model.Iv_RTypeID != null && model.Iv_RTypeID != 0)
            {
                para += " and Iv_RTypeID = @Iv_RTypeID ";
                pList.Add(new MySqlParameter("@Iv_RTypeID", model.Iv_RTypeID));
            }
            if (model.Iv_applyStatus != null && model.Iv_applyStatus != 0)
            {
                para += " and Iv_applyStatus = @Iv_applyStatus ";
                pList.Add(new MySqlParameter("@Iv_applyStatus", model.Iv_applyStatus));
            }
            string sql = @"SELECT count(*) 
                                  from wms_requisitionmain wr
                                    left join sys_user su on wr.Iv_applierID = su.userID
                                    where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select *,su.empName as Iv_applierName from wms_requisitionmain wr
                                    left join sys_user su on wr.Iv_applierID = su.userID
                                    where 1=1 " + para;

            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<WmsRequisitionMainModel> list = db.ExecuteList<WmsRequisitionMainModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 根据条件查询领料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsRequisitionMainModel> GetWmsRequisitionMainList(WmsRequisitionMainModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (!string.IsNullOrEmpty(model.Iv_applyNo))
            {
                para += " and Iv_applyNo like CONCAT('%',@Iv_applyNo,'%') ";
                pList.Add(new MySqlParameter("@Iv_applyNo", model.Iv_applyNo));
            }
            if (model.Iv_RTypeID != null && model.Iv_RTypeID != 0)
            {
                para += " and Iv_RTypeID = @Iv_RTypeID ";
                pList.Add(new MySqlParameter("@Iv_RTypeID", model.Iv_RTypeID));
            }
            if (model.Iv_applyStatus != null && model.Iv_applyStatus != 0)
            {
                para += " and Iv_applyStatus = @Iv_applyStatus ";
                pList.Add(new MySqlParameter("@Iv_applyStatus", model.Iv_applyStatus));
            }

            string sql = @"select *,su.empName as Iv_applierName from wms_requisitionmain wr
                                    left join sys_user su on wr.Iv_applierID = su.userID
                                    where 1=1 " + para;
            //sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<WmsRequisitionMainModel> list = db.ExecuteList<WmsRequisitionMainModel>(sql, pList.ToArray());

            return list;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteWmsRequisitionMain(string Iv_guid)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                bool ret = false;

                try
                {
                    RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                    List<MySqlParameter> pList = new List<MySqlParameter>();

                    string[] list = Iv_guid.Split(',');
                    for (int i = 0; i < list.Length; i++)
                    {
                        var Ivguid = list[i].ToString();
                        string sql = "delete from wms_requisitiondetail where Iv_guid = '" + Ivguid + "'";
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    for (int i = 0; i < list.Length; i++)
                    {
                        var Ivguid = list[i].ToString();
                        string sql = "delete from wms_requisitionmain where Iv_guid = '" + Ivguid + "'";
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    myTrans.Commit();
                    ret = true;
                }
                catch
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }


        /// <summary>
        /// 根据 Iv_guid获取 领料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsRequisitionDetailModel> GetWmsRequisitionDetail(WmsRequisitionDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            //if (model.Iv_guid != Guid.Empty)
            //{
            //    para += "";

            //}

            string sql = @"select wrd.*,bm.mName as wlName,wr.*,su.empName as Iv_applierName from wms_requisitiondetail wrd
									left join wms_requisitionmain wr on wr.Iv_guid = wrd.Iv_guid
                                    left join sys_user su on wr.Iv_applierID = su.userID
									left join base_material bm on wrd.Ivd_wlLjID = bm.ID
                                    where 1=1 and wr.Iv_guid = @Iv_guid " + para;
            pList.Add(new MySqlParameter("@Iv_guid", model.Iv_guid));
            List<WmsRequisitionDetailModel> list = db.ExecuteList<WmsRequisitionDetailModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 保存 领料单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveWmsRequisitionMainDetail(WmsRequisitionMainModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                bool ret = false;

                try
                {

                    var Ivguid = Guid.Empty;

                    #region wms_requisitionmain 数据操作

                    if (model.Iv_guid == Guid.Empty)
                    {
                        #region 添加主表

                        Ivguid = Guid.NewGuid();

                        string sqlmainadd = @"insert into wms_requisitionmain (Iv_guid,Iv_applyNo,Iv_RTypeID,Iv_SWID,Iv_TWID,Iv_applierID,Iv_applyDate,Iv_applyStatus,Iv_remark) 
                                            values(@Iv_guid,@Iv_applyNo,@Iv_RTypeID,@Iv_SWID,@Iv_TWID,@Iv_applierID,@Iv_applyDate,@Iv_applyStatus,@Iv_remark	)";
                        List<MySqlParameter> mainaddList = new List<MySqlParameter>();
                        mainaddList.Add(new MySqlParameter("@Iv_guid", Ivguid));
                        mainaddList.Add(new MySqlParameter("@Iv_applyNo", model.Iv_applyNo));
                        mainaddList.Add(new MySqlParameter("@Iv_RTypeID", model.Iv_RTypeID));
                        mainaddList.Add(new MySqlParameter("@Iv_SWID", model.Iv_SWID));
                        mainaddList.Add(new MySqlParameter("@Iv_TWID", model.Iv_TWID));
                        mainaddList.Add(new MySqlParameter("@Iv_applierID", model.Iv_applierID));
                        mainaddList.Add(new MySqlParameter("@Iv_applyDate", model.Iv_applyDate));
                        mainaddList.Add(new MySqlParameter("@Iv_applyStatus", model.Iv_applyStatus));
                        mainaddList.Add(new MySqlParameter("@Iv_remark", model.Iv_remark));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlmainadd, mainaddList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 修改主表

                        Ivguid = model.Iv_guid;

                        string sqlmainupdate = @"update wms_requisitionmain set Iv_applyNo=@Iv_applyNo,Iv_RTypeID=@Iv_RTypeID,Iv_SWID=@Iv_SWID,Iv_TWID=@Iv_TWID,
                                                            Iv_applierID=@Iv_applierID,Iv_applyDate=@Iv_applyDate,Iv_applyStatus=@Iv_applyStatus,Iv_remark=@Iv_remark
                                                            where Iv_guid=@Iv_guid ";
                        List<MySqlParameter> mainupdateList = new List<MySqlParameter>();
                        mainupdateList.Add(new MySqlParameter("@Iv_applyNo", model.Iv_applyNo));
                        mainupdateList.Add(new MySqlParameter("@Iv_RTypeID", model.Iv_RTypeID));
                        mainupdateList.Add(new MySqlParameter("@Iv_SWID", model.Iv_SWID));
                        mainupdateList.Add(new MySqlParameter("@Iv_TWID", model.Iv_TWID));
                        mainupdateList.Add(new MySqlParameter("@Iv_applierID", model.Iv_applierID));
                        mainupdateList.Add(new MySqlParameter("@Iv_applyDate", model.Iv_applyDate));
                        mainupdateList.Add(new MySqlParameter("@Iv_applyStatus", model.Iv_applyStatus));
                        mainupdateList.Add(new MySqlParameter("@Iv_remark", model.Iv_remark));
                        mainupdateList.Add(new MySqlParameter("@Iv_guid", Ivguid));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlmainupdate, mainupdateList.ToArray());

                        #endregion
                    }

                    #endregion

                    #region wms_requisitiondetail 数据操作

                    //先删除所有该GUID下的领料单明细 
                    string sqlids = "delete from wms_requisitiondetail where Iv_guid = @Iv_guid ";
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    pList.Add(new MySqlParameter("@Iv_guid", Ivguid));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlids, pList.ToArray());

                    //此次新增项集合 
                    var insertItemList = model.detailList.Where(_ => _.Ivd_ID == 0).ToList();

                    foreach (var news in insertItemList)
                    {
                        #region 添加

                        string sqldetailadd1 = @"insert into wms_requisitiondetail(Iv_guid,Ivd_wlLjID,Ivd_wlModelID,Ivd_applyQty,Ivd_remark) 
                                                                    values(@Iv_guid,@Ivd_wlLjID,@Ivd_wlModelID,@Ivd_applyQty,@Ivd_remark)";
                        List<MySqlParameter> detailadd1List = new List<MySqlParameter>();
                        detailadd1List.Add(new MySqlParameter("@Iv_guid", Ivguid));
                        detailadd1List.Add(new MySqlParameter("@Ivd_wlLjID", news.Ivd_wlLjID));
                        detailadd1List.Add(new MySqlParameter("@Ivd_wlModelID", news.Ivd_wlModelID));
                        detailadd1List.Add(new MySqlParameter("@Ivd_applyQty", news.Ivd_applyQty));
                        detailadd1List.Add(new MySqlParameter("@Ivd_remark", news.Ivd_remark));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqldetailadd1, detailadd1List.ToArray());

                        #endregion
                    }

                    #endregion

                    myTrans.Commit();
                    ret = true;
                }
                catch
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }

        /// <summary>
        /// 根据 申请单号 条件查询领料单主表最大申请单号 
        /// </summary>
        /// <param name="Iv_applyNo"></param>
        /// <returns></returns>
        public List<WmsRequisitionMainModel> GetWmsRequisitionByapplyNo(string Iv_applyNo)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(Iv_applyNo))
            {
                para += " and Iv_applyNo like CONCAT('%',@Iv_applyNo,'%') ";
                pList.Add(new MySqlParameter("@Iv_applyNo", Iv_applyNo));
            }

            string sql = @"select max(Iv_applyNo) as Iv_applyNo from wms_requisitionmain
                                    where 1=1 " + para;
            sql += " order by Iv_applyNo asc ";
            List<WmsRequisitionMainModel> list = db.ExecuteList<WmsRequisitionMainModel>(sql, pList.ToArray());
            return list;
        }

        #endregion

        #region 配料单 LHR

        /// <summary>
        /// 根据条件查询配料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsBatchingMainModel> GetWmsBatchingMainList(WmsBatchingMainModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.wb_code))
            {
                para += " and wb_code like CONCAT('%',@wb_code,'%') ";
                pList.Add(new MySqlParameter("@wb_code", model.wb_code));
            }
            if (model.wb_typeID != null && model.wb_typeID != 0)
            {
                para += " and wb_typeID = @wb_typeID ";
                pList.Add(new MySqlParameter("@wb_typeID", model.wb_typeID));
            }

            string sql = @"select *,GetEmpNameByuID(wb.wb_operID) as wb_operName,GetEmpNameByuID(wb.wb_receiveID) as wb_receiveName from wms_batchingmain wb
                                    where 1=1 " + para;
            //sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<WmsBatchingMainModel> list = db.ExecuteList<WmsBatchingMainModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 根据 申请单号 条件查询配料单主表最大申请单号
        /// </summary>
        /// <param name="wb_code"></param>
        /// <returns></returns>
        public List<WmsBatchingMainModel> GetBatchingmainByCode(string wb_code)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(wb_code))
            {
                para += " and wb_code like CONCAT('%',@wb_code,'%') ";
                pList.Add(new MySqlParameter("@wb_code", wb_code));
            }

            string sql = @"select max(wb_code) as wb_code from wms_batchingmain
                                   where 1=1 " + para;
            sql += " order by wb_code asc ";
            List<WmsBatchingMainModel> list = db.ExecuteList<WmsBatchingMainModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 根据 wb_guid 获取配料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsBatchingDetailModel> GetWmsDatchingDetail(WmsBatchingDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            string sql = @"select wbd.*,GetWLNameByWLID(wbd.wbd_wlLjid) as wbd_wlLJName,wm.wlModels as wbd_wlModelName,wb.*,bc.c_cardNo from wms_batchingdetail wbd
									left join wms_batchingmain wb on wbd.wb_guid = wb.wb_guid
									left join base_wuliaomodel wm on wbd.wbd_wlModelID = wm.wlmodelID
									left join base_barcode bc on wb.wb_BarCodeID = bc.ID
                                    where 1=1 and wb.wb_guid = @wb_guid " + para;
            pList.Add(new MySqlParameter("@wb_guid", model.wb_guid));
            List<WmsBatchingDetailModel> list = db.ExecuteList<WmsBatchingDetailModel>(sql, pList.ToArray());
            return list;
        }




        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteWmsBatchingMain(string wb_guid)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                bool ret = false;

                try
                {
                    RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                    List<MySqlParameter> pList = new List<MySqlParameter>();

                    string[] list = wb_guid.Split(',');
                    for (int i = 0; i < list.Length; i++)
                    {
                        var Wbguid = list[i].ToString();
                        string sql = "delete from wms_batchingdetail where wb_guid = '" + Wbguid + "'";
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    for (int i = 0; i < list.Length; i++)
                    {
                        var Wbguid = list[i].ToString();
                        string sql = "delete from wms_batchingmain where wb_guid = '" + Wbguid + "'";
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    myTrans.Commit();
                    ret = true;
                }
                catch
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }


        /// <summary>
        /// 保存 配料单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveWmsBatchingMainDetail(WmsBatchingMainModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                bool ret = false;

                try
                {

                    var Wbguid = Guid.Empty;

                    #region wms_batchingmain 数据操作

                    if (model.wb_guid == Guid.Empty)
                    {
                        #region 添加主表

                        Wbguid = Guid.NewGuid();

                        string sqlmainadd = @"insert into wms_batchingmain (wb_guid,wb_code,pp_guid,Iv_guid,wb_typeID,wb_BarCodeID,wb_SWID,wb_TWID,wb_operID,wb_batchtime,wb_dispatchTime,
                                                        wb_receiveID,wb_createtime,wb_status,wb_remark) values(@wb_guid,@wb_code,@pp_guid,@Iv_guid,@wb_typeID,@wb_BarCodeID,@wb_SWID,@wb_TWID,@wb_operID,
                                                        @wb_batchtime,@wb_dispatchTime,@wb_receiveID,@wb_createtime,@wb_status,@wb_remark)";
                        List<MySqlParameter> mainaddList = new List<MySqlParameter>();
                        mainaddList.Add(new MySqlParameter("@wb_guid", Wbguid));
                        mainaddList.Add(new MySqlParameter("@wb_code", model.wb_code));
                        mainaddList.Add(new MySqlParameter("@pp_guid", model.pp_guid));
                        mainaddList.Add(new MySqlParameter("@Iv_guid", model.Iv_guid));
                        mainaddList.Add(new MySqlParameter("@wb_typeID", model.wb_typeID));
                        mainaddList.Add(new MySqlParameter("@wb_BarCodeID", model.wb_BarCodeID));
                        mainaddList.Add(new MySqlParameter("@wb_SWID", model.wb_SWID));
                        mainaddList.Add(new MySqlParameter("@wb_TWID", model.wb_TWID));
                        mainaddList.Add(new MySqlParameter("@wb_operID", model.wb_operID));
                        mainaddList.Add(new MySqlParameter("@wb_batchtime", model.wb_batchtime));
                        mainaddList.Add(new MySqlParameter("@wb_receiveID", model.wb_receiveID));
                        mainaddList.Add(new MySqlParameter("@wb_dispatchTime", model.wb_dispatchTime));
                        mainaddList.Add(new MySqlParameter("@wb_createtime", model.wb_createtime));
                        mainaddList.Add(new MySqlParameter("@wb_status", model.wb_status));
                        mainaddList.Add(new MySqlParameter("@wb_remark", model.wb_remark));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlmainadd, mainaddList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 修改主表

                        Wbguid = model.wb_guid;

                        string sqlmainupdate = @"update wms_batchingmain set wb_code=@wb_code,pp_guid=@pp_guid,Iv_guid=@Iv_guid,wb_typeID=@wb_typeID,wb_BarCodeID=@wb_BarCodeID,wb_SWID=@wb_SWID,
                                                            wb_TWID=@wb_TWID,wb_operID=@wb_operID,wb_batchtime=@wb_batchtime,wb_dispatchTime=@wb_dispatchTime,wb_receiveID=@wb_receiveID,
                                                            wb_createtime=@wb_createtime,wb_status=@wb_status,wb_remark=@wb_remark where wb_guid=@wb_guid ";
                        List<MySqlParameter> mainupdateList = new List<MySqlParameter>();
                        mainupdateList.Add(new MySqlParameter("@wb_code", model.wb_code));
                        mainupdateList.Add(new MySqlParameter("@pp_guid", model.pp_guid));
                        mainupdateList.Add(new MySqlParameter("@Iv_guid", model.Iv_guid));
                        mainupdateList.Add(new MySqlParameter("@wb_typeID", model.wb_typeID));
                        mainupdateList.Add(new MySqlParameter("@wb_BarCodeID", model.wb_BarCodeID));
                        mainupdateList.Add(new MySqlParameter("@wb_SWID", model.wb_SWID));
                        mainupdateList.Add(new MySqlParameter("@wb_TWID", model.wb_TWID));
                        mainupdateList.Add(new MySqlParameter("@wb_operID", model.wb_operID));
                        mainupdateList.Add(new MySqlParameter("@wb_batchtime", model.wb_batchtime));
                        mainupdateList.Add(new MySqlParameter("@wb_receiveID", model.wb_receiveID));
                        mainupdateList.Add(new MySqlParameter("@wb_dispatchTime", model.wb_dispatchTime));
                        mainupdateList.Add(new MySqlParameter("@wb_createtime", model.wb_createtime));
                        mainupdateList.Add(new MySqlParameter("@wb_status", model.wb_status));
                        mainupdateList.Add(new MySqlParameter("@wb_remark", model.wb_remark));
                        mainupdateList.Add(new MySqlParameter("@wb_guid", Wbguid));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlmainupdate, mainupdateList.ToArray());

                        #endregion
                    }

                    #endregion

                    #region wms_batchingdetail 数据操作

                    //先删除所有该GUID下的配料单明细
                    string sqlids = "delete from wms_batchingdetail where wb_guid = @wb_guid ";
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    pList.Add(new MySqlParameter("@wb_guid", Wbguid));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlids, pList.ToArray());

                    //此次新增项集合
                    var insertItemList = model.detailList.Where(_ => _.wbd_ID == 0).ToList();

                    foreach (var news in insertItemList)
                    {
                        #region 添加

                        string sqldetailadd1 = @"insert into wms_batchingdetail(wb_guid,wbd_wlLJid,wbd_wlModelID,wbd_wlCodeNo,wbd_replaceQty,wbd_batchQty,wbd_remark) 
                                                                    values(@wb_guid,@wbd_wlLJid,@wbd_wlModelID,@wbd_wlCodeNo,@wbd_replaceQty,@wbd_batchQty,@wbd_remark)";
                        List<MySqlParameter> detailadd1List = new List<MySqlParameter>();
                        detailadd1List.Add(new MySqlParameter("@wb_guid", Wbguid));
                        detailadd1List.Add(new MySqlParameter("@wbd_wlLJid", news.wbd_wlLJid));
                        detailadd1List.Add(new MySqlParameter("@wbd_wlModelID", news.wbd_wlModelID));
                        detailadd1List.Add(new MySqlParameter("@wbd_wlCodeNo", news.wbd_wlCodeNo));
                        detailadd1List.Add(new MySqlParameter("@wbd_replaceQty", news.wbd_replaceQty));
                        detailadd1List.Add(new MySqlParameter("@wbd_batchQty", news.wbd_batchQty));
                        detailadd1List.Add(new MySqlParameter("@wbd_remark", news.wbd_remark));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqldetailadd1, detailadd1List.ToArray());

                        #endregion
                    }

                    #endregion

                    #region 绑码
                    if (!string.IsNullOrEmpty(model.wb_barcode))
                    {
                        var list = GetBarCodeList(new BaseBarcodeModel() { c_cardNo = model.wb_barcode });
                        if (list.Count > 0)
                        {
                            BaseBarcodeModel barcodemodel = list[0];
                            BindBarCode(barcodemodel, myTrans);
                        }
                    }

                    #endregion

                    myTrans.Commit();
                    ret = true;
                }
                catch
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }


        /// <summary>
        /// 根据 条码卡类型ID 获取所有条码卡号
        /// </summary>
        /// <param name="barcodeTypeID"></param>
        /// <param name="Status">传入布尔判断条码状态</param>
        /// <returns></returns>
        public List<BaseBarcodeModel> GetBarCodeByBarcodeTypeID(int barcodeTypeID, bool Status)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (Status == true)
            {
                para = " and c_status <> 1 ";
            }
            else
            {
                para = " and c_status = 1 ";
            }
            string sql = @"select * from base_barcode where c_cardType = @c_cardType " + para;
            pList.Add(new MySqlParameter("@c_cardType", barcodeTypeID));
            List<BaseBarcodeModel> list = db.ExecuteList<BaseBarcodeModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 根据 计划获取产品型号下所有必换件配料明细
        /// </summary>
        /// <returns></returns>
        public List<WmsBatchingDetailModel> GetPlanProdBatchingDetail(string pp_guid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select bom.wuliaoLjid as wbd_wlLJid,model.mName as wbd_wlLJName,bom.wuliaoLJid as wbd_wlModelID,
                                    model.mName as wbd_wlModelName,replaceQty as wbd_replaceQty,pp_planQty  from plan_prod as pp
                                    left join base_bom bom on pp.pp_prodModelID  = bom.prodModelId
                                    left join base_material model on bom.wuliaoLJid = model.ID
                                    where pp_guid = @pp_guid and bom.replaceTypeID = 1";
            pList.Add(new MySqlParameter("@pp_guid", pp_guid));
            List<WmsBatchingDetailModel> list = db.ExecuteList<WmsBatchingDetailModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 根据 领料单获取所有配料明细
        /// </summary>
        /// <returns></returns>
        public List<WmsBatchingDetailModel> GetRequisitionBatchingDetail(string iv_guid)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select Iv_SWID as wb_SWID,Iv_TWID as wb_TWID,Ivd_wlLjID as wbd_wlLJid,model.mName as  wbd_wlLJName,Ivd_wlModelID as wbd_wlModelID,
                                    model.mName as wbd_wlModelName,Ivd_applyQty as wbd_replaceQty from wms_requisitiondetail as detail 
                                    left join wms_requisitionmain main on detail.Iv_guid = main.Iv_guid
                                    left join base_material model on detail.Ivd_wlLjID = model.ID
                                    where detail.Iv_guid = @iv_guid ";
            pList.Add(new MySqlParameter("@iv_guid", iv_guid));
            List<WmsBatchingDetailModel> list = db.ExecuteList<WmsBatchingDetailModel>(sql, pList.ToArray());
            return list;
        }


        #endregion

        #region 用户组 WZQ

        /// <summary>
        /// 根据条件查询用户组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseUserGroupModel> GetUserGroupPaging(BaseUserGroupModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.ugGroupName))
            {
                para += " and ugGroupName like CONCAT('%',@ugGroupName,'%')";
                pList.Add(new MySqlParameter("@ugGroupName", model.ugGroupName));
            }

            string sql = @"select Count(*) from base_userGroup  where 1=1 and ugDeleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select *,(case when ugDisableFlag=0 then '启用' else '禁用' end) as IsDisableFlag from base_userGroup where 1=1 and ugDeleteFlag=0 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseUserGroupModel> list = db.ExecuteList<BaseUserGroupModel>(sql, pList.ToArray());
            //获取明细
            var ugID = list.Count > 0 ? string.Join(",", list.Select(_ => _.ID)) : "0";
            sql = "select *,GetEmpNameByuID(ugdUserId) as UserName from base_userGroupDetail where ugID in(" + ugID + ")";
            pList.Clear();
            List<BaseUserGroupDetailModel> ugDetail = db.ExecuteList<BaseUserGroupDetailModel>(sql, pList.ToArray());
            foreach (var item in list)
            {
                List<BaseUserGroupDetailModel> tempList = item.ugDetail.ToList();
                foreach (var dd in ugDetail)
                {
                    if (!dd.ugID.HasValue) continue;
                    if (dd.ugID.Value == item.ID)
                        tempList.Add(dd);
                }
                item.ugDetail = tempList;
            }
            return list;
        }

        /// <summary>
        /// 获取用户组信息
        /// </summary>
        /// <returns></returns>
        public List<BaseUserGroupModel> GetUserGroupList()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from base_userGroup where ugDeleteFlag=0";
            List<BaseUserGroupModel> list = db.ExecuteList<BaseUserGroupModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 根据角色分类的用户菜单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TreeviewModel> GetUserTreeView()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select CONCAT('key_',roleID) as nodeid,roleName as text from sys_role";
            List<TreeviewModel> list = db.ExecuteList<TreeviewModel>(sql, pList.ToArray());

            sql = "select CONCAT('key_',roleID) as parentID,userID as nodeid,empName as text from sys_user where deleted=0";
            List<TreeViewChild> Child = db.ExecuteList<TreeViewChild>(sql, pList.ToArray());
            foreach (var item in list)
            {
                List<TreeViewChild> tempList = item.nodes.ToList();
                foreach (var dd in Child)
                {
                    if (dd.parentID == item.nodeid)
                        tempList.Add(dd);
                }
                item.nodes = tempList.Count == 0 ? null : tempList;
            }
            return list;
        }

        /// <summary>
        /// 获取默认选中用户
        /// </summary>
        /// <param name="ID">用户组ID</param>
        /// <returns></returns>
        public List<string> DefaultChecked(int ID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ugdUserId from base_usergroupdetail where ugID=@ugID";
            pList.Add(new MySqlParameter("ugID", ID));
            List<BaseUserGroupDetailModel> list = db.ExecuteList<BaseUserGroupDetailModel>(sql, pList.ToArray());
            var userID = list.Count > 0 ? string.Join(",", list.Select(_ => _.ugdUserId)) : "0";

            sql = @"select CONCAT('key_',roleID) as nodeid from sys_user where userID in(" + userID + ")" + " group by roleID";
            pList.Clear();
            List<string> roleID = db.ExecuteList<TreeviewModel>(sql, pList.ToArray()).Select(x => x.nodeid).ToList();

            sql = @"select userID as nodeid from sys_user where userID in(" + userID + ")";
            pList.Clear();
            List<string> usersID = db.ExecuteList<TreeviewModel>(sql, pList.ToArray()).Select(x => x.nodeid).ToList();

            List<string> nodeId = usersID.Union(roleID).ToList();

            return nodeId;
        }

        /// <summary>
        /// 保存用户组名信息
        /// </summary>
        /// <param name="model">用户组名实体类</param>
        /// <returns></returns>
        public bool SaveBaseUserGroup(BaseUserGroupModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                int i = 0;
                string sql = "";
                try
                {
                    //获取服务器时间
                    var datetime = GetServerDateTime();

                    if (model.ID == 0)
                    {
                        sql = @"insert into base_usergroup(ugGroupName,ugRemark,ugDisableFlag,ugDeleteFlag,ugCreateTime,ugCreaterID,ugUpdateTime,ugUpdaterID)
                                   values(@ugGroupName,@ugRemark,@ugDisableFlag,@ugDeleteFlag,@ugCreateTime,@ugCreaterID,@ugUpdateTime,@ugUpdaterID)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ugGroupName", model.ugGroupName));
                        pList.Add(new MySqlParameter("@ugRemark", model.ugRemark));
                        pList.Add(new MySqlParameter("@ugDisableFlag", model.ugDisableFlag));
                        pList.Add(new MySqlParameter("@ugDeleteFlag", model.ugDeleteFlag ?? 0));
                        pList.Add(new MySqlParameter("@ugCreateTime", datetime));
                        pList.Add(new MySqlParameter("@ugCreaterID", model.ugCreaterID));
                        pList.Add(new MySqlParameter("@ugUpdateTime", datetime));
                        pList.Add(new MySqlParameter("@ugUpdaterID", model.ugUpdaterID));
                        i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                        //获取自增长ID
                        int ugID = 0;
                        pList.Clear();
                        sql = "select @@identity";
                        int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out ugID);
                        //添加用户组用户信息
                        foreach (var item in model.ugDetail)
                        {
                            sql = @"insert into base_usergroupdetail(ugID,ugdUserId)values(@ugID,@ugdUserId)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@ugID", ugID));
                            pList.Add(new MySqlParameter("@ugdUserId", item.ugdUserId));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    else
                    {
                        sql = @"update base_usergroup set ugGroupName=@ugGroupName,ugRemark=@ugRemark,ugDisableFlag=@ugDisableFlag,ugUpdateTime=@ugUpdateTime,
                                        ugUpdaterID=@ugUpdaterID  where ID=@ID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ugGroupName", model.ugGroupName));
                        pList.Add(new MySqlParameter("@ugRemark", model.ugRemark));
                        pList.Add(new MySqlParameter("@ugDisableFlag", model.ugDisableFlag));
                        pList.Add(new MySqlParameter("@ugUpdateTime", datetime));
                        pList.Add(new MySqlParameter("@ugUpdaterID", model.ugUpdaterID));
                        pList.Add(new MySqlParameter("@ID", model.ID));
                        i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                        //先删除原来的用户信息再添加
                        sql = "delete from base_usergroupdetail where ugID=@ugID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ugID", model.ID));
                        i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        //添加用户组用户信息
                        foreach (var item in model.ugDetail)
                        {
                            sql = @"insert into base_usergroupdetail(ugID,ugdUserId)values(@ugID,@ugdUserId)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@ugID", model.ID));
                            pList.Add(new MySqlParameter("@ugdUserId", item.ugdUserId));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    myTrans.Commit();
                }
                catch (Exception)
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return i > 0;
            }
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="id">ID</param>
        public void DelBaseUserGroup(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update base_usergroup set ugDeleteFlag=1 where ID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 消息类型-用户组关联表 WZQ

        /// <summary>
        /// 根据条件查询消息类型-用户组关联信息
        /// </summary>
        /// <param name="model">消息类型-用户组实体类</param>
        /// <returns></returns>
        public List<BaseRelMsgUserModel> GetRelMsgUserPaging(BaseRelMsgUserModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model.rmuMsgTypeId.HasValue && model.rmuMsgTypeId != 0)
            {
                para += " and rmuMsgTypeId=@rmuMsgTypeId ";
                pList.Add(new MySqlParameter("@rmuMsgTypeId", model.rmuMsgTypeId));
            }

            if (model.rmuUGroupId.HasValue && model.rmuUGroupId != 0)
            {
                para += " and rmuUGroupId=@rmuUGroupId ";
                pList.Add(new MySqlParameter("@rmuUGroupId", model.rmuUGroupId));
            }

            string sql = @"select Count(*) from base_rel_msguser where 1=1 and rmuDeleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select rmu.*,GetbdNameBybdID(rmuMsgTypeId) rmuMsgTypeName,ug.ugGroupName rmuUGroupName,
                            (case when rmuDisableFlag=0 then '启用' else '禁用' end) as DisableFlagText from base_rel_msguser rmu
                            left join base_usergroup ug
                            on rmu.rmuUGroupId=ug.ID where 1=1 and rmuDeleteFlag=0 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseRelMsgUserModel> list = db.ExecuteList<BaseRelMsgUserModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存消息类型-用户组关联信息
        /// </summary>
        /// <param name="model">消息类型-用户组关联信息实体</param>
        /// <returns></returns>
        public bool SaveBaseRelMsgUser(BaseRelMsgUserModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            int i = 0;
            string sql = "";

            //获取服务器时间
            var datetime = GetServerDateTime();

            if (model.ID == 0)
            {
                sql = @"insert into base_rel_msguser(rmuMsgTypeId,rmuUGroupId,rmuRemark,rmuDisableFlag,rmuDeleteFlag,rmuCreateTime,rmuCreaterID,rmuUpdateTime,
                                rmuUpdaterID)values(@rmuMsgTypeId,@rmuUGroupId,@rmuRemark,@rmuDisableFlag,@rmuDeleteFlag,@rmuCreateTime,@rmuCreaterID,@rmuUpdateTime,@rmuUpdaterID)";

                pList.Add(new MySqlParameter("rmuMsgTypeId", model.rmuMsgTypeId));
                pList.Add(new MySqlParameter("rmuUGroupId", model.rmuUGroupId));
                pList.Add(new MySqlParameter("rmuRemark", model.rmuRemark));
                pList.Add(new MySqlParameter("rmuDisableFlag", model.rmuDisableFlag));
                pList.Add(new MySqlParameter("rmuDeleteFlag", model.rmuDeleteFlag ?? 0));
                pList.Add(new MySqlParameter("rmuCreateTime", datetime));
                pList.Add(new MySqlParameter("rmuCreaterID", model.rmuCreaterID));
                pList.Add(new MySqlParameter("rmuUpdateTime", datetime));
                pList.Add(new MySqlParameter("rmuUpdaterID", model.rmuUpdaterID));
            }
            else
            {
                sql = @"update base_rel_msguser set rmuMsgTypeId=@rmuMsgTypeId,rmuUGroupId=@rmuUGroupId,rmuRemark=@rmuRemark,rmuDisableFlag=@rmuDisableFlag,
                                rmuUpdateTime=@rmuUpdateTime,rmuUpdaterID=@rmuUpdaterID where ID=@ID";

                pList.Add(new MySqlParameter("rmuMsgTypeId", model.rmuMsgTypeId));
                pList.Add(new MySqlParameter("rmuUGroupId", model.rmuUGroupId));
                pList.Add(new MySqlParameter("rmuRemark", model.rmuRemark));
                pList.Add(new MySqlParameter("rmuDisableFlag", model.rmuDisableFlag));
                pList.Add(new MySqlParameter("rmuUpdateTime", datetime));
                pList.Add(new MySqlParameter("rmuUpdaterID", model.rmuUpdaterID));
                pList.Add(new MySqlParameter("ID", model.ID));
            }
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }


        /// <summary>
        /// 判断消息类型-用户组关联信息是否存在
        /// </summary>
        /// <param name="MsgTypeId">消息类型ID</param>
        /// <param name="UGroupId">用户组ID</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public bool IsExistRelMsgUser(int MsgTypeId, int UGroupId, int ID = 0)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = string.Format(@"select count(*) from base_rel_msguser where rmuMsgTypeId={0} and rmuUGroupId={1}", MsgTypeId, UGroupId);
            if (ID != 0)
            {
                sql += " and ID<>@ID ";
                pList.Add(new MySqlParameter("@ID", ID));
            }
            var ret = db.ExecuteScalar(sql, pList.ToArray());
            int rowcount = 0;
            int.TryParse(ret + "", out rowcount);
            return rowcount > 0 ? true : false;
        }

        /// <summary>
        /// 删除消息类型-用户组关联信息
        /// </summary>
        /// <param name="id">ID</param>
        public void DelRelMsgUser(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update base_rel_msguser set rmuDeleteFlag=1 where ID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 消息内容通知信息 WZQ

        /// <summary>
        /// 消息内容通知
        /// </summary>
        /// <param name="model">消息内容实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseMsgContentModel> GetMsgContentPaging(BaseMsgContentModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.msResponderName) && model.msResponderID.HasValue && model.msResponderID != 0)
            {
                //等于管理员查看所有通知 
                //不等于则只能看自己相关联的通知
                if (model.msResponderName.ToLower() != "admin")
                {
                    para += " and ms.msResponderID=@msResponderID ";
                    pList.Add(new MySqlParameter("@msResponderID", model.msResponderID));
                }
            }
            if (model.mcTypeID.HasValue && model.mcTypeID != 0)
            {
                para += " and mc.mcTypeID=@mcTypeID ";
                pList.Add(new MySqlParameter("@mcTypeID", model.mcTypeID));
            }

            string sql = @"select Count(*) from base_msgcontent mc left join base_msg ms on mc.ID=ms.mcID where mc.mcDeleteFlag=0 and 1=1" + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"SELECT mc.ID,mc.mcTitle,mc.mcContent, mc.mcTypeID,
	                        GetbdNameBybdID (mc.mcTypeID) mcTypeName,
	                        mc.mcLevel,mc.mcUrl,mc.mcRemark,mc.mcCreateTime,ms.msResponderID,
	                        GetEmpNameByuID (ms.msResponderID) msResponderName,
	                        ms.msReadFlag,ms.msReadTime
                        FROM
	                        base_msgcontent mc
                        LEFT JOIN base_msg ms ON mc.ID = ms.mcID where mc.mcDeleteFlag=0 and 1=1" + para + " order by mc.mcLevel desc,mc.mcCreateTime desc";
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseMsgContentModel> list = db.ExecuteList<BaseMsgContentModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存消息内容
        /// </summary>
        /// <param name="model">消息内容实体</param>
        /// <returns></returns>
        public bool SaveBaseMsgContent(BaseMsgContentModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int i = 0;
                string sql = "";
                try
                {
                    //获取服务器时间
                    var serveTime = GetServerDateTime();

                    if (model.ID == 0)
                    {
                        sql = @"insert into base_msgcontent(mcTitle,mcContent,mcTypeID,mcLevel,mcUrl,mcRemark,mcDeleteFlag,mcCreateTime,mcCreaterID,
                                        mcUpdateTime,mcUpdaterID)values(@mcTitle,@mcContent,@mcTypeID,@mcLevel,@mcUrl,@mcRemark,@mcDeleteFlag,@mcCreateTime,@mcCreaterID,
                                        @mcUpdateTime,@mcUpdaterID)";
                        pList.Add(new MySqlParameter("@mcTitle", model.mcTitle));
                        pList.Add(new MySqlParameter("@mcContent", model.mcContent));
                        pList.Add(new MySqlParameter("@mcTypeID", model.mcTypeID));
                        pList.Add(new MySqlParameter("@mcLevel", model.mcLevel));
                        pList.Add(new MySqlParameter("@mcUrl", model.mcUrl));
                        pList.Add(new MySqlParameter("@mcRemark", model.mcRemark));
                        pList.Add(new MySqlParameter("@mcDeleteFlag", model.mcDeleteFlag ?? 0));
                        pList.Add(new MySqlParameter("@mcCreateTime", serveTime));
                        pList.Add(new MySqlParameter("@mcCreaterID", model.mcCreaterID));
                        pList.Add(new MySqlParameter("@mcUpdateTime", serveTime));
                        pList.Add(new MySqlParameter("@mcUpdaterID", model.mcUpdaterID));
                        i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                        //获取自增长ID
                        int mcID = 0;
                        pList.Clear();
                        sql = "select @@identity";
                        int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out mcID);

                        //根据消息类型查找用户组
                        sql = "select * from base_rel_msguser where rmuMsgTypeId=@rmuMsgTypeId";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@rmuMsgTypeId", model.mcTypeID));
                        var RelMsgUser = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
                        List<BaseRelMsgUserModel> rellist = db.ToList<BaseRelMsgUserModel>(RelMsgUser);
                        var uGroupID = rellist.Count > 0 ? string.Join(",", rellist.Select(x => x.rmuUGroupId)) : "0";
                        if (uGroupID == "0")
                        {
                            myTrans.Rollback();
                            return false;
                        }
                        //根据用户组查找人员
                        sql = @"select ugdUserId,GetEmpNameByuID(ugdUserId) EmpName from base_usergroupdetail where ugID in(" + uGroupID + ") GROUP BY ugdUserId";
                        pList.Clear();
                        var usTable = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
                        if (usTable.Rows.Count == 0)
                        {
                            myTrans.Rollback();
                            return false;
                        }
                        int? defaultFlag = 0;
                        foreach (DataRow item in usTable.Rows)
                        {
                            sql = "insert into base_msg(mcID,msResponderID,msReadFlag,msAutoFlag)values(@mcID,@msResponderID,@msReadFlag,@msAutoFlag)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@mcID", mcID));
                            pList.Add(new MySqlParameter("@msResponderID", item["ugdUserId"] ?? 0));
                            pList.Add(new MySqlParameter("@msReadFlag", defaultFlag));
                            pList.Add(new MySqlParameter("@msAutoFlag", defaultFlag));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    myTrans.Commit();
                }
                catch (Exception)
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return i > 0;
            }
        }

        /// <summary>
        /// 删除消息内容通知
        /// </summary>
        /// <param name="id">ID</param>
        public void DelMsgContent(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update base_msgcontent set mcDeleteFlag=1 where ID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 根据人员获取消息通知
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public List<BaseMsgContentModel> GetBaseMsgContent(int userID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT mc.ID,mc.mcTitle,mc.mcContent, mc.mcTypeID,
	                        GetbdNameBybdID (mc.mcTypeID) mcTypeName,
	                        mc.mcLevel,mc.mcUrl,mc.mcRemark,mc.mcCreateTime,ms.msResponderID,
	                        GetEmpNameByuID (ms.msResponderID) msResponderName,
	                        ms.msReadFlag,ms.msReadTime
                        FROM
	                        base_msgcontent mc
                        LEFT JOIN base_msg ms ON mc.ID = ms.mcID where mc.mcDeleteFlag=0
                        and ms.msReadFlag=0 and ms.msResponderID=@msResponderID  order by mc.mcLevel desc,mc.mcCreateTime desc";
            pList.Add(new MySqlParameter("@msResponderID", userID));
            List<BaseMsgContentModel> list = db.ExecuteList<BaseMsgContentModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 消息已读
        /// </summary>
        /// <param name="ID">消息通知ID</param>
        public void MsgContentRead(int ID, int userID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            //获取服务器时间
            var serveTime = GetServerDateTime();

            string sql = "update base_msg set msReadFlag=@msReadFlag,msReadTime=@msReadTime where mcID=@mcID and msResponderID=@msResponderID";
            pList.Add(new MySqlParameter("@msReadFlag", 1));
            pList.Add(new MySqlParameter("@msReadTime", serveTime));
            pList.Add(new MySqlParameter("@mcID", ID));
            pList.Add(new MySqlParameter("@msResponderID", userID));
            db.ExecuteNonQuery(sql, pList.ToArray());
            return;
        }

        #endregion

        #region 工具参数配方表 WZQ
        /// <summary>
        /// 工具参数配方信息
        /// </summary>
        /// <param name="model">工具参数配实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseToolforMulaModel> GetToolforMulaPaging(BaseToolforMulaModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model.tfmToolTypeID.HasValue && model.tfmToolTypeID != 0)
            {
                para += " and tfmToolTypeID=@tfmToolTypeID ";
                pList.Add(new MySqlParameter("@tfmToolTypeID", model.tfmToolTypeID));
            }

            if (!string.IsNullOrEmpty(model.tfmName))
            {
                para += " and tfmName like CONCAT('%',@tfmName,'%')";
                pList.Add(new MySqlParameter("@tfmName", model.tfmName));
            }

            string sql = @"select Count(*) from base_toolformula  where tfmDeleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select *,GetGJNameByGJID(tfmToolID) ToolName,GetbdNameBybdID(tfmToolTypeID) ToolTypeName,
                            GetbdNameBybdID(tfmTestTypeID) TestTypeName,GetbdNameBybdID(tfmTestItemID) TestItemName from base_toolformula where tfmDeleteFlag=0 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseToolforMulaModel> list = db.ExecuteList<BaseToolforMulaModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 获取所有工具配方信息
        /// </summary>
        /// <returns></returns>
        public List<BaseToolforMulaModel> GetToolForMulaAll()
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from base_toolformula where tfmDeleteFlag=0 and tfmDisableFlag=0";
            List<BaseToolforMulaModel> list = db.ExecuteList<BaseToolforMulaModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存工具参数配方信息
        /// </summary>
        /// <param name="model">工具参数配方信息实体</param>
        /// <returns></returns>
        public bool SaveBaseToolforMula(BaseToolforMulaModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            int i = 0;
            string sql = "";

            //获取服务器时间
            var datetime = GetServerDateTime();

            if (model.ID == 0)
            {
                sql = @"insert into base_toolformula(tfmToolID,tfmToolTypeID,tfmTestTypeID,tfmTestItemID,tfmCode,tfmName,tfmDisableFlag,tfmDeleteFlag,tfmCreateTime,tfmCreaterID,
                                tfmUpdateTime,tfmUpdaterID,tfmRemark)values(@tfmToolID,@tfmToolTypeID,@tfmTestTypeID,@tfmTestItemID,@tfmCode,@tfmName,@tfmDisableFlag,@tfmDeleteFlag,@tfmCreateTime,@tfmCreaterID,
                                @tfmUpdateTime,@tfmUpdaterID,@tfmRemark)";

                pList.Add(new MySqlParameter("@tfmToolID", model.tfmToolID));
                pList.Add(new MySqlParameter("@tfmToolTypeID", model.tfmToolTypeID));
                pList.Add(new MySqlParameter("@tfmTestTypeID", model.tfmTestTypeID));
                pList.Add(new MySqlParameter("@tfmTestItemID", model.tfmTestItemID));
                pList.Add(new MySqlParameter("@tfmCode", model.tfmCode));
                pList.Add(new MySqlParameter("@tfmName", model.tfmName));
                pList.Add(new MySqlParameter("@tfmDisableFlag", model.tfmDisableFlag));
                pList.Add(new MySqlParameter("@tfmDeleteFlag", model.tfmDeleteFlag ?? 0));
                pList.Add(new MySqlParameter("@tfmCreateTime", datetime));
                pList.Add(new MySqlParameter("@tfmCreaterID", model.tfmCreaterID));
                pList.Add(new MySqlParameter("@tfmUpdateTime", datetime));
                pList.Add(new MySqlParameter("@tfmUpdaterID", model.tfmUpdaterID));
                pList.Add(new MySqlParameter("@tfmRemark", model.tfmRemark));
            }
            else
            {
                sql = @"update base_toolformula set tfmToolID=@tfmToolID,tfmToolTypeID=@tfmToolTypeID,tfmTestTypeID=@tfmTestTypeID,tfmTestItemID=@tfmTestItemID,
                                tfmCode=@tfmCode,tfmName=@tfmName,tfmDisableFlag=@tfmDisableFlag,tfmUpdateTime=@tfmUpdateTime,tfmUpdaterID=@tfmUpdaterID,
                                tfmRemark=@tfmRemark where ID=@ID";

                pList.Add(new MySqlParameter("@tfmToolID", model.tfmToolID));
                pList.Add(new MySqlParameter("@tfmToolTypeID", model.tfmToolTypeID));
                pList.Add(new MySqlParameter("@tfmTestTypeID", model.tfmTestTypeID));
                pList.Add(new MySqlParameter("@tfmTestItemID", model.tfmTestItemID));
                pList.Add(new MySqlParameter("@tfmCode", model.tfmCode));
                pList.Add(new MySqlParameter("@tfmName", model.tfmName));
                pList.Add(new MySqlParameter("@tfmDisableFlag", model.tfmDisableFlag));
                pList.Add(new MySqlParameter("@tfmUpdateTime", datetime));
                pList.Add(new MySqlParameter("@tfmUpdaterID", model.tfmCreaterID));
                pList.Add(new MySqlParameter("@tfmRemark", model.tfmRemark));
                pList.Add(new MySqlParameter("@ID", model.ID));
            }
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }

        /// <summary>
        /// 删除工具参数配方信息
        /// </summary>
        /// <param name="id">ID</param>
        public void DelBaseToolforMula(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update base_toolformula set tfmDeleteFlag=1 where ID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 工具参数配方明细表 WZQ
        /// <summary>
        /// 工具参数配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseToolforMulaDetailModel> GetToolforMulaDetailPaging(BaseToolforMulaDetailModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model.tfmID != 0)
            {
                para += " and tfmID=@tfmID";
                pList.Add(new MySqlParameter("@tfmID", model.tfmID));
            }

            if (model.tfmdItemType.HasValue && model.tfmdItemType != 0)
            {
                para += " and tfmdItemType=@tfmdItemType ";
                pList.Add(new MySqlParameter("@tfmdItemType", model.tfmdItemType));
            }

            if (!string.IsNullOrEmpty(model.tfmdName))
            {
                para += " and tfmdName like CONCAT('%',@tfmdName,'%')";
                pList.Add(new MySqlParameter("@tfmdName", model.tfmdName));
            }

            string sql = @"select Count(*) from base_toolformula_detail  where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select *,GetbdNameBybdID(tfmdItemType) ItemTypeName from base_toolformula_detail where 1=1  " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseToolforMulaDetailModel> list = db.ExecuteList<BaseToolforMulaDetailModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 获取所有工具配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细实体</param>
        /// <returns></returns>
        public List<BaseToolforMulaDetailModel> GetToolForMulaDetailAll(BaseToolforMulaDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model.ID != 0)
            {
                para += " and tfm.ID=@ID ";
                pList.Add(new MySqlParameter("@ID", model.ID));
            }
            string sql = @"select GetbdNameBybdID(tfm.tfmTestTypeID) TestTypeName,GetbdNameBybdID(tfm.tfmTestItemID) TestItemName,
                                   tfmd.*,GetbdNameBybdID(tfmd.tfmdItemType) ItemTypeName 
                                   from base_toolformula  tfm
                                   left join base_toolformula_detail tfmd 
                                   on tfmd.tfmID=tfm.ID where 1=1 " + para;
            List<BaseToolforMulaDetailModel> list = db.ExecuteList<BaseToolforMulaDetailModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存工具参数配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细信息实体</param>
        /// <returns></returns>
        public bool SaveBaseToolforMulaDetail(BaseToolforMulaDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            int i = 0;
            string sql = "";

            if (model.ID == 0)
            {
                sql = @"insert into base_toolformula_detail(tfmID,tfmdItemType,tfmdName,tfmdItemValue,tfmdMinValue,tfmdMaxValue,tfmdRemark)
                                values(@tfmID,@tfmdItemType,@tfmdName,@tfmdItemValue,@tfmdMinValue,@tfmdMaxValue,@tfmdRemark)";

                pList.Add(new MySqlParameter("@tfmID", model.tfmID));
                pList.Add(new MySqlParameter("@tfmdItemType", model.tfmdItemType));
                pList.Add(new MySqlParameter("@tfmdName", model.tfmdName));
                pList.Add(new MySqlParameter("@tfmdItemValue", model.tfmdItemValue));
                pList.Add(new MySqlParameter("@tfmdMinValue", model.tfmdMinValue));
                pList.Add(new MySqlParameter("@tfmdMaxValue", model.tfmdMaxValue));
                pList.Add(new MySqlParameter("@tfmdRemark", model.tfmdRemark));
            }
            else
            {
                sql = @"update base_toolformula_detail set tfmdItemType=@tfmdItemType,tfmdName=@tfmdName,tfmdItemValue=@tfmdItemValue,tfmdMinValue=@tfmdMinValue,
                                tfmdMaxValue=@tfmdMaxValue,tfmdRemark=@tfmdRemark  where ID=@ID";

                pList.Add(new MySqlParameter("@tfmdItemType", model.tfmdItemType));
                pList.Add(new MySqlParameter("@tfmdName", model.tfmdName));
                pList.Add(new MySqlParameter("@tfmdItemValue", model.tfmdItemValue));
                pList.Add(new MySqlParameter("@tfmdMinValue", model.tfmdMinValue));
                pList.Add(new MySqlParameter("@tfmdMaxValue", model.tfmdMaxValue));
                pList.Add(new MySqlParameter("@tfmdRemark", model.tfmdRemark));
                pList.Add(new MySqlParameter("@ID", model.ID));
            }
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }

        /// <summary>
        /// 删除工具参数配方明细信息
        /// </summary>
        /// <param name="id">ID</param>
        public void DelBaseToolforMulaDetail(string id)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from  base_toolformula_detail where ID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 探伤检测 WZQ

        /// <summary>
        /// 保存探伤检测
        /// </summary>
        /// <param name="model">探伤检测实体</param>
        /// <returns></returns>
        public bool SaveFlawDetectionResult(LogFlawDetectionModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            if (model.lfdID == 0)
            {
                sql = @"insert into log_flawdetection(lfdProdNoSys,lfdPartCode,lfdBarCode,lfdImgPath,lfduploadTime,lfdImgOne,lfdImgTwo,lfdStatus,lfdRemark)
                                   values(@lfdProdNoSys,@lfdPartCode,@lfdBarCode,@lfdImgPath,now(),@lfdImgOne,@lfdImgTwo,@lfdStatus,@lfdRemark)";
                pList.Add(new MySqlParameter("@lfdProdNoSys", model.lfdProdNoSys));
                pList.Add(new MySqlParameter("@lfdPartCode", model.lfdPartCode));
                pList.Add(new MySqlParameter("@lfdBarCode", model.lfdBarCode));
                pList.Add(new MySqlParameter("@lfdImgPath", model.lfdImgPath));
                pList.Add(new MySqlParameter("@lfdImgOne", model.lfdImgOne));
                pList.Add(new MySqlParameter("@lfdImgTwo", model.lfdImgTwo));
                pList.Add(new MySqlParameter("@lfdStatus", model.lfdStatus));
                pList.Add(new MySqlParameter("@lfdRemark", model.lfdRemark));
            }
            else
            {
                sql = @"update log_flawdetection set lfdResult=@lfdResult,lfdResultTime=now(),lfdStatus=1 where lfdID=@lfdID and lfdStatus=0 ";
                pList.Add(new MySqlParameter("@lfdResult", model.lfdResult));
                pList.Add(new MySqlParameter("@lfdID", model.lfdID));
            }
            return db.ExecuteNonQuery(sql, pList.ToArray()) > 0;
        }

        /// <summary>
        /// 获取探伤检验数据
        /// </summary>
        /// <param name="model">探伤检验实体</param>
        /// <returns></returns>
        public List<LogFlawDetectionModel> GetFlawDetectionList(LogFlawDetectionModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.lfdProdNoSys))
                {
                    para += " and lfdProdNoSys=@lfdProdNoSys";
                    pList.Add(new MySqlParameter("@lfdProdNoSys", model.lfdProdNoSys));
                }
                if (!string.IsNullOrEmpty(model.lfdPartCode))
                {
                    para += " and lfdPartCode=@lfdPartCode";
                    pList.Add(new MySqlParameter("@lfdPartCode", model.lfdPartCode));
                }
                if (model.lfdStatus.HasValue)
                {
                    para += " and lfdStatus=@lfdStatus";
                    pList.Add(new MySqlParameter("@lfdStatus", model.lfdStatus));
                }
            }
            string sql = @"select * from log_flawdetection where 1=1 " + para;
            var list = db.ExecuteList<LogFlawDetectionModel>(sql, pList.ToArray());
            return list;
        }


        #endregion

        #region 计划工序维护 LHR 2020-03-06


        /// <summary>
        /// 计划工序维护分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Base_PartGongxuModel> GetPartGongxu(Base_PartGongxuModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model.prodModelID.HasValue && model.prodModelID.Value != 0)
            {
                para += " and prodModelID = @prodModelID ";
                pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            }
            if (!string.IsNullOrEmpty(model.LIKEoperationName))
            {
                para += "and operationName like concat('%',@LIKEoperationName,'%') ";
                pList.Add(new MySqlParameter("@LIKEoperationName", model.LIKEoperationName));
            }
            string sql = @"select Count(*) from base_partGongxu pgx
                                    left join base_productmodel pd on pgx.prodModelID = pd.ID
                                    where 1=1 and pgx.deleteFlag = 0  " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select pgx.*,pd.Pmodel,pd.DrawingNo,pd.PID,GetbdNameBybdID(pgx.entrustType) as entrustTypeText from base_partGongxu pgx
                                    left join base_productmodel pd on pgx.prodModelID = pd.ID
                                    where 1=1 and pgx.deleteFlag = 0 " + para;
            para += " order by CONVERT(pgx.operationNo,SIGNED),pgx.prodModelID asc ";
            //CAST(pgx.operationNo as SIGNED) 解决Mysql数据库varchar排序数值问题
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<Base_PartGongxuModel> list = db.ExecuteList<Base_PartGongxuModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 计划工序维护查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Base_PartGongxuModel> GetPartGongxu(Base_PartGongxuModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model.prodModelID.HasValue && model.prodModelID.Value != 0)
            {
                para += " and prodModelID = @prodModelID ";
                pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            }
            if (!string.IsNullOrEmpty(model.LIKEoperationName))
            {
                para += "and operationName like concat('%',@LIKEoperationName,'%') ";
                pList.Add(new MySqlParameter("@LIKEoperationName", model.LIKEoperationName));
            }
            if (model.UNID.HasValue && model.UNID > 0)
            {
                para += " and pgx.ID <> @UNID ";
                pList.Add(new MySqlParameter("@UNID", model.UNID));
            }
            if (!string.IsNullOrEmpty(model.operationName))
            {
                para += " and pgx.operationName = @operationName ";
                pList.Add(new MySqlParameter("@operationName", model.operationName));
            }
            if (!string.IsNullOrEmpty(model.operationCode))
            {
                para += " and pgx.operationCode = @operationCode ";
                pList.Add(new MySqlParameter("@operationCode", model.operationCode));
            }

            string sql = @"select pgx.*,pd.Pmodel,pd.DrawingNo,pd.PID,GetbdNameBybdID(pgx.entrustType) as entrustTypeText from base_partGongxu pgx
                                    left join base_productmodel pd on pgx.prodModelID = pd.ID
                                    where 1=1 and pgx.deleteFlag = 0 " + para;
            return db.ExecuteList<Base_PartGongxuModel>(sql, pList.ToArray());
        }



        /// <summary>
        /// 添加 工序维护
        /// </summary>
        /// <param name="model"></param>
        public void AddPartGongxu(Base_PartGongxuModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into base_partGongxu(prodModelID,entrustType,workCenterCode,workCenterName,operationNo,operationName,operationCode,isCheckPoint,isReportPoint,
                           isPickingPoint,entrustSupplierCode,taiweiCode,opertionAlias,proInstruction,status,remark,deleteFlag,createTime,createMan,updateTime,updateMan) 
                           values(@prodModelID,@entrustType,@workCenterCode,@workCenterName,@operationNo,@operationName,@operationCode,@isCheckPoint,@isReportPoint,
                           @isPickingPoint,@entrustSupplierCode,@taiweiCode,@opertionAlias,@proInstruction,@status,@remark,@deleteFlag,@createTime,@createMan,updateTime,updateMan)";
            pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            pList.Add(new MySqlParameter("@entrustType", model.entrustType));
            pList.Add(new MySqlParameter("@workCenterCode", model.workCenterCode));
            pList.Add(new MySqlParameter("@workCenterName", model.workCenterName));
            pList.Add(new MySqlParameter("@operationNo", model.operationNo));
            pList.Add(new MySqlParameter("@operationName", model.operationName));
            pList.Add(new MySqlParameter("@operationCode", model.operationCode));
            pList.Add(new MySqlParameter("@isCheckPoint", model.isCheckPoint));
            pList.Add(new MySqlParameter("@isReportPoint", model.isReportPoint));
            pList.Add(new MySqlParameter("@isPickingPoint", model.isPickingPoint));
            pList.Add(new MySqlParameter("@entrustSupplierCode", model.entrustSupplierCode));
            pList.Add(new MySqlParameter("@taiweiCode", model.taiweiCode));
            pList.Add(new MySqlParameter("@opertionAlias", model.opertionAlias));
            pList.Add(new MySqlParameter("@proInstruction", model.proInstruction));
            pList.Add(new MySqlParameter("@status", model.status));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@deleteFlag", model.deleteFlag));
            pList.Add(new MySqlParameter("@createTime", model.createTime));
            pList.Add(new MySqlParameter("@createMan", model.createMan));
            pList.Add(new MySqlParameter("@updateTime", model.updateTime));
            pList.Add(new MySqlParameter("@updateMan", model.updateMan));
            db.ExecuteNonQuery(sql, pList.ToArray());
            return;
        }

        /// <summary>
        /// 修改 工序维护
        /// </summary>
        /// <param name="model"></param>
        public void EditPartGongxu(Base_PartGongxuModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"UPDATE base_partGongxu SET prodModelID=@prodModelID,entrustType=@entrustType,workCenterCode=@workCenterCode,workCenterName=@workCenterName,operationNo=@operationNo,
                            operationName=@operationName,operationCode=@operationCode,isCheckPoint=@isCheckPoint,isReportPoint=@isReportPoint,isPickingPoint=@isPickingPoint,
                            entrustSupplierCode=@entrustSupplierCode,taiweiCode=@taiweiCode,opertionAlias=@opertionAlias,proInstruction=@proInstruction,status=@status,
                            remark=@remark,deleteFlag=@deleteFlag,updateTime=@updateTime,updateMan=@updateMan WHERE ID=@ID";
            pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            pList.Add(new MySqlParameter("@entrustType", model.entrustType));
            pList.Add(new MySqlParameter("@workCenterCode", model.workCenterCode));
            pList.Add(new MySqlParameter("@workCenterName", model.workCenterName));
            pList.Add(new MySqlParameter("@operationNo", model.operationNo));
            pList.Add(new MySqlParameter("@operationName", model.operationName));
            pList.Add(new MySqlParameter("@operationCode", model.operationCode));
            pList.Add(new MySqlParameter("@isCheckPoint", model.isCheckPoint));
            pList.Add(new MySqlParameter("@isReportPoint", model.isReportPoint));
            pList.Add(new MySqlParameter("@isPickingPoint", model.isPickingPoint));
            pList.Add(new MySqlParameter("@entrustSupplierCode", model.entrustSupplierCode));
            pList.Add(new MySqlParameter("@taiweiCode", model.taiweiCode));
            pList.Add(new MySqlParameter("@opertionAlias", model.opertionAlias));
            pList.Add(new MySqlParameter("@proInstruction", model.proInstruction));
            pList.Add(new MySqlParameter("@status", model.status));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@deleteFlag", model.deleteFlag));
            pList.Add(new MySqlParameter("@updateTime", model.updateTime));
            pList.Add(new MySqlParameter("@updateMan", model.updateMan));
            pList.Add(new MySqlParameter("@ID", model.ID));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 逻辑删除 工序维护
        /// </summary>
        /// <param name="id"></param>
        public void DelPartGongxu(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update base_partGongxu set deleteFlag=1 where ID in(" + id + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 获取 产品型号-图号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetProductDrawingNoModel()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select a.ID,CONCAT_WS('-',b.Pname,a.Pmodel) as Pmodel,a.PID,
                                    CONCAT_WS('-',a.Pmodel,a.DrawingNo) as PmodelDrawingNo,a.DrawingNo
                                    from base_productModel a
                                    left join base_product b on a.PID = b.ID where a.Pstatus =0 ";
            return db.ExecuteList<BaseProductModelModel>(sql, pList.ToArray());
        }


        /// <summary>
        /// 根据产品型号 查询当前产品型号下所有 工序名称
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Base_PartGongxuModel> GetPartGongxu(int PID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            para += "and prodModelID = @PID ";
            pList.Add(new MySqlParameter("@PID", PID));
            string sql = @"select ID,operationCode,operationName,operationNo from base_partGongxu where deleteFlag = 0 and status = 0 " + para;
            List<Base_PartGongxuModel> list = db.ExecuteList<Base_PartGongxuModel>(sql, pList.ToArray());
            return list;
        }


        #endregion

        #region 备料申请主表 LHR 2020-03-18

        /// <summary>
        /// 查询备料申请单记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PmsRequisitionMainModel> GetPmsRequisitionMainList(PmsRequisitionMainModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.LIKEpm_orderCode))
            {
                para += " and prm.pm_orderCode like CONCAT('%',@LIKEpm_orderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpm_orderCode", model.LIKEpm_orderCode.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEpp_orderCode))
            {
                para += " and prm.pp_orderCode like CONCAT('%',@LIKEpp_orderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpp_orderCode", model.LIKEpp_orderCode.Trim()));
            }

            if (model.pm_status.HasValue && model.pm_status != -1)
            {
                para += " and prm.pm_status =@pm_status ";
                pList.Add(new MySqlParameter("@pm_status", model.pm_status));
            }

            if (!string.IsNullOrEmpty(model.pm_orderCode))
            {
                para += " and prm.pm_orderCode =@pm_orderCode ";
                pList.Add(new MySqlParameter("@pm_orderCode", model.pm_orderCode));
            }

            string sql = @"select *,GetEmpNameByuID(prm.pm_applierID) pm_applierText,GetEmpNameByuID(prm.pm_rejectID) pm_rejectText,
                            CONCAT_WS('-',pm.Pmodel,pm.DrawingNo) as PmodelDrawingNo from pms_requisitionmain prm
                            left join part_plan pp on prm.pp_orderCode = pp.pp_orderCode
                            left join productinfo pf on prm.pf_ID = pf.pf_ID
                            left join base_productmodel pm on pp.pp_prodModelID = pm.ID where 1=1 " + para;
            List<PmsRequisitionMainModel> list = db.ExecuteList<PmsRequisitionMainModel>(sql, pList.ToArray());
            return list;
        }



        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="mainModel">pms_requisitionmain 主表 状态 0.未备料 1.已备料 2.已确认 3.已驳回</param>
        /// <param name="detailModel">pms_requisitiondetail 子表 状态 0.未备料 1.已备料 2.已确认 3.已驳回 4.少料 5.缺料</param>
        /// <param name="pp_status">计划状态 0：未开始；1：已下发任务；2：已开始任务；3：已完成 4：已驳回</param>
        /// <returns></returns>
        public int Reject(List<PmsRequisitionMainModel> mainModel, List<PmsRequisitionDetailModel> detailModel, int pp_status)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                List<MySqlParameter> pList = new List<MySqlParameter>();
                string sql = "";
                int ret = 0;

                try
                {

                    foreach (PmsRequisitionDetailModel detailModelitem in detailModel)
                    {
                        //修改备料从表 状态驳回
                        sql = @"Update pms_requisitiondetail set pd_status=@pd_status,pd_updateTime=@pd_updateTime,pd_updateMan=@pd_updateMan where pm_orderCode=@pm_orderCode";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pd_status", detailModelitem.pd_status));
                        pList.Add(new MySqlParameter("@pd_updateTime", detailModelitem.pd_updateTime));
                        pList.Add(new MySqlParameter("@pd_updateMan", detailModelitem.pd_updateMan));
                        pList.Add(new MySqlParameter("@pm_orderCode", detailModelitem.pm_orderCode));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }


                    foreach (PmsRequisitionMainModel mainModelitem in mainModel)
                    {
                        //修改备料主表 状态驳回并填入驳回原因
                        sql = @"Update pms_requisitionmain set pm_rejectID=@pm_rejectID,pm_rejectDate=@pm_rejectDate,pm_rejectMemo=@pm_rejectMemo,pm_status=@pm_status,pm_updateTime=@pm_updateTime,
                            pm_updateMan=@pm_updateMan where pm_orderCode=@pm_orderCode";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pm_rejectID", mainModelitem.pm_rejectID));
                        pList.Add(new MySqlParameter("@pm_rejectDate", mainModelitem.pm_rejectDate));
                        pList.Add(new MySqlParameter("@pm_rejectMemo", mainModelitem.pm_rejectMemo));
                        pList.Add(new MySqlParameter("@pm_status", mainModelitem.pm_status));
                        pList.Add(new MySqlParameter("@pm_updateTime", mainModelitem.pm_updateTime));
                        pList.Add(new MySqlParameter("@pm_updateMan", mainModelitem.pm_updateMan));
                        pList.Add(new MySqlParameter("@pm_orderCode", mainModelitem.pm_orderCode));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }


                    sql = @"Update Part_Plan set pp_status=@pp_status,pp_updateTime=@pp_updateTime,pp_updateMan=@pp_updateMan where pp_orderCode=@pp_orderCode";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pp_status", pp_status));
                    pList.Add(new MySqlParameter("@pp_updateTime", mainModel[0].pm_updateTime));
                    pList.Add(new MySqlParameter("@pp_updateMan", mainModel[0].pm_updateMan));
                    pList.Add(new MySqlParameter("@pp_orderCode", mainModel[0].pp_orderCode));
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }

            }
        }




        #endregion

        #region 备料申请从表 LHR 2020-03-18

        /// <summary>
        /// 根据备料申请单据编码 查询备料明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PmsRequisitionDetailModel> GetPmsRequisitionDetailList(PmsRequisitionDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.pm_orderCode))
            {
                para += " and prd.pm_orderCode =@pm_orderCode ";
                pList.Add(new MySqlParameter("@pm_orderCode", model.pm_orderCode.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEpd_materialCode))
            {
                para += " and prd.pd_materialCode like CONCAT('%',@LIKEpd_materialCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpd_materialCode", model.LIKEpd_materialCode.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEpd_materialName))
            {
                para += " and prd.pd_materialName like CONCAT('%',@LIKEpd_materialName,'%') ";
                pList.Add(new MySqlParameter("@LIKEpd_materialName", model.LIKEpd_materialName.Trim()));
            }

            if (!string.IsNullOrEmpty(model.paraStr))
            {
                para += " and prd.pd_status in (" + model.paraStr + ") ";
            }

            string sql = @"select * from pms_requisitiondetail prd
                           left join pms_requisitionmain prm on prd.pm_orderCode = prm.pm_orderCode 
                           where 1=1 " + para;
            List<PmsRequisitionDetailModel> list = db.ExecuteList<PmsRequisitionDetailModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 通过产品编号获取备料申请物料明细
        /// </summary>
        /// <param name="prodNo"></param>
        /// <returns></returns>
        public List<PmsRequisitionDetailModel> GetPmsRequisitionDetailList(string prodNo)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(prodNo))
            {
                pList.Add(new MySqlParameter("@prodNo", prodNo.Trim()));
            }

            string sql = @"SELECT * FROM pms_requisitiondetail req
                           INNER JOIN  pms_requisitionmain prm ON req.pm_orderCode = prm.pm_orderCode 
						   INNER JOIN  productinfo prod ON prm.pf_ID=prod.pf_ID
                           WHERE req.pd_status<>0 AND req.pd_status<>3 AND prod.pf_prodNo = @prodNo ";

            var list = db.ExecuteList<PmsRequisitionDetailModel>(sql, pList.ToArray());

            return list;
        }


        /// <summary>
        /// 根据计划单据编码查询 配件计划备料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                para += " and ps.pp_orderCode = @pp_orderCode ";
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode.Trim()));
            }

            if (model.ps_operationID.HasValue && model.ps_operationID != 0)
            {
                para += " and ps.ps_operationID = @ps_operationID ";
                pList.Add(new MySqlParameter("@ps_operationID", model.ps_operationID));
            }

            string sql = @"select ps.*,GetIssueModeBybdvalue(ps.ps_issueMode) as issueModeText,GetProvideTypeBybdvalue(ps.ps_provideType) provideTypeText  from part_planstock ps
                    left join part_plan pp on ps.pp_orderCode = pp.pp_orderCode
					left join base_ebom ebom on ps.ps_materialID = ebom.ebParentID
                    where ps.ps_deleteFlag=0 " + para;
            List<PartPlanStockModel> list = db.ExecuteList<PartPlanStockModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 通用修改备料申请单状态
        /// </summary>
        /// <param name="model">pms_requisitiondetail 子表明细</param>
        /// <param name="pm_status">pms_requisitionmain 主表状态</param>
        /// <returns></returns>
        public int SavePmsRequisitionDetail(List<PmsRequisitionDetailModel> model, int pm_status)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                List<MySqlParameter> pList = new List<MySqlParameter>();
                string sql = "";
                int ret = 0;

                try
                {
                    sql = @"Update pms_requisitionmain set pm_status=@pm_status,pm_updateTime=@pm_updateTime,pm_updateMan=@pm_updateMan where pm_orderCode=@pm_orderCode";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pm_status", pm_status));
                    pList.Add(new MySqlParameter("@pm_updateTime", DateTime.Now));
                    pList.Add(new MySqlParameter("@pm_updateMan", model[0].pd_updateMan));
                    pList.Add(new MySqlParameter("@pm_orderCode", model[0].pm_orderCode));
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());


                    //循环修改备料从表 修改状态
                    for (int i = 0; i < model.Count; i++)
                    {
                        sql = @"Update pms_requisitiondetail set pd_status=@pd_status,pd_remark=@pd_remark,pd_updateTime=@pd_updateTime,pd_updateMan=@pd_updateMan where pd_orderCode=@pd_orderCode";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pd_status", model[i].pd_status));
                        pList.Add(new MySqlParameter("@pd_remark", model[i].pd_remark));
                        pList.Add(new MySqlParameter("@pd_orderCode", model[i].pd_orderCode));
                        pList.Add(new MySqlParameter("@pd_updateTime", DateTime.Now));
                        pList.Add(new MySqlParameter("@pd_updateMan", model[i].pd_updateMan));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }
                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }

            }
        }


        /// <summary>
        /// 绑定产品编码
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RequisitionMainmodel"></param>
        /// <returns></returns>
        public int SaveBindProdNo(ProductInfoModel model, PmsRequisitionMainModel RequisitionMainmodel)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                string sql = "";
                int ret = 0;
                //产品信息表返回主键
                int identity = 0;
                DAL_ProductInfo DAL = new DAL_ProductInfo();
                DAL.AddProductInfo(model, myTrans, out identity);

                try
                {
                    //pm_status=@pm_status,pm_deleteFlag=@pm_deleteFlag,
                    sql = @"Update pms_requisitionmain set pf_ID=@pf_ID,pm_applierID=@pm_applierID,pm_applyDate=@pm_applyDate,pm_rejectID=@pm_rejectID,pm_rejectDate=@pm_rejectDate,pm_rejectType=@pm_rejectType,
                            pm_rejectMemo=@pm_rejectMemo,pm_createTime=@pm_createTime,pm_createMan=@pm_createMan,pm_updateTime=@pm_updateTime,pm_updateMan=@pm_updateTime where pm_orderCode=@pm_orderCode";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pf_ID", identity));
                    pList.Add(new MySqlParameter("@pm_applierID", RequisitionMainmodel.pm_applierID));
                    pList.Add(new MySqlParameter("@pm_applyDate", RequisitionMainmodel.pm_applyDate));
                    pList.Add(new MySqlParameter("@pm_rejectID", RequisitionMainmodel.pm_rejectID));
                    pList.Add(new MySqlParameter("@pm_rejectDate", RequisitionMainmodel.pm_rejectDate));
                    pList.Add(new MySqlParameter("@pm_rejectType", RequisitionMainmodel.pm_rejectType));
                    pList.Add(new MySqlParameter("@pm_rejectMemo", RequisitionMainmodel.pm_rejectMemo));
                    pList.Add(new MySqlParameter("@pm_createTime", RequisitionMainmodel.pm_createTime));
                    pList.Add(new MySqlParameter("@pm_createMan", RequisitionMainmodel.pm_createMan));
                    pList.Add(new MySqlParameter("@pm_updateTime", RequisitionMainmodel.pm_updateTime));
                    pList.Add(new MySqlParameter("@pm_updateMan", RequisitionMainmodel.pm_updateMan));
                    pList.Add(new MySqlParameter("@pm_orderCode", RequisitionMainmodel.pm_orderCode));
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }


        #endregion

        #region 物料条码卡管理 LHR 2020-05-07

        /// <summary>
        /// 物料条码卡管理分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseMaterialBarCodeModel> GetMaterialBarCodePage(BaseMaterialBarCodeModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model.m_prodID.HasValue && model.m_prodID != 0)
            {
                para += " and bmb.m_prodID=@m_prodID ";
                pList.Add(new MySqlParameter("@m_prodID", model.m_prodID));
            }

            if (model.m_MaterialID.HasValue && model.m_MaterialID != 0)
            {
                para += " and bmb.m_MaterialID=@m_MaterialID ";
                pList.Add(new MySqlParameter("@m_MaterialID", model.m_MaterialID));
            }

            if (!string.IsNullOrEmpty(model.m_MaterialText))
            {
                para += " and m.mName like CONCAT('%',@m_MaterialText,'%') ";
                pList.Add(new MySqlParameter("@m_MaterialText", model.m_MaterialText.Trim()));
            }

            if (!string.IsNullOrEmpty(model.mDrawingNo))
            {
                para += " and m.mDrawingNo like CONCAT('%',@mDrawingNo,'%') ";
                pList.Add(new MySqlParameter("@mDrawingNo", model.mDrawingNo.Trim()));
            }

            if (!string.IsNullOrEmpty(model.m_cardNo))
            {
                para += " and bmb.m_cardNo like CONCAT('%',@m_cardNo,'%') ";
                pList.Add(new MySqlParameter("@m_cardNo", model.m_cardNo.Trim()));
            }

            if (model.m_status.HasValue)
            {
                para += " and bmb.m_status=@m_status ";
                pList.Add(new MySqlParameter("@m_status", model.m_status));
            }

            string sql = @"select Count(*) from base_MaterialBarCode bmb
                           left join base_material m on  m.ID = bmb.m_MaterialID
                           left join base_supplier su on su.ID = bmb.m_supplierID
                           left join v_productmodel v on v.ID = bmb.m_prodID
                           where  1=1 and m_deleteFlag=0 " + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select bmb.*,CONCAT_WS('-',v.Pmodel,v.DrawingNo) prodName,m.mName as m_MaterialText,su.suName as m_supplierText,CONCAT_WS(' - ',m.mName,m.mDrawingNo) as mNameDrawingNo 
                    from base_MaterialBarCode bmb
                    left join base_material m on  m.ID = bmb.m_MaterialID
                    left join base_supplier su on su.ID = bmb.m_supplierID
					left join v_productmodel v on v.ID = bmb.m_prodID
                    where  1=1 and m_deleteFlag=0  " + para;
            //sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            sql += " limit " + model.PageIndex + "," + model.PageSize;
            List<BaseMaterialBarCodeModel> list = db.ExecuteList<BaseMaterialBarCodeModel>(sql, pList.ToArray());

            return list;

        }


        /// <summary>
        /// 用于条码生成器 获取下拉列表值
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialBarCodeModel> GetMaterialBarCode()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            string sql = @"select mb.ID,CONCAT_WS(';',m.mName,m.mDrawingNo,m_specificationmodels) as barcode from base_materialbarcode mb
                    left join base_material m on mb.m_MaterialID = m.ID
                    where  1=1 and m_deleteFlag=0 " + para;
            List<BaseMaterialBarCodeModel> list = db.ExecuteList<BaseMaterialBarCodeModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 获取条码卡信息
        /// </summary>
        /// <returns></returns>
        public BaseMaterialBarCodeModel GetMaterialBarCodeByModel(BaseMaterialBarCodeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model.ID != 0)
            {
                para += " and mb.ID = @ID";
                pList.Add(new MySqlParameter("@ID", model.ID));
            }
            if (!string.IsNullOrEmpty(model.mDrawingNo))
            {
                para += " and m.mDrawingNo = @mDrawingNo";
                pList.Add(new MySqlParameter("@mDrawingNo", model.mDrawingNo));
            }
            if (!string.IsNullOrEmpty(model.m_specificationmodels))
            {
                para += " and mb.m_specificationmodels = @m_specificationmodels";
                pList.Add(new MySqlParameter("@m_specificationmodels", model.m_specificationmodels));
            }
            string sql = @"select mb.*,m.mName as m_MaterialText,su.suName as m_supplierText,m.mDrawingNo  from base_materialbarcode mb
                    left join base_material m on mb.m_MaterialID = m.ID
					left join base_supplier su on su.ID = mb.m_supplierID
                    where  1=1 and m_deleteFlag=0" + para;
            List<BaseMaterialBarCodeModel> list = db.ExecuteList<BaseMaterialBarCodeModel>(sql, pList.ToArray());
            return list.Count > 0 ? list[0] : null;
        }


        /// <summary>
        /// 判断条码卡和物料ID是否存在
        /// </summary>
        /// <param name="UNID"></param>
        /// <param name="m_cardNo"></param>
        /// <param name="m_MaterialID"></param>
        /// <returns></returns>
        public bool IsExistMaterialBarCode(int UNID, string m_cardNo, int m_MaterialID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            //if (!string.IsNullOrEmpty(m_cardNo))
            //{
            //    para += " and m_cardNo=@m_cardNo ";
            //    pList.Add(new MySqlParameter("@m_cardNo", m_cardNo));
            //}
            //if (m_MaterialID != 0)
            //{
            //    para += " and m_MaterialID=@m_MaterialID ";
            //    pList.Add(new MySqlParameter("@m_MaterialID", m_MaterialID));
            //}
            //去重应该 排除当前ID
            if (UNID != 0)
            {
                para += " and ID <> @UNID ";
                pList.Add(new MySqlParameter("@UNID", UNID));
            }
            string sql = @"select count(*) from base_MaterialBarCode 
            where 1=1 and m_deleteFlag=0 and (m_cardNo='" + m_cardNo + "' or m_MaterialID=" + m_MaterialID + ") " + para;
            var obj = db.ExecuteScalar(sql, pList.ToArray());
            var count = 0;
            int.TryParse(obj + "", out count);
            if (count >= 1)
                return true;
            else
                return false;
        }



        /// <summary>
        /// 添加/修改物料条码卡管理信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveMaterialBarCode(BaseMaterialBarCodeModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    //DateTime serverTime = GetServerDateTime();

                    if (model.ID == 0)
                    {
                        #region 新增

                        sql = @"INSERT INTO base_MaterialBarCode(m_prodID,m_cardType,m_code,m_batchNo,m_MaterialID,m_supplierID,m_status,m_remark,m_deleteFlag,m_specificationmodels,m_manufacturer) 
                                Values(@m_prodID,@m_cardType,@m_code,@m_batchNo,@m_MaterialID,@m_supplierID,@m_status,@m_remark,@m_deleteFlag,@m_specificationmodels,@m_manufacturer) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@m_prodID", model.m_prodID));
                        //pList.Add(new MySqlParameter("@m_cardNo", model.m_cardNo));
                        pList.Add(new MySqlParameter("@m_cardType", model.m_cardType));
                        pList.Add(new MySqlParameter("@m_code", model.m_code));
                        pList.Add(new MySqlParameter("@m_batchNo", model.m_batchNo));
                        pList.Add(new MySqlParameter("@m_MaterialID", model.m_MaterialID));
                        pList.Add(new MySqlParameter("@m_supplierID", model.m_supplierID));
                        pList.Add(new MySqlParameter("@m_status", model.m_status));
                        pList.Add(new MySqlParameter("@m_remark", model.m_remark));
                        pList.Add(new MySqlParameter("@m_deleteFlag", model.m_deleteFlag));
                        pList.Add(new MySqlParameter("@m_specificationmodels", model.m_specificationmodels));
                        pList.Add(new MySqlParameter("@m_manufacturer", model.m_manufacturer));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 编辑
                        sql = @"update base_MaterialBarCode set m_prodID=@m_prodID,m_cardType=@m_cardType,m_code=@m_code,m_batchNo=@m_batchNo,m_MaterialID=@m_MaterialID,
                                m_supplierID=@m_supplierID,m_status=@m_status,m_remark=@m_remark,m_deleteFlag=@m_deleteFlag,m_specificationmodels=@m_specificationmodels,m_manufacturer=@m_manufacturer where ID=@ID ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@m_prodID", model.m_prodID));
                        //pList.Add(new MySqlParameter("@m_cardNo", model.m_cardNo));
                        pList.Add(new MySqlParameter("@m_cardType", model.m_cardType));
                        pList.Add(new MySqlParameter("@m_code", model.m_code));
                        pList.Add(new MySqlParameter("@m_batchNo", model.m_batchNo));
                        pList.Add(new MySqlParameter("@m_MaterialID", model.m_MaterialID));
                        pList.Add(new MySqlParameter("@m_supplierID", model.m_supplierID));
                        pList.Add(new MySqlParameter("@m_status", model.m_status));
                        pList.Add(new MySqlParameter("@m_remark", model.m_remark));
                        pList.Add(new MySqlParameter("@m_deleteFlag", model.m_deleteFlag));
                        pList.Add(new MySqlParameter("@m_specificationmodels", model.m_specificationmodels));
                        pList.Add(new MySqlParameter("@m_manufacturer", model.m_manufacturer));
                        pList.Add(new MySqlParameter("@ID", model.ID));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }
                    myTrans.Commit();
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteMaterialBarCode(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "";
            int i = 0;
            //DateTime NowTime = db.GetServerTime();

            sql = @"update base_MaterialBarCode set m_deleteFlag=1 where ID in(" + id + ")";
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }



        #endregion

        #region 图片轮播配置

        /// <summary>
        /// 图片轮播配置 分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseImgCarousel> GetImgCarouselPage(BaseImgCarousel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            string sql = @"select Count(*) from base_ImgCarousel where 1=1 and deleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select * from base_ImgCarousel where  1=1 and deleteFlag=0 " + para;
            sql += " order by sort asc limit " + model.PageIndex + "," + model.PageSize;
            List<BaseImgCarousel> list = db.ExecuteList<BaseImgCarousel>(sql, pList.ToArray());

            return list;

        }


        /// <summary>
        /// 添加/修改 图片轮播配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveImgCarousel(BaseImgCarousel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";
                    DateTime serverTime = GetServerDateTime();

                    if (model.ID == 0)
                    {
                        #region 新增

                        var MaxSort = ConvertHelper.ToInt32(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text, "select Max(sort) from base_ImgCarousel", null), 0);

                        sql = @"INSERT INTO base_ImgCarousel(imgUrl,fullPath,title,remark,sort,deleteFlag,createTime,createMan,updateTime) 
                                Values(@imgUrl,fullPath,@title,@remark,@sort,@deleteFlag,@createTime,@createMan,@updateTime) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@imgUrl", model.imgUrl));
                        pList.Add(new MySqlParameter("@fullPath", model.fullPath));
                        pList.Add(new MySqlParameter("@title", model.title));
                        pList.Add(new MySqlParameter("@remark", model.remark));
                        pList.Add(new MySqlParameter("@sort", MaxSort + 1));
                        pList.Add(new MySqlParameter("@deleteFlag", model.deleteFlag));
                        pList.Add(new MySqlParameter("@createTime", serverTime));
                        pList.Add(new MySqlParameter("@createMan", model.createMan));
                        pList.Add(new MySqlParameter("@updateTime", serverTime));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 编辑
                        sql = @"update base_ImgCarousel set imgUrl=@imgUrl,fullPath=@fullPath,title=@title,remark=@remark,updateTime=@updateTime,updateMan=@updateMan where ID=@ID ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@imgUrl", model.imgUrl));
                        pList.Add(new MySqlParameter("@fullPath", model.fullPath));
                        pList.Add(new MySqlParameter("@title", model.title));
                        pList.Add(new MySqlParameter("@remark", model.remark));
                        pList.Add(new MySqlParameter("@updateTime", serverTime));
                        pList.Add(new MySqlParameter("@updateMan", model.updateMan));
                        pList.Add(new MySqlParameter("@ID", model.ID));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }
                    myTrans.Commit();
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }



        /// <summary>
        /// 单个图片删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DelImgCarousel(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            sql = @"update base_ImgCarousel set imgUrl='',fullpath='' where ID in(" + id + ")";
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteImgCarousel(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            sql = @"update base_ImgCarousel set deleteFlag=1 where ID in(" + id + ")";
            i = db.ExecuteNonQuery(sql, pList.ToArray());

            //删除完成后后进行重新排序
            List<BaseImgCarousel> List = db.ExecuteList<BaseImgCarousel>("select * from base_ImgCarousel where deleteFlag=0", null);
            for (int j = 0; j < List.Count; j++)
            {
                sql = @"update base_ImgCarousel set sort=" + (j + 1) + " where ID =" + List[j].ID;
                db.ExecuteNonQuery(sql, pList.ToArray());
            }
            return i > 0;
        }

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSort(List<BaseImgCarousel> model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;

            for (int j = 0; j < model.Count; j++)
            {
                sql = @"update base_ImgCarousel set sort=" + (j + 1) + " where ID =" + model[j].ID;
                i += db.ExecuteNonQuery(sql, pList.ToArray());
            }
            return i;
        }


        #endregion

        #region PPT 轮播


        /// <summary>
        /// PPT 轮播配置 分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BasePPTCarousel> GetPptCarouselPage(BasePPTCarousel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            string sql = @"select Count(*) from base_pptcarousel where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select * from base_pptcarousel where 1=1 " + para;
            sql += " order by sort asc limit " + model.PageIndex + "," + model.PageSize;
            List<BasePPTCarousel> list = db.ExecuteList<BasePPTCarousel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 添加/修改 PPT 轮播配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePptCarousel(BasePPTCarousel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";
                    if (model.ID == 0)
                    {
                        #region 新增

                        var MaxSort = ConvertHelper.ToInt32(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text, "select Max(sort) from base_pptcarousel", null), 0);

                        sql = @"INSERT INTO base_pptcarousel(imgUrl,fullPath,sort,remark) Values(@imgUrl,fullPath,@sort,@remark) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@imgUrl", model.imgUrl));
                        pList.Add(new MySqlParameter("@fullPath", model.fullPath));
                        pList.Add(new MySqlParameter("@sort", MaxSort + 1));
                        pList.Add(new MySqlParameter("@remark", model.remark));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 编辑
                        sql = @"update base_pptcarousel set imgUrl=@imgUrl,fullPath=@fullPath,remark=@remark where ID=@ID ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@imgUrl", model.imgUrl));
                        pList.Add(new MySqlParameter("@fullPath", model.fullPath));
                        pList.Add(new MySqlParameter("@remark", model.remark));
                        pList.Add(new MySqlParameter("@ID", model.ID));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }
                    myTrans.Commit();
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }



        /// <summary>
        /// 单个图片删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DelPptCarousel(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            sql = @"update base_pptcarousel set imgUrl='',fullpath='' where ID in(" + id + ")";
            i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeletePptCarousel(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;
            sql = @"delete from base_pptcarousel where ID in(" + id + ")";
            i = db.ExecuteNonQuery(sql, pList.ToArray());

            //删除完成后后进行重新排序
            List<BasePPTCarousel> List = db.ExecuteList<BasePPTCarousel>("select * from base_pptcarousel where 1=1 ", null);
            for (int j = 0; j < List.Count; j++)
            {
                sql = @"update base_pptcarousel set sort=" + (j + 1) + " where ID =" + List[j].ID;
                db.ExecuteNonQuery(sql, pList.ToArray());
            }
            return i > 0;
        }

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePptSort(List<BasePPTCarousel> model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            int i = 0;

            for (int j = 0; j < model.Count; j++)
            {
                sql = @"update base_pptcarousel set sort=" + (j + 1) + " where ID =" + model[j].ID;
                i += db.ExecuteNonQuery(sql, pList.ToArray());
            }
            return i;
        }


        /// <summary>
        /// 根据相应的cfg_code 修改大屏、ppt轮播 切换时间
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int UpdateConfig(string code, string value)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update sys_config set cfg_value='" + value + "' where cfg_code ='" + code + "'";
            return db.ExecuteNonQuery(sql, pList.ToArray());
        }


        #endregion

        #region 配料管理

        /// <summary>
        /// 分页查询 
        /// </summary>
        public List<BatchingRecordModel> BatchingRecordForPage(BatchingRecordModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.BatchCode))//计划订单号
                {
                    para += " and br.BatchCode like concat('%',@BatchCode,'%') ";
                    pList.Add(new MySqlParameter("@BatchCode", model.BatchCode));
                }

                if (model.PModelID.HasValue && model.PModelID != 0)//型号
                {
                    para += " and br.PModelID=@PModelID";
                    pList.Add(new MySqlParameter("@PModelID", model.PModelID));
                }

                //if (model.agw_gwID.HasValue && model.agw_gwID != 0)//工位 
                //{
                //    para += " and agw.agw_gwID=@agw_gwID";
                //    pList.Add(new MySqlParameter("@agw_gwID", model.agw_gwID));
                //}
                //if (!string.IsNullOrEmpty(model.starttime))//开始时间 
                //{
                //    var starttime = DateTime.Parse(model.starttime);
                //    para += " and agw.agw_starttime>=@agw_starttime";
                //    pList.Add(new MySqlParameter("@agw_starttime", starttime));
                //}
                //if (!string.IsNullOrEmpty(model.starttime1))//开始截止时间1
                //{
                //    var starttime1 = DateTime.Parse(model.starttime1).AddDays(+1).AddSeconds(-1);
                //    para += " and agw.agw_starttime<=@agw_startEndtime";
                //    pList.Add(new MySqlParameter("@agw_startEndtime", starttime1));
                //}
                //if (!string.IsNullOrEmpty(model.endtime))//完成时间 
                //{
                //    var endtime = DateTime.Parse(model.endtime);
                //    para += " and agw.agw_finishtime>=@agw_finishtime";
                //    pList.Add(new MySqlParameter("@agw_finishtime", endtime));
                //}
                //if (!string.IsNullOrEmpty(model.endtime1))//完成截止时间 
                //{
                //    var endtime1 = DateTime.Parse(model.endtime1).AddDays(+1).AddSeconds(-1);
                //    para += " and agw.agw_finishtime<=@agw_finishEndtime ";
                //    pList.Add(new MySqlParameter("@agw_finishEndtime", endtime1));
                //}
            }

            string sql = @"SELECT count(*) 
                                  FROM batching_record br
                                  LEFT JOIN base_productmodel pm ON br.PModelID = pm.ID
                                  LEFT JOIN base_program pro on br.ProgID = pro.ID
                                  LEFT JOIN sys_user su on br.ApplierID = su.userID
                                  WHERE 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"SELECT br.*,
                           pm.Pmodel as PModelName,
                           pro.progName as ProgName,
                           su.empName as AplierName
                           FROM batching_record br
                           LEFT JOIN base_productmodel pm ON br.PModelID = pm.ID
                           LEFT JOIN base_program pro on br.ProgID = pro.ID
                           LEFT JOIN sys_user su on br.ApplierID = su.userID
                           WHERE 1=1 " + para;

            sql += " order by br.BatchDate desc limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BatchingRecordModel> list = db.ExecuteList<BatchingRecordModel>(sql, pList.ToArray());

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];

                    sql = @"select br.*,bm.mName as MaterialName from batching_recorddetail br 
                            left join base_material bm on bm.ID = br.MaterialID
                            where br.BatchCode=@BatchCode ";

                    pList.Clear();
                    pList.Add(new MySqlParameter("@BatchCode", item.BatchCode));

                    item.Details = db.ExecuteList<BatchingRecordDetailModel>(sql, pList.ToArray());
                }
            }

            return list;

        }

        /// <summary>
        /// 条件查询 
        /// </summary>
        public BatchingRecordModel GetBatchingRecord(BatchingRecordModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.BatchCode))//计划订单号
            {
                para += " and br.BatchCode like concat('%',@BatchCode,'%') ";
                pList.Add(new MySqlParameter("@BatchCode", model.BatchCode));
            }

            string sql = @"SELECT br.*,
                           pm.Pmodel as PModelName,
                           pro.progName as ProgName,
                           su.empName as AplierName
                           FROM batching_record br
                           LEFT JOIN base_productmodel pm ON br.PModelID = pm.ID
                           LEFT JOIN base_program pro on br.ProgID = pro.ID
                           LEFT JOIN sys_user su on br.ApplierID = su.userID
                           WHERE 1=1 " + para;

            BatchingRecordModel batching = db.ExecuteList<BatchingRecordModel>(sql, pList.ToArray()).FirstOrDefault();

            if (batching != null)
            {
                sql = @"select br.*,bm.mName as MaterialName from batching_recorddetail br 
                            left join base_material bm on bm.ID = br.MaterialID
                            where br.BatchCode=@BatchCode ";

                pList.Clear();
                pList.Add(new MySqlParameter("@BatchCode", batching.BatchCode));

                batching.Details = db.ExecuteList<BatchingRecordDetailModel>(sql, pList.ToArray());
            }

            return batching;
        }

        /// <summary>
        /// 新增 
        /// </summary>
        public void AddBatchingRecord(BatchingRecordModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "insert into batching_record(BatchCode,PModelID,ProgID,WarehouseID,TypeID,ApplierID,BatchDate,BatchStatus) values(@BatchCode,@PModelID,@ProgID,@WarehouseID,@TypeID,@ApplierID,@BatchDate,@BatchStatus)";

            pList.Add(new MySqlParameter("@BatchCode", model.BatchCode));
            pList.Add(new MySqlParameter("@PModelID", model.PModelID));
            pList.Add(new MySqlParameter("@ProgID", model.ProgID));
            pList.Add(new MySqlParameter("@WarehouseID", model.WarehouseID));
            pList.Add(new MySqlParameter("@TypeID", model.TypeID));
            pList.Add(new MySqlParameter("@ApplierID", model.ApplierID));
            pList.Add(new MySqlParameter("@BatchDate", model.BatchDate));
            pList.Add(new MySqlParameter("@BatchStatus", model.BatchStatus));

            db.ExecuteNonQuery(sql, pList.ToArray());

            foreach (var item in model.Details)
            {
                pList.Clear();
                pList.Add(new MySqlParameter("@BatchCode", model.BatchCode));
                pList.Add(new MySqlParameter("@MaterialID", item.MaterialID));
                pList.Add(new MySqlParameter("@Quantity", item.Quantity));

                sql = "insert into batching_recorddetail(BatchCode,MaterialID,Quantity) values(@BatchCode,@MaterialID,@Quantity)";

                db.ExecuteNonQuery(sql, pList.ToArray());
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        public void EditBatchingRecordState(BatchingRecordModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "update batching_record set BatchStatus=@BatchStatus,ReceiveID=@ReceiveID,Createtime=@Createtime where BatchCode=@BatchCode ";

            pList.Add(new MySqlParameter("@BatchCode", model.BatchCode));
            pList.Add(new MySqlParameter("@BatchStatus", model.BatchCode));

            pList.Add(new MySqlParameter("@ReceiveID", model.ReceiveID));
            pList.Add(new MySqlParameter("@Createtime", model.Createtime));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 配方管理

        public List<BaseFormulaModel> GetFormula(string formulaCode, int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT bf.*,bp.Pmodel prodmodelName,bp.tighteningTorque tighteningTorque  FROM base_formula bf LEFT JOIN base_productmodel bp on bf.prodmodelID=bp.ID WHERE 1=1 ";
            if (!string.IsNullOrEmpty(formulaCode))
            {
                sql += " and bf.formulaCode like'%" + formulaCode + "%'";
            }
            if (id != 0)
            {
                sql += " and bf.ID=@ID";
                pList.Add(new MySqlParameter("@ID", id));
            }
            sql += " ORDER BY ID DESC";
            List<BaseFormulaModel> query = db.ExecuteList<BaseFormulaModel>(sql, pList.ToArray());
            return query;
        }

        public List<BaseFormulaModel> GetFormulaByFCode(string formulaCode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT bf.*,bp.Pmodel prodmodelName,bp.tighteningTorque tighteningTorque  FROM base_formula bf LEFT JOIN base_productmodel bp on bf.prodmodelID=bp.ID WHERE 1=1 ";
            if (!string.IsNullOrEmpty(formulaCode))
            {
                sql += " and bf.formulaCode =" + formulaCode;
            }
            sql += " ORDER BY ID DESC";
            List<BaseFormulaModel> query = db.ExecuteList<BaseFormulaModel>(sql, pList.ToArray());
            return query;
        }


        public List<BaseFormulaModel> GetFormulaByPmodel(int pModelId)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT bf.*,bp.Pmodel prodmodelName,bp.tighteningTorque tighteningTorque  FROM base_formula bf LEFT JOIN base_productmodel bp on bf.prodmodelID=bp.ID WHERE 1=1 ";
            if (pModelId != 0)
            {
                sql += " and prodModelID=@ID";
                pList.Add(new MySqlParameter("@ID", pModelId));
            }
            sql += " ORDER BY ID DESC";
            List<BaseFormulaModel> query = db.ExecuteList<BaseFormulaModel>(sql, pList.ToArray());
            return query;
        }

        public BaseFormulaModel GetFormulaByCode(string formulaCode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT * FROM base_formula WHERE 1=1";
            if (!string.IsNullOrEmpty(formulaCode))
            {
                sql += " and formulaCode='" + formulaCode + "'";
            }
            sql += " ORDER BY ID DESC";
            List<BaseFormulaModel> query = db.ExecuteList<BaseFormulaModel>(sql, pList.ToArray());
            return query.Count > 0 ? query[0] : null;
        }


        public int EditFormula(BaseFormulaModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            if (model.ID != 0)
            {
                var result = GetFormulaByCode(model.formulaCode);
                if (result != null)
                {
                    if (result.ID != model.ID)
                        return -1;
                }
                sql = @"UPDATE base_formula SET formulaCode=@formulaCode,formulaName=@formulaName,pointInfoDes=@pointInfoDes WHERE ID=@ID";
                pList.Add(new MySqlParameter("@ID", model.ID));
            }
            else
            {
                var result = GetFormulaByCode(model.formulaCode);
                if (result != null)
                {
                    return -1;
                }
                sql = @"INSERT INTO base_formula(formulaCode,formulaName,pointInfoDes) VALUES(@formulaCode,@formulaName,@pointInfoDes)";
            }
            pList.Add(new MySqlParameter("@formulaCode", model.formulaCode));
            pList.Add(new MySqlParameter("@formulaName", model.formulaName));
            //pList.Add(new MySqlParameter("@prodmodelID", model.prodmodelID));
            pList.Add(new MySqlParameter("@pointInfoDes", model.pointInfoDes));
            return db.ExecuteNonQuery(sql, pList.ToArray());
        }

        public int DeleteFormula(int ID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "DELETE FROM base_formula WHERE ID=" + ID;
            return db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

    }
}