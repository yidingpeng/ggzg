using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Plan;
using RW.PMS.Model.Sys;
using RW.PMS.WinForm.Common;
using RW.PMS.WinForm.UI.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Assembly
{
    public partial class FrmPartPlan : FormSkin
    {


        IBLL_Follow bllFollow = DIService.GetService<IBLL_Follow>();
        IBLL_System bllSystem = DIService.GetService<IBLL_System>();
        IBLL_BaseInfo bllBase = DIService.GetService<IBLL_BaseInfo>();


        public FrmPartPlan()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.dgvData.AutoGenerateColumns = false;
        }


        private void FrmPartPlan_Load(object sender, EventArgs e)
        {
            try
            {
                SetEmpGongweiRight();//权限判定、控制

                BingDDL();//绑定下拉框

                BindData();//绑定基础数据(查询)

                //获取服务器地址
                SysconfigModel config = bllSystem.GetConfigByCode("ServerIP");
                ServerIP = config.cfg_value;//服务器IP
                if (ServerIP == "")
                {
                    MessageBox.Show("获取服务器地址失败！请检查网络");
                    return;
                }

                //状态栏显示
                this.toolStripStatusLabel1.Text = "当前区域：" + PublicVariable.CurAreaName + "-" + PublicVariable.CurGwName + " (" + PublicVariable.LocalIP + ")";
                this.toolStripStatusLabel2.Text = "当前登陆用户：" + PublicVariable.CurEmpName;
                this.toolStripStatusLabel3.Text = "网络通讯状态：";
                this.toolStripStatusLabel4.Text = "当前系统时间：" + PublicVariable.GetSystemDateTime();

                if (PingNet == null)
                {
                    PingNet = new System.Threading.Thread(PingNetThread);
                    PingNet.IsBackground = true;
                    PingNet.Start();
                }

                this.Text = PublicVariable.CurAreaName;

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("异常来自 HRESULT:0xC0040007"))
                    RWMessageBox.Show("OPC初始化异常,请检查OPC点位配置!");
                else
                    RWMessageBox.Show(ex.Message);
            }
        }

        #region 下拉框绑定
        /// <summary>
        /// 初始化绑定下拉值
        /// </summary>
        private void BingDDL()
        {
            try
            {
                //产品-型号
                //List<BaseProductModelModel> dtProdModel = bllBase.GetProductModel();
                List<BaseProductModelModel> dtProdModel = bllBase.GetProductDrawingNoModel();//产品型号(图号)
                dtProdModel.Insert(0, new BaseProductModelModel { ID = 0, PmodelDrawingNo = "--请选择--" });
                cmbProdModel.DataSource = dtProdModel;
                cmbProdModel.ValueMember = "ID";
                cmbProdModel.DisplayMember = "PmodelDrawingNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 网络通讯
        private Thread PingNet = null;
        private bool isPing = true;
        private int timerSecond = 10;//ping服务器网络的秒数，从配置表里取pingServerTimer(S)
        private string ServerIP = "";//网络服务器地址

        /// <summary>
        /// PingNet后台线程(每x秒获取一次网络状态)
        /// </summary>
        private void PingNetThread()
        {
            try
            {
                while (isPing)
                {
                    //判断网络
                    string pingMsg = "";
                    bool bPing = NetworkHelper.Ping(out pingMsg, ServerIP, timerSecond);
                    if (bPing)
                    {
                        toolStripStatusLabel3.Text = "网络通讯状态：连接正常";
                        toolStripStatusLabel3.ForeColor = Color.Green;
                    }
                    else
                    {
                        this.toolStripStatusLabel3.Text = "网络通讯状态：连接异常";
                        toolStripStatusLabel3.ForeColor = Color.Red;
                    }
                    Thread.Sleep(timerSecond * 1000);
                }
            }
            catch {

            }
        }
        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Query(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 绑定数据（查询）
        /// </summary>
        private void BindData()
        {
            int Status = -1;
            if (rdbNoStart.Checked)//未开始
                Status = 0;
            else if (rdbIssued.Checked)//已下发
                Status = 1;
            else if (rdbStart.Checked)//已开始
                Status = 2;
            else if (rdbFinish.Checked)//已完成
                Status = 3;
            else if (rdbRejected.Checked)//已驳回
                Status = 4;

            //string AreaArrID = PublicVariable.BeforeAreaID + "," + PublicVariable.CurAreaID;
            //if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.checkArea.ToString())
            //{
            //    AreaArrID = PublicVariable.BeforeAreaID + "," + PublicVariable.BeBeforeAreaID + "," + PublicVariable.CurAreaID;
            //}

            //显示该区域的追溯信息
            IBLL_Plan bllPlan = DIService.GetService<IBLL_Plan>();
            PartPlanModel model = new PartPlanModel();
            //只查询当前区域的上一个区域数据
            model.LIKEorderCode = txtPporderCode.Text.Trim();//计划单据号
            model.LIKEorderCodeRel = txtPporderCodeRel.Text.Trim();//第三方计划单据号
            model.LIKEPpmaterial = txtPpmaterial.Text.Trim();//物料编码（图号）
            model.pp_project = txtPproject.Text.Trim();//项目号编码
            model.pp_prodModelID = (int)cmbProdModel.SelectedValue;//产品型号
            model.pp_status = Status;
            model.sort = "pp.pp_startDate";
            model.sortOrder = "desc";
            List<PartPlanModel> PartPlanList = bllPlan.GetPartPlanList(model);
            this.dgvData.DataSource = PartPlanList;

            for (int i = 0; i < PartPlanList.Count; i++)
            {
                if (PartPlanList[i].pp_status == 1)
                {
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.ForeColor = Color.Orange;
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.SelectionForeColor = Color.Orange;
                    dgvData.Rows[i].Cells["btnRequisitionMain"].Value = "配料";

                }
                else if (PartPlanList[i].pp_status == 2)
                {
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.ForeColor = Color.Yellow;
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.SelectionForeColor = Color.Yellow;

                }
                else if (PartPlanList[i].pp_status == 3)
                {
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.ForeColor = Color.Green;
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.SelectionForeColor = Color.Green;
                }
                else if (PartPlanList[i].pp_status == 4)
                {
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.ForeColor = Color.Red;
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.SelectionForeColor = Color.Red;
                }
                else
                {
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.ForeColor = Color.Blue;//#337ab7
                    //dgvData.Rows[i].Cells["pp_statusText"].Style.SelectionForeColor = Color.Blue;
                    dgvData.Rows[i].Cells["btnRequisitionMain"].Value = "";
                }
            }
        }

        #endregion

        #region 信息反馈
        /// <summary>
        /// 信息反馈按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnFeedBack_Click(object sender, EventArgs e)
        {
            Follow.FrmFollowFeedback f = new Follow.FrmFollowFeedback();
            f.ShowDialog();
        }
        #endregion


        #region 故障报修
        private void toolbtnFaultRepair_Click(object sender, EventArgs e)
        {
            using (var frmFollowFaultRepair = new Follow.FrmFollowFaultRepair())//打开备料界面
            {
                frmFollowFaultRepair.ShowDialog();
                frmFollowFaultRepair.Dispose();
            }
            //Follow.FrmFollowFaultRepair f = new Follow.FrmFollowFaultRepair();
            //f.ShowDialog();
        }
        #endregion

        #region 双击事件
        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //暂时取消双击编辑功能 Update By Leon 20190927
                //toolbtnEdit_Click(null, null);
                //根据区域决定双击触发什么事件,若为拆解区则打开装配管理系统.
                if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.ZassemblyArea.ToString())
                {
                    //修改双击功能:改为传递追溯主表实体类至装配管理系统. By Leon 20191130
                    //获取追溯主表ID
                    Guid fm_guid = dgvData.SelectedRows[0].Cells["fm_guid"].Value.ToGuid();
                    if (fm_guid == Guid.Empty)
                        throw new Exception("当前双击行追溯主表GUID获取失败");
                    //List<FollowMainModel> list = bllFollow.GetFMList(new FollowMainModel() { fm_guid = fm_guid });
                    //if (list.Count == 0)
                    //    throw new Exception("追溯主表数据获取失败");

                    //FrmMain f = new FrmMain(true, list[0]);//打开装配管理系统
                    //f.ShowDialog();
                }
                //if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.dryArea.ToString())
                //{
                //    toolbtnEdit_Click(null, null);
                //}
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 退出
        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Environment.Exit(0);
        }
        #endregion

        //刷新当前系统时间
        [DebuggerStepThrough]
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel4.Text = "当前系统时间：" + PublicVariable.GetSystemDateTime();
        }


        /// <summary>
        /// 计划单据号 文本框回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPporderCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)//回车
                {
                    string strPporderCode = txtPporderCode.Text.Trim();
                    if (string.IsNullOrEmpty(strPporderCode))
                        return;
                }
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// 窗体关闭修改考勤信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPartPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //考勤记录录入登出时间
            int i = DIService.GetService<IBLL_System>().SaveLogoutTime(PublicVariable.CurEmpID);
        }


        #region 刷新
        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            //清空条件
            txtPporderCodeRel.Text = "";
            txtPporderCode.Text = "";
            cmbProdModel.SelectedValue = 0;

            //将为全部设置为选中状态
            //rdbAll.Checked = true;
            rdbIssued.Checked = true;

            BindData();//绑定数据
        }
        #endregion

        #region 异常下线
        /// <summary>
        /// 异常下线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnError_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvData.SelectedRows.Count == 0)
            //    {
            //        RWMessageBox.Show("请选择一行数据再进行此操作！");
            //        return;
            //    }
            //    if (MessageBox.Show("异常下线后不能恢复！确定要异常下线吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        string strProdNoSys = dgvData.SelectedRows.Count > 0 ? dgvData.SelectedRows[0].Cells["fp_prodNo_sys"].Value.ToString() : "";
            //        var errDownCode_follow = ConvertHelper.ToInt32(EDAEnums.FollowStatus.errorDown, 2);
            //        var errDownCode_ams = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.errorDown, 2);
            //        int errTypeID = bllSystem.GetBaseDataId("ErrorOffline");
            //        int EmpId = PublicVariable.CurEmpID;
            //        string EmpName = PublicVariable.CurEmpName;
            //        int GwId = PublicVariable.CurGwID;
            //        string GwName = PublicVariable.CurGwName;
            //        //调用异常下线功能
            //        bllFollow.ProdErrorOffLine(strProdNoSys, errDownCode_follow, errDownCode_ams, errTypeID, "", Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, "产品追溯信息异常下线", EmpId, EmpName, GwId, GwName);
            //        MessageBox.Show("异常下线成功!");
            //        //刷新
            //        BindData();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        #endregion

        /// <summary>
        /// 权限判定
        /// </summary>
        private void SetEmpGongweiRight()
        {
            var rightModels = bllBase.GetRightList(new BaseGongweiRightModel() { empID = PublicVariable.CurEmpID, IP = PublicVariable.LocalIP });
            //没有作业指导的权限
            if (rightModels == null || rightModels.Count == 0 || !rightModels.Exists(f => f.rightTypeName == "作业指导"))
            {
                MessageBox.Show("您没有使用当前功能的权限！");
                Application.Exit();
                return;
            }
            //异常下线权限判定
            toolbtnError.Visible = false;
            if (rightModels.Exists(f => f.rightTypeName == "异常下线"))
            {
                //toolbtnError.Visible = true;
                toolbtnError.Visible = false;
            }
        }


        /// <summary>
        /// 产品管理  改为设备保养计划明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnProductManage_Click(object sender, EventArgs e)
        {
            FrmDeviceExecDetail frmDeviceExecDetail = new FrmDeviceExecDetail();
            frmDeviceExecDetail.ShowDialog();
        }



        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewColumn column = dgvData.Columns[e.ColumnIndex];
                    if (column is DataGridViewButtonColumn)
                    {
                        if (column.Name == "btnRequisitionMain")
                        {
                            if (dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                                return;
                            if (dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "配料")
                            {
                                //说明点击的列是DataGridViewButtonColumn列
                                //DataGridViewColumn column = dgvRequisitionMain.Columns[e.ColumnIndex];
                                string PpOrderCode = dgvData.SelectedRows[0].Cells["pp_orderCode"].Value.ToString();
                                if (string.IsNullOrEmpty(PpOrderCode))
                                    RWMessageBox.ShowExclamation("获取当前双击行信息失败！");

                                using (var f = new FrmPmsRequisitionMain(PpOrderCode))//打开备料界面
                                {
                                    var result = f.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {
                                        //重新绑定
                                        BindData();
                                    }
                                    f.Dispose();
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
        
    }
}
