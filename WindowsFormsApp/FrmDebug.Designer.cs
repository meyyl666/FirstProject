
namespace WindowsFormsApp
{
    partial class FrmDebug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connect = new HZH_Controls.Controls.UCBtnImg();
            this.ipCheck1 = new WindowsFormsApp.IPCheck.IPCheck();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.Color.White;
            this.btn_Connect.BtnBackColor = System.Drawing.Color.White;
            this.btn_Connect.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            this.btn_Connect.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btn_Connect.BtnText = "连接";
            this.btn_Connect.ConerRadius = 5;
            this.btn_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Connect.EnabledMouseEffect = false;
            this.btn_Connect.FillColor = System.Drawing.Color.Red;
            this.btn_Connect.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Connect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btn_Connect.Image = null;
            this.btn_Connect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Connect.ImageFontIcons = null;
            this.btn_Connect.IsRadius = true;
            this.btn_Connect.IsShowRect = true;
            this.btn_Connect.IsShowTips = false;
            this.btn_Connect.Location = new System.Drawing.Point(519, 73);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Connect.RectWidth = 1;
            this.btn_Connect.Size = new System.Drawing.Size(184, 60);
            this.btn_Connect.TabIndex = 43;
            this.btn_Connect.TabStop = false;
            this.btn_Connect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Connect.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Connect.TipsText = "";
            this.btn_Connect.BtnClick += new System.EventHandler(this.btn_Connect_BtnClick);
            // 
            // ipCheck1
            // 
            this.ipCheck1.CameraBusy = false;
            this.ipCheck1.CameraIP = "127.0.0.0";
            this.ipCheck1.Editable = true;
            this.ipCheck1.Location = new System.Drawing.Point(57, 26);
            this.ipCheck1.Name = "ipCheck1";
            this.ipCheck1.PLCBusy = false;
            this.ipCheck1.RobotBusy = false;
            this.ipCheck1.Size = new System.Drawing.Size(400, 200);
            this.ipCheck1.TabIndex = 44;
            // 
            // FrmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 601);
            this.Controls.Add(this.ipCheck1);
            this.Controls.Add(this.btn_Connect);
            this.Name = "FrmDebug";
            this.Text = "FrmDebug";
            this.Load += new System.EventHandler(this.FrmDebug_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCBtnImg btn_Connect;
        private IPCheck.IPCheck ipCheck1;
    }
}