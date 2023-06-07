using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RW.PMS.IBLL;
using RW.PMS.Common;
using BaseEnty = RW.PMS.Model.BaseInfo;
using SysEnty = RW.PMS.Model.Sys;
using DevEnty = RW.PMS.Model.Device;
using RW.PMS.Model.Sys;

namespace RW.PMS.WinForm.UI.Device
{
    public partial class FrmDeviceSpotCheck : Form
    {
        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        IBLL_BaseInfo BaseBll = DIService.GetService<IBLL_BaseInfo>();

        public FrmDeviceSpotCheck()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;//选中单元格后为编辑状态

            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;  //设置自动换行

            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;//设置自动调整高度

            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True; //让整个DataGridView的所有cell都可以自动换行。

            dataGridView1.Columns["col_checkItem"].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
        }

        private void FrmDeviceSpotCheck_Load(object sender, EventArgs e)
        {

        }

        private void BindData() { 
          
        }
    }
}
