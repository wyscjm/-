using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        long setTime = 0L;
        int enterTimes = 0;
        bool randnum = false;
        List<string> names_list;
        int names_len;
        public Form1()
        {
            InitializeComponent();
            names_list = ReadTxtFromFile("./name_config.txt");
            names_len = names_list.Count;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_total_number.Text = string.Format("总人数:{0}", names_len);
            label1.Text = names_list[0]; //"Hello!";
            button1.Font = new Font(button1.Font.FontFamily, 30, button1.Font.Style);
            timers.Text = "运行时间:0s"; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            randnum = !randnum;
            if (randnum)
            {
                Button a = sender as Button;
                a.Text = "停止";
                setTime = 0;
                timers.Text = "运行时间:0s";
            }
            else
            {
                Button a = sender as Button;
                a.Text = "运行";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (randnum)
            {
                enterTimes++;
                if (enterTimes >= 40)
                {
                    setTime += 1;
                    timers.Text = string.Format("运行时间:{0}s", setTime);
                    enterTimes = 0;
                }
                Random random = new Random();
                int i = random.Next(1, names_len);

                label1.Text = names_list[i];

                //if (i >= 10)
                //{
                //    label1.Text = i.ToString();
                //}
                //else
                //{
                //    label1.Text = string.Format("0{0}", i.ToString());
                //}
            }
        }


        //--------------------- 
        //作者：梦想不断超越 
        //来源：CSDN 
        //原文：https://blog.csdn.net/lujiachun1/article/details/76653715 
        //版权声明：本文为博主原创文章，转载请附上博文链接！
        /// <summary>读取文件，返回一个含有文件数据的行列表</summary>
        /// <param name="TxtFilePath">文件路径</param>
        /// <returns>文件数据的行列表</returns>
        private List<string> ReadTxtFromFile(string TxtFilePath)
        {
            // 1 首先创建一个泛型为string 的List列表
            List<string> AllRowStrList = new List<string>();
            {
                // 2 加载文件
                System.IO.StreamReader sr = new
                    System.IO.StreamReader(TxtFilePath, 
                        Encoding.Default);
                String line; // 3 调用StreamReader的ReadLine()函数
                while ((line = sr.ReadLine()) != null)
                {   // 4 将每行添加到文件List中

                    // 判断是否有特殊符号
                    line = line.Replace("；",",");
                    line = line.Replace("，", ",");
                    line = line.Replace(";", ",");
                    line = line.Replace("、", ",");
                    List<string> listStrLineElements = line.Split(',').ToList();
                    AllRowStrList.AddRange(listStrLineElements);
                }
                // 5 关闭流
                sr.Close();
            }
            // remove empty name
            AllRowStrList = AllRowStrList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

            // 6 完成操作
            return AllRowStrList;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
