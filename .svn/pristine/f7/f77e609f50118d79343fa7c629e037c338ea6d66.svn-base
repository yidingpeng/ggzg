using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.WinForm
{
    public class FormSkin: MaterialForm
    {
        protected readonly MaterialSkinManager materialSkinManager;
        protected FormSkin()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormSkin
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "FormSkin";
            this.ResumeLayout(false);

        }
    }
}
