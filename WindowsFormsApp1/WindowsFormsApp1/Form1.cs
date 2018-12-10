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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "00";
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
                    timers.Text = $"运行时间:{setTime}s";
                    enterTimes = 0;
                }
                Random random = new Random();
                int i = random.Next(1, 60);
                if (i >= 10)
                {
                    label1.Text = i.ToString();
                }
                else
                {
                    label1.Text = $"0{i.ToString()}";
                }
            }
        }

    }
}
