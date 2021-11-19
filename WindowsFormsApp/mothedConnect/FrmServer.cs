using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsApp.mothedConnect
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
        }

        //服务器端socket
        Socket serverSocket = null;
        //客户端连接的集合
        Dictionary<EndPoint, Socket> clientSocketDic = new Dictionary<EndPoint, Socket>();




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个负责监听的Socket
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //创建IP地址和端口号对象
            IPAddress ip = IPAddress.Any;
            //IPAddress ip = IPAddress.Parse(textBox1.Text);
            IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(textBox2.Text));
            //让负责监听的Socket绑定IP地址和端口号
            serverSocket.Bind(endPoint);

            ShowMsg("监听成功");
            //设置监听队列（某一个时间点内可以连入该服务端的最大客户端数量）
            serverSocket.Listen(5);
            //新开启线程，负责监听的Socket来接受客户端的连接 创建跟客户端通信的Socket
            Thread ListenThread = new Thread(ListenClient);
            ListenThread.IsBackground = true;
            ListenThread.Start(serverSocket);

        }

        void ShowMsg(string str)
        {
            textBox4.AppendText(str + "\r\n");
        }

        /// <summary>
        /// 监听来自客户端的连接
        /// </summary>
        private void ListenClient(object o)
        {
            Socket serverSocket = o as Socket;
            //等待客户端的连接，并且创建一个负责通信的Socket
            while(true)
            {
                try
                {
                    //负责跟客户端通信的Socket
                    Socket socketSend = serverSocket.Accept();
                    //将远程连接的客户端的IP地址和Socket存入集合中
                    dicSocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                    //将远程连接的客户端的IP地址和端口号存入下拉框中
                    comboBox1.Items.Add(socketSend.RemoteEndPoint.ToString());
                    ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + "连接成功");
                    //客户端连接成功后，服务器应该接受客户端发来的消息
                    //开启一个新线程用于接受客户端的消息
                    Thread th = new Thread(Receive);
                    th.IsBackground = true;
                    th.Start(socketSend);

                }
                catch
                {

                }

            }

        }

        //将远程连接的客户端的IP地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();


        /// <summary>
        /// 服务器端不停地接受客户端发来的信息
        /// </summary>
        /// <param name="o"></param>
        void Receive(object o)
        {
            try
            {
                Socket socketSend = o as Socket;
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 2];
                    //实际接受到的有效字节数
                    int num = socketSend.Receive(buffer);
                    if (num == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, num);
                    ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                }
            }
            catch
            {

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmServer_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

        }


        /// <summary>
        /// 服务器端发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox5.Text;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            //获得用户在下拉框中选中的IP地址
            string ip = comboBox1.SelectedIndex.ToString();
            dicSocket[ip].Send(buffer);
        }
    }

}
