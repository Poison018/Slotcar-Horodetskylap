using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zase4ka.Properties;
namespace zase4kak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = Settings.Default.enabled4;
            checkBox2.Checked = Settings.Default.enabled6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();
            f2.Show();
            f2.button1.Visible = true;
            f2.button3.Visible = false;
            this.Visible = false;
            f2.button5.Visible = false;
            f2.button2.Visible = true;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                label2.Text = "Доступно";
                label2.ForeColor = Color.DarkGreen;
            }
            else
            {
                label2.Text = "Заблоковано";
                label2.ForeColor = Color.DarkRed;
            }


            if (button3.Enabled == true)
            {
                label3.Text = "Доступно";
                label3.ForeColor = Color.DarkGreen;
            }
            else
            {
                label3.Text = "Заблоковано";
                label3.ForeColor = Color.DarkRed;
            }


            if (textBox1.Text == "alabamba")
            {
                
                label1.Visible = false;
                textBox1.Visible = false;
       
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                textBox1.Text = "";
            }
            else
            {
                if (textBox1.Text != "")
                {
                    label1.Text = "Пароль не вірний!";
                    label1.ForeColor = Color.DarkRed;
                }
                else
                {
                    label1.Text = "Введіть пароль!!";
                    label1.ForeColor = Color.DarkGreen;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button2.Visible = false;
            label1.Visible = true;
           
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Visible = false;
            f2.Show();
            f2.button1.Visible = false;
            f2.button5.Visible = true;
           // f2.button4.Visible = true;
            f2.button2.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                button1.Enabled = true;
                Settings.Default.enabled4 = checkBox1.Checked = true;
                Settings.Default.Save();
            }
            else
            {
                button1.Enabled = false ;
                Settings.Default.enabled4 = checkBox1.Checked = false;
                Settings.Default.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label5.Visible = false; ;
            button5.Visible = false;
            button4.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            button2.Visible = true;
            Settings.Default.enabled4 = checkBox1.Checked;
            Settings.Default.enabled6 = checkBox2.Checked;
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                button3.Enabled = true;
                Settings.Default.enabled6 = checkBox2.Checked = true;
                Settings.Default.Save();
            }
            else
            {
                button3.Enabled = false;
                Settings.Default.enabled6 = checkBox2.Checked = false;
                Settings.Default.Save();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

           

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            label5.Visible = true;
            Settings.Default.best_time_name1pr24 = "Рекорд1";
            Settings.Default.best_time_name2pr24 = "Рекорд2";
            Settings.Default.best_time_name3pr24 = "Рекорд3";
            Settings.Default.best_time_name1retro = "Рекорд1";
            Settings.Default.best_time_name2retro = "Рекорд2";
            Settings.Default.best_time_name3retro = "Рекорд2";
            Settings.Default.best_time_name1vantagivka = "Рекорд1";
            Settings.Default.best_time_name2vantagivka = "Рекорд2";
            Settings.Default.best_time_name3vantagivka = "Рекорд3";
            Settings.Default.best_time_name1Es_s = "Рекорд1";
            Settings.Default.best_time_name2Es_s = "Рекорд2";
            Settings.Default.best_time_name3Es_s = "Рекорд3";
            Settings.Default.best_time_name1g33 = "Рекорд1";
            Settings.Default.best_time_name2g33 = "Рекорд2";
            Settings.Default.best_time_name3g33 = "Рекорд3";
            Settings.Default.best_time_name1f124 = "Рекорд1";
            Settings.Default.best_time_name2f124 = "Рекорд2";
            Settings.Default.best_time_name3f124 = "Рекорд3";
            Settings.Default.best_time_name1g12 = "Рекорд1";
            Settings.Default.best_time_name2g12 = "Рекорд2";
            Settings.Default.best_time_name3g12 = "Рекорд3";
            Settings.Default.best_time_name1es24 = "Рекорд1";
            Settings.Default.best_time_name2es24 = "Рекорд2";
            Settings.Default.best_time_name3es24 = "Рекорд3";
            Settings.Default.best_time_name1es32 = "Рекорд1";
            Settings.Default.best_time_name2es32 = "Рекорд2";
            Settings.Default.best_time_name3es32 = "Рекорд3";
            Settings.Default.best_time_name1f1 = "Рекорд1";
            Settings.Default.best_time_name2f1 = "Рекорд2";
            Settings.Default.best_time_name3f1 = "Рекорд3";
            Settings.Default.best_time_name1g15 = "Рекорд1";
            Settings.Default.best_time_name2g15 = "Рекорд2";
            Settings.Default.best_time_name3g15 = "Рекорд3";
            Settings.Default.best_time_name1g12open = "Рекорд1";
            Settings.Default.best_time_name2g12open = "Рекорд2";
            Settings.Default.best_time_name3g12open = "Рекорд3";



            Settings.Default.best_time_result1Pr24 = "999";
            Settings.Default.best_time_result2Pr24 = "999";
            Settings.Default.best_time_result3Pr24 = "999";
            Settings.Default.best_time_result1retro = "999";
            Settings.Default.best_time_result2retro = "999";
            Settings.Default.best_time_result3retro = "999";
            Settings.Default.best_time_result1vantagivka = "999";
            Settings.Default.best_time_result2vantagivka = "999";
            Settings.Default.best_time_result3vantagivka = "999";
            Settings.Default.best_time_result1Es_s = "999";
            Settings.Default.best_time_result2Es_s = "999";
            Settings.Default.best_time_result3Es_s = "999";
            Settings.Default.best_time_result1g33 = "999";
            Settings.Default.best_time_result2g33 = "999";
            Settings.Default.best_time_result3g33 = "999";
            Settings.Default.best_time_result1f124 = "999";
            Settings.Default.best_time_result2f124 = "999";
            Settings.Default.best_time_result3f124 = "999";
            Settings.Default.best_time_result1g12 = "999";
            Settings.Default.best_time_result2g12 = "999";
            Settings.Default.best_time_result3g12 = "999";
            Settings.Default.best_time_result1es24 = "999";
            Settings.Default.best_time_result2es24 = "999";
            Settings.Default.best_time_result3es24 = "999";
            Settings.Default.best_time_result1es32 = "999";
            Settings.Default.best_time_result2es32 = "999";
            Settings.Default.best_time_result3es32 = "999";
            Settings.Default.best_time_result1f1 = "999";
            Settings.Default.best_time_result2f1 = "999";
            Settings.Default.best_time_result3f1 = "999";
            Settings.Default.best_time_result1g15 = "999";
            Settings.Default.best_time_result2g15 = "999";
            Settings.Default.best_time_result3g15 = "999";
            Settings.Default.best_time_result1g12open = "999";
            Settings.Default.best_time_result2g12open = "999";
            Settings.Default.best_time_result3g12open = "999";
            Settings.Default.Save();
        }
    }
}
