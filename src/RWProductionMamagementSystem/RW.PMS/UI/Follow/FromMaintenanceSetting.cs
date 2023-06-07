using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Follow
{
    public partial class FromMaintenanceSetting : Form
    {
        private static IBLL_BaseInfo BLL = DIService.GetService<IBLL_BaseInfo>();

        public FromMaintenanceSetting()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = false;

            //设置自动换行
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //设置自动调整高度
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //让整个DataGridView的所有cell都可以自动换行。
            this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void FromMaintenanceSetting_Load(object sender, EventArgs e)
        {
            bindData();
        }

        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            FromMainSettingEdit feedback = new FromMainSettingEdit(EDAEnums.ActionType.Add.ToString(), 0);
            DialogResult dialogresult = feedback.ShowDialog();

            //判断是否返回为OK，刷新窗体 
            if (dialogresult == DialogResult.OK)
            {
                bindData();
            }
        }

        private void toolbtnEdit_Click(object sender, EventArgs e)
        {
            //获取ID
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value) : 0;
            if (ID != 0)
            {
                FromMainSettingEdit feedback = new FromMainSettingEdit(EDAEnums.ActionType.Edit.ToString(), ID);
                DialogResult dialogresult = feedback.ShowDialog();
                //判断是否返回为OK，刷新窗体 
                if (dialogresult == DialogResult.OK)
                {
                    bindData();
                }
            }
            else
            {
                MessageBox.Show("请选择需要修改的数据！");
            }
        }
       
        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            try
            {   
                DialogResult value = MessageBox.Show("你确定是否删除该维保信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (value == DialogResult.Yes)
                {
                    //获取ID
                    int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value) : 0;
                    if (ID != 0)
                    {
                        BLL.DeleteMaintenanceSetting(ID.ToString());
                        MessageBox.Show("删除成功！");
                        bindData();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            bindData();
        }

        //绑定查询
        public void bindData()
        {
            try
            {
                List<MaintenanceSettingModel> list = BLL.GetMaintenanceSettingAll();
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value) : 0;
            FromMainSettingEdit feedback = new FromMainSettingEdit(EDAEnums.ActionType.Edit.ToString(), ID);
            DialogResult dialogresult = feedback.ShowDialog();
            //判断是否返回为OK，刷新窗体 
            if (dialogresult == DialogResult.OK)
            {
                bindData();
            }
        }

        private void toolbtnMaintain_Click(object sender, EventArgs e)
        {
            DialogResult msgGoOn = MessageBox.Show("是否保养该项点？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (msgGoOn.ToString() == "No")
            {
                return;
            }

            //获取ID
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value) : 0;
            bool result = BLL.EditmaintainUsedTime(ID);
            if (result)
            {
                MessageBox.Show("保养成功！");
            }
            else
            {
                MessageBox.Show("保养失败！");
            }
            bindData();
        }
    }
}
