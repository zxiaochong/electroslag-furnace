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
        public static Button[,] btnUp = new Button[funNum,100];
        public static Button[,] btnDown = new Button[funNum, 100];

        public static string fileRoad;
        public static string fileName;
        public static string file;
    }
}
