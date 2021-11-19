
namespace WinFormsBase
{
    partial class FrmWorking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorking));
            this.btn_Init = new HZH_Controls.Controls.UCBtnExt();
            this.btn_Start = new HZH_Controls.Controls.UCSwitch();
            this.ste_WorkStep = new HZH_Controls.Controls.UCStep();
            this.lab_Step = new CCWin.SkinControl.SkinLabel();
            this.bar_Step = new CCWin.SkinControl.SkinProgressBar();
            this.btn_Debug = new HZH_Controls.Controls.UCBtnImg();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.lab_PLCStatus = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.lab_RobStatus = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.lab_CamStatus = new CCWin.SkinControl.SkinLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Init
            // 
            this.btn_Init.BackColor = System.Drawing.Color.White;
            this.btn_Init.BtnBackColor = System.Drawing.Color.White;
            this.btn_Init.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Init.BtnForeColor = System.Drawing.Color.White;
            this.btn_Init.BtnText = "初始化";
            this.btn_Init.ConerRadius = 5;
            this.btn_Init.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Init.EnabledMouseEffect = false;
            this.btn_Init.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btn_Init.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Init.IsRadius = true;
            this.btn_Init.IsShowRect = true;
            this.btn_Init.IsShowTips = false;
            this.btn_Init.Location = new System.Drawing.Point(357, 65);
            this.btn_Init.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Init.RectWidth = 1;
            this.btn_Init.Size = new System.Drawing.Size(132, 102);
            this.btn_Init.TabIndex = 42;
            this.btn_Init.TabStop = false;
            this.btn_Init.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Init.TipsText = "";
            this.btn_Init.BtnClick += new System.EventHandler(this.btn_Init_BtnClick);
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_Start.Checked = false;
            this.btn_Start.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btn_Start.FalseTextColr = System.Drawing.Color.Black;
            this.btn_Start.Location = new System.Drawing.Point(76, 76);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(203, 74);
            this.btn_Start.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.btn_Start.TabIndex = 43;
            this.btn_Start.Texts = new string[] {
        "停止",
        "启动"};
            this.btn_Start.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btn_Start.TrueTextColr = System.Drawing.Color.White;
            this.btn_Start.CheckedChanged += new System.EventHandler(this.btn_Start_CheckedChanged);
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // ste_WorkStep
            // 
            this.ste_WorkStep.BackColor = System.Drawing.Color.Transparent;
            this.ste_WorkStep.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ste_WorkStep.ForeColor = System.Drawing.Color.Black;
            this.ste_WorkStep.ImgCompleted = null;
            this.ste_WorkStep.LineWidth = 2;
            this.ste_WorkStep.Location = new System.Drawing.Point(76, 239);
            this.ste_WorkStep.Name = "ste_WorkStep";
            this.ste_WorkStep.Size = new System.Drawing.Size(823, 190);
            this.ste_WorkStep.StepBackColor = System.Drawing.Color.Gray;
            this.ste_WorkStep.StepFontColor = System.Drawing.Color.DimGray;
            this.ste_WorkStep.StepForeColor = System.Drawing.Color.YellowGreen;
            this.ste_WorkStep.StepIndex = 0;
            this.ste_WorkStep.Steps = new string[] {
        "初始化",
        "寻找Mark点",
        "校准切向偏移",
        "校准径向偏移",
        "校准旋转偏移",
        "取放盘片"};
            this.ste_WorkStep.StepWidth = 35;
            this.ste_WorkStep.TabIndex = 44;
            this.ste_WorkStep.TabStop = false;
            // 
            // lab_Step
            // 
            this.lab_Step.AutoSize = true;
            this.lab_Step.BackColor = System.Drawing.Color.Transparent;
            this.lab_Step.BorderColor = System.Drawing.Color.White;
            this.lab_Step.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Step.Location = new System.Drawing.Point(506, 700);
            this.lab_Step.Name = "lab_Step";
            this.lab_Step.Size = new System.Drawing.Size(54, 20);
            this.lab_Step.TabIndex = 45;
            this.lab_Step.Text = "进度：";
            // 
            // bar_Step
            // 
            this.bar_Step.Back = null;
            this.bar_Step.BackColor = System.Drawing.Color.Transparent;
            this.bar_Step.BarBack = null;
            this.bar_Step.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.bar_Step.ForeColor = System.Drawing.Color.Red;
            this.bar_Step.Location = new System.Drawing.Point(702, 700);
            this.bar_Step.Name = "bar_Step";
            this.bar_Step.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.bar_Step.Size = new System.Drawing.Size(155, 23);
            this.bar_Step.TabIndex = 46;
            // 
            // btn_Debug
            // 
            this.btn_Debug.BackColor = System.Drawing.Color.White;
            this.btn_Debug.BtnBackColor = System.Drawing.Color.White;
            this.btn_Debug.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            this.btn_Debug.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btn_Debug.BtnText = "调试";
            this.btn_Debug.ConerRadius = 5;
            this.btn_Debug.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Debug.EnabledMouseEffect = false;
            this.btn_Debug.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btn_Debug.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Debug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btn_Debug.Image = ((System.Drawing.Image)(resources.GetObject("btn_Debug.Image")));
            this.btn_Debug.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Debug.ImageFontIcons = null;
            this.btn_Debug.IsRadius = true;
            this.btn_Debug.IsShowRect = true;
            this.btn_Debug.IsShowTips = false;
            this.btn_Debug.Location = new System.Drawing.Point(603, 65);
            this.btn_Debug.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Debug.Name = "btn_Debug";
            this.btn_Debug.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Debug.RectWidth = 1;
            this.btn_Debug.Size = new System.Drawing.Size(134, 102);
            this.btn_Debug.TabIndex = 47;
            this.btn_Debug.TabStop = false;
            this.btn_Debug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Debug.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Debug.TipsText = "";
            this.btn_Debug.BtnClick += new System.EventHandler(this.btn_Debug_BtnClick);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(81, 700);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(40, 20);
            this.skinLabel1.TabIndex = 48;
            this.skinLabel1.Text = "PLC:";
            // 
            // lab_PLCStatus
            // 
            this.lab_PLCStatus.AutoSize = true;
            this.lab_PLCStatus.BackColor = System.Drawing.Color.Transparent;
            this.lab_PLCStatus.BorderColor = System.Drawing.Color.White;
            this.lab_PLCStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_PLCStatus.ForeColor = System.Drawing.Color.Red;
            this.lab_PLCStatus.Location = new System.Drawing.Point(127, 700);
            this.lab_PLCStatus.Name = "lab_PLCStatus";
            this.lab_PLCStatus.Size = new System.Drawing.Size(39, 20);
            this.lab_PLCStatus.TabIndex = 49;
            this.lab_PLCStatus.Text = "离线";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(181, 700);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(58, 20);
            this.skinLabel3.TabIndex = 48;
            this.skinLabel3.Text = "机械臂:";
            // 
            // lab_RobStatus
            // 
            this.lab_RobStatus.AutoSize = true;
            this.lab_RobStatus.BackColor = System.Drawing.Color.Transparent;
            this.lab_RobStatus.BorderColor = System.Drawing.Color.White;
            this.lab_RobStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_RobStatus.ForeColor = System.Drawing.Color.Red;
            this.lab_RobStatus.Location = new System.Drawing.Point(235, 700);
            this.lab_RobStatus.Name = "lab_RobStatus";
            this.lab_RobStatus.Size = new System.Drawing.Size(39, 20);
            this.lab_RobStatus.TabIndex = 49;
            this.lab_RobStatus.Text = "离线";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(286, 700);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(43, 20);
            this.skinLabel2.TabIndex = 48;
            this.skinLabel2.Text = "相机:";
            // 
            // lab_CamStatus
            // 
            this.lab_CamStatus.AutoSize = true;
            this.lab_CamStatus.BackColor = System.Drawing.Color.Transparent;
            this.lab_CamStatus.BorderColor = System.Drawing.Color.White;
            this.lab_CamStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_CamStatus.ForeColor = System.Drawing.Color.Red;
            this.lab_CamStatus.Location = new System.Drawing.Point(335, 700);
            this.lab_CamStatus.Name = "lab_CamStatus";
            this.lab_CamStatus.Size = new System.Drawing.Size(39, 20);
            this.lab_CamStatus.TabIndex = 49;
            this.lab_CamStatus.Text = "离线";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(781, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmWorking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = global::WindowsFormsApp.Properties.Resources.metalBG;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            this.BackgroundImage = global::WindowsFormsApp.Properties.Resources.metalBG;
            this.BackPalace = global::WindowsFormsApp.Properties.Resources.metalBG;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lab_CamStatus);
            this.Controls.Add(this.lab_RobStatus);
            this.Controls.Add(this.lab_PLCStatus);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.btn_Debug);
            this.Controls.Add(this.bar_Step);
            this.Controls.Add(this.lab_Step);
            this.Controls.Add(this.ste_WorkStep);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_Init);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmWorking";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Text = "研磨机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorking_FormClosing);
            this.Load += new System.EventHandler(this.FrmWorking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HZH_Controls.Controls.UCBtnExt btn_Init;
        private HZH_Controls.Controls.UCSwitch btn_Start;
        private HZH_Controls.Controls.UCStep ste_WorkStep;
        private CCWin.SkinControl.SkinLabel lab_Step;
        private CCWin.SkinControl.SkinProgressBar bar_Step;
        private HZH_Controls.Controls.UCBtnImg btn_Debug;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel lab_PLCStatus;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel lab_RobStatus;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel lab_CamStatus;
        private System.Windows.Forms.Button button1;
    }
}