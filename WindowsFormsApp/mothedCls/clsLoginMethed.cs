using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp.mothedCls
{
    class clsLoginMethed
    {
        ClsCon con = new ClsCon();   //创建数据库连接关闭对象

        public string Select_Table(clsLogin cf)     //查询用户表 
        {
            string login_name = cf.LName;
            string login_pwd = cf.LPwd;
            try
            {
                con.ConDatabase();    //创建并打开数据库
                //检验是否有该用户，如果有，则匹配密码
                SqlCommand cmd = con._mySql.CreateCommand();
                cmd.CommandText = @"SELECT user_pwd FROM tb_User WHERE user_name = @d;";
                cmd.Parameters.AddWithValue("@d", login_name);
                object Right_Pwd = cmd.ExecuteScalar();
                con.closeCon();
                if (Right_Pwd == null)
                    return null;
                else
                    return Right_Pwd.ToString();
            }
            catch
            {
                con.closeCon();
                return "error";
            }
        }





        public object Result_First;   //储存查询结果中第一条记录第一个字段的值
        public int Result_Num;     //储存查询影响的记录数量
        public SqlDataReader Result_Set;  //储存查询结果记录集

    }
}
