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
using System.Data.SqlClient;
using WinFormsBase.mothedCls;


namespace WinFormsBase
{
    public partial class FrmLogin : Form
    {
        ClsCon con = new ClsCon();  //实例化连接对象con
        clsLoginMethed cm = new clsLoginMethed();  //实例化登陆方法cm   
        clsLogin cl = new clsLogin();   //实例化登陆对象
        string ErrorNum = string.Empty; //记录登陆时用户名
        int Num = 0;  //记录点击次数

        

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
            #region 用户与密码是否正确不正确给三次机会然后关闭
            cl.LName = this.txt_UserName.Text;    //获取用户输入的用户名
            cl.LPwd = this.txt_PassWord.Text;  //获取用户输入的密码
            //clsMD5Encrypt.GetMD5Password(this.txt_PassWord.Text.Trim().ToString())
            string Pwd = cm.Select_Table(cl);  //查询该用户正确密码
            if(Pwd == cl.LPwd)
            {
                MessageBox.Show("登陆成功");


                //下面要进入操作界面了

                ///////////////////////////////////////
                ///

                //////////////////////////////////

            }
            else if(this.txt_UserName.Text == "" || this.txt_PassWord.Text == "")
            {
                MessageBox.Show("请输入用户名或密码");
            }
            else if(Pwd == "error")
            {
                MessageBox.Show("请检查数据库名与查询表名是否出现错误");
            }
            else   //密码输入错误
            {
                if(ErrorNum == cl.LName)
                {
                    Num++;
                    if(Num >= 3)
                    {
                        this.Close();
                    }
                }
                else
                {
                    ErrorNum = cl.LName;
                    Num++;
                }
                MessageBox.Show("用户名或密码有误,三次后将自动关闭,这是第" + Num + "次");
                this.txt_PassWord.Text = string.Empty;
                this.txt_PassWord.Focus();
            }

            #endregion
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


        /// <summary>
        /// 加载登录界面时，进行连接数据库测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                con.ConDatabase();    //连接数据库
                if (con._mySql.State == ConnectionState.Open)
                {
                    txt_dbstate.Text = "数据库连接成功";
                }
                else
                {
                    txt_dbstate.Text = "数据库未连接";
                }
                //using (con._mySql = new SqlConnection("server=DESKTOP-9OCF6G3;pwd=qq64022020;uid=sa;database=db_Point"))
                //{
                //    con._mySql.Open();

                //    if (con._mySql.State == ConnectionState.Open)
                //    {
                //        txt_dbstate.Text = "数据库连接成功";
                //        con._mySql.Close();//关闭连接
                //    }
                //}
            }
            catch (Exception ex)
            {
                txt_dbstate.Text = ex.Message;
            }



        }

        private void txt_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }


        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Title_Click(object sender, EventArgs e)
        {

        }
    }
}
