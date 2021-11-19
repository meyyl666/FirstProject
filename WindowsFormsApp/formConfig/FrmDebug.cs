using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp;



namespace WindowsFormsApp.formConfig
{
    /// <summary>
    /// 此类用于控制Debug界面控件的行为，控件初始化在主界面中进行
    /// </summary>
    public class FrmDebug : Form
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmDebug
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "FrmDebug";
            this.Load += new System.EventHandler(this.FrmDebug_Load);
            this.ResumeLayout(false);

        }

        private void FrmDebug_Load(object sender, EventArgs e)
        {

        }
    }
}
