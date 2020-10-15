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
		public Form3()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{


			timer1.Enabled = true;
			button1.Visible = false;
		}

		int mins, secs, min, sec, i, msecs, mmsecs, b, c, d;




		int timetostart = 5; // значення стартового таймера


		double Time, Times, Timez, Timeg;//timer на час кола
		private void timer1_Tick(object sender, EventArgs e)
		{

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
					serialPort1.Open();
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


				}
			}
		}



		private void timer3_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

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
				timer3.Enabled = false;
				timer4.Enabled = true;
				sec = 1;
				min = Convert.ToInt32(textBox13.Text);
				label4.Text = "00:00";
				label13.Text = "<<Гонка!>>";
				label15.Text = "2/4";
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


				}
			}
		}



		private void timer5_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

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
				sec = 1;
				min = Convert.ToInt32(textBox13.Text);
				label4.Text = "00:00";
				label13.Text = "<<Гонка!>>";
				label15.Text = "3/4";

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

		private void timer13_Tick(object sender, EventArgs e)
		{

			c++;                                            //добавляю кола 1 доріці
			label24.Text = Convert.ToString(c);


			timer13.Enabled = false;
		}

		private void timer14_Tick(object sender, EventArgs e)
		{

			d++;                                            //добавляю кола 4 доріці
			label25.Text = Convert.ToString(d);


			timer14.Enabled = false;
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

		private void button2_Click(object sender, EventArgs e)
		{
			serialPort1.BaudRate = 9600;
			serialPort1.PortName = comboBox1.Text;
			button2.Visible = false;
			button1.Visible = true;
			comboBox1.Visible = false;
			label49.Visible = false;

			// цикл для підтягування спортсменів за результатами лаптайму

			int n = listBox1.Items.Count - 1;

			label48.Text = Convert.ToString(listBox1.Items[n]);
			if (label48.Text == "")
			{
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
				
			}

			
			button4.Visible = false;
		}

		private void timer10_Tick(object sender, EventArgs e)
		{

			i++;                                            //добавляю кола 1 доріці
			label17.Text = Convert.ToString(i);

			//textBox15.Text = "0";
			timer10.Enabled = false;
		}

		private void timer7_Tick(object sender, EventArgs e)
		{
			label4.Text = Convert.ToString(mins) + ":" + Convert.ToString(secs);
			secs--;

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
				sec = 1;
				min = Convert.ToInt32(textBox13.Text);
				label4.Text = "00:00";
				label13.Text = "<<Гонка!>>";
				label15.Text = "4/4";



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


				}


			}


		}

		private void timer9_Tick(object sender, EventArgs e)
		{
			
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

			
			timer12.Enabled = false;
		}

	}
}