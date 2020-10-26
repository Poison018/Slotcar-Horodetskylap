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


namespace zase4kak
{
	public partial class Form3 : Form
	{
		string[,] list = new string[50, 5];
		string[] name = new string[40];
		public Form3()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{


			timer1.Enabled = true;
			button1.Visible = false;
			button6.Visible = true;
			button6.Focus();
		}

		int mins, secs, min, sec, i, msecs, mmsecs, b, c, d;

		


		int timetostart = 5; // значення стартового таймера


		double Time, Times, Timez, Timeg;//timer на час кола
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




			label4.Text = Convert.ToString(timetostart); //вивід стартового таймера у лейбл
			timetostart--;

			if (timetostart == -1) //якщо стартовий номер = -1 таймер зупиняє роботу і ховає лейбл4
			{

				timer1.Enabled = false;


				if (timetostart == -1)


				{
					timer2.Enabled = true;
					label4.Text = "00:00";
					sec = 1;
					min = Convert.ToInt32(textBox13.Text);
					label13.Text = "<<Гонка!>>";
					label15.Visible = true;
					label15.Text = "1/4";
					label13.Visible = true;
					timer20.Enabled = true;
					timer11.Enabled = true;
					timer16.Enabled = true;
					timer17.Enabled = true;
					timer15.Enabled = true;
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

					timer2.Enabled = false;
					label4.Text = "00:00";
					secs = Convert.ToInt32(textBox14.Text);
					mins = 0;
					timer3.Enabled = true;
					label13.Text = "<<Перехід!>>";



					//перехід між доріжками


					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;



					textBox16.Text = label45.Text;
					label50.Text = label17.Text;
					label66.Text = label21.Text;


					textBox17.Text = label46.Text;
					label51.Text = label24.Text;
					label63.Text = label27.Text;

					textBox18.Text = label47.Text;
					label52.Text = label23.Text;
					label64.Text = label26.Text;

					textBox19.Text = label48.Text;
					label53.Text = label25.Text;
					label65.Text = label28.Text;




					label45.Text = textBox17.Text;
					label17.Text = label51.Text;
					label21.Text = label63.Text;

					label46.Text = textBox19.Text;
					label24.Text = label53.Text;
					label27.Text = label65.Text;

					label47.Text = textBox16.Text;
					label23.Text = label50.Text;
					label26.Text = label66.Text;

					label48.Text = textBox18.Text;
					label25.Text = label52.Text;
					label28.Text = label64.Text;


					

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

					number_group.Text = "1";
				}
			}
		}



		private void timer3_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

			button6.Enabled = false;
		
			



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

