/* ===================================
 * 当前项目：TimeStamp
 * 功能描述：Form1  
 * 创 建 者：hackgsl
 * 创建日期：2020-04-14 21:09:03
 * CLR Ver ：4.0.30319.42000
 * =================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeStamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dat = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            textBox2.Text = dat.ToString("yyyy-MM-dd");
            textBox4.Text = GetTimeStamp(dat); ;
            //设置每隔一秒调用一次定时器Tick事件
            timer1.Interval = 1000;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = GetTimeStamp(DateTime.Parse(Convert.ToDateTime(textBox2.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = ConvertStringToDateTime(textBox4.Text).ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "开始")
            {
                button3.Text = "停止";
                //启动定时器
                timer1.Start();
            }
            else
            {
                button3.Text = "开始";
                //停止定时器
                timer1.Stop();
            }

        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp(DateTime time)
        {
            long ts = ConvertDateTimeToInt(time);
            return ts.ToString();
        }

        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000000;   //改这里可以实现秒级或者毫秒级    
            return t;
        }
        /// <summary>        
        /// 时间戳转为C#格式时间        
        /// </summary>        
        /// <param name="timeStamp"></param>        
        /// <returns></returns>        
        private DateTime ConvertStringToDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //重新设置日期时间控件的文本
            dateTimePicker1.ResetText();
            textBox1.Text = ConvertDateTimeToInt(dateTimePicker1.Value).ToString();
        }
    }
}
