using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Torque;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace RW.PMS.WinForm.UI.Assembly
{
    public partial class FrmPrintCode : Form
    {
        IBLL_Torque bll = DIService.GetService<IBLL_Torque>();
        //初始化绑定默认关键词（此数据源可以从数据库取）
        List<string> listOnit = new List<string>();
        public FrmPrintCode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定ComboBox
        /// </summary>
        private void BindComboBox()
        {
            List<TorqueTool> list = bll.JDListAll();
            foreach (var item in list)
            {
                listOnit.Add(item.TorqueName + "-" + item.TorqueCode);
            }

            /*
             * 1.注意用Item.Add(obj)或者Item.AddRange(obj)方式添加
             * 2.如果用DataSource绑定，后面再进行绑定是不行的，即便是Add或者Clear也不行
             */
            this.cmbToolName.Items.AddRange(listOnit.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cmbToolName.SelectedItem != null)
            {
                //实例化打印对象
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,可以自定义纸张的大小(单位：mm).  当打印高度不确定时也可以不设置
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custum", 197, 157);

                //注册PrintPage事件，打印每一页时会触发该事件
                printDocument1.PrintPage += new PrintPageEventHandler(this.PrintCode);
                printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = "Zebra GX430t";//打印机名称

                //开始打印
                printDocument1.Print();
            }
            else
            {
                MessageBox.Show("请选择扳手信息！");
            }
        }

        private void PrintCode(object sender, PrintPageEventArgs e)
        {
            Font Fonts = new Font("Microsoft YaHei", 8, FontStyle.Regular); //标题字体  
            Font FontBarCode = new Font("Microsoft YaHei", 8, FontStyle.Regular); //条码字体           
            Brush Brush = new SolidBrush(Color.Black); //画刷 

            Bitmap bitmap = CreateCode(this.cmbToolName.SelectedItem.ToString().Split('-')[1]);
            e.Graphics.DrawImage(bitmap, new Point(0, 30));

            //使绘图质量最高，即消除锯齿
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        }


        //生成条码
        public Bitmap CreateCode(string code)
        {
            EncodingOptions encoding = new EncodingOptions();
            encoding.Height = 80;
            encoding.Width = 220;

            ZXing.BarcodeWriter barcode = new ZXing.BarcodeWriter();
            barcode.Options = encoding;
            barcode.Format = BarcodeFormat.CODE_128;

            return barcode.Write(code);
        }

        private void FrmPrintCode_Load(object sender, EventArgs e)
        {
            BindComboBox();
        }
    }
}
