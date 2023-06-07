using MySql.Data.MySqlClient;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Torque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.DAL
{
    public class DAL_Torque:IDAL_Torque
    {

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TorqueTool> GetTorquePageList(TorqueTool model, out int totalCount)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.TorqueName))
            {
                para += " and TorqueName like CONCAT('%',@TorqueName,'%') ";
                pList.Add(new MySqlParameter("@TorqueName", model.TorqueName));
            }
            if (!string.IsNullOrEmpty(model.TorqueCode))
            {
                para += " and TorqueCode like CONCAT('%',@TorqueCode,'%') ";
                pList.Add(new MySqlParameter("@TorqueCode", model.TorqueCode));
            }
            string sql = "select count(*) from torque_tool where 1=1 AND IsDelete=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);
            sql = "select * from torque_tool where 1=1 AND IsDelete=0 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<TorqueTool> list = db.ExecuteList<TorqueTool>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        ///查询所有校验工具数据
        /// </summary>
        /// <returns></returns>
        public List<TorqueTool> JDListAll()
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string SQL = @"select * from torque_tool where IsDelete=0 ";
            List<TorqueTool> list = db.ExecuteList<TorqueTool>(SQL, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 根据ID查询校验工具信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        public TorqueTool GetTorqueToolId(int Id)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select * from torque_tool where IsDelete=0 AND Id=@Id";
            List.Add(new MySqlParameter("@Id", Id));
            List<TorqueTool> list = db.ExecuteList<TorqueTool>(sql, List.ToArray());
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }
        /// <summary>
        /// 保存扭矩基础信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTorqueTool(TorqueTool model)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            pList.Clear();
            pList.Add(new MySqlParameter("@Id", model.Id));
            pList.Add(new MySqlParameter("@TorqueCode", model.TorqueCode));
            pList.Add(new MySqlParameter("@TorqueName", model.TorqueName));
            pList.Add(new MySqlParameter("@Ranges", model.Ranges));
            pList.Add(new MySqlParameter("@SSBZ", model.SSBZ));
            pList.Add(new MySqlParameter("@BGR", model.BGR));
            pList.Add(new MySqlParameter("@SCCJ", model.SCCJ));
            pList.Add(new MySqlParameter("@LengthS", model.LengthS));
            pList.Add(new MySqlParameter("@Remark", model.Remark));
            pList.Add(new MySqlParameter("@IsDelete", "0"));
            string SQL;
            if (model.Id == 0)
            {
                SQL = @"insert into torque_tool(TorqueCode,TorqueName,Ranges,SSBZ,BGR,SCCJ,LengthS,Remark,IsDelete) values(@TorqueCode,@TorqueName,@Ranges,@SSBZ,@BGR,@SCCJ,@LengthS,@Remark,@IsDelete)";
            }
            else
            {
                SQL = @"update torque_tool set 
                        TorqueCode=@TorqueCode,
                        TorqueName=@TorqueName,
                        Ranges=@Ranges,SSBZ=@SSBZ,
                        BGR=@BGR,SCCJ=@SCCJ,
                        LengthS=@LengthS,
                        Remark=@Remark where Id=@Id";
            }
            int i = db.ExecuteNonQuery(SQL, pList.ToArray());
            return i > 0;
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id">用户ID</param>
        public void TorqueToolDelete(string id)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update torque_tool set IsDelete = 1 where Id in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        ///查询当天的试验台测试数据
        /// </summary>
        /// <returns></returns>
        public List<torque_jianding> JDListTo_Days()
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string SQL = @"select * from torque_jianding where 1=1 AND deleted=0 AND to_days(JDRQ) = to_days(now()) ";
            List<torque_jianding> list = db.ExecuteList<torque_jianding>(SQL, pList.ToArray());
            return list;
        }

        /// <summary>
        ///根据ID查询试验台测试数据
        /// </summary>
        /// <returns></returns>
        public torque_jianding JDListTo_DaysByCode(string ID)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            pList.Add(new MySqlParameter("@ID",new Guid(ID)));
            string SQL = @"select * from torque_jianding where ID = @ID AND deleted=0 ";
            List<torque_jianding> list = db.ExecuteList<torque_jianding>(SQL, pList.ToArray());
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 保存扭矩校验信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTorqueTestInfo(torque_jianding model)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@QJMC", model.QJMC));
            pList.Add(new MySqlParameter("@GGXH", model.GGXH));
            pList.Add(new MySqlParameter("@JLBH", model.JLBH));
            pList.Add(new MySqlParameter("@JDYJ", model.JDYJ));
            pList.Add(new MySqlParameter("@ZSBH", model.ZSBH));
            pList.Add(new MySqlParameter("@JDJL", model.JDJL));
            pList.Add(new MySqlParameter("@TYJSYQ", model.TYJSYQ));
            pList.Add(new MySqlParameter("@JDRQ", model.JDRQ));
            pList.Add(new MySqlParameter("@JDY", model.JDY));
            pList.Add(new MySqlParameter("@JCZ3", model.JCZ3));
            pList.Add(new MySqlParameter("@JCZ4", model.JCZ5));
            pList.Add(new MySqlParameter("@JCZ5", model.JCZ5));

            string SQL = @"insert into torque_jianding(ID,QJMC
                        ,GGXH
                        ,JLBH
                        ,JDYJ
                        ,ZSBH
                        ,JDJL,TYJSYQ,JDRQ,JDY,JCZ3,JCZ4,JCZ5) 
                         values(@ID,@QJMC
                        ,@GGXH
                        ,@JLBH
                        ,@JDYJ
                        ,@ZSBH
                        ,@JDJL,@TYJSYQ,@JDRQ,@JDY,@JCZ3,@JCZ4,@JCZ5)";

            int i = db.ExecuteNonQuery(SQL, pList.ToArray());
            return i > 0;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<torque_jianding> GetPagingBaseJD(torque_jianding model, out int totalCount)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (!string.IsNullOrEmpty(model.QJMC))
            {
                para += " and QJMC like CONCAT('%',@QJMC,'%') ";

                pList.Add(new MySqlParameter("@QJMC", model.QJMC));
            }

            if (!string.IsNullOrEmpty(model.JDRQ))
            {
                if (model.JDRQ == "今天")
                {
                    para += " AND to_days(JDRQ) = to_days(now()) ";
                }
                else if (model.JDRQ == "昨天")
                {
                    para += " AND TO_DAYS( NOW( ) ) - TO_DAYS(JDRQ) = 1 ";
                }
                else if (model.JDRQ == "近3天")
                {
                    para += " AND DATE_SUB(CURDATE(), INTERVAL 3 DAY) <= date(JDRQ) ";
                }
                else if (model.JDRQ == "近7天")
                {
                    para += " AND DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= date(JDRQ) ";
                }
                pList.Add(new MySqlParameter("@JDRQ", model.JDRQ));
            }

            string sql = "select count(*) from torque_jianding where 1=1 AND deleted=0 " + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select * from torque_jianding where 1=1 AND deleted=0 " + para;

            sql += " order by JDRQ desc limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<torque_jianding> list = db.ExecuteList<torque_jianding>(sql, pList.ToArray());

            return list;
        }
    }
}
