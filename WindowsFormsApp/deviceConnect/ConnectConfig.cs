using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using WindowsFormsApp.components;

namespace WindowsFormsApp.deviceConnect
{
    public class ConnectConfig
    {
        static ConnectConfig()
        {


        }

        //创建时间对象，用于超时判断
        public static System.Timers.Timer timer;

        //基于EventHandler委托定义相机连接与断开事件
        public static event EventHandler Connecting;   //连接事件

        public static event EventHandler DisConnecting;//断开连接事件

        //建立状态自动更新列表
        public static List<AutoUpdatable> updateList = new List<AutoUpdatable>();
        //创建相机Socket
        public static Socket CameraSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        //创建机械臂Socket
        public static Socket RobotSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //构造机械臂通信客户端代理。
        public static Hsc3.Comm.CommApi CmJixiebi = new Hsc3.Comm.CommApi();
        //构造机械臂变量操作代理
        public static Hsc3.Proxy.ProxyVar proVar = new Hsc3.Proxy.ProxyVar(CmJixiebi);
        //构造机械臂运动功能代理
        public static Hsc3.Proxy.ProxyMotion proMot = new Hsc3.Proxy.ProxyMotion(CmJixiebi);

        public static Hsc3.Comm.ProxyVm proxyVm = new Hsc3.Comm.ProxyVm(CmJixiebi);

        //创建PLC通讯接口


        //创建相机IP和端口号
        public static string CameraIP
        {
            get;
            set;
        }="192.168.250.60";
        public static int CameraPort = 8999;
        //创建PLC的IP和端口号
        public static string PLCIP
        {
            get;
            set;
        } = "192.168.250.63";
        public static int PLCPort = 9000;
        //创建间接控制机械臂的IP和端口号
        public static string RobotIP
        {
            set;
            get;
        } = "192.168.250.65";
        public static int RobotPort = 9000;
        //创建直接机械臂控制柜端口号
        public static ushort RobotPort1 = 23234;


        //用于判断设备连接状态（默认为未连接）
        public static bool CameraConnected = false;
        public static bool PLCConnected = false;
        public static bool RobotConnected = false;


        /// <summary>
        /// 建立与设备的通讯连接
        /// </summary>
        public static void Connect()
        {
            //建立通讯
            try
            {


                //有一个没连接上就执行再次连接事件
                if (!CameraConnected||!RobotConnected)
                {
                    Connecting?.Invoke(null, new EventArgs());
                }
                //触发连接事件
                

                //将相机状态变为已连接
                CameraConnected = true;
               // ConnectConfig.StartUpdate();
            }
            catch(Exception ex)
            {
                CameraConnected = false;
            }


           //建立与PLC的连接 

           //建立与机械臂的连接
        }

        public static void DisConnect()
        {

            //如果相机状态为未连接，则返回
            if (!CameraConnected&&!RobotConnected) return;
            //Stop();
            //触发相机和机械臂Socket断开连接事件
            DisConnecting?.Invoke(null, new EventArgs());


        }

        public static void Stop()
        {
            if (timer != null)
                timer.Stop();
        }

        public static void StartUpdate()
        {
            if(timer == null)
            {
                //实例化timer，设置间隔时间为200ms
                timer = new System.Timers.Timer(200);
                //到达时间后执行的事件
                timer.Elapsed += (sender, e) =>
                {
                    foreach(var u in updateList)
                    {
                        u.ReFreshState();
                    }

                };

            }
        }

        

    }




}
