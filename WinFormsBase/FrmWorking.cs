using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Linq;
using WinFormsBase.deviceConnect;
using CCWin;
using HZH_Controls.Controls;

namespace WinFormsBase
{

    /// <summary>
    /// 此窗体为工作主界面
    /// </summary>
    public partial class FrmWorking : Form
    {
        //标志位
        public bool ListenFlag = false;
        //服务器端监听Socket
        public Socket serverSocket = null;
        //客户端连接的集合
        Dictionary<string, Socket> clientSocketDic = new Dictionary<string, Socket>();


        public FrmWorking()
        {
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | //不擦除背景
            //    ControlStyles.OptimizedDoubleBuffer | //双缓冲
            //    ControlStyles.UserPaint,    //使用自定义重绘事件
            //    true);
            //this.UpdateStyles();

            //页面组件初始化
            InitializeComponent();
            //系统初始化
            SystemInitConfig();
        }

        //创建调试界面


        //创建服务器界面



        private byte[] receiveBuffer = new byte[2048];

        private static int X_real = 719;
        private static int Y_real = 531;
        

        //Mark点寻找状态指示
        public enum SearchState
        {
            NORESULT,  //未寻找到目标

        }

        private bool _running = false;
        public bool Running
        {
            get
            {
                return _running;
            }
            set
            {

            }
        }






        private void SystemInitConfig()
        {
            string xmlPath = @"config.xml";
            //初始化一个xml实例
            var xmldoc = new XmlDocument();
            //加载路径，导入指定xml文件
            xmldoc.Load(xmlPath);
            //指定一个节点
            XmlElement xmlRoot = xmldoc.DocumentElement;


            //从XML文件中获取相机的IP和端口号
            ConnectConfig.CameraIP = xmlRoot["CameraIP"].InnerText;
            ConnectConfig.CameraPort = int.Parse(xmlRoot["CameraPort"].InnerText);


        }




        private void FrmWorking_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void pan_Logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pan_ServerFrm_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// 监听按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Listen_Click(object sender, EventArgs e)
        {
            try
            {
                //切换标志位和按钮文字
                if(txt_ClinetIP.Text == null || txt_ClinetPort == null)
                {
                    MessageBox.Show("请输入IP或端口号");
                    return;
                }
                ListenFlag = !ListenFlag;
                if(ListenFlag)
                    btn_Listen.Text = "取消监听";
                else
                    btn_Listen.Text = "监听";
                //创建一个负责监听的Socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //创建IP地址和端口号对象
                IPAddress ClinetIP = IPAddress.Parse(txt_ClinetIP.Text);
                IPEndPoint endPoint = new IPEndPoint(ClinetIP, int.Parse(txt_ClinetPort.Text));
                //让负责监听的Socket绑定IP地址和端口号
                serverSocket.Bind(endPoint);
                ShowStateMsg("监听成功");
                //设置监听队列
                serverSocket.Listen(5);
                //新开启线程，负责监听的Socket来接收客户端的连接，创建跟客户端通信的Socket
                Thread ListenThread = new Thread(ListenClinet);
                ListenThread.IsBackground = true;
                ListenThread.Start(serverSocket);

            }
            catch
            {

            }

        }

        public void ShowStateMsg(string str)
        {
            txt_StateShow.AppendText(str + "\r\n");
        }

        public void ShowReceiveMsg(string str)
        {
            txt_Receive.AppendText(str + "\r\n");
        }

        /// <summary>
        /// 监听来自客户端的连接
        /// </summary>
        /// <param name="o"></param>
        private void ListenClinet(object o)
        {
            Socket serverSocket = o as Socket;
            try
            {
                //等待客户端的连接，并且创建一个负责通信的Socket
                while (ListenFlag)
                {
                    //负责跟客户端通信的Socket
                    Socket LinkSocket = serverSocket.Accept();
                    //将远程连接的客户端的IP地址和端口号存入集合中
                    clientSocketDic.Add(LinkSocket.RemoteEndPoint.ToString(), LinkSocket);
                    //将远程连接的客户端的IP地址和端口号存入下拉框中
                    cbx_ClinetChoose.Items.Add(LinkSocket.RemoteEndPoint.ToString());
                    ShowStateMsg(LinkSocket.RemoteEndPoint.ToString() + ":" + "连接成功");
                    //客户端连接成功后，服务器应该接受客户端发来的消息
                    //开启一个新线程用于接受客户端的消息
                    Thread ReceiveThread = new Thread(ReceiveMsg);
                    ReceiveThread.IsBackground = true;
                    ReceiveThread.Start(LinkSocket);
                        
                }
            
            }
            catch
            {

            }

        }


        public void ReceiveMsg(object o)
        {
            try
            {
                Socket LinkSocket = o as Socket;
                while(ListenFlag)
                {
                    byte[] buffer = new byte[1024];
                    //实际接受到的有效字节数
                    int num = LinkSocket.Receive(buffer);
                    if(num == 0)
                    {
                        break;
                    }
                    //处理数据



                    //////
                    string str = System.Text.Encoding.UTF8.GetString(buffer, 0, num);
                    ShowReceiveMsg(LinkSocket.RemoteEndPoint + ":" + str);
                }
            }
            catch
            {

            }
        }

    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_MainFrm_Click(object sender, EventArgs e)
        {
            this.pan_ServerFrm.Visible = false;
        }

        private void btn_ServerFrm_Click(object sender, EventArgs e)
        {
            this.pan_ServerFrm.Visible = true;
        }
    }
}
