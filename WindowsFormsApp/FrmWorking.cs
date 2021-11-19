using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Linq;
using WindowsFormsApp.deviceConnect;
using CCWin;
using HZH_Controls.Controls;
using WindowsFormsApp.deviceConnect;
using WindowsFormsApp;
using CCWin.SkinControl;
using WindowsFormsApp.utils.Saga;
using System.Text.RegularExpressions;

namespace WinFormsBase
{

    /// <summary>
    /// 此窗体为工作主界面
    /// </summary>
    public partial class FrmWorking : CCWin.Skin_Color
    {

        /// <summary>
        /// 主界面构造函数
        /// </summary>
        public FrmWorking() 
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | //不擦除背景
                ControlStyles.OptimizedDoubleBuffer | //双缓冲
                ControlStyles.UserPaint,    //使用自定义重绘事件
                true);
            this.UpdateStyles();

            //页面组件初始化
            InitializeComponent();
            //系统信息初始化（IP）读取文件中的信息到上位机中
            SystemInitConfig();
        }

        //创建调试界面
        private FrmDebug debugForm = new FrmDebug();

        #region  自定义代码
        //创建接收相机数据的数组
        private byte[] camReceiveBuffer = new byte[2048];
        //创建接收发送机械臂数据的数组
        private byte[] robReceiveBuffer = new byte[2048];
        private byte[] sendBuffer = System.Text.Encoding.UTF8.GetBytes("switch nice");

        //定义异步Socket,用于与相机通讯
        private static SocketAsyncEventArgs camReceiveArgs;
        //定义异步Socket,用于与机械臂通讯
        private static SocketAsyncEventArgs robReceiveArgs;

        //标准模板位置坐标
        private static int X_real = 719;
        private static int Y_real = 531;
        //微调轴的角度
        private static int J1angle = 0;
        private static int J4angle = 0;

        //要取的物料个数
        public int PanNumber = 0;

        //定义寻找Mark点的状态
        public enum SearchState   //待修改
        {
            INIT,//初始化
            NORESULT,//查找无结果
            FIX_OFFSET_Q,//切向偏移
            FIX_OFFSET_J,//径向偏移
            FIX_ROTATION, //旋转偏移
            DEAL_PLATE  //处理盘片
        }

        //运行状态标志位定义
        private bool _running = false;

        //初始化标志位
        private bool _initflag = false;

        private bool _sendflag = false;

        

        public bool SendFlag
        {
            get
            {
                return _sendflag;
            }
            set
            {
                _sendflag = value;
                //触发事件
                this.Invoke(new Action(() =>
                {
                    if (value)
                    { 
                        ConnectConfig.CameraSocket.Send(Encoding.Default.GetBytes("switch Nice"));
                    }
                }));
            }
        }
       

        //上位机做服务器的时候用
       // private Socket socketServer;  //目前还没用到

        //设置或获取系统运行状态
        public bool Running
        {
            get
            {
                return _running;
            }
            set
            {
                _running = value;
                //触发事件
                this.Invoke(new Action(() => 
                {
                    //btn_Init.FillColor = value ? Color.Red : Color.Lime; 
                    //btn_Init.BtnText = value ? "断开连接" : "初始化";
                    if(!value) //系统停止运行
                    {
                        btn_Start.Checked = false;  //按钮设置为未选中状态
                        promise?.TrySetCanceled();  //取消线程 
                    }
                    else
                    {
                        btn_Start.Checked = true;
                        searchState = SearchState.NORESULT;//状态初始化
                    }

                }));
            }
            
        }

        //获取初始化状态  true 为初始化完成，false为初始化失败

        public bool Initflag
        {
            get
            {
                return _initflag;
            }
            set
            {
                _initflag = value;
                this.Invoke(new Action(() =>
                {
                    btn_Init.FillColor = value ? Color.Lime : Color.Red; //
                    btn_Init.BtnText = value ? "断开连接" : "初始化";
                    if (!value) //初始化失败
                    {
                        btn_Start.Checked = false;  //按钮设置为未选中状态
                       // promise?.TrySetCanceled();  //取消线程 
                    }
                    searchState = SearchState.INIT;//状态初始化
                }));
            }
        }

        //创建寻找Mark状态的对象，并初始化为未找到目标状态
        private SearchState _searchState = SearchState.INIT;
        public SearchState searchState
        {
            set
            {
                _searchState = value;
                Invoke(new Action(() =>
                {
                    ste_WorkStep.StepIndex = (int)value;
                    string str = "进度：";
                    switch(value)
                    {
                        case SearchState.INIT:
                            lab_Step.Text = str + "初始化";
                            ste_WorkStep.StepIndex = 1;
                            break;
                        case SearchState.NORESULT:
                            lab_Step.Text = str + "寻找Mark点";
                            ste_WorkStep.StepIndex = 2;
                            bar_Step.Value = 20;
                            break;
                        case SearchState.FIX_OFFSET_Q:
                            lab_Step.Text = str + "校准切向偏移";
                            ste_WorkStep.StepIndex = 3;
                            bar_Step.Value = 40;
                            break;
                        case SearchState.FIX_OFFSET_J:
                            lab_Step.Text = str + "校准径向偏移";
                            ste_WorkStep.StepIndex = 4;
                            bar_Step.Value = 60;
                            break;
                        case SearchState.FIX_ROTATION:
                            lab_Step.Text = str + "校准旋转偏移";
                            ste_WorkStep.StepIndex = 5;
                            bar_Step.Value = 80;
                            break;
                        case SearchState.DEAL_PLATE:
                            lab_Step.Text = str + "取放盘片";
                            ste_WorkStep.StepIndex = 6;
                            bar_Step.Value = 100;
                            break;
                        default:
                            break;
                    }

                }));

            }
            get
            {
                return _searchState;
            }
        }

        Dictionary<string, Action<string>> MiddleWares = new Dictionary<string, Action<string>>();

        #endregion


        private void FrmWorking_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CCWin.MessageBoxEx.Show("?", "确定退出？", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btn_Debug_BtnClick(object sender, EventArgs e)
        {
            if(debugForm == null)
            {
                debugForm = new FrmDebug();
            }
            debugForm.Show();
            this.Show();
        }

        private async void btn_Init_BtnClick(object sender, EventArgs e)
        {

            if(!Initflag)//判断初始化标志位  开始是false
            {
                //通讯连接
                ConnectConfig.Connect();
                Thread.Sleep(1000); 
                //设备复位
                var t1 = new Task(InitAction);
                t1.Start();
                var t = await Task.WhenAny(new Task[] {
                    t1,
                    Task.Delay(120000)
                });
                if(t != t1)
                {
                    MessageBox.Show("设备未能复位完成");
                    t1.Dispose();
                }

                Initflag = true;  //初始化完成
                ConnectConfig.proxyVm.pause("T1102.PRG");
                Thread.Sleep(100);
                ConnectConfig.proxyVm.unload("T1102.PRG");
                

            }
            //系统已经初始化
            else
            {
                //断开通讯连接
                Initflag = false;
                ConnectConfig.DisConnect();
                
            }
        }


        /// <summary>
        /// 初始化设备的初始位置（未完成）
        /// </summary>
        /// 
        public void InitAction()
        {

        }

        /// <summary>
        /// 初始化设备IP信息
        /// </summary>
        private void SystemInitConfig()
        {
            string xmlPath = @"config.xml";
            //初始化一个xml实例
            var xmldoc = new XmlDocument();
            //创建一个行描述信息，并且添加到doc文档中
            //XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("V1.0", "utf-8",null);

            //加载路径，导入指定xml文件
            xmldoc.Load(xmlPath);
            //指定一个节点
            XmlElement xmlRoot = xmldoc.DocumentElement;


            //从XML文件中获取设备的IP和端口号
            ConnectConfig.CameraIP = xmlRoot["CameraIP"].InnerText;
            ConnectConfig.CameraPort = int.Parse(xmlRoot["CameraPort"].InnerText);
            ConnectConfig.PLCIP = xmlRoot["PLCIP"].InnerText;
            ConnectConfig.PLCPort = int.Parse(xmlRoot["PLCPort"].InnerText);
            ConnectConfig.RobotIP = xmlRoot["RobotIP"].InnerText;
            ConnectConfig.RobotPort = int.Parse(xmlRoot["RobotPort"].InnerText);
        }

        /// <summary>
        /// 初始化下位机状态(未完成)
        /// </summary>
        private void InitUIStatus()
        {

        }


        private void FrmWorking_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //绑定事件
            ConnectConfig.Connecting += ConnectConfig_Connecting;
            ConnectConfig.DisConnecting += ConnectConfig_DisConnecting;

            //初始化Saga，用于异步控制
            InitSaga();

        }

        private void ConnectConfig_Connecting(object sender, EventArgs e)
        { 
            try
            {
                //选择上位机模式
                //InitializeSocketServer();  //上位机服务器模式   可能用于机械臂
                InitSocketSlave();  //上位机客户端模式  连接机械臂和相机

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                ConnectConfig.DisConnect();
            }

        }


        private void ConnectConfig_DisConnecting(object sender,EventArgs e)
        {

            if(ConnectConfig.CameraSocket.Connected||ConnectConfig.RobotConnected)
            {
                try
                {
                    //断开相机Socket连接
                    ConnectConfig.CameraSocket.Disconnect(true);
                    CameraStatus(false);
                    //断开机械臂Socket连接
                    ConnectConfig.RobotSocket.Disconnect(true);
                    RobotConnect.disconnectIPC(ConnectConfig.CmJixiebi);
                    RobotStatus(false);
                    //断开PLC连接


                    Initflag = false;//将系统初始化标志位设置成未初始化
                    //状态改变
                    //CameraStatus(false);
                    //RobotStatus(false);
                    ste_WorkStep.StepIndex = 0;
                }
                catch(Exception ex)
                {
                    //写日志
                }
            }

        }


        /// <summary>
        /// 初始化Socker客户端模式
        /// </summary>
        private void InitSocketSlave()
        {
            try
            {
                //与相机Socket建立连接
                if(!ConnectConfig.CameraConnected)
                {
                    var point = new IPEndPoint(IPAddress.Parse(ConnectConfig.CameraIP), ConnectConfig.CameraPort);

                    //建立相机异步连接套接字
                    ConnectConfig.CameraSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    camReceiveArgs = new SocketAsyncEventArgs();
                    camReceiveArgs.RemoteEndPoint = point;
                    camReceiveArgs.Completed += ReceiveArgs_Dva;//回调方法  连接完成后接收数据
                    camReceiveArgs.SetBuffer(camReceiveBuffer, 0, camReceiveBuffer.Length);//设置接收数据的buffer
                    ConnectConfig.CameraSocket.ConnectAsync(camReceiveArgs);
                }

                //与机械臂Socket建立连接
                if (!ConnectConfig.RobotConnected)
                {
                    var point1 = new IPEndPoint(IPAddress.Parse(ConnectConfig.RobotIP), ConnectConfig.RobotPort);
                    ConnectConfig.RobotSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    robReceiveArgs = new SocketAsyncEventArgs();
                    robReceiveArgs.RemoteEndPoint = point1;
                    robReceiveArgs.Completed += ReceiveArgs_Dva;//回调方法  异步操作完成后会执行的函数
                    robReceiveArgs.SetBuffer(robReceiveBuffer, 0, robReceiveBuffer.Length);//设置接收数据的buffer
                    ConnectConfig.RobotSocket.ConnectAsync(robReceiveArgs);

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);

            }

        }


        /// <summary>
        /// 此函数用于上位机做客户端时接收和发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceiveArgs_Dva(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                if(e == camReceiveArgs)
                {
                    MessageBox.Show("相机连接失败");
                    
                }
                if(e == robReceiveArgs)
                {
                    MessageBox.Show("机械臂Socket连接失败");
                }
                return;
            }
            switch(e.LastOperation)
            {
                //连接成功，就创建通讯套接字
                case SocketAsyncOperation.Connect:
                    if(sender == ConnectConfig.CameraSocket)
                    {
                        //Socket连接成功后，改变相机状态
                        CameraStatus(true);
                        Console.WriteLine("相机Socket连接成功");
                        //立马发起异步接受请求
                        ConnectConfig.CameraSocket.ReceiveAsync(camReceiveArgs);
                    }
                    else if(sender == ConnectConfig.RobotSocket)
                    {
                        Console.WriteLine("机械臂Socket连接成功");
                        //机械臂Socket连接成功后再去连接控制柜
                        bool flag = RobotConnect.connectIPC(ConnectConfig.CmJixiebi, ConnectConfig.RobotIP, ConnectConfig.RobotPort1);
                        //都连接成功后改变机械臂状态
                        RobotStatus(true && flag);
                        //发起异步接受请求
                        ConnectConfig.RobotSocket.ReceiveAsync(robReceiveArgs);

                    }
                    //Console.WriteLine(e.LastOperation);
                    //Socket client = sender as Socket;
                    //client?.ReceiveAsync(receiveArgs);
                    break;
                //接收状态
                case SocketAsyncOperation.Receive:
                    if(sender == ConnectConfig.CameraSocket)
                    {
                        int echLength = e.BytesTransferred;
                        if (echLength != 0)
                        {
                            string msg = Encoding.Default.GetString(e.Buffer, 0, echLength);
                            foreach (var middleWare in MiddleWares)
                            {
                                middleWare.Value(msg);  //用saga来处理数据
                            }
                            if (Initflag)
                            {
                                ConnectConfig.CameraSocket.ReceiveAsync(e);
                            }

                        }
                        else
                        {
                            //如果相机主动断开连接
                            CameraStatus(false);
                            ConnectConfig.CameraSocket.Close();
                            //断线重连
                            if (Running || Initflag)
                            {
                                InitSocketSlave();
                            }
                        }
                    }
                    //Console.WriteLine(robReceiveArgs.LastOperation);
                    if(sender == ConnectConfig.RobotSocket)
                    {
                        int echLength = e.BytesTransferred;
                        //处理数据
                        if (echLength != 0)
                        {
                            string msg = Encoding.Default.GetString(e.Buffer, 0, echLength);
                            //foreach (var middleWare in MiddleWares)
                            //{
                            //    middleWare.Value(msg);  //用saga来处理数据
                            //}
                            if (Initflag)
                            {
                                ConnectConfig.RobotSocket.ReceiveAsync(e);
                            }

                        }
                        else  //机械臂主动断开连接
                        {
                            RobotStatus(false);
                            ConnectConfig.RobotSocket.Close();
                            if (Running || Initflag)
                            {
                                InitSocketSlave();
                            }

                        }

                    }

                    break;
                default:
                    break;

            }
        }




        #region saga frame

        //声明一个线程对象，用于主程序的线程
        TaskCompletionSource<string> promise;  
        //创建一个Saga对象，控制任务的进行
        Saga<string> saga = new Saga<string>();
        //建立相机有效信息的正则表达式（X;Y;角度）
        Regex msgRegex = new Regex(@"(?<xpos>\d+[.]\d+);(?<ypos>\d+[.]\d+);(?<angle>-?\d+[.]\d+);");

        /// <summary>
        /// 初始化Saga，用于最初的相机坐标信息匹配
        /// </summary>
        private void InitSaga()
        {
            //初始化匹配方式  相机数据只要不是零就匹配成功
            saga.IsNeed += EffectMatch;
            //初始化中间件，目前只做了对应saga的部分
            InitMiddleWare();
        }

        /// <summary>
        /// 过滤相机数据
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool EffectMatch(Effect<string> effect,string str)
        {
            if(effect.effectType == EffectType.TAKE&&msgRegex.IsMatch(str))
            {
                var match = msgRegex.Match(str);
                if (match.Groups["xpos"].Value != "0.000" || match.Groups["ypos"].Value != "0.000" || match.Groups["angle"].Value != "0.000")
                {
                    Console.WriteLine($"{match.Groups["xpos"].Value},,,,{match.Groups["ypos"].Value},,,,{match.Groups["angle"].Value}");
                    return true;
                }
                
            }
            return false;
        }

        private void InitMiddleWare()
        {
            if(MiddleWares.Count > 0)
            {
                return;
            }
            //添加saga中间件
            MiddleWares.Add("saga", SagaMiddleWare);
        }
        private void SagaMiddleWare(string msg)
        {
            saga.channel.DealCarmeraData(msg);
        }




        #endregion

        #region  流程代码

        IEnumerable<Effect<string>> mainProcess()
        {
            while (Running && PanNumber < 5)
            {
                //返回回调效果（寻找Mark点任务）
                
                yield return saga.Call(findMarkProcess);

                yield return saga.Call((resolve, promise) =>
                {
                    SendFlag = true;
                    resolve("switch");
                });

                //SendFlag = true;
                Running = false;
                //Console.WriteLine("下一步");
                //yield return saga.Call(fit);

            }
        }


        // <summary>
        // 寻找Mark点并使得机械臂停下
        // </summary>
        // <returns></returns>
        IEnumerable<Effect<string>> findMarkProcess()
        {
            Console.WriteLine("我在寻找Mark点");
            //运行程序
            RobotConnect.AutoLoadProgram("\"/usr/codesys/hsc3_app/script\"", "\"T1102.PRG\"");
            
            //先创建一个Take效果并返回,用于提取有用坐标信息
            var token = saga.Take("");
            yield return token;

            Console.WriteLine("我要开始解析了");
            //解析
            double Xpoint, Ypoint;
            double angel = ParseCMD(saga.GetRes(token),out Xpoint,out Ypoint);
            Console.WriteLine("X实际坐标为：{0},Y的实际坐标为{1}，偏移角度为{2}",Xpoint,Ypoint,angel);
            
        }
        IEnumerable<Effect<string>> fit()
        {
            var token = saga.Take("");
            yield return token;
        }


        /// <summary>
        /// 提取X，Y,角度值
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="XPoint"></param>
        /// <param name="YPoint"></param>
        /// <returns></returns>
        private double ParseCMD(string str,out double XPoint,out double YPoint)
        {
            var match = msgRegex.Match(str);
            XPoint = double.Parse(match.Groups["xpos"].Value);
            YPoint = double.Parse(match.Groups["ypos"].Value);
            return double.Parse(match.Groups["angle"].Value);

        }


        public void SendToCamera(string msg)
        {

        }



        #endregion


        #region 设备状态显示
        public void CameraStatus(bool status)
        {
            if(status)
            {
                ConnectConfig.CameraConnected = true;
                SetText("在线", lab_CamStatus);
                SetColor(Color.Lime, lab_CamStatus);
            }
            else
            {
                ConnectConfig.CameraConnected = false;
                SetText("离线", lab_CamStatus);
                SetColor(Color.Red, lab_CamStatus);
            }
        }

        public void RobotStatus(bool status)
        {
            if(status)
            {
                ConnectConfig.RobotConnected = true;
                SetText("在线", lab_RobStatus);
                SetColor(Color.Lime,lab_RobStatus);
            }
            else
            {
                ConnectConfig.RobotConnected = false;
                SetText("离线", lab_RobStatus);
                SetColor(Color.Red, lab_RobStatus);
            }
        }

        private void SetText(string str, SkinLabel ctrl)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    ctrl.Text = str;
                }));
            }
            else
            {
                ctrl.Text = str;
            }
        }

        private void SetColor(Color color, SkinLabel ctrl)
        {
            if (InvokeRequired && !this.IsDisposed)
            {
                Invoke(new Action(() =>
                {
                    ctrl.ForeColor = color;
                }));
            }
            else
                ctrl.ForeColor = color;
        }

        private void SetChecked(bool chk,UCSwitch ctrl)
        {
            if(InvokeRequired && !this.IsDisposed)
            {
                Invoke(new Action(() =>
                {
                    ctrl.Checked = chk;
                }));
            }
            else
            {
                ctrl.Checked = chk;
            }
        }


        #endregion

        private void RunTask()
        {
            //若未初始化完成，直接返回不执行
            if (Initflag == false) return;
            //将系统状态变为运行状态
            Running = true;
            //如果线程对象未创建或者线程处于已完成的状态
            if(promise == null || promise.Task.IsCompleted)
            {
                //建立主线线程对象
                promise = new TaskCompletionSource<string>();
                //自动运行任务，运行结束后自动将启动按钮复位
                saga.AutoRun(mainProcess, promise).ContinueWith((task) =>
                {
                    //任务完成后
                    //将启动按钮复位
                    SetChecked(false,btn_Start);
                    //系统运行标志位还原
                    Running = false;
                    
                });
            }
            else
            {

            }
        }

        private void StopTask()
        {
            if (promise != null)
                saga.Cancel(promise);
        }


        private void btn_Start_Click(object sender, EventArgs e)
        {
            //如果初始化未完成或者启动按钮未选中
            if(!Initflag || !btn_Start.Checked)
            {
                btn_Start.Checked = false;
                ste_WorkStep.StepIndex = 1;
                //停止任务
                StopTask();
            }
            else
            {
                //开始运行任务
                RunTask();
            }
        }

        private void btn_Start_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectConfig.proxyVm.unload("\"T1102.PRG\"");
        }
    }
}
