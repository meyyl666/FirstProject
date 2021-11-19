using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.components;

namespace WindowsFormsApp.IPCheck
{
    public partial class IPCheck : UserControl
    {
        public IPCheck()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | //不擦除背景
            ControlStyles.OptimizedDoubleBuffer | //双缓冲
            ControlStyles.UserPaint,    //使用自定义重绘事件
            true);
            InitializeComponent();
            
        }

        private void IPCheck_Load(object sender, EventArgs e)
        {
            
        }

        //供外文件获取和设置相机的IP
        public string CameraIP
        {
            set
            {
                cbx_CameraIP.Text = value;
            }
            get
            {
                return cbx_CameraIP.Text;
            }
        }

        //建立连接时间对象，用于检测连接是否超时
        Timer timer = new Timer();
        
        Ping PingCamera = new Ping();

        public bool Editable
        {
            get
            {
                return cbx_CameraIP.Enabled;
            }
            set
            {
                cbx_CameraIP.Enabled = value;
                cbx_PLCIP.Enabled = value;
                cbx_RobotIP.Enabled = value;
            }

        }

        //设备繁忙标志位
        private bool _cameraBusy = false;
        private bool _PLCBusy = false;
        private bool _robotBusy = false;


        private Timer busyTimer = new Timer();
        //获取设备状态 false 为不忙，true 为忙
        public bool CameraBusy
        {
            get
            {
                return _cameraBusy;
            }
            set
            {
                _cameraBusy = value;
                if(value)
                    busyTimer.Start();
                else
                {
                    if (!_PLCBusy && !_robotBusy)
                        busyTimer.Stop();
                }
            }
        }

        public bool PLCBusy
        {
            get
            {
                return _PLCBusy;
            }
            set
            {
                _PLCBusy = value;
                if (value)
                    busyTimer.Start();
                else
                {
                    if (!_cameraBusy && !_robotBusy)
                        busyTimer.Stop();
                }
            }
        }



        public bool RobotBusy
        {
            get
            {
                return _robotBusy;
            }
            set
            {
                _cameraBusy = value;
                if (value)
                    busyTimer.Start();
                else
                {
                    if (!_PLCBusy && !_cameraBusy)
                        busyTimer.Stop();
                }
            }
        }

        private async void pan_CamCon_Click(object sender, EventArgs e)
        {
            try
            {
                pan_CamCon.BackColor = Color.Red;
                Regex r = new Regex(@"(\d{1,3}\.){3}\d{1,3}");
                if (r.IsMatch(cbx_CameraIP.Text))
                {
                    //Save2Xml("CameraIP", cbx_CameraIP.Text);
                    if (CameraBusy) return;
                    CameraBusy = true;
                    var res = await PingCamera.SendPingAsync(cbx_CameraIP.Text);
                    long delay = res.RoundtripTime;
                    Console.Write(delay);
                    if (res.Status == IPStatus.Success)
                    {
                        pan_CamCon.BackColor = Color.Lime;
                        lab_CamDelay.Text = delay.ToString() + "ms";
                    }
                    else
                    {
                        pan_CamCon.BackColor = Color.Red;
                        lab_CamDelay.Text = res.Status.ToString();
                    }
                    CameraBusy = false;

                }
                else
                {
                    MessageBox.Show("请输入正确的IP");
                }

            }
            catch
            {

            }

            
        }

        //private void cbx_CameraIP_TextChanged(object sender, EventArgs e)
        //{
        //    Regex r = new Regex(@"(\d{1,3}\.){3}\d{1,3}");
        //    if (r.IsMatch(cbx_CameraIP.Text))
        //    {
        //        //Save2Xml("CameraIP", cbx_CameraIP.Text);
        //        MessageBox.Show("error");
        //    }


        //}

        private void Save2Xml(string attrname, string value)
        {
            OnIPChange?.Invoke(this, new IPEventArgs()
            {
                attrname = attrname,
                value = value
            }) ;
        }

        public event EventHandler Initing;
        public event EventHandler<IPEventArgs> OnIPChange;




    }

        public class IPEventArgs:EventArgs
        {
            public string attrname;
            public string value;
        }



    
}
