using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Sys;
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
    public partial class FrmSysLog : Form
    {
        private static IBLL_System BLL = DIService.GetService<IBLL_System>();

        public FrmSysLog()
        {
            InitializeComponent();
            bindData();
        }

        public void bindData()
        {
            string starttime = dtpStartTime.Value.ToString("yyyy-MM-dd");
            string endtime = dtpEndTime.Value.ToString("yyyy-MM-dd");
            List<SysLogModel> list = BLL.GetSysLog(starttime, endtime);
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindData();
        }
    }
}
