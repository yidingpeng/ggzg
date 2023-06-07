using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RW.PMS.IBLL;
using RW.PMS.Common;
using RW.PMS.Utils;

namespace RW.PMS.WinForm.UI.Assembly
{
    /// <summary>
    /// 装配记录查询窗体
    /// </summary>
    public partial class FrmAssemblyFollow : Form
    {
        IBLL_Assembly BLL = DIService.GetService<IBLL_Assembly>();
        public FrmAssemblyFollow()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void FrmAssemblyFollow_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Value = PublicVariable.GetServerTime();
            dateTimePicker2.Value = PublicVariable.GetServerTime();

            search();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            int gwID = PublicVariable.CurGwID;
            string prodNo = txtProdNo.Text.Trim();
            string begindate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string enddate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            dataGridView1.DataSource = BLL.GetGongweiAssembly(gwID, prodNo, begindate, enddate);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
