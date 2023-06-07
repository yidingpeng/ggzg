using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.CreateBarCode
{
    public partial class Form1 : FormSkin
    {
        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();


        public class BarCode
        {
            public string Name { get; set; }

            public string DrawingNo { get; set; }

            public string SpecificationModels { get; set; }

            public string SerialNumber { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;//选中单元格后为编辑状态
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //绑定物料信息
            var ddlList = Basebll.GetMaterialBarCode();
            cmbMaterialBarCode.DataSource = ddlList;
            cmbMaterialBarCode.DisplayMember = "barcode";
            cmbMaterialBarCode.ValueMember = "ID";

            //绑定产品型号信息
            var ddlprodModel = Basebll.GetProductDrawingNoModel();
            cmbProdModel.DataSource = ddlprodModel;
            cmbProdModel.DisplayMember = "PmodelDrawingNo";
            cmbProdModel.ValueMember = "ID";

        }

        /// <summary>
        /// 添加按钮
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


            var m = Basebll.GetMaterialBarCodeByModel(new BaseMaterialBarCodeModel() { ID = cmbMaterialBarCode.SelectedValue.ToInt() });
            if (m != null)
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    additem(m.m_MaterialText, m.mDrawingNo, m.m_specificationmodels, m.m_manufacturer);
                }
            }

        }

        /// <summary>
        /// 向 DataGridView中添加行
        /// </summary>
        /// <param name="Code"></param>
        public void additem(string ColName, string ColDrawingNo, string ColSpecificationModels, string Colmanufacturer)
        {

            DataGridViewRow dgvr = new DataGridViewRow();
            foreach (DataGridViewColumn c in this.dataGridView1.Columns)
            {
                dgvr.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
            }
            dgvr.Cells[1].Value = ColName;
            dgvr.Cells[2].Value = ColDrawingNo;
            dgvr.Cells[3].Value = ColSpecificationModels == null ? "/" : ColSpecificationModels;
            dgvr.Cells[4].Value = Colmanufacturer;
            this.dataGridView1.Rows.Add(dgvr);
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
        /// 删除当前索引行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Remove(dataGridView1.Rows[index]);
        }

        /// <summary>
        /// 创建Excel 导出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCreate_Click(object sender, EventArgs e)
        {
            await AddRecord();
        }




        /// <summary>
        /// 添加记录明细
        /// </summary>
        /// <returns></returns>
        private async Task AddRecord()
        {
            int SerialNumberCount = 0;

            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("当前没有需要导出的条码信息，请检查！");
                return;
            }

            //if (nupBatteriesNoEnd.Value < nupBatteriesNoBeg.Value)
            //{
            //    MessageBox.Show("电芯流水号（结束）不能小于流水号（开始）！");
            //    nupBatteriesNoEnd.Focus();
            //    return;
            //}

            //var model = new BarcodeMain
            //{
            //    Year = cmbYear.SelectedItem.ToString(),
            //    Month = cmbMonth.SelectedItem.ToString(),
            //    ProdModel = cmbModelCode.SelectedItem.ToString(),
            //    ProdModelNoBegin = (int)nupModelNoBegin.Value,
            //    ProdModelNoEnd = (int)nupModelNoEnd.Value,
            //    BatteriesCode = cmbBatteriesCode.SelectedItem.ToString(),
            //    BatteriesNoBeg = (int)nupBatteriesNoBeg.Value,
            //    BatteriesNoEnd = (int)nupBatteriesNoEnd.Value,
            //    BatteriesNum = (int)nupBatteriesNum.Value,
            //    BackupNum = (int)nupBackupNum.Value,
            //    TotalNo = (int)nupTotal.Value
            //};

            //CreateBarcodeRecord(model);

            //var res = await _barcodeService.AddBarcode(model);

            //if (!res.Success)
            //{
            //    MessageBox.Show("添加出错！" + res.Message);
            //    return;
            //}

            //QueryBarcodeRecord(model.Records);

            //// MessageBox.Show("Records：" + model.Records.Count.ToString());



            //生成条码列表
            var Records = new List<BarCode>();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var SpecificationModelsValue = dataGridView1.Rows[index].Cells["ColSpecificationModels"].Value;
                var SerialNumberValue = dataGridView1.Rows[index].Cells["colSerialNumber"].Value;
                if (SerialNumberValue == null)
                    SerialNumberCount++;

                Records.Add(new BarCode
                {
                    Name = dataGridView1.Rows[index].Cells["ColName"].Value.ToString(),
                    DrawingNo = dataGridView1.Rows[index].Cells["ColDrawingNo"].Value.ToString(),
                    SpecificationModels = SpecificationModelsValue == null ? "/" : SpecificationModelsValue.ToString(),
                    SerialNumber = SerialNumberValue == null ? "" : SerialNumberValue.ToString()
                });
            }

            if (SerialNumberCount > 0)
            {
                MessageBox.Show("当前条码信息中有序列号为空，请检查！");
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
                headrow.CreateCell(0, CellType.String).SetCellValue("name");
                headrow.CreateCell(1, CellType.String).SetCellValue("drawingno");
                headrow.CreateCell(2, CellType.String).SetCellValue("specificationmodels");
                headrow.CreateCell(3, CellType.String).SetCellValue("manufacturer");
                headrow.CreateCell(4, CellType.String).SetCellValue("SerialNo");//序列号
                headrow.CreateCell(5, CellType.String).SetCellValue("SerialNumber");//二维码

                //循环添加内容
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    IRow Datarow = sheet.CreateRow(i + 1);

                    var Name = dataGridView1.Rows[i].Cells["ColName"].Value.ToString();//产品名称
                    var DrawingNo = dataGridView1.Rows[i].Cells["ColDrawingNo"].Value.ToString();//部件号或图号
                    var SpecificationModels = dataGridView1.Rows[i].Cells["ColSpecificationModels"].Value.ToString();//型号或规格
                    var manufacturer = dataGridView1.Rows[i].Cells["Colmanufacturer"].Value.ToString();//制造商名称
                    var SerialNumber = dataGridView1.Rows[i].Cells["colSerialNumber"].Value.ToString();//序列号

                    Datarow.CreateCell(0, CellType.String).SetCellValue(Name);
                    Datarow.CreateCell(1, CellType.String).SetCellValue(DrawingNo);
                    Datarow.CreateCell(2, CellType.String).SetCellValue(SpecificationModels);
                    Datarow.CreateCell(3, CellType.String).SetCellValue(manufacturer);
                    Datarow.CreateCell(4, CellType.String).SetCellValue(SerialNumber);//序列号

                    var serial = $"{DrawingNo};{SpecificationModels};{SerialNumber}";
                    Datarow.CreateCell(5, CellType.String).SetCellValue(serial);//二维码
                }

                //using (FileStream fs = new FileStream(filePath, FileMode.Create))
                //{
                //    workbook.Write(fs);
                //    workbook.Close();
                //}

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

        /// <summary>
        /// 手动清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var f2 = new Form2())
            {
                f2.ShowDialog();
                f2.Dispose();
            }
        }




    }
}
