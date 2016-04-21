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
    public partial class Form2 : Form
    {
        public Form2(iii fun)
        {
            InitializeComponent();
            myfun = fun;
        }
        iii myfun;
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.fileName = textBox1.Text;
            Class1.filePath = textBox2.Text;
            Class1.file = Class1.filePath + Class1.fileName;

            //string a="";
            //a.Replace(Class1.fileName,"\\");
            //按路径和名称新建文件夹
            //Console.WriteLine("'C:\\test'目录是否存在：" + System.IO.Directory.Exists("C:\\test"));
            //textBox2.Text = "'C:\\test'目录是否存在：" + System.IO.Directory.Exists("C:\\test");
            // if (System.IO.Directory.Exists(Class1.fileRoad  + Class1.fileName) == false)
            //{
            //    System.IO.Directory.CreateDirectory(Class1.fileRoad  + Class1.fileName);
            //} 
            
            if (System.IO.Directory.Exists(Class1.file) == false)
            {
                System.IO.Directory.CreateDirectory(Class1.file);
                MessageBox.Show("工程创建成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("工程已存在，是否覆盖？");
                //System.IO.File.Create(Class1.file+"\\a.txt");
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Class1.filePath = folderBrowserDialog1.SelectedPath+"\\";
                textBox2.Text = folderBrowserDialog1.SelectedPath+"\\";
            }
            //FolderDialog fDialog = new FolderDialog();
            //fDialog.DisplayDialog();
            //this.tbfilePath.Text = fDialog.Path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            myfun();
        }
        public delegate void iii();

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
