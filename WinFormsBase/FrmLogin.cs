using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace WinFormsBase
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            CloseTimer.Interval = 20;
            CloseTimer.Tick += CloseTimer_Tick;
        }


        #region 窗体变色效果

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //获取画布
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));

            LinearGradientBrush brush = new LinearGradientBrush(rec, Color.FromArgb(225, 101, 127), Color.FromArgb(93, 127, 124),LinearGradientMode.BackwardDiagonal);

            g.FillRectangle(brush, rec);
        }






        #endregion


        #region 无边框拖动


        

        private void lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            //获取位置
            mPoint = e.Location;
        }

        private void lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            //只有左键才能拖动
            if(e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }


        private Point mPoint;
        #endregion

        private void lbl_login_Click(object sender, EventArgs e)
        {
            MessageBox.Show("登陆成功");
            this.Close();
        }
            

        //创建定时器
        private Timer CloseTimer = new Timer();
        private void CloseTimer_Tick(object sender,EventArgs e)
        {
            if (this.Opacity >= 0.025)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                this.CloseTimer.Enabled = false;
                this.Close();
            }
        }
        /// <summary>
        /// 关闭淡出效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_close_Click(object sender, EventArgs e)
        {
            //开定时器
            CloseTimer.Enabled = true;
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void txt_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("登陆成功");
        }
    }
}
