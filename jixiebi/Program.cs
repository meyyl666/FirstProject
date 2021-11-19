using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestHSCAPI
{
    class Program
    {
        static bool connectIPC(Hsc3.Comm.CommApi cmApi, string strIP, ushort uPort)
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
                Console.WriteLine("连接成功");
                return true;
            }
            else
            {
                Console.WriteLine("连接失败");
                return false;
            }
        }

        static bool disconnectIPC(Hsc3.Comm.CommApi cmApi)
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

        static void Main(string[] args)
        {
            //构造通信客户端代理。
            Hsc3.Comm.CommApi cmApi = new Hsc3.Comm.CommApi();
            //构造变量操作代理
            Hsc3.Proxy.ProxyVar proVar = new Hsc3.Proxy.ProxyVar(cmApi);
            //构造运动功能代理
            Hsc3.Proxy.ProxyMotion proMot = new Hsc3.Proxy.ProxyMotion(cmApi);

            //连接，控制器固定IP:"10.10.56.214",固定端口号: 23234
            //ulong look =  cmApi.connect("192.168.100.181", 23234);
            if (connectIPC(cmApi, "192.168.250.65", 23234))
            {
                proMot.setGpEn(0, true);
                proMot.setOpMode(Hsc3.Comm.OpMode.OP_T1);
                proMot.setJogVord(20);
                proMot.setInchLen(10);
                
               //for(int i = 0;i<200;i++)
               //{
                proMot.startJog(0, 0, Hsc3.Comm.DirectType.NEGATIVE);
                //}
                //proMot.setEstop(true);
                ////R寄存器写入与读取
                //double dRegisterValueSet = 100;
                //double dRegisterValueGet = 0;
                //int index = 0;
                //ulong ret_set = proVar.setR(index, dRegisterValueSet);
                //ulong ret_get = proVar.getR(index, ref dRegisterValueGet);
                //if (ret_get == 0 && ret_set == 0 && dRegisterValueGet == dRegisterValueSet)
                //{
                //    Console.WriteLine("R[" + index + "] = " + dRegisterValueGet);
                //}
                ////JR寄存器写入与读取
                //List<double> jPosSet = new List<double> { 0.0, -90.0, 180.0, 0.0, 90.0, 0.0 };
                //List<double> jPosGet = new List<double>();
                //ret_set = proVar.setJR(0, index, ref jPosSet);
                //ret_get = proVar.getJR(0, index, ref jPosGet);
                //if (ret_get == 0 && ret_set == 0)
                //{
                //    string jrdata = "JR[" + index + "] = {";
                //    foreach (var item in jPosGet)
                //    {
                //        jrdata += item.ToString() + ",";
                //    }
                //    Console.WriteLine(jrdata + "}");
                //}
                //LR寄存器的读取同JR,接口：proxyVar::getLR()和proxyVar::setLR()
                //UT寄存器的读取和设置, 注意：UT和UF只需要6个数据，如果多给了，6个数据后面的数据是无效的。返回也是6个数据
                //List<double> posSet = new List<double> { 0.0, -90.0, 180.0, 0.0, 90.0, 0.0 };
                //List<double> posGet = new List<double>();
                //ret_set = proMot.setTool(0, index, posSet);
                //ret_get = proMot.getTool(0, index, ref posGet);
                //if (ret_get == 0 && ret_set == 0)
                //{
                //    string tooldata = "UT[" + index + "] = {";
                //    foreach (var item in jPosGet)
                //    {
                //        tooldata += item.ToString() + ",";
                //    }
                //    Console.WriteLine(tooldata + "}");
                //}
                //UF寄存器的读取同UT,接口：proxyMotion::setWorkpiece()和proxyVar::getWorkpiece()

                //JR/LR/UT/UF寄存器的保存接口是ProxyVar::saveGp()
                //R寄存器的保存接口是ProxyVar::saveCommon()
                //List<double> jntpos = new List<double>();
                //ulong ret = proMot.getJntData(0, ref jntpos);	// gpId都填0
                //if (ret == 0)
                //{
                //    double J1 = jntpos[0];
                //    double J2 = jntpos[1];
                //    double J3 = jntpos[2];
                //    double J4 = jntpos[3];
                //    double J5 = jntpos[4];
                //    double J6 = jntpos[5];
                //}
                //else
                //    Console.WriteLine("Failed to get Joint Data. ErrorCode=" + ret);
            }
            Console.Write("Press any key to continue . . . ");
            //Console.ReadKey(true);
            //完成所有操作后，务必断开与控制器的连接
            disconnectIPC(cmApi);
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
