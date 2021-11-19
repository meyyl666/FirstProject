using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp.deviceConnect;

namespace WindowsFormsApp.utils.Saga
{
    class Channel<T>
    {
        public Saga<T> saga;

        public void DealCarmeraData(T data)
        {
           // Console.WriteLine(saga.listQue.Count);
            for(int i = saga.listQue.Count-1;i>=0;i--)
            {
               // Console.WriteLine("我在处理数据");
                var effect = saga.listQue[i];
                if (saga.IsNeed(effect, data))
                {
                    saga.listQue.Remove(effect);
                    Console.WriteLine("success match" + saga.listQue.Count);
                    ConnectConfig.proxyVm.pause("T1102.PRG");
                    //ConnectConfig.proMot.setEstop(true);
                    effect.cb(data); //线程结束
                    break;
                }
                //else
                //    Console.WriteLine("匹配失败");
            }
        }

        public void DealRobotData(T data)
        {


        }


    }
}
