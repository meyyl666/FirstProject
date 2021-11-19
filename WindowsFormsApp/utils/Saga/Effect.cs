using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.utils.Saga
{
    class Effect<T>
    {
        public int id;
        public EffectType effectType;  //效果类型
        public object param;
        public Func<T, bool> cb;
    }

    public enum EffectType
    {
        TAKE,//提取有效信息
        PUT,
        FORK,
        CALL,//调用
        OVERLOAD
    }
}
