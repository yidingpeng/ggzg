using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.CreateBarCode
{
    public partial class Form2 : FormSkin
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绘制序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = row.Index + 1;

            }
        }


        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("生成数量无法小于等于零！");
                return;
            }
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                Thread.Sleep(5);
                additem(DateTime.Now.ToString("yyMMddHHmmssfff"));
            }
        }


        /// <summary>
        /// 向 DataGridView中添加行
        /// </summary>
        /// <param name="Code"></param>
        public void additem(string ColName)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            foreach (DataGridViewColumn c in this.dataGridView1.Columns)
            {
                dgvr.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
            }
            dgvr.Cells[1].Value = ColName;
            this.dataGridView1.Rows.Add(dgvr);
        }


        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            int SerialNumberCount = 0;

            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("当前没有需要导出的分装编号信息，请检查！");
                return;
            }

            var dialog = saveFileDialog.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                CreateExcelFile(saveFileDialog.FileName);
            }

        }


        private void CreateExcelFile(string filePath)
        {
            try
            {
                var workbook = new XSSFWorkbook();
                //创建sheet1
                ISheet sheet = workbook.CreateSheet("Sheet1");

                //创建行
                IRow headrow = sheet.CreateRow(0);
                headrow.CreateCell(0, CellType.String).SetCellValue("no");

                //循环添加内容
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    IRow Datarow = sheet.CreateRow(i + 1);

                    var Name = dataGridView1.Rows[i].Cells["ColPartsNo"].Value.ToString();//分装部件编号
                    Datarow.CreateCell(0, CellType.String).SetCellValue(Name);
                }

                using (var file = File.OpenWrite(filePath))
                {
                    workbook.Write(file);
                }
                workbook.Close();

                dataGridView1.Rows.Clear();
                MessageBox.Show("导出成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }







    }
}
