using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Device;
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

namespace RW.PMS.WinForm.UI.Device
{
    public partial class FrmPreviewPicture : Form
    {
        private int ID = 0;

        IBLL_Device BLL = DIService.GetService<IBLL_Device>();

        public FrmPreviewPicture(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private void FrmPreviewPicture_Load(object sender, EventArgs e)
        {
            List<Device_upkeepPlanDetailModel> picture = BLL.GetDevicePlanDetail().Where(p => p.id == ID).ToList();
            SetImage(picture[0].udimg);
        }


        /// <summary>
        /// 设置预览大图片
        /// </summary>
        /// <param name="image"></param>
        private void SetImage(byte[] image)
        {
            try
            {
                //员工头像显示
                if (image == null || image.Length == 0) return;
                MemoryStream myStream = new MemoryStream();
                foreach (byte a in image)
                {
                    myStream.WriteByte(a);
                }
                Image myImage = Image.FromStream(myStream);
                myStream.Close();
                this.pictureBox1.Image = myImage;
                this.pictureBox1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
