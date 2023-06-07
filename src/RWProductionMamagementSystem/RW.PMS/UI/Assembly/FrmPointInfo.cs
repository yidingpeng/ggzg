using RW.PMS.Common;
using RW.PMS.IBLL.Programs;
using RW.PMS.Model.Programs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Assembly
{
    public partial class FrmPointInfo : Form
    {
        private static IBLL_PointInfo BLL = DIService.GetService<IBLL_PointInfo>();
        public FrmPointInfo()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            bindData();
        }

        public void bindData()
        {
            List<PointInfoModel> list = BLL.GetPointInfo(txtexplain.Text,0);
            dataGridView1.DataSource = list;

        }

        /// <summary>
        /// 点位添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            FrmPointInfoEdit feedback = new FrmPointInfoEdit(EDAEnums.ActionType.Add.ToString(), 0);
            DialogResult dialogresult = feedback.ShowDialog();
            //判断是否返回为OK，刷新窗体
            if (dialogresult == DialogResult.OK)
            {
                bindData();
            }
        }
        /// <summary>
        /// 点位修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnEdit_Click(object sender, EventArgs e)
        {
            //获取ID
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column1"].Value) : 0;
            if (ID != 0)
            {
                FrmPointInfoEdit feedback = new FrmPointInfoEdit(EDAEnums.ActionType.Edit.ToString(), ID);
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
        /// <summary>
        /// 点位删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult value = MessageBox.Show("你确定是否删除该点位信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (value == DialogResult.Yes)
                {
                    //获取ID
                    int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column1"].Value) : 0;
                    if (ID != 0)
                    {
                        int result = BLL.DeletePointInfo(ID);
                        if (result>0)
                        {
                            MessageBox.Show("删除成功！");
                            bindData();
                        }
                        else
                            MessageBox.Show("删除失败！");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            bindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //获取ID 
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Column1"].Value) : 0;
            FrmPointInfoEdit feedback = new FrmPointInfoEdit(EDAEnums.ActionType.Edit.ToString(), ID);
            DialogResult dialogresult = feedback.ShowDialog();
            //判断是否返回为OK，刷新窗体
            if (dialogresult == DialogResult.OK)
            {
                bindData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindData();
        }
    }
}
