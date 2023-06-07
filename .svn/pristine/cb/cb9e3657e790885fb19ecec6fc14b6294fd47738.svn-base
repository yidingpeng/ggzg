using MySql.Data.MySqlClient;
using RW.PMS.Model.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.MYSQL.DAL
{
    public class DAL_BaseInfo
    {
        RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

        #region 产品信息 Add

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductModel> GetPagingBaseProduct(BaseProductModel model, out int totalCount)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = "select count(*) from base_product where 1=1";
            if (!string.IsNullOrEmpty(model.Pname))
            {
                sql += " where and Pname like '%@Pname%'";
                List.Add(new MySqlParameter("@Pname", model.Pname));
            }
            int.TryParse(db.ExecuteScalar(sql, List.ToArray()) + "", out totalCount);

            List.Clear();
            sql = @"select * from base_product";
            if (!string.IsNullOrEmpty(model.Pname))
            {
                sql += " where and Pname like '%@Pname%'";
                List.Add(new MySqlParameter("@Pname", model.Pname));
            }
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseProductModel> list = db.ExecuteList<BaseProductModel>(sql, List.ToArray());
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">产品信息实体类</param>
        public void AddBaseProduct(BaseProductModel model)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = "INSERT INTO base_product (Pname,Pstatus,remark) VALUES (@Pname,@Pstatus,@remark)";
            List.Add(new MySqlParameter("@Pname", model.Pname));
            List.Add(new MySqlParameter("@Pstatus", model.Pname));
            List.Add(new MySqlParameter("@remark", model.Pname));
            db.ExecuteNonQuery(sql, List.ToArray());
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">产品信息表Id</param>
        /// <returns></returns>
        public BaseProductModel GetBaseProductId(int Id)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select ID,Pname,Pstatus,remark from base_product where ID=@ID";
            List.Add(new MySqlParameter("@ID", Id));
            List<BaseProductModel> list = db.ExecuteList<BaseProductModel>(sql, List.ToArray());
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
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = "UPDATE base_product SET Pname=@Pname,Pstatus=@Pstatus,remark=@remark WHERE ID=@ID";
            List.Add(new MySqlParameter("@Pname", model.Pname));
            List.Add(new MySqlParameter("@Pstatus", model.Pname));
            List.Add(new MySqlParameter("@remark", model.Pname));
            List.Add(new MySqlParameter("@ID", model.ID));
            db.ExecuteNonQuery(sql, List.ToArray());

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProduct(string id)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string[] list = id.Split(',');
            for (int i = 0; i < list.Length; i++)
            {
                var num = Convert.ToInt32(list[i]);
                string sqlquery = @"select ID,Pname,Pstatus,remark from base_product where ID=@ID";
                List.Add(new MySqlParameter("@ID", id));
                List<BaseProductModel> items = db.ExecuteList<BaseProductModel>(sqlquery, List.ToArray());

                //var items = context.base_product.SingleOrDefault<base_product>(s => s.ID == num);
                if (items == null)
                {
                    throw new Exception("未找到该产品！");
                }
                else
                {
                    string sql = @"DELETE FROM base_product WHERE ID=@ID";
                    List.Add(new MySqlParameter("@ID", num));
                    db.ExecuteNonQuery(sql, List.ToArray());
                }
            }

        }

        #endregion

        #region 产品型号信息 Add

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetPagingBaseProductModel(BaseProductModelModel model, out int totalCount)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select count(*) from base_productModel bpm
                           left join base_product bpt on bpm.pid = bpt.ID
                           where bpm.PID = @PID";

            List.Add(new MySqlParameter("@PID", model.PID));
            totalCount = (int)db.ExecuteScalar(sql, List.ToArray());

            List.Clear();
            sql = @"select count(*) from base_productModel bpm
                    left join base_product bpt on bpm.pid = bpt.ID
                    where bpm.PID = @PID";
            List.Add(new MySqlParameter("@PID", model.PID));

            if (!string.IsNullOrEmpty(model.Pmodel))
            {
                sql += " and Pmodel like '%@Pmodel%'";
                List.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            }
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, List.ToArray());
            return list;

        }

        /// <summary>
        /// 获取未禁用的所有产品型号(用于下拉框)
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetProductModelAll()
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select * from base_productModel where Pstatus <> 1 ";
            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, List.ToArray());
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">产品型号实体类</param>
        public void AddBaseProductModel(BaseProductModelModel model)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = "INSERT INTO base_productModel (PID,Pmodel,beatMinite,Pstatus,remark) VALUES (@PID,@Pmodel,@beatMinite,@Pstatus,@remark)";
            List.Add(new MySqlParameter("@PID", model.PID));
            List.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            List.Add(new MySqlParameter("@beatMinite", model.beatMinite));
            List.Add(new MySqlParameter("@Pstatus", model.Pstatus));
            List.Add(new MySqlParameter("@remark", model.remark));
            db.ExecuteNonQuery(sql, List.ToArray());
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">产品型号信息表Id</param>
        /// <returns></returns>
        public BaseProductModelModel GetBaseProductModelId(int Id)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select ID,PID,Pmodel,beatMinite,Pstatus,remark from base_productModel where ID=@ID";
            List.Add(new MySqlParameter("@ID", Id));
            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, List.ToArray());
            if (list.Count > 0)
                return list[0];
            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProductModel(BaseProductModelModel model)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = "UPDATE base_productModel SET PID=@PID,Pmodel=@Pmodel,beatMinite=@beatMinite,Pstatus=@Pstatus,remark=@remark WHERE ID=@ID";
            List.Add(new MySqlParameter("@PID", model.PID));
            List.Add(new MySqlParameter("@Pmodel", model.Pmodel));
            List.Add(new MySqlParameter("@beatMinite", model.beatMinite));
            List.Add(new MySqlParameter("@Pstatus", model.Pstatus));
            List.Add(new MySqlParameter("@remark", model.remark));
            db.ExecuteNonQuery(sql, List.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProductModel(string id)
        {

            List<MySqlParameter> List = new List<MySqlParameter>();
            string[] list = id.Split(',');
            for (int i = 0; i < list.Length; i++)
            {
                var num = Convert.ToInt32(list[i]);
                string sqlquery = @"select ID,PID,Pmodel,beatMinite,Pstatus,remark from base_productModel where ID=@ID";
                List.Add(new MySqlParameter("@ID", id));
                List<BaseProductModelModel> items = db.ExecuteList<BaseProductModelModel>(sqlquery, List.ToArray());

                if (items == null)
                {
                    throw new Exception("未找到该产品型号！");
                }
                else
                {
                    string sql = @"DELETE FROM base_productModel WHERE ID=@ID";
                    List.Add(new MySqlParameter("@ID", num));
                    db.ExecuteNonQuery(sql, List.ToArray());
                }
            }
        }

        #endregion

        #region 工位信息 
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseGongweiModel> GetPagingBaseGongWei(BaseGongweiModel model, out int totalCount)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"SELECT count(*)
                            FROM  base_gongweiOPC opc 
                            LEFT JOIN base_gongwei gw ON opc.gwID = gw.ID 
                            where 1=1 ";
            if (!string.IsNullOrEmpty(model.gwname))
            {
                sql += " and Pname = like '%@Gwname%'";
                List.Add(new MySqlParameter("@Gwname", model.gwname));
            }
            if (!string.IsNullOrEmpty(model.IP))
            {
                sql += " and Pname like '%@IP%'";
                List.Add(new MySqlParameter("@IP", model.IP));
            }
            if (model.areaID != null && model.areaID != 0)
            {
                sql += " and Pname = @AreaID";
                List.Add(new MySqlParameter("@AreaID", model.areaID));
            }
            totalCount = (int)db.ExecuteScalar(sql, List.ToArray());

            List.Clear();
            sql = @"SELECT opc.gwID,gw.gwcode,gw.gwname,gw.gwStatus,gw.IP,gw.areaID,gw.gworder,gw.isFinishGW,gw.isHasFollow,gw.isHasAms,gw.remark,opc.ID,opc.gwID,opc.gwname,
                    opc.opcTypeID,opc.opcTypeCode,opc.opcValue,opc.remark
                    FROM  base_gongweiOPC opc 
                    LEFT JOIN base_gongwei gw ON opc.gwID = gw.ID 
                    where 1=1 ";

            if (!string.IsNullOrEmpty(model.gwname))
            {
                sql += " and Pname = like '%@Gwname%'";
                List.Add(new MySqlParameter("@Gwname", model.gwname));
            }
            if (!string.IsNullOrEmpty(model.IP))
            {
                sql += " and Pname like '%@IP%'";
                List.Add(new MySqlParameter("@IP", model.IP));
            }
            if (model.areaID != null && model.areaID != 0)
            {
                sql += " and Pname = @AreaID";
                List.Add(new MySqlParameter("@AreaID", model.areaID));
            }

            sql += " order by opc.gwid ASC,opc.opcTypeID DESC";
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, List.ToArray());
            return list;

        }


        /// <summary>
        /// 获取所有工位
        /// </summary>
        /// <returns></returns>
        public List<BaseGongweiModel> GetAllBaseGongWei(int areaID)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select ID,Gwname,GwOrder from base_gongwei where gwStatus <> 1 ";
            if (areaID != 0)
            {
                sql += " and areaID = @areaID ";
                List.Add(new MySqlParameter("@areaID", areaID));
            }
            List<BaseGongweiModel> list = db.ExecuteList<BaseGongweiModel>(sql, List.ToArray());
            return list;
        }

        /// <summary>
        /// 获取产品型号信息2019-05-15
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetAllBaseProModel()
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select bpm.ID,Pmodel,PID,PName from base_productModel bpm
                            LEFT JOIN base_product bpt on bpm.PID = bpt.ID";
            List<BaseProductModelModel> list = db.ExecuteList<BaseProductModelModel>(sql, List.ToArray());
            return list;
        }


        /// <summary>
        /// 查询所有工位opc点位信息
        /// </summary>
        /// <returns></returns>
        public List<BaseGongweiOpcModel> GetGongWeiOPC()
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select opc.ID,gwID,gw.gwname,opcTypeID,opcTypeCode,opcValue,opc.remark 
                            from base_gongweiOPC opc
                            left join base_gongwei gw on opc.gwID = gw.ID";
            List<BaseGongweiOpcModel> list = db.ExecuteList<BaseGongweiOpcModel>(sql, List.ToArray());
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">工位信息实体类</param>
        public void AddBaseGongWei(BaseGongweiModel model)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"INSERT INTO base_gongwei (gwcode,gwname,gwStatus,IP,areaID,gwOrder,isFinishGW,isHasFollow,isHasAms,remark) 
                            VALUES (@gwcode,@gwname,@gwStatus,@IP,@areaID,@gwOrder,@isFinishGW,@isHasFollow,@isHasAms,@remark)";
            List.Add(new MySqlParameter("@gwcode", model.gwcode));
            List.Add(new MySqlParameter("@gwname", model.gwname));
            List.Add(new MySqlParameter("@gwStatus", model.gwStatus));
            List.Add(new MySqlParameter("@IP", model.IP));
            List.Add(new MySqlParameter("@areaID", model.areaID));
            List.Add(new MySqlParameter("@gwOrder", model.gwOrder));
            List.Add(new MySqlParameter("@isFinishGW", model.isFinishGW));
            List.Add(new MySqlParameter("@isHasFollow", model.isFinishGW));
            List.Add(new MySqlParameter("@isHasAms", model.isHasAms));
            List.Add(new MySqlParameter("@remark", model.remark));
            db.ExecuteNonQuery(sql, List.ToArray());

        }
        #endregion
    }
}
