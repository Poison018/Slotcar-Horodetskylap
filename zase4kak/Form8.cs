﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Media;
using zase4ka.Properties;

namespace zase4kak
{
	public partial class Form8 : Form
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

		public Form8()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;

			// вибір кольору доріжки
			panel1.BackColor = Settings.Default.line1_6;
			panel3.BackColor = Settings.Default.line2_6;
			panel4.BackColor = Settings.Default.line3_6;
			panel5.BackColor = Settings.Default.line4_6;
			panel10.BackColor = Settings.Default.line5_6;
			panel11.BackColor = Settings.Default.line6_6;
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



		private void Form8_Load(object sender, EventArgs e)
		{

			
			timetostartsound.SoundLocation = "music/81980c1a7dcb7cd.wav";
			timetostartsound.Load();
			fivesecond.SoundLocation = "music/fivesecond.wav";
			fivesecond.Load();
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

		double prognoz1, prognoz2, prognoz3, prognoz4, prognoz5, prognoz6;
		int mins, secs, min, sec, i, msecs, mmsecs, b, c, d, v, l, time_to_traning_min, time_to_traning_sec, traning_number_group = 1;

		int time_to_traning_secs = 1;// секунди для тренування


		int lane1, lane2, lane3, lane4, lane5, lane6, lane2_1, lane2_2, lane2_3, lane2_4, lane2_5, lane2_6, lane3_1, lane3_2, lane3_3, lane3_4, lane3_5, lane3_6, lane4_1, lane4_2, lane4_3, lane4_4, lane4_5, lane4_6, lane5_1, lane5_2, lane5_3, lane5_4, lane5_5, lane5_6, lane6_1, lane6_2, lane6_3, lane6_4, lane6_5, lane6_6;
		int position = 1, position1 = 0;


		int timetostart = 5; // значення стартового таймера

		double delay;

		double Time, Times, Timez, Timeg, Timeb, Timeo, seredniychas1, seredniychas2, seredniychas3, seredniychas4, seredniychas5, seredniychas6;//timer на час кола
		private void timer1_Tick(object sender, EventArgs e)
		{
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

			timer26.Interval = 15;
			Timeo = 0.0;

			timer27.Interval = 15;
			Timeb = 0.0;

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
					timer43.Enabled = true;
					label71.Visible = true;
					timer2.Enabled = true;
					label4.Text = "00:00";
					sec = 1;
					min = Convert.ToInt32(textBox13.Text);
					label13.Text = "<<Гонка!>>";
					label15.Visible = true;
					label15.Text = "1/6";
					label13.Visible = true;
					timer20.Enabled = true;
					timer11.Enabled = true;
					timer16.Enabled = true;
					timer17.Enabled = true;
					timer15.Enabled = true;
					timer26.Enabled = true;
					timer27.Enabled = true;
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


					//перехід між доріжками
					timer43.Enabled = false;

					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					timer26.Enabled = false;
					timer27.Enabled = false;


					//
					lane1 = Convert.ToInt32(label17.Text);
					lane2_2 = Convert.ToInt32(label24.Text);
					lane3_3 = Convert.ToInt32(label23.Text);
					lane4_4 = Convert.ToInt32(label25.Text);
					lane5_5 = Convert.ToInt32(label97.Text);
					lane6_6 = Convert.ToInt32(label112.Text);








					textBox16.Text = label45.Text;  //червона
					label50.Text = label17.Text;
					label66.Text = label21.Text;
					label125.Text = label8.Text;
					label131.Text = label54.Text;



					textBox17.Text = label46.Text; //біла
					label51.Text = label24.Text;
					label63.Text = label27.Text;
					label126.Text = label56.Text;
					label132.Text = label57.Text;

					textBox18.Text = label47.Text;  //зелена
					label52.Text = label23.Text;
					label64.Text = label26.Text;
					label127.Text = label117.Text;
					label133.Text = label58.Text;

					textBox19.Text = label48.Text;  //оранжева
					label53.Text = label25.Text;
					label65.Text = label28.Text;
					label128.Text = label119.Text;
					label134.Text = label118.Text;

					textBox28.Text = label115.Text;  //синя
					label90.Text = label97.Text;
					label73.Text = label95.Text;
					label129.Text = label121.Text;
					label135.Text = label120.Text;

					textBox32.Text = label116.Text;  //жовта
					label105.Text = label112.Text;
					label102.Text = label110.Text;
					label130.Text = label123.Text;
					label136.Text = label122.Text;




					label45.Text = textBox32.Text;
					label17.Text = label105.Text;
					label21.Text = label102.Text;
					label8.Text = label130.Text;
					label54.Text = label136.Text;

					label46.Text = textBox28.Text;
					label24.Text = label90.Text;
					label27.Text = label73.Text;
					label56.Text = label129.Text;
					label57.Text = label135.Text;

					label47.Text = textBox16.Text;
					label23.Text = label50.Text;
					label26.Text = label66.Text;
					label117.Text = label125.Text;
					label58.Text = label131.Text;

					label48.Text = textBox17.Text;
					label25.Text = label51.Text;
					label28.Text = label63.Text;
					label119.Text = label126.Text;
					label118.Text = label132.Text;

					label115.Text = textBox18.Text;
					label97.Text = label52.Text;
					label95.Text = label64.Text;
					label121.Text = label127.Text;
					label120.Text = label133.Text;

					label116.Text = textBox19.Text;
					label112.Text = label53.Text;
					label110.Text = label65.Text;
					label123.Text = label128.Text;
					label122.Text = label134.Text;

					//label8.Text = "0";
					//	label56.Text = "0";
					//label117.Text = "0";
					//label119.Text = "0";
					//	label121.Text = "0";
					//	label123.Text = "0";


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

					label94.Text = "00,000";
					label96.Text = "00,000";
					label93.Text = "00,000";
					label99.Text = "00,000";
					label92.Text = "999";

					label100.Text = "00,000";
					label101.Text = "00,000";
					label103.Text = "00,000";
					label114.Text = "00,000";
					label107.Text = "999";


					number_group.Text = "1";

					// сортування по результату
					dataGridView3.Rows.Add(label17.Text + "," + 6);
					dataGridView3.Rows.Add(label24.Text + "," + 5);
					dataGridView3.Rows.Add(label23.Text + "," + 4);
					dataGridView3.Rows.Add(label25.Text + "," + 3);
					dataGridView3.Rows.Add(label97.Text + "," + 2);
					dataGridView3.Rows.Add(label112.Text + "," + 1);

					dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);









					//червона

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
					{
						panel1.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
									{

										panel1.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
										{

											panel1.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}



					// біла

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
					{
						panel3.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label24.Text + "," + 5))//&& Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
									{

										panel3.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
										{

											panel3.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					// зелена

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
					{
						panel4.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
									{

										panel4.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
										{

											panel4.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//оранжева 



					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
					{
						panel5.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
									{

										panel5.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label25.Text + "," + 3))//&& Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
										{

											panel5.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//синя

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label97.Text + "," + 2))//&& Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
					{
						panel10.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
						{

							panel10.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
							{

								panel10.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
								{

									panel10.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
									{

										panel10.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
										{

											panel10.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}


					//жовта

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
					{
						panel11.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
						{

							panel11.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
							{

								panel11.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
								{

									panel11.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
									{

										panel11.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
										{

											panel11.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}
					timer34.Enabled = true;
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

				Time = Convert.ToDouble(label102.Text);
				Timeg = Convert.ToDouble(label63.Text);
				Timez = Convert.ToDouble(label73.Text);
				Times = Convert.ToDouble(label66.Text);
				Timeo = Convert.ToDouble(label64.Text);
				Timeb = Convert.ToDouble(label65.Text);
				timer43.Enabled = true;
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

				label4.Text = "00:00";
				label13.Text = "<<Гонка!>>";
				label15.Text = "2/6";

				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;

				button6.Enabled = true;
				button6.Focus();
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

					timer43.Enabled = false;

					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					timer26.Enabled = false;
					timer27.Enabled = false;




					//

					lane3 = Convert.ToInt32(label23.Text) - lane1;
					lane2_4 = Convert.ToInt32(label25.Text) - lane2_2;
					lane3_5 = Convert.ToInt32(label97.Text) - lane3_3;
					lane4_6 = Convert.ToInt32(label112.Text) - lane4_4;
					lane5_2 = Convert.ToInt32(label24.Text) - lane5_5;
					lane6_1 = Convert.ToInt32(label17.Text) - lane6_6;




					textBox16.Text = label45.Text;  //червона
					label50.Text = label17.Text;
					label66.Text = label21.Text;
					label125.Text = label8.Text;
					label131.Text = label54.Text;



					textBox17.Text = label46.Text; //біла
					label51.Text = label24.Text;
					label63.Text = label27.Text;
					label126.Text = label56.Text;
					label132.Text = label57.Text;

					textBox18.Text = label47.Text;  //зелена
					label52.Text = label23.Text;
					label64.Text = label26.Text;
					label127.Text = label117.Text;
					label133.Text = label58.Text;

					textBox19.Text = label48.Text;  //оранжева
					label53.Text = label25.Text;
					label65.Text = label28.Text;
					label128.Text = label119.Text;
					label134.Text = label118.Text;

					textBox28.Text = label115.Text;  //синя
					label90.Text = label97.Text;
					label73.Text = label95.Text;
					label129.Text = label121.Text;
					label135.Text = label120.Text;

					textBox32.Text = label116.Text;  //жовта
					label105.Text = label112.Text;
					label102.Text = label110.Text;
					label130.Text = label123.Text;
					label136.Text = label122.Text;




					label45.Text = textBox32.Text;
					label17.Text = label105.Text;
					label21.Text = label102.Text;
					label8.Text = label130.Text;
					label54.Text = label136.Text;

					label46.Text = textBox28.Text;
					label24.Text = label90.Text;
					label27.Text = label73.Text;
					label56.Text = label129.Text;
					label57.Text = label135.Text;

					label47.Text = textBox16.Text;
					label23.Text = label50.Text;
					label26.Text = label66.Text;
					label117.Text = label125.Text;
					label58.Text = label131.Text;

					label48.Text = textBox17.Text;
					label25.Text = label51.Text;
					label28.Text = label63.Text;
					label119.Text = label126.Text;
					label118.Text = label132.Text;

					label115.Text = textBox18.Text;
					label97.Text = label52.Text;
					label95.Text = label64.Text;
					label121.Text = label127.Text;
					label120.Text = label133.Text;

					label116.Text = textBox19.Text;
					label112.Text = label53.Text;
					label110.Text = label65.Text;
					label123.Text = label128.Text;
					label122.Text = label134.Text;

					//label8.Text = "0";
					//label56.Text = "0";
					//label117.Text = "0";
					//label119.Text = "0";
					//label121.Text = "0";
					//label123.Text = "0";

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

					label94.Text = "00,000";
					label96.Text = "00,000";
					label93.Text = "00,000";
					label99.Text = "00,000";
					label92.Text = "999";

					label100.Text = "00,000";
					label101.Text = "00,000";
					label103.Text = "00,000";
					label114.Text = "00,000";
					label107.Text = "999";

					number_group.Text = "2";


					// сортування по результату
					dataGridView3.Rows.Add(label17.Text + "," + 6);
					dataGridView3.Rows.Add(label24.Text + "," + 5);
					dataGridView3.Rows.Add(label23.Text + "," + 4);
					dataGridView3.Rows.Add(label25.Text + "," + 3);
					dataGridView3.Rows.Add(label97.Text + "," + 2);
					dataGridView3.Rows.Add(label112.Text + "," + 1);

					dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);









					//червона

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
					{
						panel1.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
									{

										panel1.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
										{

											panel1.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}



					// біла

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
					{
						panel3.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label24.Text + "," + 5))//&& Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
									{

										panel3.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
										{

											panel3.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					// зелена

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
					{
						panel4.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
									{

										panel4.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
										{

											panel4.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//оранжева 



					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
					{
						panel5.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
									{

										panel5.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label25.Text + "," + 3))//&& Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
										{

											panel5.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//синя

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label97.Text + "," + 2))//&& Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
					{
						panel10.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
						{

							panel10.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
							{

								panel10.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
								{

									panel10.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
									{

										panel10.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
										{

											panel10.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}


					//жовта

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
					{
						panel11.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
						{

							panel11.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
							{

								panel11.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
								{

									panel11.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
									{

										panel11.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
										{

											panel11.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}
					timer34.Enabled = true;

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
				timer43.Enabled = true;
				Time = Convert.ToDouble(label102.Text);
				Timeg = Convert.ToDouble(label63.Text);
				Timez = Convert.ToDouble(label73.Text);
				Times = Convert.ToDouble(label66.Text);
				Timeo = Convert.ToDouble(label64.Text);
				Timeb = Convert.ToDouble(label65.Text);

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
				label15.Text = "3/6";

				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;

				button6.Enabled = true;
				button6.Focus();
			}

		}

		private void Form3_Load(object sender, EventArgs e)
		{
			timetostartsound.SoundLocation = "music/81980c1a7dcb7cd.wav";
			timetostartsound.Load();
			fivesecond.SoundLocation = "music/fivesecond.wav";
			fivesecond.Load();
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
					timer43.Enabled = false;

					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					timer26.Enabled = false;
					timer27.Enabled = false;



					//


					lane5 = Convert.ToInt32(label97.Text) - lane1 - lane3;
					lane2_6 = Convert.ToInt32(label112.Text) - lane2_2 - lane2_4;
					lane3_2 = Convert.ToInt32(label24.Text) - lane3_3 - lane3_5;
					lane4_1 = Convert.ToInt32(label17.Text) - lane4_4 - lane4_6;
					lane5_4 = Convert.ToInt32(label25.Text) - lane5_5 - lane5_2;
					lane6_3 = Convert.ToInt32(label23.Text) - lane6_6 - lane6_1;







					textBox16.Text = label45.Text;  //червона
					label50.Text = label17.Text;
					label66.Text = label21.Text;
					label125.Text = label8.Text;
					label131.Text = label54.Text;



					textBox17.Text = label46.Text; //біла
					label51.Text = label24.Text;
					label63.Text = label27.Text;
					label126.Text = label56.Text;
					label132.Text = label57.Text;

					textBox18.Text = label47.Text;  //зелена
					label52.Text = label23.Text;
					label64.Text = label26.Text;
					label127.Text = label117.Text;
					label133.Text = label58.Text;

					textBox19.Text = label48.Text;  //оранжева
					label53.Text = label25.Text;
					label65.Text = label28.Text;
					label128.Text = label119.Text;
					label134.Text = label118.Text;

					textBox28.Text = label115.Text;  //синя
					label90.Text = label97.Text;
					label73.Text = label95.Text;
					label129.Text = label121.Text;
					label135.Text = label120.Text;

					textBox32.Text = label116.Text;  //жовта
					label105.Text = label112.Text;
					label102.Text = label110.Text;
					label130.Text = label123.Text;
					label136.Text = label122.Text;




					label45.Text = textBox32.Text;
					label17.Text = label105.Text;
					label21.Text = label102.Text;
					label8.Text = label130.Text;
					label54.Text = label136.Text;

					label46.Text = textBox28.Text;
					label24.Text = label90.Text;
					label27.Text = label73.Text;
					label56.Text = label129.Text;
					label57.Text = label135.Text;

					label47.Text = textBox16.Text;
					label23.Text = label50.Text;
					label26.Text = label66.Text;
					label117.Text = label125.Text;
					label58.Text = label131.Text;

					label48.Text = textBox17.Text;
					label25.Text = label51.Text;
					label28.Text = label63.Text;
					label119.Text = label126.Text;
					label118.Text = label132.Text;

					label115.Text = textBox18.Text;
					label97.Text = label52.Text;
					label95.Text = label64.Text;
					label121.Text = label127.Text;
					label120.Text = label133.Text;

					label116.Text = textBox19.Text;
					label112.Text = label53.Text;
					label110.Text = label65.Text;
					label123.Text = label128.Text;
					label122.Text = label134.Text;

					//label8.Text = "0";
					//label56.Text = "0";
					//label117.Text = "0";
					//label119.Text = "0";
					//label121.Text = "0";
					//label123.Text = "0";

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

					label94.Text = "00,000";
					label96.Text = "00,000";
					label93.Text = "00,000";
					label99.Text = "00,000";
					label92.Text = "999";

					label100.Text = "00,000";
					label101.Text = "00,000";
					label103.Text = "00,000";
					label114.Text = "00,000";
					label107.Text = "999";

					number_group.Text = "3";




					// сортування по результату
					dataGridView3.Rows.Add(label17.Text + "," + 6);
					dataGridView3.Rows.Add(label24.Text + "," + 5);
					dataGridView3.Rows.Add(label23.Text + "," + 4);
					dataGridView3.Rows.Add(label25.Text + "," + 3);
					dataGridView3.Rows.Add(label97.Text + "," + 2);
					dataGridView3.Rows.Add(label112.Text + "," + 1);

					dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);









					//червона

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
					{
						panel1.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
									{

										panel1.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
										{

											panel1.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}



					// біла

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
					{
						panel3.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label24.Text + "," + 5))//&& Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
									{

										panel3.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
										{

											panel3.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					// зелена

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
					{
						panel4.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
									{

										panel4.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
										{

											panel4.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//оранжева 



					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
					{
						panel5.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
									{

										panel5.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label25.Text + "," + 3))//&& Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
										{

											panel5.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//синя

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label97.Text + "," + 2))//&& Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
					{
						panel10.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
						{

							panel10.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
							{

								panel10.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
								{

									panel10.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
									{

										panel10.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
										{

											panel10.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}


					//жовта

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
					{
						panel11.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
						{

							panel11.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
							{

								panel11.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
								{

									panel11.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
									{

										panel11.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
										{

											panel11.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}
					timer34.Enabled = true;

				}

			}

		}

		private void timer17_Tick(object sender, EventArgs e)
		{


			Timez += 0.0003 * 53;                   //timer на час кола біла доріжка
			label27.Text = string.Format("{0:F3}", Timez);       //timer на час кола біла доріжка

		}

		private void timer16_Tick(object sender, EventArgs e)
		{

			Timeg += 0.0003 * 53;                   //timer на час кола оранжева доріжка
			label28.Text = string.Format("{0:F3}", Timeg);       //timer на час кола оранжева доріжка

		}











		private void timer18_Tick(object sender, EventArgs e)
		{































			int chervona, bila, zelena, orangeva, sunia, shovta;


			if (textBox20.Text == "" || textBox21.Text == "" || textBox22.Text == "" || textBox23.Text == "" || textBox36.Text == "" || textBox37.Text == "")
			{
				button9.Enabled = false;
			}
			else
			{
				button9.Enabled = true;
			}


			switch (Convert.ToInt32(label67.Text))
			{
				case 85:
					{
						label71.Text = "Група - << O >>";
						break;
					}

				case 77:
					{
						label71.Text = "Група - << N >>";
						break;
					}

				case 73:
					{
						label71.Text = "Група - << M >>";
						break;
					}

				case 67:
					{
						label71.Text = "Група - << L >>";
						break;
					}

				case 61:
					{
						label71.Text = "Група - << K >>";
						break;
					}

				case 55:
					{
						label71.Text = "Група - << J >>";
						break;
					}

				case 49:
					{
						label71.Text = "Група - << I >>";
						break;
					}
				case 43:
					{
						label71.Text = "Група - << H >>";
						break;
					}
				case 37:
					{
						label71.Text = "Група - << G >>";
						break;
					}
				case 31:
					{
						label71.Text = "Група - << F >>";
						break;
					}
				case 25:
					{
						label71.Text = "Група - << E >>";
						break;
					}
				case 19:
					{
						label71.Text = "Група - << D >>";
						break;
					}
				case 13:
					{
						label71.Text = "Група - << C >>";
						break;
					}
				case 7:
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

			}














			//chervona = Convert.ToInt32(label17.Text);
			//bila = Convert.ToInt32(label24.Text);
			//zelena = Convert.ToInt32(label23.Text);
			//orangeva = Convert.ToInt32(label25.Text);
			//sunia = Convert.ToInt32(label97.Text);
			//shovta = Convert.ToInt32(label112.Text);

			//for (int i = 0; i < 1; i++)
			//         {
			//	listBox2.Items.Add(chervona);
			//	listBox2.Items.Add(bila);
			//	listBox2.Items.Add(zelena);
			//	listBox2.Items.Add(orangeva);
			//	listBox2.Items.Add(sunia);
			//	listBox2.Items.Add(shovta);
			//	break;

			//}

			//listBox1.Items.Add(s);
			//if (chervona != bila && chervona !=zelena && chervona != orangeva && chervona != sunia && chervona != shovta && zelena != sunia && zelena!= shovta)



			//{





			//int[] line = new int[] { chervona, bila, zelena, orangeva, sunia, shovta };

			//         Array.Sort(line);

			//         foreach (int n in line)

			//label8.Text = (Convert.ToString(n));




























			//if (label15.Text == "2/6" || label15.Text == "3/6" || label15.Text == "5/6")
			//{
			//	if (Convert.ToInt32(label8.Text) < Convert.ToInt32(label117.Text))
			//	{
			//		label123.Text = label117.Text;
			//		label117.Text = label8.Text;
			//		label8.Text = label123.Text;
			//                 if (chervona == Convert.ToInt32(label8.Text))
			//                 {
			//                     panel1.Location = new Point(4, 219);
			//                     //label8.Text = "0";
			//                 }
			//                 else
			//                 {
			//                     if (bila == Convert.ToInt32(label8.Text))
			//                     {
			//                         panel3.Location = new Point(4, 219);
			//                         //label8.Text = "0";
			//                     }
			//                     else
			//                     {
			//                         if (zelena == Convert.ToInt32(label8.Text))
			//                         {
			//                             panel4.Location = new Point(4, 219);
			//                             //label8.Text = "0";
			//                         }
			//                         else
			//                         {
			//                             if (orangeva == Convert.ToInt32(label8.Text))
			//                             {
			//                                 panel5.Location = new Point(4, 219);
			//                                 //label8.Text = "0";
			//                             }
			//                             else
			//                             {
			//                                 if (sunia == Convert.ToInt32(label8.Text))
			//                                 {
			//                                     panel10.Location = new Point(4, 219);
			//                                     //label8.Text = "0";
			//                                 }
			//                                 else
			//                                 {
			//                                     if (shovta == Convert.ToInt32(label8.Text))
			//                                     {
			//                                         panel11.Location = new Point(4, 219);
			//                                         //label8.Text = "0";
			//                                     }
			//                                 }
			//                             }
			//                         }
			//                     }
			//                 }
			//             }





			//	if (Convert.ToInt32(label117.Text) < Convert.ToInt32(label58.Text))
			//	{
			//		label118.Text = label58.Text;
			//		label58.Text = label117.Text;
			//		label117.Text = label118.Text;
			//                 if (chervona == Convert.ToInt32(label117.Text))
			//                 {
			//                     panel1.Location = new Point(4, 321);
			//                     //label117.Text = "0";
			//                 }
			//                 else
			//                 {
			//                     if (bila == Convert.ToInt32(label117.Text))
			//                     {
			//                         panel3.Location = new Point(4, 321);
			//                         //label117.Text = "0";
			//                     }
			//                     else
			//                     {
			//                         if (zelena == Convert.ToInt32(label117.Text))
			//                         {
			//                             panel4.Location = new Point(4, 321);
			//                             //label117.Text = "0";
			//                         }
			//                         else
			//                         {
			//                             if (orangeva == Convert.ToInt32(label117.Text))
			//                             {
			//                                 panel5.Location = new Point(4, 321);
			//                                 //label117.Text = "0";
			//                             }
			//                             else
			//                             {
			//                                 if (sunia == Convert.ToInt32(label117.Text))
			//                                 {
			//                                     panel10.Location = new Point(4, 321);
			//                                     //	label117.Text = "0";
			//                                 }
			//                                 else
			//                                 {
			//                                     if (shovta == Convert.ToInt32(label117.Text))
			//                                     {
			//                                         panel11.Location = new Point(4, 321);
			//                                         //	label117.Text = "0";
			//                                     }
			//                                 }
			//                             }
			//                         }
			//                     }
			//                 }
			//             }




			//	if (Convert.ToInt32(label58.Text) < Convert.ToInt32(label57.Text))
			//	{
			//		label119.Text = label57.Text;
			//		label57.Text = label58.Text;
			//		label58.Text = label119.Text;
			//                 if (chervona == Convert.ToInt32(label58.Text))
			//                 {
			//                     panel1.Location = new Point(4, 423);
			//                     //	label58.Text = "0";
			//                 }
			//                 else
			//                 {
			//                     if (bila == Convert.ToInt32(label58.Text))
			//                     {
			//                         panel3.Location = new Point(4, 423);
			//                         //label58.Text = "0";
			//                     }
			//                     else
			//                     {
			//                         if (zelena == Convert.ToInt32(label58.Text))
			//                         {
			//                             panel4.Location = new Point(4, 423);
			//                             //	label58.Text = "0";
			//                         }
			//                         else
			//                         {
			//                             if (orangeva == Convert.ToInt32(label58.Text))
			//                             {
			//                                 panel5.Location = new Point(4, 423);
			//                                 //	label58.Text = "0";
			//                             }
			//                             else
			//                             {
			//                                 if (sunia == Convert.ToInt32(label58.Text))
			//                                 {
			//                                     panel10.Location = new Point(4, 423);
			//                                     //	label58.Text = "0";
			//                                 }
			//                                 else
			//                                 {
			//                                     if (shovta == Convert.ToInt32(label58.Text))
			//                                     {
			//                                         panel11.Location = new Point(4, 423);
			//                                         //	label58.Text = "0";
			//                                     }
			//                                 }
			//                             }
			//                         }
			//                     }
			//                 }

			//             }



			//	if (Convert.ToInt32(label57.Text) < Convert.ToInt32(label56.Text))
			//	{
			//		label120.Text = label56.Text;
			//		label56.Text = label57.Text;
			//		label57.Text = label120.Text;
			//		if (chervona == Convert.ToInt32(label57.Text))
			//		{
			//			panel1.Location = new Point(4, 525);
			//			//label57.Text = "0";
			//		}
			//		else
			//		{
			//			if (bila == Convert.ToInt32(label57.Text))
			//			{
			//				panel3.Location = new Point(4, 525);
			//				//label57.Text = "0";
			//			}
			//			else
			//			{
			//				if (zelena == Convert.ToInt32(label57.Text))
			//				{
			//					panel4.Location = new Point(4, 525);
			//					//label57.Text = "0";
			//				}
			//				else
			//				{
			//					if (orangeva == Convert.ToInt32(label57.Text))
			//					{
			//						panel5.Location = new Point(4, 525);
			//					//	label57.Text = "0";
			//					}
			//					else
			//					{
			//						if (sunia == Convert.ToInt32(label57.Text))
			//						{
			//							panel10.Location = new Point(4, 525);
			//						//	label57.Text = "0";
			//						}
			//						else
			//						{
			//							if (shovta == Convert.ToInt32(label57.Text))
			//							{
			//								panel11.Location = new Point(4, 525);
			//							//	label57.Text = "0";
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}

			//	}



			//	if (Convert.ToInt32(label56.Text) < Convert.ToInt32(label54.Text))
			//	{
			//		label121.Text = label54.Text;
			//		label54.Text = label56.Text;
			//		label56.Text = label121.Text;
			//		if (chervona == Convert.ToInt32(label56.Text))
			//		{
			//			panel1.Location = new Point(4, 628);
			//			//label56.Text = "0";
			//		}
			//		else
			//		{
			//			if (bila == Convert.ToInt32(label56.Text))
			//			{
			//				panel3.Location = new Point(4, 628);
			//				//label56.Text = "0";
			//			}
			//			else
			//			{
			//				if (zelena == Convert.ToInt32(label56.Text))
			//				{
			//					panel4.Location = new Point(4, 628);
			//					//label56.Text = "0";
			//				}
			//				else
			//				{
			//					if (orangeva == Convert.ToInt32(label56.Text))
			//					{
			//						panel5.Location = new Point(4, 628);
			//						//label56.Text = "0";
			//					}
			//					else
			//					{
			//						if (sunia == Convert.ToInt32(label56.Text))
			//						{
			//							panel10.Location = new Point(4, 628);
			//							//label56.Text = "0";
			//						}
			//						else
			//						{
			//							if (shovta == Convert.ToInt32(label56.Text))
			//							{
			//								panel11.Location = new Point(4, 628);
			//								//label56.Text = "0";
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}

			//	}


			//}






			label55.Visible = true;
			label59.Visible = true;
			label60.Visible = true;
			label61.Visible = true;
			label62.Visible = true;
			label75.Visible = true;
			label104.Visible = true;

			if (panel1.Location == new Point(4, 219))
			{


				int label17l, label23l, label24l, label25l, label97l, label112l;

				//label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label23.Text);
				label59.Text = "0";

				label23l = Convert.ToInt32(label23.Text) - Convert.ToInt32(label17.Text);
				label61.Text = Convert.ToString(label23l);

				label24l = Convert.ToInt32(label24.Text) - Convert.ToInt32(label17.Text);
				label60.Text = Convert.ToString(label24l);

				label25l = Convert.ToInt32(label25.Text) - Convert.ToInt32(label17.Text);
				label62.Text = Convert.ToString(label25l);

				label97l = Convert.ToInt32(label97.Text) - Convert.ToInt32(label17.Text);
				label75.Text = Convert.ToString(label97l);

				label112l = Convert.ToInt32(label112.Text) - Convert.ToInt32(label17.Text);
				label104.Text = Convert.ToString(label112l);



			}



			if (panel3.Location == new Point(4, 219))
			{


				int label17l, label23l, label25l, label97l, label112l;

				label60.Text = "0";

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label24.Text);
				label59.Text = Convert.ToString(label17l);

				label23l = Convert.ToInt32(label23.Text) - Convert.ToInt32(label24.Text);
				label61.Text = Convert.ToString(label23l);

				label25l = Convert.ToInt32(label25.Text) - Convert.ToInt32(label24.Text);
				label62.Text = Convert.ToString(label25l);

				label97l = Convert.ToInt32(label97.Text) - Convert.ToInt32(label24.Text);
				label75.Text = Convert.ToString(label97l);

				label112l = Convert.ToInt32(label112.Text) - Convert.ToInt32(label24.Text);
				label104.Text = Convert.ToString(label112l);


			}

			if (panel4.Location == new Point(4, 219))
			{


				int label17l, label24l, label25l, label97l, label112l;

				label61.Text = "0";

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label23.Text);
				label59.Text = Convert.ToString(label17l);

				label24l = Convert.ToInt32(label24.Text) - Convert.ToInt32(label23.Text);
				label60.Text = Convert.ToString(label24l);

				label25l = Convert.ToInt32(label25.Text) - Convert.ToInt32(label23.Text);
				label62.Text = Convert.ToString(label25l);

				label97l = Convert.ToInt32(label97.Text) - Convert.ToInt32(label23.Text);
				label75.Text = Convert.ToString(label97l);

				label112l = Convert.ToInt32(label112.Text) - Convert.ToInt32(label23.Text);
				label104.Text = Convert.ToString(label112l);

			}

			if (panel5.Location == new Point(4, 219))
			{


				int label17l, label23l, label24l, label97l, label112l;

				label62.Text = "0";

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label25.Text);
				label59.Text = Convert.ToString(label17l);

				label24l = Convert.ToInt32(label24.Text) - Convert.ToInt32(label25.Text);
				label60.Text = Convert.ToString(label24l);

				label23l = Convert.ToInt32(label23.Text) - Convert.ToInt32(label25.Text);
				label61.Text = Convert.ToString(label23l);

				label97l = Convert.ToInt32(label97.Text) - Convert.ToInt32(label25.Text);
				label75.Text = Convert.ToString(label97l);

				label112l = Convert.ToInt32(label112.Text) - Convert.ToInt32(label25.Text);
				label104.Text = Convert.ToString(label112l);

			}

			if (panel10.Location == new Point(4, 219))

			{


				int label17l, label23l, label24l, label25l, label112l;

				label75.Text = "0";

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label97.Text);
				label59.Text = Convert.ToString(label17l);

				label24l = Convert.ToInt32(label24.Text) - Convert.ToInt32(label97.Text);
				label60.Text = Convert.ToString(label24l);

				label23l = Convert.ToInt32(label23.Text) - Convert.ToInt32(label97.Text);
				label61.Text = Convert.ToString(label23l);

				label25l = Convert.ToInt32(label25.Text) - Convert.ToInt32(label97.Text);
				label62.Text = Convert.ToString(label25l);

				label112l = Convert.ToInt32(label112.Text) - Convert.ToInt32(label97.Text);
				label104.Text = Convert.ToString(label112l);

			}

			if (panel11.Location == new Point(4, 219))

			{


				int label17l, label23l, label24l, label25l, label97l;

				label104.Text = "0";

				label17l = Convert.ToInt32(label17.Text) - Convert.ToInt32(label112.Text);
				label59.Text = Convert.ToString(label17l);

				label24l = Convert.ToInt32(label24.Text) - Convert.ToInt32(label112.Text);
				label60.Text = Convert.ToString(label24l);

				label23l = Convert.ToInt32(label23.Text) - Convert.ToInt32(label112.Text);
				label61.Text = Convert.ToString(label23l);

				label25l = Convert.ToInt32(label25.Text) - Convert.ToInt32(label112.Text);
				label62.Text = Convert.ToString(label25l);

				label97l = Convert.ToInt32(label97.Text) - Convert.ToInt32(label112.Text);
				label75.Text = Convert.ToString(label97l);


			}




















			//if (chervona != bila && chervona != zelena && chervona != orangeva && chervona != sunia && chervona != shovta)
			//{

			//	if (chervona < zelena && chervona < orangeva && chervona < bila && chervona < sunia && chervona < shovta)   // червона

			//	{
			//		panel1.Location = new Point(4, 731);
			//	}
			//	else
			//	{
			//		if (chervona < orangeva && chervona < bila && chervona < sunia && chervona < shovta || chervona < zelena && chervona < orangeva && chervona < bila && chervona < sunia || chervona < sunia && chervona < zelena && shovta < orangeva && chervona < bila || chervona < sunia && chervona < shovta && chervona < zelena && chervona < orangeva || chervona < bila && chervona < sunia && chervona < shovta && chervona < zelena)
			//		{
			//			panel1.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (chervona < bila && chervona < sunia && chervona < shovta || chervona < orangeva && chervona < zelena && chervona < bila || chervona < shovta && chervona < orangeva && chervona < zelena || chervona < sunia && chervona < shovta && chervona < orangeva || chervona < zelena && chervona < bila && chervona < sunia)
			//			{
			//				panel1.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (chervona < zelena && chervona < bila || chervona < sunia && chervona < orangeva || chervona < bila && chervona < sunia || chervona < orangeva && chervona < shovta || chervona < shovta && chervona < zelena)
			//				{
			//					panel1.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (chervona < shovta || chervona < zelena || chervona < sunia || chervona < orangeva || chervona < bila)
			//					{
			//						panel1.Location = new Point(4, 321);
			//					}
			//					else
			//					{
			//						if (chervona > shovta && chervona > zelena && chervona > sunia && chervona > orangeva & chervona > bila)
			//						{
			//							panel1.Location = new Point(4, 219);
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}

			//}


			//if (zelena != chervona && zelena != bila && zelena != orangeva && zelena != sunia && zelena != shovta)
			//{

			//	if (zelena < chervona && zelena < orangeva && zelena < bila && zelena < sunia && zelena < shovta) // зелена
			//	{
			//		panel4.Location = new Point(4, 731);
			//	}
			//	else
			//	{
			//		if (zelena < orangeva && zelena < bila && zelena < sunia && zelena < shovta || zelena < chervona && zelena < orangeva && zelena < bila && zelena < sunia || zelena < shovta && zelena < chervona && zelena < orangeva && zelena < bila || zelena < sunia && zelena < shovta && zelena < chervona && zelena < orangeva || zelena < bila && zelena < sunia && zelena < shovta && zelena < chervona)
			//		{
			//			panel4.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (zelena < bila && zelena < sunia && zelena < shovta || zelena < orangeva && zelena < chervona && zelena < bila || zelena < shovta && zelena < orangeva && zelena < chervona || zelena < sunia && zelena < shovta && zelena < orangeva || zelena < chervona && zelena < bila && zelena < sunia)
			//			{
			//				panel4.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (zelena < chervona && zelena < bila || zelena < sunia && zelena < orangeva || zelena < bila && zelena < sunia || zelena < orangeva && zelena < shovta || zelena < shovta && zelena < chervona)
			//				{
			//					panel4.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (zelena < shovta || zelena < chervona || zelena < sunia || zelena < orangeva || zelena < bila)
			//					{
			//						panel4.Location = new Point(4, 321);
			//					}
			//					else
			//					{
			//						if (zelena > chervona && zelena > bila && zelena > orangeva && zelena > sunia && zelena > shovta)
			//						{
			//							panel4.Location = new Point(4, 219);
			//						}
			//					}
			//				}
			//			}

			//		}
			//	}

			//}
			//if (bila != chervona && bila != shovta && bila != sunia && bila != zelena && bila != orangeva)
			//{

			//	if (bila < chervona && bila < orangeva && bila < zelena && bila < sunia && bila < shovta)         // біла
			//	{
			//		panel3.Location = new Point(4, 731);

			//	}
			//	else
			//	{
			//		if (bila < orangeva && bila < zelena && bila < sunia && bila < shovta || bila < chervona && bila < orangeva && bila < zelena && bila < sunia || bila < shovta && bila < chervona && bila < orangeva && bila < zelena || bila < sunia && bila < shovta && bila < chervona && bila < orangeva || bila < zelena && bila < sunia && bila < shovta && bila < chervona)
			//		{
			//			panel3.Location = new Point(4, 628);

			//		}
			//		else
			//		{
			//			if (bila < zelena && bila < sunia && bila < shovta || bila < orangeva && bila < chervona && bila < zelena || bila < shovta && bila < orangeva && bila < chervona || bila < sunia && bila < shovta && bila < orangeva || bila < chervona && bila < zelena && bila < sunia)
			//			{
			//				panel3.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (bila < chervona && bila < zelena || bila < sunia && bila < orangeva || bila < zelena & bila < sunia || bila < orangeva && bila < shovta || bila < shovta && bila < chervona)
			//				{
			//					panel3.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (bila < shovta || bila < chervona || bila < sunia || bila < orangeva || bila < zelena)
			//					{
			//						panel3.Location = new Point(4, 321);

			//					}
			//					else
			//					{
			//						if (bila > shovta && bila > chervona && bila > sunia && bila > orangeva && bila > zelena)
			//						{
			//							panel3.Location = new Point(4, 219);
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}
			//}




			//if (sunia != chervona && sunia != orangeva && sunia != zelena && sunia != bila && sunia != shovta)  //синя
			//{

			//	if (sunia < chervona && sunia < orangeva && sunia < zelena && sunia < bila && sunia < shovta)
			//	{
			//		panel10.Location = new Point(4, 731);

			//	}
			//	else
			//	{
			//		if (sunia < orangeva && sunia < zelena && sunia < bila && sunia < shovta || sunia < chervona && sunia < orangeva && sunia < zelena && sunia < bila || sunia < shovta && sunia < chervona && sunia < orangeva && sunia < zelena || sunia < bila && sunia < shovta && sunia < chervona && sunia < orangeva || sunia < zelena && sunia < bila && sunia < shovta && sunia < chervona)
			//		{
			//			panel10.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (sunia < zelena && sunia < bila && sunia < shovta || sunia < orangeva && sunia < chervona && sunia < zelena || sunia < shovta && sunia < orangeva && sunia < chervona || sunia < bila && sunia < shovta && sunia < orangeva || sunia < chervona && sunia < zelena && sunia < bila)
			//			{
			//				panel10.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (sunia < chervona && sunia < zelena || sunia < bila && sunia < orangeva || sunia < zelena && sunia < bila || sunia < orangeva && sunia < shovta || sunia < shovta && sunia < chervona)
			//				{
			//					panel10.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (sunia < shovta || sunia < chervona || sunia < bila || sunia < orangeva || sunia < zelena)
			//					{
			//						panel10.Location = new Point(4, 321);
			//					}
			//					else
			//					{
			//						if (sunia > chervona && sunia > orangeva && sunia > zelena && sunia > bila && sunia > shovta)
			//						{
			//							panel10.Location = new Point(4, 219);
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}
			//}
			//if (shovta != sunia && shovta != bila && shovta != zelena && shovta != orangeva && shovta != chervona) // жовта
			//{
			//	if (shovta < chervona && shovta < orangeva && shovta < zelena && shovta < bila && shovta < sunia)
			//	{
			//		panel11.Location = new Point(4, 731);
			//	}
			//	else
			//	{
			//		if (shovta < orangeva && shovta < zelena && shovta < bila && shovta < sunia || shovta < chervona && shovta < orangeva && shovta < zelena && shovta < bila || shovta < sunia && shovta < chervona && shovta < orangeva || shovta < zelena && shovta < bila && shovta < sunia && shovta < chervona)
			//		{
			//			panel11.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (shovta < zelena && shovta < bila && shovta < sunia || shovta < orangeva && shovta < chervona && shovta < zelena || shovta < sunia && shovta < orangeva && shovta < chervona || shovta < bila && shovta < sunia && shovta < orangeva || shovta < chervona && shovta < zelena && shovta < bila)
			//			{
			//				panel11.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (shovta < zelena && shovta < chervona || shovta < bila && shovta < orangeva || shovta < zelena && shovta < bila || shovta < orangeva && shovta < sunia || shovta < sunia && shovta < chervona)
			//				{
			//					panel11.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (shovta < sunia || shovta < chervona || shovta < bila || shovta < orangeva || shovta < zelena)
			//					{
			//						panel11.Location = new Point(4, 321);

			//					}
			//					else
			//					{
			//						if (shovta > sunia && shovta > bila && shovta > zelena && shovta > orangeva && shovta > chervona)
			//						{
			//							panel11.Location = new Point(4, 219);
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}
			//}




			//if (orangeva > chervona && orangeva > shovta && orangeva > zelena && orangeva > bila && orangeva > sunia)  // оранжева
			//{

			//	if (orangeva < chervona && orangeva < shovta && orangeva < zelena && orangeva < bila && orangeva < sunia)
			//	{
			//		panel5.Location = new Point(4, 731);
			//	}
			//	else
			//	{
			//		if (orangeva < shovta && orangeva < zelena && orangeva < bila && orangeva < sunia || orangeva < chervona && orangeva < shovta && orangeva < zelena && orangeva < bila || orangeva < sunia && orangeva < chervona && orangeva < shovta && orangeva < zelena || orangeva < bila && orangeva < sunia && orangeva < chervona && orangeva < shovta || orangeva < zelena && orangeva < bila && orangeva < sunia && orangeva < shovta)
			//		{
			//			panel5.Location = new Point(4, 628);

			//		}
			//		else
			//		{
			//			if (orangeva < zelena && orangeva < bila && orangeva < sunia || orangeva < shovta && orangeva < chervona && orangeva < zelena || orangeva < sunia && orangeva < shovta && orangeva < chervona || orangeva < bila && orangeva < sunia && orangeva < shovta || orangeva < chervona && orangeva < zelena && orangeva < bila)
			//			{
			//				panel5.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (orangeva < chervona && orangeva < zelena || orangeva < bila && orangeva < shovta || orangeva < zelena && orangeva < bila || orangeva < shovta && orangeva < sunia || orangeva < sunia && orangeva < chervona)
			//				{
			//					panel5.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (orangeva < sunia || orangeva < chervona || orangeva < bila && orangeva < shovta || orangeva < zelena)
			//					{
			//						panel5.Location = new Point(4, 321);

			//					}
			//					else
			//					{
			//						if (orangeva > chervona && orangeva > shovta && orangeva > zelena && orangeva > bila && orangeva > sunia)
			//						{
			//							panel5.Location = new Point(4, 219);
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}

			//}



			//}








			//if (chervona != bila && chervona != zelena && chervona != orangeva && chervona != sunia && chervona != shovta)
			//{

			//	if (chervona > bila && chervona > zelena && chervona > orangeva && chervona > sunia && chervona > shovta)
			//	{
			//		panel1.Location = new Point(4, 219);
			//	}
			//}

			//if (bila != chervona && bila != zelena && bila != orangeva && bila != sunia && bila != shovta)
			//{
			//	if (bila > chervona && bila > zelena && bila > orangeva && bila > sunia && bila > shovta)
			//	{
			//		panel3.Location = new Point(4, 219);
			//	}

			//}


			//if (zelena != chervona && zelena != bila && zelena != orangeva && zelena != sunia && zelena != shovta)
			//{
			//	if (zelena > chervona && zelena > bila && zelena > orangeva && zelena > sunia && zelena > shovta)
			//	{
			//		panel4.Location = new Point(4, 219);
			//	}
			//}



			//if (orangeva != chervona && orangeva != bila && orangeva != zelena && orangeva != sunia && orangeva != shovta)
			//{
			//	if (orangeva > chervona && orangeva > bila && orangeva > zelena && orangeva > sunia && orangeva > shovta)
			//	{
			//		panel5.Location = new Point(4, 219);

			//	}
			//}



			//if (sunia != chervona && sunia != bila && sunia != zelena && sunia != orangeva && sunia != shovta)
			//{


			//	if (sunia > chervona && sunia > bila && sunia > zelena && sunia > orangeva && sunia > shovta)
			//	{
			//		panel10.Location = new Point(4, 219);
			//	}
			//}

			//if (shovta != chervona && shovta != bila && shovta != zelena && shovta != orangeva && shovta != sunia)
			//{
			//	if (shovta > chervona && shovta > bila && shovta > zelena && shovta > orangeva && shovta > sunia)
			//	{
			//		panel11.Location = new Point(4, 219);
			//	}
			//}







			//	if (chervona < bila && chervona > zelena && chervona > orangeva && chervona > sunia && chervona > shovta)      // червона друге місце
			//	{
			//		panel1.Location = new Point(4, 321);
			//	}
			//	else
			//	{
			//		if (chervona < zelena && chervona >bila && chervona > orangeva && chervona > sunia && chervona > shovta)
			//		{
			//			panel1.Location = new Point(4, 321);
			//		}
			//		else
			//		{
			//			if (chervona < orangeva && chervona > bila && chervona > zelena && chervona > sunia && chervona > shovta)
			//			{
			//				panel1.Location = new Point(4, 321);
			//			}
			//			else
			//			{
			//				if (chervona < sunia && chervona > bila && chervona > zelena && chervona > orangeva && chervona > shovta)
			//				{
			//					panel1.Location = new Point(4, 321);
			//				}
			//				else
			//				{
			//					if (chervona < shovta && chervona > bila && chervona > zelena && chervona > sunia && chervona > orangeva)
			//					{
			//						panel1.Location = new Point(4, 321);
			//					}
			//				}
			//			}
			//		}
			//	}






			//	if (bila < chervona && bila > zelena && bila > orangeva && bila > sunia && bila > shovta)  // біла доріжка друге місце
			//	{
			//		panel3.Location = new Point(4, 321);
			//	}
			//	else
			//	{
			//		if (bila < zelena && bila > chervona && bila >orangeva && bila > sunia && bila > shovta)
			//		{
			//			panel3.Location = new Point(4, 321);
			//		}
			//		else
			//		{
			//			if (bila < orangeva && bila > zelena && bila > chervona && bila > sunia && bila > shovta)
			//			{
			//				panel3.Location = new Point(4, 321);
			//			}
			//			else
			//			{
			//				if (bila < sunia && bila > zelena && bila > orangeva && bila > chervona && bila > shovta)
			//				{
			//					panel3.Location = new Point(4, 321);
			//				}
			//				else
			//				{
			//					if (bila < shovta && bila > zelena && bila > orangeva && bila > sunia && bila > chervona)
			//					{
			//						panel3.Location = new Point(4, 321);
			//					}
			//				}
			//			}
			//		}
			//	}



			//	if (zelena < chervona && zelena > bila && zelena > orangeva && zelena > sunia && zelena > shovta) // зелена доріжка друге місце
			//	{
			//		panel4.Location = new Point(4, 321);
			//	}
			//	else
			//	{

			//		if (zelena < bila && zelena > chervona && zelena > orangeva && zelena > sunia && zelena > shovta)
			//		{
			//			panel4.Location = new Point(4, 321);
			//		}
			//		else
			//		{

			//			if (zelena < orangeva && zelena > bila && zelena > chervona && zelena > sunia && zelena > shovta)
			//			{
			//				panel4.Location = new Point(4, 321);
			//			}
			//			else
			//			{

			//				if (zelena < sunia && zelena > bila && zelena > orangeva && zelena > chervona && zelena > shovta)
			//				{
			//					panel4.Location = new Point(4, 321);
			//				}
			//				else
			//				{

			//					if (zelena < shovta && zelena > bila && zelena > orangeva && zelena > sunia && zelena > chervona)
			//					{
			//						panel4.Location = new Point(4, 321);
			//					}
			//				}
			//			}
			//		}
			//	}





			//	if (orangeva < chervona && orangeva > bila && orangeva > zelena && orangeva > sunia & orangeva > shovta) // оранжева доріжка друге місце
			//	{
			//		panel5.Location = new Point(4, 321);
			//	}
			//	else
			//	{
			//		if (orangeva < bila && orangeva > chervona && orangeva > zelena && orangeva > sunia & orangeva > shovta)
			//		{
			//			panel5.Location = new Point(4, 321);
			//		}
			//		else
			//		{
			//			if (orangeva < zelena && orangeva > bila && orangeva > chervona && orangeva > sunia & orangeva > shovta)
			//			{
			//				panel5.Location = new Point(4, 321);
			//			}
			//			else
			//			{
			//				if (orangeva < sunia && orangeva > bila && orangeva > zelena && orangeva > chervona & orangeva > shovta)
			//				{
			//					panel5.Location = new Point(4, 321);
			//				}
			//				else
			//				{
			//					if (orangeva < shovta && orangeva > bila && orangeva > zelena && orangeva > sunia & orangeva > chervona)
			//					{
			//						panel5.Location = new Point(4, 321);
			//					}
			//				}
			//			}
			//		}
			//	}





			//	if (sunia < chervona && sunia > bila && sunia > zelena && sunia > orangeva && sunia > shovta)      // синя доріжка друге місце
			//	{
			//		panel10.Location = new Point(4, 321);
			//	}
			//	else
			//	{
			//		if (sunia < bila && sunia > chervona && sunia > zelena && sunia > orangeva && sunia > shovta)
			//		{
			//			panel10.Location = new Point(4, 321);
			//		}
			//		else
			//		{
			//			if (sunia < zelena && sunia > bila && sunia > chervona && sunia > orangeva && sunia > shovta)
			//			{
			//				panel10.Location = new Point(4, 321);
			//			}
			//			else
			//			{
			//				if (sunia < orangeva && sunia > bila && sunia > zelena && sunia >= chervona && sunia > shovta)
			//				{
			//					panel10.Location = new Point(4, 321);
			//				}
			//				else
			//				{
			//					if (sunia < shovta && sunia > bila && sunia > zelena && sunia > orangeva && sunia > chervona)
			//					{
			//						panel10.Location = new Point(4, 321);
			//					}
			//				}
			//			}
			//		}
			//	}





			//	if (shovta < chervona && shovta > bila && shovta > zelena && shovta > orangeva && shovta > sunia)          // жовта доріжка друге місце
			//	{
			//		panel11.Location = new Point(4, 321);
			//	}
			//	else
			//	{
			//		if (shovta < bila && shovta > chervona && shovta > zelena && shovta > orangeva && shovta > sunia)
			//		{
			//			panel11.Location = new Point(4, 321);
			//		}
			//		else
			//		{
			//			if (shovta < zelena && shovta > bila && shovta > chervona && shovta > orangeva && shovta > sunia)
			//			{
			//				panel11.Location = new Point(4, 321);
			//			}
			//			else
			//			{
			//				if (shovta < orangeva && shovta > bila && shovta > zelena && shovta > chervona && shovta > sunia)
			//				{
			//					panel11.Location = new Point(4, 321);
			//				}
			//				else
			//				{
			//					if (shovta < sunia && shovta > bila && shovta > zelena && shovta > orangeva && shovta > chervona)
			//					{
			//						panel11.Location = new Point(4, 321);
			//					}
			//				}
			//			}
			//		}
			//	}





			//	if (chervona < bila && chervona < zelena && chervona > orangeva && chervona > sunia && chervona > shovta)  // червона третє місце
			//	{
			//		panel1.Location = new Point(4, 423);
			//	}
			//	else
			//	{
			//		if (chervona < bila && chervona < orangeva && chervona > zelena && chervona > sunia && chervona > shovta)
			//		{
			//			panel1.Location = new Point(4, 423);
			//		}
			//		else
			//		{
			//			if (chervona < bila && chervona < sunia && chervona > orangeva && chervona > zelena && chervona > shovta)
			//			{
			//				panel1.Location = new Point(4, 423);
			//			}
			//			else
			//			{
			//				if (chervona < bila && chervona < shovta && chervona > orangeva && chervona > sunia && chervona > zelena)
			//				{
			//					panel1.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (chervona < orangeva && chervona < zelena && chervona >bila && chervona > sunia && chervona > shovta)
			//					{
			//						panel1.Location = new Point(4, 423);
			//					}
			//					else
			//					{
			//						if (chervona < sunia && chervona < zelena && chervona > orangeva && chervona > bila && chervona > shovta)
			//						{
			//							panel1.Location = new Point(4, 423);
			//						}
			//						else
			//						{
			//							if (chervona < shovta && chervona < zelena && chervona > orangeva && chervona > sunia && chervona > bila)
			//							{
			//								panel1.Location = new Point(4, 423);
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}





			//	if (bila < chervona && bila < zelena && bila > orangeva && bila > sunia && bila > shovta)   // біла третє місце
			//	{
			//		panel3.Location = new Point(4, 423);
			//	}
			//	else
			//	{
			//		if (bila < chervona && bila < orangeva && bila > zelena && bila > sunia && bila > shovta)
			//		{
			//			panel3.Location = new Point(4, 423);
			//		}
			//		else
			//		{
			//			if (bila < chervona && bila < sunia && bila > orangeva && bila > zelena && bila > shovta)
			//			{
			//				panel3.Location = new Point(4, 423);
			//			}
			//			else
			//			{
			//				if (bila < chervona && bila < shovta && bila > orangeva && bila > sunia && bila > zelena)
			//				{
			//					panel3.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (bila < orangeva && bila < zelena && bila > chervona && bila > sunia && bila > shovta)
			//					{
			//						panel3.Location = new Point(4, 423);
			//					}
			//					else
			//					{
			//						if (bila < sunia && bila < zelena && bila > orangeva && bila > zelena && bila > shovta)
			//						{
			//							panel3.Location = new Point(4, 423);
			//						}
			//						else
			//						{
			//							if (bila < shovta && bila < zelena && bila > orangeva && bila > sunia && bila > zelena)
			//							{
			//								panel3.Location = new Point(4, 423);
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}







			//	if (zelena < chervona && zelena < bila && zelena > orangeva && zelena > sunia && zelena > shovta)  // зелена третє місце
			//	{
			//		panel4.Location = new Point(4, 423);
			//	}
			//	else
			//	{
			//		if (zelena < chervona && zelena < orangeva && zelena > bila && zelena > sunia && zelena > shovta)
			//		{
			//			panel4.Location = new Point(4, 423);
			//		}
			//		else
			//		{
			//			if (zelena < chervona && zelena < sunia && zelena > orangeva && zelena > bila && zelena > shovta)
			//			{
			//				panel4.Location = new Point(4, 423);
			//			}
			//			else
			//			{
			//				if (zelena < chervona && zelena < shovta && zelena > orangeva && zelena > sunia && zelena > bila)
			//				{
			//					panel4.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (zelena < orangeva && zelena < bila && zelena > chervona && zelena > sunia && zelena > shovta)
			//					{
			//						panel4.Location = new Point(4, 423);
			//					}
			//					else
			//					{
			//						if (zelena < sunia && zelena < bila && zelena > orangeva && zelena > chervona && zelena > shovta)
			//						{
			//							panel4.Location = new Point(4, 423);
			//						}
			//						else
			//						{
			//							if (zelena < shovta && zelena < bila && zelena > orangeva && zelena > sunia && zelena > chervona)
			//							{
			//								panel4.Location = new Point(4, 423);
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}





			//	if (orangeva < chervona && orangeva < bila && orangeva > zelena && orangeva > sunia && orangeva > shovta)    // оранжева третє місце
			//	{
			//		panel5.Location = new Point(4, 423);
			//	}
			//	else
			//	{
			//		if (orangeva < chervona && orangeva < zelena && orangeva > bila && orangeva > sunia && orangeva > shovta)
			//		{
			//			panel5.Location = new Point(4, 423);
			//		}
			//		else
			//		{
			//			if (orangeva < chervona && orangeva < sunia && orangeva > zelena && orangeva > bila && orangeva > shovta)
			//			{
			//				panel5.Location = new Point(4, 423);
			//			}
			//			else
			//			{
			//				if (orangeva < chervona && orangeva < shovta && orangeva > zelena && orangeva > sunia && orangeva > bila)
			//				{
			//					panel5.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (orangeva < zelena && orangeva < bila && orangeva > chervona && orangeva > sunia && orangeva > shovta)
			//					{
			//						panel5.Location = new Point(4, 423);
			//					}
			//					else
			//					{
			//						if (orangeva < sunia && orangeva < bila && orangeva > zelena && orangeva > bila && orangeva > shovta)
			//						{
			//							panel5.Location = new Point(4, 423);
			//						}
			//						else
			//						{
			//							if (orangeva < shovta && orangeva < bila && orangeva > zelena && orangeva > sunia && orangeva > bila)
			//							{
			//								panel5.Location = new Point(4, 423);
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}








			//	if (sunia < chervona && sunia < bila && sunia > zelena && sunia > orangeva && sunia > shovta)                // синя третє місце
			//	{
			//		panel10.Location = new Point(4, 423);
			//	}
			//	else
			//	{
			//		if (sunia < chervona && sunia < zelena && sunia > bila && sunia > orangeva && sunia > shovta)
			//		{
			//			panel10.Location = new Point(4, 423);
			//		}
			//		else
			//		{
			//			if (sunia < chervona && sunia < orangeva && sunia >zelena && sunia > bila && sunia > shovta)
			//			{
			//				panel10.Location = new Point(4, 423);
			//			}
			//			else
			//			{
			//				if (sunia < chervona && sunia < shovta && sunia > zelena && sunia > orangeva && sunia >bila)
			//				{
			//					panel10.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (sunia < zelena && sunia < bila && sunia > chervona && sunia > orangeva && sunia > shovta)
			//					{
			//						panel10.Location = new Point(4, 423);
			//					}
			//					else
			//					{
			//						if (sunia < orangeva && sunia < bila && sunia > zelena && sunia > chervona && sunia > shovta)
			//						{
			//							panel10.Location = new Point(4, 423);
			//						}
			//						else
			//						{

			//							if (sunia < shovta && sunia < bila && sunia > zelena && sunia > orangeva && sunia >= chervona)
			//							{
			//								panel10.Location = new Point(4, 423);
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}

			//}





			//	if (shovta < chervona && shovta < bila && shovta >zelena && shovta > orangeva && shovta > sunia)  // жовта третє місце
			//	{
			//		panel11.Location = new Point(4, 423);
			//	}
			//	else
			//	{
			//		if (shovta < chervona && shovta < zelena && shovta > bila && shovta > orangeva && shovta > sunia)
			//		{
			//			panel11.Location = new Point(4, 423);
			//		}
			//		else
			//		{
			//			if (shovta < chervona && shovta < orangeva && shovta > zelena && shovta > bila && shovta > sunia)
			//			{
			//				panel11.Location = new Point(4, 423);
			//			}
			//			else
			//			{
			//				if (shovta < chervona && shovta < sunia && shovta > zelena && shovta > orangeva && shovta > bila)
			//				{
			//					panel11.Location = new Point(4, 423);
			//				}
			//				else
			//				{
			//					if (shovta < zelena && shovta < bila && shovta > chervona && shovta > orangeva && shovta > sunia)
			//					{
			//						panel11.Location = new Point(4, 423);
			//					}
			//					else
			//					{
			//						if (shovta < orangeva && shovta < bila && shovta >zelena && shovta > chervona && shovta > sunia)
			//						{
			//							panel11.Location = new Point(4, 423);
			//						}
			//						else
			//						{
			//							if (shovta < sunia && shovta < bila && shovta > zelena && shovta > orangeva && shovta > chervona)
			//							{
			//								panel11.Location = new Point(4, 423);
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}






			//	if (chervona < bila && chervona < zelena && chervona < orangeva && chervona > sunia && chervona > shovta)  //червона четверте місце
			//	{
			//		panel1.Location = new Point(4, 525);
			//	}
			//	else
			//	{
			//		if (chervona < sunia && chervona < zelena && chervona < orangeva && chervona > bila && chervona > shovta)
			//		{
			//			panel1.Location = new Point(4, 525);
			//		}
			//		else
			//		{
			//			if (chervona < shovta && chervona < zelena && chervona < orangeva && chervona > sunia && chervona > bila)
			//			{
			//				panel1.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (chervona < bila && chervona < orangeva && chervona < zelena && chervona > sunia && chervona > shovta)
			//				{
			//					panel1.Location = new Point(4, 525);
			//				}
			//				else
			//				{
			//					if (chervona < bila && chervona < sunia && chervona < orangeva && chervona > zelena && chervona > shovta)
			//					{
			//						panel1.Location = new Point(4, 525);
			//					}
			//					else
			//					{
			//						if (chervona < bila && chervona < shovta && chervona < orangeva && chervona > sunia && chervona > zelena)
			//						{
			//							panel1.Location = new Point(4, 525);
			//						}
			//						else
			//						{
			//							if (chervona < bila && chervona < zelena && chervona < sunia && chervona > orangeva && chervona > shovta)
			//							{
			//								panel1.Location = new Point(4, 525);
			//							}
			//							else
			//							{
			//								if (chervona < bila && chervona < zelena && chervona < shovta && chervona > sunia && chervona > orangeva)
			//								{
			//									panel1.Location = new Point(4, 525);
			//								}
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}






			//	if (bila < chervona && bila < zelena && bila < orangeva && bila > sunia && bila > shovta)  // біла четверте місце
			//	{
			//		panel3.Location = new Point(4, 525);
			//	}
			//	else
			//	{
			//		if (bila < sunia && bila < zelena && bila < orangeva && bila > chervona && bila > shovta)
			//		{
			//			panel3.Location = new Point(4, 525);
			//		}
			//		else
			//		{
			//			if (bila < shovta && bila < zelena && bila < orangeva && bila > sunia && bila > chervona)
			//			{
			//				panel3.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (bila < chervona && bila < sunia && bila < orangeva && bila > zelena && bila > shovta)
			//				{
			//					panel3.Location = new Point(4, 525);
			//				}
			//				else
			//				{
			//					if (bila < chervona && bila < sunia && bila < orangeva && bila > zelena && bila > shovta)
			//					{
			//						panel3.Location = new Point(4, 525);
			//					}
			//					else
			//					{
			//						if (bila < chervona && bila < shovta && bila < orangeva && bila > sunia && bila > zelena)
			//						{
			//							panel3.Location = new Point(4, 525);
			//						}
			//						else
			//						{
			//							if (bila < chervona && bila < zelena && bila < sunia && bila > orangeva && bila > shovta)
			//							{
			//								panel3.Location = new Point(4, 525);
			//							}
			//							else
			//							{
			//								if (bila < chervona && bila < zelena && bila < shovta && bila > sunia && bila > orangeva)
			//								{
			//									panel3.Location = new Point(4, 525);
			//								}
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}





			//	if (zelena < chervona && zelena < bila && zelena < orangeva && zelena > sunia && zelena > shovta) // зелена четверте місце
			//	{
			//		panel4.Location = new Point(4, 525);
			//	}
			//	else
			//	{
			//		if (zelena < sunia && zelena < bila && zelena < orangeva && zelena > chervona && zelena > shovta)
			//		{
			//			panel4.Location = new Point(4, 525);
			//		}
			//		else
			//		{
			//			if (zelena < shovta && zelena < bila && zelena < orangeva && zelena > sunia && zelena > chervona)
			//			{
			//				panel4.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (zelena < chervona && zelena < sunia && zelena < orangeva && zelena > bila && zelena > shovta)
			//				{
			//					panel4.Location = new Point(4, 525);
			//				}
			//				else
			//				{
			//					if (zelena < chervona && zelena < shovta && zelena < orangeva && zelena > sunia && zelena > bila)
			//					{
			//						panel4.Location = new Point(4, 525);
			//					}
			//					else
			//					{
			//						if (zelena < chervona && zelena < bila && zelena < sunia && zelena > orangeva && zelena > shovta)
			//						{
			//							panel4.Location = new Point(4, 525);
			//						}
			//						else
			//						{
			//							if (zelena < chervona && zelena < bila && zelena < shovta && zelena > sunia && zelena > orangeva)
			//							{
			//								panel4.Location = new Point(4, 525);
			//							}
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}







			//	if (orangeva < chervona && orangeva < bila && orangeva < zelena && orangeva > sunia && orangeva > shovta)  // оранжева четверте місце
			//	{
			//		panel5.Location = new Point(4, 525);
			//	}
			//	else
			//	{
			//		if (orangeva < sunia && orangeva < bila && orangeva < zelena && orangeva > chervona && orangeva > shovta)
			//		{
			//			panel5.Location = new Point(4, 525);
			//		}
			//		else
			//		{
			//			if (orangeva < shovta && orangeva < bila && orangeva < zelena && orangeva > sunia && orangeva > chervona)
			//			{
			//				panel5.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (orangeva < chervona && orangeva < sunia && orangeva < zelena && orangeva > bila && orangeva > shovta)
			//				{
			//					panel5.Location = new Point(4, 525);
			//				}
			//				else
			//				{
			//					if (orangeva < chervona && orangeva < shovta && orangeva < zelena && orangeva > sunia && orangeva > bila)
			//					{
			//						panel5.Location = new Point(4, 525);
			//					}
			//					else
			//					{
			//						if (orangeva < chervona && orangeva < bila && orangeva < sunia && orangeva > zelena && orangeva > shovta)
			//						{
			//							panel5.Location = new Point(4, 525);
			//						}
			//						else
			//						{
			//							if (orangeva < chervona && orangeva < bila && orangeva < shovta && orangeva > sunia && orangeva > zelena)
			//							{
			//								panel5.Location = new Point(4, 525);
			//							}
			//						}
			//					}
			//				}

			//		}
			//	}
			//}






			//	if (sunia < chervona && sunia < bila && sunia < zelena && sunia > orangeva && sunia > shovta) // синя четверте місце
			//	{
			//		panel10.Location = new Point(4, 525);
			//	}
			//	else
			//	{
			//		if (sunia < orangeva && sunia < bila && sunia < zelena && sunia > chervona && sunia > shovta)
			//		{
			//			panel10.Location = new Point(4, 525);
			//		}
			//		else
			//		{
			//			if (sunia < shovta && sunia < bila && sunia < zelena && sunia > orangeva && sunia > chervona)
			//			{
			//				panel10.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (sunia < chervona && sunia < orangeva && sunia < zelena && sunia > bila && sunia > shovta)
			//				{
			//					panel10.Location = new Point(4, 525);
			//				}
			//				else
			//				{
			//					if (sunia < chervona && sunia < shovta && sunia < zelena && sunia > orangeva && sunia > bila)
			//					{
			//						panel10.Location = new Point(4, 525);
			//					}
			//					else
			//					{
			//						if (sunia < chervona && sunia < bila && sunia < orangeva && sunia > zelena && sunia > shovta)
			//						{
			//							panel10.Location = new Point(4, 525);
			//						}
			//						else
			//						{
			//							if (sunia < chervona && sunia < bila && sunia < shovta && sunia > orangeva && sunia > zelena)
			//							{
			//								panel10.Location = new Point(4, 525);
			//							}
			//						}
			//					}

			//			}
			//		}
			//	}
			//}






			//	if (shovta < chervona && shovta < bila && shovta < zelena && shovta > orangeva && shovta > sunia) // жовта четверте місце
			//	{
			//		panel11.Location = new Point(4, 525);
			//	}
			//	else
			//	{
			//		if (shovta < orangeva && shovta < bila && shovta < zelena && shovta > chervona && shovta > sunia)
			//		{
			//			panel11.Location = new Point(4, 525);
			//		}
			//		else
			//		{
			//			if (shovta < sunia && shovta < bila && shovta < zelena && shovta > orangeva && shovta > chervona)
			//			{
			//				panel11.Location = new Point(4, 525);
			//			}
			//			else
			//			{
			//				if (shovta < chervona && shovta < orangeva && shovta < zelena && shovta > bila && shovta > sunia)
			//				{
			//					panel11.Location = new Point(4, 525);
			//				}
			//				else
			//				{
			//					if (shovta < chervona && shovta < sunia && shovta < zelena && shovta > orangeva && shovta > bila)
			//					{
			//						panel11.Location = new Point(4, 525);
			//					}
			//					else
			//					{
			//						if (shovta < chervona && shovta < bila && shovta < orangeva && shovta > zelena && shovta > sunia)
			//						{
			//							panel11.Location = new Point(4, 525);
			//						}
			//						else
			//						{
			//							if (shovta < chervona && shovta < bila && shovta < sunia && shovta > orangeva && shovta > zelena)
			//							{
			//								panel11.Location = new Point(4, 525);
			//							}
			//						}
			//					}
			//				}
			//			}

			//	}

			//}






			//	if (chervona < bila && chervona < zelena && chervona < orangeva && chervona < sunia && chervona > shovta)  // червона 5 місце
			//	{
			//		panel1.Location = new Point(4, 628);
			//	}
			//	else
			//	{
			//		if (chervona < shovta && chervona < zelena && chervona < orangeva && chervona < sunia && chervona > bila)
			//		{
			//			panel1.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (chervona < bila && chervona < shovta && chervona < orangeva && chervona < sunia && chervona > zelena)
			//			{
			//				panel1.Location = new Point(4, 628);
			//			}
			//			else
			//			{
			//				if (chervona < bila && chervona < zelena && chervona < shovta && chervona < sunia && chervona > orangeva)
			//				{
			//					panel1.Location = new Point(4, 628);
			//				}
			//				else
			//				{
			//					if (chervona < bila && chervona < zelena && chervona < orangeva && chervona < shovta && chervona > sunia)
			//					{
			//						panel1.Location = new Point(4, 628);
			//					}
			//				}
			//			}
			//		}

			//}






			//	if (bila < chervona && bila < zelena && bila < orangeva && bila < sunia && bila >= shovta)   // біла 5 місце
			//	{
			//		panel3.Location = new Point(4, 628);
			//	}
			//	else
			//	{
			//		if (bila < shovta && bila < zelena && bila < orangeva && bila < sunia && bila > chervona)
			//		{
			//			panel3.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (bila < chervona && bila < shovta && bila < orangeva && bila < sunia && bila > zelena)
			//			{
			//				panel3.Location = new Point(4, 628);
			//			}
			//			else
			//			{
			//				if (bila < chervona && bila < zelena && bila < shovta && bila < sunia && bila > orangeva)
			//				{
			//					panel3.Location = new Point(4, 628);
			//				}
			//				else
			//				{
			//					if (bila < chervona && bila < zelena && bila < orangeva && bila < shovta && bila > sunia)
			//					{
			//						panel3.Location = new Point(4, 628);
			//					}
			//				}
			//			}
			//		}

			//}





			//	if (zelena < chervona && zelena < bila && zelena < orangeva && zelena < sunia && zelena >=shovta)  // зелена 5 місце
			//	{
			//		panel4.Location = new Point(4, 628);
			//	}
			//	else
			//	{
			//		if (zelena < shovta && zelena < bila && zelena < orangeva && zelena < sunia && zelena > chervona)
			//		{
			//			panel4.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (zelena < chervona && zelena < shovta && zelena < orangeva && zelena < sunia && zelena > bila)
			//			{
			//				panel4.Location = new Point(4, 628);
			//			}
			//			else
			//			{
			//				if (zelena < chervona && zelena < bila && zelena < shovta && zelena < sunia && zelena > orangeva)
			//				{
			//					panel4.Location = new Point(4, 628);
			//				}
			//				else
			//				{
			//					if (zelena < chervona && zelena < bila && zelena < orangeva && zelena < shovta && zelena > sunia)
			//					{
			//						panel4.Location = new Point(4, 628);
			//					}

			//				}
			//			}
			//		}
			//	}






			//	if (orangeva < chervona && orangeva < bila && orangeva < zelena && orangeva < sunia && orangeva > shovta) // оранжева 5 місце
			//	{
			//		panel5.Location = new Point(4, 628);
			//	}
			//	else
			//	{
			//		if (orangeva < shovta && orangeva < bila && orangeva < zelena && orangeva < sunia && orangeva > chervona)
			//		{
			//			panel5.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (orangeva < chervona && orangeva < shovta && orangeva < zelena && orangeva < sunia && orangeva > bila)
			//			{
			//				panel5.Location = new Point(4, 628);
			//			}
			//			else
			//			{
			//				if (orangeva < chervona && orangeva < bila && orangeva < shovta && orangeva < sunia && orangeva > zelena)
			//				{
			//					panel5.Location = new Point(4, 628);
			//				}
			//				else
			//				{
			//					if (orangeva < chervona && orangeva < bila && orangeva < zelena && orangeva < shovta && orangeva > sunia)
			//					{
			//						panel5.Location = new Point(4, 628);
			//					}
			//				}
			//			}
			//		}

			//}






			//	if (sunia < chervona && sunia < bila && sunia < zelena && sunia < orangeva && sunia > shovta) //синя 5 місце
			//	{
			//		panel10.Location = new Point(4, 628);
			//	}
			//	else
			//	{
			//		if (sunia < shovta && sunia < bila && sunia < zelena && sunia < orangeva && sunia > chervona)
			//		{
			//			panel10.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (sunia < chervona && sunia < shovta && sunia < zelena && sunia < orangeva && sunia > bila)
			//			{
			//				panel10.Location = new Point(4, 628);
			//			}
			//			else
			//			{
			//				if (sunia < chervona && sunia < bila && sunia < shovta && sunia < orangeva && sunia > zelena)
			//				{
			//					panel10.Location = new Point(4, 628);
			//				}
			//				else
			//				{

			//					if (sunia < chervona && sunia < bila && sunia < zelena && sunia < shovta && sunia > orangeva)
			//					{
			//						panel10.Location = new Point(4, 628);
			//					}
			//				}
			//			}
			//		}
			//	}








			//	if (shovta < chervona && shovta < bila && shovta < zelena && shovta < orangeva && shovta > sunia) // жовта 5 місце
			//	{
			//		panel11.Location = new Point(4, 628);
			//	}
			//	else
			//	{
			//		if (shovta < sunia && shovta < bila && shovta < zelena && shovta < orangeva && shovta > chervona)
			//		{
			//			panel11.Location = new Point(4, 628);
			//		}
			//		else
			//		{
			//			if (shovta < chervona && shovta < sunia && shovta < zelena && shovta < orangeva && shovta > bila)
			//			{
			//				panel11.Location = new Point(4, 628);
			//			}
			//			else
			//			{
			//				if (shovta < chervona && shovta < bila && shovta < sunia && shovta < orangeva && shovta > zelena)
			//				{
			//					panel11.Location = new Point(4, 628);
			//				}
			//				else
			//				{
			//					if (shovta < chervona && shovta < bila && shovta < zelena && shovta < sunia && shovta > orangeva)
			//					{
			//						panel11.Location = new Point(4, 628);
			//					}
			//				}
			//			}
			//		}
			//	}




			//if (chervona < bila && chervona < zelena && chervona < orangeva && chervona < sunia && chervona < shovta)
			//{

			//	panel1.Location = new Point(4, 731);
			//}

			//if (bila < chervona && bila < zelena && bila < orangeva && bila < sunia && bila < shovta)
			//{
			//	panel3.Location = new Point(4, 731);
			//}

			//if (zelena < chervona && zelena < bila && zelena < orangeva && zelena < sunia && zelena < shovta)
			//{
			//	panel4.Location = new Point(4, 731);
			//}

			//if (orangeva < chervona && orangeva < bila && orangeva < zelena && orangeva < sunia && orangeva < shovta)
			//{
			//	panel5.Location = new Point(4, 731);
			//}

			//if (sunia < chervona && sunia < bila && sunia < zelena && sunia < orangeva && sunia < shovta)
			//{
			//	panel10.Location = new Point(4, 731);
			//}

			//if (shovta < chervona && shovta < bila && shovta < zelena && shovta < orangeva && shovta < sunia)
			//{
			//	panel11.Location = new Point(4, 731);
			//}






		}


		private void timer19_Tick(object sender, EventArgs e)
		{
			if (serialPort1.IsOpen == true && timer3.Enabled == true || timer5.Enabled == true || timer7.Enabled == true || timer32.Enabled == true || timer33.Enabled == true)
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
				for (int j = 1; j < 2; j++) //по всем колонкам
					s += list[i, j];
				listBox1.Items.Add(s);
			}


			button4.Visible = false;

			button3.Visible = false;


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

		private void button3_Click(object sender, EventArgs e)
		{
			label49.Visible = true;
			comboBox1.Visible = true;
			button5.Visible = true;
			button4.Visible = false;
			button3.Visible = false;
			label88.Visible = true;
			label89.Visible = true;
			textBox26.Visible = true;
			textBox27.Visible = true;
			button20.Visible = true;
			label137.Visible = true;
			textBox39.Visible = true;




		}

		private void button5_Click(object sender, EventArgs e)
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



			label55.Visible = false;
			label59.Visible = false;
			label60.Visible = false;
			label61.Visible = false;
			label62.Visible = false;
			label75.Visible = false;
			label104.Visible = false;
			label124.Visible = false;
			label54.Visible = false;
			label57.Visible =false;
			label58.Visible = false;
			label118.Visible = false;
			label120.Visible = false;
			label122.Visible = false;

			textBox1.Location = new Point(92, -13);
			textBox1.Size = new Size(301, 151);
			textBox6.Location = new Point(92, -5);
			textBox6.Size = new Size(301, 151);
			textBox9.Location = new Point(92, -5);
			textBox9.Size = new Size(301, 151);
			textBox12.Location = new Point(92, 1);
			textBox12.Size = new Size(301, 151);
			label17.Location = new Point(88, -10);
			label24.Location = new Point(88, -6);
			label23.Location = new Point(88, -6);
			label25.Location = new Point(88, -10);
			textBox2.Location = new Point(431, 7);
			textBox2.Size = new Size(1083, 80);
			textBox5.Location = new Point(431, 7);
			textBox5.Size = new Size(1083, 80);
			textBox8.Location = new Point(431, 7);
			textBox8.Size = new Size(1083, 80);
			textBox11.Location = new Point(431, 7);
			textBox11.Size = new Size(1083, 80);
			label7.Text = "Круги";
			label5.Visible = false;
			label9.Location = new Point(878, 8);
			label22.Location = new Point(431, 26);
			label19.Location = new Point(610, 26);
			label20.Location = new Point(803, 26);
			label76.Visible = true;
			label77.Visible = true;
			label78.Visible = true;
			label30.Location = new Point(431, 26);
			label32.Location = new Point(610, 26);
			label31.Location = new Point(803, 26);
			label79.Visible = true;
			label80.Visible = true;
			label81.Visible = true;
			label34.Location = new Point(431, 26);
			label36.Location = new Point(610, 26);
			label35.Location = new Point(803, 26);
			label82.Visible = true;
			label83.Visible = true;
			label84.Visible = true;
			label39.Location = new Point(431, 26);
			label41.Location = new Point(610, 26);
			label40.Location = new Point(803, 26);
			label87.Visible = true;
			label86.Visible = true;
			label85.Visible = true;
			button17.Visible = true;
			timer18.Enabled = false;
			textBox3.Size = new Size(223, 80);
			textBox4.Size = new Size(223, 80);
			textBox7.Size = new Size(223, 80);
			textBox10.Size = new Size(223, 80);
			textBox31.Location = new Point(92, -2);
			textBox35.Location = new Point(92, -2);
			textBox31.Size = new Size(301, 151);
			textBox35.Size = new Size(301, 151);
			label97.Location = new Point(88, -11);
			label112.Location = new Point(88, -11);
			textBox30.Location = new Point(431, 7);
			textBox30.Size = new Size(1083, 80);
			textBox34.Location = new Point(431, 7);
			textBox34.Size = new Size(1083, 80);
			label74.Location = new Point(431, 26);
			label72.Location = new Point(610, 26);
			label94.Location = new Point(803, 26);
			label93.Visible = true;
			label11.Visible = true;
			label96.Visible = true;
			label103.Location = new Point(431, 26);
			label101.Location = new Point(610, 26);
			label100.Location = new Point(803, 26);
			label108.Visible = true;
			label111.Visible = true;
			label109.Visible = true;








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
				case 36:
					{
						label71.Text = "Група - << J >>";
						break;
					}

				case 32:
					{
						label71.Text = "Група - << I >>";
						break;
					}
				case 28:
					{
						label71.Text = "Група - << H >>";
						break;
					}
				case 24:
					{
						label71.Text = "Група - << G >>";
						break;
					}
				case 20:
					{
						label71.Text = "Група - << F >>";
						break;
					}
				case 16:
					{
						label71.Text = "Група - << E >>";
						break;
					}
				case 12:
					{
						label71.Text = "Група - << D >>";
						break;
					}
				case 8:
					{
						label71.Text = "Група - << C >>";
						break;
					}
				case 4:
					{
						label71.Text = "Група - << B >>";
						break;
					}
				case 0:
					{
						label71.Text = "Група - << A >>";
						break;
					}
				case 228:
					{
						label71.Text = "<< Фінал! >>";
						break;
					}

			}






			//алгоритм сортування відставання до суперника


			if (Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text))


			{

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

				//алгоритм сортування жовтої доріжки по місцям

				if (Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text))

				{
					if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
					{
						panel5.Location = new Point(7, 213);

					}
					else
					{
						if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text))
						{
							panel5.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
							{
								panel5.Location = new Point(7, 358);
							}
							else
							{
								if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
								{
									panel5.Location = new Point(7, 358);
								}
								else
								{




									if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text))
									{
										panel5.Location = new Point(7, 502);
									}
									else
									{
										if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text))
										{
											panel5.Location = new Point(7, 502);
										}
										else
										{
											if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
											{
												panel5.Location = new Point(7, 502);
											}
											else
											{

												if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
												{
													panel5.Location = new Point(7, 645);
												}
												else
												{
													if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text))
													{
														panel5.Location = new Point(7, 502);
													}
													else
													{
														if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
														{
															panel5.Location = new Point(7, 502);
														}
														else
														{
															if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
															{
																panel5.Location = new Point(7, 502);
															}
															else
															{
																if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text))
																{
																	panel5.Location = new Point(7, 358);

																}
																else
																{
																	if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text))
																	{
																		panel5.Location = new Point(7, 358);
																	}
																	else
																	{
																		if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
																		{
																			panel5.Location = new Point(7, 358);
																		}
																	}
																}

															}

														}

													}

												}
											}
										}
									}
								}

							}
						}
					}
				}


				//алгоритм сортування синьої доріжки по місцям
				if (Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text))
				{
					if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
					{
						panel4.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text))
						{
							panel4.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
							{
								panel4.Location = new Point(7, 358);
							}
							else
							{
								if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
								{
									panel4.Location = new Point(7, 358);
								}
								else
								{

									if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text))
									{
										panel4.Location = new Point(7, 502);
									}
									else
									{
										if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text))
										{
											panel4.Location = new Point(7, 502);
										}
										else
										{
											if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
											{
												panel4.Location = new Point(7, 502);
											}
											else
											{


												if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
												{
													panel4.Location = new Point(7, 645);

												}
												else
												{
													if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text))
													{
														panel4.Location = new Point(7, 502);
													}
													else
													{
														if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
														{
															panel4.Location = new Point(7, 502);
														}
														else
														{
															if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
															{
																panel4.Location = new Point(7, 502);
															}
															else
															{
																if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text))
																{
																	panel4.Location = new Point(7, 358);
																}
																else
																{
																	if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
																	{
																		panel4.Location = new Point(7, 358);
																	}
																	else
																	{
																		if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text))
																		{
																			panel4.Location = new Point(7, 358);
																		}
																	}
																}
															}
														}
													}

												}
											}
										}
									}

								}
							}
						}
					}
				}

				//алгоритм сортування зеленої доріжки по місцям
				if (Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text))
				{
					if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label17.Text))
					{
						panel3.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label23.Text))
						{
							panel3.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label17.Text))
							{
								panel3.Location = new Point(7, 358);
							}
							else
							{
								if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label17.Text))
								{
									panel3.Location = new Point(7, 358);
								}
								else
								{


									if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text))
									{
										panel3.Location = new Point(7, 502);


									}
									else
									{
										if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
										{
											panel3.Location = new Point(7, 645);
										}
										else
										{
											if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text))
											{
												panel3.Location = new Point(7, 502);
											}
											else
											{
												if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
												{
													panel3.Location = new Point(7, 502);
												}
												else
												{
													if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
													{
														panel3.Location = new Point(7, 502);
													}
													else
													{
														if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text))
														{
															panel3.Location = new Point(7, 358);
														}
														else
														{
															if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
															{
																panel3.Location = new Point(7, 358);
															}
															else
															{
																if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text))
																{
																	panel3.Location = new Point(7, 358);
																}
															}
														}
													}




												}
											}
										}
									}
								}
							}

						}
					}
				}

				//алгоритм сортування червоної доріжки по місцям
				if (Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text))
				{
					if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
					{
						panel1.Location = new Point(7, 213);
					}
					else
					{
						if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text))
						{
							panel1.Location = new Point(7, 358);
						}
						else
						{
							if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
							{
								panel1.Location = new Point(7, 358);
							}
							else
							{
								if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
								{
									panel1.Location = new Point(7, 358);
								}
								else
								{


									if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text))
									{
										panel1.Location = new Point(7, 502);
									}
									else
									{
										if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
										{
											panel1.Location = new Point(7, 502);
										}
										else
										{
											if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text))
											{
												panel1.Location = new Point(7, 502);
											}
											else
											{



												if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
												{
													panel1.Location = new Point(7, 645);
												}
												else
												{
													if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text))
													{
														panel1.Location = new Point(7, 502);
													}
													else
													{
														if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
														{
															panel1.Location = new Point(7, 502);
														}
														else
														{
															if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
															{
																panel1.Location = new Point(7, 502);
															}
															else
															{
																if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text))
																{
																	panel1.Location = new Point(7, 358);
																}
																else
																{
																	if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text))
																	{
																		panel1.Location = new Point(7, 358);
																	}
																	else
																	{
																		if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
																		{
																			panel1.Location = new Point(7, 358);
																		}
																	}
																}

															}

														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
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
			//		

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

			serialPort1.WriteLine("3");


			//if (serialPort1.IsOpen == true)
			//{
			//	serialPort1.Close();
			//	}


			label69.Text = "Трек виключений";
			label69.BackColor = Color.Red;
			button10.Enabled = true;
			button11.Enabled = false;


			label13.Text = "<<Пауза>>";


			pausesound.Play();
			if (number_group.Text == "0")   // кнопка пауза для 1 заїзду
			{
				//serialPort1.Close();
				timer2.Enabled = false;
				timer17.Enabled = false;
				timer11.Enabled = false;
				timer15.Enabled = false;
				timer16.Enabled = false;
				timer26.Enabled = false;
				timer27.Enabled = false;
				button6.Visible = false;
				button7.Visible = true;
				button7.Focus();
			}

			if (number_group.Text == "1")   // кнопка пауза для 2 заїзду
			{
				//serialPort1.Close();
				timer4.Enabled = false;
				timer17.Enabled = false;
				timer11.Enabled = false;
				timer15.Enabled = false;
				timer16.Enabled = false;
				timer26.Enabled = false;
				timer27.Enabled = false;
				button6.Visible = false;
				button7.Visible = true;
				button7.Focus();
			}

			if (number_group.Text == "2")   // кнопка пауза для 3 заїзду
			{
				//serialPort1.Close();
				timer6.Enabled = false;
				timer17.Enabled = false;
				timer11.Enabled = false;
				timer15.Enabled = false;
				timer16.Enabled = false;
				button6.Visible = false;
				timer26.Enabled = false;
				timer27.Enabled = false;
				button7.Visible = true;
				button7.Focus();
			}

			if (number_group.Text == "3")   // кнопка пауза для 4 заїзду
			{
				//serialPort1.Close();
				timer8.Enabled = false;
				timer17.Enabled = false;
				timer11.Enabled = false;
				timer15.Enabled = false;
				timer16.Enabled = false;
				button6.Visible = false;
				timer26.Enabled = false;
				timer27.Enabled = false;
				button7.Visible = true;
				button7.Focus();
			}

			if (number_group.Text == "4")   // кнопка пауза для 5 заїзду
			{
				//serialPort1.Close();
				timer30.Enabled = false;
				timer17.Enabled = false;
				timer11.Enabled = false;
				timer15.Enabled = false;
				timer16.Enabled = false;
				timer26.Enabled = false;
				timer27.Enabled = false;
				button6.Visible = false;
				button7.Visible = true;
				button7.Focus();
			}
			if (number_group.Text == "5")   // кнопка пауза для 6 заїзду
			{
				//serialPort1.Close();
				timer31.Enabled = false;
				timer17.Enabled = false;
				timer11.Enabled = false;
				timer15.Enabled = false;
				timer16.Enabled = false;
				timer26.Enabled = false;
				timer27.Enabled = false;
				button6.Visible = false;
				button7.Visible = true;
				button7.Focus();
			}

		}

		private void button7_Click(object sender, EventArgs e)
		{
			//if (serialPort1.IsOpen == false)
			//{
			//	serialPort1.Open();
			//}

			start_to_pause.Play();
			timer44.Enabled = true;
			label13.Text = "<<Гонка!>>";
		}

		private void button7_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				startsound.Play();

				if (serialPort1.IsOpen == false)
				{
					serialPort1.Open();
				}

				serialPort1.WriteLine("4");
				label69.Text = "Трек включений";
				label69.BackColor = Color.Green;
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
					timer16.Enabled = false;
					button6.Visible = true;
					button7.Visible = false;
					button6.Focus();
				}






			}
		}

		private void button6_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				serialPort1.WriteLine("3");
				if (serialPort1.IsOpen == true)
				{
					serialPort1.Close();
				}

				pausesound.Play();

				label69.Text = "Трек виключений";
				label69.BackColor = Color.Red;

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
			{
				int bila, chervona, zelena, orangeva, sunia, shovta;

				chervona = Convert.ToInt32(label17.Text);
				bila = Convert.ToInt32(label24.Text);
				zelena = Convert.ToInt32(label23.Text);
				orangeva = Convert.ToInt32(label25.Text);
				sunia = Convert.ToInt32(label97.Text);
				shovta = Convert.ToInt32(label112.Text);

				c++;                                            //добавляю кола 1 доріці
				label24.Text = Convert.ToString(c);


				// алгоритм прогнозу
				if (label15.Text == "1/6")
				{
					double masuv, kola, seredniychas, prognoz;
					kola = Convert.ToDouble(label29.Text);
					masuv = Convert.ToDouble(label56.Text);
					seredniychas2 = Convert.ToDouble(label57.Text);
					kola = (kola + masuv);
					label56.Text = Convert.ToString(kola);
					seredniychas2 = kola / Convert.ToDouble(label24.Text);

				}
				else
				{
					if (label15.Text == "2/6")
					{
						double masuv, kola, seredniychas, prognoz;
						kola = Convert.ToDouble(label29.Text);
						masuv = Convert.ToDouble(label56.Text);
						seredniychas5 = Convert.ToDouble(label57.Text);
						kola = (kola + masuv);
						label56.Text = Convert.ToString(kola);
						seredniychas5 = kola / Convert.ToDouble(label24.Text);

					}
					else
					{
						if (label15.Text == "3/6")
						{
							double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label29.Text);
							masuv = Convert.ToDouble(label56.Text);
							seredniychas3 = Convert.ToDouble(label57.Text);
							kola = (kola + masuv);
							label56.Text = Convert.ToString(kola);
							seredniychas3 = kola / Convert.ToDouble(label24.Text);

						}
						else
						{
							if (label15.Text == "4/6")
							{
								double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label29.Text);
								masuv = Convert.ToDouble(label56.Text);
								seredniychas1 = Convert.ToDouble(label57.Text);
								kola = (kola + masuv);
								label56.Text = Convert.ToString(kola);
								seredniychas1 = kola / Convert.ToDouble(label24.Text);

							}
							else
							{
								if (label15.Text == "5/6")
								{
									double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label29.Text);
									masuv = Convert.ToDouble(label56.Text);
									seredniychas6 = Convert.ToDouble(label57.Text);
									kola = (kola + masuv);
									label56.Text = Convert.ToString(kola);
									seredniychas6 = kola / Convert.ToDouble(label24.Text);

								}
								else
								{
									if (label15.Text == "6/6")
									{
										double masuv, kola, seredniychas, prognoz;
										kola = Convert.ToDouble(label29.Text);
										masuv = Convert.ToDouble(label56.Text);
										seredniychas4 = Convert.ToDouble(label57.Text);
										kola = (kola + masuv);
										label56.Text = Convert.ToString(kola);
										seredniychas4 = kola / Convert.ToDouble(label24.Text);

									}
								}
							}
						}
					}
				}


				// підсвітка під час кола
				textBox6.BackColor = Color.LawnGreen;
				label24.BackColor = Color.LawnGreen;
				timer36.Enabled = true;









				// для сортування позиції гонщика
				if (Convert.ToDouble(label30.Text) < 1)         //обмеження по часу кола 1 секунда
				{
					c--;
					label24.Text = Convert.ToString(c);
				}

				timer13.Enabled = false;
			}
		}

		private void timer14_Tick(object sender, EventArgs e)
		{
			if (Convert.ToDouble(label38.Text) > delay)
			{
				d++;                                            //добавляю кола 4 доріці
				label25.Text = Convert.ToString(d);

				// алгоритм прогнозу

				if (label15.Text == "1/6")
				{
					double masuv, kola, seredniychas, prognoz;
					kola = Convert.ToDouble(label38.Text);
					masuv = Convert.ToDouble(label119.Text);
					seredniychas4 = Convert.ToDouble(label118.Text);
					kola = (kola + masuv);
					label119.Text = Convert.ToString(kola);
					seredniychas4 = kola / Convert.ToDouble(label25.Text);
				}
				else
				{
					if (label15.Text == "2/6")
					{
						double masuv, kola, seredniychas, prognoz;
						kola = Convert.ToDouble(label38.Text);
						masuv = Convert.ToDouble(label119.Text);
						seredniychas2 = Convert.ToDouble(label118.Text);
						kola = (kola + masuv);
						label119.Text = Convert.ToString(kola);
						seredniychas2 = kola / Convert.ToDouble(label25.Text);
					}
					else
					{
						if (label15.Text == "3/6")
						{
							double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label38.Text);
							masuv = Convert.ToDouble(label119.Text);
							seredniychas5 = Convert.ToDouble(label118.Text);
							kola = (kola + masuv);
							label119.Text = Convert.ToString(kola);
							seredniychas5 = kola / Convert.ToDouble(label25.Text);
						}
						else
						{
							if (label15.Text == "4/6")
							{
								double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label38.Text);
								masuv = Convert.ToDouble(label119.Text);
								seredniychas3 = Convert.ToDouble(label118.Text);
								kola = (kola + masuv);
								label119.Text = Convert.ToString(kola);
								seredniychas3 = kola / Convert.ToDouble(label25.Text);
							}
							else
							{
								if (label15.Text == "5/6")
								{
									double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label38.Text);
									masuv = Convert.ToDouble(label119.Text);
									seredniychas1 = Convert.ToDouble(label118.Text);
									kola = (kola + masuv);
									label119.Text = Convert.ToString(kola);
									seredniychas1 = kola / Convert.ToDouble(label25.Text);
								}
								else
								{
									if (label15.Text == "6/6")
									{
										double masuv, kola, seredniychas, prognoz;
										kola = Convert.ToDouble(label38.Text);
										masuv = Convert.ToDouble(label119.Text);
										seredniychas6 = Convert.ToDouble(label118.Text);
										kola = (kola + masuv);
										label119.Text = Convert.ToString(kola);
										seredniychas6 = kola / Convert.ToDouble(label25.Text);
									}
								}
							}
						}
					}
				}





				// підсвітка під час кола
				textBox12.BackColor = Color.LawnGreen;
				label25.BackColor = Color.LawnGreen;
				timer38.Enabled = true;







				if (Convert.ToDouble(label39.Text) < 1)         //обмеження по часу кола 1 секунда
				{
					d--;
					label25.Text = Convert.ToString(d);
				}

				timer14.Enabled = false;
			}
		}
		private void timer21_Tick(object sender, EventArgs e)
		{



			int n;







			if (label116.Text == "" && label15.Text == "номер заизду")
			{
				n = listBox1.Items.Count - 1;
				//label48.Text = Convert.ToString(listBox1.Items[n]);

				for (int i = 0; i < n; n--)
				{

					label116.Text = Convert.ToString(listBox1.Items[n]);
					if (label116.Text != "")
					{
						break;
					}

				}
				n--;
				label115.Text = Convert.ToString(listBox1.Items[n]);
				n--;
				label48.Text = Convert.ToString(listBox1.Items[n]);
				n--;
				label47.Text = Convert.ToString(listBox1.Items[n]);
				n--;
				label46.Text = Convert.ToString(listBox1.Items[n]);
				n--;
				label45.Text = Convert.ToString(listBox1.Items[n]);
				label67.Text = Convert.ToString(n);
				//Convert.ToString(listBox1.Items.Count);

				timer21.Enabled = false;

			}

			if (Convert.ToInt32(label67.Text) != 0)
			{

				if (label67.Text != "1")
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

						panel1.Location = new Point(4, 219);
						panel3.Location = new Point(4, 321);
						panel4.Location = new Point(4, 423);
						panel5.Location = new Point(4, 525);
						panel10.Location = new Point(4, 628);
						panel11.Location = new Point(4, 731);

						label17.Text = "0";
						label24.Text = "0";
						label23.Text = "0";
						label25.Text = "0";
						label97.Text = "0";
						label112.Text = "0";
						label122.Text = "0";
						label120.Text = "0";
						label118.Text = "0";
						label58.Text = "0";
						label57.Text = "0";
						label54.Text = "0";
						label8.Text = "0";
						label56.Text = "0";
						label117.Text = "0";
						label119.Text = "0";
						label121.Text = "0";
						label123.Text = "0";


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

						label94.Text = "00,000";
						label96.Text = "00,000";
						label93.Text = "00,000";
						label99.Text = "00,000";
						label92.Text = "999";

						label100.Text = "00,000";
						label101.Text = "00,000";
						label103.Text = "00,000";
						label114.Text = "00,000";
						label107.Text = "999";

						label55.Visible = false;
						label59.Visible = false;
						label60.Visible = false;
						label61.Visible = false;
						label62.Visible = false;
						n--;
						label116.Text = Convert.ToString(listBox1.Items[n]);
						n--;
						label115.Text = Convert.ToString(listBox1.Items[n]);
						n--;
						label48.Text = Convert.ToString(listBox1.Items[n]);
						n--;
						label47.Text = Convert.ToString(listBox1.Items[n]);
						n--;
						label46.Text = Convert.ToString(listBox1.Items[n]);
						n--;
						label45.Text = Convert.ToString(listBox1.Items[n]);


						label67.Text = Convert.ToString(n);
						timetostart = 5;
						label13.Visible = false;
						timer21.Enabled = false;

					}

				}
            }
           

		}


		private void timer15_Tick(object sender, EventArgs e)
		{


			Times += 0.0003 * 53;                   //timer на час кола зелена доріжка
			label26.Text = string.Format("{0:F3}", Times);       //timer на час кола зелена доріжка

		}

		private void button9_Click(object sender, EventArgs e)
		{
			label68.Visible = false;

			textBox20.Visible = false;
			textBox21.Visible = false;
			textBox22.Visible = false;
			textBox23.Visible = false;
			textBox36.Visible = false;
			textBox37.Visible = false;

			button9.Visible = false;


			if (textBox25.Text == "")
			{
				position = 1;
				position1 = 0;

				button8.Visible = true;

			

				dataGridView1.Rows.Add("",label45.Text,lane3_1, lane3_2, lane3_3, lane3_4, lane3_5, lane3_6, label17.Text + "," + textBox20.Text);

				dataGridView1.Rows.Add("",label46.Text, lane4_1, lane4_2, lane4_3, lane4_4, lane4_5, lane4_6, label24.Text + "," + textBox22.Text);

				dataGridView1.Rows.Add("", label47.Text,lane5_1, lane5_2, lane5_3, lane5_4, lane5_5, lane5_6, label23.Text + "," + textBox21.Text);

				dataGridView1.Rows.Add("",label48.Text,lane6_1, lane6_2, lane6_3, lane6_4, lane6_5, lane6_6, label25.Text + "," + textBox23.Text);

				dataGridView1.Rows.Add("",label115.Text,lane2_1, lane2_2, lane2_3, lane2_4, lane2_5, lane2_6, label97.Text + "," + textBox36.Text);

				dataGridView1.Rows.Add("",label116.Text,lane1, lane2, lane3, lane4, lane5, lane6, label112.Text + "," + textBox37.Text);

				//сортування результату гонки в таблиці


				dataGridView1.Sort(dataGridView1.Columns[8], ListSortDirection.Descending);
				


				// добавляю порядок спортсмені ( порядок місць)
				for (int cell = 0; dataGridView1.Rows.Count > cell; cell++)
				{

					dataGridView1.Rows[position1].Cells[0].Value = position;



					if (dataGridView1.Rows.Count > position)

					{
						position1 = position1 + 1;
						position = position + 1;
					}

				}
				textBox20.Text = "";
				textBox21.Text = "";
				textBox22.Text = "";
				textBox23.Text = "";
				textBox36.Text = "";
				textBox37.Text = "";

			}
			else
			{
			
				button16.Visible = true;
				position = 1;
				position1 = 0;
				dataGridView2.Rows.Add("", label45.Text, lane3_1, lane3_2, lane3_3, lane3_4, lane3_5, lane3_6, label17.Text + "," + textBox20.Text);

				dataGridView2.Rows.Add("", label46.Text, lane4_1, lane4_2, lane4_3, lane4_4, lane4_5, lane4_6, label24.Text + "," + textBox22.Text);

				dataGridView2.Rows.Add("", label47.Text, lane5_1, lane5_2, lane5_3, lane5_4, lane5_5, lane5_6, label23.Text + "," + textBox21.Text);

				dataGridView2.Rows.Add("", label48.Text, lane6_1, lane6_2, lane6_3, lane6_4, lane6_5, lane6_6, label25.Text + "," + textBox23.Text);

				dataGridView2.Rows.Add("", label115.Text, lane2_1, lane2_2, lane2_3, lane2_4, lane2_5, lane2_6, label97.Text + "," + textBox36.Text);

				dataGridView2.Rows.Add("", label116.Text, lane1, lane2, lane3, lane4, lane5, lane6, label112.Text + "," + textBox37.Text);
				//сортування результату гонки в таблиці


				dataGridView2.Sort(dataGridView2.Columns[8], ListSortDirection.Descending);
				// добавляю порядок спортсмені ( порядок місць)
				for (int cell = 0; dataGridView1.Rows.Count > cell; cell++)
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
				textBox36.Text = "";
				textBox37.Text = "";
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
			textBox13.Text = textBox24.Text;
			prognoz1 = 0;
			prognoz2 = 0;
			prognoz3 = 0;
			prognoz4 = 0;
			prognoz5 = 0;
			prognoz6 = 0;
			seredniychas1 = 0;
			seredniychas2 = 0;
			seredniychas3 = 0;
			seredniychas4 = 0;
			seredniychas5 = 0;
			seredniychas6 = 0;

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
			panel1.Location = new Point(4, 219);
			panel3.Location = new Point(4, 321);
			panel4.Location = new Point(4, 423);
			panel5.Location = new Point(4, 525);
			panel10.Location = new Point(4, 628);
			panel11.Location = new Point(4, 731);

			label17.Text = "0";
			label24.Text = "0";
			label23.Text = "0";
			label25.Text = "0";
			label97.Text = "0";
			label112.Text = "0";

			label122.Text = "0";
			label120.Text = "0";
			label118.Text = "0";
			label58.Text = "0";
			label57.Text = "0";
			label54.Text = "0";


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

			label94.Text = "00,000";
			label96.Text = "00,000";
			label93.Text = "00,000";
			label99.Text = "00,000";
			label92.Text = "999";

			label100.Text = "00,000";
			label101.Text = "00,000";
			label103.Text = "00,000";
			label114.Text = "00,000";
			label107.Text = "999";

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
			label116.Text = dataGridView1[1, 5].Value.ToString();
			label115.Text = dataGridView1[1, 4].Value.ToString();
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

			timer26.Interval = 15;
			Timeo = 0.0;

			timer27.Interval = 15;
			Timeb = 0.0;


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
					timer43.Enabled = true;
					label71.Visible = true;
					timer2.Enabled = true;
					label4.Text = "00:00";
					sec = 1;
					min = Convert.ToInt32(textBox24.Text);
					label13.Text = "<<Гонка!>>";
					label15.Visible = true;
					label15.Text = "1/6";
					label13.Visible = true;
					timer20.Enabled = true;
					timer11.Enabled = true;
					timer16.Enabled = true;
					timer17.Enabled = true;
					timer27.Enabled = true;
					timer28.Enabled = true;
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

			DialogResult dialog = MessageBox.Show(
				 "Вы действительно хотите выйти из программы?",
				 "Завершение программы",
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

			Settings.Default.line1_6 = panel1.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void зеленаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line1_6 = panel1.BackColor = Color.LimeGreen;
			Settings.Default.Save();

		}

		private void білаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel1.BackColor = Color.White;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel1.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void фіолетоваToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel1.BackColor = Color.Purple;
			Settings.Default.Save();
		}

		private void жовтаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line1_6 = panel1.BackColor = Color.Gold;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line1_6 = panel1.BackColor = Color.DodgerBlue;
			Settings.Default.Save();

		}

		private void чорнаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Default.line1_6 = panel1.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void червонаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel3.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void білаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel3.BackColor = Color.White;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel3.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void доріжкаToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void фіолетоваToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel3.BackColor = Color.Purple;
			Settings.Default.Save();
		}

		private void жовтаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel3.BackColor = Color.Gold;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel3.BackColor = Color.DodgerBlue;
			Settings.Default.Save();
		}

		private void чорнаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel3.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void зеленаToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Settings.Default.line2_6 = panel3.BackColor = Color.LimeGreen;
			Settings.Default.Save();
		}

		private void червонаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel4.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void білаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel4.BackColor = Color.White;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel4.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void фіолетоваToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel4.BackColor = Color.Purple;
			Settings.Default.Save();
		}

		private void жовтаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel4.BackColor = Color.Gold;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel4.BackColor = Color.DodgerBlue;
			Settings.Default.Save();
		}

		private void чорнаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel4.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void доріжкаToolStripMenuItem2_Click(object sender, EventArgs e)
		{

		}

		private void зеленаToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Settings.Default.line3_6 = panel4.BackColor = Color.LimeGreen;
			Settings.Default.Save();
		}

		private void червонаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel5.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void білаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel5.BackColor = Color.White;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel5.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void фіолетоваToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel5.BackColor = Color.Purple;
			Settings.Default.Save();

		}

		private void жовтаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel5.BackColor = Color.Gold;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel5.BackColor = Color.DodgerBlue;
			Settings.Default.Save();
		}

		private void чорнаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel5.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void зеленаToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Settings.Default.line4_6 = panel5.BackColor = Color.LimeGreen;
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
			}
		}

		private void timer26_Tick(object sender, EventArgs e)
		{
			if (label13.Text == "Тренування!") // алгоритм часу для тренування
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
			label88.Visible = false;
			label89.Visible = false;
			textBox26.Visible = false;
			textBox27.Visible = false;
			button20.Visible = false;
			label137.Visible = false;
			textBox39.Visible = false;
			label15.Visible = true;
			time_to_traning_min = Convert.ToInt32(textBox26.Text);
			time_to_traning_sec = Convert.ToInt32(textBox27.Text);
			button5.Enabled = true;
			label15.Text = traning_number_group + "/" + textBox39.Text;

		}

		private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{

        }


        private void button19_Click_2(object sender, EventArgs e)
		{
			button19.Visible = false;
			button1.Enabled = true;
		}

		private void timer28_Tick(object sender, EventArgs e)
		{
			if (Convert.ToDouble(label99.Text) > delay)
			{
				v++;                                            //добавляю кола 1 доріці
				label97.Text = Convert.ToString(v);

				// алгоритм прогнозу

				if (label15.Text == "1/6")
				{


					double masuv, kola, seredniychas, prognoz;
					kola = Convert.ToDouble(label99.Text);
					masuv = Convert.ToDouble(label121.Text);
					seredniychas5 = Convert.ToDouble(label120.Text);
					kola = (kola + masuv);
					label121.Text = Convert.ToString(kola);
					seredniychas5 = kola / Convert.ToDouble(label97.Text);
				}
				else
				{
					if (label15.Text == "2/6")
					{


						double masuv, kola, seredniychas, prognoz;
						kola = Convert.ToDouble(label99.Text);
						masuv = Convert.ToDouble(label121.Text);
						seredniychas3 = Convert.ToDouble(label120.Text);
						kola = (kola + masuv);
						label121.Text = Convert.ToString(kola);
						seredniychas3 = kola / Convert.ToDouble(label97.Text);
					}
					else
					{
						if (label15.Text == "3/6")
						{


							double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label99.Text);
							masuv = Convert.ToDouble(label121.Text);
							seredniychas1 = Convert.ToDouble(label120.Text);
							kola = (kola + masuv);
							label121.Text = Convert.ToString(kola);
							seredniychas1 = kola / Convert.ToDouble(label97.Text);
						}
						else
						{
							if (label15.Text == "4/6")
							{


								double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label99.Text);
								masuv = Convert.ToDouble(label121.Text);
								seredniychas6 = Convert.ToDouble(label120.Text);
								kola = (kola + masuv);
								label121.Text = Convert.ToString(kola);
								seredniychas6 = kola / Convert.ToDouble(label97.Text);
							}
							else
							{
								if (label15.Text == "5/6")
								{


									double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label99.Text);
									masuv = Convert.ToDouble(label121.Text);
									seredniychas4 = Convert.ToDouble(label120.Text);
									kola = (kola + masuv);
									label121.Text = Convert.ToString(kola);
									seredniychas4 = kola / Convert.ToDouble(label97.Text);
								}
								else
								{
									if (label15.Text == "6/6")
									{


										double masuv, kola, seredniychas, prognoz;
										kola = Convert.ToDouble(label99.Text);
										masuv = Convert.ToDouble(label121.Text);
										seredniychas2 = Convert.ToDouble(label120.Text);
										kola = (kola + masuv);
										label121.Text = Convert.ToString(kola);
										seredniychas2 = kola / Convert.ToDouble(label97.Text);
									}
								}
							}
						}
					}
				}






				// підсвітка під час кола
				textBox31.BackColor = Color.LawnGreen;
				label97.BackColor = Color.LawnGreen;
				timer39.Enabled = true;




				if (Convert.ToDouble(label74.Text) < 1)         //обмеження по часу кола 1 секунда
				{
					v--;
					label97.Text = Convert.ToString(v);
				}
				//textBox15.Text = "0";
				timer28.Enabled = false;
			}
		}

		private void timer29_Tick(object sender, EventArgs e)
		{
			if (Convert.ToDouble(label114.Text) > delay)
			{
				l++;                                            //добавляю кола 1 доріці
				label112.Text = Convert.ToString(l);



				// алгоритм прогнозу
				if (label15.Text == "1/6")
				{


					double masuv, kola, seredniychas, prognoz;
					kola = Convert.ToDouble(label114.Text);
					masuv = Convert.ToDouble(label123.Text);
					seredniychas6 = Convert.ToDouble(label122.Text);
					kola = (kola + masuv);
					label123.Text = Convert.ToString(kola);
					seredniychas6 = kola / Convert.ToDouble(label112.Text);

				}
				else
				{
					if (label15.Text == "2/6")
					{


						double masuv, kola, seredniychas, prognoz;
						kola = Convert.ToDouble(label114.Text);
						masuv = Convert.ToDouble(label123.Text);
						seredniychas4 = Convert.ToDouble(label122.Text);
						kola = (kola + masuv);
						label123.Text = Convert.ToString(kola);
						seredniychas4 = kola / Convert.ToDouble(label112.Text);

					}
					else
					{
						if (label15.Text == "3/6")
						{


							double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label114.Text);
							masuv = Convert.ToDouble(label123.Text);
							seredniychas2 = Convert.ToDouble(label122.Text);
							kola = (kola + masuv);
							label123.Text = Convert.ToString(kola);
							seredniychas2 = kola / Convert.ToDouble(label112.Text);

						}
						else
						{
							if (label15.Text == "4/6")
							{


								double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label114.Text);
								masuv = Convert.ToDouble(label123.Text);
								seredniychas5 = Convert.ToDouble(label122.Text);
								kola = (kola + masuv);
								label123.Text = Convert.ToString(kola);
								seredniychas5 = kola / Convert.ToDouble(label112.Text);

							}
							else
							{
								if (label15.Text == "5/6")
								{


									double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label114.Text);
									masuv = Convert.ToDouble(label123.Text);
									seredniychas3 = Convert.ToDouble(label122.Text);
									kola = (kola + masuv);
									label123.Text = Convert.ToString(kola);
									seredniychas3 = kola / Convert.ToDouble(label112.Text);

								}
								else
								{
									if (label15.Text == "6/6")
									{


										double masuv, kola, seredniychas, prognoz;
										kola = Convert.ToDouble(label114.Text);
										masuv = Convert.ToDouble(label123.Text);
										seredniychas1 = Convert.ToDouble(label122.Text);
										kola = (kola + masuv);
										label123.Text = Convert.ToString(kola);
										seredniychas1 = kola / Convert.ToDouble(label112.Text);

									}
								}
							}
						}
					}
				}





				// підсвітка під час кола
				textBox35.BackColor = Color.LawnGreen;
				label112.BackColor = Color.LawnGreen;
				timer40.Enabled = true;






				if (Convert.ToDouble(label103.Text) < 1)         //обмеження по часу кола 1 секунда
				{
					l--;
					label112.Text = Convert.ToString(l);
				}
				//textBox15.Text = "0";
				timer29.Enabled = false;
			}
		}

		private void label94_Click(object sender, EventArgs e)
		{

		}

		private void timer30_Tick(object sender, EventArgs e)
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
					timer30.Enabled = false;
					label4.Text = "00:00";
					secs = Convert.ToInt32(textBox14.Text);
					mins = 0;
					timer33.Enabled = true;
					label13.Text = "<<Перехід!>>";
					button6.Enabled = false;

					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					timer26.Enabled = false;
					timer27.Enabled = false;


					timer43.Enabled = false;





					//


					lane4 = Convert.ToInt32(label25.Text) - lane1 - lane3 - lane5 - lane2;
					lane2_3 = Convert.ToInt32(label23.Text) - lane2_2 - lane2_4 - lane2_6 - lane2_1;
					lane3_6 = Convert.ToInt32(label112.Text) - lane3_3 - lane3_5 - lane3_2 - lane3_4;
					lane4_5 = Convert.ToInt32(label97.Text) - lane4_4 - lane4_6 - lane4_1 - lane4_3;
					lane5_1 = Convert.ToInt32(label17.Text) - lane5_5 - lane5_2 - lane5_4 - lane5_6;
					lane6_2 = Convert.ToInt32(label24.Text) - lane6_6 - lane6_1 - lane6_3 - lane6_5;







					textBox16.Text = label45.Text;  //червона
					label50.Text = label17.Text;
					label66.Text = label21.Text;
					label125.Text = label8.Text;
					label131.Text = label54.Text;



					textBox17.Text = label46.Text; //біла
					label51.Text = label24.Text;
					label63.Text = label27.Text;
					label126.Text = label56.Text;
					label132.Text = label57.Text;

					textBox18.Text = label47.Text;  //зелена
					label52.Text = label23.Text;
					label64.Text = label26.Text;
					label127.Text = label117.Text;
					label133.Text = label58.Text;

					textBox19.Text = label48.Text;  //оранжева
					label53.Text = label25.Text;
					label65.Text = label28.Text;
					label128.Text = label119.Text;
					label134.Text = label118.Text;

					textBox28.Text = label115.Text;  //синя
					label90.Text = label97.Text;
					label73.Text = label95.Text;
					label129.Text = label121.Text;
					label135.Text = label120.Text;

					textBox32.Text = label116.Text;  //жовта
					label105.Text = label112.Text;
					label102.Text = label110.Text;
					label130.Text = label123.Text;
					label136.Text = label122.Text;




					label45.Text = textBox32.Text;
					label17.Text = label105.Text;
					label21.Text = label102.Text;
					label8.Text = label130.Text;
					label54.Text = label136.Text;

					label46.Text = textBox28.Text;
					label24.Text = label90.Text;
					label27.Text = label73.Text;
					label56.Text = label129.Text;
					label57.Text = label135.Text;

					label47.Text = textBox16.Text;
					label23.Text = label50.Text;
					label26.Text = label66.Text;
					label117.Text = label125.Text;
					label58.Text = label131.Text;

					label48.Text = textBox17.Text;
					label25.Text = label51.Text;
					label28.Text = label63.Text;
					label119.Text = label126.Text;
					label118.Text = label132.Text;

					label115.Text = textBox18.Text;
					label97.Text = label52.Text;
					label95.Text = label64.Text;
					label121.Text = label127.Text;
					label120.Text = label133.Text;

					label116.Text = textBox19.Text;
					label112.Text = label53.Text;
					label110.Text = label65.Text;
					label123.Text = label128.Text;
					label122.Text = label134.Text;

					//label8.Text = "0";
					//	label56.Text = "0";
					//	label117.Text = "0";
					//	label119.Text = "0";
					////	label121.Text = "0";
					//label123.Text = "0";

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

					label94.Text = "00,000";
					label96.Text = "00,000";
					label93.Text = "00,000";
					label99.Text = "00,000";
					label92.Text = "999";

					label100.Text = "00,000";
					label101.Text = "00,000";
					label103.Text = "00,000";
					label114.Text = "00,000";
					label107.Text = "999";

					number_group.Text = "5";





					// сортування по результату
					dataGridView3.Rows.Add(label17.Text + "," + 6);
					dataGridView3.Rows.Add(label24.Text + "," + 5);
					dataGridView3.Rows.Add(label23.Text + "," + 4);
					dataGridView3.Rows.Add(label25.Text + "," + 3);
					dataGridView3.Rows.Add(label97.Text + "," + 2);
					dataGridView3.Rows.Add(label112.Text + "," + 1);

					dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);









					//червона

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
					{
						panel1.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
									{

										panel1.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
										{

											panel1.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}



					// біла

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
					{
						panel3.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label24.Text + "," + 5))//&& Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
									{

										panel3.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
										{

											panel3.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					// зелена

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
					{
						panel4.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
									{

										panel4.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
										{

											panel4.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//оранжева 



					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
					{
						panel5.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
									{

										panel5.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label25.Text + "," + 3))//&& Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
										{

											panel5.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//синя

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label97.Text + "," + 2))//&& Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
					{
						panel10.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
						{

							panel10.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
							{

								panel10.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
								{

									panel10.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
									{

										panel10.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
										{

											panel10.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}


					//жовта

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
					{
						panel11.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
						{

							panel11.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
							{

								panel11.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
								{

									panel11.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
									{

										panel11.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
										{

											panel11.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}
					timer34.Enabled = true;
				}
			}
		}

		private void timer31_Tick(object sender, EventArgs e)
		{
			sec--;
			label4.Text = Convert.ToString(min) + ":" + Convert.ToString(sec); //зчитую час гонки який був заданий у настройках





			if (sec == 0)                                               //таймер для гонки 1 перший заїзд
			{
				min--;
				sec = 60;

				if (min == -1 && sec == 60)
				{
					timer43.Enabled = false;
					button6.Enabled = false;
					serialPort1.WriteLine("3"); //пауза
					label69.Text = "Трек виключений";
					label69.BackColor = Color.Red;
					button10.Enabled = true;
					button11.Enabled = false;

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
					textBox36.BackColor = panel10.BackColor;
					textBox36.Visible = true;
					textBox37.BackColor = panel11.BackColor;
					textBox37.Visible = true;

					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					timer26.Enabled = false;
					timer27.Enabled = false;

					button9.Visible = true;
					button6.Enabled = false;



					//


					lane6 = Convert.ToInt32(label112.Text) - lane1 - lane3 - lane5 - lane2 - lane4;
					lane2_5 = Convert.ToInt32(label97.Text) - lane2_2 - lane2_4 - lane2_6 - lane2_1 - lane2_3;
					lane3_1 = Convert.ToInt32(label17.Text) - lane3_3 - lane3_5 - lane3_2 - lane3_4 - lane3_6;
					lane4_2 = Convert.ToInt32(label24.Text) - lane4_4 - lane4_6 - lane4_1 - lane4_3 - lane4_5;
					lane5_3 = Convert.ToInt32(label23.Text) - lane5_5 - lane5_2 - lane5_4 - lane5_6 - lane5_1;
					lane6_4 = Convert.ToInt32(label25.Text) - lane6_6 - lane6_1 - lane6_3 - lane6_5 - lane6_2;








					timer31.Enabled = false;
					label4.Text = "00:00";
					label13.Text = "<<Фініш!>>";



					number_group.Text = "0";

					serialPort1.Close();
					//вивід результату в таблицю




				}


			}


		}

		private void timer32_Tick(object sender, EventArgs e)
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

				Time = Convert.ToDouble(label102.Text);
				Timeg = Convert.ToDouble(label63.Text);
				Timez = Convert.ToDouble(label73.Text);
				Times = Convert.ToDouble(label66.Text);
				Timeo = Convert.ToDouble(label64.Text);
				Timeb = Convert.ToDouble(label65.Text);

				timer43.Enabled = true;
				timer32.Enabled = false;
				timer30.Enabled = true;
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
				label15.Text = "5/6";

				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;

				button6.Enabled = true;
				button6.Focus();
			}
		}

		private void timer33_Tick(object sender, EventArgs e)
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

				Time = Convert.ToDouble(label102.Text);
				Timeg = Convert.ToDouble(label63.Text);
				Timez = Convert.ToDouble(label73.Text);
				Times = Convert.ToDouble(label66.Text);
				Timeo = Convert.ToDouble(label64.Text);
				Timeb = Convert.ToDouble(label65.Text);

				timer43.Enabled = true;
				timer33.Enabled = false;
				timer31.Enabled = true;
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
				label15.Text = "6/6";

				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;

				button6.Enabled = true;
				button6.Focus();
			}
		}

		private void label115_Click(object sender, EventArgs e)
		{

		}

		private void label53_Click(object sender, EventArgs e)
		{

		}

		private void timer34_Tick(object sender, EventArgs e)

		{





			dataGridView3.Rows.Clear();
			timer34.Enabled = false;



			//listBox2.Items.Clear();

















			//label128.Text = label8.Text;
			//label122.Text = label117.Text;
			//label124.Text = label58.Text;
			//label125.Text = label57.Text;
			//label126.Text = label56.Text;



			//if (Convert.ToInt32(label17.Text) == Convert.ToInt32(label124.Text))
			//{
			//	panel1.Location = new Point(4, 423);
			//	//	label58.Text = "0";
			//}
			//else
			//{
			//	if (Convert.ToInt32(label24.Text) == Convert.ToInt32(label124.Text))
			//	{
			//		panel3.Location = new Point(4, 423);
			//		//label58.Text = "0";
			//	}
			//	else
			//	{
			//		if (Convert.ToInt32(label23.Text) == Convert.ToInt32(label124.Text))
			//		{
			//			panel4.Location = new Point(4, 423);
			//			//	label58.Text = "0";
			//		}
			//		else
			//		{
			//			if (Convert.ToInt32(label25.Text) == Convert.ToInt32(label124.Text))
			//			{
			//				panel5.Location = new Point(4, 423);
			//				//	label58.Text = "0";
			//			}
			//			else
			//			{
			//				if (Convert.ToInt32(label97.Text) == Convert.ToInt32(label124.Text))
			//				{
			//					panel10.Location = new Point(4, 423);
			//					//	label58.Text = "0";
			//				}
			//				else
			//				{
			//					if (Convert.ToInt32(label112.Text) == Convert.ToInt32(label124.Text))
			//					{
			//						panel11.Location = new Point(4, 423);
			//						//	label58.Text = "0";
			//					}
			//				}
			//			}
			//		}
			//	}
			//}





			//if (Convert.ToInt32(label17.Text) == Convert.ToInt32(label122.Text))
			//{
			//	panel1.Location = new Point(4, 321);
			//	//label117.Text = "0";
			//}
			//else
			//{
			//	if (Convert.ToInt32(label24.Text) == Convert.ToInt32(label122.Text))
			//	{
			//		panel3.Location = new Point(4, 321);
			//		//label117.Text = "0";
			//	}
			//	else
			//	{
			//		if (Convert.ToInt32(label23.Text) == Convert.ToInt32(label122.Text))
			//		{
			//			panel4.Location = new Point(4, 321);
			//			//label117.Text = "0";
			//		}
			//		else
			//		{
			//			if (Convert.ToInt32(label25.Text) == Convert.ToInt32(label122.Text))
			//			{
			//				panel5.Location = new Point(4, 321);
			//				//label117.Text = "0";
			//			}
			//			else
			//			{
			//				if (Convert.ToInt32(label97.Text) == Convert.ToInt32(label122.Text))
			//				{
			//					panel10.Location = new Point(4, 321);
			//					//	label117.Text = "0";
			//				}
			//				else
			//				{
			//					if (Convert.ToInt32(label112.Text) == Convert.ToInt32(label122.Text))
			//					{
			//						panel11.Location = new Point(4, 321);
			//						//	label117.Text = "0";
			//					}
			//				}
			//			}
			//		}
			//	}
			//}




			//if (Convert.ToInt32(label17.Text) == Convert.ToInt32(label128.Text))
			//{
			//	panel1.Location = new Point(4, 219);
			//	//label8.Text = "0";
			//}
			//else
			//{
			//	if (Convert.ToInt32(label24.Text) == Convert.ToInt32(label128.Text))
			//	{
			//		panel3.Location = new Point(4, 219);
			//		//label8.Text = "0";
			//	}
			//	else
			//	{
			//		if (Convert.ToInt32(label23.Text) == Convert.ToInt32(label128.Text))
			//		{
			//			panel4.Location = new Point(4, 219);
			//			//label8.Text = "0";
			//		}
			//		else
			//		{
			//			if (Convert.ToInt32(label25.Text) == Convert.ToInt32(label128.Text))
			//			{
			//				panel5.Location = new Point(4, 219);
			//				//label8.Text = "0";
			//			}
			//			else
			//			{
			//				if (Convert.ToInt32(label97.Text) == Convert.ToInt32(label128.Text))
			//				{
			//					panel10.Location = new Point(4, 219);
			//					//label8.Text = "0";
			//				}
			//				else
			//				{
			//					if (Convert.ToInt32(label112.Text) == Convert.ToInt32(label128.Text))
			//					{
			//						panel11.Location = new Point(4, 219);
			//						//label8.Text = "0";
			//					}
			//				}
			//			}
			//		}
			//	}
			//}
		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

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

		private void dataGridView1_SortCompare_1(object sender, DataGridViewSortCompareEventArgs e)
		{

		}

		private void dataGridView1_SortCompare_2(object sender, DataGridViewSortCompareEventArgs e)
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

		private void timer35_Tick(object sender, EventArgs e)
		{
			textBox1.BackColor = Color.WhiteSmoke;
			label17.BackColor = Color.WhiteSmoke;
			timer35.Enabled = false;
		}

        private void button21_Click(object sender, EventArgs e)
        {
			min = 0;
			sec = 2;
        }

        private void timer36_Tick(object sender, EventArgs e)
		{
			textBox6.BackColor = Color.WhiteSmoke;
			label24.BackColor = Color.WhiteSmoke;
			timer36.Enabled = false;
		}

		private void timer37_Tick(object sender, EventArgs e)
		{
			textBox9.BackColor = Color.WhiteSmoke;
			label23.BackColor = Color.WhiteSmoke;
			timer37.Enabled = false;
		}

		private void timer38_Tick(object sender, EventArgs e)
		{
			textBox12.BackColor = Color.WhiteSmoke;
			label25.BackColor = Color.WhiteSmoke;
			timer38.Enabled = false;
		}

		private void timer39_Tick(object sender, EventArgs e)
		{
			textBox31.BackColor = Color.WhiteSmoke;
			label97.BackColor = Color.WhiteSmoke;
			timer39.Enabled = false;
		}

		private void timer40_Tick(object sender, EventArgs e)
		{
			textBox35.BackColor = Color.WhiteSmoke;
			label112.BackColor = Color.WhiteSmoke;
			timer40.Enabled = false;
		}

		private void button7_KeyDown_1(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{

				//if (serialPort1.IsOpen == false)
				//{
				//	serialPort1.Open();
				//	}
				start_to_pause.Play();
				timer44.Enabled = true;


			}
		}

		private void button6_KeyDown_1(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				serialPort1.WriteLine("3");


				//if (serialPort1.IsOpen == true)
				//{
				//	serialPort1.Close();
				//	}


				label69.Text = "Трек виключений";
				label69.BackColor = Color.Red;
				button10.Enabled = true;
				button11.Enabled = false;





				pausesound.Play();
				if (number_group.Text == "0")   // кнопка пауза для 1 заїзду
				{
					//serialPort1.Close();
					timer2.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					timer26.Enabled = false;
					timer27.Enabled = false;
					button7.Visible = true;
					button7.Focus();
				}

				if (number_group.Text == "1")   // кнопка пауза для 2 заїзду
				{
					//serialPort1.Close();
					timer4.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					timer26.Enabled = false;
					timer27.Enabled = false;
					button7.Visible = true;
					button7.Focus();
				}

				if (number_group.Text == "2")   // кнопка пауза для 3 заїзду
				{
					//serialPort1.Close();
					timer6.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					timer26.Enabled = false;
					timer27.Enabled = false;
					button7.Visible = true;
					button7.Focus();
				}

				if (number_group.Text == "3")   // кнопка пауза для 4 заїзду
				{
					//serialPort1.Close();
					timer8.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					button6.Visible = false;
					timer26.Enabled = false;
					timer27.Enabled = false;
					button7.Visible = true;
					button7.Focus();
				}

				if (number_group.Text == "4")   // кнопка пауза для 5 заїзду
				{
					//serialPort1.Close();
					timer30.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					timer26.Enabled = false;
					timer27.Enabled = false;
					button6.Visible = false;
					button7.Visible = true;
					button7.Focus();
				}
				if (number_group.Text == "5")   // кнопка пауза для 6 заїзду
				{
					//serialPort1.Close();
					timer31.Enabled = false;
					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					timer26.Enabled = false;
					timer27.Enabled = false;
					button6.Visible = false;
					button7.Visible = true;
					button7.Focus();
				}
			}
		}

		private void червонаToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Settings.Default.line5_6 = panel10.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void білаToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Settings.Default.line5_6 = panel10.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Settings.Default.line5_6 = panel10.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void фіолетоваToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Settings.Default.line5_6 = panel10.BackColor = Color.Purple;
			Settings.Default.Save();
		}

		private void жовтаToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Settings.Default.line5_6 = panel10.BackColor = Color.Yellow;
			Settings.Default.Save();
		}

		private void синяToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Settings.Default.line5_6 = panel10.BackColor = Color.DodgerBlue;
			Settings.Default.Save();
		}

		private void чорнаToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Settings.Default.line5_6 = panel10.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void зеленаToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Settings.Default.line5_6 = panel10.BackColor = Color.Green;
			Settings.Default.Save();
		}

		private void червонаToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Settings.Default.line6_6 = panel11.BackColor = Color.Red;
			Settings.Default.Save();
		}

		private void білаToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Settings.Default.line6_6 = panel11.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

		private void оранжеваToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Settings.Default.line6_6 = panel11.BackColor = Color.Orange;
			Settings.Default.Save();
		}

		private void фіолетоваToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Settings.Default.line6_6 = panel11.BackColor = Color.Purple;
			Settings.Default.Save();
		}

		private void жовтаToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Settings.Default.line6_6 = panel11.BackColor = Color.Yellow;
			Settings.Default.Save();
		}

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void секToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 1;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor= Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void секToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 2;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void секToolStripMenuItem2_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 3;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
			Settings.Default.Save();
		}

        private void секToolStripMenuItem3_Click(object sender, EventArgs e)
        {
			Settings.Default.delay1 = delay = 4;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor = Color.Lime;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
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
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor = Color.WhiteSmoke;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor = Color.WhiteSmoke;
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

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
			

		}

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
			// обмежую активність кнопки ок (button20) коли поля не заповненні
			if (textBox26.Text != "" && textBox27.Text != "" && textBox39.Text != "")
			{
				button20.Enabled = true;
			}
			else
			{
				button20.Enabled = false;
			}
			try
			{
				int f = Convert.ToInt32(textBox27.Text);
			}
			catch (System.FormatException)
			{
				MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
				textBox27.Clear();
			}
			
		}

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
			// обмежую активність кнопки ок (button20) коли поля не заповненні
			if (textBox26.Text != "" && textBox27.Text != "" && textBox39.Text != "")
			{
				button20.Enabled = true;
			}
			else
			{
				button20.Enabled = false;
			}
			try
			{
				int g = Convert.ToInt32(textBox39.Text);
			}
			catch (System.FormatException)
			{
				MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
				textBox39.Clear();
			}
			
		}

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
			
		}

        private void textBox26_TextChanged_1(object sender, EventArgs e)
        {
			// обмежую активність кнопки ок (button20) коли поля не заповненні
			if (textBox26.Text != "" && textBox27.Text != "" && textBox39.Text != "")
			{
				button20.Enabled = true;
			}
			else
			{
				button20.Enabled = false;
			}

			try
			{
				int s = Convert.ToInt32(textBox26.Text);
			}
			catch (System.FormatException)
			{
				MessageBox.Show("Ви ввели символ! Будь ласка,введіть цифрy");
				textBox26.Clear();
			}
			
		}

        private void toolStripTextBox1_VisibleChanged(object sender, EventArgs e)
        {
			
		}

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
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

        private void timer47_Tick(object sender, EventArgs e)
        {
			
        }

        private void button15_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void timer44_Tick(object sender, EventArgs e)
		{
			serialPort1.WriteLine("4");
			label69.Text = "Трек включений";
			label69.BackColor = Color.Green;
			button10.Enabled = false;

			button11.Enabled = true;
			//startsound.Play();
			if (number_group.Text == "0")   // кнопка продовжити для 1 заїзду
			{

				timer2.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;
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
				timer26.Enabled = true;
				timer27.Enabled = true;
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
				timer26.Enabled = true;
				timer27.Enabled = true;
				timer16.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}

			if (number_group.Text == "3")   // кнопка продовжити для 4 заїзду
			{

				timer8.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}
			if (number_group.Text == "4")   // кнопка продовжити для 5 заїзду
			{

				timer30.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}
			if (number_group.Text == "5")   // кнопка продовжити для 6 заїзду
			{

				timer31.Enabled = true;
				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;
				button6.Visible = true;
				button7.Visible = false;
				button6.Focus();
			}
			timer44.Enabled = false;
		}

		private void timer42_Tick(object sender, EventArgs e)
		{
			
		}

		private void timer46_Tick(object sender, EventArgs e)
		{
			dataGridView3.Rows.Clear();
			timer46.Enabled = false;
		}

		private void timer45_Tick(object sender, EventArgs e)
		{

			if (label13.Text != "Тренування!")
			{
				// сортування по результату
				dataGridView3.Rows.Add(label17.Text + "," + 6);
				dataGridView3.Rows.Add(label24.Text + "," + 5);
				dataGridView3.Rows.Add(label23.Text + "," + 4);
				dataGridView3.Rows.Add(label25.Text + "," + 3);
				dataGridView3.Rows.Add(label97.Text + "," + 2);
				dataGridView3.Rows.Add(label112.Text + "," + 1);

				dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);






				//червона

				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
				{
					panel1.Location = new Point(4, 219);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
					{

						panel1.Location = new Point(4, 321);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(4, 423);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(4, 525);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(4, 628);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
									{

										panel1.Location = new Point(4, 731);
									}
								}
							}
						}
					}

				}



				// біла

				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
				{
					panel3.Location = new Point(4, 219);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
					{

						panel3.Location = new Point(4, 321);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(4, 423);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(4, 525);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label24.Text + "," + 5))//&& Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(4, 628);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
									{

										panel3.Location = new Point(4, 731);
									}
								}
							}
						}
					}

				}

				// зелена

				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
				{
					panel4.Location = new Point(4, 219);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
					{

						panel4.Location = new Point(4, 321);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(4, 423);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(4, 525);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(4, 628);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
									{

										panel4.Location = new Point(4, 731);
									}
								}
							}
						}
					}

				}

				//оранжева 



				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
				{
					panel5.Location = new Point(4, 219);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
					{

						panel5.Location = new Point(4, 321);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(4, 423);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(4, 525);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(4, 628);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label25.Text + "," + 3))//&& Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
									{

										panel5.Location = new Point(4, 731);
									}
								}
							}
						}
					}

				}

				//синя

				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label97.Text + "," + 2))//&& Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
				{
					panel10.Location = new Point(4, 219);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
					{

						panel10.Location = new Point(4, 321);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
						{

							panel10.Location = new Point(4, 423);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
							{

								panel10.Location = new Point(4, 525);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
								{

									panel10.Location = new Point(4, 628);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
									{

										panel10.Location = new Point(4, 731);
									}
								}
							}
						}
					}

				}


				//жовта

				if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
				{
					panel11.Location = new Point(4, 219);
				}
				else
				{
					if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
					{

						panel11.Location = new Point(4, 321);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
						{

							panel11.Location = new Point(4, 423);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
							{

								panel11.Location = new Point(4, 525);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
								{

									panel11.Location = new Point(4, 628);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
									{

										panel11.Location = new Point(4, 731);
									}
								}
							}
						}
					}

				}
				timer46.Enabled = true;
			}
			timer45.Enabled = false;
		}

		private void синяToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Settings.Default.line6_6 = panel11.BackColor = Color.DodgerBlue;
			Settings.Default.Save();
		}

		private void чорнаToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Settings.Default.line6_6 = panel11.BackColor = Color.Black;
			Settings.Default.Save();
		}

		private void зеленаToolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Settings.Default.line6_6 = panel11.BackColor = Color.Green;
			Settings.Default.Save();
		}

		private void доріжкаToolStripMenuItem5_Click(object sender, EventArgs e)
		{

		}

		private void timer43_Tick(object sender, EventArgs e)
		{
			// алгоритм прогнозу
			
			if (label15.Text == "1/6")
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

				prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label97.Text);
				label120.Text = Convert.ToString(prognoz5);
				label120.Text = string.Format("{0:F2}", prognoz5);

				prognoz6 = (Convert.ToInt32(textBox38.Text) / seredniychas6) + Convert.ToDouble(label112.Text);
				label122.Text = Convert.ToString(prognoz6);
				label122.Text = string.Format("{0:F2}", prognoz6);
			}
			else
			{
				if (label15.Text == "2/6")
				{
					prognoz6 = (Convert.ToInt32(textBox38.Text) / seredniychas6) + Convert.ToDouble(label17.Text);
					label54.Text = Convert.ToString(prognoz6);
					label54.Text = string.Format("{0:F2}", prognoz6);


					prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label24.Text);
					label57.Text = Convert.ToString(prognoz5);
					label57.Text = string.Format("{0:F2}", prognoz5);


					prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label23.Text);
					label58.Text = Convert.ToString(prognoz1);
					label58.Text = string.Format("{0:F2}", prognoz1);


					prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label25.Text);
					label118.Text = Convert.ToString(prognoz2);
					label118.Text = string.Format("{0:F2}", prognoz2);

					prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label97.Text);
					label120.Text = Convert.ToString(prognoz3);
					label120.Text = string.Format("{0:F2}", prognoz3);

					prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label112.Text);
					label122.Text = Convert.ToString(prognoz4);
					label122.Text = string.Format("{0:F2}", prognoz4);
				}
				else
				{
					if (label15.Text == "3/6")
					{
						prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label17.Text);
						label54.Text = Convert.ToString(prognoz4);
						label54.Text = string.Format("{0:F2}", prognoz4);


						prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label24.Text);
						label57.Text = Convert.ToString(prognoz3);
						label57.Text = string.Format("{0:F2}", prognoz3);


						prognoz6 = (Convert.ToInt32(textBox38.Text) / seredniychas6) + Convert.ToDouble(label23.Text);
						label58.Text = Convert.ToString(prognoz6);
						label58.Text = string.Format("{0:F2}", prognoz6);


						prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label25.Text);
						label118.Text = Convert.ToString(prognoz5);
						label118.Text = string.Format("{0:F2}", prognoz5);

						prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label97.Text);
						label120.Text = Convert.ToString(prognoz1);
						label120.Text = string.Format("{0:F2}", prognoz1);

						prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label112.Text);
						label122.Text = Convert.ToString(prognoz2);
						label122.Text = string.Format("{0:F2}", prognoz2);
					}
					else
					{
						if (label15.Text == "4/6")
						{
							prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label17.Text);
							label54.Text = Convert.ToString(prognoz2);
							label54.Text = string.Format("{0:F2}", prognoz2);


							prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label24.Text);
							label57.Text = Convert.ToString(prognoz1);
							label57.Text = string.Format("{0:F2}", prognoz1);


							prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label23.Text);
							label58.Text = Convert.ToString(prognoz4);
							label58.Text = string.Format("{0:F2}", prognoz4);


							prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label25.Text);
							label118.Text = Convert.ToString(prognoz3);
							label118.Text = string.Format("{0:F2}", prognoz3);

							prognoz6 = (Convert.ToInt32(textBox38.Text) / seredniychas6) + Convert.ToDouble(label97.Text);
							label120.Text = Convert.ToString(prognoz6);
							label120.Text = string.Format("{0:F2}", prognoz6);

							prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label112.Text);
							label122.Text = Convert.ToString(prognoz5);
							label122.Text = string.Format("{0:F2}", prognoz5);
						}
						else
						{
							if (label15.Text == "5/6")
							{
								prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label17.Text);
								label54.Text = Convert.ToString(prognoz5);
								label54.Text = string.Format("{0:F2}", prognoz5);


								prognoz6 = (Convert.ToInt32(textBox38.Text) / seredniychas6) + Convert.ToDouble(label24.Text);
								label57.Text = Convert.ToString(prognoz6);
								label57.Text = string.Format("{0:F2}", prognoz6);


								prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label23.Text);
								label58.Text = Convert.ToString(prognoz2);
								label58.Text = string.Format("{0:F2}", prognoz2);


								prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label25.Text);
								label118.Text = Convert.ToString(prognoz1);
								label118.Text = string.Format("{0:F2}", prognoz1);

								prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label97.Text);
								label120.Text = Convert.ToString(prognoz4);
								label120.Text = string.Format("{0:F2}", prognoz4);

								prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label112.Text);
								label122.Text = Convert.ToString(prognoz3);
								label122.Text = string.Format("{0:F2}", prognoz3);
							}
							else
							{
								if (label15.Text == "6/6")
								{
									prognoz3 = (Convert.ToInt32(textBox38.Text) / seredniychas3) + Convert.ToDouble(label17.Text);
									label54.Text = Convert.ToString(prognoz3);
									label54.Text = string.Format("{0:F2}", prognoz3);


									prognoz4 = (Convert.ToInt32(textBox38.Text) / seredniychas4) + Convert.ToDouble(label24.Text);
									label57.Text = Convert.ToString(prognoz4);
									label57.Text = string.Format("{0:F2}", prognoz4);


									prognoz5 = (Convert.ToInt32(textBox38.Text) / seredniychas5) + Convert.ToDouble(label23.Text);
									label58.Text = Convert.ToString(prognoz5);
									label58.Text = string.Format("{0:F2}", prognoz5);


									prognoz6 = (Convert.ToInt32(textBox38.Text) / seredniychas6) + Convert.ToDouble(label25.Text);
									label118.Text = Convert.ToString(prognoz6);
									label118.Text = string.Format("{0:F2}", prognoz6);

									prognoz2 = (Convert.ToInt32(textBox38.Text) / seredniychas2) + Convert.ToDouble(label97.Text);
									label120.Text = Convert.ToString(prognoz2);
									label120.Text = string.Format("{0:F2}", prognoz2);

									prognoz1 = (Convert.ToInt32(textBox38.Text) / seredniychas1) + Convert.ToDouble(label112.Text);
									label122.Text = Convert.ToString(prognoz1);
									label122.Text = string.Format("{0:F2}", prognoz1);
								}
							}
						}
					}
				}

			}

		}

		private void timer41_Tick(object sender, EventArgs e)
		{
			int value;



			switch (Convert.ToInt32(textBox13.Text))
			{
				case 1:
					{
						if (label15.Text == "1/6")
						{
							value = (60 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (60 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (60 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (60 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (60 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 2:
					{
						if (label15.Text == "1/6")
						{
							value = (120 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (120 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (120 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (120 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (120 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 3:
					{
						if (label15.Text == "1/6")
						{
							value = (180 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (180 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (180 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (180 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (180 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 4:
					{
						if (label15.Text == "1/6")
						{
							value = (240 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (240 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (240 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (240 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (240 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 5:
					{
						if (label15.Text == "1/6")
						{
							value = (300 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (300 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (300 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (300 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (300 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 6:
					{
						if (label15.Text == "1/6")
						{
							value = (360 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (360 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (360 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (360 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (360 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 7:
					{
						if (label15.Text == "1/6")
						{
							value = (420 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (420 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (420 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (420 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (420 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 8:
					{
						if (label15.Text == "1/6")
						{
							value = (480 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (480 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (480 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (480 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (480 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 9:
					{
						if (label15.Text == "1/6")
						{
							value = (540 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (540 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (540 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (540 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (540 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 10:
					{
						if (label15.Text == "1/6")
						{
							value = (600 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (600 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (600 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (600 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (600 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 11:
					{
						if (label15.Text == "1/6")
						{
							value = (660 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (660 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (660 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (660 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (660 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 12:
					{
						if (label15.Text == "1/6")
						{
							value = (720 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (720 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (720 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (720 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (720 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 13:
					{
						if (label15.Text == "1/6")
						{
							value = (780 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (780 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (780 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (780 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (780 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 14:
					{
						if (label15.Text == "1/6")
						{
							value = (840 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (840 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (840 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (840 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (840 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
										}
									}
								}
							}
						}

						break;
					}
				case 15:
					{
						if (label15.Text == "1/6")
						{
							value = (900 * 5) + sec;
							textBox38.Text = Convert.ToString(value);
						}
						else
						{
							if (label15.Text == "2/6")
							{
								value = (900 * 4) + sec;
								textBox38.Text = Convert.ToString(value);
							}
							else
							{
								if (label15.Text == "3/6")
								{
									value = (900 * 3) + sec;
									textBox38.Text = Convert.ToString(value);
								}
								else
								{
									if (label15.Text == "4/6")
									{
										value = (900 * 2) + sec;
										textBox38.Text = Convert.ToString(value);
									}
									else
									{
										if (label15.Text == "5/6")
										{
											value = (900 * 1) + sec;
											textBox38.Text = Convert.ToString(value);
										}
										else
										{
											if (label15.Text == "6/6")
											{
												value = sec;
												textBox38.Text = Convert.ToString(value);
											}
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


		private void timer26_Tick_1(object sender, EventArgs e)
		{
			Timeo += 0.0003 * 53;                   //timer на час кола синя доріжка
			label95.Text = string.Format("{0:F3}", Timeo);       //timer на час кола синя доріжка
		}

		private void timer27_Tick(object sender, EventArgs e)
		{
			Timeb += 0.0003 * 53;                   //timer на час кола жовта доріжка
			label110.Text = string.Format("{0:F3}", Timeb);       //timer на час кола жовта доріжка
		}

		private void Form8_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.line_1 = panel1.BackColor;
			Settings.Default.line_2 = panel3.BackColor;
			Settings.Default.line_3 = panel4.BackColor;
			Settings.Default.line_4 = panel5.BackColor;
			Settings.Default.delay1 = delay;
			Settings.Default.color_delay = секToolStripMenuItem.BackColor;
			Settings.Default.deley6_text = toolStripTextBox1.Text;
			Settings.Default.color_delay1 = секToolStripMenuItem1.BackColor;
			Settings.Default.color_delay2 = секToolStripMenuItem2.BackColor;
			Settings.Default.color_delay3 = секToolStripMenuItem3.BackColor;
			Settings.Default.color_delay4 = секToolStripMenuItem4.BackColor;
			Settings.Default.color_delay5 = секToolStripMenuItem5.BackColor;
			Settings.Default.color_delay6 = toolStripTextBox1.BackColor;

			DialogResult dialog = MessageBox.Show(
				 "Вы действительно хотите выйти из программы?",
				 "Завершение программы",
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

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

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


					if(Convert.ToInt32(textBox39.Text) > traning_number_group) { 


						serialPort1.Write("3");
						perehid.Play();
						serialPort1.WriteLine("3");//пауза
						label69.Text = "Трек виключений";
						label69.BackColor = Color.Red;
						timer24.Enabled = false;
						timer25.Enabled = true;
						label13.Text = "Перехід!";

						traning_number_group = traning_number_group + 1;
						label15.Text = traning_number_group + "/" + textBox39.Text;

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

					} else
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

		private void button17_Click(object sender, EventArgs e)
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
			timer26.Enabled = true;
			timer27.Enabled = true;
		}

		private void timer11_Tick(object sender, EventArgs e)
		{


			Time += 0.0003 * 53;                   //timer на час кола червона доріжка
			label21.Text = string.Format("{0:F3}", Time);       //timer на час кола червона доріжка 





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

			//serialPort1.BaudRate = 19200;
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
				ExcelWorkShee_lap_TIME = (Microsoft.Office.Interop.Excel.Worksheet) ExcelWorkBook_lap_TIME.Worksheets.get_Item(1);



				for (int j = 0; j<dataGridView2.ColumnCount; j++)
					Excel_Lapp_TIME.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;

				for (int i = 0; i<dataGridView2.Rows.Count; i++)
				{
					for (int j = 0; j<dataGridView2.ColumnCount; j++)
					{
						Excel_Lapp_TIME.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
					}
	}
				
				
				
				
						Excel_Lapp_TIME.UserControl = true;
						Excel_Lapp_TIME.AlertBeforeOverwriting = true;

						Excel_Lapp_TIME.Visible = true;

				
			}




		}

		private void button8_Click(object sender, EventArgs e)
		{
			prognoz1 = 0;
			prognoz2 = 0;
			prognoz3 = 0;
			prognoz4 = 0;
			prognoz5 = 0;
			prognoz6 = 0;
			seredniychas1 = 0;
			seredniychas2 = 0;
			seredniychas3 = 0;
			seredniychas4 = 0;
			seredniychas5 = 0;
			seredniychas6 = 0;

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
			label15.Text = "1/6";
		}

		private void timer10_Tick(object sender, EventArgs e)
		{
			if (Convert.ToDouble(label18.Text) > delay)
			{




				int chervona, bila, zelena, orangeva, sunia, shovta;
				i++;                                            //добавляю кола 1 доріці
				label17.Text = Convert.ToString(i);


				// алгоритм прогнозу
				double masuv, kola, seredniychas, prognoz;


				if (label15.Text == "1/6")
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
					if (label15.Text == "2/6")
					{
						kola = Convert.ToDouble(label18.Text);
						masuv = Convert.ToDouble(label8.Text);
						seredniychas6 = Convert.ToDouble(label54.Text);
						kola = (kola + masuv);
						label8.Text = Convert.ToString(kola);
						seredniychas6 = kola / Convert.ToDouble(label17.Text);
					}
					else
					{
						if (label15.Text == "3/6")
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
							if (label15.Text == "4/6")
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
								if (label15.Text == "5/6")
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
									if (label15.Text == "6/6")
									{
										kola = Convert.ToDouble(label18.Text);
										masuv = Convert.ToDouble(label8.Text);
										seredniychas3 = Convert.ToDouble(label54.Text);
										kola = (kola + masuv);
										label8.Text = Convert.ToString(kola);
										seredniychas3 = kola / Convert.ToDouble(label17.Text);
									}
								}
							}
						}
					}
				}


				chervona = Convert.ToInt32(label17.Text);
				bila = Convert.ToInt32(label24.Text);
				zelena = Convert.ToInt32(label23.Text);
				orangeva = Convert.ToInt32(label25.Text);
				sunia = Convert.ToInt32(label97.Text);
				shovta = Convert.ToInt32(label112.Text);




				// підсвітка під час кола
				textBox1.BackColor = Color.LawnGreen;
				label17.BackColor = Color.LawnGreen;
				timer35.Enabled = true;









				//для сортування місця гонщика
				if (Convert.ToDouble(label22.Text) < 1)         //обмеження по часу кола 1 секунда
				{
					i--;
					label17.Text = Convert.ToString(i);
				}
				//textBox15.Text = "0";
				timer10.Enabled = false;
			}
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
				timer43.Enabled = true;
				Time = Convert.ToDouble(label102.Text);
				Timeg = Convert.ToDouble(label63.Text);
				Timez = Convert.ToDouble(label73.Text);
				Times = Convert.ToDouble(label66.Text);
				Timeo = Convert.ToDouble(label64.Text);
				Timeb = Convert.ToDouble(label65.Text);

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
				label15.Text = "4/6";

				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;
				timer26.Enabled = true;
				timer27.Enabled = true;

				button6.Enabled = true;
				button6.Focus();
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
					perehid.Play();
					serialPort1.WriteLine("3");//пауза
					label69.Text = "Трек виключений";
					label69.BackColor = Color.Red;
					button10.Enabled = true;
					button11.Enabled = false;
					timer8.Enabled = false;
					label4.Text = "00:00";
					secs = Convert.ToInt32(textBox14.Text);
					mins = 0;
					timer32.Enabled = true;
					label13.Text = "<<Перехід!>>";
					button6.Enabled = false;


					//перехід між доріжками
					timer43.Enabled = false;

					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;
					timer26.Enabled = false;
					timer27.Enabled = false;







					//


					lane2 = Convert.ToInt32(label24.Text) - lane1 - lane3 - lane5;
					lane2_1 = Convert.ToInt32(label17.Text) - lane2_2 - lane2_4 - lane2_6;
					lane3_4 = Convert.ToInt32(label25.Text) - lane3_3 - lane3_5 - lane3_2;
					lane4_3 = Convert.ToInt32(label23.Text) - lane4_4 - lane4_6 - lane4_1;
					lane5_6 = Convert.ToInt32(label112.Text) - lane5_5 - lane5_2 - lane5_4;
					lane6_5 = Convert.ToInt32(label97.Text) - lane6_6 - lane6_1 - lane6_3;










					textBox16.Text = label45.Text;  //червона
					label50.Text = label17.Text;
					label66.Text = label21.Text;
					label125.Text = label8.Text;
					label131.Text = label54.Text;



					textBox17.Text = label46.Text; //біла
					label51.Text = label24.Text;
					label63.Text = label27.Text;
					label126.Text = label56.Text;
					label132.Text = label57.Text;

					textBox18.Text = label47.Text;  //зелена
					label52.Text = label23.Text;
					label64.Text = label26.Text;
					label127.Text = label117.Text;
					label133.Text = label58.Text;

					textBox19.Text = label48.Text;  //оранжева
					label53.Text = label25.Text;
					label65.Text = label28.Text;
					label128.Text = label119.Text;
					label134.Text = label118.Text;

					textBox28.Text = label115.Text;  //синя
					label90.Text = label97.Text;
					label73.Text = label95.Text;
					label129.Text = label121.Text;
					label135.Text = label120.Text;

					textBox32.Text = label116.Text;  //жовта
					label105.Text = label112.Text;
					label102.Text = label110.Text;
					label130.Text = label123.Text;
					label136.Text = label122.Text;




					label45.Text = textBox32.Text;
					label17.Text = label105.Text;
					label21.Text = label102.Text;
					label8.Text = label130.Text;
					label54.Text = label136.Text;

					label46.Text = textBox28.Text;
					label24.Text = label90.Text;
					label27.Text = label73.Text;
					label56.Text = label129.Text;
					label57.Text = label135.Text;

					label47.Text = textBox16.Text;
					label23.Text = label50.Text;
					label26.Text = label66.Text;
					label117.Text = label125.Text;
					label58.Text = label131.Text;

					label48.Text = textBox17.Text;
					label25.Text = label51.Text;
					label28.Text = label63.Text;
					label119.Text = label126.Text;
					label118.Text = label132.Text;

					label115.Text = textBox18.Text;
					label97.Text = label52.Text;
					label95.Text = label64.Text;
					label121.Text = label127.Text;
					label120.Text = label133.Text;

					label116.Text = textBox19.Text;
					label112.Text = label53.Text;
					label110.Text = label65.Text;
					label123.Text = label128.Text;
					label122.Text = label134.Text;

					//label8.Text = "0";
					//label56.Text = "0";
					//label117.Text = "0";
					//label119.Text = "0";
					//	label121.Text = "0";
					//	label123.Text = "0";

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

					label94.Text = "00,000";
					label96.Text = "00,000";
					label93.Text = "00,000";
					label99.Text = "00,000";
					label92.Text = "999";

					label100.Text = "00,000";
					label101.Text = "00,000";
					label103.Text = "00,000";
					label114.Text = "00,000";
					label107.Text = "999";

					number_group.Text = "4";






					// сортування по результату
					dataGridView3.Rows.Add(label17.Text + "," + 6);
					dataGridView3.Rows.Add(label24.Text + "," + 5);
					dataGridView3.Rows.Add(label23.Text + "," + 4);
					dataGridView3.Rows.Add(label25.Text + "," + 3);
					dataGridView3.Rows.Add(label97.Text + "," + 2);
					dataGridView3.Rows.Add(label112.Text + "," + 1);

					dataGridView3.Sort(dataGridViewTextBoxColumn4, ListSortDirection.Descending);









					//червона

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToDouble(label17.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToDouble(label17.Text) != Convert.ToDouble(label112.Text))
					{
						panel1.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label17.Text + "," + 6))//&& Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
						{

							panel1.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
							{

								panel1.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
								{

									panel1.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
									{

										panel1.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label17.Text + "," + 6))// && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label112.Text))
										{

											panel1.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}



					// біла

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToDouble(label24.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label24.Text) != Convert.ToDouble(label112.Text))
					{
						panel3.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text ) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
						{

							panel3.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
							{

								panel3.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
								{

									panel3.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label24.Text + "," + 5))//&& Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
									{

										panel3.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label24.Text + "," + 5))// && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label112.Text))
										{

											panel3.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					// зелена

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToDouble(label23.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label25.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label23.Text) != Convert.ToDouble(label112.Text))
					{
						panel4.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
						{

							panel4.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
							{

								panel4.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label23.Text + "," + 4))//&& Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
								{

									panel4.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
									{

										panel4.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label23.Text + "," + 4))// && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label112.Text))
										{

											panel4.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//оранжева 



					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToDouble(label25.Text) != Convert.ToDouble(label17.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label24.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label23.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label97.Text) && Convert.ToDouble(label25.Text) != Convert.ToDouble(label112.Text))
					{
						panel5.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
						{

							panel5.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
							{

								panel5.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
								{

									panel5.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label25.Text + "," + 3))// && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
									{

										panel5.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label25.Text + "," + 3))//&& Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label97.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label112.Text))
										{

											panel5.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}

					//синя

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label97.Text + "," + 2))//&& Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
					{
						panel10.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
						{

							panel10.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
							{

								panel10.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
								{

									panel10.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
									{

										panel10.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label97.Text + "," + 2))// && Convert.ToInt32(label97.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label97.Text) != Convert.ToInt32(label112.Text))
										{

											panel10.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}


					//жовта

					if (Convert.ToDouble(dataGridView3[0, 0].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
					{
						panel11.Location = new Point(4, 219);
					}
					else
					{
						if (Convert.ToDouble(dataGridView3[0, 1].Value) == Convert.ToDouble(label112.Text + "," + 1))// && Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
						{

							panel11.Location = new Point(4, 321);
						}
						else
						{
							if (Convert.ToDouble(dataGridView3[0, 2].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
							{

								panel11.Location = new Point(4, 423);
							}
							else
							{
								if (Convert.ToDouble(dataGridView3[0, 3].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
								{

									panel11.Location = new Point(4, 525);
								}
								else
								{
									if (Convert.ToDouble(dataGridView3[0, 4].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
									{

										panel11.Location = new Point(4, 628);
									}
									else
									{
										if (Convert.ToDouble(dataGridView3[0, 5].Value) == Convert.ToDouble(label112.Text + "," + 1))// Convert.ToInt32(label112.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label112.Text) != Convert.ToInt32(label97.Text))
										{

											panel11.Location = new Point(4, 731);
										}
									}
								}
							}
						}

					}
					timer34.Enabled = true;

				}


			}


		}

		private void timer9_Tick(object sender, EventArgs e)
		{
			timer19.Enabled = true;








			











			

			
				
				


					if (Convert.ToInt16(textBox15.Text) == 01)
					{








						i = Convert.ToInt32(label17.Text);          //червона доріжка
						timer10.Enabled = true;
						timer11.Enabled = false;
						label18.Text = label21.Text;
						Time = 0;
						timer11.Enabled = true;
						timer45.Enabled = true;

						if (label13.Text == "Тренування!")  // алгоритм для часу кола для тренування червона доріжка
						{

							if (Convert.ToDouble(label16.Text) > delay) // обмеження часу у тренуванні
							{
								textBox15.Text = "0";

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
                    if (Convert.ToDouble(label18.Text) > delay)//обмеження крвщого часу кола 3 секунди
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






            }
            else
            {





                if (Convert.ToInt32(textBox15.Text) == 010)
                {







                    c = Convert.ToInt32(label24.Text);
                    timer13.Enabled = true;
                    timer17.Enabled = false;
                    label29.Text = label27.Text;
                    Timez = 0;
                    timer17.Enabled = true;
                    timer45.Enabled = true;



                    if (label13.Text == "Тренування!")      // алгоритм для часу кола для тренування біла доріжка
                    {
                        if (Convert.ToDouble(label42.Text) > delay) // обмеження часу у тренуванні
                        {
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
                    else                                     // алгоритм для часу кола для гонки біла доріжка
                    {

                        textBox15.Text = "0";

                        if (Convert.ToDouble(label29.Text) > delay)//обмеження крвщого часу кола 3 секунди
                        {

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





                }
                else
                {





                    if (Convert.ToInt32(textBox15.Text) == 011)
                    {






                        b = Convert.ToInt32(label23.Text);
                        timer12.Enabled = true;
                        timer15.Enabled = false;
                        label37.Text = label26.Text;
                        Times = 0;
                        timer15.Enabled = true;
                        timer45.Enabled = true;



                        if (label13.Text == "Тренування!")      // алгоритм для часу кола для тренування зелена доріжка
                        {
                            if (Convert.ToDouble(label43.Text) > delay) // обмеження часу у тренуванні
                            {
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
                        else                                        // алгоритм для часу кола для гонки зелена доріжка
                        {


                            textBox15.Text = "0";

                            if (Convert.ToDouble(label37.Text) > delay) //обмеження крвщого часу кола 3 секунди
                            {

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
                    }
                    else
                    {





                        if (Convert.ToInt32(textBox15.Text) == 0100)

                        {





                            d = Convert.ToInt32(label25.Text);
                            timer14.Enabled = true;
                            timer16.Enabled = false;
                            label38.Text = label28.Text;
                            Timeg = 0;
                            timer16.Enabled = true;
                            timer45.Enabled = true;





                            if (label13.Text == "Тренування!")// алгоритм для часу кола для тренування оранжева доріжка
                            {

                                if (Convert.ToDouble(label44.Text) > delay) // обмеження часу у тренуванні
                                {
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
                            else                                     // алгоритм для часу кола для Гонки оранжева доріжка
                            {


                                textBox15.Text = "0";
                                if (Convert.ToDouble(label38.Text) > delay)//обмеження крвщого часу кола 3 секунди
                                {

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
                        }





                        else
                        {

                            if (Convert.ToInt32(textBox15.Text) == 10000)




                            {





                                l = Convert.ToInt32(label112.Text);          //жовта доріжка
                                timer29.Enabled = true;
                                timer27.Enabled = false;
                                label114.Text = label110.Text;
                                Timeb = 0;
                                timer27.Enabled = true;
                                timer45.Enabled = true;
                                textBox15.Text = "0";


                                if (label13.Text == "Тренування!")      // алгоритм для часу кола для тренування жовта доріжка
                                {
                                    if (Convert.ToDouble(label107.Text) > delay) // обмеження часу у тренуванні
                                    {

                                        textBox15.Text = "0";
                                        label109.Text = label111.Text;
                                        label111.Text = label108.Text;
                                        label108.Text = label100.Text;
                                        label100.Text = label101.Text;
                                        label101.Text = label103.Text;
                                        label103.Text = label114.Text;
                                        label112.Text = Convert.ToString(l);
                                        if (Convert.ToDouble(label107.Text) > Convert.ToDouble(label114.Text))
                                        {
                                            label107.Text = label114.Text;
                                            best_time.Play();

                                        }
                                    }
                                    else
                                    {
                                        label107.Text = "999";
                                        label114.Text = "999";
                                        textBox15.Text = "0";
                                    }
                                }
                                else
                                {






                                    if (Convert.ToDouble(label114.Text) > delay)//обмеження крвщого часу кола 3 секунди
                                    {
                                        label100.Text = label101.Text;
                                        label101.Text = label103.Text;
                                        label103.Text = label114.Text;
                                        label112.Text = Convert.ToString(l);


                                        if (Convert.ToDouble(label107.Text) > Convert.ToDouble(label114.Text))
                                        {
                                            label107.Text = label114.Text;


                                        }

                                    }
                                    else
                                    {
                                        button6.PerformClick();
                                        MessageBox.Show("Щось пішло не так!! Перевірте модель на 6 доріжці!");
                                    }
                                }
                            }
                            else
                            {




                                if (Convert.ToInt32(textBox15.Text) == 10001)
                                {



                                    v = Convert.ToInt32(label97.Text);          //синя доріжка
                                    timer28.Enabled = true;
                                    timer26.Enabled = false;
                                    label99.Text = label95.Text;
                                    Timeo = 0;
                                    timer26.Enabled = true;
                                    timer45.Enabled = true;

                                    textBox15.Text = "0";

                                    if (label13.Text == "Тренування!")      // алгоритм для часу кола для тренування синя доріжка
                                    {
                                        if (Convert.ToDouble(label92.Text) > delay) // обмеження часу у тренуванні
                                        {





                                            label11.Text = label96.Text;
                                            label96.Text = label93.Text;
                                            label93.Text = label94.Text;

                                            label94.Text = label72.Text;
                                            label72.Text = label74.Text;
                                            label74.Text = label99.Text;
                                            label97.Text = Convert.ToString(v);


                                            if (Convert.ToDouble(label92.Text) > Convert.ToDouble(label99.Text))
                                            {
                                                label92.Text = label99.Text;
                                                best_time.Play();

                                            }
                                        }
                                        else
                                        {
                                            label107.Text = "999";
                                            label114.Text = "999";
                                            textBox15.Text = "0";
                                        }
                                    }
                                    else
                                    {



                                        if (Convert.ToDouble(label99.Text) > delay)//обмеження крвщого часу кола 3 секунди
                                        {

                                            label94.Text = label72.Text;
                                            label72.Text = label74.Text;
                                            label74.Text = label99.Text;
                                            label97.Text = Convert.ToString(v);


                                            if (Convert.ToDouble(label92.Text) > Convert.ToDouble(label99.Text))
                                            {
                                                label92.Text = label99.Text;


                                            }

                                        }
                                        else
                                        {
                                            button6.PerformClick();
                                            MessageBox.Show("Щось пішло не так!! Перевірте модель на 5 доріжці!");
                                        }

                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(textBox15.Text) == 011111111)
                                    {
                                        button6.PerformClick();
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




                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(textBox15.Text) == 010111111)
                                        {
                                            button7.PerformClick();
                                            textBox15.Text = "0";
                                        }
                                        else
                                        {
                                            textBox15.Text = "0";
                                        }

                                    }

                                }
                            }


                        }



                    }
                }


            }

				



			

			





































            //switch (Convert.ToInt32(textBox15.Text))
            //{

            //	case 10000:
            //		{
            //			l = Convert.ToInt32(label112.Text);          //жовта доріжка
            //			timer29.Enabled = true;
            //			timer27.Enabled = false;
            //			label114.Text = label110.Text;
            //			Timeb = 0;
            //			timer27.Enabled = true;
            //			timer45.Enabled = true;
            //			textBox15.Text = "0";


            //			if (label13.Text == "Тренування!")      // алгоритм для часу кола для тренування жовта доріжка
            //			{
            //				if (Convert.ToDouble(label107.Text) > delay) // обмеження часу у тренуванні
            //				{

            //					textBox15.Text = "0";
            //					label109.Text = label111.Text;
            //					label111.Text = label108.Text;
            //					label108.Text = label100.Text;
            //					label100.Text = label101.Text;
            //					label101.Text = label103.Text;
            //					label103.Text = label114.Text;
            //					label112.Text = Convert.ToString(l);
            //					if (Convert.ToDouble(label107.Text) > Convert.ToDouble(label114.Text))
            //					{
            //						label107.Text = label114.Text;
            //						best_time.Play();

            //					}
            //				}
            //				else
            //				{
            //					label107.Text = "999";
            //					label114.Text = "999";
            //					textBox15.Text = "0";
            //				}
            //			}
            //			else
            //			{






            //				if (Convert.ToDouble(label114.Text) > delay)//обмеження крвщого часу кола 3 секунди
            //				{
            //					label100.Text = label101.Text;
            //					label101.Text = label103.Text;
            //					label103.Text = label114.Text;
            //					label112.Text = Convert.ToString(l);


            //					if (Convert.ToDouble(label107.Text) > Convert.ToDouble(label114.Text))
            //					{
            //						label107.Text = label114.Text;


            //					}

            //				}
            //				else
            //				{
            //					button6.PerformClick();
            //					MessageBox.Show("Щось пішло не так!! Перевірте модель на 6 доріжці!");
            //				}
            //			}
            //		}
            //		break;
            //	case 10001:
            //		{
            //			v = Convert.ToInt32(label97.Text);          //синя доріжка
            //			timer28.Enabled = true;
            //			timer26.Enabled = false;
            //			label99.Text = label95.Text;
            //			Timeo = 0;
            //			timer26.Enabled = true;
            //			timer45.Enabled = true;

            //			textBox15.Text = "0";

            //			if (label13.Text == "Тренування!")      // алгоритм для часу кола для тренування синя доріжка
            //			{
            //				if (Convert.ToDouble(label92.Text) > delay) // обмеження часу у тренуванні
            //				{





            //					label11.Text = label96.Text;
            //					label96.Text = label93.Text;
            //					label93.Text = label94.Text;

            //					label94.Text = label72.Text;
            //					label72.Text = label74.Text;
            //					label74.Text = label99.Text;
            //					label97.Text = Convert.ToString(v);


            //					if (Convert.ToDouble(label92.Text) > Convert.ToDouble(label99.Text))
            //					{
            //						label92.Text = label99.Text;
            //						best_time.Play();

            //					}
            //				}
            //				else
            //				{
            //					label107.Text = "999";
            //					label114.Text = "999";
            //					textBox15.Text = "0";
            //				}
            //			}
            //			else
            //			{



            //				if (Convert.ToDouble(label99.Text) > delay)//обмеження крвщого часу кола 3 секунди
            //				{

            //					label94.Text = label72.Text;
            //					label72.Text = label74.Text;
            //					label74.Text = label99.Text;
            //					label97.Text = Convert.ToString(v);


            //					if (Convert.ToDouble(label92.Text) > Convert.ToDouble(label99.Text))
            //					{
            //						label92.Text = label99.Text;


            //					}

            //				}
            //				else
            //				{
            //					button6.PerformClick();
            //					MessageBox.Show("Щось пішло не так!! Перевірте модель на 5 доріжці!");
            //				}

            //			}
            //		}
            //		break;
            //	case 01:
            //		{
            //			i = Convert.ToInt32(label17.Text);          //червона доріжка
            //			timer10.Enabled = true;
            //			timer11.Enabled = false;
            //			label18.Text = label21.Text;
            //			Time = 0;
            //			timer11.Enabled = true;
            //			timer45.Enabled = true;

            //			if (label13.Text == "Тренування!")  // алгоритм для часу кола для тренування червона доріжка
            //			{

            //				if (Convert.ToDouble(label16.Text) > delay) // обмеження часу у тренуванні
            //				{
            //					textBox15.Text = "0";

            //					label78.Text = label77.Text;
            //					label77.Text = label76.Text;
            //					label76.Text = label20.Text;
            //					label20.Text = label19.Text;
            //					label19.Text = label22.Text;
            //					label22.Text = label18.Text;
            //					label17.Text = Convert.ToString(i);


            //					if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
            //					{
            //						label16.Text = label18.Text;
            //						best_time.Play();

            //					}
            //				}
            //				else
            //				{
            //					label18.Text = "999";
            //					label16.Text = "999";
            //					textBox15.Text = "0";
            //				}
            //			}
            //			else                             // алгоритм для часу кола для гонок червона доріжка
            //			{
            //				textBox15.Text = "0";
            //				if (Convert.ToDouble(label18.Text) > delay)//обмеження крвщого часу кола 3 секунди
            //				{
            //					label20.Text = label19.Text;
            //					label19.Text = label22.Text;
            //					label22.Text = label18.Text;
            //					label17.Text = Convert.ToString(i);


            //					if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
            //					{
            //						label16.Text = label18.Text;


            //					}
            //				}
            //				else
            //				{
            //					button6.PerformClick();
            //					MessageBox.Show("Щось пішло не так!! Перевірте модель на 1 доріжці!");
            //				}
            //			}
            //			break;
            //		}
            //	case 010:
            //		{
            //			c = Convert.ToInt32(label24.Text);
            //			timer13.Enabled = true;
            //			timer17.Enabled = false;
            //			label29.Text = label27.Text;
            //			Timez = 0;
            //			timer17.Enabled = true;
            //			timer45.Enabled = true;



            //			if (label13.Text == "Тренування!")      // алгоритм для часу кола для тренування біла доріжка
            //			{
            //				if (Convert.ToDouble(label42.Text) > delay) // обмеження часу у тренуванні
            //				{
            //					label79.Text = label80.Text;
            //					label80.Text = label81.Text;
            //					label81.Text = label31.Text;
            //					label31.Text = label32.Text;
            //					label32.Text = label30.Text;
            //					label30.Text = label29.Text;
            //					label24.Text = Convert.ToString(c);
            //					textBox15.Text = "0";

            //					if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
            //					{
            //						label42.Text = label29.Text;
            //						best_time.Play();


            //					}
            //				}
            //				else
            //				{


            //					label29.Text = "999";
            //					label42.Text = "999";
            //					textBox15.Text = "0";
            //				}
            //			}
            //			else                                     // алгоритм для часу кола для гонки біла доріжка
            //			{

            //				textBox15.Text = "0";

            //				if (Convert.ToDouble(label29.Text) > delay)//обмеження крвщого часу кола 3 секунди
            //				{

            //					label31.Text = label32.Text;
            //					label32.Text = label30.Text;
            //					label30.Text = label29.Text;
            //					label24.Text = Convert.ToString(c);


            //					if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
            //					{
            //						label42.Text = label29.Text;


            //					}

            //				}
            //				else
            //				{
            //					button6.PerformClick();
            //					MessageBox.Show("Щось пішло не так!! Перевірте модель на 2 доріжці!");
            //				}
            //			}
            //			break;
            //		}
            //	case 011:
            //		{
            //			b = Convert.ToInt32(label23.Text);
            //			timer12.Enabled = true;
            //			timer15.Enabled = false;
            //			label37.Text = label26.Text;
            //			Times = 0;
            //			timer15.Enabled = true;
            //			timer45.Enabled = true;



            //			if (label13.Text == "Тренування!")      // алгоритм для часу кола для тренування зелена доріжка
            //			{
            //				if (Convert.ToDouble(label43.Text) > delay) // обмеження часу у тренуванні
            //				{
            //					label82.Text = label83.Text;
            //					label83.Text = label84.Text;
            //					label84.Text = label35.Text;
            //					label35.Text = label36.Text;
            //					label36.Text = label34.Text;
            //					label34.Text = label37.Text;
            //					label23.Text = Convert.ToString(b);
            //					textBox15.Text = "0";


            //					if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
            //					{
            //						label43.Text = label37.Text;
            //						best_time.Play();

            //					}
            //				}
            //				else
            //				{
            //					label37.Text = "999";
            //					label43.Text = "999";
            //					textBox15.Text = "0";
            //				}
            //			}
            //			else                                        // алгоритм для часу кола для гонки зелена доріжка
            //			{


            //				textBox15.Text = "0";

            //				if (Convert.ToDouble(label37.Text) > delay) //обмеження крвщого часу кола 3 секунди
            //				{

            //					label35.Text = label36.Text;
            //					label36.Text = label34.Text;
            //					label34.Text = label37.Text;
            //					label23.Text = Convert.ToString(b);



            //					if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
            //					{
            //						label43.Text = label37.Text;

            //					}

            //				}
            //				else
            //				{
            //					button6.PerformClick();
            //					MessageBox.Show("Щось пішло не так!! Перевірте модель на 3 доріжці!");
            //				}
            //			}
            //			break;
            //		}
            //	case 0100:
            //		{
            //			d = Convert.ToInt32(label25.Text);
            //			timer14.Enabled = true;
            //			timer16.Enabled = false;
            //			label38.Text = label28.Text;
            //			Timeg = 0;
            //			timer16.Enabled = true;
            //			timer45.Enabled = true;





            //			if (label13.Text == "Тренування!")// алгоритм для часу кола для тренування оранжева доріжка
            //			{

            //				if (Convert.ToDouble(label44.Text) > delay) // обмеження часу у тренуванні
            //				{
            //					label85.Text = label86.Text;
            //					label86.Text = label87.Text;
            //					label87.Text = label40.Text;
            //					label40.Text = label41.Text;
            //					label41.Text = label39.Text;
            //					label39.Text = label38.Text;
            //					label25.Text = Convert.ToString(d);
            //					textBox15.Text = "0";

            //					if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //					{
            //						label44.Text = label38.Text;
            //						best_time.Play();

            //					}
            //				}
            //				else
            //				{
            //					label38.Text = "999";
            //					label44.Text = "999";
            //					textBox15.Text = "0";
            //				}
            //			}
            //			else                                     // алгоритм для часу кола для Гонки оранжева доріжка
            //			{


            //				textBox15.Text = "0";
            //				if (Convert.ToDouble(label38.Text) > delay)//обмеження крвщого часу кола 3 секунди
            //				{

            //					label40.Text = label41.Text;
            //					label41.Text = label39.Text;
            //					label39.Text = label38.Text;
            //					label25.Text = Convert.ToString(d);


            //					if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //					{
            //						label44.Text = label38.Text;

            //					}

            //				}
            //				else
            //				{
            //					button6.PerformClick();
            //					MessageBox.Show("Щось пішло не так!! Перевірте модель на 4 доріжці!");
            //				}
            //			}
            //			break;
            //		}
            //	//case 01111://// білан + зелена+ оранжева+Червона доріжка
            //	{
            //		c = Convert.ToInt32(label24.Text);
            //		timer13.Enabled = true;
            //		timer17.Enabled = false;
            //		label29.Text = label27.Text;
            //		Timez = 0;
            //		timer17.Enabled = true;
            //		label31.Text = label32.Text;
            //		label32.Text = label30.Text;
            //		label30.Text = label29.Text;
            //		label24.Text = Convert.ToString(c);


            //		b = Convert.ToInt32(label23.Text);
            //		timer12.Enabled = true;
            //		timer15.Enabled = false;
            //		label37.Text = label26.Text;
            //		Times = 0;
            //		timer15.Enabled = true;
            //		label35.Text = label36.Text;
            //		label36.Text = label34.Text;
            //		label34.Text = label37.Text;
            //		label23.Text = Convert.ToString(b);


            //		d = Convert.ToInt32(label25.Text);
            //		timer14.Enabled = true;
            //		timer16.Enabled = false;
            //		label38.Text = label28.Text;
            //		Timeg = 0;
            //		timer16.Enabled = true;
            //		label40.Text = label41.Text;
            //		label41.Text = label39.Text;
            //		label39.Text = label38.Text;
            //		label25.Text = Convert.ToString(d);

            //		i = Convert.ToInt32(label17.Text);
            //		timer10.Enabled = true;
            //		timer11.Enabled = false;
            //		label18.Text = label21.Text;
            //		Time = 0;
            //		timer11.Enabled = true;
            //		label20.Text = label19.Text;
            //		label19.Text = label22.Text;
            //		label22.Text = label18.Text;
            //		label17.Text = Convert.ToString(i);
            //		textBox15.Text = "0";

            //		if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
            //		{
            //			label16.Text = label18.Text;

            //		}

            //		if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //		{
            //			label44.Text = label38.Text;

            //		}

            //		if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
            //		{
            //			label43.Text = label37.Text;

            //		}

            //		if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
            //		{
            //			label42.Text = label29.Text;

            //		}
            //		break;
            //	}
            //case 01110:         // біла + зелена+ оранжева доріжка
            //	{
            //		c = Convert.ToInt32(label24.Text);
            //		timer13.Enabled = true;
            //		timer17.Enabled = false;
            //		label29.Text = label27.Text;
            //		Timez = 0;
            //		timer17.Enabled = true;
            //		label31.Text = label32.Text;
            //		label32.Text = label30.Text;
            //		label30.Text = label29.Text;
            //		label24.Text = Convert.ToString(c);


            //		b = Convert.ToInt32(label23.Text);
            //		timer12.Enabled = true;
            //		timer15.Enabled = false;
            //		label37.Text = label26.Text;
            //		Times = 0;
            //		timer15.Enabled = true;
            //		label35.Text = label36.Text;
            //		label36.Text = label34.Text;
            //		label34.Text = label37.Text;
            //		label23.Text = Convert.ToString(b);


            //		d = Convert.ToInt32(label25.Text);
            //		timer14.Enabled = true;
            //		timer16.Enabled = false;
            //		label38.Text = label28.Text;
            //		Timeg = 0;
            //		timer16.Enabled = true;
            //		label40.Text = label41.Text;
            //		label41.Text = label39.Text;
            //		label39.Text = label38.Text;
            //		label25.Text = Convert.ToString(d);
            //		textBox15.Text = "0";

            //		if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //		{
            //			label44.Text = label38.Text;

            //		}

            //		if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
            //		{
            //			label43.Text = label37.Text;

            //		}

            //		if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
            //		{
            //			label42.Text = label29.Text;

            //		}
            //		break;
            //	}
            //case 01100:
            //	{
            //		i = Convert.ToInt32(label17.Text);          //червона доріжка + зелена + оранжева
            //		timer10.Enabled = true;
            //		timer11.Enabled = false;
            //		label18.Text = label21.Text;
            //		Time = 0;
            //		timer11.Enabled = true;
            //		label20.Text = label19.Text;
            //		label19.Text = label22.Text;
            //		label22.Text = label18.Text;
            //		label17.Text = Convert.ToString(i);


            //		b = Convert.ToInt32(label23.Text);
            //		timer12.Enabled = true;
            //		timer15.Enabled = false;
            //		label37.Text = label26.Text;
            //		Times = 0;
            //		timer15.Enabled = true;
            //		label35.Text = label36.Text;
            //		label36.Text = label34.Text;
            //		label34.Text = label37.Text;
            //		label23.Text = Convert.ToString(b);

            //		d = Convert.ToInt32(label25.Text);
            //		timer14.Enabled = true;
            //		timer16.Enabled = false;
            //		label38.Text = label28.Text;
            //		Timeg = 0;
            //		timer16.Enabled = true;
            //		label40.Text = label41.Text;
            //		label41.Text = label39.Text;
            //		label39.Text = label38.Text;
            //		label25.Text = Convert.ToString(d);
            //		textBox15.Text = "0";

            //		if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //		{
            //			label44.Text = label38.Text;

            //		}


            //		if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
            //		{
            //			label43.Text = label37.Text;

            //		}

            //		if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
            //		{
            //			label16.Text = label18.Text;

            //		}
            //		break;
            //	}
            //case 01011:
            //	{
            //		i = Convert.ToInt32(label17.Text);          //червона  + біла+ оранжева доріжка
            //		timer10.Enabled = true;
            //		timer11.Enabled = false;
            //		label18.Text = label21.Text;
            //		Time = 0;
            //		timer11.Enabled = true;
            //		label20.Text = label19.Text;
            //		label19.Text = label22.Text;
            //		label22.Text = label18.Text;
            //		label17.Text = Convert.ToString(i);


            //		c = Convert.ToInt32(label24.Text);
            //		timer13.Enabled = true;
            //		timer17.Enabled = false;
            //		label29.Text = label27.Text;
            //		Timez = 0;
            //		timer17.Enabled = true;
            //		label31.Text = label32.Text;
            //		label32.Text = label30.Text;
            //		label30.Text = label29.Text;
            //		label24.Text = Convert.ToString(c);

            //		d = Convert.ToInt32(label25.Text);
            //		timer14.Enabled = true;
            //		timer16.Enabled = false;
            //		label38.Text = label28.Text;
            //		Timeg = 0;
            //		timer16.Enabled = true;
            //		label40.Text = label41.Text;
            //		label41.Text = label39.Text;
            //		label39.Text = label38.Text;
            //		label25.Text = Convert.ToString(d);
            //		textBox15.Text = "0";

            //		if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //		{
            //			label44.Text = label38.Text;

            //		}


            //		if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
            //		{
            //			label42.Text = label29.Text;

            //		}

            //		if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
            //		{
            //			label16.Text = label18.Text;

            //		}
            //		break;
            //	}


            //case 01010:                                     // біла + зелена доріжка
            //	{
            //		c = Convert.ToInt32(label24.Text);
            //		timer13.Enabled = true;
            //		timer17.Enabled = false;
            //		label29.Text = label27.Text;
            //		Timez = 0;
            //		timer17.Enabled = true;
            //		label31.Text = label32.Text;
            //		label32.Text = label30.Text;
            //		label30.Text = label29.Text;
            //		label24.Text = Convert.ToString(c);


            //		b = Convert.ToInt32(label23.Text);
            //		timer12.Enabled = true;
            //		timer15.Enabled = false;
            //		label37.Text = label26.Text;
            //		Times = 0;
            //		timer15.Enabled = true;
            //		label35.Text = label36.Text;
            //		label36.Text = label34.Text;
            //		label34.Text = label37.Text;
            //		label23.Text = Convert.ToString(b);
            //		textBox15.Text = "0";


            //		if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
            //		{
            //			label43.Text = label37.Text;

            //		}

            //		if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
            //		{
            //			label42.Text = label29.Text;

            //		}
            //		break;
            //	}
            //case 01001: // оранжева + зелена доріжка
            //	{

            //		d = Convert.ToInt32(label25.Text);
            //		timer14.Enabled = true;
            //		timer16.Enabled = false;
            //		label38.Text = label28.Text;
            //		Timeg = 0;
            //		timer16.Enabled = true;
            //		label40.Text = label41.Text;
            //		label41.Text = label39.Text;
            //		label39.Text = label38.Text;
            //		label25.Text = Convert.ToString(d);



            //		b = Convert.ToInt32(label23.Text);
            //		timer12.Enabled = true;
            //		timer15.Enabled = false;
            //		label37.Text = label26.Text;
            //		Times = 0;
            //		timer15.Enabled = true;
            //		label35.Text = label36.Text;
            //		label36.Text = label34.Text;
            //		label34.Text = label37.Text;
            //		label23.Text = Convert.ToString(b);
            //		textBox15.Text = "0";


            //		if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
            //		{
            //			label43.Text = label37.Text;

            //		}

            //		if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //		{
            //			label44.Text = label38.Text;

            //		}
            //		break;
            //	}
            //case 01000:
            //	{
            //		i = Convert.ToInt32(label17.Text);          //червона доріжка + зелена
            //		timer10.Enabled = true;
            //		timer11.Enabled = false;
            //		label18.Text = label21.Text;
            //		Time = 0;
            //		timer11.Enabled = true;
            //		label20.Text = label19.Text;
            //		label19.Text = label22.Text;
            //		label22.Text = label18.Text;
            //		label17.Text = Convert.ToString(i);


            //		b = Convert.ToInt32(label23.Text);
            //		timer12.Enabled = true;
            //		timer15.Enabled = false;
            //		label37.Text = label26.Text;
            //		Times = 0;
            //		timer15.Enabled = true;
            //		label35.Text = label36.Text;
            //		label36.Text = label34.Text;
            //		label34.Text = label37.Text;
            //		label23.Text = Convert.ToString(b);
            //		textBox15.Text = "0";


            //		if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
            //		{
            //			label43.Text = label37.Text;

            //		}

            //		if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
            //		{
            //			label16.Text = label18.Text;

            //		}
            //		break;
            //	}
            //case 0111:
            //	{
            //		i = Convert.ToInt32(label17.Text);          //червона + оранжева доріжка
            //		timer10.Enabled = true;
            //		timer11.Enabled = false;
            //		label18.Text = label21.Text;
            //		Time = 0;
            //		timer11.Enabled = true;
            //		label20.Text = label19.Text;
            //		label19.Text = label22.Text;
            //		label22.Text = label18.Text;
            //		label17.Text = Convert.ToString(i);


            //		d = Convert.ToInt32(label25.Text);
            //		timer14.Enabled = true;
            //		timer16.Enabled = false;
            //		label38.Text = label28.Text;
            //		Timeg = 0;
            //		timer16.Enabled = true;
            //		label40.Text = label41.Text;
            //		label41.Text = label39.Text;
            //		label39.Text = label38.Text;
            //		label25.Text = Convert.ToString(d);
            //		textBox15.Text = "0";

            //		if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //		{
            //			label44.Text = label38.Text;

            //		}

            //		if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
            //		{
            //			label16.Text = label18.Text;

            //		}
            //		break;
            //	}
            //case 0110:
            //	{
            //		i = Convert.ToInt32(label17.Text);          //червона + біла доріжка
            //		c = Convert.ToInt32(label24.Text);

            //		timer10.Enabled = true;
            //		timer11.Enabled = false;
            //		label18.Text = label21.Text;
            //		Time = 0;
            //		timer11.Enabled = true;
            //		label20.Text = label19.Text;
            //		label19.Text = label22.Text;
            //		label22.Text = label18.Text;
            //		label17.Text = Convert.ToString(i);






            //		timer13.Enabled = true;
            //		timer17.Enabled = false;
            //		label29.Text = label27.Text;
            //		Timez = 0;
            //		timer17.Enabled = true;
            //		label31.Text = label32.Text;
            //		label32.Text = label30.Text;
            //		label30.Text = label29.Text;
            //		label24.Text = Convert.ToString(c);
            //		textBox15.Text = "0";

            //		if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
            //		{
            //			label42.Text = label29.Text;

            //		}

            //		if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
            //		{
            //			label16.Text = label18.Text;

            //		}
            //		break;
            //	}
            //case 0101:                              // оранжева + біла
            //	{
            //		d = Convert.ToInt32(label25.Text);
            //		c = Convert.ToInt32(label24.Text);
            //		timer14.Enabled = true;
            //		timer13.Enabled = true;
            //		timer16.Enabled = false;
            //		timer17.Enabled = false;
            //		label38.Text = label28.Text;
            //		label29.Text = label27.Text;
            //		Timeg = 0;
            //		Timez = 0;
            //		timer16.Enabled = true;
            //		timer17.Enabled = true;
            //		label40.Text = label41.Text;
            //		label31.Text = label32.Text;
            //		label41.Text = label39.Text;
            //		label32.Text = label30.Text;
            //		label39.Text = label38.Text;
            //		label30.Text = label29.Text;
            //		label25.Text = Convert.ToString(d);
            //		label24.Text = Convert.ToString(c);
            //		textBox15.Text = "0";



            //		if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
            //		{
            //			label42.Text = label29.Text;

            //		}

            //		if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
            //		{
            //			label44.Text = label38.Text;

            //		}
            //		break;

            //	}

            //case 0:
            //	{

            //		break;
            //	}

            //case 011111111:
            //	{


            //		button6.PerformClick();
            //		textBox15.Text = "0";

            //	}
            //	break;
            //case 010111111:
            //	{
            //		button7.PerformClick();
            //		textBox15.Text = "0";

            //	}
            //	break;
            //default:
            //	{
            //		textBox15.Text = "0";
            //		break;
            //	}


























































































            //if (number_group.Text == "0")   // кнопка пауза для 1 заїзду
            //{
            //	timer2.Enabled = false;
            //	timer17.Enabled = false;
            //	timer11.Enabled = false;
            //	timer15.Enabled = false;
            //	timer16.Enabled = false;
            //	button6.Visible = false;
            //	button7.Visible = true;
            //	button7.Focus();
            //	textBox15.Text = "0";
            //}

            //if (number_group.Text == "1")   // кнопка пауза для 2 заїзду
            //{
            //	timer4.Enabled = false;
            //	timer17.Enabled = false;
            //	timer11.Enabled = false;
            //	timer15.Enabled = false;
            //	timer16.Enabled = false;
            //	button6.Visible = false;
            //	button7.Visible = true;
            //	button7.Focus();
            //	textBox15.Text = "0";
            //}

            //if (number_group.Text == "2")   // кнопка пауза для 3 заїзду
            //{
            //	timer6.Enabled = false;
            //	timer17.Enabled = false;
            //	timer11.Enabled = false;
            //	timer15.Enabled = false;
            //	timer16.Enabled = false;
            //	button6.Visible = false;
            //	button7.Visible = true;
            //	button7.Focus();
            //	textBox15.Text = "0";
            //}

            //if (number_group.Text == "3")   // кнопка пауза для 3 заїзду
            //{
            //	timer8.Enabled = false;
            //	timer17.Enabled = false;
            //	timer11.Enabled = false;
            //	timer15.Enabled = false;
            //	timer16.Enabled = false;
            //	button6.Visible = false;
            //	button7.Visible = true;
            //	button7.Focus();
            //	textBox15.Text = "0";
            //}












        }

		//serialPort1.Close();
		//
		///textBox15.Text = "0";

		//MessageBox.Show("Щось пішло не так!! Перевірте моделі!");




		//break;

		//}




		//if (Convert.ToInt32(textBox15.Text) == 01111) // зелена + Синя+ Жовта+Червона доріжка
		//{
		//	c = Convert.ToInt32(label24.Text);
		//	timer13.Enabled = true;
		//	timer17.Enabled = false;
		//	label29.Text = label27.Text;
		//	Timez = 0;
		//	timer17.Enabled = true;
		//	label31.Text = label32.Text;
		//	label32.Text = label30.Text;
		//	label30.Text = label29.Text;
		//	label24.Text = Convert.ToString(c);


		//	b = Convert.ToInt32(label23.Text);
		//	timer12.Enabled = true;
		//	timer15.Enabled = false;
		//	label37.Text = label26.Text;
		//	Times = 0;
		//	timer15.Enabled = true;
		//	label35.Text = label36.Text;
		//	label36.Text = label34.Text;
		//	label34.Text = label37.Text;
		//	label23.Text = Convert.ToString(b);


		//	d = Convert.ToInt32(label25.Text);
		//	timer14.Enabled = true;
		//	timer16.Enabled = false;
		//	label38.Text = label28.Text;
		//	Timeg = 0;
		//	timer16.Enabled = true;
		//	label40.Text = label41.Text;
		//	label41.Text = label39.Text;
		//	label39.Text = label38.Text;
		//	label25.Text = Convert.ToString(d);

		//	i = Convert.ToInt32(label17.Text);         
		//	timer10.Enabled = true;
		//	timer11.Enabled = false;
		//	label18.Text = label21.Text;
		//	Time = 0;
		//	timer11.Enabled = true;
		//	label20.Text = label19.Text;
		//	label19.Text = label22.Text;
		//	label22.Text = label18.Text;
		//	label17.Text = Convert.ToString(i);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
		//	{
		//		label16.Text = label18.Text;

		//	}

		//	if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
		//	{
		//		label44.Text = label38.Text;

		//	}

		//	if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
		//	{
		//		label43.Text = label37.Text;

		//	}

		//	if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
		//	{
		//		label42.Text = label29.Text;

		//	}


		//}

		//if (Convert.ToInt32(textBox15.Text) == 01110) // зелена + Синя+ Жовта доріжка
		//{
		//	c = Convert.ToInt32(label24.Text);
		//	timer13.Enabled = true;
		//	timer17.Enabled = false;
		//	label29.Text = label27.Text;
		//	Timez = 0;
		//	timer17.Enabled = true;
		//	label31.Text = label32.Text;
		//	label32.Text = label30.Text;
		//	label30.Text = label29.Text;
		//	label24.Text = Convert.ToString(c);


		//	b = Convert.ToInt32(label23.Text);
		//	timer12.Enabled = true;
		//	timer15.Enabled = false;
		//	label37.Text = label26.Text;
		//	Times = 0;
		//	timer15.Enabled = true;
		//	label35.Text = label36.Text;
		//	label36.Text = label34.Text;
		//	label34.Text = label37.Text;
		//	label23.Text = Convert.ToString(b);


		//	d = Convert.ToInt32(label25.Text);
		//	timer14.Enabled = true;
		//	timer16.Enabled = false;
		//	label38.Text = label28.Text;
		//	Timeg = 0;
		//	timer16.Enabled = true;
		//	label40.Text = label41.Text;
		//	label41.Text = label39.Text;
		//	label39.Text = label38.Text;
		//	label25.Text = Convert.ToString(d);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
		//	{
		//		label44.Text = label38.Text;

		//	}

		//	if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
		//	{
		//		label43.Text = label37.Text;

		//	}

		//	if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
		//	{
		//		label42.Text = label29.Text;

		//	}


		//}


		//if (Convert.ToInt32(textBox15.Text) == 01100)
		//{
		//	i = Convert.ToInt32(label17.Text);          //червона доріжка + Синя + жовта
		//	timer10.Enabled = true;
		//	timer11.Enabled = false;
		//	label18.Text = label21.Text;
		//	Time = 0;
		//	timer11.Enabled = true;
		//	label20.Text = label19.Text;
		//	label19.Text = label22.Text;
		//	label22.Text = label18.Text;
		//	label17.Text = Convert.ToString(i);


		//	b = Convert.ToInt32(label23.Text);
		//	timer12.Enabled = true;
		//	timer15.Enabled = false;
		//	label37.Text = label26.Text;
		//	Times = 0;
		//	timer15.Enabled = true;
		//	label35.Text = label36.Text;
		//	label36.Text = label34.Text;
		//	label34.Text = label37.Text;
		//	label23.Text = Convert.ToString(b);

		//	d = Convert.ToInt32(label25.Text);
		//	timer14.Enabled = true;
		//	timer16.Enabled = false;
		//	label38.Text = label28.Text;
		//	Timeg = 0;
		//	timer16.Enabled = true;
		//	label40.Text = label41.Text;
		//	label41.Text = label39.Text;
		//	label39.Text = label38.Text;
		//	label25.Text = Convert.ToString(d);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
		//	{
		//		label44.Text = label38.Text;

		//	}


		//	if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
		//	{
		//		label43.Text = label37.Text;

		//	}

		//	if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
		//	{
		//		label16.Text = label18.Text;

		//	}
		//}



		//if (Convert.ToInt32(textBox15.Text) == 01011)
		//{
		//	i = Convert.ToInt32(label17.Text);          //червона  + Зелена+ Жовта доріжка
		//	timer10.Enabled = true;
		//	timer11.Enabled = false;
		//	label18.Text = label21.Text;
		//	Time = 0;
		//	timer11.Enabled = true;
		//	label20.Text = label19.Text;
		//	label19.Text = label22.Text;
		//	label22.Text = label18.Text;
		//	label17.Text = Convert.ToString(i);


		//	c = Convert.ToInt32(label24.Text);
		//	timer13.Enabled = true;
		//	timer17.Enabled = false;
		//	label29.Text = label27.Text;
		//	Timez = 0;
		//	timer17.Enabled = true;
		//	label31.Text = label32.Text;
		//	label32.Text = label30.Text;
		//	label30.Text = label29.Text;
		//	label24.Text = Convert.ToString(c);

		//	d = Convert.ToInt32(label25.Text);
		//	timer14.Enabled = true;
		//	timer16.Enabled = false;
		//	label38.Text = label28.Text;
		//	Timeg = 0;
		//	timer16.Enabled = true;
		//	label40.Text = label41.Text;
		//	label41.Text = label39.Text;
		//	label39.Text = label38.Text;
		//	label25.Text = Convert.ToString(d);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
		//	{
		//		label44.Text = label38.Text;

		//	}


		//	if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
		//	{
		//		label42.Text = label29.Text;

		//	}

		//	if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
		//	{
		//		label16.Text = label18.Text;

		//	}
		//}

		//if (Convert.ToInt32(textBox15.Text) == 01011)
		//{
		//	i = Convert.ToInt32(label17.Text);          //червона  + Зелена+ Синя доріжка
		//	timer10.Enabled = true;
		//	timer11.Enabled = false;
		//	label18.Text = label21.Text;
		//	Time = 0;
		//	timer11.Enabled = true;
		//	label20.Text = label19.Text;
		//	label19.Text = label22.Text;
		//	label22.Text = label18.Text;
		//	label17.Text = Convert.ToString(i);


		//	c = Convert.ToInt32(label24.Text);
		//	timer13.Enabled = true;
		//	timer17.Enabled = false;
		//	label29.Text = label27.Text;
		//	Timez = 0;
		//	timer17.Enabled = true;
		//	label31.Text = label32.Text;
		//	label32.Text = label30.Text;
		//	label30.Text = label29.Text;
		//	label24.Text = Convert.ToString(c);


		//	b = Convert.ToInt32(label23.Text);
		//	timer12.Enabled = true;
		//	timer15.Enabled = false;
		//	label37.Text = label26.Text;
		//	Times = 0;
		//	timer15.Enabled = true;
		//	label35.Text = label36.Text;
		//	label36.Text = label34.Text;
		//	label34.Text = label37.Text;
		//	label23.Text = Convert.ToString(b);
		//	textBox15.Text = "0";


		//	if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
		//	{
		//		label43.Text = label37.Text;

		//	}


		//	if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
		//	{
		//		label42.Text = label29.Text;

		//	}

		//	if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
		//	{
		//		label16.Text = label18.Text;

		//	}
		//}

		//if (Convert.ToInt32(textBox15.Text) == 01010) // зелена + Синя доріжка
		//{
		//	c = Convert.ToInt32(label24.Text);
		//	timer13.Enabled = true;
		//	timer17.Enabled = false;
		//	label29.Text = label27.Text;
		//	Timez = 0;
		//	timer17.Enabled = true;
		//	label31.Text = label32.Text;
		//	label32.Text = label30.Text;
		//	label30.Text = label29.Text;
		//	label24.Text = Convert.ToString(c);


		//	b = Convert.ToInt32(label23.Text);
		//	timer12.Enabled = true;
		//	timer15.Enabled = false;
		//	label37.Text = label26.Text;
		//	Times = 0;
		//	timer15.Enabled = true;
		//	label35.Text = label36.Text;
		//	label36.Text = label34.Text;
		//	label34.Text = label37.Text;
		//	label23.Text = Convert.ToString(b);
		//	textBox15.Text = "0";


		//	if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
		//	{
		//		label43.Text = label37.Text;

		//	}

		//	if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
		//	{
		//		label42.Text = label29.Text;

		//	}


		//}



		//if (Convert.ToInt32(textBox15.Text) == 01001) // жовта + Синя доріжка
		//{
		//	d = Convert.ToInt32(label25.Text);
		//	timer14.Enabled = true;
		//	timer16.Enabled = false;
		//	label38.Text = label28.Text;
		//	Timeg = 0;
		//	timer16.Enabled = true;
		//	label40.Text = label41.Text;
		//	label41.Text = label39.Text;
		//	label39.Text = label38.Text;
		//	label25.Text = Convert.ToString(d);



		//	b = Convert.ToInt32(label23.Text);
		//	timer12.Enabled = true;
		//	timer15.Enabled = false;
		//	label37.Text = label26.Text;
		//	Times = 0;
		//	timer15.Enabled = true;
		//	label35.Text = label36.Text;
		//	label36.Text = label34.Text;
		//	label34.Text = label37.Text;
		//	label23.Text = Convert.ToString(b);
		//	textBox15.Text = "0";


		//	if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
		//	{
		//		label43.Text = label37.Text;

		//	}

		//	if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
		//	{
		//		label44.Text = label38.Text;

		//	}


		//}




		//if (Convert.ToInt32(textBox15.Text) == 01000)
		//{
		//	i = Convert.ToInt32(label17.Text);          //червона доріжка + Синя
		//	timer10.Enabled = true;
		//	timer11.Enabled = false;
		//	label18.Text = label21.Text;
		//	Time = 0;
		//	timer11.Enabled = true;
		//	label20.Text = label19.Text;
		//	label19.Text = label22.Text;
		//	label22.Text = label18.Text;
		//	label17.Text = Convert.ToString(i);


		//	b = Convert.ToInt32(label23.Text);
		//	timer12.Enabled = true;
		//	timer15.Enabled = false;
		//	label37.Text = label26.Text;
		//	Times = 0;
		//	timer15.Enabled = true;
		//	label35.Text = label36.Text;
		//	label36.Text = label34.Text;
		//	label34.Text = label37.Text;
		//	label23.Text = Convert.ToString(b);
		//	textBox15.Text = "0";


		//	if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
		//	{
		//		label43.Text = label37.Text;

		//	}

		//	if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
		//	{
		//		label16.Text = label18.Text;

		//	}
		//}




		//if (Convert.ToInt32(textBox15.Text) == 0111)
		//{
		//	i = Convert.ToInt32(label17.Text);          //червона + Жовта доріжка
		//	timer10.Enabled = true;
		//	timer11.Enabled = false;
		//	label18.Text = label21.Text;
		//	Time = 0;
		//	timer11.Enabled = true;
		//	label20.Text = label19.Text;
		//	label19.Text = label22.Text;
		//	label22.Text = label18.Text;
		//	label17.Text = Convert.ToString(i);


		//	d = Convert.ToInt32(label25.Text);
		//	timer14.Enabled = true;
		//	timer16.Enabled = false;
		//	label38.Text = label28.Text;
		//	Timeg = 0;
		//	timer16.Enabled = true;
		//	label40.Text = label41.Text;
		//	label41.Text = label39.Text;
		//	label39.Text = label38.Text;
		//	label25.Text = Convert.ToString(d);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
		//	{
		//		label44.Text = label38.Text;

		//	}

		//	if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
		//	{
		//		label16.Text = label18.Text;

		//	}
		//}




		//if (Convert.ToInt32(textBox15.Text) == 0110)
		//{
		//	i = Convert.ToInt32(label17.Text);          //червона + зелена доріжка
		//	c = Convert.ToInt32(label24.Text);

		//	timer10.Enabled = true;
		//	timer11.Enabled = false;
		//	label18.Text = label21.Text;
		//	Time = 0;
		//	timer11.Enabled = true;
		//	label20.Text = label19.Text;
		//	label19.Text = label22.Text;
		//	label22.Text = label18.Text;
		//	label17.Text = Convert.ToString(i);






		//	timer13.Enabled = true;
		//	timer17.Enabled = false;
		//	label29.Text = label27.Text;
		//	Timez = 0;
		//	timer17.Enabled = true;
		//	label31.Text = label32.Text;
		//	label32.Text = label30.Text;
		//	label30.Text = label29.Text;
		//	label24.Text = Convert.ToString(c);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
		//	{
		//		label42.Text = label29.Text;

		//	}

		//	if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
		//	{
		//		label16.Text = label18.Text;

		//	}
		//}






		//if (Convert.ToInt32(textBox15.Text) == 0101) // жовта + зелена
		//{
		//	d = Convert.ToInt32(label25.Text);
		//	c = Convert.ToInt32(label24.Text);
		//	timer14.Enabled = true;
		//	timer13.Enabled = true;
		//	timer16.Enabled = false;
		//	timer17.Enabled = false;
		//	label38.Text = label28.Text;
		//	label29.Text = label27.Text;
		//	Timeg = 0;
		//	Timez = 0;
		//	timer16.Enabled = true;
		//	timer17.Enabled = true;
		//	label40.Text = label41.Text;
		//	label31.Text = label32.Text;
		//	label41.Text = label39.Text;
		//	label32.Text = label30.Text;
		//	label39.Text = label38.Text;
		//	label30.Text = label29.Text;
		//	label25.Text = Convert.ToString(d);
		//	label24.Text = Convert.ToString(c);
		//	textBox15.Text = "0";



		//	if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
		//	{
		//		label42.Text = label29.Text;

		//	}

		//	if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
		//	{
		//		label44.Text = label38.Text;

		//	}


		//}

		//if (Convert.ToInt32(textBox15.Text) == 01)
		//{
		//	i = Convert.ToInt32(label17.Text);          //червона доріжка
		//	timer10.Enabled = true;
		//	timer11.Enabled = false;
		//	label18.Text = label21.Text;
		//	Time = 0;
		//	timer11.Enabled = true;
		//	label20.Text = label19.Text;
		//	label19.Text = label22.Text;
		//	label22.Text = label18.Text;
		//	label17.Text = Convert.ToString(i);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
		//	{
		//		label16.Text = label18.Text;

		//	}
		//}



		//		if (Convert.ToInt32(textBox15.Text) == 011) // синя доріжка
		//		{
		//			b = Convert.ToInt32(label23.Text);
		//			timer12.Enabled = true;
		//			timer15.Enabled = false;
		//			label37.Text = label26.Text;
		//			Times = 0;
		//			timer15.Enabled = true;
		//			label35.Text = label36.Text;
		//			label36.Text = label34.Text;
		//			label34.Text = label37.Text; 
		//			label23.Text = Convert.ToString(b);
		//			textBox15.Text = "0";


		//	if (Convert.ToDouble(label43.Text) > Convert.ToDouble(label37.Text))
		//	{
		//		label43.Text = label37.Text;

		//	}


		//}


		//if (Convert.ToInt32(textBox15.Text) == 010) // зелена доріжка
		//{
		//	c = Convert.ToInt32(label24.Text);
		//	timer13.Enabled = true;
		//	timer17.Enabled = false;
		//	label29.Text = label27.Text;
		//	Timez = 0;
		//	timer17.Enabled = true;
		//	label31.Text = label32.Text;
		//	label32.Text = label30.Text;
		//	label30.Text = label29.Text; 
		//	label24.Text = Convert.ToString(c);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
		//	{
		//		label42.Text = label29.Text;

		//	}


		//}

		//if (Convert.ToInt32(textBox15.Text) == 0100) // жовта доріжка
		//{
		//	d = Convert.ToInt32(label25.Text);
		//	timer14.Enabled = true;
		//	timer16.Enabled = false;
		//	label38.Text = label28.Text;
		//	Timeg = 0;
		//	timer16.Enabled = true;
		//	label40.Text = label41.Text;
		//	label41.Text = label39.Text;
		//	label39.Text = label38.Text;
		//	label25.Text = Convert.ToString(d);
		//	textBox15.Text = "0";

		//	if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
		//	{
		//		label44.Text = label38.Text;

		//	}


		//}


		private void timer12_Tick(object sender, EventArgs e)
		{
			if (Convert.ToDouble(label37.Text) > delay)
			{
				b++;                                            //добавляю кола 1 доріці
				label23.Text = Convert.ToString(b);


				// алгоритм прогнозу
				if (label15.Text == "1/6")
				{


					double masuv, kola, seredniychas, prognoz;
					kola = Convert.ToDouble(label37.Text);
					masuv = Convert.ToDouble(label117.Text);
					seredniychas3 = Convert.ToDouble(label58.Text);
					kola = (kola + masuv);
					label117.Text = Convert.ToString(kola);
					seredniychas3 = kola / Convert.ToDouble(label23.Text);
				}
				else
				{
					if (label15.Text == "2/6")
					{


						double masuv, kola, seredniychas, prognoz;
						kola = Convert.ToDouble(label37.Text);
						masuv = Convert.ToDouble(label117.Text);
						seredniychas1 = Convert.ToDouble(label58.Text);
						kola = (kola + masuv);
						label117.Text = Convert.ToString(kola);
						seredniychas1 = kola / Convert.ToDouble(label23.Text);
					}
					else
					{
						if (label15.Text == "3/6")
						{


							double masuv, kola, seredniychas, prognoz;
							kola = Convert.ToDouble(label37.Text);
							masuv = Convert.ToDouble(label117.Text);
							seredniychas6 = Convert.ToDouble(label58.Text);
							kola = (kola + masuv);
							label117.Text = Convert.ToString(kola);
							seredniychas6 = kola / Convert.ToDouble(label23.Text);
						}
						else
						{
							if (label15.Text == "4/6")
							{


								double masuv, kola, seredniychas, prognoz;
								kola = Convert.ToDouble(label37.Text);
								masuv = Convert.ToDouble(label117.Text);
								seredniychas4 = Convert.ToDouble(label58.Text);
								kola = (kola + masuv);
								label117.Text = Convert.ToString(kola);
								seredniychas4 = kola / Convert.ToDouble(label23.Text);
							}
							else
							{
								if (label15.Text == "5/6")
								{


									double masuv, kola, seredniychas, prognoz;
									kola = Convert.ToDouble(label37.Text);
									masuv = Convert.ToDouble(label117.Text);
									seredniychas2 = Convert.ToDouble(label58.Text);
									kola = (kola + masuv);
									label117.Text = Convert.ToString(kola);
									seredniychas2 = kola / Convert.ToDouble(label23.Text);
								}
								else
								{
									if (label15.Text == "6/6")
									{


										double masuv, kola, seredniychas, prognoz;
										kola = Convert.ToDouble(label37.Text);
										masuv = Convert.ToDouble(label117.Text);
										seredniychas5 = Convert.ToDouble(label58.Text);
										kola = (kola + masuv);
										label117.Text = Convert.ToString(kola);
										seredniychas5 = kola / Convert.ToDouble(label23.Text);
									}
								}
							}
						}
					}
				}


				// підсвітка під час кола
				textBox9.BackColor = Color.LawnGreen;
				label23.BackColor = Color.LawnGreen;
				timer37.Enabled = true;


				timer34.Enabled = true;

				if (Convert.ToDouble(label34.Text) < 1)         //обмеження по часу кола 1 секунда
				{
					b--;
					label23.Text = Convert.ToString(b);
				}

				timer12.Enabled = false;
			}

		}
	} 
}