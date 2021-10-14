using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsBase.mothedCls
{
    class clsLogin
    {
        string login_id = null;
        string employee_ID;
        string login_name;
        string login_pwd;
        string login_power = "0";

        public string LID
        {
            get { return login_id; }
            set { login_id = value; }
        }

        public string LEID
        {
            get { return employee_ID; }
            set { employee_ID = value; }
        }

        public string LName
        {
            get { return login_name; }
            set { login_name = value; }
        }

        public string LPwd
        {
            get { return login_pwd; }
            set { login_pwd = value; }
        }
        public string LPower
        {
            get { return login_power; }
            set { login_power = value; }
        }


    }



}
