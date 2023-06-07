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
    public partial class FrmPointInfoEdit : Form
    {
        private string frm_actionType = "";
        private int frm_ID = 0;
        private static IBLL_PointInfo BLL = DIService.GetService<IBLL_PointInfo>();

        public FrmPointInfoEdit(string _actionType, int ID)
        {
            InitializeComponent();

            frm_actionType = _actionType;
            frm_ID = ID;
            if (frm_ID != 0)
            {
                BindData();
            }
        }

        public void BindData()
        {
            var data= BLL.GetPointInfo(null, frm_ID);
            txtTagName.Text = data[0].TagName;
            txtAddress.Text = data[0].Address;
            txtExplain.Text = data[0].ExplainInfo;
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frm_actionType == EDAEnums.ActionType.Add.ToString())
            {
                if (Check())
                {
                    PointInfoModel pointInfo = new PointInfoModel { ID = frm_ID, TagName =txtTagName.Text, Address=txtAddress.Text, ExplainInfo = txtExplain.Text };
                    int Result = BLL.EditPointInfo(pointInfo);
                    if (Result>0)
                    {
                        MessageBox.Show("保存成功！");
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (Result==-1)
                    {
                        MessageBox.Show("已存在该标记名称记录！");
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                }
            }
            else if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
            {
                PointInfoModel pointInfo = new PointInfoModel { ID=frm_ID, TagName = txtTagName.Text, Address = txtAddress.Text, ExplainInfo = txtExplain.Text };
                pointInfo.ID = Convert.ToInt32(frm_ID);
                int Result = BLL.EditPointInfo(pointInfo);
                if (Result>0)
                {
                    MessageBox.Show("修改成功！");
                    this.DialogResult = DialogResult.OK;
                }
                else if (Result == -1)
                {
                    MessageBox.Show("已存在该标记名称记录！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }


        public bool Check()
        {
            if (String.IsNullOrEmpty(txtTagName.Text))
            {
                MessageBox.Show("请输入标记名称");
                return false;
            }
            else if (String.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("请输入地址");
                return false;
            }
            else if (String.IsNullOrEmpty(txtExplain.Text))
            {
                MessageBox.Show("请输入说明");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
