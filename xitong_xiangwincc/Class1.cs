using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xitong_xiangwincc
{
    class Class1
    {
        public static int funNum = 10;//函数的个数
        public static int btnNum = 0;//button的个数
        //public static Button[,] btnUp = new Button[funNum,100];
        //public static Button[,] btnDown = new Button[funNum, 100];

        public static string filePath;
        public static string fileName;
        public static string file;

        public static string projectName;//项目名称
        public static int biaozhi=0;//标志位，改为1则说明自己设置项目名称了，否则默认为“函数1”

        //public static string[] input = new string[50];
        //public static string[] output = new string[10];
        //public static string[,] input;
        //public static string[,] output;
        public static string[] input;
        public static string[] output;
    }
}
