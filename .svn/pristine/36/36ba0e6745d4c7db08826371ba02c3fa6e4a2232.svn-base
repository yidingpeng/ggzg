using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Sys;
using RW.PMS.Utils;
using RW.PMS.WinForm.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Follow
{
    public partial class FrmProductSendArea : Form
    {
        IBLL_System Systembll = DIService.GetService<IBLL_System>();
        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Follow BLL = DIService.GetService<IBLL_Follow>();

        private int frm_empId = 0;
        private string frm_empName = "";
        private string frm_areaID = "";
        private string frm_gwID = "";
        private string frm_gwName = "";
        private string frm_areaName = "";
        private string frm_areaCode = "";
        private int frm_beforeAreaID = 0;

        //网络通讯
        private System.Threading.Thread PingNet = null;
        private bool isPing = true;
        private int timerSecond = 10;//ping服务器网络的秒数，从配置表里取pingServerTimer(S)
        private string ServerIP = "";//网络服务器地址

        /// <summary>
        /// 发货系统
        /// </summary>
        public FrmProductSendArea()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            frm_empId = PublicVariable.CurEmpID;
            frm_empName = PublicVariable.CurEmpName;
            frm_gwID = PublicVariable.CurGwID.ToString();
            frm_gwName = PublicVariable.CurGwName;
            frm_areaID = PublicVariable.CurAreaID.ToString();
            frm_areaName = PublicVariable.CurAreaName;
            frm_areaCode = PublicVariable.CurAreaBDCode;
            frm_beforeAreaID = PublicVariable.BeforeAreaID;

            //if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.productCacheArea.ToString()) { this.Text = "产品缓冲区"; }//产品缓冲区 
            //if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.sendArea.ToString()) { this.Text = "发货区"; }//发货区 

        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmProductSendArea_Load(object sender, EventArgs e)
        {
            SetEmpGongweiRight();
            //绑定下拉
            BingDDL();
            //绑定DataGridView
            bindData();
            //获取服务器地址
            ServerIP = PublicVariable.ServerIP;
            if (ServerIP == "")
            {
                MessageBox.Show("获取服务器地址失败！请检查网络");
                return;
            }

            //状态栏显示
            this.toolStripStatusLabel1.Text = "当前区域：" + frm_areaName + "-" + PublicVariable.CurGwName + " (" + PublicVariable.LocalIP + ")";
            this.toolStripStatusLabel2.Text = "当前登陆用户：" + frm_empName;
            this.toolStripStatusLabel3.Text = "网络通讯状态：";
            this.toolStripStatusLabel4.Text = "当前系统时间：" + PublicVariable.GetServerTime().ToString("yyyy-MM-dd HH:mm:ss");

            if (PingNet == null)
            {
                PingNet = new System.Threading.Thread(PingNetThread);
                PingNet.IsBackground = true;
                PingNet.Start();
            }
        }

        /// <summary>
        /// ping服务器
        /// </summary>
        private void PingNetThread()
        {
            try
            {
                while (isPing)
                {
                    string pingMsg = "";
                    bool connectServer = NetworkHelper.Ping(out pingMsg, ServerIP, timerSecond);
                    if (connectServer == false)
                    {
                        this.toolStripStatusLabel3.Text = "网络通讯状态：连接异常";
                        toolStripStatusLabel3.ForeColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = "网络通讯状态：连接正常";
                        toolStripStatusLabel3.ForeColor = Color.Green;
                    }
                    Thread.Sleep(timerSecond * 1000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        private void BingDDL()
        {
            try
            {
                //车型
                List<BaseDataModel> dtcarmodel = Systembll.GetBaseDataTypeValue("subwayType");
                dtcarmodel.Insert(0, new BaseDataModel { ID = -1, bdname = "--请选择--" });
                cmbCarModel.DataSource = dtcarmodel;
                cmbCarModel.ValueMember = "ID";
                cmbCarModel.DisplayMember = "Bdname";

                //检修类型
                List<BaseDataModel> dtRepairType = Systembll.GetBaseDataTypeValue("repairType");
                dtRepairType.Insert(0, new BaseDataModel { ID = -1, bdname = "--请选择--" });
                cmbRepairType.DataSource = dtRepairType;
                cmbRepairType.ValueMember = "ID";
                cmbRepairType.DisplayMember = "Bdname";

                //产品-型号
                List<BaseProductModelModel> dtProdModel = Basebll.GetProductModel();
                dtProdModel.Insert(0, new BaseProductModelModel { ID = -1, Pmodel = "--请选择--" });
                cmbProdModel.DataSource = dtProdModel;
                cmbProdModel.ValueMember = "ID";
                cmbProdModel.DisplayMember = "Pmodel";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void bindData()
        {
            string fm_prodNo = txtProdNo.Text.Trim();
            //设置下拉默认选中值
            int pmodelID = ConvertHelper.ToInt32(cmbProdModel.SelectedValue, -1);
            int carModelID = ConvertHelper.ToInt32(cmbCarModel.SelectedValue, -1);
            int repairType = ConvertHelper.ToInt32(cmbRepairType.SelectedValue, -1);
            int isSend = 0;

            int finishStatus = -1;
            if (rdbNotSend.Checked)
                finishStatus = (int)EDAEnums.FollowStatus.notFinish;
            if (rdbDoneNotsend.Checked)
                finishStatus = (int)EDAEnums.FollowStatus.finished;
            if (rdbError.Checked)
                finishStatus = ConvertHelper.ToInt32(EDAEnums.FollowStatus.errorDown, 2);
            if (rdbSended.Checked)
                isSend = 1;
            if (rdbAll.Checked)
                isSend = -1;

            //显示该区域的追溯信息
            List<FollowProductSendModel> datalist = null;
            //if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.productCacheArea.ToString()) { datalist = BLL.GetFollowProductSendData(fm_prodNo, pmodelID, carModelID, repairType, PublicVariable.CurAreaID, finishStatus, isSend); }//产品缓冲区 
            if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.sendArea.ToString()) { datalist = BLL.GetFollowProductSendData(fm_prodNo, pmodelID, carModelID, repairType, 0, finishStatus, isSend); }//发货区

            dataGridView1.DataSource = datalist;

            for (int i = 0; i < datalist.Count(); i++)
            {
                // 2019 - 10 - 29 修改 fm_isSend  && ConvertHelper.ToInt32(datalist[i].isSend, -1) == -1
                if (ConvertHelper.ToInt32(datalist[i].fm_finishStatus, -1) == Convert.ToInt32(EDAEnums.FollowStatus.finished))
                {
                    dataGridView1.Rows[i].Cells["colbtnCall"].Value = "呼叫AGV";
                    dataGridView1.Rows[i].Cells["colbtnSend"].Value = "发货";
                }
                else
                {
                    dataGridView1.Rows[i].Cells["colbtnCall"].Value = "";
                    dataGridView1.Rows[i].Cells["colbtnSend"].Value = "";
                }
            }
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnQuery_Click(object sender, EventArgs e)
        {
            //绑定DataGridView
            bindData();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            txtProdNo.Text = "";
            cmbProdModel.SelectedValue = "-1";
            cmbCarModel.SelectedValue = "-1";
            cmbRepairType.SelectedValue = "-1";
            rdbNotSend.Checked = true;
            rdbDoneNotsend.Checked = false;
            rdbError.Checked = false;
            rdbSended.Checked = false;
            rdbAll.Checked = false;
            //绑定DataGridView
            bindData();
        }

        /// <summary>
        /// 异常下线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnError_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("异常下线后不能恢复！确定要异常下线吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    try
            //    {
            //        #region 异常下线更改所有追溯表、装配表的状态，记录日志
            //        string strProdNoSys = dataGridView1.SelectedRows.Count > 0 ? dataGridView1.SelectedRows[0].Cells["fp_prodNo_sys"].Value.ToString() : "";
            //        if (strProdNoSys == "")
            //        {
            //            MessageBox.Show("当前选中行GUID为空！");
            //            return;
            //        }
            //        var errDownCode_follow = ConvertHelper.ToInt32(EDAEnums.FollowStatus.errorDown, 2);
            //        var errDownCode_ams = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.errorDown, 2);
            //        int errTypeID = Systembll.GetBaseDataId("ErrorOffline");
            //        int EmpId = PublicVariable.CurEmpID;
            //        string EmpName = PublicVariable.CurEmpName;
            //        int GwId = PublicVariable.CurGwID;
            //        string GwName = PublicVariable.CurGwName;
            //        //调用异常下线功能
            //        var Followbll = DIService.GetService<IBLL_Follow>();
            //        Followbll.ProdErrorOffLine(strProdNoSys, errDownCode_follow, errDownCode_ams, errTypeID, "", Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, "产品追溯信息异常下线", EmpId, EmpName, GwId, GwName);
            //        MessageBox.Show("异常下线成功!");
            //        //刷新 绑定DataGridView
            //        bindData();

            //        #endregion
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("异常下线失败！" + ex.Message);
            //    }
            //}
        }


        /// <summary>
        /// 信息反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnFeedBack_Click(object sender, EventArgs e)
        {
            UI.Follow.FrmFollowFeedback frm = new UI.Follow.FrmFollowFeedback();
            frm.ShowDialog();
        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmProductSendArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            //考勤记录录入登出时间
            int i = DIService.GetService<IBLL_System>().SaveLogoutTime(PublicVariable.CurEmpID);
        }

        /// <summary>
        /// 当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel4.Text = "当前系统时间：" + PublicVariable.GetServerTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 未完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbNotSend_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Columns["colbtnCall"].Visible = false;
            this.dataGridView1.Columns["colbtnSend"].Visible = true;
            //绑定DataGridView
            bindData();
        }

        /// <summary>
        /// 已完成，未发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbDoneNotsend_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Columns["colbtnCall"].Visible = false;
            this.dataGridView1.Columns["colbtnSend"].Visible = true;
            //绑定DataGridView
            bindData();
        }

        /// <summary>
        /// 已发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbSended_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Columns["colbtnCall"].Visible = false;
            this.dataGridView1.Columns["colbtnSend"].Visible = false;
            //绑定DataGridView
            bindData();
        }

        /// <summary>
        /// 异常下线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbError_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Columns["colbtnCall"].Visible = false;
            this.dataGridView1.Columns["colbtnSend"].Visible = false;
            //绑定DataGridView
            bindData();
        }

        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            //绑定DataGridView
            bindData();
        }


        /// <summary>
        /// 触发DataGridView行控件点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                    if (column is DataGridViewButtonColumn)
                    {
                        if (column.Name == "colbtnCall")
                        {
                            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "呼叫AGV")
                            {
                                if (MessageBox.Show("确定要呼叫AGV吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    string fm_warehouse = dataGridView1.Rows[e.RowIndex].Cells["fm_warehouse"].Value.ToString();
                                    if (fm_warehouse == "" || fm_warehouse == "0")
                                    {
                                        MessageBox.Show("仓库号信息错误！");
                                        return;
                                    }
                                    ////呼叫AGV，连接socket
                                    //FrmCallAGV frmCallAgv = new FrmCallAGV(fm_warehouse);
                                    //DialogResult ddr = frmCallAgv.ShowDialog();
                                    //if (ddr == DialogResult.OK)
                                    //{
                                    //    MessageBox.Show("呼叫成功！");
                                    //    //dataGridView_check.Rows[e.RowIndex].Cells["col_NGreason"].Value = frmNGreason.NGreason;
                                    //    //if (frmCallAgv.checkResult == 0)
                                    //    //    dataGridView_check.Rows[e.RowIndex].Cells["RFIDcardNo"].Value = "";
                                    //}
                                }
                            }
                        }
                        else if (column.Name == "colbtnSend")
                        {
                            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "发货")
                            {
                                if (MessageBox.Show("确定要发货吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    //发货时修改追溯主表的是否发货、发货人、发货时间信息
                                    string strfm_guid = dataGridView1.Rows[e.RowIndex].Cells["fm_guid"].Value.ToString();
                                    string strfp_guid = dataGridView1.Rows[e.RowIndex].Cells["fp_guid"].Value.ToString();
                                    string strpInfo_ID = dataGridView1.Rows[e.RowIndex].Cells["pInfo_ID"].Value.ToString();
                                    string strsubwayInfoID = dataGridView1.Rows[e.RowIndex].Cells["subwayInfoID"].Value == null ? "0" : dataGridView1.Rows[e.RowIndex].Cells["subwayInfoID"].Value.ToString();
                                    FollowProductSendModel model = new FollowProductSendModel();
                                    model.fm_guid = new Guid(strfm_guid);
                                    model.fp_guid = new Guid(strfp_guid);
                                    model.pInfo_ID = strpInfo_ID.ToInt();
                                    model.send_subwayInfoID = strsubwayInfoID.ToInt();
                                    model.sendTime = PublicVariable.GetServerTime();
                                    model.sender = ConvertHelper.ToInt32(frm_empId, 0);
                                    model.isSend = 1;

                                    model.fm_curAreaID = PublicVariable.CurAreaID;
                                    model.fm_curGwID = PublicVariable.CurGwID;
                                    model.fm_curGw = PublicVariable.CurGwName;

                                    bool updateSender = BLL.UpdateSend(model);
                                    if (updateSender)
                                    {
                                        MessageBox.Show("发货成功！");
                                        //绑定DataGridView
                                        bindData();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //设置用户工位权限
        private void SetEmpGongweiRight()
        {
            var rightModels = DIService.GetService<IBLL_BaseInfo>().GetRightList(new BaseGongweiRightModel() { empID = PublicVariable.CurEmpID, IP = PublicVariable.LocalIP });
            //没有使用例外转序的权限
            if (rightModels == null ||
                rightModels.Count == 0 ||
                !rightModels.Exists(f => f.rightTypeName == "作业指导"))
            {
                MessageBox.Show("您没有使用当前功能的权限！");
                Application.Exit();
                return;
            }

            toolbtnError.Visible = false;
            if (rightModels.Exists(f => f.rightTypeName == "异常下线"))
            {
                toolbtnError.Visible = true;
            }
        }

    }
}