using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Device;
using RW.PMS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseEnty = RW.PMS.Model.BaseInfo;
using SysEnty = RW.PMS.Model.Sys;
using DevEnty = RW.PMS.Model.Device;
using RW.PMS.Model.Sys;
using RW.PMS.Model.BaseInfo;
using Microsoft.Reporting.WebForms;

namespace RW.PMS.WinForm.UI.Device
{
    public partial class FrmDeviceExecDetail : FormSkin
    {
        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        IBLL_BaseInfo BaseBll = DIService.GetService<IBLL_BaseInfo>();
        private string devID = "";
        private string localIP = "";
        private int EmpId;
        private string Empname;

        IBLL_Device BLL = DIService.GetService<IBLL_Device>();

        public FrmDeviceExecDetail()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            this.EmpId = PublicVariable.CurEmpID;
            this.Empname = PublicVariable.CurEmpName;
            this.localIP = PublicVariable.LocalIP;
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;//选中单元格后为编辑状态

            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;  //设置自动换行

            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;//设置自动调整高度

            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }


        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDeviceExecDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (localIP == "")
                {
                    MessageBox.Show("获取本机IP出错，请检查");
                    this.btnExec.Enabled = false;
                    return;
                }
                BindDDL();
                //加载数据
                BindData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        private void BindDDL()
        {
            try
            {
                List<BaseEnty.DeviceModel> devAll = Devbll.GetDevice();
                this.cmbDevice.DataSource = devAll;
                this.cmbDevice.ValueMember = "ID";
                this.cmbDevice.DisplayMember = "DevName";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool BindData()
        {
            try
            {

                string IP = PublicVariable.LocalIP;
                List<BaseEnty.DeviceModel> devlist = Devbll.GetDevice().Where(x => x.DevIP == IP).ToList();
                if (devlist.Count > 0)
                {
                    this.cmbDevice.SelectedValue = devlist[0].ID;

                    Selectdes();
                }
                txtChecker.Text = PublicVariable.CurEmpName;
                txtChecker.Tag = PublicVariable.CurEmpID;

                bool isget = false;

                //List<DeviceSpotCheckModel> item = BLL.GetUpKeepPlanByIP(localIP);
                //if (item.Count > 0)
                //{
                //    this.devID = item[0].dsc_device.ToString();
                //    this.txtDevName.Text = item[0].DevName;
                //    this.txtDevNo.Text = item[0].DevNo;
                //    this.txtDevIP.Text = item[0].IP;



                //    this.dataGridView1.DataSource = item;

                //    isget = true;
                //}

                return isget;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void Selectdes()
        {
            
            BaseEnty.DeviceModel dc = Devbll.GetDevice().Where(s => s.ID == Convert.ToInt32(this.cmbDevice.SelectedValue)).ToList()[0];

            this.devID = dc.ID.ToString();
            this.txtDevNo.Text = dc.DevNo;
            this.txtDevIP.Text = dc.DevIP;

            DeviceSpotCheckModel md = new DeviceSpotCheckModel() { };

            md.dsc_device = Convert.ToInt32(this.cmbDevice.SelectedValue);

            md.dsc_class = 1;

            int count = 1000;

            List<DeviceSpotCheckModel> dclist = Devbll.DeviceSpotCheckPage(md, out count);

            int sum = dclist.Count;

            for (int i = 0; i < sum; i++)
            {
                while (dclist[i].dsc_class == 1)
                {
                    dclist.RemoveAt(i);

                    sum--;

                    if (sum == 0 || dclist.Count - 1 < i)
                    {
                        break;
                    }
                }
            }

            dataGridView1.DataSource = dclist;

        }


        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExec_Click(object sender, EventArgs e)
        {
            try
            {
                Device_upKeepPlanModel dup = new Device_upKeepPlanModel();

                dup.DevID = Convert.ToInt32(this.cmbDevice.SelectedValue);
                dup.ExecDate = DateTime.Now;
                dup.ExecEmp = Convert.ToInt32(txtChecker.Tag);
                dup.ExecEmpName = txtChecker.Text;
                dup.Remark = txtRemark.Text;


                List<Device_upkeepPlanDetailModel> upkeepPlanList = new List<Device_upkeepPlanDetailModel>();

                int dataGridveViewCount = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow dr = dataGridView1.Rows[i];
                    if (dr.Cells["col_check"].Value != null)
                    {
                        if (dr.Cells["col_check"].Value.ToString() == "1")
                        {
                            dataGridveViewCount++;

                            Device_upkeepPlanDetailModel checkEnty = new Device_upkeepPlanDetailModel();
                            checkEnty.spotid = dr.Cells["spotid"].Value.ToString();
                            checkEnty.dsc_position = dr.Cells["dsc_position"].Value != null ? dr.Cells["dsc_position"].Value.ToString() : "";
                            checkEnty.dsc_project = dr.Cells["dsc_project"].Value != null ? dr.Cells["dsc_project"].Value.ToString() : "";
                            checkEnty.udimg = dr.Cells["dsc_img"].Value as byte[];
                            checkEnty.udremark = dr.Cells["Remark"].Value != null ? dr.Cells["Remark"].Value.ToString() : "";
                            upkeepPlanList.Add(checkEnty);
                        }
                    }
                }
                if (dataGridveViewCount == 0)
                {
                    MessageBox.Show("请勾选要保养的项点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool Result = Devbll.SaveDevicePlan(dup, upkeepPlanList);

                if (Result)
                {
                    MessageBox.Show("保存成功！");
                    BindData();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
                //if (devID != "0" && devID != "" && localIP != "")
                //{
                //    bool update = BLL.UpdateDevExecTime(ConvertHelper.ToInt32(devID, 0), this.EmpId, this.Empname);
                //    if (update)
                //    {
                //        MessageBox.Show("执行成功");
                //        BindData();

                //        this.Close();

                //    }
                //    else
                //        MessageBox.Show("执行失败");
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //修改双击功能:改为传递追溯主表实体类至装配管理系统. By Leon 20191130
                int id = dataGridView1.SelectedRows[0].Cells["detailid"].Value.ToInt();
                if (id == 0)
                    throw new Exception("当前双击行ID获取失败");

                FrmPreviewPicture f = new FrmPreviewPicture(id);//打开预览大图界面

                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDevice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Selectdes();
        }
    }
}
