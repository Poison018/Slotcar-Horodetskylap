﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zase4kak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();
            f2.Show();
            f2.button1.Visible = true;
            f2.button3.Visible = false;
            this.Visible = false;
            f2.button4.Visible = false;
            f2.button2.Visible = true;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text == "alabamba")
            {
                label1.Visible = false;
                textBox1.Visible = false;
                timer1.Enabled = false;
               
            }
            else
            {
                label1.Text = "Пароль не вірний!";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button2.Visible = false;
            label1.Visible = true;
            timer1.Enabled = true;
            
            
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
            f2.button3.Visible = true;
            f2.button4.Visible = true;
            f2.button2.Visible = false;
        }
    }
}
