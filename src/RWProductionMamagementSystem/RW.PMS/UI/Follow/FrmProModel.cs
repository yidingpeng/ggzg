using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
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
    public partial class FrmProModel : Form
    {
        private static IBLL_BaseInfo BLL = DIService.GetService<IBLL_BaseInfo>();
        public FrmProModel()
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

        private void FrmProModel_Load(object sender, EventArgs e)
        {
            bindData();
        }

        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            FrmProModelEdit feedback = new FrmProModelEdit(EDAEnums.ActionType.Add.ToString(), 0);
            DialogResult dialogresult = feedback.ShowDialog();

            //判断是否返回为OK，刷新窗体    
            if (dialogresult == DialogResult.OK)
            {
                bindData();
                Main .frm1.BindFormulaDLL();
            }
        }

        //绑定查询 
        public void bindData()
        {
            try
            {
                List<BaseProductModelModel> list = BLL.GetProductModelAll();
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolbtnEdit_Click(object sender, EventArgs e)
        {
            //获取ID 
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value) : 0;
            if (ID != 0)
            {
                FrmProModelEdit feedback = new FrmProModelEdit(EDAEnums.ActionType.Edit.ToString(), ID);
                DialogResult dialogresult = feedback.ShowDialog();
                //判断是否返回为OK，刷新窗体 
                if (dialogresult == DialogResult.OK)
                {
                    bindData();
                    Main.frm1.BindFormulaDLL();
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
                DialogResult value = MessageBox.Show("你确定是否删除该产品型号？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (value == DialogResult.Yes)
                {
                    //获取ID 
                    int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value) : 0;
                    if (ID != 0)
                    {
                        BLL.DeleteBaseProductModel(ID.ToString());
                        MessageBox.Show("删除成功！");
                        bindData();
                        Main.frm1.BindFormulaDLL();
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //获取ID
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value) : 0;
            FrmProModelEdit formula = new FrmProModelEdit(EDAEnums.ActionType.Edit.ToString(), ID);
            DialogResult dialogresult = formula.ShowDialog();
            //判断是否返回为OK，刷新窗体
            if (dialogresult == DialogResult.OK)
            {
                bindData();
                Main.frm1.BindFormulaDLL();
            }
        }
    }
}
