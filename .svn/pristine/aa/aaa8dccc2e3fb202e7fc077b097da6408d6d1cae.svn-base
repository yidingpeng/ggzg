using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Utils;
using RW.PMS.Utils.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Assembly
{
    /// <summary>
    /// 模拟装配窗体
    /// </summary>
    public partial class FrmDemoAms : Form
    {
        #region 成员变量
        /// <summary>
        /// 工位ID
        /// </summary>
        private int frm_gwID = 0;

        /// <summary>
        /// 工位名称
        /// </summary>
        private string frm_gwname = "";


        IBLL_Assembly dalProd = DIService.GetService<IBLL_Assembly>();
        IBLL_ProgramInfo _programBLL = DIService.GetService<IBLL_ProgramInfo>();

        /// <summary>
        /// 工序工步信息
        /// </summary>
        private List<ProGXGBModel> dtleftgb = new List<ProGXGBModel>();
        //工具、物料信息
        private List<ProGJValModel> dtleftGj = new List<ProGJValModel>();

        List<string> gjList = new List<string>();//获取当前工艺程序的所有工具动态生成Led灯
        List<string> wlList = new List<string>();//获取当前工艺程序的所有物料动态生成Led灯

        private int StepIndex = 0;//启动装配后DataTable运行行的索引
        private int gxStepIndex = 0;//返回上一步用，跳转到工序
        private int curGjIndex = 0;//工具管控，执行步骤indexx
        private int curWlIndex = 0;//物料管控，执行步骤indexx
        private bool IsStart = false;//记录是否启动/暂停
        private bool IsOneStart = false;
        /// <summary>
        /// 工具显示文字(拆卸中 or 装配中)
        /// </summary>
        private string toolText = "";
        private int GjCount = 0;//记录当前工步的工具总数量
        private int WlCount = 0;//记录当前工步的物料总数量
        //视频保存路径
        private string _videoDir = Path.Combine(Application.StartupPath, "gxVideo");

        //网络通讯
        //private System.Threading.Thread PingNet = null;
        private bool isPing = true;
        private int timerSecond = 2;//ping服务器网络的秒数，从配置表里取pingServerTimer(S)
        private string ServerIP = "";//网络服务器地址

        private string _curGJName = string.Empty;
        #endregion

        #region 构造函数
        public FrmDemoAms()
        {
            InitializeComponent();

            frm_gwID = PublicVariable.CurGwID;
            frm_gwname = PublicVariable.CurGwName.ToString();
        }
        #endregion

        #region 绑定下拉框
        /// <summary>
        /// 加载产品型号
        /// </summary>
        private void BingDDL()
        {
            try
            {
                //产品型号
                cmbProdModel.DataSource = dalProd.GetProdModelForDDL(PublicVariable.CurGwID);
                cmbProdModel.DisplayMember = "Value";
                cmbProdModel.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("产品型号绑定失败！" + ex.Message);
            }
        }
        #endregion

        #region 加载函数
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MnMain_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            PicLight.Visible = false;//隐藏绿灯，启动装配/拆解亮绿灯

            //若为拆卸区则启动拆卸,否则启动装配
            if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.disassemblyArea.ToString())
            {
                this.toolbtnStart.Text = "启动拆卸";
                this.toolText = "拆卸中";
                this.lblTitle.Text = "模 拟 拆 卸 指 导";
            }
            else
            {
                this.toolbtnStart.Text = "启动装配";
                this.toolText = "装配中";
                this.lblTitle.Text = "模 拟 装 配 指 导";
            }

            //绑定下拉框
            BingDDL();

            #region 网络通讯和视频控件设置
            this.axWindowsMediaPlayer1.uiMode = "none"; //视频属性配置：去掉菜单控制栏
            this.axWindowsMediaPlayer1.enableContextMenu = false;   //屏蔽右键
            //怎么让鼠标双击全屏失效？
            this.axWindowsMediaPlayer1.stretchToFit = true; //视频属性配置：铺满屏幕
            this.axWindowsMediaPlayer1.Visible = false;
            //获取服务器地址
            ServerIP = PublicVariable.ServerIP;
            if (ServerIP == "")
            {
                MessageBox.Show("获取服务器地址失败！请检查网络");
                return;
            }
            //获取ping服务器的时间间隔
            string strpingServerTimer = PublicVariable.GetSysConfig("pingServerTimer");
            if (string.IsNullOrEmpty(strpingServerTimer))
            {
                MessageBox.Show("获取网络通讯时间间隔失败！请检查网络");
                return;
            }
            else
            {
                timerSecond = Convert.ToInt32(strpingServerTimer);
            }

            ////状态栏显示
            //this.toolStripStatusLabel1.Text = "当前区域：" + PublicVariable.CurAreaName + "-" + PublicVariable.CurGwName + " (" + PublicVariable.LocalIP + ")";
            //this.toolStripStatusLabel2.Text = "当前登陆用户：" + PublicVariable.CurEmpName;
            //this.toolStripStatusLabel3.Text = "网络通讯状态：";
            //this.toolStripStatusLabel4.Text = "当前系统时间：" + PublicVariable.GetServerTime().ToString("yyyy-MM-dd HH:mm:ss");


            //if (PingNet == null)
            //{
            //    PingNet = new System.Threading.Thread(PingNetThread);
            //    PingNet.IsBackground = true;
            //    PingNet.Start();
            //}
            #endregion

            cmbProdModel_SelectedIndexChanged(null, null);//没有追溯系统则要重新程序下拉


        }
        #endregion

        /// <summary>
        /// 动态生成控件
        /// </summary>
        private void AddControls(string name)
        {
            var btn = new Button
            {
                BackColor = System.Drawing.SystemColors.ControlLightLight,//背景色
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ForeColor = System.Drawing.SystemColors.ActiveCaptionText,
                Image = RW.PMS.WinForm.Properties.Resources.black,
                ImageAlign = System.Drawing.ContentAlignment.TopCenter,
                Name = name,
                Size = new System.Drawing.Size(75, 57),
                Text = name,
                TextAlign = System.Drawing.ContentAlignment.BottomCenter,
                UseVisualStyleBackColor = true,
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.White;
            btn.FlatAppearance.MouseOverBackColor = Color.White;
            btn.Click += btn_Click;

            fLPanel1.Controls.Add(btn);
        }

        /// <summary>
        /// 动态控件点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (sender as Button);
            if (btn.Name == _curGJName && !string.IsNullOrEmpty(_curGJName))//工具不为空并判断是否是正确的工具
            {
                PicLight.Image = Properties.Resources.normal;
                btn.Image = Properties.Resources.black;
                richTxtGjValue.Text = string.Empty;
                if (GjCount == 1 && WlCount == 1)
                {
                    StepIndex++;
                    ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                }
                else if (GjCount == 1 && WlCount == 0)
                {
                    StepIndex++;
                    ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                }
                else if (WlCount == 1 && GjCount == 0)
                {
                    StepIndex++;
                    ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                }
                else if (curGjIndex >= GjCount && WlCount == 0)
                {
                    curGjIndex = 0;
                    StepIndex++;
                    ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                }
                else if (curWlIndex >= WlCount && GjCount == 0)
                {
                    curWlIndex = 0;
                    StepIndex++;
                    ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                }
                else
                {
                    ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                }
            }
            else
            {
                //判断有工具才会提示
                if (!string.IsNullOrEmpty(_curGJName))
                {
                    PicLight.Image = Properties.Resources.scram;
                    richTxtGjValue.Text = "提示:\r\n" + "请拿取或放回正确的工具/物料";
                }

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
                    if (connectServer)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        private void Clear()
        {
            try
            {
                ControlHelper.Invoke(this, delegate { timer1.Enabled = false; });

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].ReadOnly = true;
                    dataGridView1.Rows[i].Selected = false;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.FirstDisplayedScrollingRowIndex = 0; //滚动条动态滚动

                //赋值
                txt_gbDesc.Text = string.Empty;
                richTxtGbName.Text = string.Empty;
                richTxtGjValue.Text = string.Empty;
                StepIndex = 0;//启动装配后运行的索引
                curGjIndex = 0;//工具管控，执行步骤indexx
                curWlIndex = 0;//物料管控，执行步骤indexx
                GjCount = 0;
                WlCount = 0;
                gxStepIndex = 0;
                _curGJName = string.Empty;
                IsStart = false;
                //图片处理
                this.pictureBox1.Image = null;
                this.pictureBox1.Refresh();

                //播放工步视频
                this.axWindowsMediaPlayer1.URL = string.Empty;
                this.axWindowsMediaPlayer1.Refresh();
                clearLed();
            }
            catch { }
        }

        /// <summary>
        /// 关灯
        /// </summary>
        private void clearLed()
        {
            richTxtGjValue.Text = string.Empty;
            foreach (Control ctr in fLPanel1.Controls)
            {
                var btn = (ctr as Button);
                btn.Image = Properties.Resources.black;
            }
        }

        /// <summary>
        /// 启动装配/拆解
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnStart_Click(object sender, EventArgs e)
        {
            if (cmbProdModel.SelectedValue == null) return;
            if (!IsOneStart)//首次点击,启动
            {
                if (cmbProgram.SelectedValue == null) return;
                dtleftGj = _programBLL.ProgGJValList((int)cmbProgram.SelectedValue);//获取程序的工具列表
                foreach (ProGJValModel item in dtleftGj)
                {
                    string gjName = item.GJName;
                    string wlName = item.WLName;
                    if (!string.IsNullOrEmpty(gjName))
                    {
                        if (!gjList.Contains(gjName))
                            gjList.Add(gjName);
                    }
                    if (!string.IsNullOrEmpty(wlName))
                    {
                        if (!wlList.Contains(wlName))
                            wlList.Add(wlName);
                    }
                }

                foreach (var gj in gjList)
                {
                    AddControls(gj);
                }
                foreach (var wl in wlList)
                {
                    AddControls(wl);
                }

                PicLight.Visible = true;//显示绿灯
                Clear();
                string PmodelId = cmbProdModel.SelectedValue.ToString();
                string progId = cmbProgram.SelectedValue != null ? cmbProgram.SelectedValue.ToString() : "0";
                if (PmodelId == "0" || progId == "0")
                {
                    MessageBox.Show("请选择产品型号、工艺程序");
                    return;
                }

                dtleftgb = _programBLL.ProgGXGBList((int)cmbProgram.SelectedValue);

                this.dataGridView1.DataSource = dtleftgb;
                StepIndex = 0;
                gxStepIndex = 0;
                IsOneStart = true;

                this.toolbtnStart.Text = toolText;//拆卸中
                ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
            }
            else
            {
                if (IsStart)
                {
                    toolbtnStart.Image = Properties.Resources.play;
                    this.toolbtnStart.Text = toolText;
                    IsStart = false;
                    if (dtleftgb.Count > 0)
                        ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                }
                else
                {
                    toolbtnStart.Image = Properties.Resources.pause;
                    this.toolbtnStart.Text = "暂停";
                    IsStart = true;
                    ControlHelper.Invoke(this, delegate { timer1.Enabled = false; });
                }
            }
        }

        /// <summary>
        /// 工序返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnReturn_Click(object sender, EventArgs e)
        {
            if (gxStepIndex == 0 && StepIndex == 0)//第一步，则不让返回
            {
                MessageBox.Show("已经是第一道工序，不能返回", "温馨提示");
                return;
            }
            else
            {
                if (StepIndex >= dataGridView1.RowCount)
                {
                    MessageBox.Show("已经是第后一道工序，不能返回", "温馨提示");
                    return;
                }
                if (gxStepIndex == StepIndex)//如果是工序的第一道工步，则返回到上一道工序的第一道工步
                {
                    //通过gxStepIndex获取当前工序的序号
                    int curGxIndex = Convert.ToInt32(dtleftgb[gxStepIndex].gxOrder.ToString());
                    //再得到序号减1，并且工步order为1的索引
                    var drsFistGb = dtleftgb.Where(f => f.gxOrder == curGxIndex - 1 && f.gbOrder == 1).ToList();
                    if (drsFistGb.Count == 1)
                    {
                        int curGbIndex = drsFistGb.FirstOrDefault().RowID;
                        gxStepIndex = curGbIndex;
                    }
                    else
                    {
                        MessageBox.Show("返回出错");
                        return;
                    }
                }
                for (int i = gxStepIndex; i <= StepIndex; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Rows[i].Cells[2].Value = Properties.Resources.beijing;
                }
                dataGridView1.Rows[gxStepIndex].Selected = true;
                dataGridView1.Rows[gxStepIndex].Cells[2].Value = Properties.Resources.RightRed;
                StepIndex = gxStepIndex;
                timer1.Interval = 1000;
                ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                clearLed();
            }
        }

        /// <summary>
        /// 手动管控按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnNext_Click(object sender, EventArgs e)
        {
            if (StepIndex != dtleftgb.Count)
            {
                if (GjCount == 1 && WlCount == 1)
                {
                    StepIndex++;
                }
                else if (GjCount == 1 && WlCount == 0)
                {
                    StepIndex++;
                }
                else if (WlCount == 1 && GjCount == 0)
                {
                    StepIndex++;
                }
                else if (curGjIndex >= GjCount && WlCount == 0 && GjCount > 0)
                {
                    curGjIndex = 0;
                    StepIndex++;
                }
                else if (curWlIndex >= WlCount && GjCount == 0 && WlCount > 0)
                {
                    curWlIndex = 0;
                    StepIndex++;
                }
                foreach (Control ctr in fLPanel1.Controls)
                {
                    var btn = (ctr as Button);
                    btn.Image = Properties.Resources.black;
                }
                timer1_Tick(sender, e);
            }
            else
            {
                if (StepIndex >= dataGridView1.RowCount)
                {
                    if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.disassemblyArea.ToString())
                    {
                        richTxtGbName.Text = "拆卸完成\r\n";
                        this.toolbtnStart.Text = "启动拆卸";
                        IsOneStart = false;
                        clearLed();
                        Clear();
                    }
                    else
                    {
                        richTxtGbName.Text = "装配完成\r\n";
                        this.toolbtnStart.Text = "启动装配";
                        IsOneStart = false;
                        clearLed();
                        Clear();
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// 下拉改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProdModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectValue = this.cmbProdModel.SelectedValue.ToInt();
            if (selectValue > 0)
            {
                var dtprog = dalProd.GetProgramForDLL(frm_gwID, selectValue, 0);
                this.cmbProgram.DisplayMember = "Value";
                this.cmbProgram.ValueMember = "Key";
                this.cmbProgram.DataSource = dtprog;
            }
        }

        #region

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="img"></param>
        private void ShowImage(byte[] img)
        {
            try
            {
                using (MemoryStream myStream = new MemoryStream(img))
                {
                    Image myImage = Image.FromStream(myStream);
                    this.pictureBox1.Image = myImage;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                this.pictureBox1.Image = null;
            }
            this.pictureBox1.Refresh();
        }
        /// <summary>
        /// 显示视频
        /// </summary>
        /// <param name="path"></param>
        private void ShowVideo(string path)
        {
            if (File.Exists(path))
            {
                this.axWindowsMediaPlayer1.Visible = true;
                this.axWindowsMediaPlayer1.URL = path;
                this.axWindowsMediaPlayer1.Ctlcontrols.play();
                this.axWindowsMediaPlayer1.settings.setMode("loop", true);//循环播放
            }
        }
        #endregion 显示图片和视频
        /// <summary>
        /// 获取工具物料OPC点位信息
        /// </summary>
        /// <param name="gjwlOpcType"></param>
        private string GetGJWLOPCValue(IEnumerable<GJOPCType> gjwlOPCTypes, string gjwlOpcType)
        {
            var value = string.Empty;
            var detail = gjwlOPCTypes.Where(f => f.Code == gjwlOpcType).FirstOrDefault();
            if (detail != null)
            {
                value = detail.Value;
            }
            return value;
        }

        /// <summary>
        /// 获取工位OPC点位信息
        /// </summary>
        /// <param name="gwOPCType"></param>
        /// <returns></returns>
        private string GetGWOPCValue(IEnumerable<BaseGongweiOpcModel> OPC, string gwOPCType)
        {
            var value = string.Empty;
            var detail = OPC.Where(f => f.opcTypeCode == gwOPCType).FirstOrDefault();
            if (detail != null)
            {
                value = detail.opcValue;
            }
            return value;
        }

        /// <summary>
        /// 工步跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            ControlHelper.Invoke(this, delegate { timer1.Enabled = false; });
            if (StepIndex >= dataGridView1.RowCount)
            {
                if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.disassemblyArea.ToString())
                {
                    richTxtGbName.Text = "拆卸完成\r\n";
                    this.toolbtnStart.Text = "启动拆卸";
                    IsOneStart = false;//装配完成重新点击
                    clearLed();
                }
                else
                {
                    richTxtGbName.Text = "装配完成\r\n";
                    this.toolbtnStart.Text = "启动装配";
                    IsOneStart = false;//装配完成重新点击
                    clearLed();
                }
                return;
            }
            var gxgbModel = dtleftgb[StepIndex];
            dataGridView1.Rows[StepIndex].Selected = true;
            dataGridView1.Rows[StepIndex].ReadOnly = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[StepIndex].Cells[2];
            dataGridView1.Rows[StepIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            if (StepIndex != 0)
                dataGridView1.Rows[StepIndex - 1].Cells[2].Value = Properties.Resources.beijing;


            dataGridView1.Rows[StepIndex].Cells[2].Value = Properties.Resources.RightRed;

            #region 基础控件显示
            //滚动条动态滚动
            if (dataGridView1.SelectedRows.Count > 15)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows.Count - 15;
            }

            //赋值
            txt_gbDesc.Text = gxgbModel.gbdesc;
            richTxtGbName.Text = "提示:\r\n" + gxgbModel.gbname;
            richTxtGjValue.Text = string.Empty;
            _curGJName = string.Empty;
            this.pictureBox1.Image = null;
            this.pictureBox1.Refresh();
            #endregion

            #region 第一个工步的第一个工具或物料时的逻辑，播放视频，新增工序数据

            if (gxgbModel.gbOrder == 1 && curGjIndex == 0 && curWlIndex == 0)
            {
                //播放视频
                #region 播放工步视频
                if (!string.IsNullOrEmpty(gxgbModel.GxvedioFilename))
                {
                    var fileName = Path.Combine(_videoDir, gxgbModel.GxvedioFilename);
                    if (File.Exists(fileName))
                    {
                        ShowVideo(fileName);
                    }
                    else
                    {
                        this.axWindowsMediaPlayer1.Visible = false;
                    }
                }
                else
                {
                    this.axWindowsMediaPlayer1.Visible = false;
                }
                #endregion
                //每当工步序号为1时，就保存工序当前的index,为了做返回上一步，即返回当前工序的第一个工步
                gxStepIndex = StepIndex;
            }
            else
            {
                this.axWindowsMediaPlayer1.Visible = false;
            }
            #endregion


            var drsGj = dtleftGj.Where(f => f.ProgGBID == gxgbModel.progGBID && f.GJID.HasValue && f.GJID > 0).ToList();
            var drsWl = dtleftGj.Where(f => f.ProgGBID == gxgbModel.progGBID && f.WLID.HasValue && f.WLID > 0).ToList();
            GjCount = drsGj.Count;
            WlCount = drsWl.Count;
            string gjGetTag = string.Empty;
            string gjPutTag = string.Empty;

            if (drsGj.Count > 0 && drsWl.Count > 0)//工具和物料都大于零则走工具管控
            {
                if (curGjIndex < GjCount)
                {
                    #region 图片显示
                    if (drsGj[curGjIndex].GJImg != null && drsGj[curGjIndex].GJImg.Length > 0)
                    {
                        ShowImage(drsGj[curGjIndex].GJImg);
                    }
                    #endregion
                    bool IsGjWl = true;
                    GjWlGuanKong(drsGj, ref gjGetTag, ref gjPutTag, IsGjWl);
                }

            }
            else if (drsGj.Count > 0 && drsWl.Count == 0)
            {
                if (curGjIndex < GjCount)
                {
                    #region 图片显示
                    if (drsGj[curGjIndex].GJImg != null && drsGj[curGjIndex].GJImg.Length > 0)
                    {
                        ShowImage(drsGj[curGjIndex].GJImg);
                    }
                    #endregion
                    bool IsGjWl = true;
                    GjWlGuanKong(drsGj, ref gjGetTag, ref gjPutTag, IsGjWl);
                }
            }
            else if (drsWl.Count > 0 && drsGj.Count == 0)
            {
                if (curWlIndex < WlCount)
                {
                    #region 图片显示
                    if (drsWl[curWlIndex].WLImg != null && drsWl[curWlIndex].WLImg.Length > 0)
                    {
                        ShowImage(drsWl[curWlIndex].WLImg);
                    }
                    #endregion
                    bool IsGjWl = false;
                    GjWlGuanKong(drsWl, ref gjGetTag, ref gjPutTag, IsGjWl);
                }
            }
            else
            {
                if (gxgbModel.progGBID.HasValue)
                {
                    //获取图片
                    var image = _programBLL.GetGBImage(gxgbModel.progGBID.Value);
                    ShowImage(image);
                }
                int Interval = Convert.ToInt32(gxgbModel.GBDelayTime);
                timer1.Interval = Interval == 0 ? 1000 : Interval * 1000;
                ControlHelper.Invoke(this, delegate { timer1.Enabled = true; });
                StepIndex++;
            }
        }

        /// <summary>
        /// 工具管控
        /// </summary>
        /// <param name="drsGjWl"></param>
        /// <param name="gjGetTag"></param>
        /// <param name="gjPutTag"></param>
        /// <param name="isGJ">工具标识</param>
        private void GjWlGuanKong(List<ProGJValModel> drsGjWl, ref string gjGetTag, ref string gjPutTag, bool isGJ)
        {
            string GjWlname = "";

            if (isGJ)//工具还是物料判断
            {
                GjWlname = drsGjWl[curGjIndex].GJName;
                gjGetTag = GetGJWLOPCValue(drsGjWl[curGjIndex].GJOPCTypes, EDAEnums.GJWLOPCType.GJWLGet);
                gjPutTag = GetGJWLOPCValue(drsGjWl[curGjIndex].GJOPCTypes, EDAEnums.GJWLOPCType.GJWLPut);
            }
            else
            {
                GjWlname = drsGjWl[curWlIndex].WLName;
                gjGetTag = GetGJWLOPCValue(drsGjWl[curWlIndex].GJOPCTypes, EDAEnums.GJWLOPCType.GJWLGet);
                gjPutTag = GetGJWLOPCValue(drsGjWl[curWlIndex].GJOPCTypes, EDAEnums.GJWLOPCType.GJWLPut);
            }

            _curGJName = string.Empty;
            _curGJName = GjWlname;

            if (drsGjWl.Count == 1)
            {
                if (!string.IsNullOrEmpty(gjGetTag))//如果Q点和I点都有设置,则
                {
                    bool IsTakePut = true;
                    GetTakePut(GjWlname, IsTakePut);
                }
                else
                {
                    bool IsTakePut = false;
                    GetTakePut(GjWlname, IsTakePut);
                }
            }
            else if (drsGjWl.Count > 1)
            {
                if (!string.IsNullOrEmpty(gjGetTag))//如果Q点和I点都有设置,则
                {
                    bool IsTakePut = true;
                    GetTakePut(GjWlname, IsTakePut);

                    if (isGJ)
                        curGjIndex++;
                    else
                        curWlIndex++;

                }
                else
                {
                    bool IsTakePut = false;
                    GetTakePut(GjWlname, IsTakePut);
                    if (isGJ)
                        curGjIndex++;
                    else
                        curWlIndex++;
                }
            }
        }

        /// <summary>
        /// 拿取放回
        /// </summary>
        /// <param name="GjWlname"></param>
        /// <param name="IsTakePut"></param>
        private void GetTakePut(string GjWlname, bool IsTakePut)
        {
            string Msg = "";
            if (IsTakePut)
            {
                Msg = "\r\n请拿起";
            }
            else
            {
                Msg = "\r\n请放回";
            }
            clearLed();
            richTxtGjValue.Text = richTxtGjValue.Text + Msg + GjWlname;
            GetLedD(GjWlname);
        }

        /// <summary>
        /// 提示拿取正确的灯
        /// </summary>
        /// <param name="drsGj"></param>
        private void GetLedD(string drsGj)
        {
            foreach (Control ctr in fLPanel1.Controls)
            {
                if (ctr is Button)
                {
                    if (ctr.Name == drsGj)
                    {
                        var btn = (ctr as Button);
                        btn.Image = Properties.Resources.green;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 动态加载时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel4.Text = "当前系统时间：" + PublicVariable.GetServerTime().ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
