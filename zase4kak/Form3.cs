using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Media;
using zase4ka.Properties;
namespace zase4kak
{
	public partial class Form3 : Form
	{
		string[,] list = new string[60, 5];
		string[] name = new string[40];
		SoundPlayer timetostartsound = new SoundPlayer();
		SoundPlayer kinetsgonkisound = new SoundPlayer();
		SoundPlayer pausesound = new SoundPlayer();
		SoundPlayer startsound = new SoundPlayer();
		SoundPlayer perehid = new SoundPlayer();
		SoundPlayer sekynd = new SoundPlayer();
		SoundPlayer fivesecond = new SoundPlayer();
		SoundPlayer best_time = new SoundPlayer();
		SoundPlayer start_to_pause = new SoundPlayer();



		int timetotraning = 60;

		public Form3()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;

			AutoSize = false;
			AutoScaleMode = AutoScaleMode.Font;

			float scaleX = ((float)Screen.PrimaryScreen.WorkingArea.Width / 1920);
			float scaleY = ((float)Screen.PrimaryScreen.WorkingArea.Height / 1080);
			SizeF aSf = new SizeF(scaleX, scaleY);
			this.Scale(aSf);
			
			

			// вибір кольору доріжки
			panel1.BackColor = Settings.Default.line_1;
			panel3.BackColor = Settings.Default.line_2;
			panel4.BackColor = Settings.Default.line_3;
			panel5.BackColor = Settings.Default.line_4;
			delay = Settings.Default.delay1;
			секToolStripMenuItem.BackColor = Settings.Default.color_delay;
			секToolStripMenuItem1.BackColor = Settings.Default.color_delay1;
			секToolStripMenuItem2.BackColor = Settings.Default.color_delay2;
			секToolStripMenuItem3.BackColor = Settings.Default.color_delay3;
			секToolStripMenuItem4.BackColor = Settings.Default.color_delay4;
			секToolStripMenuItem5.BackColor = Settings.Default.color_delay5;
			toolStripTextBox1.Text = Settings.Default.deley6_text;
			toolStripTextBox1.BackColor = Settings.Default.color_delay6;
		
		}

		private void button1_Click(object sender, EventArgs e)
		{
			fivesecond.Play();
			button13.Visible = false;
			label70.Visible = false;
			button12.Enabled = false;
			timer1.Enabled = true;
			button1.Visible = false;

			button6.Focus();
		}

		
		//записник результату кожної доріжки
		int lanes1,lanes2,lanes3, lanes4, lanes5, lane2_1, lane2_2, lane2_3, lane2_4, lane2_5, lane3_1, lane3_2, lane3_3, lane3_4, lane3_5, lane4_1, lane4_2, lane4_3, lane4_4, lane4_5, lane5_1, lane5_2, lane5_3, lane5_4, lane5_5;
		int position = 1, position1 = 0;

		int mins, secs, min, sec, i, msecs, mmsecs, b, c, d, time_to_traning_min, time_to_traning_sec, traning_number_group = 1;

		int time_to_traning_secs = 1;// секунди для тренування
		double delay;

		int timetostart = 5; // значення стартового таймера

		string prostoi, prostoi2, prostoi3;
		int prostoi_number,prostoi_number2, prostoi_number3;

		//для прогнозу
		double prognoz1, prognoz2, prognoz3, prognoz4,prognoz5;
		double masuv, kola, seredniychas, prognoz;

		double Time, Times, Timez, Timeg,Timeb, seredniychas1, seredniychas2, seredniychas3, seredniychas4,seredniychas5;//timer на час кола
		private void timer1_Tick(object sender, EventArgs e)
		{


			//ОБНУЛЯЮ ДАНІ ДЛЯ ПРОГНОЗУ
			prognoz1 = 0;
			prognoz2 = 0;
			prognoz3 = 0;
			prognoz4 = 0;
			prognoz5 = 0;
			seredniychas1 = 0;
			seredniychas2 = 0;
			seredniychas3 = 0;
			seredniychas4 = 0;
			seredniychas5 = 0;
			masuv = 0;
			kola = 0;
			seredniychas = 0;
			prognoz = 0;
			label54.Text = "0";
			label57.Text = "0";
			label58.Text = "0";
			label118.Text = "0";
			label8.Text = "0";
			label56.Text = "0";
			label117.Text = "0";
			label119.Text = "0";

			label131.Text = "0";
			label125.Text = "0";
			label132.Text = "0";
			label126.Text = "0";

			label133.Text = "0";
			label127.Text = "0";
			label134.Text = "0";
			label128.Text = "0";


			label18.Text = "00,000";
			label22.Text = "00,000";
			label19.Text = "00,000";
			label20.Text = "00,000";
			label16.Text = "999";
			label29.Text = "00,000";
			label30.Text = "00,000";
			label31.Text = "00,000";
			label32.Text = "00,000";
			label42.Text = "999";
			label35.Text = "00,000";
			label36.Text = "00,000";
			label37.Text = "00,000";
			label34.Text = "00,000";
			label43.Text = "999";
			label38.Text = "00,000";
			label39.Text = "00,000";
			label40.Text = "00,000";
			label41.Text = "00,000";
			label44.Text = "999";




			timer11.Interval = 15; //timer на час кола
			Time = 0.0;             //timer на час кола

			timer16.Interval = 15; //timer на час кола
			Timeg = 0.0;             //timer на час кола

			timer17.Interval = 15; //timer на час кола
			Timez = 0.0;             //timer на час кола

			timer15.Interval = 15; //timer на час кола
			Times = 0.0;             //timer на час кола


			if (label4.Text == "4")             //звук для time to start
			{

				timetostartsound.SoundLocation = "music/81980c1a7dcb7cd.wav";
				timetostartsound.Load();
				timetostartsound.Play();
			}

			label4.Text = Convert.ToString(timetostart); //вивід стартового таймера у лейбл
			timetostart--;

			if (timetostart == -1) //якщо стартовий номер = -1 таймер зупиняє роботу і ховає лейбл4
			{

				timer1.Enabled = false;


				if (timetostart == -1)


				{



					prognoz1 = 0;
					prognoz2 = 0;
					prognoz3 = 0;
					prognoz4 = 0;
					prognoz5 = 0;
					timer32.Enabled = true;
					label71.Visible = true;
					timer2.Enabled = true;
					label4.Text = "00:00";
					sec = 1;
					min = Convert.ToInt32(textBox13.Text);
					label13.Text = "<<Гонка!>>";
					label15.Visible = true;

					//для простою
					if (label72.Visible == false)
					{
						label15.Text = "1/4";
                    }
                    else
                    {
						label15.Text = "1/5";
					}
					label13.Visible = true;
					timer20.Enabled = true;
					timer11.Enabled = true;
					timer16.Enabled = true;
					timer17.Enabled = true;
					timer15.Enabled = true;
					serialPort1.Open();
					serialPort1.WriteLine("4");
					serialPort1.Close();
					label69.Text = "Трек включений";
					label69.BackColor = Color.Green;
					button10.Enabled = false;
					button11.Enabled = true;



				}





			}

		}