			if (secs == 0 && mins == 0)
			{
				Time = Convert.ToDouble(label63.Text);
				Timeg = Convert.ToDouble(label64.Text);
				Timez = Convert.ToDouble(label65.Text);
				Times = Convert.ToDouble(label66.Text);

				timer3.Enabled = false;
				timer4.Enabled = true;
				sec = 1;
				min = Convert.ToInt32(textBox13.Text);
				label4.Text = "00:00";
				label13.Text = "<<Гонка!>>";
				label15.Text = "2/4";

				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;

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

					timer4.Enabled = false;
					label4.Text = "00:00";
					secs = Convert.ToInt32(textBox14.Text);
					mins = 0;
					timer5.Enabled = true;
					label13.Text = "<<Перехід!>>";


					//перехід між доріжками

					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;

					textBox16.Text = label45.Text;
					label50.Text = label17.Text;
					label66.Text = label21.Text;

					textBox17.Text = label46.Text;
					label51.Text = label24.Text;
					label63.Text = label27.Text;

					textBox18.Text = label47.Text;
					label52.Text = label23.Text;
					label64.Text = label26.Text;

					textBox19.Text = label48.Text;
					label53.Text = label25.Text;
					label65.Text = label28.Text;



					label45.Text = textBox17.Text;
					label17.Text = label51.Text;
					label21.Text = label63.Text;

					label46.Text = textBox19.Text;
					label24.Text = label53.Text;
					label27.Text = label65.Text;

					label47.Text = textBox16.Text;
					label23.Text = label50.Text;
					label26.Text = label66.Text;

					label48.Text = textBox18.Text;
					label25.Text = label52.Text;
					label28.Text = label64.Text;

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

					number_group.Text = "2";

				}
			}
		}



		private void timer5_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

			button6.Enabled = false;

			

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

			if (secs == 0 && mins == 0)
			{
				timer5.Enabled = false;
				timer6.Enabled = true;

				Time = Convert.ToDouble(label63.Text);
				Timeg = Convert.ToDouble(label64.Text);
				Timez = Convert.ToDouble(label65.Text);
				Times = Convert.ToDouble(label66.Text);


				sec = 1;
				min = Convert.ToInt32(textBox13.Text);
				label4.Text = "00:00";
				label13.Text = "<<Гонка!>>";
				label15.Text = "3/4";

				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;

				button6.Enabled = true;
				button6.Focus();
			}

		}

		private void Form3_Load(object sender, EventArgs e)
		{
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

					timer6.Enabled = false;
					label4.Text = "00:00";
					secs = Convert.ToInt32(textBox14.Text);
					mins = 0;
					timer7.Enabled = true;
					label13.Text = "<<Перехід!>>";

					//перехід між доріжками


					timer17.Enabled = false;
					timer11.Enabled = false;
					timer15.Enabled = false;
					timer16.Enabled = false;


					textBox16.Text = label45.Text;
					label50.Text = label17.Text;
					label66.Text = label21.Text;


					textBox17.Text = label46.Text;
					label51.Text = label24.Text;
					label63.Text = label27.Text;

					textBox18.Text = label47.Text;
					label52.Text = label23.Text;
					label64.Text = label26.Text;

					textBox19.Text = label48.Text;
					label53.Text = label25.Text;
					label65.Text = label28.Text;




					label45.Text = textBox17.Text;
					label17.Text = label51.Text;
					label21.Text = label63.Text;

					label46.Text = textBox19.Text;
					label24.Text = label53.Text;
					label27.Text = label65.Text;

					label47.Text = textBox16.Text;
					label23.Text = label50.Text;
					label26.Text = label66.Text;

					label48.Text = textBox18.Text;
					label25.Text = label52.Text;
					label28.Text = label64.Text;

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

					number_group.Text = "3";

				}

			}

		}

		private void timer17_Tick(object sender, EventArgs e)
		{


			Timez += 0.001 * timer17.Interval;                   //timer на час кола зелена доріжка
			label27.Text = string.Format("{0:F3}", Timez);       //timer на час кола зелена доріжка

		}

		private void timer16_Tick(object sender, EventArgs e)
		{

			Timeg += 0.001 * timer16.Interval;                   //timer на час кола жовта доріжка
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

        private void button3_Click_1(object sender, EventArgs e)
        {
			label49.Visible = true;
			comboBox1.Visible = true;
			button5.Visible = true;
			button4.Visible = false;
			button3.Visible = false;
		}

        private void button5_Click(object sender, EventArgs e)
        {
			serialPort1.BaudRate = 9600;
			serialPort1.PortName = comboBox1.Text;
			button5.Visible = false;
			button1.Visible = true;
			comboBox1.Visible = false;
			label49.Visible = false;
			timer21.Enabled = true;
			button1.Focus();
			
		}

		private void timer18_Tick_1(object sender, EventArgs e)
		{


			





			//алгоритм сортування відставання до суперника


			if (Convert.ToInt32(label25.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) != Convert.ToInt32(label17.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) != Convert.ToInt32(label24.Text))


			{
				label8.Visible = true;
				panel6.Visible = true;
				panel7.Visible = true;
				panel8.Visible = true;
				panel9.Visible = true;
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
							panel5.Location = new Point(7, 294);
						}
						else
						{
							if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
							{
								panel5.Location = new Point(7, 294);
							}
							else
							{
								if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
								{
									panel5.Location = new Point(7, 294);
								}
								else
								{




									if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label23.Text))
									{
										panel5.Location = new Point(7, 389);
									}
									else
									{
										if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label24.Text))
										{
											panel5.Location = new Point(7, 389);
										}
										else
										{
											if (Convert.ToInt32(label25.Text) > Convert.ToInt32(label17.Text))
											{
												panel5.Location = new Point(7, 389);
											}
											else
											{

												if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
												{
													panel5.Location = new Point(7, 477);
												}
												else
												{
													if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text))
													{
														panel5.Location = new Point(7, 389);
													}
													else
													{
														if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
														{
															panel5.Location = new Point(7, 389);
														}
														else
														{
															if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
															{
																panel5.Location = new Point(7, 389);
															}
															else
															{
																if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label24.Text))
																{
																	panel5.Location = new Point(7, 294);

																}
																else
																{
																	if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label23.Text))
																	{
																		panel5.Location = new Point(7, 294);
																	}
																	else
																	{
																		if (Convert.ToInt32(label25.Text) < Convert.ToInt32(label17.Text))
																		{
																			panel5.Location = new Point(7, 294);
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
							panel4.Location = new Point(7, 294);
						}
						else
						{
							if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
							{
								panel4.Location = new Point(7, 294);
							}
							else
							{
								if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
								{
									panel4.Location = new Point(7, 294);
								}
								else
								{

									if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label25.Text))
									{
										panel4.Location = new Point(7, 389);
									}
									else
									{
										if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label24.Text))
										{
											panel4.Location = new Point(7, 389);
										}
										else
										{
											if (Convert.ToInt32(label23.Text) > Convert.ToInt32(label17.Text))
											{
												panel4.Location = new Point(7, 389);
											}
											else
											{


												if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
												{
													panel4.Location = new Point(7, 477);

												}
												else
												{
													if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text))
													{
														panel4.Location = new Point(7, 389);
													}
													else
													{
														if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
														{
															panel4.Location = new Point(7, 389);
														}
														else
														{
															if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text) && Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
															{
																panel4.Location = new Point(7, 389);
															}
															else
															{
																if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label24.Text))
																{
																	panel4.Location = new Point(7, 294);
																}
																else
																{
																	if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label17.Text))
																	{
																		panel4.Location = new Point(7, 294);
																	}
																	else
																	{
																		if (Convert.ToInt32(label23.Text) < Convert.ToInt32(label25.Text))
																		{
																			panel4.Location = new Point(7, 294);
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
							panel3.Location = new Point(7, 294);
						}
						else
						{
							if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label17.Text))
							{
								panel3.Location = new Point(7, 294);
							}
							else
							{
								if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) > Convert.ToInt32(label17.Text))
								{
									panel3.Location = new Point(7, 294);
								}
								else
								{


									if (Convert.ToInt32(label24.Text) > Convert.ToInt32(label25.Text))
									{
										panel3.Location = new Point(7, 389);


									}
									else
									{
										if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
										{
											panel3.Location = new Point(7, 477);
										}
										else
										{
											if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text))
											{
												panel3.Location = new Point(7, 389);
											}
											else
											{
												if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
												{
													panel3.Location = new Point(7, 389);
												}
												else
												{
													if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
													{
														panel3.Location = new Point(7, 389);
													}
													else
													{
														if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label23.Text))
														{
															panel3.Location = new Point(7, 294);
														}
														else
														{
															if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label17.Text))
															{
																panel3.Location = new Point(7, 294);
															}
															else
															{
																if (Convert.ToInt32(label24.Text) < Convert.ToInt32(label25.Text))
																{
																	panel3.Location = new Point(7, 294);
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
							panel1.Location = new Point(7, 294);
						}
						else
						{
							if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
							{
								panel1.Location = new Point(7, 294);
							}
							else
							{
								if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
								{
									panel1.Location = new Point(7, 294);
								}
								else
								{


									if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label25.Text))
									{
										panel1.Location = new Point(7, 389);
									}
									else
									{
										if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label24.Text))
										{
											panel1.Location = new Point(7, 389);
										}
										else
										{
											if (Convert.ToInt32(label17.Text) > Convert.ToInt32(label23.Text))
											{
												panel1.Location = new Point(7, 389);
											}
											else
											{



												if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
												{
													panel1.Location = new Point(7, 477);
												}
												else
												{
													if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text))
													{
														panel1.Location = new Point(7, 389);
													}
													else
													{
														if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
														{
															panel1.Location = new Point(7, 389);
														}
														else
														{
															if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text) && Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
															{
																panel1.Location = new Point(7, 389);
															}
															else
															{
																if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label23.Text))
																{
																	panel1.Location = new Point(7, 294);
																}
																else
																{
																	if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label25.Text))
																	{
																		panel1.Location = new Point(7, 294);
																	}
																	else
																	{
																		if (Convert.ToInt32(label17.Text) < Convert.ToInt32(label24.Text))
																		{
																			panel1.Location = new Point(7, 294);
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
			

		}

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label17_TextChanged(object sender, EventArgs e)
        {
			
        }

        private void button6_Click(object sender, EventArgs e)
        {
			if(number_group.Text == "0")	// кнопка пауза для 1 заїзду
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

			if (number_group.Text == "1")	// кнопка пауза для 2 заїзду
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

        private void button7_Click(object sender, EventArgs e)
        {

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

        private void button7_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Space)
			{
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
			if(e.KeyCode == Keys.Space)
            {
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
			if(e.KeyCode == Keys.Space)
            {
				timer1.Enabled = true;
				button1.Visible = false;
				button6.Visible = true;
				button6.Focus();
			}
        }

        private void timer20_Tick(object sender, EventArgs e)
        {
			serialPort1.Open();
			timer20.Enabled = false;
        }

       

        private void timer13_Tick(object sender, EventArgs e)
		{

			c++;                                            //добавляю кола 1 доріці
			label24.Text = Convert.ToString(c);

			if (Convert.ToDouble(label30.Text) < 1)         //обмеження по часу кола 1 секунда
			{
				c--;
				label24.Text = Convert.ToString(c);
			}

			timer13.Enabled = false;
		}

		private void timer14_Tick(object sender, EventArgs e)
		{

			d++;                                            //добавляю кола 4 доріці
			label25.Text = Convert.ToString(d);
			if (Convert.ToDouble(label39.Text) < 1)         //обмеження по часу кола 1 секунда
			{
				d--;
				label25.Text = Convert.ToString(d);
			}

			timer14.Enabled = false;
		}
			
		private void timer21_Tick(object sender, EventArgs e)
		{



			int n;







			if (label48.Text == "" && label15.Text == "номер заизду")
				{
				n = 39;
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
					//Convert.ToString(listBox1.Items.Count);
					
					timer21.Enabled = false;

				}

			if(Convert.ToInt32(label67.Text) != 0)
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
					panel3.Location = new Point(7, 294);
					panel4.Location = new Point(7, 389);
					panel5.Location = new Point(7, 477);

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
					label8.Visible = false;
					panel6.Visible = false;
					panel7.Visible = false;
					panel8.Visible = false;
					panel9.Visible = false;
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
					timetostart = 5;
					label13.Visible = false;
					timer21.Enabled = false;

                }
               
			}

			if (label67.Text == "0" && label13.Text == "<<Фініш!>>")
			{
				label13.Text = "Заїзди завершено!";
			}
		}
		

        private void timer15_Tick(object sender, EventArgs e)
		{


			Times += 0.001 * timer15.Interval;                   //timer на час кола синя доріжка
			label26.Text = string.Format("{0:F3}", Times);       //timer на час кола синя доріжка

		}

		private void timer11_Tick(object sender, EventArgs e)
		{


			Time += 0.001 * timer11.Interval;                   //timer на час кола
			label21.Text = string.Format("{0:F3}", Time);       //timer на час кола 





		}



		private void label16_Click(object sender, EventArgs e)
		{

		}

		private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			textBox15.AppendText(serialPort1.ReadLine());

		}


		int n;

		private void button2_Click(object sender, EventArgs e)
		{
			serialPort1.BaudRate = 9600;
			serialPort1.PortName = comboBox1.Text;
			button2.Visible = false;
			button1.Visible = true;
			comboBox1.Visible = false;
			label49.Visible = false;
			timer21.Enabled = true;


			// цикл для підтягування спортсменів за результатами лаптайму

			

			
			button4.Visible = false;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			timer21.Enabled = true;
		}

		private void timer10_Tick(object sender, EventArgs e)
		{

			i++;                                            //добавляю кола 1 доріці
			label17.Text = Convert.ToString(i);
			if (Convert.ToDouble(label22.Text) < 1)			//обмеження по часу кола 1 секунда
            {
				i--;
				label17.Text = Convert.ToString(i); 
			}
			//textBox15.Text = "0";
			timer10.Enabled = false;
		}

		private void timer7_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

			button6.Enabled = false;

			

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

			if (secs == 0 && mins == 0)
			{
				timer7.Enabled = false;
				timer8.Enabled = true;

				Time = Convert.ToDouble(label63.Text);
				Timeg = Convert.ToDouble(label64.Text);
				Timez = Convert.ToDouble(label65.Text);
				Times = Convert.ToDouble(label66.Text);


				sec = 1;
				min = Convert.ToInt32(textBox13.Text);
				label4.Text = "00:00";
				label13.Text = "<<Гонка!>>";
				label15.Text = "4/4";

				timer17.Enabled = true;
				timer11.Enabled = true;
				timer15.Enabled = true;
				timer16.Enabled = true;

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

					timer8.Enabled = false;
					label4.Text = "00:00";
					label13.Text = "<<Фініш!>>";

					label8.Visible = false;
					panel6.Visible = false;
					panel7.Visible = false;
					panel8.Visible = false;
					panel9.Visible = false;

					number_group.Text = "0";
					button8.Visible = true;
					serialPort1.Close();
					//вивід результату в таблицю
					dataGridView1.Visible = true;

					dataGridView1.Rows.Add("Червона",label45.Text, label17.Text);
					
					dataGridView1.Rows.Add("Зелена",label46.Text, label24.Text);
					
					dataGridView1.Rows.Add("Синя",label47.Text, label23.Text);
					
					dataGridView1.Rows.Add("Жовта",label48.Text, label25.Text);
					//сортування результату гонки в таблиці

					
					dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);
					
					

				}


			}


		}

		private void timer9_Tick(object sender, EventArgs e)
		{
			timer19.Enabled = true;





			if (Convert.ToInt32(textBox15.Text) == 01111) // зелена + Синя+ Жовта+Червона доріжка
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


			}

			if (Convert.ToInt32(textBox15.Text) == 01110) // зелена + Синя+ Жовта доріжка
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


			}


			if (Convert.ToInt32(textBox15.Text) == 01100)
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
			}



			if (Convert.ToInt32(textBox15.Text) == 01011)
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
			}

			if (Convert.ToInt32(textBox15.Text) == 01011)
			{
				i = Convert.ToInt32(label17.Text);          //червона  + Зелена+ Синя доріжка
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

				if (Convert.ToDouble(label16.Text) > Convert.ToDouble(label18.Text))
				{
					label16.Text = label18.Text;

				}
			}

			if (Convert.ToInt32(textBox15.Text) == 01010) // зелена + Синя доріжка
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


			}



			if (Convert.ToInt32(textBox15.Text) == 01001) // жовта + Синя доріжка
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


			}




			if (Convert.ToInt32(textBox15.Text) == 01000)
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
			}




			if (Convert.ToInt32(textBox15.Text) == 0111)
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
			}




			if (Convert.ToInt32(textBox15.Text) == 0110)
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
			}






			if (Convert.ToInt32(textBox15.Text) == 0101) // жовта + зелена
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


			}

			if (Convert.ToInt32(textBox15.Text) == 01)
			{
				i = Convert.ToInt32(label17.Text);          //червона доріжка
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
			}

				

					if (Convert.ToInt32(textBox15.Text) == 011) // синя доріжка
					{
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


			}


			if (Convert.ToInt32(textBox15.Text) == 010) // зелена доріжка
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
				textBox15.Text = "0";

				if (Convert.ToDouble(label42.Text) > Convert.ToDouble(label29.Text))
				{
					label42.Text = label29.Text;

				}


			}

			if (Convert.ToInt32(textBox15.Text) == 0100) // жовта доріжка
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
				textBox15.Text = "0";

				if (Convert.ToDouble(label44.Text) > Convert.ToDouble(label38.Text))
				{
					label44.Text = label38.Text;

				}


			}


			





		}
		private void timer12_Tick(object sender, EventArgs e)
		{

			b++;                                            //добавляю кола 1 доріці
			label23.Text = Convert.ToString(b);


			if (Convert.ToDouble(label34.Text) < 1)         //обмеження по часу кола 1 секунда
			{
				b--;
				label23.Text = Convert.ToString(b);
			}

			timer12.Enabled = false;
		}

	}
}