using RW.PMS.IDAL;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Data;
using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using MySql.Data.MySqlClient;
using RW.PMS.Model.Test;

namespace RW.PMS.DAL
{
    internal class DAL_Follow : IDAL_Follow
    {
        DAL_BaseInfo BaseInfoDal = new DAL_BaseInfo();

        #region 条码卡关联设置
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseBarcodeModel> GetFollowBarcodeForPage(BaseBarcodeModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.c_cardNo))
            {
                para += "and c_cardNo like CONCAT('%',@c_cardNo,'%')";
                pList.Add(new MySqlParameter("@c_cardNo", model.c_cardNo));
            }
            if (model.c_status != null && model.c_status != -1)
            {
                para += "and c_status = @c_status ";
                pList.Add(new MySqlParameter("@c_status", model.c_status));
            }
            if (model.c_cardType != null && model.c_cardType != -1)
            {
                para += "and c_cardType = @c_cardType ";
                pList.Add(new MySqlParameter("@c_cardType", model.c_cardType));
            }
            if (model.c_AmsGwID != null && model.c_AmsGwID != -1)
            {
                para += "and c_AmsGwID = @c_AmsGwID ";
                pList.Add(new MySqlParameter("@c_AmsGwID", model.c_AmsGwID));
            }

            string sql = @"select Count(*) from base_barcode bc
                                    left join base_gongwei gw on bc.c_curGwID = gw.ID
                                    left join base_gongwei gw1 on bc.c_AmsGwID = gw1.ID
                                    left join sys_baseData sb on bc.c_cardType = sb.ID
                                    left join sys_baseData sb1 on bc.c_curAreaID = sb1.ID
                                    where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select bc.id,c_cardNo,c_curStampNo,c_curComponentId,GetWLNameByWLID(c_curComponentId) c_curComponentName,c_cardType,sb.bdname as c_cardTypeText,c_AmsGwID,gw1.gwname as c_AmsGwText,c_putLocation,c_curAreaID,sb1.bdname as c_curAreaText,
                            c_curGwID,gw.gwname as c_curGwText,c_curFmGuid,c_curProdNo,c_status, case when c_status=0 then '启用' else '禁用' end as Status,c_remark
                            from base_barcode bc
                            left join base_gongwei gw on bc.c_curGwID = gw.ID
                            left join base_gongwei gw1 on bc.c_AmsGwID = gw1.ID
                            left join sys_baseData sb on bc.c_cardType = sb.ID
                            left join sys_baseData sb1 on bc.c_curAreaID = sb1.ID
                            where 1=1 " + para;

            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseBarcodeModel> list = db.ExecuteList<BaseBarcodeModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 获取条形码类型
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetCardType()
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,bdname from sys_baseData where bdtypeCode = 'barcodeType' ";
            List<BaseDataModel> list = db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 根据ID获取条码信息
        /// </summary>
        /// <param name="Id">条码信息表Id</param>
        /// <returns></returns>
        public BaseBarcodeModel GetFollowBarcodeId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select id,c_cardNo,c_cardType,c_AmsGwID,c_putLocation,c_curAreaID,c_curGwID,c_curFmGuid,c_curProdNo,c_curComponentId,c_curStampNo,c_status,c_remark 
from base_barcode where ID=@ID";
            pList.Add(new MySqlParameter("@ID", Id));
            List<BaseBarcodeModel> list = db.ExecuteList<BaseBarcodeModel>(sql, pList.ToArray());
            if (list.Count > 0)
                return list[0];

