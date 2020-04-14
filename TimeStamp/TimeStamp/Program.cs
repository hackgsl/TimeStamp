/* ===================================
 * 项目名称：TimeStamp
 * 功能描述：Program  
 * 创 建 者：hackgsl
 * 创建日期：2020-04-14 21:09:03
 * CLR Ver ：4.0.30319.42000
 * =================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimeStamp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
