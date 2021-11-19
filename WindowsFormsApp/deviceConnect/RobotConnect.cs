using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp.deviceConnect
{
    static class RobotConnect
    {
        //连接
        public static bool connectIPC(Hsc3.Comm.CommApi cmApi, string strIP, ushort uPort)
        {
            ulong conn;
            conn = cmApi.connect(strIP, uPort);
            cmApi.setUseHeartBeat(true);//开启心跳
            string backStr = "";
            conn = cmApi.execCmd("mot.getRobTypeName(0)", ref backStr, 0);
            if (conn != 0)
            {
                Console.WriteLine("CommApi::connect() : ret = " + conn);
            }
            if (cmApi.isConnected())
            {
                Console.WriteLine("机械臂控制柜连接成功");
                return true;
            }
            else
            {
                Console.WriteLine("机械臂控制柜连接失败");
                return false;
            }
        }
        //断开连接
        public static bool disconnectIPC(Hsc3.Comm.CommApi cmApi)
        {
            ulong ret = cmApi.disconnect();
            Thread.Sleep(500);
            if (cmApi.isConnected())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //自动运行程序
        public static void AutoLoadProgram(string path,string filename)
        {
            string str = "";
            //使能机械臂
            ConnectConfig.proMot.setGpEn(0, true);
            //将机器人设置为自动运行模式
            ConnectConfig.proMot.setOpMode(Hsc3.Comm.OpMode.OP_AUT);
            //设置自动运行模式
            ConnectConfig.proMot.setAutoMode(Hsc3.Comm.AutoMode.AUTO_MODE_CONTINUE);
            //
            //设置自动运行倍率
            ConnectConfig.proMot.setVord(75);
            //加载程序
            ConnectConfig.proxyVm.load(path, filename);
            
            
            //运行程序
            ConnectConfig.proxyVm.start(filename);
            Thread.Sleep(200);
        }

        //切换操作模式（手动，外部，自动运行）


        //笛卡尔坐标运行


        //限位设置


    }



}
