using System;
using System.Collections.Generic;
using WindowsFormsApp.deviceConnect;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp
{
    public partial class FrmDebug : Form
    {
        public FrmDebug()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | //不擦除背景
                 ControlStyles.OptimizedDoubleBuffer | //双缓冲
                 ControlStyles.UserPaint,    //使用自定义重绘事件
                 true);
            this.UpdateStyles();
            InitializeComponent();
        }

        private void FrmDebug_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitUpdate();
            ConnectConfig.DisConnecting += (o, ex) =>
            {
                
            };
        }

        private void btn_Connect_BtnClick(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;
             Task.Run(() =>
            {
                if(!ConnectConfig.CameraConnected)  //如果连接状态为false
                {
                    ConnectConfig.Connect();
                    btn_Connect.FillColor = Color.LightGreen;  
                }
                else
                {
                    ConnectConfig.DisConnect();
                    btn_Connect.FillColor = Color.Red;
                }

            });
            btn_Connect.Enabled = true;

        }

        private void InitUpdate()
        {

        }
    }
}