            return null;
        }

        /// <summary>
        /// 返回英文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceCharAZ(string str, out string number)
        {
            string old = "";
            number = "0";
            char[] carr = str.ToCharArray();
            for (int i = 0; i < carr.Length; i++)
            {
                if (Regex.IsMatch(carr[i].ToString(), "[A-Z]"))
                {
                    old += carr[i].ToString();
                }
                else
                {
                    number += carr[i];
                }
            }
            return old;
        }

        /// <summary>
        /// 新增条码
        /// </summary>
        /// <param name="model"></param>
        public void AddFollowBarcodeManyCard(BaseBarcodeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            int cardNum = Convert.ToInt32(model.Num);
            for (int i = 0; i < cardNum; i++)
            {
                //0的总数
                string english = "00000000000000000000";
                //返回的000001、数字
                string number;
                //返回英文
                string Num1 = ReplaceCharAZ(model.c_cardNo, out number);
                //总数量
                int count1 = model.c_cardNo.Length;
                //英文数量
                int count2 = Num1.Length;
                //8-2=6
                int sum = count1 - count2;
                //开始计算
                int Num2 = int.Parse(number) + i;
                //计算后的长度
                int Num3 = Num2.ToString().Length;
                //使用总长度-英文长度-计算的数字长度=占用的string长度
                int b = sum - Num3;
                //00000按照长度分割
                english = english.Substring(0, b);
                //拼接
                string Num4 = Num1 + english + Num2;

                bool isExist = GetSelectCard(Num4);
                if (isExist == false)
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = @"insert into base_barcode(c_cardNo,c_cardType,c_AmsGwID,c_status,c_remark) values(@c_cardNo,@c_cardType,@c_AmsGwID,@c_status,@c_remark)";
                    pList.Add(new MySqlParameter("@c_cardNo", Num4));
                    pList.Add(new MySqlParameter("@c_cardType", model.c_cardType));
                    pList.Add(new MySqlParameter("@c_AmsGwID", model.c_AmsGwID));
                    pList.Add(new MySqlParameter("@c_status", model.c_status));
                    pList.Add(new MySqlParameter("@c_remark", model.c_remark));
                    db.ExecuteNonQuery(sql, pList.ToArray());
                }
            }
        }

        /// <summary>
        /// 判断条形码是否存在
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public bool GetSelectCard(string CardNo)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select Count(*) from base_barcode where c_cardNo=@c_cardNo";
            pList.Add(new MySqlParameter("@c_cardNo", CardNo));
            int count = int.Parse(db.ExecuteScalar(sql, pList.ToArray()).ToString());
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 添加条形码信息
        /// </summary>
        /// <param name="model"></param>
        public void AddFollowBarcode(BaseBarcodeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into base_barcode(c_cardNo,c_cardType,c_AmsGwID,c_status,c_remark) values(@c_cardNo,@c_cardType,@c_AmsGwID,@c_status,@c_remark)";
            pList.Add(new MySqlParameter("@c_cardNo", model.c_cardNo));
            pList.Add(new MySqlParameter("@c_cardType", model.c_cardType));
            pList.Add(new MySqlParameter("@c_AmsGwID", model.c_AmsGwID));
            pList.Add(new MySqlParameter("@c_status", model.c_status));
            pList.Add(new MySqlParameter("@c_remark", model.c_remark));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 条形码信息修改
        /// </summary>
        /// <param name="model"></param>
        public void EditFollowBarcode(BaseBarcodeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update base_barcode set c_cardNo=@c_cardNo,c_cardType=@c_cardType,c_AmsGwID=@c_AmsGwID,c_status=@c_status,c_remark=@c_remark where id = @id";
            pList.Add(new MySqlParameter("@c_cardNo", model.c_cardNo));
            pList.Add(new MySqlParameter("@c_cardType", model.c_cardType));
            pList.Add(new MySqlParameter("@c_AmsGwID", model.c_AmsGwID));
            pList.Add(new MySqlParameter("@c_status", model.c_status));
            pList.Add(new MySqlParameter("@c_remark", model.c_remark));
            pList.Add(new MySqlParameter("@id", model.id));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除条形码信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFollowBarcode(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from base_barcode where id in(" + id + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 信息反馈管理

        /// <summary>
        /// 信息反馈分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<FollowAbnormalModel> GetPagingFollowFeedback(FollowAbnormalModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model != null)
            {
                if (model.fa_isok != -1 && model.fa_isok != null)
                {
                    para += " and fa_isok = @fa_isok ";
                    pList.Add(new MySqlParameter("@fa_isok", model.fa_isok));
                }

                if (model.fa_areaID != -1 && model.fa_areaID != null)
                {
                    para += " and fa_areaID = @fa_areaID ";
                    pList.Add(new MySqlParameter("@fa_areaID", model.fa_areaID));
                }
            }

            string sql = @"select Count(*) from follow_abnormal where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            sql = @"select ID,fa_orderCode,fa_gwID,fa_gwName,fa_areaID,fa_areaName,fa_operID,fa_oper,fa_createtime,fa_feedMemo,
                    fa_feedType,GetbdNameBybdID(fa_feedType) as fa_feedTypeText,fa_remark,fa_isok,fa_result from follow_abnormal
							    where 1=1 " + para;
            sql += "  order by fa_createtime desc limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<FollowAbnormalModel> lists = db.ExecuteList<FollowAbnormalModel>(sql, pList.ToArray());
            return lists;
        }

        /// <summary>
        /// 信息反馈子表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<FeedbackDetailModel> GetFeedbackDetail(FeedbackDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model != null)
            {
                if (model.id != 0)
                {
                    para += " and id = @id ";
                    pList.Add(new MySqlParameter("@id", model.id));
                }
            }
            string sql = @"select id,fdb_type,fId,fdb_img from follow_feedback_Detail where 1=1 " + para;
            List<FeedbackDetailModel> lists = db.ExecuteList<FeedbackDetailModel>(sql, pList.ToArray());
            return lists;
        }



        /// <summary>
        /// 信息反馈管理修改绑定
        /// </summary>
        /// <param name="Id">信息反馈表Id</param>
        /// <returns></returns>
        public FollowFeedbackModel GetFollowFeedbackId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,fb_orderCode,fb_gwID,fb_gwName,fb_areaID,fb_areaName,fb_operID,fb_oper,fb_createtime,fb_feedMemo,fb_feedType,fb_remark,fb_isok,fb_result from follow_feedback
							    where ID = @ID ";
            pList.Add(new MySqlParameter("@ID", Id));
            List<FollowFeedbackModel> lists = db.ExecuteList<FollowFeedbackModel>(sql, pList.ToArray());

            lists[0].DetailList = db.ExecuteList<FeedbackDetailModel>("select * from follow_feedback_Detail where fId = " + Id, null);
            return lists[0];
        }

        /// <summary>
        /// 异常反馈管理修改绑定
        /// </summary>
        /// <param name="Id">信息反馈表Id</param>
        /// <returns></returns>
        public FollowAbnormalModel GetFollowAbnormalId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,fa_orderCode,fa_gwID,fa_gwName,fa_areaID,fa_areaName,fa_operID,fa_oper,fa_createtime,fa_feedMemo,fa_feedType,fa_remark,fa_isok,fa_result,fa_agvstate from follow_abnormal
							    where ID = @ID ";
            pList.Add(new MySqlParameter("@ID", Id));
            List<FollowAbnormalModel> lists = db.ExecuteList<FollowAbnormalModel>(sql, pList.ToArray());

            return lists[0];
        }
        public bool SelectAGVstate(int areaID, int gwID, int operID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (areaID != 0)
            {
                para += " and fa_areaID = @fa_areaID ";
                pList.Add(new MySqlParameter("@fa_areaID", areaID));
            }

            if (gwID != 0)
            {
                para += " and fa_gwID = @fa_gwID ";
                pList.Add(new MySqlParameter("@fa_gwID", gwID));
            }
            if (operID != 0)
            {
                para += " and fa_operID = @fa_operID ";
                pList.Add(new MySqlParameter("@fa_operID", operID));
            }
            string sql = @"select ID,fa_orderCode,fa_gwID,fa_gwName,fa_areaID,fa_areaName,fa_operID,fa_oper,fa_createtime,fa_feedMemo,fa_feedType,GetbdNameBybdID(fa_feedType) as fa_feedTypeText,fa_remark,fa_isok,fa_result,fa_agvstate from follow_abnormal where 1=1 " + para;
            sql += " order by fa_createtime desc";
            List<FollowAbnormalModel> lists = db.ExecuteList<FollowAbnormalModel>(sql, pList.ToArray());

            foreach (FollowAbnormalModel item in lists)
            {
                if (item.fa_agvstate == 1)
                {

                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 信息反馈管理修改
        /// </summary>
        /// <param name="model"></param>
        public void EditFollowFeedback(FollowFeedbackModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"Update follow_feedback set fb_isok=@fb_isok,fb_result=@fb_result where ID = @ID";
            pList.Add(new MySqlParameter("@fb_isok", model.fb_isok));
            pList.Add(new MySqlParameter("@fb_result", model.fb_result));
            pList.Add(new MySqlParameter("@ID", model.ID));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 异常反馈管理修改
        /// </summary>
        /// <param name="model"></param>
        public void EditFollowAbnormal(FollowAbnormalModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"Update follow_abnormal set fa_isok=@fa_isok,fa_result=@fa_result,fa_agvstate=@fa_agvstate where ID = @ID";
            pList.Add(new MySqlParameter("@fa_isok", model.fa_isok));
            pList.Add(new MySqlParameter("@fa_result", model.fa_result));
            pList.Add(new MySqlParameter("@fa_agvstate", model.fa_agvstate));
            pList.Add(new MySqlParameter("@ID", model.ID));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
        }
        #endregion


        #region 条码卡使用记录查询
        /// <summary>
        /// 条码卡使用记录查询-分页查询-BS端显示用
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<FollowBarcodeLogModel> getFollowBarcodeLogForPage(FollowBarcodeLogModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.C_cardNo))
                {
                    para += " and bar.c_cardNo=@c_cardNo";
                    pList.Add(new MySqlParameter("@c_cardNo", model.C_cardNo.Trim()));
                }
                if (!string.IsNullOrEmpty(model.Fm_StampNo))
                {
                    para += " and bar.c_stampNo=@c_stampNo";
                    pList.Add(new MySqlParameter("@c_stampNo", model.Fm_StampNo.Trim()));
                }
                if (model.Fm_prodModelID != null && model.Fm_prodModelID != -1)
                {
                    para += " and pf.pf_prodModelID=@pf_prodModelID";
                    pList.Add(new MySqlParameter("@pf_prodModelID", model.Fm_prodModelID));
                }
                if (model.Fd_areaID != null && model.Fd_areaID != -1)
                {
                    para += " and bar.c_areaID=@c_areaID";
                    pList.Add(new MySqlParameter("@c_areaID", model.Fd_areaID));
                }
                if (model.Fd_gwID != null && model.Fd_gwID != -1)
                {
                    para += " and bar.c_gwID=@c_gwID";
                    pList.Add(new MySqlParameter("@c_gwID", model.Fd_gwID));
                }
                if (model.Fd_operID != null && model.Fd_operID != -1)
                {
                    para += " and bar.c_operID=@c_operID";
                    pList.Add(new MySqlParameter("@c_operID", model.Fd_operID));
                }
                if (!string.IsNullOrEmpty(model.Starttime))
                {
                    var starttime = DateTime.Parse(model.Starttime);
                    para += " and bar.c_createtime>=@starttime";
                    pList.Add(new MySqlParameter("@starttime", starttime));
                }
                if (!string.IsNullOrEmpty(model.Endtime))
                {
                    var endtime = DateTime.Parse(model.Endtime).AddDays(+1).AddSeconds(-1);
                    para += " and bar.c_createtime<=@endtime";
                    pList.Add(new MySqlParameter("@endtime", endtime));
                }
            }
            string sql = @" select Count(*) from follow_barcode_Log bar 
                                    left join  productInfo pf on bar.c_pInfoID=pf.pf_ID
                                    left join  v_productModel vpm on pf.pf_prodModelID=vpm.ID where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select bar.c_cardNo C_cardNo,pf.pf_prodModelID Fm_prodModelID,CONCAT_WS('-', vpm.Pname, vpm.Pmodel) ProdModel,
                            bar.c_areaID Fd_areaID,GetbdNameBybdID(bar.c_areaID) Fd_areaName,bar.c_stampNo Fm_StampNo,bar.c_gwID Fd_gwID,
                            GetGwNameByID(bar.c_gwID) Fd_gwName,bar.c_partId,GetWLNameByWLID(bar.c_partId) c_partName,
                            bar.c_createtime Fd_createtime,bar.c_operID Fd_operID,GetEmpNameByuID(bar.c_operID) Fd_oper,bar.c_remark C_remark
                            from follow_barcode_Log bar 
                            left join  productInfo pf on bar.c_pInfoID=pf.pf_ID
                            left join  v_productModel vpm on pf.pf_prodModelID=vpm.ID where 1=1" + para;
            sql += " ORDER BY bar.c_createtime desc";
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            return db.ExecuteList<FollowBarcodeLogModel>(sql, pList.ToArray());
        }

        #endregion

        #region 试验报表信息查看
        /// <summary>
        /// 试验报表信息查看
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TestResultMainModel> GetProductTestForPage(TestResultMainModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.LIKETrmProdNo))
                {
                    para += " and trm.trmProdNo like CONCAT('%', @LIKETrmProdNo, '%') ";
                    pList.Add(new MySqlParameter("@LIKETrmProdNo", "%" + model.LIKETrmProdNo + "%"));
                }

                if (!string.IsNullOrEmpty(model.pp_orderCode))
                {
                    para += " and pf.pp_orderCode like CONCAT('%', @pp_orderCode, '%') ";
                    pList.Add(new MySqlParameter("@pp_orderCode", "%" + model.pp_orderCode + "%"));
                }

                if (model.trmStartTime.HasValue)//开始时间
                {
                    para += " and trm.trmStartTime>=@trmStartTime";
                    pList.Add(new MySqlParameter("@trmStartTime", model.trmStartTime));
                }
                if (model.trmEndTime.HasValue)//截止时间
                {
                    para += " and trm.trmEndTime<=@trmEndTime";
                    pList.Add(new MySqlParameter("@trmEndTime", model.trmEndTime.Value.AddDays(+1).AddSeconds(-1)));
                }
            }

            string sql = @"select Count(*) from test_resultmain trm
                            left join productinfo pf on trm.pfID = pf.pf_ID
                            left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
                            left join base_productmodel pm on pm.ID = pf.pf_prodModelID where 1=1 " + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);
            sql = @"select trm.*,CONCAT_WS('-',pm.Pmodel,pm.DrawingNo) as PmodelDrawingNo,pf.pp_orderCode,pp.pp_projectName from test_resultmain trm
                    left join productinfo pf on trm.pfID = pf.pf_ID
                    left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
                    left join base_productmodel pm on pm.ID = pf.pf_prodModelID where 1=1 " + para;

            sql += " ORDER BY trm.trmStartTime desc limit " + model.PageIndex + "," + model.PageSize;
            List<TestResultMainModel> product_test = db.ExecuteList<TestResultMainModel>(sql, pList.ToArray());
            return product_test;
        }


        /// <summary>
        /// 试验报表明细信息查看
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TestResultDetailModel> GetTestResultDetailForPage(TestResultDetailModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (model.trmGUID.HasValue)
                {
                    //para += " and trm.trmProdNo like CONCAT('%', @LIKETrmProdNo, '%') ";
                    //pList.Add(new MySqlParameter("@LIKETrmProdNo", "%" + model.trmGUID + "%"));
                    para += " and rd.trmGUID = @trmGUID ";
                    pList.Add(new MySqlParameter("@trmGUID", model.trmGUID));
                }
            }

            string sql = @"select Count(*) from test_resultdetail rd 
                        left join test_resultmain rm on rd.trmGUID = rm.trmGUID
                        left join productinfo pf on pf.pf_ID = rm.pfID 
                        left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
                        left join base_productmodel pm on pm.ID = pf.pf_prodModelID
                        where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select rd.*,CONCAT_WS('-',pm.Pmodel,pm.DrawingNo) as PmodelDrawingNo,pf.pp_orderCode,rm.trmProdNo,pp.pp_projectName  from test_resultdetail rd 
                    left join test_resultmain rm on rd.trmGUID = rm.trmGUID
                    left join productinfo pf on pf.pf_ID = rm.pfID 
                    left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
                    left join base_productmodel pm on pm.ID = pf.pf_prodModelID
                    where 1=1 " + para;

            sql += " limit " + model.PageIndex + "," + model.PageSize;
            List<TestResultDetailModel> TestResultDetail = db.ExecuteList<TestResultDetailModel>(sql, pList.ToArray());
            return TestResultDetail;
        }

        #endregion

        #region 故障统计报表
        public List<HitchModel> GetHitchModelPage(HitchModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = @"SELECT pr.pf_prodNo as prodNo,vp.PID as prodID,Pname as prodName
                            ,vp.ID as prodModelID,CONCAT(Pname,'',Pmodel) as prodModelName
                            ,pf_carModelID as carModelID,GetbdNameBybdID(pf_carModelID) as carModelName
                            ,pf_carNo as carNo,fr_devID as devID
                            ,fr_devName as devName,GetbdNameBybdID(fr_faultCode) as faultCode
                            ,GetbdNameBybdID(fr_faultLevel) as faultLevel,GetbdNameBybdID(fr_faultClass) as faultClass
                            ,fr_faultCode as faultCodeId,fr_faultLevel as faultLevelId,fr_faultClass as faultClassId,fr_createtime as createtime
                            FROM follow_faultRepair as fo 
                            LEFT JOIN v_productModel as vp 
                            ON fo.pf_prodModelID=vp.ID
                            LEFT JOIN base_Device as de
                            ON fo.fr_devID=de.id 
                            LEFT JOIN productInfo as pr
                            ON fo.pf_prodNo=pr.pf_prodNo
                            WHERE 1=1 ";
            if (model != null)
            {

                if (!string.IsNullOrEmpty(model.prodNo))//生产编号
                {
                    sql += " and pr.pf_prodNo=@pf_prodNo";
                    plist.Add(new MySqlParameter("@pf_prodNo", model.prodNo));
                }
                if (model.prodModelID > 0)//产品型号id
                {
                    sql += " and vp.ID=@prodModelID";
                    plist.Add(new MySqlParameter("@prodModelID", model.prodNo));
                }
                if (model.carModelID > 0)//车型id
                {
                    sql += " and pf_carModelID=@pf_carModelID";
                    plist.Add(new MySqlParameter("@pf_carModelID", model.carModelID));
                }
                if (!string.IsNullOrEmpty(model.carNo))
                {
                    sql += " and pf_carNo=@pf_carNo";
                    plist.Add(new MySqlParameter("@pf_carNo", model.carNo));//车号
                }
                if (model.devID > 0)//设备
                {
                    sql += " and fr_devID=@fr_devID";
                    plist.Add(new MySqlParameter("@fr_devID", model.devID));

                }
                if (model.faultCodeId > 0)//故障代码
                {
                    sql += " and fr_faultCode=@fr_faultCode";
                    plist.Add(new MySqlParameter("@fr_faultCode", model.faultCodeId));
                }
                if (model.faultLevelId > 0)//故障级别
                {
                    sql += " and fr_faultLevel=@fr_faultLevel";
                    plist.Add(new MySqlParameter("@fr_faultLevel", model.faultLevelId));
                }
                if (model.faultClassId > 0)//故障类别
                {
                    sql += " and fr_faultClass=@fr_faultClass";
                    plist.Add(new MySqlParameter("@fr_faultClass", model.faultClassId));
                }
                if (!string.IsNullOrEmpty(model.Starttime))//开始时间
                {
                    var starttime = DateTime.Parse(model.Starttime);
                    sql += " and fr_createtime>=@starttime";
                    plist.Add(new MySqlParameter("@starttime", starttime));
                }
                if (!string.IsNullOrEmpty(model.Endtime))//结束时间
                {
                    var endtime = DateTime.Parse(model.Endtime).AddDays(+1).AddSeconds(-1);
                    sql += " and fr_createtime<=@endtime";
                    plist.Add(new MySqlParameter("@endtime", endtime));
                }
            }
            List<HitchModel> HitchModellist = db.ExecuteList<HitchModel>(sql, plist.ToArray());
            totalCount = HitchModellist.Count();
            HitchModellist = HitchModellist.OrderByDescending(x => x.createtime).Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize).ToList();

            return HitchModellist;
        }


        /// <summary>
        /// 获取故障情况（饼图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<HitchModel> GetHitchCircle(string Starttime, string Endtime)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(Starttime))
            {
                var starttime = DateTime.Parse(Starttime);                      //开始时间
                para += " and fr_createtime>=@starttime";
                pList.Add(new MySqlParameter("@starttime", starttime));
            }
            if (!string.IsNullOrEmpty(Endtime))
            {
                var endtime = DateTime.Parse(Endtime).AddDays(+1).AddSeconds(-1); //结束时间
                para += " and fr_createtime<=@Endtime";
                pList.Add(new MySqlParameter("@Endtime", endtime));
            }
            string sql = "select GetbdNameBybdID(fr_faultClass) faultClass,count(fr_faultClass) count from follow_faultRepair where 1=1 " + para;
            sql += " group by fr_faultClass";
            List<HitchModel> list = db.ExecuteList<HitchModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 获取故障情况 大屏（折线图)
        /// </summary>
        /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<HitchModel> GetHitchLine(string Starttime, string Endtime)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(Starttime))
            {
                var starttime = DateTime.Parse(Starttime);                      //开始时间
                para += " and fr_createtime>=@starttime";
                pList.Add(new MySqlParameter("@starttime", starttime));
            }
            if (!string.IsNullOrEmpty(Endtime))
            {
                var endtime = DateTime.Parse(Endtime).AddDays(+1).AddSeconds(-1); //结束时间
                para += " and fr_createtime<=@Endtime";
                pList.Add(new MySqlParameter("@Endtime", endtime));
            }
            string sql = "select GetbdNameBybdID(fr_faultLevel) faultLevel,count(fr_faultLevel) count from follow_faultRepair where 1=1 " + para;
            sql += " group by fr_faultLevel";
            List<HitchModel> list = db.ExecuteList<HitchModel>(sql, pList.ToArray());
            return list;
        }

        /// 获取故障情况（柱状图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<HitchModel> GetHitchPillar(string Starttime, string Endtime)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(Starttime))
            {
                var starttime = DateTime.Parse(Starttime);                      //开始时间
                para += " and fr_createtime>=@starttime";
                pList.Add(new MySqlParameter("@starttime", starttime));
            }
            if (!string.IsNullOrEmpty(Endtime))
            {
                var endtime = DateTime.Parse(Endtime).AddDays(+1).AddSeconds(-1); //结束时间
                para += " and fr_createtime<=@Endtime";
                pList.Add(new MySqlParameter("@Endtime", endtime));
            }
            string sql = "select date(fr_createtime) createtime,count(fr_createtime) count from follow_faultRepair where 1=1  " + para;
            sql += "  group by date(fr_createtime)";
            List<HitchModel> Hitchlist = db.ExecuteList<HitchModel>(sql, pList.ToArray());
            return Hitchlist;
        }

        #endregion

        #region 操作异常统计查询
        /// <summary>
        /// 操作异常统计分页查询
        /// </summary>
        /// <param name="model">操作异常实体</param>
        /// <param name="totalCount">总条数</param>
        /// <returns></returns>
        public List<OperateErrorModel> GetOperateErrorModelPage(OperateErrorModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            totalCount = 0;
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.prodNo))
                {
                    para += " and pr.pf_prodNo like CONCAT('%',@pf_prodNo,'%') "; //产品编号
                    pList.Add(new MySqlParameter("@pf_prodNo", model.prodNo));
                }
                if (model.prodModelID.HasValue && model.prodModelID > 0)
                {
                    para += " and pr.pf_prodModelID=@pf_prodModelID";//产品型号id
                    pList.Add(new MySqlParameter("@pf_prodModelID", model.prodModelID));
                }
                //if (model.carModelID.HasValue && model.carModelID > 0)
                //{
                //              //车型id
                //}
                if (!string.IsNullOrEmpty(model.pf_compartNo))
                {
                    para += " and pr.pf_compartNo like CONCAT('%',@pf_compartNo,'%') "; //车厢号
                    pList.Add(new MySqlParameter("@pf_compartNo", model.pf_compartNo));
                }
                if (model.errorId.HasValue && model.errorId > 0)
                {
                    para += " and p.ErrorTypeID=@ErrorTypeID";  //异常类型id
                    pList.Add(new MySqlParameter("@ErrorTypeID", model.errorId));
                }
                if (!string.IsNullOrEmpty(model.Starttime))
                {
                    var starttime = DateTime.Parse(model.Starttime);                      //开始时间
                    para += " and p.errDate>=@starttime";
                    pList.Add(new MySqlParameter("@starttime", starttime));
                }
                if (!string.IsNullOrEmpty(model.Endtime))
                {
                    var endtime = DateTime.Parse(model.Endtime).AddDays(+1).AddSeconds(-1); //结束时间
                    para += " and p.errDate<=@Endtime";
                    pList.Add(new MySqlParameter("@Endtime", endtime));
                }
                string sql = @"select count(*) from assembly_errorInfo as p 
                                       left join productInfo as pr ON p.pInfo_ID=pr.pf_ID
                                       left join v_productModel as vp ON pr.pf_prodModelID=vp.ID
                                       where p.ErrorTypeID != 21 and p.ErrorTypeID != 0 " + para;
                int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

                sql = @"select pr.pf_prodNo as prodNo,pf_ID as pInfo_ID,PID as prodID,Pname as prodName,vp.ID as prodModelID,Pmodel as prodModelName,
                                ErrorTypeID as errorId,GetbdNameBybdID(ErrorTypeID) as errName,err_operID as OperId,err_oper as OperName,errDate as ErrDate,pr.pf_compartNo,pr.pf_bogieNo 
                                from assembly_errorInfo as p
                                left join productInfo as pr ON p.pInfo_ID=pr.pf_ID
                                left join v_productModel as vp ON pr.pf_prodModelID=vp.ID
                                where p.ErrorTypeID != 21 and p.ErrorTypeID != 0  " + para;
                sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
                List<OperateErrorModel> Errlist = db.ExecuteList<OperateErrorModel>(sql, pList.ToArray());
                return Errlist;
            }

            return null;

        }


        /// <summary>
        /// 获取异常情况（饼图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<OperateErrorModel> GetOperateErrorCircle(string Starttime, string Endtime)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(Starttime))
            {
                var starttime = DateTime.Parse(Starttime);                      //开始时间
                para += " and errDate>=@starttime";
                pList.Add(new MySqlParameter("@starttime", starttime));
            }
            if (!string.IsNullOrEmpty(Endtime))
            {
                var endtime = DateTime.Parse(Endtime).AddDays(+1).AddSeconds(-1); //结束时间
                para += " and errDate<=@Endtime";
                pList.Add(new MySqlParameter("@Endtime", endtime));
            }
            string sql = @"select GetbdNameBybdID(ErrorTypeID) errName,count(ErrorTypeID) AnomalyCount
                                   from assembly_errorInfo
                                   where ErrorTypeID!=21 and ErrorTypeID!=0" + para;
            sql += " GROUP BY ErrorTypeID";
            List<OperateErrorModel> list = db.ExecuteList<OperateErrorModel>(sql, pList.ToArray());
            return list;
        }


        /// 获取异常情况（折线图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<OperateErrorModel> GetOperateErrorLine(string Starttime, string Endtime)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(Starttime))
            {
                var starttime = DateTime.Parse(Starttime);                      //开始时间
                para += " and errDate>=@starttime";
                pList.Add(new MySqlParameter("@starttime", starttime));
            }
            if (!string.IsNullOrEmpty(Endtime))
            {
                var endtime = DateTime.Parse(Endtime).AddDays(+1).AddSeconds(-1); //结束时间
                para += " and errDate<=@Endtime";
                pList.Add(new MySqlParameter("@Endtime", endtime));
            }
            string sql = @"select err_oper OperName,count(err_oper) AnomalyCount
                                   from assembly_errorInfo
                                   where ErrorTypeID!=21 and ErrorTypeID!=0" + para;
            sql += " GROUP BY err_oper";
            List<OperateErrorModel> Errlist = db.ExecuteList<OperateErrorModel>(sql, pList.ToArray());
            return Errlist;
        }


        /// 获取异常情况（柱状图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<OperateErrorModel> GetOperateErrorPillar(string Starttime, string Endtime)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(Starttime))
            {
                var starttime = DateTime.Parse(Starttime);                      //开始时间
                para += " and errDate>=@starttime";
                pList.Add(new MySqlParameter("@starttime", starttime));
            }
            if (!string.IsNullOrEmpty(Endtime))
            {
                var endtime = DateTime.Parse(Endtime).AddDays(+1).AddSeconds(-1); //结束时间
                para += " and errDate<=@Endtime";
                pList.Add(new MySqlParameter("@Endtime", endtime));
            }
            string sql = @"select date(errDate) ErrDate,count(errDate) AnomalyCount
                                   from assembly_errorInfo
                                   where ErrorTypeID!=21 and ErrorTypeID!=0" + para;
            sql += " group by date(errDate)";
            List<OperateErrorModel> Errlist = db.ExecuteList<OperateErrorModel>(sql, pList.ToArray());
            return Errlist;
        }


        #endregion

        #region 故障报修

        /// <summary>
        /// 故障报修分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<FollowFaultRepairModel> GetFollowFaultRepairForPage(FollowFaultRepairModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = @"SELECT
	                                fr.id AS ID,
	                                fr_devID AS Fr_devID,
	                                devName AS Fr_devName,
	                                fr_operID AS Fr_operID,
	                                op.empName AS Fr_oper,
	                                fr_createtime AS Fr_createtime,
	                                fr_faultCode AS Fr_faultCode,
	                                fr_faultLevel AS Fr_faultLevel,
	                                fr_faultClass AS Fr_faultClass,
	                                GetbdNameBybdID (fr_faultCode) AS FaultCodeName,
	                                GetbdNameBybdID (fr_faultLevel) AS FaultLevelName,
	                                GetbdNameBybdID (fr_faultClass) AS FaultClassName,
	                                pf_prodModelID,
	                                Pmodel AS ProdModel,
	                                pf_carModelID AS Pf_carModelID,
	                                GetbdNameBybdID (pf_carModelID) AS CarModel,
	                                pf_carNo AS Pf_carNo,
	                                pf_prodNo AS Pf_prodNo,
	                                fr_faultMemo AS Fr_faultMemo,
	                                fr_repairMemo AS Fr_repairMemo,
	                                fr_emergency AS Fr_emergency,
	                                GetbdNameBybdID (fr_emergency) AS Emergency,
	                                bdvalue AS BdValue,
	                                fr_solve_time AS Fr_solve_time,
	                                fr_solve_operID AS Fr_solve_operID,
	                                sol.empName AS Fr_solve_oper,
	                                fr_solve_reason AS Fr_solve_reason,
	                                fr_solve_method AS Fr_solve_method,
	                                fr_status AS Fr_status,
	                                fr_status AS Fr_status,
	                                fr_remark AS Fr_remark
                                FROM follow_faultRepair AS fr
                                LEFT JOIN base_Device AS dev ON fr.fr_devID = dev.id
                                LEFT JOIN sys_User AS op ON fr.fr_operID = op.userID
                                LEFT JOIN base_productModel AS pd ON fr.pf_prodModelID = pd.ID
                                LEFT JOIN sys_User AS sol ON fr.fr_solve_operID = sol.userID
                                LEFT JOIN sys_baseData AS bd ON fr.fr_emergency = bd.ID
                                WHERE 1 = 1 ";
            if (model != null)
            {
                if (model.Fr_devID != -1 && model.Fr_devID != null)
                {
                    sql += " and fr_devID=@fr_devID";
                    plist.Add(new MySqlParameter("@fr_devID", model.Fr_devID));
                }

                if (!string.IsNullOrEmpty(model.Pf_prodNo))
                {
                    sql += " and pf_prodNo=@pf_prodNo";
                    plist.Add(new MySqlParameter("@pf_prodNo", model.Pf_prodNo));
                }

                if (model.Fr_status != -1 && model.Fr_status != null)
                {
                    sql += " and fr_status=@fr_status";
                    plist.Add(new MySqlParameter("@fr_status", model.Fr_status));
                }

                if (model.Fr_faultLevel != -1 && model.Fr_faultLevel != null)
                {
                    sql += " and fr_faultLevel=@fr_faultLevel";
                    plist.Add(new MySqlParameter("@fr_faultLevel", model.Fr_faultClass));
                }

                if (model.Fr_faultClass != -1 && model.Fr_faultClass != null)
                {
                    sql += " and fr_faultClass=@fr_faultClass";
                    plist.Add(new MySqlParameter("@fr_faultClass", model.Fr_faultClass));
                }

                if (model.Fr_emergency != -1 && model.Fr_emergency != null)
                {
                    sql += " and fr_emergency=@fr_emergency";
                    plist.Add(new MySqlParameter("@fr_emergency", model.Fr_emergency));
                }
            }
            List<FollowFaultRepairModel> list = db.ExecuteList<FollowFaultRepairModel>(sql, plist.ToArray());
            totalCount = list.Count();
            list = list.OrderByDescending(x => x.Fr_status).OrderBy(x => x.BdValue).Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize).ToList();
            return list;
        }

        /// <summary>
        /// 故障报修根据ID获取数据
        /// </summary>
        /// <param name="Id">故障报修表Id</param>
        /// <returns></returns>
        public FollowFaultRepairModel GetFollowFaultRepairId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = @"SELECT id as ID,fr_devID as Fr_devID,fr_devName as Fr_devName,fr_operID as Fr_operID,fr_oper as Fr_oper
                                ,fr_createtime as Fr_createtime,fr_faultCode as Fr_faultCode,fr_faultLevel as Fr_faultLevel,fr_faultClass as Fr_faultClass
                                ,pf_prodModelID as Pf_prodModelID,pf_carModelID as Pf_carModelID,pf_carNo as Pf_carNo,pf_prodNo as Pf_prodNo
                                ,fr_faultMemo as Fr_faultMemo,fr_repairMemo as Fr_repairMemo,fr_emergency as Fr_emergency,fr_solve_time as Fr_solve_time
                                ,fr_solve_operID as Fr_solve_operID,fr_solve_oper as Fr_solve_oper,fr_solve_reason as Fr_solve_reason,fr_solve_method as Fr_solve_method
                                ,fr_status as Fr_status,fr_remark as Fr_remark
                                FROM follow_faultRepair 
                                WHERE id=@id";
            plist.Add(new MySqlParameter("@id", Id));
            var list = db.ExecuteList<FollowFaultRepairModel>(sql, plist.ToArray());
            if (list.Count > 0)
                return list[0];
            return null;
        }

        /// <summary>
        /// 修改故障报修信息
        /// </summary>
        /// <param name="model"></param>
        public void EditFollowFaultRepair(FollowFaultRepairModel model)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = @"UPDATE follow_faultRepair SET fr_solve_time=@Fr_solve_time,fr_solve_operID=@Fr_solve_operID,fr_solve_oper=@Fr_solve_oper,
                                   fr_solve_reason=@Fr_solve_reason,fr_solve_method=@Fr_solve_method,fr_status=@Fr_status,fr_remark=@Fr_remark WHERE id=@ID";
            plist.Add(new MySqlParameter("@Fr_solve_time", model.Fr_solve_time));
            plist.Add(new MySqlParameter("@Fr_solve_operID", model.Fr_solve_operID));
            plist.Add(new MySqlParameter("@Fr_solve_oper", model.Fr_solve_oper));
            plist.Add(new MySqlParameter("@Fr_solve_reason", model.Fr_solve_reason));
            plist.Add(new MySqlParameter("@Fr_solve_method", model.Fr_solve_method));
            plist.Add(new MySqlParameter("@Fr_status", model.Fr_status));
            plist.Add(new MySqlParameter("@Fr_remark", model.Fr_remark));
            plist.Add(new MySqlParameter("@ID", model.ID));
            db.ExecuteNonQuery(sql, plist.ToArray());
        }

        #endregion

        #region 电机产品信息查询

        /// <summary>
        /// 生产产品信息 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfoList(ProductInfoModel model)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model.pf_prodNo != null)
            {
                para += " and pf_prodNo like CONCAT('%',@pf_prodNo,'%') ";
                pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
            }

            if (model.pf_prodModelID != null && model.pf_prodModelID !=0)
            {
                para += " and pf_prodModelID=@pf_prodModelID ";
                pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
            }
 
           string sql = @"select pf.pf_ID,pf.pf_prodNo,pf.pf_serialNumber,bt.Pname,pf.pf_prodModelID,bl.Pmodel,pf.pf_startTime,pf.pf_finishTime,pf.pf_finishStatus from productinfo pf
                      left join base_productmodel bl on bl.ID = pf.pf_prodModelID
                      left join base_product bt on bt.ID = bl.PID
                      where 1=1  " + para;

            sql += " ORDER BY pf_ID ";

            List<ProductInfoModel> list = db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());

            return list;
        }


        #endregion

        #region CS端

        #region 信息反馈
        /// <summary>
        /// 查询反馈
        /// </summary>
        /// <param name="fbareaID">区域</param>
        /// <param name="fbgwID">工位</param>
        /// <param name="fboperID">用户</param>
        /// <returns></returns>
        public List<FollowFeedbackModel> GetFollowfeedback(int fbareaID, int fbgwID, int fboperID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (fbareaID != 0)
            {
                para += " and fb_areaID = @fb_areaID ";
                pList.Add(new MySqlParameter("@fb_areaID", fbareaID));
            }

            if (fbgwID != 0)
            {
                para += " and fb_gwID = @fb_gwID ";
                pList.Add(new MySqlParameter("@fb_gwID", fbgwID));
            }
            if (fbgwID != 0)
            {
                para += " and fb_operID = @fb_operID ";
                pList.Add(new MySqlParameter("@fb_operID", fboperID));
            }
            string sql = @"select ID,fb_orderCode,fb_gwID,fb_gwName,fb_areaID,fb_areaName,fb_operID,fb_oper,fb_createtime,fb_feedMemo,fb_feedType,GetbdNameBybdID(fb_feedType) as fb_feedTypeText,fb_remark,fb_isok,fb_result from follow_feedback where 1=1 " + para;
            sql += " order by fb_createtime desc";
            List<FollowFeedbackModel> lists = db.ExecuteList<FollowFeedbackModel>(sql, pList.ToArray());
            return lists;
        }


        /// <summary>
        /// 查询反馈
        /// </summary>
        /// <param name="fbareaID">区域</param>
        /// <param name="fbgwID">工位</param>
        /// <param name="fboperID">用户</param>
        /// <returns></returns>
        public List<FollowAbnormalModel> GetFollowAbnormal(int fbareaID, int fbgwID, int fboperID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (fbareaID != 0)
            {
                para += " and fa_areaID = @fa_areaID ";
                pList.Add(new MySqlParameter("@fa_areaID", fbareaID));
            }

            if (fbgwID != 0)
            {
                para += " and fa_gwID = @fa_gwID ";
                pList.Add(new MySqlParameter("@fa_gwID", fbgwID));
            }
            if (fbgwID != 0)
            {
                para += " and fa_operID = @fa_operID ";
                pList.Add(new MySqlParameter("@fa_operID", fboperID));
            }
            string sql = @"select ID,fa_orderCode,fa_gwID,fa_gwName,fa_areaID,fa_areaName,fa_operID,fa_oper,fa_createtime,fa_feedMemo,fa_feedType,GetbdNameBybdID(fa_feedType) as fa_feedTypeText,fa_remark,fa_isok,fa_result from follow_abnormal where 1=1 " + para;
            sql += " order by fa_createtime desc";
            List<FollowAbnormalModel> lists = db.ExecuteList<FollowAbnormalModel>(sql, pList.ToArray());
            return lists;
        }

        /// <summary>
        /// APP保存信息反馈
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertFeeback(FollowFeedbackModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                List<MySqlParameter> pList = new List<MySqlParameter>();
                int ID = 0;
                string sql = "";
                try
                {
                    if (model == null || model.fb_oper == null)
                    {
                        return false;
                    }

                    string strCode = "";
                    strCode = db.GetSerialNumber("follow_feedback", "FB", 4);//调用存储过程获取流水号

                    sql = @"insert into follow_feedback(fb_orderCode,fb_gwID,fb_gwName,fb_areaID,fb_areaName,fb_operID,fb_oper,fb_createtime,fb_feedMemo,fb_feedType,fb_isok,fb_remark) 
                                    values(@fb_orderCode,@fb_gwID,@fb_gwName,@fb_areaID,@fb_areaName,@fb_operID,@fb_oper,@fb_createtime,@fb_feedMemo,@fb_feedType,@fb_isok,@fb_remark)";
                    pList.Add(new MySqlParameter("@fb_orderCode", strCode));
                    pList.Add(new MySqlParameter("@fb_gwID", model.fb_gwID));
                    pList.Add(new MySqlParameter("@fb_gwName", model.fb_gwName));
                    pList.Add(new MySqlParameter("@fb_areaID", model.fb_areaID));
                    pList.Add(new MySqlParameter("@fb_areaName", model.fb_areaName));
                    pList.Add(new MySqlParameter("@fb_operID", model.fb_operID));
                    pList.Add(new MySqlParameter("@fb_oper", model.fb_oper));
                    pList.Add(new MySqlParameter("@fb_createtime", db.GetServerTime()));
                    pList.Add(new MySqlParameter("@fb_feedMemo", model.fb_feedMemo));
                    pList.Add(new MySqlParameter("@fb_feedType", model.fb_feedType));
                    pList.Add(new MySqlParameter("@fb_remark", "APP"));
                    pList.Add(new MySqlParameter("@fb_isok", 0));
                    var Result = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    sql = @"select @@IDENTITY";
                    pList.Clear();
                    ID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();

                    #region 子表follow_feedback_Detail新增

                    foreach (var item in model.DetailList)
                    {
                        sql = @"insert into follow_feedback_Detail(fdb_type,fId,fdb_img) 
                                    values(0,@fId,@fdb_img)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@fId", ID));
                        pList.Add(new MySqlParameter("@fdb_img", item.fdb_img));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    }
                    #endregion

                    myTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                }
                finally
                {
                    myTrans.Dispose();
                }
                return true;
            }

        }

        /// <summary>
        /// 保存信息反馈
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddFollow_Feedback(FollowFeedbackModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string strCode = "";
            strCode = db.GetSerialNumber("follow_feedback", "FB", 4);//调用存储过程获取流水号

            string sql = @"insert into follow_feedback(fb_orderCode,fb_gwID,fb_gwName,fb_areaID,fb_areaName,fb_operID,fb_oper,fb_createtime,fb_feedMemo,fb_feedType,fb_isok,fb_remark) 
                                    values(@fb_orderCode,@fb_gwID,@fb_gwName,@fb_areaID,@fb_areaName,@fb_operID,@fb_oper,@fb_createtime,@fb_feedMemo,@fb_feedType,@fb_isok,@fb_remark)";
            pList.Add(new MySqlParameter("@fb_orderCode", strCode));
            pList.Add(new MySqlParameter("@fb_gwID", model.fb_gwID));
            pList.Add(new MySqlParameter("@fb_gwName", model.fb_gwName));
            pList.Add(new MySqlParameter("@fb_areaID", model.fb_areaID));
            pList.Add(new MySqlParameter("@fb_areaName", model.fb_areaName));
            pList.Add(new MySqlParameter("@fb_operID", model.fb_operID));
            pList.Add(new MySqlParameter("@fb_oper", model.fb_oper));
            pList.Add(new MySqlParameter("@fb_createtime", model.fb_createtime));
            pList.Add(new MySqlParameter("@fb_feedMemo", model.fb_feedMemo));
            pList.Add(new MySqlParameter("@fb_feedType", model.fb_feedType));
            pList.Add(new MySqlParameter("@fb_remark", model.fb_remark));
            pList.Add(new MySqlParameter("@fb_isok", model.fb_isok));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
            return Result > 0 ? true : false;
        }

        /// <summary>
        /// 保存异常反馈
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddFollow_Abnormal(FollowAbnormalModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string strCode = "";
            strCode = db.GetSerialNumber("follow_abnormal", "FA", 4);//调用存储过程获取流水号

            string sql = @"insert into follow_abnormal(fa_orderCode,fa_gwID,fa_gwName,fa_areaID,fa_areaName,fa_operID,fa_oper,fa_createtime,fa_feedMemo,fa_feedType,fa_isok,fa_remark,fa_agvstate) 
                                    values(@fa_orderCode,@fa_gwID,@fa_gwName,@fa_areaID,@fa_areaName,@fa_operID,@fa_oper,@fa_createtime,@fa_feedMemo,@fa_feedType,@fa_isok,@fa_remark,@fa_agvstate)";
            pList.Add(new MySqlParameter("@fa_orderCode", strCode));
            pList.Add(new MySqlParameter("@fa_gwID", model.fa_gwID));
            pList.Add(new MySqlParameter("@fa_gwName", model.fa_gwName));
            pList.Add(new MySqlParameter("@fa_areaID", model.fa_areaID));
            pList.Add(new MySqlParameter("@fa_areaName", model.fa_areaName));
            pList.Add(new MySqlParameter("@fa_operID", model.fa_operID));
            pList.Add(new MySqlParameter("@fa_oper", model.fa_oper));
            pList.Add(new MySqlParameter("@fa_createtime", model.fa_createtime));
            pList.Add(new MySqlParameter("@fa_feedMemo", model.fa_feedMemo));
            pList.Add(new MySqlParameter("@fa_feedType", model.fa_feedType));
            pList.Add(new MySqlParameter("@fa_remark", model.fa_remark));
            pList.Add(new MySqlParameter("@fa_isok", model.fa_isok));
            pList.Add(new MySqlParameter("@fa_agvstate", model.fa_agvstate));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
            return Result > 0 ? true : false;
        }

        /// <summary>
        /// 修改程序信息
        /// </summary>
        /// <param name="program"></param>
        public bool UpdateFollow_Feedback(FollowFeedbackModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update follow_feedback set fb_gwID=@fb_gwID,fb_gwName=@fb_gwName,fb_areaID=@fb_areaID,fb_areaName=@fb_areaName,
                                    fb_operID=@fb_operID,fb_oper=@fb_oper,fb_createtime=@fb_createtime,fb_feedMemo=@fb_feedMemo,fb_feedType=@fb_feedType,fb_remark=@fb_remark
                                    where ID = @ID";
            pList.Add(new MySqlParameter("@fb_gwID", model.fb_gwID));
            pList.Add(new MySqlParameter("@fb_gwName", model.fb_gwName));
            pList.Add(new MySqlParameter("@fb_areaID", model.fb_areaID));
            pList.Add(new MySqlParameter("@fb_areaName", model.fb_areaName));
            pList.Add(new MySqlParameter("@fb_operID", model.fb_operID));
            pList.Add(new MySqlParameter("@fb_oper", model.fb_oper));
            pList.Add(new MySqlParameter("@fb_createtime", model.fb_createtime));
            pList.Add(new MySqlParameter("@fb_feedMemo", model.fb_feedMemo));
            pList.Add(new MySqlParameter("@fb_feedType", model.fb_feedType));
            pList.Add(new MySqlParameter("@fb_remark", model.fb_remark));
            pList.Add(new MySqlParameter("@ID", model.ID));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
            return Result > 0 ? true : false;
        }

        /// <summary>
        /// 修改异常反馈信息
        /// </summary>
        /// <param name="program"></param>
        public bool UpdateFollow_Abnormal(FollowAbnormalModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update follow_abnormal set fa_gwID=@fa_gwID,fa_gwName=@fa_gwName,fa_areaID=@fa_areaID,fa_areaName=@fa_areaName,
                                    fa_operID=@fa_operID,fa_oper=@fa_oper,fa_createtime=@fa_createtime,fa_feedMemo=@fa_feedMemo,fa_feedType=@fa_feedType,fa_remark=@fa_remark,fa_agvstate=@fa_agvstate
                                    where ID = @ID";
            pList.Add(new MySqlParameter("@fa_gwID", model.fa_gwID));
            pList.Add(new MySqlParameter("@fa_gwName", model.fa_gwName));
            pList.Add(new MySqlParameter("@fa_areaID", model.fa_areaID));
            pList.Add(new MySqlParameter("@fa_areaName", model.fa_areaName));
            pList.Add(new MySqlParameter("@fa_operID", model.fa_operID));
            pList.Add(new MySqlParameter("@fa_oper", model.fa_oper));
            pList.Add(new MySqlParameter("@fa_createtime", model.fa_createtime));
            pList.Add(new MySqlParameter("@fa_feedMemo", model.fa_feedMemo));
            pList.Add(new MySqlParameter("@fa_feedType", model.fa_feedType));
            pList.Add(new MySqlParameter("@fa_remark", model.fa_remark));
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@fa_agvstate", model.fa_agvstate));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
            return Result > 0 ? true : false;
        }


        /// <summary>
        /// 删除信息反馈
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteFollow_Feedback(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from follow_feedback where ID=" + id;
            List<follow_feedback> list = db.ExecuteList<follow_feedback>(sql, pList.ToArray());
            if (list.Count == 0)
            {
                throw new Exception(string.Format("没有找到信息反馈编号为{0}的信息！", id));
            }
            sql = "delete from follow_feedback where ID=" + id;
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }
        /// <summary>
        /// 查询AGV是否启用
        /// </summary>
        /// <param name="id"></param>
        public bool SelectAGVstateId(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select bdvalue from sys_basedata where ID=" + id;

            DataSet ds = db.ExecuteDataSet(sql, pList.ToArray());

            if (Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]) == 1)
            {
                return false;
            };
 
            return true;
        }
        /// <summary>
        /// 删除异常反馈
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteFollow_Abnormal(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from follow_abnormal where ID=" + id;
            List<follow_abnormal> list = db.ExecuteList<follow_abnormal>(sql, pList.ToArray());
            if (list.Count == 0)
            {
                throw new Exception(string.Format("没有找到异常反馈编号为{0}的信息！", id));
            }
            sql = "delete from follow_abnormal where ID=" + id;
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i > 0;
        }
        #endregion

        #region 故障报修
        /// <summary>
        /// 故障报修绑定数据
        /// </summary>
        /// <param name="IP">IP</param>
        /// <returns></returns>
        public List<FollowFaultRepairModel> GetFollowFaultRepair(string IP)
        {
            //fr.fr_emergency as Emergency
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select fr.id as ID,fr.fr_devID as Fr_devID,dev.devName as Fr_devName
                                ,dev.devIP as IP,op.empName as Fr_oper,fr.fr_createtime as Fr_createtime,GetbdNameBybdID(fr.fr_faultCode) as FaultCodeName
                                ,GetbdNameBybdID(fr.fr_faultLevel) as FaultLevelName
                                ,GetbdNameBybdID(fr.fr_faultClass) as FaultClassName,Pmodel as ProdModel,GetbdNameBybdID(pf_carModelID) as CarModel
                                ,fr.pf_carNo as Pf_carNo,fr.pf_prodNo as Pf_prodNo
                                ,fr.fr_faultMemo as Fr_faultMemo,fr.fr_repairMemo as Fr_repairMemo,GetbdNameBybdID(fr.fr_emergency) as Emergency
                                ,bd.bdvalue as BdValue,fr.fr_solve_time as Fr_solve_time,sol.empName as Fr_solve_oper
                                ,fr.fr_solve_reason as Fr_solve_reason,fr.fr_solve_method as Fr_solve_method,fr.fr_status as Fr_status
                                ,fr.fr_remark as Fr_remark from follow_faultRepair as fr LEFT JOIN
                                base_Device as dev  on fr.fr_devID=dev.id LEFT JOIN
                                sys_User as op on fr.fr_operID=op.userID LEFT JOIN
                                base_productModel as pd on fr.pf_prodModelID=pd.ID LEFT JOIN
                                sys_User as sol on fr.fr_solve_operID=sol.userID LEFT JOIN
                                sys_baseData as bd on fr.fr_emergency=bd.ID WHERE dev.devIP=@IP
                                ORDER BY fr.fr_status,bd.bdvalue ASC  ";
            pList.Add(new MySqlParameter("@IP", IP));
            var list = db.ExecuteList<FollowFaultRepairModel>(sql, pList.ToArray());
            return list;
        }
        /// <summary>
        /// 新增故障报修
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddFollow_FaultRepair(FollowFaultRepairModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"INSERT into follow_faultRepair (fr_devID,fr_devName,fr_operID,fr_oper,fr_createtime,fr_faultCode,fr_faultLevel,fr_faultClass,
                                   pf_prodModelID,pf_carModelID,pf_carNo,pf_prodNo,fr_faultMemo,fr_repairMemo,fr_emergency,fr_status,fr_remark)VALUES(@fr_devID,
                                   @fr_devName,@fr_operID,@fr_oper,@fr_createtime,@fr_faultCode,@fr_faultLevel,@fr_faultClass,@pf_prodModelID,@pf_carModelID,
                                   @pf_carNo,@pf_prodNo,@fr_faultMemo,@fr_repairMemo,@fr_emergency,0,@fr_remark)";
            pList.Add(new MySqlParameter("@fr_devID", model.Fr_devID));
            pList.Add(new MySqlParameter("@fr_devName", model.Fr_devName));
            pList.Add(new MySqlParameter("@fr_operID", model.Fr_operID));
            pList.Add(new MySqlParameter("@fr_oper", model.Fr_oper));
            pList.Add(new MySqlParameter("@fr_createtime", model.Fr_createtime));
            pList.Add(new MySqlParameter("@fr_faultCode", model.Fr_faultCode));
            pList.Add(new MySqlParameter("@fr_faultLevel", model.Fr_faultLevel));
            pList.Add(new MySqlParameter("@fr_faultClass", model.Fr_faultClass));
            pList.Add(new MySqlParameter("@pf_prodModelID", model.Pf_prodModelID));
            pList.Add(new MySqlParameter("@pf_carModelID", model.Pf_carModelID));
            pList.Add(new MySqlParameter("@pf_carNo", model.Pf_carNo));
            pList.Add(new MySqlParameter("@pf_prodNo", model.Pf_prodNo));
            pList.Add(new MySqlParameter("@fr_faultMemo", model.Fr_faultMemo));
            pList.Add(new MySqlParameter("@fr_repairMemo", model.Fr_repairMemo));
            pList.Add(new MySqlParameter("@fr_emergency", model.Fr_emergency));
            pList.Add(new MySqlParameter("@fr_remark", model.Fr_remark));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
            if (i > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改故障报修信息
        /// </summary>
        /// <param name="program"></param>
        public bool UpdateFollow_FaultRepair(FollowFaultRepairModel model)
        {
            if (Getentity(model.ID) == null)
            {
                throw new Exception(string.Format("没有找到故障报修编号为{0}的信息！", model.ID));
            }
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"UPDATE follow_faultRepair SET fr_devID=@fr_devID,fr_devName=@fr_devName,fr_operID=@fr_operID,
                                   fr_oper=@fr_oper,fr_createtime=@fr_createtime,fr_faultCode=@fr_faultCode,fr_faultLevel=@fr_faultLevel,
                                   fr_faultClass=@fr_faultClass,pf_prodModelID=@pf_prodModelID,pf_carModelID=@pf_carModelID,pf_carNo=@pf_carNo,
                                   pf_prodNo=@pf_prodNo,fr_faultMemo=@fr_faultMemo,fr_repairMemo=@fr_repairMemo,fr_emergency=@fr_emergency,fr_remark=@fr_remark WHERE id=@id ";
            pList.Add(new MySqlParameter("@fr_devID", model.Fr_devID));
            pList.Add(new MySqlParameter("@fr_devName", model.Fr_devName));
            pList.Add(new MySqlParameter("@fr_operID", model.Fr_operID));
            pList.Add(new MySqlParameter("@fr_oper", model.Fr_oper));
            pList.Add(new MySqlParameter("@fr_createtime", model.Fr_createtime));
            pList.Add(new MySqlParameter("@fr_faultCode", model.Fr_faultCode));
            pList.Add(new MySqlParameter("@fr_faultLevel", model.Fr_faultLevel));
            pList.Add(new MySqlParameter("@fr_faultClass", model.Fr_faultClass));
            pList.Add(new MySqlParameter("@pf_prodModelID", model.Pf_prodModelID));
            pList.Add(new MySqlParameter("@pf_carModelID", model.Pf_carModelID));
            pList.Add(new MySqlParameter("@pf_carNo", model.Pf_carNo));
            pList.Add(new MySqlParameter("@pf_prodNo", model.Pf_prodNo));
            pList.Add(new MySqlParameter("@fr_faultMemo", model.Fr_faultMemo));
            pList.Add(new MySqlParameter("@fr_repairMemo", model.Fr_repairMemo));
            pList.Add(new MySqlParameter("@fr_emergency", model.Fr_emergency));
            pList.Add(new MySqlParameter("@fr_remark", model.Fr_remark));
            pList.Add(new MySqlParameter("@id", model.ID));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
            if (i > 0)
            {
                return true;
            }
            return false;
        }

        public follow_faultRepair Getentity(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select *from follow_faultRepair where id=@id";
            pList.Add(new MySqlParameter("@id", id));
            var follow_faultRepair = db.ExecuteList<follow_faultRepair>(sql, pList.ToArray());
            if (follow_faultRepair.Count() == 0)
            {
                return null;
            }
            return follow_faultRepair[0];


        }

        /// <summary>
        /// 删除故障报修信息
        /// </summary>
        /// <param name="id">主表ID</param>
        public bool DeleteFollow_FaultRepair(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            if (Getentity(id) == null)
            {
                throw new Exception(string.Format("没有找到故障报修编号为{0}的信息！", id));
            }
            string sql = "DELETE from follow_faultRepair WHERE id=@id";
            pList.Add(new MySqlParameter("@id", id));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
            if (i > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        /// <summary>
        /// 根据卡号获取卡表信息
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public BaseBarcodeModel GetBarcodeByCardNo(string cardNo)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select * from base_barcode where c_cardNo=@c_cardNo ";
            pList.Add(new MySqlParameter("@c_cardNo", cardNo));
            List<BaseBarcodeModel> list = db.ExecuteList<BaseBarcodeModel>(sql, pList.ToArray());
            if (list.Count == 0) return null;
            return list[0];
        }


      



      
       


        /// <summary>
        /// 获取发货区数据
        /// </summary>
        /// <param name="pf_prodNo">生产编号</param>
        /// <param name="ProdModelID">产品型号</param>
        /// <param name="pf_carModelID">车型</param>
        /// <param name="fp_repairTypeID">检修类型</param>
        /// <param name="fm_curAreaID">当前区域</param>
        /// <param name="fm_finishStatus">追溯状态</param>
        /// <param name="isSend">是否发货</param>
        /// <returns></returns>
        public List<FollowProductSendModel> GetFollowProductSendData(string pf_prodNo, int ProdModelID, int pf_carModelID, int fp_repairTypeID, int fm_curAreaID, int fm_finishStatus, int isSend)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(pf_prodNo))
            {
                para += " and pf_prodNo like CONCAT('%',@pf_prodNo,'%') ";
                pList.Add(new MySqlParameter("@pf_prodNo", pf_prodNo));
            }
            if (ProdModelID != -1)
            {
                para += " and pf.pf_prodModelID = @ProdModelID ";
                pList.Add(new MySqlParameter("@ProdModelID", ProdModelID));
            }
            if (pf_carModelID != -1)
            {
                para += " and  si.subwayType = @subwayType ";
                pList.Add(new MySqlParameter("@subwayType", pf_carModelID));
            }
            if (fp_repairTypeID != -1)
            {
                para += " and fp.fp_repairTypeID = @fp_repairTypeID ";
                pList.Add(new MySqlParameter("@fp_repairTypeID", fp_repairTypeID));
            }
            if (fm_finishStatus != -1)
            {
                para += " and fm_finishStatus = @fm_finishStatus ";
                pList.Add(new MySqlParameter("@fm_finishStatus", fm_finishStatus));
            }
            if (isSend != -1 && isSend != 0)
            {
                para += " and fs.isSend = @isSend ";
                pList.Add(new MySqlParameter("@isSend", isSend));
            }
            if (fm_curAreaID != -1 && fm_curAreaID != 0)
            {
                para += "and fm.fm_curAreaID=@fm_curAreaID ";
                pList.Add(new MySqlParameter("@fm_curAreaID", fm_curAreaID));
            }

            string sql = @"select 
                                    pf.pf_prodNo,fp.fp_prodNo_sys,vpm.Pname as Pname,pf.pf_prodModelID,vpm.Pmodel as Pmodel,
                                    si.subwayType,GetbdNameBybdID(si.subwayType) as subwayTypeText,si.carNo as carNoText,
                                    si.groups,pf.pf_factoryID,GetbdNameBybdID(pf.pf_factoryID) as factoryText,
                                    fp.fp_repairTypeID,GetbdNameBybdID(fp.fp_repairTypeID) as repairTypeText,pf.pf_stampNo,
                                    fm.fm_guid,fm.fp_guid,fm.pInfo_ID,si.ID as subwayInfoID,fm.fm_curAreaID,GetbdNameBybdID(fm.fm_curAreaID) as curAreaText,fm.fm_curGwID,
                                    fm.fm_curGw,fs.isSend,fs.sender,su.empName as sendText,fs.sendTime,fm.fm_finishStatus,
                                    fm.fm_warehouse,fm.fm_remark
                                    from follow_main fm
                                    left join follow_send fs on fm.fm_guid = fs.fm_guid
                                    left join productInfo pf on fm.pInfo_ID = pf.pf_ID
                                    left join subwayInfo si on pf.pf_subwayInfoID = si.ID
                                    left join v_productModel vpm on pf.pf_prodModelID = vpm.ID
                                    left join follow_production fp on pf.pf_ID = fp.fp_pInfo_ID
                                    left join sys_User su on fs.sender = su.userID
                                    where 1=1 " + para;

            List<FollowProductSendModel> list = db.ExecuteList<FollowProductSendModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 修改发货信息
        /// </summary>
        /// <param name="fm_guid"></param>
        /// <param name="EmpId"></param>
        /// <returns></returns>
        public bool UpdateSend(FollowProductSendModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                bool ret = false;
                try
                {
                    //根据当前fm_guid判断是否存在检修记录信息
                    string dtfm = "select * from follow_main where fm_guid = @fm_guid ";
                    pList.Add(new MySqlParameter("@fm_guid", model.fm_guid));
                    DataTable dt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, dtfm, pList.ToArray());
                    if (dt.Rows.Count != 0)
                    {

                        #region 添加follow_send发货表记录表、修改follow_main、follow_production表状态等

                        //查询发货表是否存在当前追溯信息的发货记录
                        string sendExist = "select * from follow_send where fm_guid = @fm_guid ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@fm_guid", model.fm_guid));
                        DataTable dtSend = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, sendExist, pList.ToArray());
                        if (dtSend.Rows.Count <= 0)
                        {
                            string addsql = @"insert into follow_send (fm_guid,fp_guid,pInfo_ID,send_subwayInfoID,send_compartNo,send_bogieNo,isSend,sendTime,sender)
                                                    values(@fm_guid,@fp_guid,@pInfo_ID,@send_subwayInfoID,@send_compartNo,@send_bogieNo,@isSend,@sendTime,@sender)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@fm_guid", model.fm_guid));
                            pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
                            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
                            pList.Add(new MySqlParameter("@send_subwayInfoID", model.send_subwayInfoID));
                            pList.Add(new MySqlParameter("@send_compartNo", model.send_compartNo));
                            pList.Add(new MySqlParameter("@send_bogieNo", model.send_bogieNo));
                            pList.Add(new MySqlParameter("@isSend", model.isSend));
                            pList.Add(new MySqlParameter("@sendTime", model.sendTime));
                            pList.Add(new MySqlParameter("@sender", model.sender));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, addsql, pList.ToArray());
                        }
                        else
                        {
                            string updatesql = @"update follow_send set fp_guid=@fp_guid,pInfo_ID=@pInfo_ID,send_subwayInfoID=@send_subwayInfoID,send_compartNo=@send_compartNo,
                                                    send_bogieNo=@send_bogieNo,isSend=@isSend,sendTime=@sendTime,sender=@sender  where fm_guid = @fm_guid ";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
                            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
                            pList.Add(new MySqlParameter("@send_subwayInfoID", model.send_subwayInfoID));
                            pList.Add(new MySqlParameter("@send_compartNo", model.send_compartNo));
                            pList.Add(new MySqlParameter("@send_bogieNo", model.send_bogieNo));
                            pList.Add(new MySqlParameter("@isSend", model.isSend));
                            pList.Add(new MySqlParameter("@sendTime", model.sendTime));
                            pList.Add(new MySqlParameter("@sender", model.sender));
                            pList.Add(new MySqlParameter("@fm_guid", model.fm_guid));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, updatesql, pList.ToArray());
                        }

                        //修改检修记录主表
                        string updatefm = @"update follow_main set fm_finishStatus=@fm_finishStatus,fm_curAreaID=@fm_curAreaID,fm_curGwID=@fm_curGwID,fm_curGw=@fm_curGw,fm_resultIsOK=1 where fm_guid = @fm_guid ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@fm_finishStatus", 4));
                        pList.Add(new MySqlParameter("@fm_curAreaID", model.fm_curAreaID));
                        pList.Add(new MySqlParameter("@fm_curGwID", model.fm_curGwID));
                        pList.Add(new MySqlParameter("@fm_curGw", model.fm_curGw));
                        pList.Add(new MySqlParameter("@fm_guid", model.fm_guid));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, updatefm, pList.ToArray());


                        //修改产品表
                        string updatefp = @"update follow_production set fp_finishTime=@fp_finishTime,fp_finishStatus=@fp_finishStatus,
                                                    fp_resultIsOK=@fp_resultIsOK,fp_resultMemo=@fp_resultMemo where fp_guid = @fp_guid ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@fp_finishStatus", 1));
                        pList.Add(new MySqlParameter("@fp_finishTime", model.sendTime));
                        pList.Add(new MySqlParameter("@fp_resultIsOK", 1));
                        pList.Add(new MySqlParameter("@fp_resultMemo", "合格"));
                        pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, updatefp, pList.ToArray());


                        #endregion

                        #region 解绑

                        string barcode = "select id,c_cardNo from base_barcode where c_curFmGuid = @fm_guid ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@fm_guid", model.fm_guid));
                        DataTable dtbarcode = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, barcode, pList.ToArray());

                        foreach (DataRow barcodes in dtbarcode.Rows)
                        {
                            if (!string.IsNullOrEmpty(barcodes["c_cardNo"].ToString()) && barcodes["ID"].ToInt() != 0)
                            {
                                string updatebarcode = @"update base_barcode set c_curAreaID=0,c_curGwID=0,c_curFmGuid='00000000-0000-0000-0000-000000000000',c_curProdNo='',
                                                                c_curComponentId=0,c_curStampNo='',c_status=0 where id=@id ";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@id", barcodes["ID"].ToInt()));
                                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, updatebarcode, pList.ToArray());
                            }
                        }

                        #endregion

                        myTrans.Commit();
                        ret = true;
                    }
                }
                catch
                {
                    myTrans.Rollback();
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }

        /// <summary>
        /// 获取当前区域的已关联的RFID卡，大部件,  拆卸区大组件
        /// </summary>
        /// <param name="fm_guid">产品线追溯主表GUID</param>
        /// <param name="areaID">当前区域ID</param>
        /// <param name="pmodelID">产品型号ID</param>
        /// <param name="componentId">组件ID，制动柜拆卸传0</param>
        /// <param name="stampNo">钢印号，组件拆解区传</param>
        /// <returns></returns>
        //public List<BarcodeFollowDetailModel> GetRFIDcardByAreaFmGuid(Guid fm_guid, int areaID, int pmodelID, int componentId, string stampNo, string barcode, int gwID)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        string strtemp1 = string.Empty;
        //        string strtemp2 = string.Empty;

        //        if (componentId > 0)
        //        {
        //            strtemp1 = " and plj.componentId=" + componentId.ToString();
        //            strtemp2 = " and fd.fd_stampNo='" + stampNo.ToString() + "' ";

        //            if (!string.IsNullOrEmpty(barcode))
        //            {
        //                strtemp2 = " and fd.fd_barcode='" + barcode + "'";
        //            }
        //        }

        //        string sql = string.Format(@"select prod.pf_prodModelID,fd.fd_wuliaoLJid as wuliaoLJid,fd.fd_wuliaoLJName as wlname,fd.fd_barcode,fd.fd_componentId,fd.fd_componentName,fd.fd_stampNo,fd.fd_isCancel,
        //              fd.fd_guid,isnull(fd.fd_isWuliaoBox,0) as fd_isWuliaoBox,fd_isNextScan,fd_checkResult  
        //              from follow_main fm 
        //              inner join productInfo prod on fm.pInfo_ID = prod.pf_ID
        //              inner join follow_detail fd on fm.fm_guid=fd.fm_guid 
        //              and fd.fd_areaID={0} and fm.fm_guid='{1}' and fd.fd_gwID={2} {3}  ", areaID, fm_guid, strtemp2, gwID);


        //        var result = context.Database.SqlQuery<BarcodeFollowDetailModel>(sql).ToList();

        //        return result;
        //    }
        //}

        /// <summary>
        /// 修改追溯明细表rfid卡的撤销状态
        /// </summary>
        /// <param name="fd_guid">明细表guid</param>
        /// <param name="isCancel">撤销状态：0：取消撤销；1：撤销</param>
        /// <returns></returns>
        //public void ChangeRFIDisCancel(Guid fd_guid, int isCancel)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var detail = context.follow_detail.Where(f => f.fd_guid == fd_guid).FirstOrDefault();
        //        if (detail != null)
        //        {
        //            detail.fd_isCancel = isCancel;

        //            context.SaveChanges();
        //        }

        //    }
        //}

      
       

        /// <summary>
        /// 更换条码卡信息
        /// </summary>
        /// <param name="oldModel">老卡实体</param>
        /// <param name="newModel">新卡实体</param>
        /// <returns>msg</returns>
        public string ReplacementBarCode(BaseBarcodeModel oldModel, BaseBarcodeModel newModel)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                string sql = "";
                int i = 0;
                try
                {
                    //旧卡信息替换至新卡中
                    sql = @"update base_barcode set c_status=@c_status,c_curAreaID=@c_curAreaID,c_curGwID=@c_curGwID,c_curFmGuid=@c_curFmGuid,c_curProdNo=@c_curProdNo
                    ,c_curComponentId=@c_curComponentId,c_curStampNo=@c_curStampNo,c_remark=@c_remark where id=@id ";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@id", newModel.id));
                    pList.Add(new MySqlParameter("@c_status", oldModel.c_status));
                    pList.Add(new MySqlParameter("@c_curAreaID", oldModel.c_curAreaID));
                    pList.Add(new MySqlParameter("@c_curGwID", oldModel.c_curGwID));
                    pList.Add(new MySqlParameter("@c_curFmGuid", oldModel.c_curFmGuid));
                    pList.Add(new MySqlParameter("@c_curProdNo", oldModel.c_curProdNo));
                    pList.Add(new MySqlParameter("@c_curComponentId", oldModel.c_curComponentId));
                    pList.Add(new MySqlParameter("@c_curStampNo", oldModel.c_curStampNo));
                    pList.Add(new MySqlParameter("@c_remark", oldModel.c_remark));
                    i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //添加绑定记录表
                    sql = @"insert follow_barcode_log(c_cardNo,c_cardType,c_pInfoID,c_partId,c_stampNo,c_operID,c_createtime,c_remark) 
