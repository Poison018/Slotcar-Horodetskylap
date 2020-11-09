using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.IO.Ports;
namespace zase4kak
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			//CheckForIllegalCrossThreadCalls = false;
		}

		private void Form2_Load(object sender, EventArgs e)
		{


		}

		private void button1_Click(object sender, EventArgs e)
		{


			Form3 f3 = new Form3();


			f3.textBox24.Text = textBox5.Text;


			f3.textBox13.Text = textBox1.Text;
			f3.textBox14.Text = textBox2.Text;

			switch (comboBox2.SelectedIndex)
			{
				case 0:
					f3.label14.Text = "Ретро";
					f3.label14.Visible = true;

					break;
				case 1:
					f3.label14.Text = "Вантажівка";
					f3.label14.Visible = true;
					break;
				case 2:
					f3.label14.Text = "ЕS-Стандарт";
					f3.label14.Visible = true;
					break;
				case 3:
					f3.label14.Text = "G-33";
					f3.label14.Visible = true;
					break;
				case 4:
					f3.label14.Text = "F1-24";
					f3.label14.Visible = true;
					break;
				case 5:
					f3.label14.Text = "G12-Стандарт";
					f3.label14.Visible = true;
					break;
				case 6:
					f3.label14.Text = "G12";
					f3.label14.Visible = true;
					break;
				case 7:
					f3.label14.Text = "PR24";
					f3.label14.Visible = true;
					break;
				case 8:
					f3.label14.Text = "ES-24";
					f3.label14.Visible = true;
					break;
				case 9:
					f3.label14.Text = "ES-32";
					f3.label14.Visible = true;
					break;
				case 10:
					f3.label14.Text = "F1";
					f3.label14.Visible = true;
					break;
				case 11:
					f3.label14.Text = "G15";
					f3.label14.Visible = true;
					break;
				case 12:
					f3.label14.Text = "Open-G12";
					f3.label14.Visible = true;
					break;


			}
			f3.Show();
			//this.Visible = false;
		}



		private void timer1_Tick(object sender, EventArgs e)
		{


			if(checkBox1.Checked == true)		//задавання параметрів фінальної гонки
            {
				label8.Visible = true;
				textBox5.Visible = true;
            }
            else
            {
				label8.Visible = false;
				textBox5.Visible = false;
			}



			if(textBox1.Text == "" || textBox2.Text == "")
            {
				button1.Enabled = false;
            }
            else
            {
				button1.Enabled = true;
            }


			if (textBox3.Text == "" || textBox4.Text == "")
            {
				button2.Enabled = false;

            }
            else
            {
				button2.Enabled = true;
            }

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form4 f4 = new Form4();
			f4.Show();
			f4.textBox106.Text = textBox3.Text;
			f4.textBox107.Text = textBox4.Text;
			
			switch (comboBox2.SelectedIndex)
			{
				case 0:
					f4.label1.Text = "Ретро";
					f4.label1.Visible = true;

					break;
				case 1:
					f4.label1.Text = "Вантажівка";
					f4.label1.Visible = true;
					break;
				case 2:
					f4.label1.Text = "ЕS-Стандарт";
					f4.label1.Visible = true;
					break;
				case 3:
					f4.label1.Text = "G-33";
					f4.label1.Visible = true;
					break;
				case 4:
					f4.label1.Text = "F1-24";
					f4.label1.Visible = true;
					break;
				case 5:
					f4.label1.Text = "G12-Стандарт";
					f4.label1.Visible = true;
					break;
				case 6:
					f4.label1.Text = "G12";
					f4.label1.Visible = true;
					break;
				case 7:
					f4.label1.Text = "PR24";
					f4.label1.Visible = true;
					break;
				case 8:
					f4.label1.Text = "ES-24";
					f4.label1.Visible = true;
					break;
				case 9:
					f4.label1.Text = "ES-32";
					f4.label1.Visible = true;
					break;
				case 10:
					f4.label1.Text = "F1";
					f4.label1.Visible = true;
					break;
				case 11:
					f4.label1.Text = "G15";
					f4.label1.Visible = true;
					break;
				case 12:
					f4.label1.Text = "Open-G12";
					f4.label1.Visible = true;
					break;
			}
		}

        private void button3_Click(object sender, EventArgs e)
        {
			
			
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
			if(checkBox1.Checked == true)
            {
			
				checkBox2.Checked = false;
            }
            else
            {
				
				checkBox1.Checked = false;
			}
			
		}

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBox2.Checked == true)
			{
				
				checkBox1.Checked = false;
				textBox5.Text = "";
			}
			else
			{
				
				checkBox2.Checked = false;
			}
		}

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
			Form3 f3 = new Form3();      //закриваю програму
				DialogResult dialog = MessageBox.Show(
				 "Вы действительно хотите выйти из программы?",
				 "Завершение программы",
				 MessageBoxButtons.YesNo,
				 MessageBoxIcon.Warning
				);
				if (dialog == DialogResult.Yes)
				{
					e.Cancel = false;
				Application.Exit();
			}
			else
				{
					e.Cancel = true;
				
				}
			}
		}
	}


    
