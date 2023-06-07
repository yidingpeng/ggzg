using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Follow
{
    public partial class FromMainSettingEdit : Form
    {
        private string frm_actionType = "";
        private int frm_ID = 0;
        private static IBLL_BaseInfo BLL = DIService.GetService<IBLL_BaseInfo>();
        private static IBLL_Device BLLDevice = DIService.GetService<IBLL_Device>();

        public FromMainSettingEdit(string _actionType, int ID)
        {
            InitializeComponent();
            BindDLL();
            frm_actionType = _actionType;
            frm_ID = ID;
        }

        public void BindDLL()
        {
            var list = BLLDevice.GetAllDevice();
            MaintenanceItem.DataSource = list;
            MaintenanceItem.DisplayMember = "DevName";
            MaintenanceItem.ValueMember = "ID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MaintenanceItem.SelectedValue == null || ConvertHelper.ToInt32(MaintenanceItem.SelectedValue, 0) == 0)
            {
                MessageBox.Show("请选择保养项点。");
                return;
            }

            if (string.IsNullOrEmpty(this.MaintenanceContent.Text.Trim()))
            {
                MessageBox.Show("请填写保养内容。");
                return;
            }

            if (string.IsNullOrEmpty(this.Frequency.Text.Trim()))
            {
                MessageBox.Show("请填写保养频率。");
                return;
            }

            if (frm_actionType == EDAEnums.ActionType.Add.ToString())
            {
                MaintenanceSettingModel model = new MaintenanceSettingModel()
                {
                    MaintenanceItem = MaintenanceItem.SelectedValue.ToString(),
                    MaintenanceContent = MaintenanceContent.Text.Trim(),
                    Frequency = Frequency.Text.Trim().ToInt(),
                    Remark = Remark.Text.Trim(),
                    Personnel = PublicVariable.CurEmpID,
                    RelatedPicture = SaveImg(),
                    UpdateTime = DateTime.Now
                };

                BLL.AddMaintenanceSetting(model);

                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK;
            }
            else if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
            {
                MaintenanceSettingModel model = new MaintenanceSettingModel()
                {
                    ID = Convert.ToInt32(frm_ID),
                    MaintenanceItem = MaintenanceItem.SelectedValue.ToString(),
                    MaintenanceContent = MaintenanceContent.Text.Trim(),
                    Frequency = Frequency.Text.Trim().ToInt(),
                    Remark = Remark.Text.Trim(),
                    Personnel = PublicVariable.CurEmpID,
                    RelatedPicture = SaveImg(),
                    UpdateTime = DateTime.Now
                };

                BLL.EditMaintenanceSetting(model);

                MessageBox.Show("修改成功！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string SaveImg()
        {
            if (RelatedPicture.ImageLocation==null)
            {
                return "";
            }
            var fileName = $"{Guid.NewGuid().ToString().Replace("-", string.Empty)}.png";

            string imgurl = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Upload\\" + DateTime.Now.ToString("yyyyMMdd") + "\\";

            //文件夹不存在则创建
            if (!Directory.Exists(imgurl))
            {
                Directory.CreateDirectory(imgurl);
            }

            //图片完整路径 
            imgurl += fileName;

            if (RelatedPicture.ImageLocation == "")
            {
                return "";
            }
            else
            {
                Image image = Image.FromFile(RelatedPicture.ImageLocation);
                image.Save(imgurl);
                return imgurl;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogTemp = new OpenFileDialog();
            openFileDialogTemp.Title = "选择要上传的图片";
            openFileDialogTemp.Filter = "PNG(*.png)|*.png|JPEG(*.jpg)|*.jpg";
            openFileDialogTemp.Multiselect = true;
            DialogResult dr = openFileDialogTemp.ShowDialog();

            if (!File.Exists(openFileDialogTemp.FileName))
            {
                MessageBox.Show("照片为空，请选择图片");
                return;
            }

            RelatedPicture.ImageLocation = openFileDialogTemp.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RelatedPicture.ImageLocation = "";
        }

        private void FromMainSettingEdit_Load(object sender, EventArgs e)
        {
            if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
            {
                MaintenanceSettingModel model = BLL.GetMaintenanceSettingId(frm_ID);

                MaintenanceItem.SelectedValue = Convert.ToInt32(model.MaintenanceItem);
                RelatedPicture.ImageLocation = model.RelatedPicture;
                MaintenanceContent.Text = model.MaintenanceContent;
                Frequency.Text = model.Frequency.ToString();
                Remark.Text = model.Remark;
            }
        }

        /// <summary>
        /// 保养频率只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
