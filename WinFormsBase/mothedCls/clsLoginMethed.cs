using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WinFormsBase.mothedCls
{
    class clsLoginMethed
    {
        ClsCon con = new ClsCon();

        public string select_table(clsLogin cf)
        {
            try
            {
                con.ConDatabase();
                
                SqlCommand cmd = new SqlCommand("SELECT", con._mySql);
                cmd.Connection.Open();
                SqlParameter[] prams =
                {
                    new SqlParameter("@login_name",SqlDbType.VarChar,50),
                    new SqlParameter("@login_pwd",SqlDbType.VarChar,50),
                    new SqlParameter("@ReturnInfo",SqlDbType.VarChar,50, ParameterDirection.Output,true, 0, 0, string.Empty,DataRowVersion.Default, null)
                };
                prams[0].Value = cf.LName;
                prams[1].Value = cf.LPwd;

                //添加参数
                foreach(SqlParameter parameter in prams)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
                string strResult = cmd.Parameters["@ReturnInfo"].Value.ToString();
                con.closeCon();
                return strResult;
            }
            catch(Exception ey)
            {
                con.closeCon();
                return ey.Message.ToString();
            }
        }


        public object Result_First;   //储存查询结果中第一条记录第一个字段的值
        public int Result_Num;     //储存查询影响的记录数量
        public SqlDataReader Result_Set;  //储存查询结果记录集

    }
}
