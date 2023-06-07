using MySql.Data.MySqlClient;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RW.PMS.DAL
{
    internal class DAL_ReportTemplate : IDAL_ReportTemplate
    {
        private const string BDTypeCode = "TemplateBindType";

        #region 生产记录报告模板

        /// <summary>
        /// 获取生产记录报告模板列表
        /// </summary>
        /// <returns></returns>
        public PageModel<List<RepTemplateModel>> GetRepTemplateList(int? pModelID, int pageSize = 10, int pageIndex = 1)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();

            var sqlStr = "SELECT {0} FROM rep_template templ LEFT JOIN base_productmodel model ON templ.PModelID=model.ID  WHERE 1=1 ";
            if (pModelID.HasValue)
            {
                pList.Add(new MySqlParameter("@PModelID", pModelID));
                sqlStr += "AND PModelID = @PModelID";
            }
            sqlStr += " ORDER BY templ.createDate";

            //get total 
            var count = 0;
            if (pageSize != 0 && pageIndex != 0)
            {
                var val = db.ExecuteScalar(string.Format(sqlStr, "COUNT(*)"), pList.ToArray());
                int.TryParse(val + "", out count);

                sqlStr += " limit " + pageSize * (pageIndex - 1) + "," + pageSize;
            }

            //get result
            var list = db.ExecuteList<RepTemplateModel>(string.Format(sqlStr,
                " templ.ID, templ.PModelID,model.PModel,templ.Name,templ.FileName,templ.Remark,templ.Enabled, templ.havFile,templ.CreateDate,templ.UpdateDate," +
                " (SELECT if(count(*)>0,1,0) FROM rep_datasource WHERE templ.PmodelID = rep_datasource.PmodelID) as HavSource "), pList.ToArray());
            var result = new PageModel<List<RepTemplateModel>>(count, list);

            return result;
        }

        /// <summary>
        /// 获取生产记录报告模板明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public RepTemplateModel GetRepTemplateDetail(int ID)
        {
            var db = new Common.MySqlHelper();
            var list = db.ExecuteList<RepTemplateModel>("SELECT * FROM rep_template rep WHERE ID=@ID", new MySqlParameter("@ID", ID));
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        /// <summary>
        /// 获取生产记录报告模板明细 根据产品型号ID
        /// </summary>
        /// <param name="pModelID"></param>
        /// <returns></returns>
        public RepTemplateModel GetRepTemplateDetailByProdModelID(int pModelID)
        {
            var db = new Common.MySqlHelper();
            var list = db.ExecuteList<RepTemplateModel>("SELECT rep.* FROM rep_template rep LEFT JOIN base_productmodel pmodel ON rep.PmodelID = pmodel.ID WHERE rep.enabled=1 AND rep.FileName!='' AND pmodel.ID=@ID ORDER BY rep.UpdateDate DESC", new MySqlParameter("@ID", pModelID));
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        /// <summary>
        /// 更新生产记录报告模板
        /// </summary>
        /// <param name="model"></param>
        public void UpdateRepTemplate(RepTemplateModel model)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();

            //判断名称是否重复
            pList.Add(new MySqlParameter("@Name", model.Name));
            var sqlStr = "SELECT Name FROM rep_template WHERE Name=@Name ";
            if (model.ID != 0)
            {
                pList.Add(new MySqlParameter("@ID", model.ID));
                sqlStr += " AND ID!=@ID";
            }
            var table = db.ExecuteDataTable(sqlStr, pList.ToArray());
            if (table.Rows.Count > 0)
            {
                throw new ArgumentException("模板名称重复！");
            }
            //同一个产品型号只能同时启用一个模板
            pList.Add(new MySqlParameter("@PModelID", model.PModelID));
            if (model.Enabled)
            {
                sqlStr = "SELECT Enabled FROM rep_template WHERE pModelID=@pModelID AND Enabled=1";
                if (model.ID != 0)
                {
                    sqlStr += " AND ID!=@ID";
                }
                table = db.ExecuteDataTable(sqlStr, pList.ToArray());
                if (table.Rows.Count > 0)
                {
                    throw new ArgumentException("同一个产品型号只能同时启用一个模板！");
                }
            }

            pList.Add(new MySqlParameter("@FileName", model.FileName));
            pList.Add(new MySqlParameter("@FileValue", model.FileValue));
            pList.Add(new MySqlParameter("@HavFile", model.havFile));
            pList.Add(new MySqlParameter("@Enabled", model.Enabled));
            pList.Add(new MySqlParameter("@Remark", model.Remark));
            pList.Add(new MySqlParameter("@UpdateDate", DateTime.Now));
            if (model.ID == 0)
            {
                pList.Add(new MySqlParameter("@CreateDate", DateTime.Now));
                sqlStr = "INSERT INTO rep_template(PModelID,Name,FileName,FileValue,HavFile,Remark,Enabled,CreateDate,UpdateDate) VALUES(@PModelID,@Name,@FileName,@FileValue,@HavFile,@Remark,@Enabled,@CreateDate,@UpdateDate)";
            }
            else
            {
                sqlStr = "UPDATE rep_template SET PModelID=@PModelID,Name=@Name,{0}HavFile=@HavFile,Remark=@Remark,Enabled=@Enabled,UpdateDate=@UpdateDate WHERE ID=@ID";

                //表示没有修改模板文件
                if (model.havFile && model.FileValue == null)
                {
                    sqlStr = string.Format(sqlStr, "");
                }
                else
                {

                    sqlStr = string.Format(sqlStr, "FileName=@FileName,FileValue=@FileValue,");
                }
            }
            db.ExecuteNonQuery(sqlStr, pList.ToArray());
        }

        /// <summary>
        /// 删除生产记录报告模板
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteRepTemplate(int ID)
        {
            var db = new Common.MySqlHelper();
            db.ExecuteNonQuery("DELETE FROM rep_template WHERE ID=@ID", new MySqlParameter("@ID", ID));
        }

        #endregion 

        #region 绑定报告模板数据源

        /// <summary>
        /// 获取绑定报告模板数据源  
        /// </summary>
        /// <param name="pmodelID"></param>
        /// <returns></returns>
        public PageModel<List<RepTemplBindSourceModel>> GetRepTemplBindSourceList(int? pmodelID, int? typeID, int pageSize = 10, int pageIndex = 1)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();

            var sqlStr = "SELECT {0} FROM rep_datasource rep LEFT JOIN base_productmodel model ON rep.PmodelID = model.ID  LEFT JOIN sys_basedata data ON rep.ITypeID=data.ID WHERE  data.bdTypeCode='" + BDTypeCode + "'";
            if (pmodelID.HasValue)
            {
                pList.Add(new MySqlParameter("@PmodelID", pmodelID));
                sqlStr += " AND rep.PmodelID=@PmodelID";
            }
            if (typeID.HasValue)
            {
                pList.Add(new MySqlParameter("@TypeID", typeID));
                sqlStr += " AND rep.ITypeID=@TypeID";
            }
            sqlStr += " ORDER BY rep.ITypeID, rep.OrderNo ,rep.createDate ";

            //get total
            var count = 0;
            if (pageSize != 0 && pageIndex != 0)
            {
                var val = db.ExecuteScalar(string.Format(sqlStr, "COUNT(*)"), pList.ToArray());
                int.TryParse(val + "", out count);

                sqlStr += " limit " + pageSize * (pageIndex - 1) + "," + pageSize;
            }
            //get result
            var list = db.ExecuteList<RepTemplBindSourceModel>(string.Format(sqlStr, "rep.*,data.bdname as ITypeName,model.Pmodel"), pList.ToArray());
            //pageModel
            var result = new PageModel<List<RepTemplBindSourceModel>>(count, list);
            return result;
        }

        /// <summary>
        /// 获取绑定报告模板数据源 明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public RepTemplBindSourceModel GetRepTemplBindSourceDetail(int ID)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();

            var sqlStr = "SELECT * FROM rep_datasource WHERE ID=@ID";

            pList.Add(new MySqlParameter("@ID", ID));
            var list = db.ExecuteList<RepTemplBindSourceModel>(sqlStr, pList.ToArray());
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        /// <summary>
        /// 更新绑定报告模板数据源
        /// </summary>
        /// <param name="models"></param>
        public void UpdateRepTemplBindSource(RepTemplBindSourceModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException($"argument {nameof(model)} is null!");
            }
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            pList.Add(new MySqlParameter("@ItemName", model.ItemName));
            pList.Add(new MySqlParameter("@PmodelID", model.PModelID));
            pList.Add(new MySqlParameter("@ITypeID", model.ITypeID));
            var sqlStr = string.Empty;
            if (model.ID == 0)
            {
                sqlStr = "SELECT COUNT(*) FROM rep_datasource WHERE ItemName=@ItemName AND PmodelID=@PmodelID AND ITypeID=@ITypeID";
            }
            else
            {
                pList.Add(new MySqlParameter("@ID", model.ID));
                sqlStr = "SELECT COUNT(*) FROM rep_datasource WHERE ItemName=@ItemName AND  PmodelID=@PmodelID AND ITypeID=@ITypeID AND ID!=@ID";
            }
            var val = db.ExecuteScalar(sqlStr, pList.ToArray());
            var count = 0;
            int.TryParse(val + "", out count);
            if (count > 0)
            {
                throw new Exception("'数据名称'不能重复！");
            }

            pList.Add(new MySqlParameter("@OrderNo", model.OrderNo));
            pList.Add(new MySqlParameter("@BindValue", model.BindValue));
            pList.Add(new MySqlParameter("@DefaultValue", model.DefaultValue));
            pList.Add(new MySqlParameter("@BindType", model.BindType));
            pList.Add(new MySqlParameter("@Remark", model.Remark));
            pList.Add(new MySqlParameter("@UpdateDate", DateTime.Now));
            if (model.ID == 0)
            {
                pList.Add(new MySqlParameter("@CreateDate", DateTime.Now));
                sqlStr = "INSERT INTO rep_datasource(PmodelID, ITypeID,ItemName,OrderNo,BindType,BindValue,DefaultValue,Remark,CreateDate,UpdateDate) VALUES(@PmodelID, @ITypeID,@ItemName,@OrderNo,@BindType,@BindValue,@DefaultValue,@Remark,@CreateDate,@UpdateDate)";

            }
            else
            {
                sqlStr = "UPDATE rep_datasource SET PmodelID=@PmodelID,ITypeID=@ITypeID,ItemName=@ItemName,OrderNo=@OrderNo,BindType=@BindType,BindValue=@BindValue,DefaultValue=@DefaultValue,Remark=@Remark,UpdateDate=@UpdateDate WHERE ID=@ID";
            }
            db.ExecuteNonQuery(CommandType.Text, sqlStr, pList.ToArray());
        }

        /// <summary>
        /// 删除绑定报告模板数据源
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteRepTemplBindSource(int ID)
        {
            var db = new Common.MySqlHelper();
            var sqlStr = "DELETE FROM rep_datasource WHERE ID=@ID";
            db.ExecuteNonQuery(sqlStr, new MySqlParameter("@ID", ID));
        }

        /// <summary>
        /// 获取绑定类型列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> GetBindTypes(int ID)
        {
            //var db = new Common.MySqlHelper();
            var dict = new Dictionary<string, string>();
            //var sqlStr = string.Empty;
            //DataTable dt = null;
            //switch (ID)
            //{
            //    case 388://基本信息
            //        dict.Add("ProdNo", "ProdNo");//部件号
            //        dict.Add("CarNo", "CarNo");//原装车号
            //        dict.Add("StartDate", "StartDate");//完工日期
            //        dict.Add("FinishDate", "FinishDate");//现装车号
            //        break;
            //    case 390://计量器具编号
            //        sqlStr = "SELECT devcode,devName FROM  base_device WHERE devDeleteFlag!=1";
            //        dt = db.ExecuteDataTable(sqlStr);
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            dict.Add(dr["devcode"].ToString(), dr["devcode"].ToString() + "-" + dr["devName"].ToString());
            //        }
            //        break;
            //    case 391://自检互检信息
            //        sqlStr = "SELECT ID,gwcode,gwname FROM base_gongwei WHERE areaID NOT IN(236,132)  ORDER BY gwOrder ";
            //        dt = db.ExecuteDataTable(sqlStr);
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            dict.Add(dr["gwcode"].ToString(), dr["gwcode"].ToString()+"-"+dr["gwname"].ToString());
            //        }
            //        break;
            //    case 392://设备检验信息
            //        sqlStr = "SELECT DISTINCT chTypeCode FROM  log_checkhash ORDER BY chTypeCode; ";
            //        dt = db.ExecuteDataTable(sqlStr);
            //        //var list = new List<string>();
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            dict.Add(dr[0].ToString(), dr[0].ToString());
            //        }
            //        //注油
            //        if (string.IsNullOrEmpty(dict.Keys.FirstOrDefault(f => f == "OilingGunQD")))
            //        {
            //            dict.Add("OilingGunQD", "OilingGunQD");
            //        }
            //        if (string.IsNullOrEmpty(dict.Keys.FirstOrDefault(f => f == "OilingGunFQD")))
            //        {
            //            dict.Add("OilingGunFQD", "OilingGunFQD");
            //        }
            //        break;
            //    case 395://完工检
            //        dict.Add("CleanInspectionResult", "CleanInspectionResult");//清洁...，检查结果
            //        dict.Add("CleanInspectionDesc", "CleanInspectionDesc");//清洁...，检查描述
            //        dict.Add("CleanInspectionReview", "CleanInspectionReview");//清洁...，复查记录
            //        dict.Add("MeasureInspectionResult", "MeasureInspectionResult");//测量...，检查结果
            //        dict.Add("MeasureInspectionDesc", "MeasureInspectionDesc");//测量...，检查描述
            //        dict.Add("MeasureInspectionReview", "MeasureInspectionReview");//测量...，复查记录
            //        dict.Add("InstallInspectionResult", "InstallInspectionResult");//安装...，检查结果
            //        dict.Add("InstallInspectionDesc", "InstallInspectionDesc");//安装...，检查描述
            //        dict.Add("InstallInspectionReview", "InstallInspectionReview");//安装...，复查记录
            //        dict.Add("InitialInspection", "InitialInspection");//初检
            //        dict.Add("RecheckInspection", "RecheckInspection");//复检
            //        dict.Add("QualityInspector", "QualityInspector");//质检员
            //        dict.Add("InspectionDate", "InspectionDate");//日期
            //        dict.Add("InspectionRemark", "InspectionRemark");//备注
            //        break;
            //    case 396://工序信息
            //        sqlStr = "SELECT ID,gxname FROM base_gongxu ORDER BY gxname";
            //        dt = db.ExecuteDataTable(sqlStr);
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            dict.Add(dr["ID"].ToString(), dr["ID"].ToString() + "-" + dr["gxname"].ToString());
            //        }
            //        break;
            //    default:
            //        break;
            //}
            return dict;
        }
        
        #endregion

    }

}