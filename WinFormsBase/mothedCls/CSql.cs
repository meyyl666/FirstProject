using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;




namespace WinFormsBase.mothedCls
{
    /// <summary>
    /// 此类用于给出SQL Server 数据库连接串
    /// </summary>
    class CSql
    {
        
        //给出本地SQL Server 数据库连接串  （使用Windows身份验证）
        public static string GetLocalCnnStr(string sever,string dbname)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.IntegratedSecurity = true;
            sb.DataSource = sever;
            sb.InitialCatalog = dbname;
            return sb.ConnectionString;

        }
        public static string GetLocalCnnStr(string dbname)
        {
            return GetLocalCnnStr(".", dbname);
        }

        public static string GetRemoteCnnStr(string server,string userid,string password,string dbname)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.IntegratedSecurity = false;
            sb.DataSource = server;
            sb.UserID = userid;
            sb.InitialCatalog = dbname;
            return sb.ConnectionString;


        }

    }
}
