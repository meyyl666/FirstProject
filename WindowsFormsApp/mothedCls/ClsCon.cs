using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp.mothedCls
{
    /// <summary>
    /// ClsCon类主要用于创建数据库连接及关闭打开的数据库连接
    /// 需要引入System.Data和System.Data.SqlClient两个命名空间
    /// </summary>
    class ClsCon
    {
        public string sever_name = "DESKTOP-9OCF6G3";
        public string db_name = "db_Mechine";

        public SqlConnection _mySql;
        
        /// <summary>
        /// 数据库连接
        /// </summary>
        /// 

        public void ConDatabase()
        {
            //第一种方法
                _mySql = new SqlConnection("server=PC-201805101742;pwd=qq64022020;uid=sa;database=db_Mechine");

                _mySql.Open();    //打开数据库 

        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        /// <returns></returns>
        public bool closeCon()
        {
            try
            {
                //若数据连接处于打开状态
                if (_mySql.State == ConnectionState.Open)
                {
                    _mySql.Close();//关闭连接
                }
                return true;
            }
            catch
            {
                return false;//若产生异常，返回false
            }
        }
    }
}
