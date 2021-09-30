﻿
namespace WinFormsBase
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.lbl_LoginUser = new System.Windows.Forms.Label();
            this.lbl_LoginPassWord = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pic_close = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_close)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_LoginUser
            // 
            this.lbl_LoginUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_LoginUser.AutoSize = true;
            this.lbl_LoginUser.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LoginUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_LoginUser.Location = new System.Drawing.Point(72, 109);
            this.lbl_LoginUser.Name = "lbl_LoginUser";
            this.lbl_LoginUser.Size = new System.Drawing.Size(74, 21);
            this.lbl_LoginUser.TabIndex = 0;
            this.lbl_LoginUser.Text = "登录用户";
            // 
            // lbl_LoginPassWord
            // 
            this.lbl_LoginPassWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_LoginPassWord.AutoSize = true;
            this.lbl_LoginPassWord.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LoginPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_LoginPassWord.Location = new System.Drawing.Point(72, 152);
            this.lbl_LoginPassWord.Name = "lbl_LoginPassWord";
            this.lbl_LoginPassWord.Size = new System.Drawing.Size(74, 21);
            this.lbl_LoginPassWord.TabIndex = 0;
            this.lbl_LoginPassWord.Text = "登录密码";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_UserName.Location = new System.Drawing.Point(196, 112);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(100, 20);
            this.txt_UserName.TabIndex = 1;
            this.txt_UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_UserName_KeyDown);
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_PassWord.Location = new System.Drawing.Point(196, 152);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.Size = new System.Drawing.Size(100, 23);
            this.txt_PassWord.TabIndex = 2;
            // 
            // btn_Login
            // 
            this.btn_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Login.BackColor = System.Drawing.Color.DarkKhaki;
            this.btn_Login.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btn_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            this.btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(72, 210);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(224, 47);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "登陆系统";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.lbl_login_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(380, 73);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "欢迎使用***登陆系统";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbl_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseDown);
            this.lbl_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_title_MouseMove);
            // 
            // pic_close
            // 
            this.pic_close.BackColor = System.Drawing.Color.Transparent;
            this.pic_close.Image = ((System.Drawing.Image)(resources.GetObject("pic_close.Image")));
            this.pic_close.Location = new System.Drawing.Point(337, 0);
            this.pic_close.Name = "pic_close";
            this.pic_close.Size = new System.Drawing.Size(43, 48);
            this.pic_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_close.TabIndex = 4;
            this.pic_close.TabStop = false;
            this.pic_close.Click += new System.EventHandler(this.pic_close_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(101)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(380, 295);
            this.Controls.Add(this.pic_close);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_PassWord);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.lbl_LoginPassWord);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.lbl_LoginUser);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_LoginUser;
        private System.Windows.Forms.Label lbl_LoginPassWord;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pic_close;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;


    }
}

