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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("已取消");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //添加按钮，完成1数据表存储，2数据库存储，3树形图存储，4清空添加卡选项
            
            //先检查有没有空值
            string[] infomation=new string[5];
            textBox2.Text = comboBox1.Text;
            textBox4.Text = comboBox2.Text;

            infomation[0] = textBox1.Text;
            infomation[1] = textBox2.Text;
            infomation[2] = textBox3.Text;
            infomation[3] = textBox4.Text;
            infomation[4] = textBox5.Text;
            if(infomation[0]==""||infomation[1]==""||infomation[2]==""||infomation[3]==""||infomation[4]=="")
            {
                MessageBox.Show("请填全信息");
            }
            else
            {
                Class1.btnNum += 1;
                //将信息插入数据表
                int rCount = dataGridView1.RowCount;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[rCount - 1].Cells[0].Value = (rCount).ToString();
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Rows[rCount - 1].Cells[i + 1].Value = infomation[i];
                    //dataGridView1.Rows[0].Cells[i + 1].Value = infomation[i];
                    
                }
                //dataGridView1.Rows[rCount - 1].Cells[0].Value = "↑";
                //dataGridView1.Rows[rCount - 1].Cells[1].Value = "↓";
                
                
                //将信息插入数据库



                //将信息插入树形图
                //string treeText;
                string treeText = tabPage1.Text.Substring(0, tabPage1.Text.Length - 2);
                string io = infomation[3];
                foreach (TreeNode tnd in treeView1.Nodes)
                {
                    int k = tnd.Nodes.Count;
                    if (k != 0)
                    {
                        foreach (TreeNode tn in tnd.Nodes)
                        {
                            if (tn.Text == treeText)
                            {
                                //tn.Nodes.Add(new TreeNode(infomation[0]));
                                AddJieDian(tn, infomation[0], infomation[3]);
                            }
                            else
                            {
                                DiGuiJieDian(tn, treeText, infomation[0], infomation[3]);//调用遍历函数
                            }
                        }
                    }
                    else
                    {
                        if (tnd.Text == treeText)
                        {
                            //tnd.Nodes.Add(new TreeNode(infomation[0]));
                            AddJieDian(tnd, infomation[0], infomation[3]);
                        }
                    }

                }

                //清空添加卡
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = null;
                comboBox2.Text = null;
                textBox1.Focus();
            }
            
            
            //treeView1.SelectedNode.

            
        }

        private void DiGuiJieDian(TreeNode tn, string treeText, string infomation0, string infomation3)
        {
            //树形图的递归遍历函数
            int k = tn.Nodes.Count;
            if (k != 0)
            {
                foreach(TreeNode tn1 in tn.Nodes)
                {
                    if (tn1.Text == treeText)
                    {
                        //tn1.Nodes.Add(new TreeNode(infomation));
                        AddJieDian(tn1, infomation0, infomation3);
                    }
                    else
                    {
                        DiGuiJieDian(tn1, treeText, infomation0, infomation3);
                    }
                }
            }
            else
            {
                if (tn.Text == treeText)
                {
                    //tn.Nodes.Add(new TreeNode(infomation));
                    AddJieDian(tn, infomation0, infomation3);
                }
            }
        }
        private void AddJieDian(TreeNode tn, string infomation0, string infomation3)
        {
            switch(infomation3)
            {
                case "输入":
                    tn.Nodes[0].Nodes.Add(new TreeNode(infomation0));
                    break;
                case "输出":
                    tn.Nodes[1].Nodes.Add(new TreeNode(infomation0));
                    break;
            }
        }

        private void 新建工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();//这里应该得用子线程吧？
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开openFileDialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Path = openFileDialog1.FileName.ToString();
                string Name = Path.Substring(Path.LastIndexOf("\\") + 1);
                //output("用户选择的文件目录为：" + Path);
                //output("");
                //output("用户选择的文件名称为：" + Name);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Visible = true;                   
            button4.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = null;
            comboBox2.Text = null;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
