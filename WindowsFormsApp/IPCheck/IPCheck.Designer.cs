using System.ComponentModel;
using System.Windows.Forms;
using CCWin;

namespace WindowsFormsApp.IPCheck
{
    [ToolboxItem(true)]
    public partial class IPCheck
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.pan_PLCCon = new CCWin.SkinControl.SkinPanel();
            this.pan_CamCon = new CCWin.SkinControl.SkinPanel();
            this.pan_RobCon = new CCWin.SkinControl.SkinPanel();
            this.cbx_PLCIP = new CCWin.SkinControl.SkinComboBox();
            this.cbx_CameraIP = new CCWin.SkinControl.SkinComboBox();
            this.cbx_RobotIP = new CCWin.SkinControl.SkinComboBox();
            this.lab_PLCDelay = new CCWin.SkinControl.SkinLabel();
            this.lab_CamDelay = new CCWin.SkinControl.SkinLabel();
            this.lab_RobDelay = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(23, 29);
            this.skinLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(36, 20);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "PLC";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(23, 79);
            this.skinLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(39, 20);
            this.skinLabel2.TabIndex = 0;
            this.skinLabel2.Text = "相机";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(23, 128);
            this.skinLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(54, 20);
            this.skinLabel3.TabIndex = 0;
            this.skinLabel3.Text = "机械臂";
            // 
            // pan_PLCCon
            // 
            this.pan_PLCCon.BackColor = System.Drawing.Color.Red;
            this.pan_PLCCon.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pan_PLCCon.DownBack = null;
            this.pan_PLCCon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pan_PLCCon.Location = new System.Drawing.Point(287, 19);
            this.pan_PLCCon.Margin = new System.Windows.Forms.Padding(0);
            this.pan_PLCCon.MouseBack = null;
            this.pan_PLCCon.Name = "pan_PLCCon";
            this.pan_PLCCon.NormlBack = null;
            this.pan_PLCCon.Size = new System.Drawing.Size(30, 30);
            this.pan_PLCCon.TabIndex = 1;
            // 
            // pan_CamCon
            // 
            this.pan_CamCon.BackColor = System.Drawing.Color.Red;
            this.pan_CamCon.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pan_CamCon.DownBack = null;
            this.pan_CamCon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pan_CamCon.Location = new System.Drawing.Point(287, 69);
            this.pan_CamCon.Margin = new System.Windows.Forms.Padding(0);
            this.pan_CamCon.MouseBack = null;
            this.pan_CamCon.Name = "pan_CamCon";
            this.pan_CamCon.NormlBack = null;
            this.pan_CamCon.Size = new System.Drawing.Size(30, 30);
            this.pan_CamCon.TabIndex = 2;
            this.pan_CamCon.Click += new System.EventHandler(this.pan_CamCon_Click);
            // 
            // pan_RobCon
            // 
            this.pan_RobCon.BackColor = System.Drawing.Color.Red;
            this.pan_RobCon.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pan_RobCon.DownBack = null;
            this.pan_RobCon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pan_RobCon.Location = new System.Drawing.Point(287, 118);
            this.pan_RobCon.Margin = new System.Windows.Forms.Padding(0);
            this.pan_RobCon.MouseBack = null;
            this.pan_RobCon.Name = "pan_RobCon";
            this.pan_RobCon.NormlBack = null;
            this.pan_RobCon.Size = new System.Drawing.Size(30, 30);
            this.pan_RobCon.TabIndex = 2;
            // 
            // cbx_PLCIP
            // 
            this.cbx_PLCIP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_PLCIP.FormattingEnabled = true;
            this.cbx_PLCIP.Location = new System.Drawing.Point(111, 23);
            this.cbx_PLCIP.Name = "cbx_PLCIP";
            this.cbx_PLCIP.Size = new System.Drawing.Size(149, 26);
            this.cbx_PLCIP.TabIndex = 3;
            this.cbx_PLCIP.Text = "127.0.0.0";
            this.cbx_PLCIP.WaterText = "";
            // 
            // cbx_CameraIP
            // 
            this.cbx_CameraIP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_CameraIP.FormattingEnabled = true;
            this.cbx_CameraIP.Location = new System.Drawing.Point(111, 73);
            this.cbx_CameraIP.Name = "cbx_CameraIP";
            this.cbx_CameraIP.Size = new System.Drawing.Size(149, 26);
            this.cbx_CameraIP.TabIndex = 3;
            this.cbx_CameraIP.Text = "192.168.250.60";
            this.cbx_CameraIP.WaterText = "";
            // 
            // cbx_RobotIP
            // 
            this.cbx_RobotIP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_RobotIP.FormattingEnabled = true;
            this.cbx_RobotIP.Location = new System.Drawing.Point(111, 128);
            this.cbx_RobotIP.Name = "cbx_RobotIP";
            this.cbx_RobotIP.Size = new System.Drawing.Size(149, 26);
            this.cbx_RobotIP.TabIndex = 3;
            this.cbx_RobotIP.Text = "127.0.0.0";
            this.cbx_RobotIP.WaterText = "";
            // 
            // lab_PLCDelay
            // 
            this.lab_PLCDelay.AutoSize = true;
            this.lab_PLCDelay.BackColor = System.Drawing.Color.Transparent;
            this.lab_PLCDelay.BorderColor = System.Drawing.Color.White;
            this.lab_PLCDelay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_PLCDelay.Location = new System.Drawing.Point(341, 19);
            this.lab_PLCDelay.Name = "lab_PLCDelay";
            this.lab_PLCDelay.Size = new System.Drawing.Size(39, 20);
            this.lab_PLCDelay.TabIndex = 5;
            this.lab_PLCDelay.Text = "0ms";
            // 
            // lab_CamDelay
            // 
            this.lab_CamDelay.AutoSize = true;
            this.lab_CamDelay.BackColor = System.Drawing.Color.Transparent;
            this.lab_CamDelay.BorderColor = System.Drawing.Color.White;
            this.lab_CamDelay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_CamDelay.Location = new System.Drawing.Point(341, 69);
            this.lab_CamDelay.Name = "lab_CamDelay";
            this.lab_CamDelay.Size = new System.Drawing.Size(39, 20);
            this.lab_CamDelay.TabIndex = 6;
            this.lab_CamDelay.Text = "0ms";
            // 
            // lab_RobDelay
            // 
            this.lab_RobDelay.AutoSize = true;
            this.lab_RobDelay.BackColor = System.Drawing.Color.Transparent;
            this.lab_RobDelay.BorderColor = System.Drawing.Color.White;
            this.lab_RobDelay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_RobDelay.Location = new System.Drawing.Point(341, 128);
            this.lab_RobDelay.Name = "lab_RobDelay";
            this.lab_RobDelay.Size = new System.Drawing.Size(39, 20);
            this.lab_RobDelay.TabIndex = 7;
            this.lab_RobDelay.Text = "0ms";
            // 
            // IPCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lab_RobDelay);
            this.Controls.Add(this.lab_CamDelay);
            this.Controls.Add(this.lab_PLCDelay);
            this.Controls.Add(this.cbx_RobotIP);
            this.Controls.Add(this.cbx_CameraIP);
            this.Controls.Add(this.cbx_PLCIP);
            this.Controls.Add(this.pan_RobCon);
            this.Controls.Add(this.pan_CamCon);
            this.Controls.Add(this.pan_PLCCon);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.Name = "IPCheck";
            this.Size = new System.Drawing.Size(400, 200);
            this.Load += new System.EventHandler(this.IPCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinPanel pan_PLCCon;
        private CCWin.SkinControl.SkinPanel pan_CamCon;
        private CCWin.SkinControl.SkinPanel pan_RobCon;
        private CCWin.SkinControl.SkinComboBox cbx_PLCIP;
        private CCWin.SkinControl.SkinComboBox cbx_CameraIP;
        private CCWin.SkinControl.SkinComboBox cbx_RobotIP;
        private CCWin.SkinControl.SkinLabel lab_PLCDelay;
        private CCWin.SkinControl.SkinLabel lab_CamDelay;
        private CCWin.SkinControl.SkinLabel lab_RobDelay;
    }
}
