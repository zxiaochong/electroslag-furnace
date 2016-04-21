using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Threading;


namespace xitong_xiangwincc
{
    public partial class Form1 : Form
    {
        public static Thread t1;
        public void fun1()
        {
            if (Class1.fileName != null)
            {
                treeView1.Nodes[0].Text = Class1.fileName;
            }
        }
        //public void fun2()
        //{
        //    if (Class1.projectName != null)
        //    {
        //        treeView1.Nodes[1].Text = Class1.projectName;
        //    }
        //}

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
            button3.Visible = false;
            button4.Visible = false;
            
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
            Form2 f2 = new Form2(fun1);
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
        private void 导入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
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
            button3.Visible = false;
            button4.Visible = false;
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

            //将参数存入input和output
            int inp = 0;
            int outp = 0;
            int totalRow = dataGridView1.RowCount - 1;
            for (int i = 0; i < totalRow; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value == "输入")
                {
                    inp++;
                }
                else
                {
                    outp++;
                }
            }
            Class1.input = new string[inp];
            Class1.output = new string[outp];
            inp = 0;
            outp = 0;
            for (int i = 0; i < totalRow; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value == "输入")
                {
                    Class1.input[inp]=dataGridView1.Rows[i].Cells[]
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
        }

        

        private void excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "_execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
                return;
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

            string str = "";
            try
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dataGridView1.Columns[i].HeaderText;
                }
                sw.WriteLine(str);
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        tempStr += dataGridView1.Rows[j].Cells[k].Value.ToString();
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }

        private void 运行设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();

        }
        
        public void Method1()
        {
            Form f4= new Form4();
            f4.Show();
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //如果是第一级
            //OpenFileDialog openFileDialog2 = new OpenFileDialog();
            //打开……
            
            //同步到右侧
            if(treeView1.SelectedNode.Level==0)
            {
                //t1 = new Thread(Method1);
                //t1.Start();
                Form f4 = new Form4();
                f4.ShowDialog();

                if (Class1.biaozhi == 1)
                {
                    string nownode = "";
                    if (Class1.projectName != null)
                    {
                        nownode = Class1.projectName;
                    }
                    else
                    {
                        nownode = "函数1";
                    }
                    tabPage1.Text = nownode + "配置";
                    treeView1.SelectedNode.Nodes.Add(nownode);
                    foreach (TreeNode td in treeView1.SelectedNode.Nodes)
                    {
                        if (td.Text == nownode)
                        {
                            td.Nodes.Add("输入");
                            td.Nodes.Add("输出");
                        }
                    }
                }
                
                //Class1.projectName = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //上调顺序按钮
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选中要调整的行");
            }
            else if (dataGridView1.CurrentRow.Index <= 0)
            {
                MessageBox.Show("该行已在顶端，不能上移");
            }
            else
            {
                int nowIndex = dataGridView1.CurrentRow.Index;
                string[] rowData = new string[5];
                for (int i = 0; i < 5; i++ )
                {
                    rowData[i] = dataGridView1.Rows[nowIndex].Cells[i+1].Value.ToString();
                }
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Rows[nowIndex].Cells[i+1].Value = dataGridView1.Rows[nowIndex-1].Cells[i+1].Value;
                }
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Rows[nowIndex-1].Cells[i+1].Value = rowData[i];
                }
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[nowIndex - 1].Cells[0];//设定当前行
                
                //以下是网上找的程序，但是本程序没有DataSource数据源所以不能这么直接用，借用思想
                //_rowData = (this.dataGridView1.DataSource as DataTable).Rows[nowIndex].ItemArray;
                //(this.dataGridView1.DataSource as DataTable).Rows[nowIndex].ItemArray = (this.dataGridView1.DataSource as DataTable).Rows[nowIndex - 1].ItemArray;
                //(this.dataGridView1.DataSource as DataTable).Rows[nowIndex - 1].ItemArray = _rowData;
                //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[nowIndex - 1].Cells[0];//设定当前行
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //下调顺序按钮
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选中要调整的行");
            }
            else if (dataGridView1.CurrentRow.Index >= dataGridView1.Rows.Count - 2)
            {
                MessageBox.Show("该行已在低端，不能下移");
            }
            else
            {
                int nowIndex = dataGridView1.CurrentRow.Index;
                string[] rowData = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    rowData[i] = dataGridView1.Rows[nowIndex].Cells[i+1].Value.ToString();
                }
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Rows[nowIndex].Cells[i+1].Value = dataGridView1.Rows[nowIndex + 1].Cells[i+1].Value;
                }
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Rows[nowIndex + 1].Cells[i+1].Value = rowData[i];
                }
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[nowIndex + 1].Cells[0];//设定当前行
            }
        }

        private void 运行参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
        //public static bool SaveDataTableToExcel(System.Data.DataTable excelTable, string filePath)
        //{
        //    Microsoft.Office.Interop.Excel.Application app =
        //        new Microsoft.Office.Interop.Excel.ApplicationClass();
        //    try
        //    {
        //        app.Visible = false;
        //        Workbook wBook = app.Workbooks.Add(true);
        //        Worksheet wSheet = wBook.Worksheets[1] as Worksheet;
        //        if (excelTable.Rows.Count > 0)
        //        {
        //            int row = 0;
        //            row = excelTable.Rows.Count;
        //            int col = excelTable.Columns.Count;
        //            for (int i = 0; i < row; i++)
        //            {
        //                for (int j = 0; j < col; j++)
        //                {
        //                    string str = excelTable.Rows[i][j].ToString();
        //                    wSheet.Cells[i + 2, j + 1] = str;
        //                }
        //            }
        //        }

        //        int size = excelTable.Columns.Count;
        //        for (int i = 0; i < size; i++)
        //        {
        //            wSheet.Cells[1, 1 + i] = excelTable.Columns[i].ColumnName;
        //        }
        //        //设置禁止弹出保存和覆盖的询问提示框   
        //        app.DisplayAlerts = false;
        //        app.AlertBeforeOverwriting = false;
        //        //保存工作簿   
        //        wBook.Save();
        //        //保存excel文件   
        //        app.Save(filePath);
        //        app.SaveWorkspace(filePath);
        //        app.Quit();
        //        app = null;
        //        return true;
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }
        //    finally
        //    {
        //    }
        //} 
    }
}
