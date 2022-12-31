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

namespace md5Mgr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            richTextBox1.Text = "You will see output here";
            richTextBox1.ReadOnly = true;
            textBox2.Hide();
            textBox3.Hide();
            button5.Hide();
            label2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("md5mgr by Enderbyte Programs\n\nEasily calculate and compare md5 checksums\n\nVersion 0.1\n(c) 2022-2023 Enderbyte Programs LLC. ALl rights reserved","Md5mgr",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Execute
            if (comboBox1.SelectedIndex == 0)
            {
                if (File.Exists(textBox1.Text) )
                {
                    try
                    {
                        richTextBox1.Text = $"{textBox1.Text} : {Execution.CalculateMD5(textBox1.Text)}";
                        Console.WriteLine(Execution.CalculateMD5(textBox1.Text));//For use as debug
                    } catch (Exception xe)
                    {
                        MessageBox.Show(xe.Message, "Calc error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("The provided file does not exist.", "md5mgr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else if (comboBox1.SelectedIndex == 1)
            {
                if (File.Exists(textBox1.Text) && File.Exists(textBox2.Text))
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = "";
                    string check1 = Execution.CalculateMD5(textBox1.Text);
                    richTextBox1.Text += textBox1.Text+" : "+check1 + "\n";
                    string check2 = Execution.CalculateMD5(textBox2.Text);
                    richTextBox1.Text += textBox2.Text + " : " + check2 + "\n";
                    if (check1.Equals(check2))
                    {
                        MessageBox.Show("Files do match");
                        richTextBox1.Text += "\nFiles do match";
                    } else
                    {
                        MessageBox.Show("Files do not match");
                        richTextBox1.Text += "\nFiles do NOT match";
                    }
                }
                else
                {
                    MessageBox.Show("The provided file does not exist.", "md5mgr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                if (File.Exists(textBox1.Text))
                {
                    string checksum = Execution.CalculateMD5(textBox1.Text);
                    richTextBox1.Text = $"{textBox1.Text} : {Execution.CalculateMD5(textBox1.Text)}";
                    if (checksum.Equals(textBox3.Text))
                    {
                        MessageBox.Show("File and sum do match","md5mgr",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else
                    {
                        MessageBox.Show("File and sum do not match", "md5mgr");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                button3.Text = "Compare";
                if (comboBox1.SelectedIndex == 1)
                {
                    textBox2.Show();
                    button5.Show();
                    textBox3.Hide();
                    label2.Hide();
                } else if (comboBox1.SelectedIndex == 2)
                {
                    textBox2.Hide();
                    button5.Hide();
                    label2.Show();
                    textBox3.Show();
                }
            } else
            {
                button3.Text = "Calculate";
                textBox2.Hide();
                textBox3.Hide();
                label2.Hide();
                button5.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Please select a file";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.Replace(" ", "").Length > 1)
            { textBox1.Text = openFileDialog.FileName; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Please select a file";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.Replace(" ", "").Length > 1)
            { textBox2.Text = openFileDialog.FileName; }
        }
    }
}