values(@c_cardNo,@c_cardType,@c_pInfoID,@c_partId,@c_stampNo,@c_operID,now(),@c_remark)";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@c_cardNo", newModel.c_cardNo));
                    pList.Add(new MySqlParameter("@c_cardType", oldModel.c_cardType));
                    pList.Add(new MySqlParameter("@c_pInfoID", oldModel.c_pInfoID));
                    pList.Add(new MySqlParameter("@c_partId", oldModel.c_curComponentId));
                    pList.Add(new MySqlParameter("@c_stampNo", oldModel.c_curStampNo));
                    pList.Add(new MySqlParameter("@c_operID", oldModel.c_operID));
                    pList.Add(new MySqlParameter("@c_remark", "更换条码卡操作，将" + oldModel.c_cardNo + "更换为" + newModel.c_cardNo));
                    i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //将新卡信息存至旧卡
                    sql = @"update base_barcode set c_status=@c_status,c_curAreaID=@c_curAreaID,c_curGwID=@c_curGwID,c_curFmGuid=@c_curFmGuid,c_curProdNo=@c_curProdNo
                    ,c_curComponentId=@c_curComponentId,c_curStampNo=@c_curStampNo,c_remark=@c_remark where id=@id ";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@id", oldModel.id));
                    pList.Add(new MySqlParameter("@c_status", newModel.c_status));
                    pList.Add(new MySqlParameter("@c_curAreaID", newModel.c_curAreaID));
                    pList.Add(new MySqlParameter("@c_curGwID", newModel.c_curGwID));
                    pList.Add(new MySqlParameter("@c_curFmGuid", newModel.c_curFmGuid));
                    pList.Add(new MySqlParameter("@c_curProdNo", newModel.c_curProdNo));
                    pList.Add(new MySqlParameter("@c_curComponentId", newModel.c_curComponentId));
                    pList.Add(new MySqlParameter("@c_curStampNo", newModel.c_curStampNo));
                    pList.Add(new MySqlParameter("@c_remark", newModel.c_remark));
                    i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    if (newModel.c_status == 1)
                    {
                        sql = @"insert follow_barcode_log(c_cardNo,c_cardType,c_pInfoID,c_partId,c_stampNo,c_operID,c_createtime,c_remark) 
values(@c_cardNo,@c_cardType,@c_pInfoID,@c_partId,@c_stampNo,@c_operID,now(),@c_remark)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@c_cardNo", oldModel.c_cardNo));
                        pList.Add(new MySqlParameter("@c_cardType", newModel.c_cardType));
                        pList.Add(new MySqlParameter("@c_pInfoID", newModel.c_pInfoID));
                        pList.Add(new MySqlParameter("@c_partId", newModel.c_curComponentId));
                        pList.Add(new MySqlParameter("@c_stampNo", newModel.c_curStampNo));
                        pList.Add(new MySqlParameter("@c_operID", newModel.c_operID));
                        pList.Add(new MySqlParameter("@c_remark", "更换条码卡操作，将" + newModel.c_cardNo + "更换为" + oldModel.c_cardNo));
                        i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    }

                    //修改换卡后产品明细记录
                    sql = @"update follow_detail set fd_barcode=@newfd_barcode where fm_guid=@fm_guid and fd_barcode=@oldfd_barcode";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@fm_guid", oldModel.c_curFmGuid));
                    pList.Add(new MySqlParameter("@oldfd_barcode", oldModel.c_cardNo));
                    pList.Add(new MySqlParameter("@newfd_barcode", newModel.c_cardNo));
                    i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    myTrans.Commit();
                    return "";
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


    }
}




