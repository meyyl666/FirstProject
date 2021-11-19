using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace WinFormsBase.mothedConnect
{
    public partial class FrmClinet : Form
    {
        public FrmClinet()
        {
            InitializeComponent();
        }

        Socket clinetSocket = null;
        Thread th;

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint CameraIP = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
            clinetSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            
            try
            {
                clinetSocket.Connect(CameraIP);
                Action action = ReceiveMsg;


                ////创建一个线程去执行这个方法
                //th = new Thread(ReceiveMsg);
                ////标记这个线程准备就绪了，可以随时被执行，具体什么时候被执行，由CPU决定
                ////将线程设置为后台线程
                //th.IsBackground = true;
                //th.Start();

                
                Task.Run(action);//开启线程监听服务器的消息
                if(clinetSocket.Connected)
                {
                    MessageBox.Show("连接成功");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("连接失败");
            }
        }



        private void Clinet_Load(object sender, EventArgs e)
        {
            //取消跨线程的访问检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            byte[] temp = Encoding.ASCII.GetBytes(textBox3.Text);
            clinetSocket.Send(temp);
        }
        /// <summary>
        /// 接收消息
        /// </summary>

        private void ReceiveMsg()
        {
            while(true)
            {
                byte[] buffer = new byte[5 * 1024];

                int length  = clinetSocket.Receive(buffer); //会阻塞线程
                if(length>0)
                {
                    byte[] temp = new byte[length];
                    Array.Copy(buffer, 0, temp, 0, length);
                    listBox1.Invoke(new Action(() => listBox1.Items.Add(Encoding.ASCII.GetString(temp))));
                }
            }
        }

        private void FrmClinet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //当点击关闭窗体的时候，判断新线程是否为null
            if (th != null)
            {
                th.Abort();  //线程被Abort后就不能再打开了
            }
        }

        private void FrmClinet_Load(object sender, EventArgs e)
        {

        }
    }
}
