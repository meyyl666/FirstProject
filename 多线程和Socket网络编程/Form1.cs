using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多线程和Socket网络编程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择音乐文件";
            ofd.InitialDirectory = @"C:\Users\Administrator\Desktop";
            ofd.Multiselect = true;
            ofd.Filter = "音乐文件|*.wav|所有文件|*.*";
            ofd.ShowDialog();
            //获取我们在文件夹中选择所有文件的全路径
            string[] path = ofd.FileNames;
            foreach(var item in path)
            {
                listBox1.Items.Add(Path.GetFileName(item));
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            index--;
            if(index<0)
            {
                index = listBox1.Items.Count - 1;
            }
            //将重新改变后的索引重新的赋值给当前选中项
            listBox1.SelectedIndex = index;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            index++;
            if(index > listBox1.Items.Count-1)
            {
                index = 0;
            }
            listBox1.SelectedIndex = index;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
