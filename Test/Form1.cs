using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //读取
            using (SqlConnection cnn = new SqlConnection("server=DESKTOP-9OCF6G3;pwd=qq64022020;uid=sa;database=db_Mechine"))
            {
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = @"SELECT user_pwd FROM tb_User WHERE user_name = 'admin';";
                object result = cmd.ExecuteScalar();
                if (result == null)
                    txt_show.Text = "没有获取任何数据";
                else
                    txt_show.Text = result.ToString();
            }


            //插入
            using (SqlConnection cnn = new SqlConnection("server=DESKTOP-9OCF6G3;pwd=qq64022020;uid=sa;database=db_Point"))
            {
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = @"INSERT INTO tb_Point(X,Y) VALUES(@x,@y);";
                cmd.Parameters.AddWithValue("@x", 300);
                cmd.Parameters.AddWithValue("@y", 400);

                //IAsyncResult ar = cmd.BeginExecuteNonQuery();
                //textBox1.Text = cmd.EndExecuteNonQuery(ar).ToString();

                textBox1.Text = cmd.ExecuteNonQuery().ToString();
            }

            using (SqlConnection cnn = new SqlConnection("server=DESKTOP-9OCF6G3;pwd=qq64022020;uid=sa;database=db_Point"))
            {
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = @"SELECT * FROM tb_Point;";
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    for(int i = 0;i<dr.FieldCount;i++)
                    {
                        listBox1.Items.Add(dr.GetName(i));
                    }
                }
            }


        }
    }
}
