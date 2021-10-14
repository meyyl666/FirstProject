using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsBase.mothedCls
{
    /// <summary>
    /// clsPoint实体类将tb_Point数据表的字段通过GET,SET访问器封装起来
    /// 
    /// </summary>
    class clsPoint
    {
        private float x_data = 0;
        private float y_data = 0;
        private float z_data = 0;

        public float X
        {
            get { return x_data; }
            set { x_data = value; }
        }
        public float Y
        {
            get { return y_data; }
            set { y_data = value; }
        }
        public float Z
        {
            get { return z_data; }
            set { y_data = value; }
        }


    }
}
