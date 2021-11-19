using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp.mothedCls
{
    /// <summary>
    /// 该类封装了对tb_Point数据的插入，修改和删除的操作的方法
    /// </summary>
    class claPointMethod
    {
        ClsCon con = new ClsCon();
        public string insert_table(clsPoint cf)
        {
            try
            {
                //创建数据库连接
                con.ConDatabase();
                //创建命令对象
                string Con_insert = "INSERT INTO tb_Point(X,Y,Z) VALUEES(@X,@Y,@Z)";
                SqlCommand cmd = new SqlCommand(Con_insert, con._mySql);
                //表示命令对象将执行存储过程
                cmd.CommandType = CommandType.StoredProcedure;
                //打开数据连接
                cmd.Connection.Open();
                SqlParameter[] prams =
                {
                    new SqlParameter("@X",SqlDbType.Float),//创建X参数实例
                    new SqlParameter("@Y",SqlDbType.Float),//创建Y参数实例
                    new SqlParameter("@Z",SqlDbType.Float),//创建Z参数实例
                    new SqlParameter("@proc_info", SqlDbType.VarChar, 50, ParameterDirection.Output,true, 0, 0, string.Empty,DataRowVersion.Default, null)
                };
                prams[0].Value = cf.X;
                prams[1].Value = cf.Y;
                prams[2].Value = cf.Z;
                //添加参数
                foreach(SqlParameter parameter in prams)
                {
                    cmd.Parameters.Add(parameter);
                    
                }
                cmd.ExecuteNonQuery();
                string strResult = cmd.Parameters["@proc_info"].Value.ToString();
                con.closeCon();
                return strResult;
            }
            catch (Exception ey)
            {
                con.closeCon();
                return ey.Message.ToString();
            }
            
        }

    }
}
