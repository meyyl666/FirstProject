using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp.components
{

    /// <summary>
    /// 该接口用于更新各设备的状态
    /// </summary>
    public interface AutoUpdatable
    {
        void ReFreshState();
    }
}
