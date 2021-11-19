using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using WinFormsBase.components;

namespace WinFormsBase.deviceConnect
{
    public class ConnectConfig
    {
        static ConnectConfig()
        {

        }

        //基于EventHandler委托定义事件
        public static event EventHandler Connecting;   
        public static event EventHandler DisConnecting;
        //建立状态自动更新列表
        public static List<AutoUpdatable> undateList = new List<AutoUpdatable>();
        //创建相机Socket
        public static Socket CameraSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 

        //创建相机IP和端口号
        public static string CameraIP
        {
            get;
            set;
        }="192.168.250.60";
        public static int CameraPort = 8999;


        public static bool Connected;

        public static void Connect()
        {

        }

    }




}