		private void timer2_Tick(object sender, EventArgs e)
		{
			sec--;
			label4.Text = Convert.ToString(min) + ":" + Convert.ToString(sec); //зчитую час гонки який був заданий у настройках





			if (sec == 0)                                               //таймер для гонки 1 перший заїзд
			{
				min--;
				sec = 60;

				if (min == -1 && sec == 60)
				{
					perehid.Play();
					serialPort1.WriteLine("3");//пауза
					label69.Text = "Трек виключений";
					label69.BackColor = Color.Red;
					button10.Enabled = true;
					button11.Enabled = false;
					timer2.Enabled = false;
					label4.Text = "00:00";
					secs = Convert.ToInt32(textBox14.Text);
					mins = 0;
					timer3.Enabled = true;
					label13.Text = "<<Перехід!>>";
					button6.Enabled = false;



					if (label72.Visible == false)
					{

						//перехід між доріжками
						timer32.Enabled = false;

						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;






						//
						lanes1 = Convert.ToInt32(label17.Text);
						lane2_2 = Convert.ToInt32(label24.Text);
						lane3_3 = Convert.ToInt32(label23.Text);
						lane4_4 = Convert.ToInt32(label25.Text);







						textBox16.Text = label45.Text;
						label50.Text = label17.Text;
						label66.Text = label21.Text;
						label125.Text = label8.Text;
						label131.Text = label54.Text;

						textBox17.Text = label46.Text;
						label51.Text = label24.Text;
						label63.Text = label27.Text;
						label126.Text = label56.Text;
						label132.Text = label57.Text;

						textBox18.Text = label47.Text;
						label52.Text = label23.Text;
						label64.Text = label26.Text;
						label127.Text = label117.Text;
						label133.Text = label58.Text;

						textBox19.Text = label48.Text;
						label53.Text = label25.Text;
						label65.Text = label28.Text;
						label128.Text = label119.Text;
						label134.Text = label118.Text;




						label45.Text = textBox17.Text;
						label17.Text = label51.Text;
						label21.Text = label63.Text;
						label8.Text = label126.Text;
						label54.Text = label132.Text;

						label46.Text = textBox19.Text;
						label24.Text = label53.Text;
						label27.Text = label65.Text;
						label56.Text = label128.Text;
						label57.Text = label134.Text;

						label47.Text = textBox16.Text;
						label23.Text = label50.Text;
						label26.Text = label66.Text;
						label117.Text = label125.Text;
						label58.Text = label131.Text;

						label48.Text = textBox18.Text;
						label25.Text = label52.Text;
						label28.Text = label64.Text;
						label119.Text = label127.Text;
						label118.Text = label133.Text;




						label18.Text = "00,000";
						label22.Text = "00,000";
						label19.Text = "00,000";
						label20.Text = "00,000";
						label16.Text = "999";
						label29.Text = "00,000";
						label30.Text = "00,000";
						label31.Text = "00,000";
						label32.Text = "00,000";
						label42.Text = "999";
						label35.Text = "00,000";
						label36.Text = "00,000";
						label37.Text = "00,000";
						label34.Text = "00,000";
						label43.Text = "999";
						label38.Text = "00,000";
						label39.Text = "00,000";
						label40.Text = "00,000";
						label41.Text = "00,000";
						label44.Text = "999";
                    }
                    else
                    {
						
						string lane1, lane2, lane3, lane4, lane5; // перемінні для імен
						string value1, value2, value3, value4, value5; // перемінні для кіл

						//перехід між доріжками
						timer32.Enabled = false;

						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;



						lanes1 = Convert.ToInt32(label17.Text);
						lane2_2 = Convert.ToInt32(label24.Text);
						lane3_3 = Convert.ToInt32(label23.Text);
						lane4_4 = Convert.ToInt32(label25.Text);
						lane5_5 = Convert.ToInt32(label75.Text);

						lane1 = label45.Text;
						lane2 = label46.Text;
						lane3 = label47.Text;
						lane4 = label48.Text;
						lane5 = label72.Text;

						label47.Text = lane1;
						label72.Text = lane2;
						label48.Text = lane3;
						label46.Text = lane4;
						label45.Text = lane5;


						value1 = label17.Text;
						value2 = label24.Text;
						value3 = label23.Text;
						value4 = label25.Text;
						value5 = label75.Text;

						label23.Text = value1;
						label75.Text = value2;
						label25.Text = value3;
						label24.Text = value4;
						label17.Text = value5;



						label18.Text = "00,000";
						label22.Text = "00,000";
						label19.Text = "00,000";
						label20.Text = "00,000";
						label16.Text = "999";
						label29.Text = "00,000";
						label30.Text = "00,000";
						label31.Text = "00,000";
						label32.Text = "00,000";
						label42.Text = "999";
						label35.Text = "00,000";
						label36.Text = "00,000";
						label37.Text = "00,000";
						label34.Text = "00,000";
						label43.Text = "999";
						label38.Text = "00,000";
						label39.Text = "00,000";
						label40.Text = "00,000";
						label41.Text = "00,000";
						label44.Text = "999";







					}


					//сортування результату
					dataGridView3.Rows.Add(label17.Text + "," + 6);
					dataGridView3.Rows.Add(label24.Text + "," + 5);
					dataGridView3.Rows.Add(label23.Text + "," + 4);
					dataGridView3.Rows.Add(label25.Text + "," + 3);

					dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);






					//червона

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
					{
						panel1.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(7, 645);
								}

							}
						}

					}



					// зелена

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
					{
						panel3.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(7, 645);
								}

							}
						}

					}

					// синя

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
					{
						panel4.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(7, 645);
								}

							}
						}

					}

					//жовта 



					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
					{
						panel5.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(7, 645);
								}


							}
						}

					}


					timer26.Enabled = true;

					number_group.Text = "1";
				}
			}
		}



		private void timer3_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

			button6.Enabled = false;

			if (label4.Text == "0:3")
			{
				timetostartsound.Play();
			}

			if (label4.Text == "0:16")//залишилось 15 секунд
			{
				sekynd.Play();
			}


			if (secs > 60)
			{
				mins++;
				secs = secs - 60;

			}
			if (secs == -1)
			{

				mins--;
				secs = 60;
			}

			if (secs == 60 && mins == -1)
			{
				serialPort1.Open();
				serialPort1.WriteLine("4"); //продовжити 
				label69.Text = "Трек включений";
				label69.BackColor = Color.Green;
				button10.Enabled = false;
				button11.Enabled = true;

				if(label72.Visible == false)
                {
					Time = Convert.ToDouble(label63.Text);
					Timeg = Convert.ToDouble(label64.Text);
					Timez = Convert.ToDouble(label65.Text);
					Times = Convert.ToDouble(label66.Text);
                }
                else
                {
					Time = Timeb;
					Timeg = Convert.ToDouble(label26.Text);
					Timez = Convert.ToDouble(label28.Text);
					Times = Convert.ToDouble(label21.Text);
					Timeb = Convert.ToDouble(label27.Text);
				}
				

				timer3.Enabled = false;
				timer4.Enabled = true;
				sec = 1;
				if (textBox25.Text == "")
				{
					min = Convert.ToInt32(textBox13.Text);
				}
				else
				{
					min = Convert.ToInt32(textBox24.Text);
				}


				//для простою
				if (label72.Visible == false)
				{
					label4.Text = "00:00";
					label13.Text = "<<Гонка!>>";
					label15.Text = "2/4";
					timer32.Enabled = true;
					timer17.Enabled = true;
					timer11.Enabled = true;
					timer15.Enabled = true;
					timer16.Enabled = true;

					button6.Enabled = true;
					button6.Focus();
                }
                else
                {
					label4.Text = "00:00";
					label13.Text = "<<Гонка!>>";
					label15.Text = "2/5";
					timer32.Enabled = true;
					timer17.Enabled = true;
					timer11.Enabled = true;
					timer15.Enabled = true;
					timer16.Enabled = true;

					button6.Enabled = true;
					button6.Focus();
				}
			}
		}



		private void timer4_Tick(object sender, EventArgs e)
		{


			sec--;
			label4.Text = Convert.ToString(min) + ":" + Convert.ToString(sec);               //зчитую час гонки який був заданий у настройках





			if (sec == 0)                                                                       //таймер для гонки 2 заїзд
			{
				min--;
				sec = 60;

				if (min == -1 && sec == 60)
				{
					perehid.Play();
					serialPort1.WriteLine("3");//пауза
					label69.Text = "Трек виключений";
					label69.BackColor = Color.Red;
					button10.Enabled = true;
					button11.Enabled = false;
					timer4.Enabled = false;
					label4.Text = "00:00";
					secs = Convert.ToInt32(textBox14.Text);
					mins = 0;
					timer5.Enabled = true;
					label13.Text = "<<Перехід!>>";

					button6.Enabled = false;


					//перехід між доріжками
					if (label72.Visible == false)
					{

						timer32.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;


						//

						lanes3 = Convert.ToInt32(label23.Text) - lanes1;
						lane2_1 = Convert.ToInt32(label17.Text) - lane2_2;
						lane3_4 = Convert.ToInt32(label25.Text) - lane3_3;
						lane4_2 = Convert.ToInt32(label24.Text) - lane4_4;


						textBox16.Text = label45.Text;
						label50.Text = label17.Text;
						label66.Text = label21.Text;
						label125.Text = label8.Text;
						label131.Text = label54.Text;

						textBox17.Text = label46.Text;
						label51.Text = label24.Text;
						label63.Text = label27.Text;
						label126.Text = label56.Text;
						label132.Text = label57.Text;

						textBox18.Text = label47.Text;
						label52.Text = label23.Text;
						label64.Text = label26.Text;
						label127.Text = label117.Text;
						label133.Text = label58.Text;

						textBox19.Text = label48.Text;
						label53.Text = label25.Text;
						label65.Text = label28.Text;
						label128.Text = label119.Text;
						label134.Text = label118.Text;




						label45.Text = textBox17.Text;
						label17.Text = label51.Text;
						label21.Text = label63.Text;
						label8.Text = label126.Text;
						label54.Text = label132.Text;

						label46.Text = textBox19.Text;
						label24.Text = label53.Text;
						label27.Text = label65.Text;
						label56.Text = label128.Text;
						label57.Text = label134.Text;

						label47.Text = textBox16.Text;
						label23.Text = label50.Text;
						label26.Text = label66.Text;
						label117.Text = label125.Text;
						label58.Text = label131.Text;

						label48.Text = textBox18.Text;
						label25.Text = label52.Text;
						label28.Text = label64.Text;
						label119.Text = label127.Text;
						label118.Text = label133.Text;

						label18.Text = "00,000";
						label22.Text = "00,000";
						label19.Text = "00,000";
						label20.Text = "00,000";
						label16.Text = "999";
						label29.Text = "00,000";
						label30.Text = "00,000";
						label31.Text = "00,000";
						label32.Text = "00,000";
						label42.Text = "999";
						label35.Text = "00,000";
						label36.Text = "00,000";
						label37.Text = "00,000";
						label34.Text = "00,000";
						label43.Text = "999";
						label38.Text = "00,000";
						label39.Text = "00,000";
						label40.Text = "00,000";
						label41.Text = "00,000";
						label44.Text = "999";


                    }
                    else
                    {
						string value1, value2, value3, value4, value5; // перемінні для кіл

						string lane1, lane2, lane3, lane4, lane5; // перемінні для імя


						//перехід між доріжками
						timer32.Enabled = false;

						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;


						lanes3 = Convert.ToInt32(label23.Text) - lanes1;
						lane2_5 = Convert.ToInt32(label75.Text) - lane2_2;
						lane3_4 = Convert.ToInt32(label25.Text) - lane3_3;
						lane4_2 = Convert.ToInt32(label24.Text) - lane4_4;
						lane5_1 = Convert.ToInt32(label17.Text) - lane5_5;




						lane1 = label47.Text;
						lane2 = label72.Text;
						lane3 = label48.Text;
						lane4 = label46.Text;
						lane5 = label45.Text;

						label48.Text = lane1;
						label45.Text = lane2;
						label46.Text = lane3;
						label72.Text = lane4;
						label47.Text = lane5;




						value1 = label23.Text;
						value2 = label75.Text;
						value3 = label25.Text;
						value4 = label24.Text;
						value5 = label17.Text;

						label25.Text = value1;
						label17.Text = value2;
						label24.Text = value3;
						label75.Text = value4;
						label23.Text = value5;






						label18.Text = "00,000";
						label22.Text = "00,000";
						label19.Text = "00,000";
						label20.Text = "00,000";
						label16.Text = "999";
						label29.Text = "00,000";
						label30.Text = "00,000";
						label31.Text = "00,000";
						label32.Text = "00,000";
						label42.Text = "999";
						label35.Text = "00,000";
						label36.Text = "00,000";
						label37.Text = "00,000";
						label34.Text = "00,000";
						label43.Text = "999";
						label38.Text = "00,000";
						label39.Text = "00,000";
						label40.Text = "00,000";
						label41.Text = "00,000";
						label44.Text = "999";





					}


					//сортування результату
					dataGridView3.Rows.Add(label17.Text + "," + 6);
					dataGridView3.Rows.Add(label24.Text + "," + 5);
					dataGridView3.Rows.Add(label23.Text + "," + 4);
					dataGridView3.Rows.Add(label25.Text + "," + 3);

					dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);






					//червона

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
					{
						panel1.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(7, 645);
								}

							}
						}

					}



					// зелена

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
					{
						panel3.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(7, 645);
								}

							}
						}

					}

					// синя

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
					{
						panel4.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(7, 645);
								}

							}
						}

					}

					//жовта 



					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
					{
						panel5.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(7, 645);
								}


							}
						}

					}


					timer26.Enabled = true;

					number_group.Text = "2";

				}
			}
		}



		private void timer5_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

			button6.Enabled = false;


			if (label4.Text == "0:3")
			{
				timetostartsound.Play();
			}

			if (label4.Text == "0:16")//залишилось 15 секунд
			{
				sekynd.Play();
			}


			if (secs > 60)
			{
				mins++;
				secs = secs - 60;

			}
			if (secs == -1)
			{

				mins--;
				secs = 60;
			}

			if (secs == 60 && mins == -1)
			{
				serialPort1.Open();
				serialPort1.WriteLine("4"); //продовжити 
				label69.Text = "Трек включений";
				label69.BackColor = Color.Green;
				button10.Enabled = false;
				button11.Enabled = true;
				timer5.Enabled = false;
				timer6.Enabled = true;

				if (label72.Visible == false)
				{
					Time = Convert.ToDouble(label63.Text);
					Timeg = Convert.ToDouble(label64.Text);
					Timez = Convert.ToDouble(label65.Text);
					Times = Convert.ToDouble(label66.Text);
				}
				else
				{
					Time = Timeb;
					Timeg = Convert.ToDouble(label26.Text);
					Timez = Convert.ToDouble(label28.Text);
					Times = Convert.ToDouble(label21.Text);
					Timeb = Convert.ToDouble(label27.Text);
				}


				sec = 1;


				if (textBox25.Text == "")
				{
					min = Convert.ToInt32(textBox13.Text);
				}
				else
				{
					min = Convert.ToInt32(textBox24.Text);
				}

				//для простою
				if (label72.Visible == false)
				{
					label4.Text = "00:00";
					label13.Text = "<<Гонка!>>";
					label15.Text = "3/4";
					timer32.Enabled = true;
					timer17.Enabled = true;
					timer11.Enabled = true;
					timer15.Enabled = true;
					timer16.Enabled = true;

					button6.Enabled = true;
					button6.Focus();
                }
                else
                {
					label4.Text = "00:00";
					label13.Text = "<<Гонка!>>";
					label15.Text = "3/5";
					timer32.Enabled = true;
					timer17.Enabled = true;
					timer11.Enabled = true;
					timer15.Enabled = true;
					timer16.Enabled = true;

					button6.Enabled = true;
					button6.Focus();
				}
			}

		}

		private void Form3_Load(object sender, EventArgs e)
		{

			if (label17.Location.X < 661)
			{
				//label45.Font = new Font(label45.Font.Name, 20, label45.Font.Style);
				label45.MaximumSize = new Size(300, 63);
				label46.MaximumSize = new Size(300, 63);
				label47.MaximumSize = new Size(300, 63);
				label48.MaximumSize = new Size(300, 63);
				dataGridView4.Location = new Point(864, 3);
				button22.Location = new Point(1650, 901);
			}

			else
			{
				//label45.Font = new Font(label45.Font.Name, 42, label45.Font.Style);
			}





			timetostartsound.SoundLocation = "music/81980c1a7dcb7cd.wav";
			timetostartsound.Load();

			sekynd.SoundLocation = "music/15secynd.wav";
			sekynd.Load();
			perehid.SoundLocation = "music/perehid.wav";
			perehid.Load();
			pausesound.SoundLocation = "music/noty-do.wav";
			pausesound.Load();
			startsound.SoundLocation = "music/re.wav";
			startsound.Load();
			kinetsgonkisound.SoundLocation = "music/aplodismenty_s_krikami_bravo.wav";
			best_time.SoundLocation = "music/00508.wav";
			best_time.Load();

			start_to_pause.SoundLocation = "music/start_to_stop.wav";
			start_to_pause.Load();

			String[] strPortName = SerialPort.GetPortNames();
			foreach (string n in strPortName)
			{
				comboBox1.Items.Add(n);
			}
			comboBox1.SelectedIndex = 0;


		}





		private void timer6_Tick(object sender, EventArgs e)
		{


			sec--;
			label4.Text = Convert.ToString(min) + ":" + Convert.ToString(sec);           //зчитую час гонки який був заданий у настройках





			if (sec == 0)                                                                   //таймер для гонки 3 заїзд
			{
				min--;
				sec = 60;

				if (min == -1 && sec == 60)
				{
					perehid.Play();
					serialPort1.WriteLine("3");//пауза
					label69.Text = "Трек виключений";
					label69.BackColor = Color.Red;
					button10.Enabled = true;
					button11.Enabled = false;
					timer6.Enabled = false;
					label4.Text = "00:00";
					secs = Convert.ToInt32(textBox14.Text);
					mins = 0;
					timer7.Enabled = true;
					label13.Text = "<<Перехід!>>";
					button6.Enabled = false;



					//перехід між доріжками



					if (label72.Visible == false)
					{
						timer32.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;




						//

						lanes4 = Convert.ToInt32(label25.Text) - lanes1 - lanes3;
						lane2_3 = Convert.ToInt32(label23.Text) - lane2_1 - lane2_2;
						lane3_2 = Convert.ToInt32(label24.Text) - lane3_3 - lane3_4;
						lane4_1 = Convert.ToInt32(label17.Text) - lane4_4 - lane4_2;









						textBox16.Text = label45.Text;
						label50.Text = label17.Text;
						label66.Text = label21.Text;
						label125.Text = label8.Text;
						label131.Text = label54.Text;

						textBox17.Text = label46.Text;
						label51.Text = label24.Text;
						label63.Text = label27.Text;
						label126.Text = label56.Text;
						label132.Text = label57.Text;

						textBox18.Text = label47.Text;
						label52.Text = label23.Text;
						label64.Text = label26.Text;
						label127.Text = label117.Text;
						label133.Text = label58.Text;

						textBox19.Text = label48.Text;
						label53.Text = label25.Text;
						label65.Text = label28.Text;
						label128.Text = label119.Text;
						label134.Text = label118.Text;




						label45.Text = textBox17.Text;
						label17.Text = label51.Text;
						label21.Text = label63.Text;
						label8.Text = label126.Text;
						label54.Text = label132.Text;

						label46.Text = textBox19.Text;
						label24.Text = label53.Text;
						label27.Text = label65.Text;
						label56.Text = label128.Text;
						label57.Text = label134.Text;

						label47.Text = textBox16.Text;
						label23.Text = label50.Text;
						label26.Text = label66.Text;
						label117.Text = label125.Text;
						label58.Text = label131.Text;

						label48.Text = textBox18.Text;
						label25.Text = label52.Text;
						label28.Text = label64.Text;
						label119.Text = label127.Text;
						label118.Text = label133.Text;

						label18.Text = "00,000";
						label22.Text = "00,000";
						label19.Text = "00,000";
						label20.Text = "00,000";
						label16.Text = "999";
						label29.Text = "00,000";
						label30.Text = "00,000";
						label31.Text = "00,000";
						label32.Text = "00,000";
						label42.Text = "999";
						label35.Text = "00,000";
						label36.Text = "00,000";
						label37.Text = "00,000";
						label34.Text = "00,000";
						label43.Text = "999";
						label38.Text = "00,000";
						label39.Text = "00,000";
						label40.Text = "00,000";
						label41.Text = "00,000";
						label44.Text = "999";

                    }
                    else
                    {



						string value1, value2, value3, value4, value5; // перемінні для кіл

						string lane1, lane2, lane3, lane4, lane5; // перемінні для імя

						

						//перехід між доріжками
						timer32.Enabled = false;

						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;


						//

						lanes4 = Convert.ToInt32(label25.Text) - lanes1 - lanes3;
						lane2_1 = Convert.ToInt32(label17.Text) - lane2_2 - lane2_5;
						lane3_2 = Convert.ToInt32(label24.Text) - lane3_3 - lane3_4;
						lane4_5 = Convert.ToInt32(label75.Text) - lane4_4 - lane4_2;
						lane5_3 = Convert.ToInt32(label23.Text) -lane5_5 - lane5_1;

						lane1 = label48.Text;
						lane2 = label45.Text;
						lane3 = label46.Text;
						lane4 = label72.Text;
						lane5 = label47.Text;

						label46.Text = lane1;
						label47.Text = lane2;
						label72.Text = lane3;
						label45.Text = lane4;
						label48.Text = lane5;





						value1 = label25.Text;
						value2 = label17.Text;
						value3 = label24.Text;
						value4 = label75.Text;
						value5 = label23.Text;

						label24.Text = value1;
						label23.Text = value2;
						label75.Text = value3;
						label17.Text = value4;
						label25.Text = value5;






						label18.Text = "00,000";
						label22.Text = "00,000";
						label19.Text = "00,000";
						label20.Text = "00,000";
						label16.Text = "999";
						label29.Text = "00,000";
						label30.Text = "00,000";
						label31.Text = "00,000";
						label32.Text = "00,000";
						label42.Text = "999";
						label35.Text = "00,000";
						label36.Text = "00,000";
						label37.Text = "00,000";
						label34.Text = "00,000";
						label43.Text = "999";
						label38.Text = "00,000";
						label39.Text = "00,000";
						label40.Text = "00,000";
						label41.Text = "00,000";
						label44.Text = "999";





					}

					//сортування результату
					dataGridView3.Rows.Add(label17.Text + "," + 6);
					dataGridView3.Rows.Add(label24.Text + "," + 5);
					dataGridView3.Rows.Add(label23.Text + "," + 4);
					dataGridView3.Rows.Add(label25.Text + "," + 3);

					dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);






					//червона

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
					{
						panel1.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(7, 645);
								}

							}
						}

					}



					// зелена

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
					{
						panel3.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(7, 645);
								}

							}
						}

					}

					// синя

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
					{
						panel4.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(7, 645);
								}

							}
						}

					}

					//жовта 



					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
					{
						panel5.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(7, 502);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(7, 645);
								}


							}
						}

					}


					timer26.Enabled = true;


					number_group.Text = "3";

				}

			}

		}

		private void timer17_Tick(object sender, EventArgs e)
		{


			Timez += 0.0003 * 53;                   //timer на час кола зелена доріжка
			label27.Text = string.Format("{0:F3}", Timez);       //timer на час кола зелена доріжка

		}

		private void timer16_Tick(object sender, EventArgs e)
		{

			Timeg += 0.0003 * 53;                //timer на час кола жовта доріжка
			label28.Text = string.Format("{0:F3}", Timeg);       //timer на час кола жовта доріжка

		}

		private void timer18_Tick(object sender, EventArgs e)
		{

		}

		private void timer19_Tick(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{


		}

		private void button4_Click(object sender, EventArgs e)
		{
			comboBox1.Text = Settings.Default.zase4ka_comPort;
			int n = ExportExcel();



			listBox1.Items.Clear();
			string s;
			for (int i = 0; i < n; i++) // по всем строкам
			{
				s = "";
				for (int j = 1; j < 2;  j++) //по всем колонкам
					s += list[i, j];
				listBox1.Items.Add(s);
				
			}


			button4.Visible = false;

			


			if (button4.Visible == false)
			{

				button2.Visible = true;
				comboBox1.Visible = true;
				label49.Visible = true;


			}
		}
		// Импорт данных из Excel-файла (не более 5 столбцов и любое количество строк <= 50.
		private int ExportExcel()
		{

			// Выбрать путь и имя файла в диалоговом окне
			OpenFileDialog ofd = new OpenFileDialog();
			// Задаем расширение имени файла по умолчанию (открывается папка с программой)
			ofd.DefaultExt = "*.xls;*.xlsx";
			// Задаем строку фильтра имен файлов, которая определяет варианты
			ofd.Filter = "файл Excel (Spisok.xlsx)|*.xlsx";
			// Задаем заголовок диалогового окна
			ofd.Title = "Виберіть файл Lap-Time";
			if (!(ofd.ShowDialog() == DialogResult.OK)) // если файл БД не выбран -> Выход
				return 0;
			Excel.Application ObjWorkExcel = new Excel.Application();
			Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(ofd.FileName);
			Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1-й лист
			var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
																								// размеры базы
			int lastColumn = (int)lastCell.Column;
			int lastRow = (int)lastCell.Row;
			// Перенос в промежуточный массив класса Form1: string[,] list = new string[50, 5]; 
			for (int j = 0; j < 5; j++) //по всем колонкам
				for (int i = 0; i < lastRow; i++) // по всем строкам
					list[i, j] = ObjWorkSheet.Cells[i + 1, j + 1].Text.ToString(); //считываем данные
			ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
			ObjWorkExcel.Quit(); // выйти из Excel
			GC.Collect(); // убрать за собой
			return lastRow;



		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			label49.Visible = true;
			comboBox1.Visible = true;
			button5.Visible = true;
			button4.Visible = false;
	
			label88.Visible = true;
			label89.Visible = true;
			textBox26.Visible = true;
			textBox27.Visible = true;
			button20.Visible = true;
			label11.Visible = true;
			textBox28.Visible = true;



		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (label13.Text != "<<Вільні тренування!>>")
			{


				label13.Visible = true;
				label13.Text = "Тренування!";
				//serialPort1.BaudRate = 9600;
				serialPort1.PortName = comboBox1.Text;
				button5.Visible = false;
				comboBox1.Visible = false;
				label49.Visible = false;
				serialPort1.Open();
				serialPort1.WriteLine("3");
				serialPort1.Close();
				Settings.Default.zase4ka_comPort = comboBox1.Text;
				Settings.Default.Save();


				// переміщення інтерфейсу під тренування
				label17.Location = new Point(92, -13);
				//textBox1.Size = new Size(301, 151);
				label24.Location = new Point(92, -5);
				//textBox6.Size = new Size(301, 151);
				label23.Location = new Point(92, -5);
				//textBox9.Size = new Size(301, 151);
				label25.Location = new Point(92, 1);
				//textBox12.Size = new Size(301, 151);
				label17.Location = new Point(88, -10);
				label24.Location = new Point(88, -6);
				label23.Location = new Point(88, -6);
				label25.Location = new Point(88, -10);
				textBox2.Location = new Point(431, 12);
				textBox2.Size = new Size(1083, 104);
				textBox5.Location = new Point(431, 12);
				textBox5.Size = new Size(1083, 104);
				textBox8.Location = new Point(431, 12);
				textBox8.Size = new Size(1083, 104);
				textBox11.Location = new Point(431, 12);
				textBox11.Size = new Size(1083, 104);
				label7.Text = "Круги";
				label5.Visible = false;
				label9.Location = new Point(878, 8);
				label22.Location = new Point(431, 34);
				label19.Location = new Point(610, 34);
				label20.Location = new Point(803, 37);
				label76.Visible = true;
				label77.Visible = true;
				label78.Visible = true;
				label30.Location = new Point(431, 33);
				label32.Location = new Point(610, 33);
				label31.Location = new Point(803, 36);
				label79.Visible = true;
				label80.Visible = true;
				label81.Visible = true;
				label34.Location = new Point(431, 35);
				label36.Location = new Point(610, 35);
				label35.Location = new Point(803, 38);
				label82.Visible = true;
				label83.Visible = true;
				label84.Visible = true;
				label39.Location = new Point(431, 34);
				label41.Location = new Point(610, 34);
				label40.Location = new Point(803, 37);
				label87.Visible = true;
				label86.Visible = true;
				label85.Visible = true;
				button17.Visible = true;
				timer18.Enabled = false;
				

				label55.Visible = false;
				label59.Visible = false;
				label60.Visible = false;
				label61.Visible = false;
				label62.Visible = false;
				label124.Visible = false;
				label54.Visible = false;
				label57.Visible = false;
				label58.Visible = false;
				label118.Visible = false;

            }
            else
            {
				
	
				serialPort1.PortName = comboBox1.Text;
				button5.Visible = false;
				comboBox1.Visible = false;
				label49.Visible = false;
				serialPort1.Open();
				serialPort1.WriteLine("3");
				serialPort1.Close();
				Settings.Default.zase4ka_comPort = comboBox1.Text;
				Settings.Default.Save();
				button17.Visible = true;
			}



		}

		private void timer18_Tick_1(object sender, EventArgs e)
		{



			if (textBox20.Text == "" || textBox21.Text == "" || textBox22.Text == "" || textBox23.Text == "")
			{
				button9.Enabled = false;
			}
			else
			{
				button9.Enabled = true;
			}


			switch (Convert.ToInt32(label67.Text))
			{
				case 37:
					{
						label71.Text = "Група - << J >>";
						break;
					}

				case 33:
					{
						label71.Text = "Група - << I >>";
						break;
					}
				case 29:
					{
						label71.Text = "Група - << H >>";
						break;
					}
				case 25:
					{
						label71.Text = "Група - << G >>";
						break;
					}
				case 21:
					{
						label71.Text = "Група - << F >>";
						break;
					}
				case 17:
					{
						label71.Text = "Група - << E >>";
						break;
					}
				case 13:
					{
						label71.Text = "Група - << D >>";
						break;
					}
				case 9:
					{
						label71.Text = "Група - << C >>";
						break;
					}
				case 5:
					{
						label71.Text = "Група - << B >>";
						break;
					}
				case 1:
					{
						label71.Text = "Група - << A >>";
						break;
					}
				case 228:
					{
						label71.Text = "<< Фінал! >>";
						break;
					}
				case 229:
                    {
						label72.Visible = false;
						label74.Visible = false;
						label75.Visible = false;
						label90.Visible = false;
						break;
                    }
				default:
					{

						//простой
						if (Convert.ToInt32(label67.Text) != 0)
						{
							label67.Text = "229";

							DialogResult dialog = MessageBox.Show(
					 "Бажаєте загрузити простій?",
					 "Групи не повні!",
					 MessageBoxButtons.YesNo,
					 MessageBoxIcon.Warning);

							if (dialog == DialogResult.Yes)
							{

								int collum_back_color = 0;
								

								int number_raiser = 1;
								for (int a = 1; listBox1.Items.Count > a; a++)
								{

									dataGridView4.Rows.Add(number_raiser, listBox1.Items[a]);
									number_raiser = number_raiser + 1;



									
									

								}
								

								for(int i = 0; i < listBox1.Items.Count; i++)
                                {

									if (collum_back_color <= 3)
									{
										dataGridView4.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
										collum_back_color = collum_back_color + 1;


									}
									else
									{
										if (collum_back_color >= 3 && collum_back_color <= 7)
										{
											dataGridView4.Rows[i].DefaultCellStyle.BackColor = Color.Red;
											collum_back_color = collum_back_color + 1;

										}
										else
										{
											dataGridView4.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
											collum_back_color = 1;
										}



									}
								}








								dataGridView4.Visible = true;
								button22.Visible = true;



								if (label17.Location.X < 676)
									
									
									{


									dataGridView4.Size = new Size(371, 421);

								}
                                else
                                {
									dataGridView4.Size = new Size(371, 421);
									dataGridView4.Location = new Point(1145, 624);
                                }
								
								button1.Visible = false;



							}
							else
							{
								label72.Visible = false;
								break;
							}

							
						}
						break;
					}
			}






			//алгоритм сортування відставання до суперника




			label55.Visible = true;
			label59.Visible = true;
			label60.Visible = true;
			label61.Visible = true;
			label62.Visible = true;

			if (panel1.Location == new Point(7, 213))
			{


				int label17l, label23l, label24l, label25l;

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label23.Text);

				label59.Text = "0";

				label23l = Convert.ToInt32(label23.Text) - Convert.ToInt32(label17.Text);

				label61.Text = Convert.ToString(label23l);

				label24l = Convert.ToInt32(label24.Text) - Convert.ToInt32(label17.Text);

				label60.Text = Convert.ToString(label24l);

				label25l = Convert.ToInt32(label25.Text) - Convert.ToInt32(label17.Text);

				label62.Text = Convert.ToString(label25l);


			}

			if (panel3.Location == new Point(7, 213))
			{


				int label17l, label23l, label25l;

				label60.Text = "0";

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label24.Text);

				label59.Text = Convert.ToString(label17l);

				label23l = Convert.ToInt32(label23.Text) - Convert.ToInt32(label24.Text);

				label61.Text = Convert.ToString(label23l);

				label25l = Convert.ToInt32(label25.Text) - Convert.ToInt32(label24.Text);

				label62.Text = Convert.ToString(label25l);


			}

			if (panel4.Location == new Point(7, 213))
			{


				int label17l, label24l, label25l;

				label61.Text = "0";

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label23.Text);

				label59.Text = Convert.ToString(label17l);

				label24l = Convert.ToInt32(label24.Text) - Convert.ToInt32(label23.Text);

				label60.Text = Convert.ToString(label24l);

				label25l = Convert.ToInt32(label25.Text) - Convert.ToInt32(label23.Text);

				label62.Text = Convert.ToString(label25l);


			}

			if (panel5.Location == new Point(7, 213))
			{


				int label17l, label23l, label24l;

				label62.Text = "0";

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label25.Text);

				label59.Text = Convert.ToString(label17l);

				label24l = Convert.ToInt32(label24.Text) - Convert.ToInt32(label25.Text);

				label60.Text = Convert.ToString(label24l);

				label23l = Convert.ToInt32(label23.Text) - Convert.ToInt32(label25.Text);

				label61.Text = Convert.ToString(label23l);

			}
			//		}

			//		//алгоритм сортування жовтої доріжки по місцям

			//		if (Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text))

			//		{
			//			if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
			//			{
			//				panel5.Location = new Point(7, 213);

			//			}
			//			else
			//			{
			//				if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text))
			//				{
			//					panel5.Location = new Point(7, 358);
			//				}
			//				else
			//				{
			//					if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
			//					{
			//						panel5.Location = new Point(7, 358);
			//					}
			//					else
			//					{
			//						if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
			//						{
			//							panel5.Location = new Point(7, 358);
			//						}
			//						else
			//						{




			//							if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text))
			//							{
			//								panel5.Location = new Point(7, 502);
			//							}
			//							else
			//							{
			//								if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text))
			//								{
			//									panel5.Location = new Point(7, 502);
			//								}
			//								else
			//								{
			//									if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
			//									{
			//										panel5.Location = new Point(7, 502);
			//									}
			//									else
			//									{

			//										if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
			//										{
			//											panel5.Location = new Point(7, 645);
			//										}
			//										else
			//										{
			//											if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text))
			//											{
			//												panel5.Location = new Point(7, 502);
			//											}
			//											else
			//											{
			//												if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
			//												{
			//													panel5.Location = new Point(7, 502);
			//												}
			//												else
			//												{
			//													if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
			//													{
			//														panel5.Location = new Point(7, 502);
			//													}
			//													else
			//													{
			//														if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text))
			//														{
			//															panel5.Location = new Point(7, 358);

			//														}
			//														else
			//														{
			//															if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text))
			//															{
			//																panel5.Location = new Point(7, 358);
			//															}
			//															else
			//															{
			//																if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
			//																{
			//																	panel5.Location = new Point(7, 358);
			//																}
			//															}
			//														}

			//													}

			//												}

			//											}

			//										}
			//									}
			//								}
			//							}
			//						}

			//					}
			//				}
			//			}
			//		}


			//		//алгоритм сортування синьої доріжки по місцям
			//		if (Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text))
			//		{
			//			if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
			//			{
			//				panel4.Location = new Point(7, 213);
			//			}
			//			else
			//			{
			//				if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text))
			//				{
			//					panel4.Location = new Point(7, 358);
			//				}
			//				else
			//				{
			//					if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
			//					{
			//						panel4.Location = new Point(7, 358);
			//					}
			//					else
			//					{
			//						if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
			//						{
			//							panel4.Location = new Point(7, 358);
			//						}
			//						else
			//						{

			//							if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text))
			//							{
			//								panel4.Location = new Point(7, 502);
			//							}
			//							else
			//							{
			//								if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text))
			//								{
			//									panel4.Location = new Point(7, 502);
			//								}
			//								else
			//								{
			//									if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
			//									{
			//										panel4.Location = new Point(7, 502);
			//									}
			//									else
			//									{


			//										if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
			//										{
			//											panel4.Location = new Point(7, 645);

			//										}
			//										else
			//										{
			//											if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text))
			//											{
			//												panel4.Location = new Point(7, 502);
			//											}
			//											else
			//											{
			//												if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
			//												{
			//													panel4.Location = new Point(7, 502);
			//												}
			//												else
			//												{
			//													if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
			//													{
			//														panel4.Location = new Point(7, 502);
			//													}
			//													else
			//													{
			//														if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text))
			//														{
			//															panel4.Location = new Point(7, 358);
			//														}
			//														else
			//														{
			//															if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
			//															{
			//																panel4.Location = new Point(7, 358);
			//															}
			//															else
			//															{
			//																if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text))
			//																{
			//																	panel4.Location = new Point(7, 358);
			//																}
			//															}
			//														}
			//													}
			//												}
			//											}

			//										}
			//									}
			//								}
			//							}

			//						}
			//					}
			//				}
			//			}
			//		}

			//		//алгоритм сортування зеленої доріжки по місцям
			//		if (Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text))
			//		{
			//			if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label17.Text))
			//			{
			//				panel3.Location = new Point(7, 213);
			//			}
			//			else
			//			{
			//				if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label23.Text))
			//				{
			//					panel3.Location = new Point(7, 358);
			//				}
			//				else
			//				{
			//					if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label17.Text))
			//					{
			//						panel3.Location = new Point(7, 358);
			//					}
			//					else
			//					{
			//						if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label17.Text))
			//						{
			//							panel3.Location = new Point(7, 358);
			//						}
			//						else
			//						{


			//							if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text))
			//							{
			//								panel3.Location = new Point(7, 502);


			//							}
			//							else
			//							{
			//								if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
			//								{
			//									panel3.Location = new Point(7, 645);
			//								}
			//								else
			//								{
			//									if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text))
			//									{
			//										panel3.Location = new Point(7, 502);
			//									}
			//									else
			//									{
			//										if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
			//										{
			//											panel3.Location = new Point(7, 502);
			//										}
			//										else
			//										{
			//											if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
			//											{
			//												panel3.Location = new Point(7, 502);
			//											}
			//											else
			//											{
			//												if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text))
			//												{
			//													panel3.Location = new Point(7, 358);
			//												}
			//												else
			//												{
			//													if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
			//													{
			//														panel3.Location = new Point(7, 358);
			//													}
			//													else
			//													{
			//														if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text))
			//														{
			//															panel3.Location = new Point(7, 358);
			//														}
			//													}
			//												}
			//											}




			//										}
			//									}
			//								}
			//							}
			//						}
			//					}

			//				}
			//			}
			//		}

			//		//алгоритм сортування червоної доріжки по місцям
			//		if (Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text))
			//		{
			//			if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
			//			{
			//				panel1.Location = new Point(7, 213);
			//			}
			//			else
			//			{
			//				if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text))
			//				{
			//					panel1.Location = new Point(7, 358);
			//				}
			//				else
			//				{
			//					if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
			//					{
			//						panel1.Location = new Point(7, 358);
			//					}
			//					else
			//					{
			//						if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
			//						{
			//							panel1.Location = new Point(7, 358);
			//						}
			//						else
			//						{


			//							if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text))
			//							{
			//								panel1.Location = new Point(7, 502);
			//							}
			//							else
			//							{
			//								if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
			//								{
			//									panel1.Location = new Point(7, 502);
			//								}
			//								else
			//								{
			//									if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text))
			//									{
			//										panel1.Location = new Point(7, 502);
			//									}
			//									else
			//									{



			//										if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
			//										{
			//											panel1.Location = new Point(7, 645);
			//										}
			//										else
			//										{
			//											if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text))
			//											{
			//												panel1.Location = new Point(7, 502);
			//											}
			//											else
			//											{
			//												if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
			//												{
			//													panel1.Location = new Point(7, 502);
			//												}
			//												else
			//												{
			//													if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
			//													{
			//														panel1.Location = new Point(7, 502);
			//													}
			//													else
			//													{
			//														if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text))
			//														{
			//															panel1.Location = new Point(7, 358);
			//														}
			//														else
			//														{
			//															if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text))
			//															{
			//																panel1.Location = new Point(7, 358);
			//															}
			//															else
			//															{
			//																if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
			//																{
			//																	panel1.Location = new Point(7, 358);
			//																}
			//															}
			//														}

			//													}

			//												}
			//											}
			//										}
			//									}
			//								}
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void timer19_Tick_1(object sender, EventArgs e)
		{
			if (serialPort1.IsOpen == true && timer3.Enabled == true || timer5.Enabled == true || timer7.Enabled == true)
			{
				serialPort1.Close();
			}

			if (panel1.BackColor == Color.Black)
			{
				label45.ForeColor = Color.White;
				label59.ForeColor = Color.White;
			}
			else
			{
				label45.ForeColor = Color.Black;
				label59.ForeColor = Color.Black;
			}


			if (panel3.BackColor == Color.Black)
			{
				label46.ForeColor = Color.White;
				label60.ForeColor = Color.White;
			}
			else
			{
				label46.ForeColor = Color.Black;
				label60.ForeColor = Color.Black;
			}

			if (panel4.BackColor == Color.Black)
			{
				label47.ForeColor = Color.White;
				label61.ForeColor = Color.White;
			}
			else
			{
				label47.ForeColor = Color.Black;
				label61.ForeColor = Color.Black;
			}

			if (panel5.BackColor == Color.Black)
			{
				label48.ForeColor = Color.White;
				label62.ForeColor = Color.White;
			}
			else
			{
				label48.ForeColor = Color.Black;
				label62.ForeColor = Color.Black;
			}


			//if (label22.Text == "00,000" || label19.Text == "00,000" || label20.Text == "00,000")
			//         {
			//	label72.Text = "-";
			//         }
			//         else
			//         {



			//	switch (Convert.ToInt32(textBox13.Text))  // прогноз червона доріжка
			//	{
			//		case 1:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 60;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);



			//			}
			//			break;
			//		case 2:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 120;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;

			//		case 3:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 180;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;
			//		case 4:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 240;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;
			//		case 5:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 300;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;
			//		case 6:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 360;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;
			//		case 7:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 420;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;
			//		case 8:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 480;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;
			//		case 9:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 540;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;
			//		case 10:
			//			{
			//				double red_result;
			//				int timetoprognoz, prognozRed;

			//				timetoprognoz = 600;

			//				red_result = Convert.ToDouble(label22.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text);


			//				prognozRed = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(red_result);


			//				label72.Text = Convert.ToString(prognozRed);
			//			}
			//			break;
			//		default:
			//			{
			//				label72.Text = "-";
			//				label73.Text = "-";
			//				label74.Text = "-";
			//				label75.Text = "-";

			//			}
			//			break;



			//	}

			//	}


			//	if (label30.Text == "00,000" || label32.Text == "00,000" || label31.Text == "00,000")   // Прогноз зелена доріжка
			//	{
			//		label73.Text = "-";
			//	}
			//	else
			//	{



			//		switch (Convert.ToInt32(textBox13.Text))
			//		{
			//			case 1:
			//				{
			//					double  Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 60;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);




			//				}
			//				break;
			//			case 2:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 120;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;

			//			case 3:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 180;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;
			//			case 4:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 240;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;
			//			case 5:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 300;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;
			//			case 6:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 360;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;
			//			case 7:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 420;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;
			//			case 8:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 480;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;
			//			case 9:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 540;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;
			//			case 10:
			//				{
			//					double Grean_result;
			//					int timetoprognoz, prognozGrean;

			//					timetoprognoz = 600;


			//					Grean_result = Convert.ToDouble(label30.Text) + Convert.ToDouble(label32.Text) + Convert.ToDouble(label31.Text);

			//					prognozGrean = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Grean_result);



			//					label73.Text = Convert.ToString(prognozGrean);
			//				}
			//				break;
			//			default:
			//				{
			//					label72.Text = "-";
			//					label73.Text = "-";
			//					label74.Text = "-";
			//					label75.Text = "-";

			//				}
			//				break;





			//		}



			//	}

			//	if (label34.Text == "00,000" || label36.Text == "00,000" || label35.Text == "00,000")
			//	{
			//		label74.Text = "-";
			//	}
			//	else
			//	{



			//		switch (Convert.ToInt32(textBox13.Text))  // прогноз синя доріжка
			//		{
			//			case 1:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 60;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);




			//				}
			//				break;
			//			case 2:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 120;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;

			//			case 3:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 180;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;
			//			case 4:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 240;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;
			//			case 5:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 300;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;
			//			case 6:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 360;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;
			//			case 7:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 420;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;
			//			case 8:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 480;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;
			//			case 9:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 540;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;
			//			case 10:
			//				{
			//					double blue_result;
			//					int timetoprognoz, prognozBlue;

			//					timetoprognoz = 600;


			//					blue_result = Convert.ToDouble(label34.Text) + Convert.ToDouble(label36.Text) + Convert.ToDouble(label35.Text);

			//					prognozBlue = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(blue_result);

			//					label74.Text = Convert.ToString(prognozBlue);

			//				}
			//				break;
			//			default:
			//				{
			//					label72.Text = "-";
			//					label73.Text = "-";
			//					label74.Text = "-";
			//					label75.Text = "-";

			//				}
			//				break;





			//		}
			//	}
			//	if (label39.Text == "00,000" || label41.Text == "00,000" || label40.Text == "00,000")
			//	{
			//		label75.Text = "-";
			//	}
			//	else
			//	{



			//		switch (Convert.ToInt32(textBox13.Text))  // прогноз жовта доріжка
			//		{
			//			case 1:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 60;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);



			//				}
			//				break;
			//			case 2:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz,prognozYelow;

			//					timetoprognoz = 120;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;

			//			case 3:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 180;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;
			//			case 4:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 240;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;
			//			case 5:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 300;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;
			//			case 6:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 360;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;
			//			case 7:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 420;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;
			//			case 8:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 480;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;
			//			case 9:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 540;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;
			//			case 10:
			//				{
			//					double Yelow_result;
			//					int timetoprognoz, prognozYelow;

			//					timetoprognoz = 600;


			//					Yelow_result = Convert.ToDouble(label39.Text) + Convert.ToDouble(label41.Text) + Convert.ToDouble(label40.Text);


			//					prognozYelow = Convert.ToInt32(timetoprognoz) / Convert.ToInt32(Yelow_result);


			//					label75.Text = Convert.ToString(prognozYelow);
			//				}
			//				break;
			//			default:
			//				{
			//					label72.Text = "-";
			//					label73.Text = "-";
			//					label74.Text = "-";
			//					label75.Text = "-";

			//				}
			//				break;





			//		}
			//	}



		}

		private void label17_Click(object sender, EventArgs e)
		{

		}

		private void label17_TextChanged(object sender, EventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (label13.Text == "Тренування!")
			{
				serialPort1.WriteLine("3");
				pausesound.Play();
				label69.Text = "Трек виключений";
				label69.BackColor = Color.Red;
				if (serialPort1.IsOpen == true)
				{
					serialPort1.Close();
				}

				timer24.Enabled = false;

				button6.Visible = false;
				button7.Visible = true;
				button7.Focus();
			}
			else
			{


				serialPort1.WriteLine("3");


				if (serialPort1.IsOpen == true)
				{
					serialPort1.Close();
				}


				label69.Text = "Трек виключений";
				label69.BackColor = Color.Red;
				button10.Enabled = true;
				button11.Enabled = false;





				pausesound.Play();
				if (number_group.Text == "0")   // кнопка пауза для 1 заїзду
				{
					serialPort1.Close();
					timer2.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					button7.Visible = true;
					button7.Focus();
				}

				if (number_group.Text == "1")   // кнопка пауза для 2 заїзду
				{
					serialPort1.Close();
					timer4.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					button7.Visible = true;
					button7.Focus();
				}

				if (number_group.Text == "2")   // кнопка пауза для 3 заїзду
				{
					serialPort1.Close();
					timer6.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					button7.Visible = true;
					button7.Focus();
				}

				if (number_group.Text == "3")   // кнопка пауза для 3 заїзду
				{
					serialPort1.Close();
					timer8.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					button7.Visible = true;
					button7.Focus();
				}

				if (number_group.Text == "4")
				{
					serialPort1.Close();
					timer38.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					button7.Visible = true;
					button7.Focus();
				}
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if(label13.Text == "Тренування!")
            {
				serialPort1.Open();
				serialPort1.WriteLine("4");
				startsound.Play();
				timer24.Enabled = true;
				button7.Visible = false;
				button6.Visible = true;
				button6.Focus();
			}
            else
            {
			start_to_pause.Play();
			timer33.Enabled = true;
            }
			
		}

		private void button7_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				if (label13.Text == "Тренування!")
				{
					serialPort1.Open();
					serialPort1.WriteLine("4");
					startsound.Play();
					timer24.Enabled = true;
					button7.Visible = false;
					button6.Visible = true;
					button6.Focus();
				}
				else
				{
					start_to_pause.Play();
					timer33.Enabled = true;
				}




			}
		}

		private void button6_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				if (label13.Text == "Тренування!")
				{
					serialPort1.WriteLine("3");
					pausesound.Play();
					label69.Text = "Трек виключений";
					label69.BackColor = Color.Red;
					if (serialPort1.IsOpen == true)
					{
						serialPort1.Close();
					}

					timer24.Enabled = false;

					button6.Visible = false;
					button7.Visible = true;
					button7.Focus();
				}
				else
				{


					serialPort1.WriteLine("3");


					if (serialPort1.IsOpen == true)
					{
						serialPort1.Close();
					}


					label69.Text = "Трек виключений";
					label69.BackColor = Color.Red;
					button10.Enabled = true;
					button11.Enabled = false;





					pausesound.Play();
					if (number_group.Text == "0")   // кнопка пауза для 1 заїзду
					{
						serialPort1.Close();
						timer2.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
					}

					if (number_group.Text == "1")   // кнопка пауза для 2 заїзду
					{
						serialPort1.Close();
						timer4.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
					}

					if (number_group.Text == "2")   // кнопка пауза для 3 заїзду
					{
						serialPort1.Close();
						timer6.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
					}

					if (number_group.Text == "3")   // кнопка пауза для 3 заїзду
					{
						serialPort1.Close();
						timer8.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
					}

					if (number_group.Text == "4")
					{
						serialPort1.Close();
						timer38.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
					}
				}
			}
		}

		private void button1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				button12.Enabled = false;
				timer1.Enabled = true;
				button1.Visible = false;

				button6.Focus();

			}
		}

		private void timer20_Tick(object sender, EventArgs e)
		{
			serialPort1.Open();
			button6.Visible = true;
			button6.Focus();
			timer20.Enabled = false;
		}



		private void timer13_Tick(object sender, EventArgs e)
		{
			if (Convert.ToDouble(label29.Text) > delay)
			{       //обмеження по часу кола 2 секунда
				c++;                                            //добавляю кола 1 доріці
				label24.Text = Convert.ToString(c);






				if (label72.Visible == false)
				{



					// алгоритм прогнозу
					if (label15.Text == "1/4")
					{
						//double masuv, kola, seredniychas, prognoz;

						kola = Convert.ToDouble(label29.Text);
						masuv = Convert.ToDouble(label56.Text);
						seredniychas2 = Convert.ToDouble(label57.Text);
						kola = (kola + masuv);
						label56.Text = Convert.ToString(kola);
						seredniychas2 = kola / Convert.ToDouble(label24.Text);

					}
					else
					{
						if (label15.Text == "2/4")
						{
							//double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label29.Text);
							masuv = Convert.ToDouble(label56.Text);
							seredniychas4 = Convert.ToDouble(label57.Text);
							kola = (kola + masuv);
							label56.Text = Convert.ToString(kola);
							seredniychas4 = kola / Convert.ToDouble(label24.Text);

						}
						else
						{
							if (label15.Text == "3/4")
							{
								//double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label29.Text);
								masuv = Convert.ToDouble(label56.Text);
								seredniychas3 = Convert.ToDouble(label57.Text);
								kola = (kola + masuv);
								label56.Text = Convert.ToString(kola);
								seredniychas3 = kola / Convert.ToDouble(label24.Text);

							}
							else
							{
								if (label15.Text == "4/4")
								{
									//	double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label29.Text);
									masuv = Convert.ToDouble(label56.Text);
									seredniychas1 = Convert.ToDouble(label57.Text);
									kola = (kola + masuv);
									label56.Text = Convert.ToString(kola);
									seredniychas1 = kola / Convert.ToDouble(label24.Text);

									if (label13.Text == "<<Фініш!>>")
									{
										masuv = 0;
										kola = 0;
										seredniychas = 0;
										prognoz = 0;
									}

								}

							}
						}
					}



				}
				else
				{





					// алгоритм прогнозу
					if (label15.Text == "1/5")
					{
						//double masuv, kola, seredniychas, prognoz;

						kola = Convert.ToDouble(label29.Text);
						masuv = Convert.ToDouble(label56.Text);
						seredniychas2 = Convert.ToDouble(label57.Text);
						kola = (kola + masuv);
						label56.Text = Convert.ToString(kola);
						seredniychas2 = kola / Convert.ToDouble(label24.Text);

					}
					else
					{
						if (label15.Text == "2/5")
						{
							//double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label29.Text);
							masuv = Convert.ToDouble(label56.Text);
							seredniychas4 = Convert.ToDouble(label57.Text);
							kola = (kola + masuv);
							label56.Text = Convert.ToString(kola);
							seredniychas4 = kola / Convert.ToDouble(label24.Text);

						}
						else
						{
							if (label15.Text == "3/5")
							{
								//double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label29.Text);
								masuv = Convert.ToDouble(label56.Text);
								seredniychas3 = Convert.ToDouble(label57.Text);
								kola = (kola + masuv);
								label56.Text = Convert.ToString(kola);
								seredniychas3 = kola / Convert.ToDouble(label24.Text);

							}
							else
							{
								if (label15.Text == "4/5")
								{
									//	double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label29.Text);
									masuv = Convert.ToDouble(label56.Text);
									seredniychas1 = Convert.ToDouble(label57.Text);
									kola = (kola + masuv);
									label56.Text = Convert.ToString(kola);
									seredniychas1 = kola / Convert.ToDouble(label24.Text);
								}
								else
								{
									if (label15.Text == "5/5")
									{
										//	double masuv, kola, seredniychas, prognoz;
										kola = Convert.ToDouble(label29.Text);
										masuv = Convert.ToDouble(label56.Text);
										seredniychas5 = Convert.ToDouble(label57.Text);
										kola = (kola + masuv);
										label56.Text = Convert.ToString(kola);
										seredniychas5 = kola / Convert.ToDouble(label24.Text);
								

									if (label13.Text == "<<Фініш!>>")
									{
										masuv = 0;
										kola = 0;
										seredniychas = 0;
										prognoz = 0;
									}
									 }
								}

							}
						}

					}
				}




















					// підсвітка під час кола
					label24.BackColor = Color.LawnGreen;
				label24.BackColor = Color.LawnGreen;
				timer28.Enabled = true;

				timer26.Enabled = true;
			}
			timer13.Enabled = false;
		}

		private void timer14_Tick(object sender, EventArgs e)
		{
			if (Convert.ToDouble(label38.Text) > delay)
			{       //обмеження по часу кола 2 секунда
				d++;                                            //добавляю кола 4 доріці
				label25.Text = Convert.ToString(d);



				if (label72.Visible == false)
				{

					// алгоритм прогнозу

					if (label15.Text == "1/4")
					{
						//double masuv, kola, seredniychas, prognoz;
						kola = Convert.ToDouble(label38.Text);
						masuv = Convert.ToDouble(label119.Text);
						seredniychas4 = Convert.ToDouble(label118.Text);
						kola = (kola + masuv);
						label119.Text = Convert.ToString(kola);
						seredniychas4 = kola / Convert.ToDouble(label25.Text);
					}
					else
					{
						if (label15.Text == "2/4")
						{
							//double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label38.Text);
							masuv = Convert.ToDouble(label119.Text);
							seredniychas3 = Convert.ToDouble(label118.Text);
							kola = (kola + masuv);
							label119.Text = Convert.ToString(kola);
							seredniychas3 = kola / Convert.ToDouble(label25.Text);
						}
						else
						{
							if (label15.Text == "3/4")
							{
								//double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label38.Text);
								masuv = Convert.ToDouble(label119.Text);
								seredniychas1 = Convert.ToDouble(label118.Text);
								kola = (kola + masuv);
								label119.Text = Convert.ToString(kola);
								seredniychas1 = kola / Convert.ToDouble(label25.Text);
							}
							else
							{
								if (label15.Text == "4/4")
								{
									//double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label38.Text);
									masuv = Convert.ToDouble(label119.Text);
									seredniychas2 = Convert.ToDouble(label118.Text);
									kola = (kola + masuv);
									label119.Text = Convert.ToString(kola);
									seredniychas2 = kola / Convert.ToDouble(label25.Text);
									if (label13.Text == "<<Фініш!>>")
									{
										masuv = 0;
										kola = 0;
										seredniychas = 0;
										prognoz = 0;
									}
								}

							}
						}
					}

				}
				else
				{


					// алгоритм прогнозу

					if (label15.Text == "1/5")
					{
						//double masuv, kola, seredniychas, prognoz;
						kola = Convert.ToDouble(label38.Text);
						masuv = Convert.ToDouble(label119.Text);
						seredniychas4 = Convert.ToDouble(label118.Text);
						kola = (kola + masuv);
						label119.Text = Convert.ToString(kola);
						seredniychas4 = kola / Convert.ToDouble(label25.Text);
					}
					else
					{
						if (label15.Text == "2/5")
						{
							//double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label38.Text);
							masuv = Convert.ToDouble(label119.Text);
							seredniychas3 = Convert.ToDouble(label118.Text);
							kola = (kola + masuv);
							label119.Text = Convert.ToString(kola);
							seredniychas3 = kola / Convert.ToDouble(label25.Text);
						}
						else
						{
							if (label15.Text == "3/5")
							{
								//double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label38.Text);
								masuv = Convert.ToDouble(label119.Text);
								seredniychas1 = Convert.ToDouble(label118.Text);
								kola = (kola + masuv);
								label119.Text = Convert.ToString(kola);
								seredniychas1 = kola / Convert.ToDouble(label25.Text);
							}
							else
							{
								if (label15.Text == "4/5")
								{
									//double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label38.Text);
									masuv = Convert.ToDouble(label119.Text);
									seredniychas5 = Convert.ToDouble(label118.Text);
									kola = (kola + masuv);
									label119.Text = Convert.ToString(kola);
									seredniychas5 = kola / Convert.ToDouble(label25.Text);
								}
								else
								{

									if (label15.Text == "5/5")
									{
										//double masuv, kola, seredniychas, prognoz;
										kola = Convert.ToDouble(label38.Text);
										masuv = Convert.ToDouble(label119.Text);
										seredniychas2 = Convert.ToDouble(label118.Text);
										kola = (kola + masuv);
										label119.Text = Convert.ToString(kola);
										seredniychas2 = kola / Convert.ToDouble(label25.Text);
									

										if (label13.Text == "<<Фініш!>>")
									{
										masuv = 0;
										kola = 0;
										seredniychas = 0;
										prognoz = 0;
									}
								  }
								}

							}
						}
					}

				}



					




					







					// підсвітка під час кола
					label25.BackColor = Color.LawnGreen;
				label25.BackColor = Color.LawnGreen;
				timer29.Enabled = true;
				timer26.Enabled = true;
			}

			timer14.Enabled = false;
		}

		private void timer21_Tick(object sender, EventArgs e)
		{



			int n;







			if (label48.Text == "" && label15.Text == "номер заизду")
			{
				n = listBox1.Items.Count - 1;
				
				//label48.Text = Convert.ToString(listBox1.Items[n]);

				for (int i = 0; i < n; n--)
				{

					label48.Text = Convert.ToString(listBox1.Items[n]);
					if (label48.Text != "")
					{
						break;
					}

				}
				n--;
				label47.Text = Convert.ToString(listBox1.Items[n]);
				n--;
				label46.Text = Convert.ToString(listBox1.Items[n]);
				n--;
				label45.Text = Convert.ToString(listBox1.Items[n]);

				label67.Text = Convert.ToString(n);




				// добавляю людину з простою
				if (prostoi_number - Convert.ToInt32(label67.Text) <= 5 && prostoi_number - Convert.ToInt32(label67.Text) >= 0)
				{
					label72.Visible = true;
					label74.Visible = true;
					label75.Visible = true;
					label90.Visible = true;
					prostoi = "finish";
				}
				else
				{

					if (prostoi_number2 - Convert.ToInt32(label67.Text) <= 5 && prostoi_number2 - Convert.ToInt32(label67.Text) >= 0 && prostoi == "finish")

					{
						label72.Text = prostoi2;
						label72.Visible = true;
						label74.Visible = true;
						label75.Visible = true;
						label90.Visible = true;
						prostoi2 = "finish";
					}
					else
					{
						if (prostoi_number3 - Convert.ToInt32(label67.Text) <=5 && prostoi_number3 - Convert.ToInt32(label67.Text) >= 0 && prostoi == "finish" && prostoi2 == "finish")

						{
							label72.Text = prostoi3;
							label72.Visible = true;
							label74.Visible = true;
							label75.Visible = true;
							label90.Visible = true;
							prostoi3 = "finish";
                        }
                        else
                        {
							label72.Visible = false;
							label74.Visible = false;
							label75.Visible = false;
							label90.Visible = false;
						}

							

					}

					
				}

			}

			if (Convert.ToInt32(label67.Text) != 1)
			{



				if (number_group.Text == "0" && label13.Text == "<<Фініш!>>")
				{
					n = Convert.ToInt32(label67.Text);
					// перехід між групами
					dataGridView1.Visible = false;
					button8.Visible = false;
					button1.Visible = true;
					button7.Visible = false;
					button6.Visible = false;
					button1.Focus();
					panel1.Location = new Point(7, 213);
					panel3.Location = new Point(7, 358);
					panel4.Location = new Point(7, 502);
					panel5.Location = new Point(7, 645);

					label17.Text = "0";
					label24.Text = "0";
					label23.Text = "0";
					label25.Text = "0";

					label18.Text = "00,000";
					label22.Text = "00,000";
					label19.Text = "00,000";
					label20.Text = "00,000";
					label16.Text = "999";
					label29.Text = "00,000";
					label30.Text = "00,000";
					label31.Text = "00,000";
					label32.Text = "00,000";
					label42.Text = "999";
					label35.Text = "00,000";
					label36.Text = "00,000";
					label37.Text = "00,000";
					label34.Text = "00,000";
					label43.Text = "999";
					label38.Text = "00,000";
					label39.Text = "00,000";
					label40.Text = "00,000";
					label41.Text = "00,000";
					label44.Text = "999";

					label55.Visible = false;
					label59.Visible = false;
					label60.Visible = false;
					label61.Visible = false;
					label62.Visible = false;
					n--;
					label48.Text = Convert.ToString(listBox1.Items[n]);
					n--;
					label47.Text = Convert.ToString(listBox1.Items[n]);
					n--;
					label46.Text = Convert.ToString(listBox1.Items[n]);
					n--;
					label45.Text = Convert.ToString(listBox1.Items[n]);


					label67.Text = Convert.ToString(n);



					// добавляю людину з простою
					if (prostoi_number - Convert.ToInt32(label67.Text) <= 5 && prostoi_number - Convert.ToInt32(label67.Text) >= 0)
					{
						label72.Visible = true;
						label74.Visible = true;
						label75.Visible = true;
						label90.Visible = true;
						prostoi = "finish";
					}
					else
					{

						if (prostoi_number2 - Convert.ToInt32(label67.Text) <= 5 && prostoi_number2 - Convert.ToInt32(label67.Text) >= 0 && prostoi == "finish")

						{
							label72.Text = prostoi2;
							label72.Visible = true;
							label74.Visible = true;
							label75.Visible = true;
							label90.Visible = true;
							prostoi2 = "finish";
						}
						else
						{
							if (prostoi_number3 - Convert.ToInt32(label67.Text) <= 5 && prostoi_number3 - Convert.ToInt32(label67.Text) >= 0 && prostoi == "finish" && prostoi2 == "finish")

							{
								label72.Text = prostoi3;
								label72.Visible = true;
								label74.Visible = true;
								label75.Visible = true;
								label90.Visible = true;
								prostoi3 = "finish";
                            }
                            else
                            {
								label72.Visible = false;
								label74.Visible = false;
								label75.Visible = false;
								label90.Visible = false;
							}

							
						}

						
					}

				



				timetostart = 5;
					label13.Visible = false;
					timer21.Enabled = false;

				}

			}


		}


		private void timer15_Tick(object sender, EventArgs e)
		{


			Times += 0.0003 * 53;                //timer на час кола синя доріжка
			label26.Text = string.Format("{0:F3}", Times);       //timer на час кола синя доріжка

		}

		private void button9_Click(object sender, EventArgs e)
		{
			label68.Visible = false;
			textBox20.Visible = false;
			textBox21.Visible = false;
			textBox22.Visible = false;
			textBox23.Visible = false;
			textBox29.Visible = false;
			button9.Visible = false;
			panel6.Visible = false;

			if (textBox25.Text == "")
			{
				

				button8.Visible = true;
			


				position = 1;
				position1 = 0;


				if (label72.Visible == false)
				{
					dataGridView1.Rows.Add("", label45.Text, lane3_1, lane3_2, lane3_3, lane3_4, label17.Text + "," + textBox20.Text);

					dataGridView1.Rows.Add("", label46.Text, lanes1, lanes2, lanes3, lanes4, label24.Text + "," + textBox22.Text);

					dataGridView1.Rows.Add("", label47.Text, lane4_1, lane4_2, lane4_3, lane4_4, label23.Text + "," + textBox21.Text);

					dataGridView1.Rows.Add("", label48.Text, lane2_1, lane2_2, lane2_3, lane2_4, label25.Text + "," + textBox23.Text);
                }
                else
                {
					dataGridView1.Rows.Add("", label45.Text, lane3_1, lane3_2, lane3_3, lane3_4, label17.Text + "," + textBox20.Text);

					dataGridView1.Rows.Add("", label46.Text, lane5_1, lane5_2, lane5_3, lane5_4, label24.Text + "," + textBox22.Text);

					dataGridView1.Rows.Add("", label47.Text, lane4_1, lane4_2, lane4_3, lane4_4, label23.Text + "," + textBox21.Text);

					dataGridView1.Rows.Add("", label48.Text, lane2_1, lane2_2, lane2_3, lane2_4, label25.Text + "," + textBox23.Text);

					dataGridView1.Rows.Add("", label72.Text, lanes1, lanes2, lanes3, lanes4, label75.Text + "," + textBox29.Text);
				}
				//сортування результату гонки в таблиці


				dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Descending);
				
				// добавляю порядок спортсмені ( порядок місць)

				for (int cell = 0; dataGridView1.Rows.Count > cell; cell++)
				{
					
					dataGridView1.Rows[position1].Cells[0].Value = position;
					


					if(dataGridView1.Rows.Count > position) 
					
					{
						position1 = position1 + 1;
						position = position + 1;
					}
					
				}

		
				textBox20.Text = "";
				textBox21.Text = "";
				textBox22.Text = "";
				textBox23.Text = "";
				textBox29.Text = "";
			}
			else
			{

				position = 1;
				position1 = 0;

		
				button16.Visible = true;

				dataGridView2.Rows.Add("",label45.Text, lane3_1, lane3_2, lane3_3, lane3_4, label17.Text + "." + textBox20.Text);

				dataGridView2.Rows.Add("",label46.Text, lanes1, lanes2, lanes3, lanes4, label24.Text + "." + textBox22.Text);

				dataGridView2.Rows.Add("",label47.Text, lane4_1, lane4_2, lane4_3, lane4_4, label23.Text + "." + textBox21.Text);

				dataGridView2.Rows.Add("",label48.Text, lane2_1, lane2_2, lane2_3, lane2_4, label25.Text + "." + textBox23.Text);
				//сортування результату гонки в таблиці


				dataGridView2.Sort(dataGridView2.Columns[6], ListSortDirection.Descending);

				// добавляю порядок спортсмені ( порядок місць)

				for (int cell = 0; dataGridView2.Rows.Count > cell; cell++)
				{

					dataGridView2.Rows[position1].Cells[0].Value = position;



					if (dataGridView2.Rows.Count > position)

					{
						position1 = position1 + 1;
						position = position + 1;
					}

				}

				textBox20.Text = "";
				textBox21.Text = "";
				textBox22.Text = "";
				textBox23.Text = "";
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			serialPort1.Open();
			serialPort1.WriteLine("4");
			serialPort1.Close();
			label69.Text = "Трек включений";
			label69.BackColor = Color.Green;
			button10.Enabled = false;
			button11.Enabled = true;
		}

		private void button11_Click(object sender, EventArgs e)
		{
			serialPort1.Open();
			serialPort1.WriteLine("3");
			serialPort1.Close();
			label69.Text = "Трек виключений";
			label69.BackColor = Color.Red;
			button10.Enabled = true;
			button11.Enabled = false;
		}

		private void button12_Click(object sender, EventArgs e)
		{
			button19.Visible = true;
			button12.Visible = false;
			button13.Visible = true;
			label13.Visible = true;
			label13.Text = "<<1 хв Тренування!>>";
			label70.Visible = true;
			timetotraning = 60;
			label70.Text = "60";
			button1.Enabled = false;
		}

		private void button13_Click(object sender, EventArgs e)
		{
			button19.Visible = false;
			button1.Enabled = false;
			label69.Text = "Трек включений";
			label69.BackColor = Color.Green;
			serialPort1.Open();
			serialPort1.WriteLine("4");
			serialPort1.Close();
			timer22.Enabled = true;
			button13.Enabled = false;
		}

		private void timer22_Tick(object sender, EventArgs e)
		{
			if (label70.Text == "6")// 5 секунд
			{
				fivesecond.Play();
			}

			if (label70.Text == "17") //залишилось 15 секунд
			{
				sekynd.Play();
			}

			if (Convert.ToInt32(label70.Text) != 0)
			{
				label70.Text = Convert.ToString(timetotraning);
				timetotraning--;

			}
			else
			{
				label70.Visible = false;
				button12.Visible = true;
				timer22.Enabled = false;
				label70.Text = "60";
				timetotraning = 60;
				button13.Visible = false;
				serialPort1.Open();
				serialPort1.WriteLine("3");
				serialPort1.Close();
				label69.Text = "Трек виключений";
				label69.BackColor = Color.Red;
				label13.Visible = false;
				button1.Enabled = true;
				button1.Focus();
				button13.Enabled = true;


			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void button14_Click(object sender, EventArgs e)
		{

			label67.Text = "228";
			textBox25.Text = textBox24.Text;

			button14.Visible = false;
			button15.Visible = true;
			min = Convert.ToInt32(textBox24.Text);
			button12.Enabled = true;
			dataGridView1.Visible = false;
			button8.Visible = false;
			button7.Visible = false;
			button6.Visible = false;
			button15.Focus();
			panel1.Location = new Point(7, 213);
			panel3.Location = new Point(7, 358);
			panel4.Location = new Point(7, 502);
			panel5.Location = new Point(7, 645);

			label17.Text = "0";
			label24.Text = "0";
			label23.Text = "0";
			label25.Text = "0";

			label18.Text = "00,000";
			label22.Text = "00,000";
			label19.Text = "00,000";
			label20.Text = "00,000";
			label16.Text = "999";
			label29.Text = "00,000";
			label30.Text = "00,000";
			label31.Text = "00,000";
			label32.Text = "00,000";
			label42.Text = "999";
			label35.Text = "00,000";
			label36.Text = "00,000";
			label37.Text = "00,000";
			label34.Text = "00,000";
			label43.Text = "999";
			label38.Text = "00,000";
			label39.Text = "00,000";
			label40.Text = "00,000";
			label41.Text = "00,000";
			label44.Text = "999";

			label55.Visible = false;
			label59.Visible = false;
			label60.Visible = false;
			label61.Visible = false;
			label62.Visible = false;
			button15.Focus();
			timetostart = 5;
			label13.Visible = false;
			timer21.Enabled = false;


			//задаю учасників фіналістів

			label48.Text = dataGridView1[1, 3].Value.ToString();
			label47.Text = dataGridView1[1, 2].Value.ToString();
			label46.Text = dataGridView1[1, 1].Value.ToString();
			label45.Text = dataGridView1[1, 0].Value.ToString();


		}

		private void button15_Click(object sender, EventArgs e)
		{
			fivesecond.Play();
			button12.Enabled = false;
			timer23.Enabled = true;
			button1.Visible = false;
			button15.Visible = false;
			button6.Visible = true;
			button6.Enabled = true;
			button6.Focus();
		}

		private void timer23_Tick(object sender, EventArgs e)
		{
			textBox13.Text = textBox24.Text;
			prognoz1 = 0;
			prognoz2 = 0;
			prognoz3 = 0;
			prognoz4 = 0;
			prognoz5 = 0;
			seredniychas1 = 0;
			seredniychas2 = 0;
			seredniychas3 = 0;
			seredniychas4 = 0;
			seredniychas5 = 0;
			masuv = 0;
			kola = 0;
			seredniychas = 0;
			prognoz = 0;


			label18.Text = "00,000";
			label22.Text = "00,000";
			label19.Text = "00,000";
			label20.Text = "00,000";
			label16.Text = "999";
			label29.Text = "00,000";
			label30.Text = "00,000";
			label31.Text = "00,000";
			label32.Text = "00,000";
			label42.Text = "999";
			label35.Text = "00,000";
			label36.Text = "00,000";
			label37.Text = "00,000";
			label34.Text = "00,000";
			label43.Text = "999";
			label38.Text = "00,000";
			label39.Text = "00,000";
			label40.Text = "00,000";
			label41.Text = "00,000";
			label44.Text = "999";
			timer11.Interval = 15; //timer на час кола
			Time = 0.0;             //timer на час кола

			timer16.Interval = 15; //timer на час кола
			Timeg = 0.0;             //timer на час кола

			timer17.Interval = 15; //timer на час кола
			Timez = 0.0;             //timer на час кола

			timer15.Interval = 15; //timer на час кола
			Times = 0.0;             //timer на час кола


			if (label4.Text == "4")             //звук для time to start
			{



				timetostartsound.Play();
			}

			label4.Text = Convert.ToString(timetostart); //вивід стартового таймера у лейбл
			timetostart--;

			if (timetostart == -1) //якщо стартовий номер = -1 таймер зупиняє роботу і ховає лейбл4
			{

				timer23.Enabled = false;


				if (timetostart == -1)


				{
					timer32.Enabled = true;
					label71.Visible = true;
					timer2.Enabled = true;
					label4.Text = "00:00";
					sec = 1;
					min = Convert.ToInt32(textBox24.Text);
					label13.Text = "<<Гонка!>>";
					label15.Visible = true;
					label15.Text = "1/4";
					label13.Visible = true;
					timer20.Enabled = true;
					timer11.Enabled = true;
					timer16.Enabled = true;
					timer17.Enabled = true;
					timer15.Enabled = true;
					serialPort1.Open();
					serialPort1.WriteLine("4");
					serialPort1.Close();
					label69.Text = "Трек включений";
					label69.BackColor = Color.Green;
					button10.Enabled = false;
					button11.Enabled = true;



				}





			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			SaveTable(dataGridView2);
			label13.Text = "<< Заїзди завершено! >>";
		}

		private void label58_Click(object sender, EventArgs e)
		{

		}

		private void label44_Click(object sender, EventArgs e)
		{

		}

		private void button15_KeyDown(object sender, KeyEventArgs e)
		{

		}

		private void Form3_FormClosing(object sender, FormClosingEventArgs e)
		{

			Settings.Default.line_1 = panel1.BackColor;
			Settings.Default.line_2 = panel3.BackColor;
			Settings.Default.line_3 = panel4.BackColor;
			Settings.Default.line_4 = panel5.BackColor;
			Settings.Default.delay1 = delay;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor;


			DialogResult dialog = MessageBox.Show(
				 "Ви дійсно хочите вийти з програми?",
				 "Завершення роботи",
				 MessageBoxButtons.YesNo,
				 MessageBoxIcon.Warning
				);
			if (dialog == DialogResult.Yes)
			{
				e.Cancel = false;
				serialPort1.Close();

			}
			else
			{
				e.Cancel = true;
			}
		}

		private void червонаToolStripMenuItem_Click(object sender, EventArgs e)
		{

			Settings.Default.line_1 = panel1.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void зеленаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line_1 = panel1.BackColor = Color.LimeGreen;
			Settings.Default.Save();

		}

		private void білаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel1.BackColor = Color.White;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel1.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void фіолетоваToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel1.BackColor = Color.Purple;
			Settings.Default.Save();
		}

		private void жовтаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line_1 = panel1.BackColor = Color.Gold;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line_1 = panel1.BackColor = Color.DodgerBlue;
			Settings.Default.Save();

		}

		private void чорнаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line_1 = panel1.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void червонаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel3.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void білаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel3.BackColor = Color.White;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel3.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void доріжкаToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void фіолетоваToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel3.BackColor = Color.Purple;
			Settings.Default.Save();
		}

		private void жовтаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel3.BackColor = Color.Gold;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel3.BackColor = Color.DodgerBlue;
			Settings.Default.Save();
		}

		private void чорнаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel3.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void зеленаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line_2 = panel3.BackColor = Color.LimeGreen;
			Settings.Default.Save();
		}

		private void червонаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel4.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void білаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel4.BackColor = Color.White;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel4.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void фіолетоваToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel4.BackColor = Color.Purple;
			Settings.Default.Save();
		}

		private void жовтаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel4.BackColor = Color.Gold;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel4.BackColor = Color.DodgerBlue;
			Settings.Default.Save();
		}

		private void чорнаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel4.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void доріжкаToolStripMenuItem2_Click(object sender, EventArgs e)
		{

		}

		private void зеленаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line_3 = panel4.BackColor = Color.LimeGreen;
			Settings.Default.Save();
		}

		private void червонаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel5.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void білаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel5.BackColor = Color.White;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel5.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void фіолетоваToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel5.BackColor = Color.Purple;
			Settings.Default.Save();

		}

        private void button3_Click_2(object sender, EventArgs e)
        {
			time_to_traning_min = 999999;

			traning_number_group = 999;



			


			button5.Enabled = true;
			button3.Visible = false;
			label49.Visible = true;
			comboBox1.Visible = true;
			button5.Visible = true;
			button4.Visible = false;
			label88.Visible = false;
			label89.Visible = false;
			textBox26.Visible = false;
			textBox27.Visible = false;
			button20.Visible = false;
			label11.Visible = false;
			textBox28.Visible = false;
			label13.Text = "<<Вільні тренування!>>";
			label4.Visible = false;
			label13.Visible = true;
			label13.Location = new Point(570, 75);


			// переміщення інтерфейсу під тренування
			label25.Location = new Point(92, -13);
			//textBox1.Size = new Size(301, 151);
			label23.Location = new Point(92, -5);
			//textBox6.Size = new Size(301, 151);
			label24.Location = new Point(92, -5);
			//textBox9.Size = new Size(301, 151);
			label17.Location = new Point(92, 1);
			//textBox12.Size = new Size(301, 151);
			label17.Location = new Point(88, -10);
			label24.Location = new Point(88, -6);
			label23.Location = new Point(88, -6);
			label25.Location = new Point(88, -10);
			textBox2.Location = new Point(431, 12);
			textBox2.Size = new Size(1083, 104);
			textBox5.Location = new Point(431, 12);
			textBox5.Size = new Size(1083, 104);
			textBox8.Location = new Point(431, 12);
			textBox8.Size = new Size(1083, 104);
			textBox11.Location = new Point(431, 12);
			textBox11.Size = new Size(1083, 104);
			label7.Text = "Круги";
			label5.Visible = false;
			label9.Location = new Point(878, 8);
			label22.Location = new Point(431, 34);
			label19.Location = new Point(610, 34);
			label20.Location = new Point(803, 37);
			label76.Visible = true;
			label77.Visible = true;
			label78.Visible = true;
			label30.Location = new Point(431, 33);
			label32.Location = new Point(610, 33);
			label31.Location = new Point(803, 36);
			label79.Visible = true;
			label80.Visible = true;
			label81.Visible = true;
			label34.Location = new Point(431, 35);
			label36.Location = new Point(610, 35);
			label35.Location = new Point(803, 38);
			label82.Visible = true;
			label83.Visible = true;
			label84.Visible = true;
			label39.Location = new Point(431, 34);
			label41.Location = new Point(610, 34);
			label40.Location = new Point(803, 37);
			label87.Visible = true;
			label86.Visible = true;
			label85.Visible = true;
		
			timer18.Enabled = false;
			

			label55.Visible = false;
			label59.Visible = false;
			label60.Visible = false;
			label61.Visible = false;
			label62.Visible = false;
			label124.Visible = false;
			label54.Visible = false;
			label57.Visible = false;
			label58.Visible = false;
			label118.Visible = false;
		}

        private void Form3_SizeChanged(object sender, EventArgs e)
        {
            if (label17.Location.X < 661)
            {
                //label45.Font = new Font(label45.Font.Name, 20, label45.Font.Style);
                label45.MaximumSize = new Size(300, 63);
                label46.MaximumSize = new Size(300, 63);
                label47.MaximumSize = new Size(300, 63);
                label48.MaximumSize = new Size(300, 63);
                dataGridView4.Location = new Point(864, 3);
                button22.Location = new Point(1279, 74);
            }
            else
            {
                label45.MaximumSize = new Size(598, 130);
                label46.MaximumSize = new Size(598, 130);
                label47.MaximumSize = new Size(598, 130);
                label48.MaximumSize = new Size(598, 130);

				label45.Size = new Size(598, 74);
				label46.Size = new Size(598, 74);
				label47.Size = new Size(598, 74);
				label48.Size = new Size(598, 74);
			}
			int p,x;
			
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
			if(checkBox1.Checked == true)
            {
				button23.Enabled = true;
				button24.Enabled = true;
				button25.Enabled = true;
				button26.Enabled = true;
            }
            else
            {
				button23.Enabled = false;
				button24.Enabled = false;
				button25.Enabled = false;
				button26.Enabled = false;
			}
        }

        private void button23_Click(object sender, EventArgs e)
        {
			i++;                                            
			label17.Text = Convert.ToString(i);
			checkBox1.Checked = false;
		}

        private void button24_Click(object sender, EventArgs e)
        {
			c++;                                            //добавляю кола 1 доріці
			label24.Text = Convert.ToString(c);
			checkBox1.Checked = false;
		}

        private void button25_Click(object sender, EventArgs e)
        {
			b++;                                            //добавляю кола 1 доріці
			label23.Text = Convert.ToString(b);
			checkBox1.Checked = false;
		}

        private void button26_Click(object sender, EventArgs e)
        {
			d++;                                            //добавляю кола 4 доріці
			label25.Text = Convert.ToString(d);
			checkBox1.Checked = false;

		}

        private void label59_TextChanged(object sender, EventArgs e)
        {
			if(label59.Text == "-99")
            {
				label59.Font = new Font(label59.Font.Name, 18, label45.Font.Style);
            }
            else
            {
				if (label59.Text == "0")
				{
					label59.Font = new Font(label59.Font.Name, 24, label45.Font.Style);
				}
			}
		}

        private void label60_TextChanged(object sender, EventArgs e)
        {
			if (label60.Text == "-99")
			{
				label60.Font = new Font(label60.Font.Name, 18, label45.Font.Style);
            }
            else
            {
				if (label60.Text == "0")
				{
					label60.Font = new Font(label60.Font.Name, 24, label45.Font.Style);
				}
			}
		}

        private void label61_TextChanged(object sender, EventArgs e)
        {
			if (label61.Text == "-99")
			{
				label61.Font = new Font(label61.Font.Name, 18, label45.Font.Style);
            }
            else
            {
				if (label61.Text == "0")
				{
					label61.Font = new Font(label61.Font.Name, 24, label45.Font.Style);
				}
			}
		}

        private void label62_TextChanged(object sender, EventArgs e)
        {
			if (label62.Text == "-99")
			{
				label62.Font = new Font(label62.Font.Name, 18, label45.Font.Style);
            }
            else
            {
				if (label62.Text == "0")
				{
					label62.Font = new Font(label62.Font.Name, 24, label45.Font.Style);
				}
			}
		}

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
			// неправельне введення тексту
			if (textBox20.Text != "")
			{
				try
				{
					int m = Convert.ToInt32(textBox20.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
					textBox20.Clear();
				}
			}
		}

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
			// неправельне введення тексту
			if (textBox21.Text != "")
			{
				try
				{
					int b = Convert.ToInt32(textBox21.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
					textBox21.Clear();
				}
			}
		}

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
			// неправельне введення тексту
			if (textBox23.Text != "")
			{
				try
				{
					int h = Convert.ToInt32(textBox23.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
					textBox23.Clear();
				}
			}
		}

        private void жовтаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel5.BackColor = Color.Gold;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel5.BackColor = Color.DodgerBlue;
			Settings.Default.Save();
		}

		private void чорнаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel5.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void зеленаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line_4 = panel5.BackColor = Color.LimeGreen;
			Settings.Default.Save();
		}

		private void timer25_Tick(object sender, EventArgs e)
		{
			time_to_traning_sec--;
			label4.Text = Convert.ToString(time_to_traning_sec);


			if (Convert.ToInt32(label4.Text) == 3)
			{
				timetostartsound.Play();

			}

			if (Convert.ToInt32(label4.Text) == 0)
			{



				serialPort1.WriteLine("4");
				time_to_traning_min = Convert.ToInt32(textBox26.Text);
				time_to_traning_sec = Convert.ToInt32(textBox27.Text);
				time_to_traning_secs = 1;
				label13.Text = "Тренування!";
				timer24.Enabled = true;
				timer25.Enabled = false;
				button6.Enabled = true;
				button6.Focus();
			}
		}

		private void timer26_Tick(object sender, EventArgs e)
		{
			if (label13.Text == "Тренування!" || label13.Text == "<<Вільні тренування!>>") // алгоритм часу для тренування
			{
				label78.Text = label77.Text;
				label77.Text = label76.Text;
				label76.Text = label20.Text;





			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			serialPort1.Close();
			this.Close();
		}

		private void button20_Click(object sender, EventArgs e)
		{
			button3.Visible = false;
			label88.Visible = false;
			label89.Visible = false;
			textBox26.Visible = false;
			textBox27.Visible = false;
			button20.Visible = false;
			label11.Visible = false;
			textBox28.Visible = false;
			label15.Visible = true;
			label15.Text = traning_number_group +"/"+ textBox28.Text;
			time_to_traning_min = Convert.ToInt32(textBox26.Text);
			time_to_traning_sec = Convert.ToInt32(textBox27.Text);
			button5.Enabled = true;
		}

		private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			if (double.Parse(e.CellValue1.ToString()) > double.Parse(e.CellValue2.ToString()))
			{
				e.SortResult = 1;
			}
			else if (double.Parse(e.CellValue1.ToString()) < double.Parse(e.CellValue2.ToString()))
			{
				e.SortResult = -1;
			}
			else
			{
				e.SortResult = 0;
			}
			e.Handled = true;
		}


		private void button19_Click_2(object sender, EventArgs e)
		{
			button19.Visible = false;
			button1.Enabled = true;
		}

		private void dataGridView2_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			if (double.Parse(e.CellValue1.ToString()) > double.Parse(e.CellValue2.ToString()))
			{
				e.SortResult = 1;
			}
			else if (double.Parse(e.CellValue1.ToString()) < double.Parse(e.CellValue2.ToString()))
			{
				e.SortResult = -1;
			}
			else
			{
				e.SortResult = 0;
			}
			e.Handled = true;
		}

		private void timer26_Tick_1(object sender, EventArgs e)
		{
			dataGridView3.Rows.Clear();
			timer26.Enabled = false;
		}

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			if (prostoi == null)
			{
				prostoi = Convert.ToString(dataGridView4.CurrentRow.Cells[1].Value);
				label72.Text = prostoi;

				prostoi_number = dataGridView4.CurrentRow.Index;
				label73.Text = Convert.ToString(prostoi_number);

            }
            else
            {
				if (prostoi !=null && prostoi2 == null)
				{
					prostoi2 = Convert.ToString(dataGridView4.CurrentRow.Cells[1].Value);
					prostoi_number2 = dataGridView4.CurrentRow.Index;

                }
                else
                {
					if (prostoi != null && prostoi2 != null && prostoi3 == null)
                    {
						prostoi3 = Convert.ToString(dataGridView4.CurrentRow.Cells[1].Value);
						prostoi_number3 = dataGridView4.CurrentRow.Index;
					}

				}
			}

			
        }

		private void button22_Click(object sender, EventArgs e)
		{
			button1.Visible = true;
			button1.Focus();



			// видаляю людину яка буде в простої
			if(prostoi != null && prostoi2 == null)
            {
				listBox1.Items.RemoveAt(prostoi_number + 1);
				dataGridView4.Visible = false;
				button22.Visible = false;
            }
            else
            {
				if(prostoi !=null && prostoi2 !=null && prostoi3 == null)
                {
					listBox1.Items.RemoveAt(prostoi_number2 + 1);
					dataGridView4.Visible = false;
					button22.Visible = false;

                }
                else
                {
					if (prostoi != null && prostoi2 != null && prostoi3 != null)
					{
						listBox1.Items.RemoveAt(prostoi_number3 + 1);
						dataGridView4.Visible = false;
						button22.Visible = false;

					}
				}
			}
			


			// добавляю людину у простой
			n = listBox1.Items.Count - 1;

			for (int i = 0; i < n; n--)
			{

				label48.Text = Convert.ToString(listBox1.Items[n]);
				if (label48.Text != "")
				{
					break;
				}

			}
			n--;
			label47.Text = Convert.ToString(listBox1.Items[n]);
			n--;
			label46.Text = Convert.ToString(listBox1.Items[n]);
			n--;
			label45.Text = Convert.ToString(listBox1.Items[n]);

			label67.Text = Convert.ToString(n);


			if (prostoi_number - Convert.ToInt32(label67.Text) <= 5 && prostoi_number - Convert.ToInt32(label67.Text) >= 0)
			{
				label72.Visible = true;
				label74.Visible = true;
				label75.Visible = true;
				label90.Visible = true;
			}
			else
			{

				if(prostoi_number2 - Convert.ToInt32(label67.Text) <= 5 && prostoi_number2 - Convert.ToInt32(label67.Text) >= 0 && prostoi == "finish")

                {
					label72.Text = prostoi2;
					label72.Visible = true;
					label74.Visible = true;
					label75.Visible = true;
					label90.Visible = true;
				}
                else
                {
					if (prostoi_number3 - Convert.ToInt32(label67.Text) <= 5 && prostoi_number3 - Convert.ToInt32(label67.Text) >= 0 && prostoi == "finish" && prostoi2 == "finish")

					{
						label72.Text = prostoi3;
						label72.Visible = true;
						label74.Visible = true;
						label75.Visible = true;
						label90.Visible = true;
					}
				}

				label72.Visible = false;
				label74.Visible = false;
				label75.Visible = false;
				label90.Visible = false;
			}
			dataGridView4.Rows.Clear();

		}

        private void timer37_Tick(object sender, EventArgs e)
        {
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

			button6.Enabled = false;

			if (label4.Text == "0:3")
			{
				timetostartsound.Play();
			}


			if (label4.Text == "0:16") //залишилось 15 секунд
			{
				sekynd.Play();
			}

			if (secs > 60)
			{
				mins++;
				secs = secs - 60;

			}
			if (secs == -1)
			{

				mins--;
				secs = 60;
			}

			if (secs == 60 && mins == -1)
			{
				serialPort1.Open();
				serialPort1.WriteLine("4"); //продовжити 
				label69.Text = "Трек включений";
				label69.BackColor = Color.Green;
				button10.Enabled = false;
				button11.Enabled = true;

				timer37.Enabled = false;
				timer38.Enabled = true;

				if (label72.Visible == false)
				{
					Time = Convert.ToDouble(label63.Text);
					Timeg = Convert.ToDouble(label64.Text);
					Timez = Convert.ToDouble(label65.Text);
					Times = Convert.ToDouble(label66.Text);
				}
				else
				{
					Time = Timeb;
					Timeg = Convert.ToDouble(label26.Text);
					Timez = Convert.ToDouble(label28.Text);
					Times = Convert.ToDouble(label21.Text);
					Timeb = Convert.ToDouble(label27.Text);
				}


				sec = 1;
				if (textBox25.Text == "")
				{
					min = Convert.ToInt32(textBox13.Text);
				}
				else
				{
					min = Convert.ToInt32(textBox24.Text);
				}


				label4.Text = "00:00";
				label13.Text = "<<Гонка!>>";
				label15.Text = "5/5";
				timer32.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;

				button6.Enabled = true;
				button6.Focus();
			}
		}

		private void timer38_Tick(object sender, EventArgs e)
		{
			sec--;
			label4.Text = Convert.ToString(min) + ":" + Convert.ToString(sec);           //зчитую час гонки який був заданий у настройках





			if (sec == 0)                                                                   //таймер для гонки 4 заїзд
			{
				min--;
				sec = 60;

				if (min == -1 && sec == 60)
				{
					
					
						button6.Enabled = false;
						serialPort1.WriteLine("3"); //пауза
						label69.Text = "Трек виключений";
						label69.BackColor = Color.Red;
						button10.Enabled = true;
						button11.Enabled = false;
						
						timer38.Enabled = false;


					panel6.Visible = true;

						kinetsgonkisound.Play();
						label68.Visible = true;
						textBox20.BackColor = panel1.BackColor;
						textBox20.Visible = true;
						textBox21.BackColor = panel4.BackColor;
						textBox21.Visible = true;
						textBox22.BackColor = panel3.BackColor;
						textBox22.Visible = true;
						textBox23.BackColor = panel5.BackColor;
						textBox29.Visible = true;
						textBox23.Visible = true;
						button9.Visible = true;
						button6.Enabled = false;

						timer32.Enabled = false;
						timer8.Enabled = false;
						label4.Text = "00:00";
						label13.Text = "<<Фініш!>>";

					timer21.Enabled = false;
					timer2.Enabled = false;
					timer4.Enabled = false;
					timer6.Enabled = false;
					timer8.Enabled = false;

					//


					lanes5 = Convert.ToInt32(label75.Text) - lanes1 - lanes3 - lanes4 - lanes2;
					lane2_4 = Convert.ToInt32(label25.Text) - lane2_2 - lane2_5 - lane2_1 - lane2_3;
					lane3_1 = Convert.ToInt32(label17.Text) - lane3_3 - lane3_4 - lane3_2 - lane3_5;
					lane4_3 = Convert.ToInt32(label23.Text) - lane4_4 - lane4_2 - lane4_5 - lane4_1;
					lane5_2 = Convert.ToInt32(label24.Text) - lane5_5 - lane5_1 - lane5_3 - lane5_4;



					number_group.Text = "0";
						
						serialPort1.Close();
						//вивід результату в таблицю
						


				}


			}
		}
				

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
			
		}

        private void timer27_Tick(object sender, EventArgs e)
		{
	
			label17.BackColor = Color.WhiteSmoke;
			timer27.Enabled = false;
		}

		private void timer31_Tick(object sender, EventArgs e)
		{

		}

        private void секToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 1;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void секToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 2;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.Lime;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void секToolStripMenuItem2_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 3;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void секToolStripMenuItem3_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 4;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void секToolStripMenuItem4_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 5;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void секToolStripMenuItem5_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 6;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
			sec = 2;
			
			
		}

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
			
		}

		private void textBox28_TextChanged(object sender, EventArgs e)
		{
			// обмежую активність кнопки ок (button20) коли поля не заповненні
			if (textBox26.Text != "" && textBox27.Text != "" && textBox28.Text != "")
			{
				button20.Enabled = true;
			}
			else
			{
				button20.Enabled = false;
			}
			// неправельне введення тексту
			if (textBox28.Text != "")
			{
				try
				{
					int h = Convert.ToInt32(textBox28.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
					textBox28.Clear();
				}
			}
		}
        private void textBox27_TextChanged(object sender, EventArgs e)
        {
			// обмежую активність кнопки ок (button20) коли поля не заповненні
			if (textBox26.Text != "" && textBox27.Text != "" && textBox28.Text != "")
			{
				button20.Enabled = true;
			}
			else
			{
				button20.Enabled = false;
			}
			// неправельне введення тексту
			if (textBox27.Text != "")
			{
				try
				{
					int g = Convert.ToInt32(textBox27.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
					textBox27.Clear();
				}
			}
		}

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
			// обмежую активність кнопки ок (button20) коли поля не заповненні

			if (textBox26.Text != "" && textBox27.Text != "" && textBox28.Text != "")
			{
				button20.Enabled = true;
			}
			else
			{
				button20.Enabled = false;
			}


			// неправельне введення тексту
			if (textBox26.Text != "")
			{
				try
				{
					int f = Convert.ToInt32(textBox26.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
					textBox26.Clear();
				}
			}
		}

		private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
		{
			if (toolStripTextBox1.Text != "")
			{
				try
				{
					int h = Convert.ToInt32(toolStripTextBox1.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
					toolStripTextBox1.Clear();
				}
			}
		}
        private void toolStripTextBox1_DoubleClick(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = Convert.ToDouble(toolStripTextBox1.Text);
			Settings.Default.deley6_text = toolStripTextBox1.Text;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.Lime;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void timer30_Tick(object sender, EventArgs e)
		{
			
			label23.BackColor = Color.WhiteSmoke;
			timer30.Enabled = false;

		}

		private void timer29_Tick(object sender, EventArgs e)
		{
			
			label25.BackColor = Color.WhiteSmoke;
			timer29.Enabled = false;

		}

		private void timer28_Tick(object sender, EventArgs e)
		{
			
			label24.BackColor = Color.WhiteSmoke;
			timer28.Enabled = false;
		}

		private void label134_Click(object sender, EventArgs e)
		{

		}

		private void timer33_Tick(object sender, EventArgs e)
		{
			if (serialPort1.IsOpen == false)
			{
				serialPort1.Open();
			}


			serialPort1.WriteLine("4");
			label69.Text = "Трек включений";
			label69.BackColor = Color.Green;
			button10.Enabled = false;

			button11.Enabled = true;

			if (number_group.Text == "0")   // кнопка продовжити для 1 заїзду
			{

				timer2.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}

			if (number_group.Text == "1")   // кнопка продовжити для 2 заїзду
			{

				timer4.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}

			if (number_group.Text == "2")   // кнопка продовжити для 3 заїзду
			{

				timer6.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}

			if (number_group.Text == "3")   // кнопка продовжити для 3 заїзду
			{

				timer8.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}
			if (number_group.Text == "4")   // кнопка продовжити для 3 заїзду
			{

				timer38.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}
			timer33.Enabled = false;
		}

		private void timer35_Tick(object sender, EventArgs e)
		{
			if (label13.Text != "Тренування!")
			{
				dataGridView3.Rows.Add(label17.Text + "," + 6);
				dataGridView3.Rows.Add(label24.Text + "," + 5);
				dataGridView3.Rows.Add(label23.Text + "," + 4);
				dataGridView3.Rows.Add(label25.Text + "," + 3);

				dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);






				//червона

				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
				{
					panel1.Location = new Point(7, 213);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
					{

						panel1.Location = new Point(7, 358);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(7, 502);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(7, 645);
							}

						}
					}

				}



				// зелена

				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
				{
					panel3.Location = new Point(7, 213);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
					{

						panel3.Location = new Point(7, 358);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(7, 502);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(7, 645);
							}

						}
					}

				}

				// синя

				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
				{
					panel4.Location = new Point(7, 213);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
					{

						panel4.Location = new Point(7, 358);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(7, 502);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(7, 645);
							}

						}
					}

				}

				//жовта 



				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
				{
					panel5.Location = new Point(7, 213);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
					{

						panel5.Location = new Point(7, 358);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(7, 502);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(7, 645);
							}


						}
					}

				}
			}
			timer26.Enabled = true;
			timer35.Enabled = false;
		}

		private void dataGridView3_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			if (double.Parse(e.CellValue1.ToString()) > double.Parse(e.CellValue2.ToString()))
			{
				e.SortResult = 1;
			}
			else if (double.Parse(e.CellValue1.ToString()) < double.Parse(e.CellValue2.ToString()))
			{
				e.SortResult = -1;
			}
			else
			{
				e.SortResult = 0;
			}
			e.Handled = true;
		}

		private void textBox22_TextChanged(object sender, EventArgs e)
		{
			// неправельне введення тексту
			if (textBox22.Text != "")
			{
				try
				{
					int n = Convert.ToInt32(textBox22.Text);
				}
				catch (System.FormatException)
				{
					MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
					textBox22.Clear();
				}
			}
		}

		private void timer32_Tick(object sender, EventArgs e)
		{
			// алгоритм прогнозу
			if(label72.Visible == false)
            {

            
			if (label15.Text == "1/4")
			{
				prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label17.Text);
				label54.Text = Convert.ToString(prognoz1);
				label54.Text = string.Format("{0:F2}", prognoz1);


				prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label24.Text);
				label57.Text = Convert.ToString(prognoz2);
				label57.Text = string.Format("{0:F2}", prognoz2);


				prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label23.Text);
				label58.Text = Convert.ToString(prognoz3);
				label58.Text = string.Format("{0:F2}", prognoz3);


				prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label25.Text);
				label118.Text = Convert.ToString(prognoz4);
				label118.Text = string.Format("{0:F2}", prognoz4);


			}
			else
			{
				if (label15.Text == "2/4")
				{
					prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label17.Text);
					label54.Text = Convert.ToString(prognoz2);
					label54.Text = string.Format("{0:F2}", prognoz2);


					prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label24.Text);
					label57.Text = Convert.ToString(prognoz4);
					label57.Text = string.Format("{0:F2}", prognoz4);


					prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label23.Text);
					label58.Text = Convert.ToString(prognoz1);
					label58.Text = string.Format("{0:F2}", prognoz1);


					prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label25.Text);
					label118.Text = Convert.ToString(prognoz3);
					label118.Text = string.Format("{0:F2}", prognoz3);


				}
				else
				{
					if (label15.Text == "3/4")
					{
						prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label17.Text);
						label54.Text = Convert.ToString(prognoz4);
						label54.Text = string.Format("{0:F2}", prognoz4);


						prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label24.Text);
						label57.Text = Convert.ToString(prognoz3);
						label57.Text = string.Format("{0:F2}", prognoz3);


						prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label23.Text);
						label58.Text = Convert.ToString(prognoz2);
						label58.Text = string.Format("{0:F2}", prognoz2);


						prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label25.Text);
						label118.Text = Convert.ToString(prognoz1);
						label118.Text = string.Format("{0:F2}", prognoz1);


					}
					else
					{
							if (label15.Text == "4/4")
							{
								prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label17.Text);
								label54.Text = Convert.ToString(prognoz3);
								label54.Text = string.Format("{0:F2}", prognoz3);


								prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label24.Text);
								label57.Text = Convert.ToString(prognoz1);
								label57.Text = string.Format("{0:F2}", prognoz1);


								prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label23.Text);
								label58.Text = Convert.ToString(prognoz4);
								label58.Text = string.Format("{0:F2}", prognoz4);


								prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label25.Text);
								label118.Text = Convert.ToString(prognoz2);
								label118.Text = string.Format("{0:F2}", prognoz2);

							}
						}
					}
				}
            }
            else
            {








				if (label15.Text == "1/5")
				{
					prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label17.Text);
					label54.Text = Convert.ToString(prognoz1);
					label54.Text = string.Format("{0:F2}", prognoz1);


					prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label24.Text);
					label57.Text = Convert.ToString(prognoz2);
					label57.Text = string.Format("{0:F2}", prognoz2);


					prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label23.Text);
					label58.Text = Convert.ToString(prognoz3);
					label58.Text = string.Format("{0:F2}", prognoz3);


					prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label25.Text);
					label118.Text = Convert.ToString(prognoz4);
					label118.Text = string.Format("{0:F2}", prognoz4);

					prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label75.Text);
					label90.Text = Convert.ToString(prognoz5);
					label90.Text = string.Format("{0:F2}", prognoz5);


				}
				else
				{


					if (label15.Text == "2/5")
					{
						prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label17.Text);
						label54.Text = Convert.ToString(prognoz5);
						label54.Text = string.Format("{0:F2}", prognoz5);


						prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label24.Text);
						label57.Text = Convert.ToString(prognoz4);
						label57.Text = string.Format("{0:F2}", prognoz4);


						prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label23.Text);
						label58.Text = Convert.ToString(prognoz1);
						label58.Text = string.Format("{0:F2}", prognoz1);


						prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label25.Text);
						label118.Text = Convert.ToString(prognoz3);
						label118.Text = string.Format("{0:F2}", prognoz3);

						prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label75.Text);
						label90.Text = Convert.ToString(prognoz2);
						label90.Text = string.Format("{0:F2}", prognoz2);
					}
					else
					{
						if (label15.Text == "3/5")
						{
							prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label17.Text);
							label54.Text = Convert.ToString(prognoz2);
							label54.Text = string.Format("{0:F2}", prognoz2);


							prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label24.Text);
							label57.Text = Convert.ToString(prognoz3);
							label57.Text = string.Format("{0:F2}", prognoz3);


							prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label23.Text);
							label58.Text = Convert.ToString(prognoz5);
							label58.Text = string.Format("{0:F2}", prognoz5);


							prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label25.Text);
							label118.Text = Convert.ToString(prognoz1);
							label118.Text = string.Format("{0:F2}", prognoz1);

							prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label75.Text);
							label90.Text = Convert.ToString(prognoz4);
							label90.Text = string.Format("{0:F2}", prognoz4);
						}
						else
						{
							if (label15.Text == "4/5")
							{
								prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label17.Text);
								label54.Text = Convert.ToString(prognoz4);
								label54.Text = string.Format("{0:F2}", prognoz4);


								prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label24.Text);
								label57.Text = Convert.ToString(prognoz1);
								label57.Text = string.Format("{0:F2}", prognoz1);


								prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label23.Text);
								label58.Text = Convert.ToString(prognoz2);
								label58.Text = string.Format("{0:F2}", prognoz2);


								prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label25.Text);
								label118.Text = Convert.ToString(prognoz5);
								label118.Text = string.Format("{0:F2}", prognoz5);

								prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label75.Text);
								label90.Text = Convert.ToString(prognoz3);
								label90.Text = string.Format("{0:F2}", prognoz3);
                            }
                            else
                            {
								if (label15.Text == "5/5")
								{
									prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label17.Text);
									label54.Text = Convert.ToString(prognoz3);
									label54.Text = string.Format("{0:F2}", prognoz3);


									prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label24.Text);
									label57.Text = Convert.ToString(prognoz5);
									label57.Text = string.Format("{0:F2}", prognoz5);


									prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label23.Text);
									label58.Text = Convert.ToString(prognoz4);
									label58.Text = string.Format("{0:F2}", prognoz4);


									prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label25.Text);
									label118.Text = Convert.ToString(prognoz2);
									label118.Text = string.Format("{0:F2}", prognoz2);

									prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label75.Text);
									label90.Text = Convert.ToString(prognoz1);
									label90.Text = string.Format("{0:F2}", prognoz1);
								}
							}
						}
					}
				}











			}
		}

		public void timer41_Tick(object sender, EventArgs e)
		{
			int value;
			if(label72.Visible == false)
            {


				switch (Convert.ToInt32(textBox13.Text))
				{
					case 1:
						{
							if (label15.Text == "1/4")
							{
								value = (60 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (60 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (60 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 2:
						{
							if (label15.Text == "1/4")
							{
								value = (120 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (120 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (120 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 3:
						{
							if (label15.Text == "1/4")
							{
								value = (180 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (180 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (180 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 4:
						{
							if (label15.Text == "1/4")
							{
								value = (240 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (240 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (240 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 5:
						{
							if (label15.Text == "1/4")
							{
								value = (300 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (300 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (300 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 6:
						{
							if (label15.Text == "1/4")
							{
								value = (360 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (360 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (360 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 7:
						{
							if (label15.Text == "1/4")
							{
								value = (420 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (420 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (420 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 8:
						{
							if (label15.Text == "1/4")
							{
								value = (480 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (480 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (480 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 9:
						{
							if (label15.Text == "1/4")
							{
								value = (540 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (540 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (540 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 10:
						{
							if (label15.Text == "1/4")
							{
								value = (600 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (600 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (600 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 11:
						{
							if (label15.Text == "1/4")
							{
								value = (660 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (660 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (660 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 12:
						{
							if (label15.Text == "1/4")
							{
								value = (720 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (720 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (720 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 13:
						{
							if (label15.Text == "1/4")
							{
								value = (780 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (780 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (780 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 14:
						{
							if (label15.Text == "1/4")
							{
								value = (840 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (840 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (840 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 15:
						{
							if (label15.Text == "1/4")
							{
								value = (900 * 3) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/4")
								{
									value = (900 * 2) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/4")
									{
										value = (900 * 1) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/4")
										{
											value = sec;
											textBox38.Text = Convert.ToString(value);
										}

									}
								}
							}

							break;
						}
					case 0:
						{
							value = sec;
							textBox38.Text = Convert.ToString(value);
							break;
						}

					default:
						{
							value = 0;
							textBox38.Text = Convert.ToString(value);
							break;
						}

                }





            }
            else
            {




				// для простоя


				switch (Convert.ToInt32(textBox13.Text))
				{
					case 1:
						{
							if (label15.Text == "1/5")
							{
								value = (60 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (60 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (60 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (60 * 1) + sec;
											value = sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 2:
						{
							if (label15.Text == "1/5")
							{
								value = (120 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (120 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (120 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (120 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 3:
						{
							if (label15.Text == "1/5")
							{
								value = (180 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (180 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (180 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (180 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 4:
						{
							if (label15.Text == "1/5")
							{
								value = (240 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (240 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (240 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (240 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 5:
						{
							if (label15.Text == "1/5")
							{
								value = (300 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (300 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (300 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (300 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 6:
						{
							if (label15.Text == "1/5")
							{
								value = (360 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (360 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (360 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (360 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 7:
						{
							if (label15.Text == "1/5")
							{
								value = (420 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (420 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (420 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (420 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 8:
						{
							if (label15.Text == "1/5")
							{
								value = (480 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (480 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (480 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (480 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 9:
						{
							if (label15.Text == "1/5")
							{
								value = (540 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (540 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (540 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (540 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 10:
						{
							if (label15.Text == "1/5")
							{
								value = (600 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (600 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (600 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (600 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 11:
						{
							if (label15.Text == "1/5")
							{
								value = (660 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (660 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (660 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (660 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 12:
						{
							if (label15.Text == "1/5")
							{
								value = (720 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (720 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (720 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (720 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 13:
						{
							if (label15.Text == "1/5")
							{
								value = (780 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (780 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (780 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (780 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 14:
						{
							if (label15.Text == "1/5")
							{
								value = (840 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (840 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (840 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (840 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 15:
						{
							if (label15.Text == "1/5")
							{
								value = (900 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "2/5")
								{
									value = (900 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "3/5")
									{
										value = (900 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "4/5")
										{
											value = (900 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
                                        }
                                        else
                                        {
											if (label15.Text == "5/5")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}

									}
								}
							}

							break;
						}
					case 0:
						{
							value = sec;
							textBox38.Text = Convert.ToString(value);
							break;
						}

					default:
						{
							value = 0;
							textBox38.Text = Convert.ToString(value);
							break;
						}

				}


			}

		}

		private void timer24_Tick(object sender, EventArgs e)
		{

			time_to_traning_secs--;
			label4.Text = Convert.ToString(time_to_traning_min) + ":" + Convert.ToString(time_to_traning_secs); //зчитую час гонки який був заданий у настройках





			if (time_to_traning_secs == 0)                                               //таймер для гонки 1 перший заїзд
			{
				time_to_traning_min--;
				time_to_traning_secs = 60;

				if (time_to_traning_min == -1 && time_to_traning_secs == 60)
				{


					if (Convert.ToInt32(textBox28.Text) > traning_number_group) {
						serialPort1.Write("3");
						perehid.Play();
						serialPort1.WriteLine("3");//пауза
						label69.Text = "Трек виключений";
						label69.BackColor = Color.Red;
						timer24.Enabled = false;
						timer25.Enabled = true;


						label13.Text = "Перехід!";

						button6.Enabled = false;


						traning_number_group = traning_number_group + 1;
						label15.Text = traning_number_group + "/" + textBox28.Text;

						label17.Text = "0";
						label24.Text = "0";
						label23.Text = "0";
						label25.Text = "0";

						label18.Text = "00,000";
						label22.Text = "00,000";
						label19.Text = "00,000";
						label20.Text = "00,000";
						label16.Text = "999";
						label29.Text = "00,000";
						label30.Text = "00,000";
						label31.Text = "00,000";
						label32.Text = "00,000";
						label42.Text = "999";
						label35.Text = "00,000";
						label36.Text = "00,000";
						label37.Text = "00,000";
						label34.Text = "00,000";
						label43.Text = "999";
						label38.Text = "00,000";
						label39.Text = "00,000";
						label40.Text = "00,000";
						label41.Text = "00,000";
						label44.Text = "999";
						label78.Text = "00,000";
						label77.Text = "00,000";
						label76.Text = "00,000";

						label79.Text = "00,000";
						label80.Text = "00,000";
						label81.Text = "00,000";

						label82.Text = "00,000";
						label83.Text = "00,000";
						label84.Text = "00,000";

						label85.Text = "00,000";
						label86.Text = "00,000";
						label87.Text = "00,000";
                    }
                    else
                    {
						serialPort1.WriteLine("3");//пауза
						label13.Text = "Тренуванян завершено!";
						label13.Location = new Point(575, 66);
						timer24.Enabled = false;
						timer25.Enabled = false;
					}


				}
			}
		}

		private void button17_Click(object sender, EventArgs e)// старт тренування
		{
			button17.Visible = false;
			button18.Visible = true;
			
			serialPort1.Open();
			serialPort1.WriteLine("4");
			timer24.Enabled = true;
			timer17.Enabled = true;
			timer15.Enabled = true;
			timer11.Enabled = true;
			timer16.Enabled = true;

			if(label13.Text == "Тренування!")
            {
				button6.Visible = true;
				button6.Focus();
            }
            else
            {
				button6.Visible = false;
            }
		}
		
		private void timer11_Tick(object sender, EventArgs e)
		{


			Time += 0.0003 * 53;                   //timer на час кола
			label21.Text = string.Format("{0:F3}", Time);       //timer на час кола 
			
			


		}



		private void label16_Click(object sender, EventArgs e)
		{

		}

		private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
		textBox15.AppendText(serialPort1.ReadLine());
			Thread.Sleep(100);

		}


		int n;

		private void button2_Click(object sender, EventArgs e)
		{
			fivesecond.SoundLocation = "music/fivesecond.wav";
			fivesecond.Load();
			//serialPort1.BaudRate = 9600;
			serialPort1.PortName = comboBox1.Text;
			button2.Visible = false;
			button1.Visible = true;
			comboBox1.Visible = false;
			label49.Visible = false;
			timer21.Enabled = true;
			serialPort1.Open();
			serialPort1.WriteLine("3");
			serialPort1.Close();
			label69.Visible = true;
			button10.Visible = true;
			button11.Visible = true;
			button12.Visible = true;
			Settings.Default.zase4ka_comPort = comboBox1.Text;
			Settings.Default.Save();

			groupBox1.Visible = true;
			checkBox1.Visible = true;

			// цикл для підтягування спортсменів за результатами лаптайму




			button4.Visible = false;
		}

		void SaveTable(DataGridView Whats_save)
		{
			if (textBox25.Text == "")
			{




				

				Microsoft.Office.Interop.Excel.Application Excel_Lapp = new Microsoft.Office.Interop.Excel.Application();
				Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook_lap;
				Microsoft.Office.Interop.Excel.Worksheet ExcelWorkShee_lap;
			
				//Книга.
				ExcelWorkBook_lap = Excel_Lapp.Workbooks.Add(System.Reflection.Missing.Value);
				//Таблица.
				ExcelWorkShee_lap = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook_lap.Worksheets.get_Item(1);



				for (int j = 0; j < dataGridView1.ColumnCount; j++)
					Excel_Lapp.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					for (int j = 0; j < dataGridView1.ColumnCount; j++)
					{
						Excel_Lapp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
					}
				}
				// Excel_Lapp.Visible = true;
				Excel_Lapp.UserControl = true;
				Excel_Lapp.AlertBeforeOverwriting = true;
				//  ExcelWorkBook_laptime.SaveAs(path);
				Excel_Lapp.Visible = true;

				// ExcelWorkBook.Close();

				// GC.Collect();






















				
			}
			else// запис в ексель результату фіналу
			{

				Microsoft.Office.Interop.Excel.Application Excel_Lapp_TIME = new Microsoft.Office.Interop.Excel.Application();
				Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook_lap_TIME;
				Microsoft.Office.Interop.Excel.Worksheet ExcelWorkShee_lap_TIME;

				//Книга.
				ExcelWorkBook_lap_TIME = Excel_Lapp_TIME.Workbooks.Add(System.Reflection.Missing.Value);
				//Таблица.
				ExcelWorkShee_lap_TIME = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook_lap_TIME.Worksheets.get_Item(1);



				for (int j = 0; j < dataGridView2.ColumnCount; j++)
					Excel_Lapp_TIME.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;

				for (int i = 0; i < dataGridView2.Rows.Count; i++)
				{
					for (int j = 0; j < dataGridView2.ColumnCount; j++)
					{
						Excel_Lapp_TIME.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
					}
				}
				// Excel_Lapp.Visible = true;
				Excel_Lapp_TIME.UserControl = true;
				Excel_Lapp_TIME.AlertBeforeOverwriting = true;
				//  ExcelWorkBook_laptime.SaveAs(path);
				Excel_Lapp_TIME.Visible = true;

				// ExcelWorkBook.Close();

				// GC.Collect();



				//string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Finaly_of_racing.xlsx";

				//Excel.Application excel_lapp_final = new Excel.Application();
				//Excel.Workbook workbooks_final = excel_lapp_final.Workbooks.Add();
				//Excel.Worksheet worksheet_final = workbooks_final.ActiveSheet;

				//for (int i = 1; i < Whats_save.RowCount + 1; i++)
				//{
				//	for (int j = 1; j < Whats_save.ColumnCount + 1; j++)
				//	{
				//		worksheet_final.Rows[i].Columns[j] = Whats_save.Rows[i - 1].Cells[j - 1].Value;

				//	}
				//}
				//excel_lapp_final.AlertBeforeOverwriting = false;
				//workbooks_final.SaveAs(path);
				//workbooks_final.Close();
			}



		}

		private void button8_Click(object sender, EventArgs e)
		{


			// обявляю фініш простоям
			if(prostoi != "finish")
            {
				prostoi = "finish";
            }
            else
            {
				if (prostoi == "finish" && prostoi2 != "finish")
                {
					prostoi2 = "finish";

                }
                else
                {
					if (prostoi == "finish" && prostoi2 == "finish" && prostoi3 != "finish")
					{
						//prostoi3 = "finish";

					}
				}

			}
		




			//обнуляю прогноз після зміни учасників
			prognoz1 = 0;
			prognoz2 = 0;
			prognoz3 = 0;
			prognoz4 = 0;
			prognoz5 = 0;
			masuv = 0;
			kola = 0;
			seredniychas = 0;
			prognoz = 0;
			label54.Text = "0";
			label57.Text = "0";
			label58.Text = "0";
			label118.Text = "0";
			label8.Text = "0";
			label56.Text = "0";
			label117.Text = "0";
			label119.Text = "0";

			label131.Text = "0";
			label125.Text = "0";
			label132.Text = "0";
			label126.Text = "0";

			label133.Text = "0";
			label127.Text = "0";
			label134.Text = "0";
			label128.Text = "0";
			label90.Text = "0";
			label75.Text = "0";




			if (label67.Text == "1" && label13.Text == "<<Фініш!>>")
			{
				label13.Text = "Заїзди завершено!";
				button6.Visible = false;
			}


			if (label13.Text == "Заїзди завершено!")
			{
				button6.Enabled = false;
				button8.Visible = false;

				if (textBox24.Text != "")  //алгоритм для показу кнопки (Фінал)
				{
					button14.Visible = true;
				}

			}
			else
			{
				button6.Enabled = true;
			}

			button12.Enabled = true;
			button1.Focus();
			timer21.Enabled = true;
			SaveTable(dataGridView1);
		}

		private void timer10_Tick(object sender, EventArgs e)
		{
			
			if (Convert.ToDouble(label18.Text) > delay)
			{
				i++;                                            //добавляю кола 1 доріці
				label17.Text = Convert.ToString(i);







				// алгоритм прогнозу
				if (label72.Visible == false)
				{


					if (label15.Text == "1/4")
					{
						kola = Convert.ToDouble(label18.Text);
						masuv = Convert.ToDouble(label8.Text);
						seredniychas1 = Convert.ToDouble(label54.Text);
						kola = (kola + masuv);
						label8.Text = Convert.ToString(kola);
						seredniychas1 = kola / Convert.ToDouble(label17.Text);

					}
					else
					{
						if (label15.Text == "2/4")
						{
							kola = Convert.ToDouble(label18.Text);
							masuv = Convert.ToDouble(label8.Text);
							seredniychas2 = Convert.ToDouble(label54.Text);
							kola = (kola + masuv);
							label8.Text = Convert.ToString(kola);
							seredniychas2 = kola / Convert.ToDouble(label17.Text);
						}
						else
						{
							if (label15.Text == "3/4")
							{
								kola = Convert.ToDouble(label18.Text);
								masuv = Convert.ToDouble(label8.Text);
								seredniychas4 = Convert.ToDouble(label54.Text);
								kola = (kola + masuv);
								label8.Text = Convert.ToString(kola);
								seredniychas4 = kola / Convert.ToDouble(label17.Text);
							}
							else
							{
								if (label15.Text == "4/4")
								{
									kola = Convert.ToDouble(label18.Text);
									masuv = Convert.ToDouble(label8.Text);
									seredniychas3 = Convert.ToDouble(label54.Text);
									kola = (kola + masuv);
									label8.Text = Convert.ToString(kola);
									seredniychas3 = kola / Convert.ToDouble(label17.Text);
									if (label13.Text == "<<Фініш!>>")
									{
										masuv = 0;
										kola = 0;
										seredniychas = 0;
										prognoz = 0;
									}
								}
							}
						}
					}
                }
                else


                {


					if (label15.Text == "1/5")
					{
						kola = Convert.ToDouble(label18.Text);
						masuv = Convert.ToDouble(label8.Text);
						seredniychas1 = Convert.ToDouble(label54.Text);
						kola = (kola + masuv);
						label8.Text = Convert.ToString(kola);
						seredniychas1 = kola / Convert.ToDouble(label17.Text);

					}
					else
					{
						if (label15.Text == "2/5")
						{
							kola = Convert.ToDouble(label18.Text);
							masuv = Convert.ToDouble(label8.Text);
							seredniychas5 = Convert.ToDouble(label54.Text);
							kola = (kola + masuv);
							label8.Text = Convert.ToString(kola);
							seredniychas5 = kola / Convert.ToDouble(label17.Text);
						}
						else
						{
							if (label15.Text == "3/5")
							{
								kola = Convert.ToDouble(label18.Text);
								masuv = Convert.ToDouble(label8.Text);
								seredniychas2 = Convert.ToDouble(label54.Text);
								kola = (kola + masuv);
								label8.Text = Convert.ToString(kola);
								seredniychas2 = kola / Convert.ToDouble(label17.Text);
							}
							else
							{
								if (label15.Text == "4/5")
								{
									kola = Convert.ToDouble(label18.Text);
									masuv = Convert.ToDouble(label8.Text);
									seredniychas4 = Convert.ToDouble(label54.Text);
									kola = (kola + masuv);
									label8.Text = Convert.ToString(kola);
									seredniychas4 = kola / Convert.ToDouble(label17.Text);

                                }
                                else
                                {
									if (label15.Text == "5/5")
									{
										kola = Convert.ToDouble(label18.Text);
										masuv = Convert.ToDouble(label8.Text);
										seredniychas3 = Convert.ToDouble(label54.Text);
										kola = (kola + masuv);
										label8.Text = Convert.ToString(kola);
										seredniychas3 = kola / Convert.ToDouble(label17.Text);


										if (label13.Text == "<<Фініш!>>")
										{
											masuv = 0;
											kola = 0;
											seredniychas = 0;
											prognoz = 0;
										}







									}





								}



									
								
							}
						}
					}



				}

















				// підсвітка під час кола
				label17.BackColor = Color.LawnGreen;
				label17.BackColor = Color.LawnGreen;
				timer27.Enabled = true;
			}


			
			timer10.Enabled = false;
		}

		private void timer7_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

			button6.Enabled = false;

			if (label4.Text == "0:3")
			{
				timetostartsound.Play();
			}


			if (label4.Text == "0:16") //залишилось 15 секунд
			{
				sekynd.Play();
			}

			if (secs > 60)
			{
				mins++;
				secs = secs - 60;

			}
			if (secs == -1)
			{

				mins--;
				secs = 60;
			}

			if (secs == 60 && mins == -1)
			{
				serialPort1.Open();
				serialPort1.WriteLine("4"); //продовжити 
				label69.Text = "Трек включений";
				label69.BackColor = Color.Green;
				button10.Enabled = false;
				button11.Enabled = true;

				timer7.Enabled = false;
				timer8.Enabled = true;




				if (label72.Visible == false)
				{
					Time = Convert.ToDouble(label63.Text);
					Timeg = Convert.ToDouble(label64.Text);
					Timez = Convert.ToDouble(label65.Text);
					Times = Convert.ToDouble(label66.Text);
				}
				else
				{
					Time = Timeb;
					Timeg = Convert.ToDouble(label26.Text);
					Timez = Convert.ToDouble(label28.Text);
					Times = Convert.ToDouble(label21.Text);
					Timeb = Convert.ToDouble(label27.Text);
				}


				sec = 1;
				if (textBox25.Text == "")
				{
					min = Convert.ToInt32(textBox13.Text);
				}
				else
				{
					min = Convert.ToInt32(textBox24.Text);
				}

				//для простою
				if (label72.Visible == false)
				{
					label4.Text = "00:00";
					label13.Text = "<<Гонка!>>";
					label15.Text = "4/4";
					timer32.Enabled = true;
					timer17.Enabled = true;
					timer11.Enabled = true;
					timer15.Enabled = true;
					timer16.Enabled = true;

					button6.Enabled = true;
					button6.Focus();
                }
                else
                {
					label4.Text = "00:00";
					label13.Text = "<<Гонка!>>";
					label15.Text = "4/5";
					timer32.Enabled = true;
					timer17.Enabled = true;
					timer11.Enabled = true;
					timer15.Enabled = true;
					timer16.Enabled = true;

					button6.Enabled = true;
					button6.Focus();
				}
			}
		}



		private void timer8_Tick(object sender, EventArgs e)
		{

			sec--;
			label4.Text = Convert.ToString(min) + ":" + Convert.ToString(sec);           //зчитую час гонки який був заданий у настройках





			if (sec == 0)                                                                   //таймер для гонки 4 заїзд
			{
				min--;
				sec = 60;

				if (min == -1 && sec == 60)
				{
					if (label72.Visible == false)
					{
						button6.Enabled = false;
						serialPort1.WriteLine("3"); //пауза
						label69.Text = "Трек виключений";
						label69.BackColor = Color.Red;
						button10.Enabled = true;
						button11.Enabled = false;



						//
						lanes2 = Convert.ToInt32(label24.Text) - lanes1 - lanes4 - lanes3;
						lane2_4 = Convert.ToInt32(label25.Text) - lane2_1 - lane2_2 - lane2_3;
						lane3_1 = Convert.ToInt32(label17.Text) - lane3_2 - lane3_3 - lane3_4;
						lane4_3 = Convert.ToInt32(label23.Text) - lane4_1 - lane4_2 - lane4_4;



						kinetsgonkisound.Play();
						label68.Visible = true;
						textBox20.BackColor = panel1.BackColor;
						textBox20.Visible = true;
						textBox21.BackColor = panel4.BackColor;
						textBox21.Visible = true;
						textBox22.BackColor = panel3.BackColor;
						textBox22.Visible = true;
						textBox23.BackColor = panel5.BackColor;
						textBox23.Visible = true;
						button9.Visible = true;
						button6.Enabled = false;

						timer32.Enabled = false;
						timer8.Enabled = false;
						label4.Text = "00:00";
						label13.Text = "<<Фініш!>>";

						panel6.Visible = true;

						number_group.Text = "0";

						serialPort1.Close();
                        //вивід результату в таблицю
                    }
                    else
                    {

						perehid.Play();
						serialPort1.WriteLine("3");//пауза
						serialPort1.Close();
						label69.Text = "Трек виключений";
						label69.BackColor = Color.Red;
						button10.Enabled = true;
						button11.Enabled = false;
						timer8.Enabled = false;
						label4.Text = "00:00";
						secs = Convert.ToInt32(textBox14.Text);
						mins = 0;
						timer37.Enabled = true;
						label13.Text = "<<Перехід!>>";
						button6.Enabled = false;

						string value1, value2, value3, value4, value5; // перемінні для кіл

						string lane1, lane2, lane3, lane4, lane5; // перемінні для імя


						//перехід між доріжками
						timer32.Enabled = false;

						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;



						//


						lanes2 = Convert.ToInt32(label24.Text) - lanes1 - lanes3 - lanes4;
						lane2_3 = Convert.ToInt32(label23.Text) - lane2_2 - lane2_5 - lane2_1;
						lane3_5 = Convert.ToInt32(label75.Text) - lane3_3 - lane3_4 - lane3_2;
						lane4_1 = Convert.ToInt32(label17.Text) - lane4_4 - lane4_2 - lane4_5;
						lane5_4 = Convert.ToInt32(label25.Text) - lane5_5 - lane5_1 - lane5_3;

						lane1 = label46.Text;
						lane2 = label47.Text;
						lane3 = label72.Text;
						lane4 = label45.Text;
						lane5 = label48.Text;

						label72.Text = lane1;
						label48.Text = lane2;
						label45.Text = lane3;
						label47.Text = lane4;
						label46.Text = lane5;






						value1 = label24.Text;
						value2 = label23.Text;
						value3 = label75.Text;
						value4 = label17.Text;
						value5 = label25.Text;

						label75.Text = value1;
						label25.Text = value2;
						label17.Text = value3;
						label23.Text = value4;
						label24.Text = value5;












						label18.Text = "00,000";
						label22.Text = "00,000";
						label19.Text = "00,000";
						label20.Text = "00,000";
						label16.Text = "999";
						label29.Text = "00,000";
						label30.Text = "00,000";
						label31.Text = "00,000";
						label32.Text = "00,000";
						label42.Text = "999";
						label35.Text = "00,000";
						label36.Text = "00,000";
						label37.Text = "00,000";
						label34.Text = "00,000";
						label43.Text = "999";
						label38.Text = "00,000";
						label39.Text = "00,000";
						label40.Text = "00,000";
						label41.Text = "00,000";
						label44.Text = "999";
















						//сортування результату
						dataGridView3.Rows.Add(label17.Text + "," + 6);
						dataGridView3.Rows.Add(label24.Text + "," + 5);
						dataGridView3.Rows.Add(label23.Text + "," + 4);
						dataGridView3.Rows.Add(label25.Text + "," + 3);

						dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);



						//червона

						if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
						{
							panel1.Location = new Point(7, 213);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(7, 358);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(7, 502);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
									{

										panel1.Location = new Point(7, 645);
									}

								}
							}

						}



						// зелена

						if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
						{
							panel3.Location = new Point(7, 213);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(7, 358);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(7, 502);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
									{

										panel3.Location = new Point(7, 645);
									}

								}
							}

						}

						// синя

						if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
						{
							panel4.Location = new Point(7, 213);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(7, 358);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(7, 502);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
									{

										panel4.Location = new Point(7, 645);
									}

								}
							}

						}

						//жовта 



						if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
						{
							panel5.Location = new Point(7, 213);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(7, 358);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(7, 502);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
									{

										panel5.Location = new Point(7, 645);
									}


								}
							}

						}


						timer26.Enabled = true;


						number_group.Text = "4";

					}


				}



				


			}


		}

		private void timer9_Tick(object sender, EventArgs e)
		{
			timer19.Enabled = true;

			


			switch (Convert.ToInt32(textBox15.Text))
			{

				case 01:

					{
						
						
						i = Convert.ToInt32(label17.Text);          //червона доріжка
						timer10.Enabled = true;
						timer11.Enabled = false;
						label18.Text = label21.Text;
						Time = 0;
						timer11.Enabled = true;
						timer35.Enabled = true;
						
				









						if (label13.Text == "Тренування!" || label13.Text == "<<Вільні тренування!>>")  // алгоритм для часу кола для тренування червона доріжка
						{

							textBox15.Text = "0";

							




								if (Convert.ToDouble(label18.Text) > delay)
								{ // якщо час кола швидший за 2 секунди він не враховується червона доріжка
									label78.Text = label77.Text;
									label77.Text = label76.Text;
									label76.Text = label20.Text;
									label20.Text = label19.Text;
									label19.Text = label22.Text;
									label22.Text = label18.Text;
									label17.Text = Convert.ToString(i);


									if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
									{
										label16.Text = label18.Text;
										best_time.Play();

									}
                            }
                            else
                            {
								label18.Text = "999";
								label16.Text = "999";
								textBox15.Text = "0";
							}
							
						}
						else                             // алгоритм для часу кола для гонок червона доріжка
						{


							textBox15.Text = "0";



							if (Convert.ToDouble(label18.Text) > delay)  // якщо час кола швидший за 2 секунди він не враховується червона доріжка
							{
								label20.Text = label19.Text;
								label19.Text = label22.Text;
								label22.Text = label18.Text;
								label17.Text = Convert.ToString(i);




								if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
								{
									label16.Text = label18.Text;


								}
                            }
                            else
                            {
								button6.PerformClick();
								MessageBox.Show("Щось пішло не так!! Перевірте модель на 1 доріжці!");
							}
						}
					
						break;
					}
				case 010:
					{
						Thread.Sleep(100);
						textBox15.Text = "0";
						c = Convert.ToInt32(label24.Text);
						timer13.Enabled = true;
						timer17.Enabled = false;
						label29.Text = label27.Text;
						Timez = 0;
						timer17.Enabled = true;


						timer35.Enabled = true;





						if (label13.Text == "Тренування!" || label13.Text == "<<Вільні тренування!>>")     // алгоритм для часу кола для тренування зеленої доріжка
						{
							

							if (Convert.ToDouble(label29.Text) > delay)
							{  // якщо час кола швидший за 2 секунди він не враховується зеленої доріжка
								label79.Text = label80.Text;
								label80.Text = label81.Text;
								label81.Text = label31.Text;
								label31.Text = label32.Text;
								label32.Text = label30.Text;
								label30.Text = label29.Text;
								label24.Text = Convert.ToString(c);
								textBox15.Text = "0";

								if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
								{
									label42.Text = label29.Text;
									best_time.Play();


								}
                            }
                            else
                            {
								label29.Text = "999";
								label42.Text = "999";
								textBox15.Text = "0";
							}
						}
						else                                     // алгоритм для часу кола для гонки зеленої доріжка
						{
							textBox15.Text = "0";


							if (Convert.ToDouble(label29.Text) > delay)
							{  // якщо час кола швидший за 2 секунди він не враховується зеленої доріжка

								label31.Text = label32.Text;
								label32.Text = label30.Text;
								label30.Text = label29.Text;
								label24.Text = Convert.ToString(c);


								if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
								{
									label42.Text = label29.Text;


								}
                            }
                            else
                            {
								button6.PerformClick();
								MessageBox.Show("Щось пішло не так!! Перевірте модель на 2 доріжці!");
							}
						}
						
						break;
					}
				case 011:
					{
						b = Convert.ToInt32(label23.Text);
						timer12.Enabled = true;
						timer15.Enabled = false;
						label37.Text = label26.Text;
						Times = 0;
						timer15.Enabled = true;


						timer35.Enabled = true;


						if (label13.Text == "Тренування!" || label13.Text == "<<Вільні тренування!>>")   // алгоритм для часу кола для тренування синьої доріжка
						{
							

							if (Convert.ToDouble(label37.Text) > 2)
							{  // якщо час кола швидший за 2 секунди він не враховується синьої доріжка
								label82.Text = label83.Text;
								label83.Text = label84.Text;
								label84.Text = label35.Text;
								label35.Text = label36.Text;
								label36.Text = label34.Text;
								label34.Text = label37.Text;
								label23.Text = Convert.ToString(b);
								textBox15.Text = "0";


								if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
								{
									label43.Text = label37.Text;
									best_time.Play();

								}
                            }
                            else
                            {
								label37.Text = "999";
								label43.Text = "999";
								textBox15.Text = "0";
							}
						}
						else                                        // алгоритм для часу кола для гонки синьої доріжка
						{
							textBox15.Text = "0";

							if (Convert.ToDouble(label37.Text) > delay)
							{  // якщо час кола швидший за 2 секунди він не враховується синьої доріжка
								label35.Text = label36.Text;
								label36.Text = label34.Text;
								label34.Text = label37.Text;
								label23.Text = Convert.ToString(b);



								if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
								{
									label43.Text = label37.Text;

								}
                            }
                            else
                            {
								button6.PerformClick();
								MessageBox.Show("Щось пішло не так!! Перевірте модель на 3 доріжці!");
							}
						}
						break;
					}
				case 0100:
					{
						d = Convert.ToInt32(label25.Text);
						timer14.Enabled = true;
						timer16.Enabled = false;
						label38.Text = label28.Text;
						Timeg = 0;
						timer16.Enabled = true;


						timer35.Enabled = true;


						if (label13.Text == "Тренування!" || label13.Text == "<<Вільні тренування!>>")// алгоритм для часу кола для тренування жовтої доріжка

						{
							
							if (Convert.ToDouble(label38.Text) > delay)
							{  // якщо час кола швидший за 2 секунди він не враховується жовтої доріжка
								label85.Text = label86.Text;
								label86.Text = label87.Text;
								label87.Text = label40.Text;
								label40.Text = label41.Text;
								label41.Text = label39.Text;
								label39.Text = label38.Text;
								label25.Text = Convert.ToString(d);
								textBox15.Text = "0";

								if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
								{
									label44.Text = label38.Text;
									best_time.Play();

								}
                            }
                            else
                            {
								label38.Text = "999";
								label44.Text = "999";
								textBox15.Text = "0";
							}
						}
						else                                     // алгоритм для часу кола для Гонки жовтої доріжка
						{
							textBox15.Text = "0";
							if (Convert.ToDouble(label38.Text) > delay)
							{  // якщо час кола швидший за 2 секунди він не враховується жовтої доріжка

								label40.Text = label41.Text;
								label41.Text = label39.Text;
								label39.Text = label38.Text;
								label25.Text = Convert.ToString(d);


								if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
								{
									label44.Text = label38.Text;

								}
                            }
                            else
                            {
								button6.PerformClick();
								MessageBox.Show("Щось пішло не так!! Перевірте модель на 4 доріжці!");
							}
						}
						break;
					}
				case 01111://// зелена + Синя+ Жовта+Червона доріжка
					{
						c = Convert.ToInt32(label24.Text);
						timer13.Enabled = true;
						timer17.Enabled = false;
						label29.Text = label27.Text;
						Timez = 0;
						timer17.Enabled = true;
						label31.Text = label32.Text;
						label32.Text = label30.Text;
						label30.Text = label29.Text;
						label24.Text = Convert.ToString(c);


						b = Convert.ToInt32(label23.Text);
						timer12.Enabled = true;
						timer15.Enabled = false;
						label37.Text = label26.Text;
						Times = 0;
						timer15.Enabled = true;
						label35.Text = label36.Text;
						label36.Text = label34.Text;
						label34.Text = label37.Text;
						label23.Text = Convert.ToString(b);


						d = Convert.ToInt32(label25.Text);
						timer14.Enabled = true;
						timer16.Enabled = false;
						label38.Text = label28.Text;
						Timeg = 0;
						timer16.Enabled = true;
						label40.Text = label41.Text;
						label41.Text = label39.Text;
						label39.Text = label38.Text;
						label25.Text = Convert.ToString(d);

						i = Convert.ToInt32(label17.Text);
						timer10.Enabled = true;
						timer11.Enabled = false;
						label18.Text = label21.Text;
						Time = 0;
						timer11.Enabled = true;
						label20.Text = label19.Text;
						label19.Text = label22.Text;
						label22.Text = label18.Text;
						label17.Text = Convert.ToString(i);
						textBox15.Text = "0";

						if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
						{
							label16.Text = label18.Text;

						}

						if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
						{
							label44.Text = label38.Text;

						}

						if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
						{
							label43.Text = label37.Text;

						}

						if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
						{
							label42.Text = label29.Text;

						}
						break;
					}
				case 01110:         // зелена + Синя+ Жовта доріжка
					{
						c = Convert.ToInt32(label24.Text);
						timer13.Enabled = true;
						timer17.Enabled = false;
						label29.Text = label27.Text;
						Timez = 0;
						timer17.Enabled = true;
						label31.Text = label32.Text;
						label32.Text = label30.Text;
						label30.Text = label29.Text;
						label24.Text = Convert.ToString(c);


						b = Convert.ToInt32(label23.Text);
						timer12.Enabled = true;
						timer15.Enabled = false;
						label37.Text = label26.Text;
						Times = 0;
						timer15.Enabled = true;
						label35.Text = label36.Text;
						label36.Text = label34.Text;
						label34.Text = label37.Text;
						label23.Text = Convert.ToString(b);


						d = Convert.ToInt32(label25.Text);
						timer14.Enabled = true;
						timer16.Enabled = false;
						label38.Text = label28.Text;
						Timeg = 0;
						timer16.Enabled = true;
						label40.Text = label41.Text;
						label41.Text = label39.Text;
						label39.Text = label38.Text;
						label25.Text = Convert.ToString(d);
						textBox15.Text = "0";

						if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
						{
							label44.Text = label38.Text;

						}

						if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
						{
							label43.Text = label37.Text;

						}

						if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
						{
							label42.Text = label29.Text;

						}
						break;
					}
				case 01100:
					{
						i = Convert.ToInt32(label17.Text);          //червона доріжка + Синя + жовта
						timer10.Enabled = true;
						timer11.Enabled = false;
						label18.Text = label21.Text;
						Time = 0;
						timer11.Enabled = true;
						label20.Text = label19.Text;
						label19.Text = label22.Text;
						label22.Text = label18.Text;
						label17.Text = Convert.ToString(i);


						b = Convert.ToInt32(label23.Text);
						timer12.Enabled = true;
						timer15.Enabled = false;
						label37.Text = label26.Text;
						Times = 0;
						timer15.Enabled = true;
						label35.Text = label36.Text;
						label36.Text = label34.Text;
						label34.Text = label37.Text;
						label23.Text = Convert.ToString(b);

						d = Convert.ToInt32(label25.Text);
						timer14.Enabled = true;
						timer16.Enabled = false;
						label38.Text = label28.Text;
						Timeg = 0;
						timer16.Enabled = true;
						label40.Text = label41.Text;
						label41.Text = label39.Text;
						label39.Text = label38.Text;
						label25.Text = Convert.ToString(d);
						textBox15.Text = "0";

						if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
						{
							label44.Text = label38.Text;

						}


						if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
						{
							label43.Text = label37.Text;

						}

						if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
						{
							label16.Text = label18.Text;

						}
						break;
					}
				case 01011:
					{
						i = Convert.ToInt32(label17.Text);          //червона  + Зелена+ Жовта доріжка
						timer10.Enabled = true;
						timer11.Enabled = false;
						label18.Text = label21.Text;
						Time = 0;
						timer11.Enabled = true;
						label20.Text = label19.Text;
						label19.Text = label22.Text;
						label22.Text = label18.Text;
						label17.Text = Convert.ToString(i);


						c = Convert.ToInt32(label24.Text);
						timer13.Enabled = true;
						timer17.Enabled = false;
						label29.Text = label27.Text;
						Timez = 0;
						timer17.Enabled = true;
						label31.Text = label32.Text;
						label32.Text = label30.Text;
						label30.Text = label29.Text;
						label24.Text = Convert.ToString(c);

						d = Convert.ToInt32(label25.Text);
						timer14.Enabled = true;
						timer16.Enabled = false;
						label38.Text = label28.Text;
						Timeg = 0;
						timer16.Enabled = true;
						label40.Text = label41.Text;
						label41.Text = label39.Text;
						label39.Text = label38.Text;
						label25.Text = Convert.ToString(d);
						textBox15.Text = "0";

						if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
						{
							label44.Text = label38.Text;

						}


						if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
						{
							label42.Text = label29.Text;

						}

						if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
						{
							label16.Text = label18.Text;

						}
						break;
					}


				case 01010:                                     // зелена + Синя доріжка
					{
						c = Convert.ToInt32(label24.Text);
						timer13.Enabled = true;
						timer17.Enabled = false;
						label29.Text = label27.Text;
						Timez = 0;
						timer17.Enabled = true;
						label31.Text = label32.Text;
						label32.Text = label30.Text;
						label30.Text = label29.Text;
						label24.Text = Convert.ToString(c);


						b = Convert.ToInt32(label23.Text);
						timer12.Enabled = true;
						timer15.Enabled = false;
						label37.Text = label26.Text;
						Times = 0;
						timer15.Enabled = true;
						label35.Text = label36.Text;
						label36.Text = label34.Text;
						label34.Text = label37.Text;
						label23.Text = Convert.ToString(b);
						textBox15.Text = "0";


						if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
						{
							label43.Text = label37.Text;

						}

						if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
						{
							label42.Text = label29.Text;

						}
						break;
					}
				case 01001: // жовта + Синя доріжка
					{

						d = Convert.ToInt32(label25.Text);
						timer14.Enabled = true;
						timer16.Enabled = false;
						label38.Text = label28.Text;
						Timeg = 0;
						timer16.Enabled = true;
						label40.Text = label41.Text;
						label41.Text = label39.Text;
						label39.Text = label38.Text;
						label25.Text = Convert.ToString(d);



						b = Convert.ToInt32(label23.Text);
						timer12.Enabled = true;
						timer15.Enabled = false;
						label37.Text = label26.Text;
						Times = 0;
						timer15.Enabled = true;
						label35.Text = label36.Text;
						label36.Text = label34.Text;
						label34.Text = label37.Text;
						label23.Text = Convert.ToString(b);
						textBox15.Text = "0";


						if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
						{
							label43.Text = label37.Text;

						}

						if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
						{
							label44.Text = label38.Text;

						}
						break;
					}
				case 01000:
					{
						i = Convert.ToInt32(label17.Text);          //червона доріжка + Синя
						timer10.Enabled = true;
						timer11.Enabled = false;
						label18.Text = label21.Text;
						Time = 0;
						timer11.Enabled = true;
						label20.Text = label19.Text;
						label19.Text = label22.Text;
						label22.Text = label18.Text;
						label17.Text = Convert.ToString(i);


						b = Convert.ToInt32(label23.Text);
						timer12.Enabled = true;
						timer15.Enabled = false;
						label37.Text = label26.Text;
						Times = 0;
						timer15.Enabled = true;
						label35.Text = label36.Text;
						label36.Text = label34.Text;
						label34.Text = label37.Text;
						label23.Text = Convert.ToString(b);
						textBox15.Text = "0";


						if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
						{
							label43.Text = label37.Text;

						}

						if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
						{
							label16.Text = label18.Text;

						}
						break;
					}
				case 0111:
					{
						i = Convert.ToInt32(label17.Text);          //червона + Жовта доріжка
						timer10.Enabled = true;
						timer11.Enabled = false;
						label18.Text = label21.Text;
						Time = 0;
						timer11.Enabled = true;
						label20.Text = label19.Text;
						label19.Text = label22.Text;
						label22.Text = label18.Text;
						label17.Text = Convert.ToString(i);


						d = Convert.ToInt32(label25.Text);
						timer14.Enabled = true;
						timer16.Enabled = false;
						label38.Text = label28.Text;
						Timeg = 0;
						timer16.Enabled = true;
						label40.Text = label41.Text;
						label41.Text = label39.Text;
						label39.Text = label38.Text;
						label25.Text = Convert.ToString(d);
						textBox15.Text = "0";

						if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
						{
							label44.Text = label38.Text;

						}

						if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
						{
							label16.Text = label18.Text;

						}
						break;
					}
				case 0110:
					{
						

						i = Convert.ToInt32(label17.Text);          //червона + зелена доріжка
						c = Convert.ToInt32(label24.Text);

						timer10.Enabled = true;
						timer11.Enabled = false;
						label18.Text = label21.Text;
						Time = 0;
						timer11.Enabled = true;
						label20.Text = label19.Text;
						label19.Text = label22.Text;
						label22.Text = label18.Text;
						label17.Text = Convert.ToString(i);






						timer13.Enabled = true;
						timer17.Enabled = false;
						label29.Text = label27.Text;
						Timez = 0;
						timer17.Enabled = true;
						label31.Text = label32.Text;
						label32.Text = label30.Text;
						label30.Text = label29.Text;
						label24.Text = Convert.ToString(c);
						textBox15.Text = "0";
						

						if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
						{
							label42.Text = label29.Text;
						

						}

						if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
						{
							label16.Text = label18.Text;
							

						}
						
						break;
						
					}
				case 0101:                              // жовта + зелена
					{
						d = Convert.ToInt32(label25.Text);
						c = Convert.ToInt32(label24.Text);
						timer14.Enabled = true;
						timer13.Enabled = true;
						timer16.Enabled = false;
						timer17.Enabled = false;
						label38.Text = label28.Text;
						label29.Text = label27.Text;
						Timeg = 0;
						Timez = 0;
						timer16.Enabled = true;
						timer17.Enabled = true;
						label40.Text = label41.Text;
						label31.Text = label32.Text;
						label41.Text = label39.Text;
						label32.Text = label30.Text;
						label39.Text = label38.Text;
						label30.Text = label29.Text;
						label25.Text = Convert.ToString(d);
						label24.Text = Convert.ToString(c);
						textBox15.Text = "0";



						if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
						{
							label42.Text = label29.Text;

						}

						if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
						{
							label44.Text = label38.Text;

						}
						break;

					}
				case 0:
					{

						break;
					}


				default:




					textBox15.Text = "0";

					if (number_group.Text == "0")   // кнопка пауза для 1 заїзду
					{
						timer2.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
						textBox15.Text = "0";

					}

					if (number_group.Text == "1")   // кнопка пауза для 2 заїзду
					{
						timer4.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
						textBox15.Text = "0";
					}

					if (number_group.Text == "2")   // кнопка пауза для 3 заїзду
					{
						timer6.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
						textBox15.Text = "0";
					}

					if (number_group.Text == "3")   // кнопка пауза для 3 заїзду
					{
						timer8.Enabled = false;
						timer17.Enabled = false;
						timer11.Enabled = false;
						timer15.Enabled = false;
						timer16.Enabled = false;
						button6.Visible = false;
						button7.Visible = true;
						button7.Focus();
						textBox15.Text = "0";
					}

					serialPort1.Close();

					

					MessageBox.Show("Щось пішло не так!! Перевірте моделі!");




					break;

			}

			
		
	
		}
		private void timer12_Tick(object sender, EventArgs e)
		{
			if (Convert.ToDouble(label37.Text) > delay){		//обмеження по часу кола 2 секунда
				b++;                                            //добавляю кола 1 доріці
			label23.Text = Convert.ToString(b);



				if (label72.Visible == false)
				{



					// алгоритм прогнозу
					if (label15.Text == "1/4")
					{



						kola = Convert.ToDouble(label37.Text);
						masuv = Convert.ToDouble(label117.Text);
						seredniychas3 = Convert.ToDouble(label58.Text);
						kola = (kola + masuv);
						label117.Text = Convert.ToString(kola);
						seredniychas3 = kola / Convert.ToDouble(label23.Text);
					}
					else
					{
						if (label15.Text == "2/4")
						{


							//double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label37.Text);
							masuv = Convert.ToDouble(label117.Text);
							seredniychas1 = Convert.ToDouble(label58.Text);
							kola = (kola + masuv);
							label117.Text = Convert.ToString(kola);
							seredniychas1 = kola / Convert.ToDouble(label23.Text);
						}
						else
						{
							if (label15.Text == "3/4")
							{


								//double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label37.Text);
								masuv = Convert.ToDouble(label117.Text);
								seredniychas2 = Convert.ToDouble(label58.Text);
								kola = (kola + masuv);
								label117.Text = Convert.ToString(kola);
								seredniychas2 = kola / Convert.ToDouble(label23.Text);
							}
							else
							{
								if (label15.Text == "4/4")
								{


									//double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label37.Text);
									masuv = Convert.ToDouble(label117.Text);
									seredniychas4 = Convert.ToDouble(label58.Text);
									kola = (kola + masuv);
									label117.Text = Convert.ToString(kola);
									seredniychas4 = kola / Convert.ToDouble(label23.Text);
									if (label13.Text == "<<Фініш!>>")
									{
										masuv = 0;
										kola = 0;
										seredniychas = 0;
										prognoz = 0;
									}
								}

							}
						}
					}
                }
                else
                {



					// алгоритм прогнозу
					if (label15.Text == "1/5")
					{



						kola = Convert.ToDouble(label37.Text);
						masuv = Convert.ToDouble(label117.Text);
						seredniychas3 = Convert.ToDouble(label58.Text);
						kola = (kola + masuv);
						label117.Text = Convert.ToString(kola);
						seredniychas3 = kola / Convert.ToDouble(label23.Text);
					}
					else
					{
						if (label15.Text == "2/5")
						{


							//double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label37.Text);
							masuv = Convert.ToDouble(label117.Text);
							seredniychas1 = Convert.ToDouble(label58.Text);
							kola = (kola + masuv);
							label117.Text = Convert.ToString(kola);
							seredniychas1 = kola / Convert.ToDouble(label23.Text);
						}
						else
						{
							if (label15.Text == "3/5")
							{


								//double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label37.Text);
								masuv = Convert.ToDouble(label117.Text);
								seredniychas5 = Convert.ToDouble(label58.Text);
								kola = (kola + masuv);
								label117.Text = Convert.ToString(kola);
								seredniychas5 = kola / Convert.ToDouble(label23.Text);
							}
							else
							{
								if (label15.Text == "4/5")
								{


									//double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label37.Text);
									masuv = Convert.ToDouble(label117.Text);
									seredniychas2 = Convert.ToDouble(label58.Text);
									kola = (kola + masuv);
									label117.Text = Convert.ToString(kola);
									seredniychas2 = kola / Convert.ToDouble(label23.Text);

								}
								else
								{
									if (label15.Text == "5/5")
									{


										//double masuv, kola, seredniychas, prognoz;
										kola = Convert.ToDouble(label37.Text);
										masuv = Convert.ToDouble(label117.Text);
										seredniychas4 = Convert.ToDouble(label58.Text);
										kola = (kola + masuv);
										label117.Text = Convert.ToString(kola);
										seredniychas4 = kola / Convert.ToDouble(label23.Text);







										if (label13.Text == "<<Фініш!>>")
										{
											masuv = 0;
											kola = 0;
											seredniychas = 0;
											prognoz = 0;
										}



									}
								}




							}
						}


					}













					}

					// підсвітка під час кола
					
			label23.BackColor = Color.LawnGreen;
			timer30.Enabled = true;
			timer26.Enabled = true;
			
		}

			timer12.Enabled = false;
		}

	}
}