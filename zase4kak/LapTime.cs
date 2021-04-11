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
    public partial class Form9 : Form
    {
        int min, sec = 1, pmin, psec, laptime, number_pilot = 0;

        double[] arr = new double[40];   //масив кращого часу
        char[] name = new char[40];
        SoundPlayer stopsound = new SoundPlayer();
        SoundPlayer startsound = new SoundPlayer();
        SoundPlayer finishsound = new SoundPlayer();
        SoundPlayer timetostart = new SoundPlayer();
        SoundPlayer kvalificatsia = new SoundPlayer();
        SoundPlayer sekyd = new SoundPlayer();
        SoundPlayer zaminapilota = new SoundPlayer();
        SoundPlayer record = new SoundPlayer();
        SoundPlayer start_to_pause = new SoundPlayer();
        string[,] list = new string[100, 4];
        int n;
        public Form9()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

       
        int number, i = 1, timer_svitofor = 0, timer_svitofor2 = 0;

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }



       





        private void button3_Click_1(object sender, EventArgs e)
        {






          if (label1.Text == "PR24")
            {
                label10.Text = Settings.Default.best_time_name1pr24;
                label11.Text = Settings.Default.best_time_name2pr24;
                label12.Text = Settings.Default.best_time_name3pr24;
                label13.Text = Settings.Default.best_time_result1Pr24;
                label14.Text = Settings.Default.best_time_result2Pr24;
                label15.Text = Settings.Default.best_time_result3Pr24;
            }
            else
            {
                if (label1.Text == "Ретро")
                {
                    label10.Text = Settings.Default.best_time_name1retro;
                    label11.Text = Settings.Default.best_time_name2retro;
                    label12.Text = Settings.Default.best_time_name3retro;
                    label13.Text = Settings.Default.best_time_result1retro;
                    label14.Text = Settings.Default.best_time_result2retro;
                    label15.Text = Settings.Default.best_time_result3retro;
                }
                else
                {
                    if (label1.Text == "Вантажівка")
                    {
                        label10.Text = Settings.Default.best_time_name1vantagivka;
                        label11.Text = Settings.Default.best_time_name2vantagivka;
                        label12.Text = Settings.Default.best_time_name3vantagivka;
                        label13.Text = Settings.Default.best_time_result1vantagivka;
                        label14.Text = Settings.Default.best_time_result2vantagivka;
                        label15.Text = Settings.Default.best_time_result3vantagivka;
                    }
                    else
                    {
                        if (label1.Text == "ES-стандарт")
                        {
                            label10.Text = Settings.Default.best_time_name1Es_s;
                            label11.Text = Settings.Default.best_time_name2Es_s;
                            label12.Text = Settings.Default.best_time_name3Es_s;
                            label13.Text = Settings.Default.best_time_result1Es_s;
                            label14.Text = Settings.Default.best_time_result2Es_s;
                            label15.Text = Settings.Default.best_time_result3Es_s;
                        }
                        else
                        {
                            if (label1.Text == "G-33")
                            {
                                label10.Text = Settings.Default.best_time_name1g33;
                                label11.Text = Settings.Default.best_time_name2g33;
                                label12.Text = Settings.Default.best_time_name3g33;
                                label13.Text = Settings.Default.best_time_result1g33;
                                label14.Text = Settings.Default.best_time_result2g33;
                                label15.Text = Settings.Default.best_time_result3g33;
                            }
                            else
                            {
                                if (label1.Text == "F1-24")
                                {
                                    label10.Text = Settings.Default.best_time_name1f124;
                                    label11.Text = Settings.Default.best_time_name2f124;
                                    label12.Text = Settings.Default.best_time_name3f124;
                                    label13.Text = Settings.Default.best_time_result1f124;
                                    label14.Text = Settings.Default.best_time_result2f124;
                                    label15.Text = Settings.Default.best_time_result3f124;
                                }
                                else
                                {
                                    if (label1.Text == "G12")
                                    {
                                        label10.Text = Settings.Default.best_time_name1g12;
                                        label11.Text = Settings.Default.best_time_name2g12;
                                        label12.Text = Settings.Default.best_time_name3g12;
                                        label13.Text = Settings.Default.best_time_result1g12;
                                        label14.Text = Settings.Default.best_time_result2g12;
                                        label15.Text = Settings.Default.best_time_result3g12;
                                    }
                                    else
                                    {
                                        if (label1.Text == "ES-24")
                                        {
                                            label10.Text = Settings.Default.best_time_name1es24;
                                            label11.Text = Settings.Default.best_time_name2es24;
                                            label12.Text = Settings.Default.best_time_name3es24;
                                            label13.Text = Settings.Default.best_time_result1es24;
                                            label14.Text = Settings.Default.best_time_result2es24;
                                            label15.Text = Settings.Default.best_time_result3es24;
                                        }
                                        else
                                        {
                                            if (label1.Text == "ES-32")
                                            {
                                                label10.Text = Settings.Default.best_time_name1es32;
                                                label11.Text = Settings.Default.best_time_name2es32;
                                                label12.Text = Settings.Default.best_time_name3es32;
                                                label13.Text = Settings.Default.best_time_result1es32;
                                                label14.Text = Settings.Default.best_time_result2es32;
                                                label15.Text = Settings.Default.best_time_result3es32;
                                            }
                                            else
                                            {
                                                if (label1.Text == "F1")
                                                {
                                                    label10.Text = Settings.Default.best_time_name1f1;
                                                    label11.Text = Settings.Default.best_time_name2f1;
                                                    label12.Text = Settings.Default.best_time_name3f1;
                                                    label13.Text = Settings.Default.best_time_result1f1;
                                                    label14.Text = Settings.Default.best_time_result2f1;
                                                    label15.Text = Settings.Default.best_time_result3f1;
                                                }
                                                else
                                                {
                                                    if (label1.Text == "G15")
                                                    {
                                                        label10.Text = Settings.Default.best_time_name1g15;
                                                        label11.Text = Settings.Default.best_time_name2g15;
                                                        label12.Text = Settings.Default.best_time_name3g15;
                                                        label13.Text = Settings.Default.best_time_result1g15;
                                                        label14.Text = Settings.Default.best_time_result2g15;
                                                        label15.Text = Settings.Default.best_time_result3g15;
                                                    }
                                                    else
                                                    {
                                                        if (label1.Text == "Open-G12")
                                                        {
                                                            label10.Text = Settings.Default.best_time_name1g12open;
                                                            label11.Text = Settings.Default.best_time_name2g12open;
                                                            label12.Text = Settings.Default.best_time_name3g12open;
                                                            label13.Text = Settings.Default.best_time_result1g12open;
                                                            label14.Text = Settings.Default.best_time_result2g12open;
                                                            label15.Text = Settings.Default.best_time_result3g12open;
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









            button3.Visible = false;
            panel7.Visible = true;

            label9.Text = label1.Text;
            int n = ExportExcel();
            listBox1.Items.Clear();
            string s;
            for (int i = 1; i < n; i++) // по всем строкам
            {
                s = "";
                for (int j = 0; j < 2; j++) //по всем колонкам
                    s += list[i, j];
                listBox1.Items.Add(s);
             

            }
            n = listBox1.Items.Count;
            
            label56.Text = Convert.ToString(listBox1.Items[n - 1]);
             
             textBox65.Text = Convert.ToString(listBox1.Items[n - 2]);
            n--;
            label104.Text = Convert.ToString(n);
            button1.Visible = true;
            button1.Focus();
            listBox1.Visible = true;
            label3.Visible = true;


        }





        private int ExportExcel()
        {

            // Выбрать путь и имя файла в диалоговом окне
            OpenFileDialog ofd = new OpenFileDialog();
            // Задаем расширение имени файла по умолчанию (открывается папка с программой)
            ofd.DefaultExt = "*.xls;*.xlsx";
            // Задаем строку фильтра имен файлов, которая определяет варианты
            ofd.Filter = "файл Excel (Spisok.xlsx)|*.xlsx";
            // Задаем заголовок диалогового окна
            ofd.Title = "Виберіть файл Учасники змагань";
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
            for (int j = 1; j < 4; j++) //по всем колонкам
                for (int i = 1; i < lastRow; i++) // по всем строкам
                    list[i, j] = ObjWorkSheet.Cells[i + 1, j + 1].Text.ToString(); //считываем данные
            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            ObjWorkExcel.Quit(); // выйти из Excel
            GC.Collect(); // убрать за собой
            return lastRow;



        }





        void SaveTable_laptime(DataGridView Whats_save_laptime)
        {





            //string path = System.IO.Directory.GetCurrentDirectory();// + @"\" + "Учасники змагання.xlsx";// запис в ексель результату гонки

            Microsoft.Office.Interop.Excel.Application Excel_Lapp_time = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook_laptime;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkShee_laptimet;
            //Книга.
            ExcelWorkBook_laptime = Excel_Lapp_time.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkShee_laptimet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook_laptime.Worksheets.get_Item(1);



            for (int j = 0; j < dataGridView2.ColumnCount; j++)
                Excel_Lapp_time.Cells[1, j + 1] = dataGridView2.Columns[j].HeaderText;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    Excel_Lapp_time.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
                }
            }
            // Excel_Lapp.Visible = true;
            Excel_Lapp_time.UserControl = true;
            Excel_Lapp_time.AlertBeforeOverwriting = true;
          //  ExcelWorkBook_laptime.SaveAs(path);
            Excel_Lapp_time.Visible = true;
            
           // ExcelWorkBook.Close();

           // GC.Collect();
        }






        void SaveTable(DataGridView Whats_save)
        {



           

            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Учасники змагання.xlsx";// запис в ексель результату гонки

            Microsoft.Office.Interop.Excel.Application Excel_Lapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = Excel_Lapp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            

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
            Excel_Lapp.AlertBeforeOverwriting = false;
            ExcelWorkBook.SaveAs(path);
            ExcelWorkBook.Close();

                  GC.Collect();
        }

       

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

   
              
            
        }

        private void dataGridView1_RowPrePaint_1(object sender, DataGridViewRowPrePaintEventArgs e)
        {
           
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            textBox108.AppendText(serialPort1.ReadLine());
            button5.Focus();
            Thread.Sleep(100);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            comboBox1.Text = Settings.Default.lapTIme_comPort;
            timer4.Enabled = false;
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            i++;                                            //добавляю кола 1 доріці
            label100.Text = Convert.ToString(i);
            timer10.Enabled = false;
        }

        private void timer9_Tick(object sender, EventArgs e)
        {

            if(timer7.Enabled == false && timer_svitofor != 0)
            {
                timer7.Enabled = true;
            }
            if (timer8.Enabled == false && timer_svitofor2 != 0)
            {
                timer8.Enabled = true;
            }

            if (Convert.ToInt32(textBox108.Text) != 0)
            {
                i = Convert.ToInt32(label100.Text);          //червона доріжка
                timer10.Enabled = true;
                timer11.Enabled = false;
                label103.Text = label102.Text;
                Time = 0;
                timer11.Enabled = true;
                
                label54.Text = label53.Text;
                label53.Text = label52.Text;
                label52.Text = label51.Text;
                label51.Text = label103.Text;
                label100.Text = Convert.ToString(i);
                textBox108.Text = "0";

                if (Convert.ToDouble(label103.Text) != 0)
                {


                    if (Convert.ToDouble(label55.Text) > Convert.ToDouble(label103.Text))
                    {
                        panel5.BackColor = Color.LawnGreen;
                        label55.BackColor = Color.LawnGreen;
                        timer5.Enabled = true;
                        label55.Text = label103.Text;
                        record.Play();
                    }

                }
            }
        
    }
        double Time;
        private void timer11_Tick(object sender, EventArgs e)
        {
            Time += 0.0003 * 53;                    //timer на час кола
            label102.Text = string.Format("{0:F4}", Time);       //timer на час кола 
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            zaminapilota.SoundLocation = "music/zaminapilota.wav";
            zaminapilota.Load();
            sekyd.SoundLocation = "music/15secynd.wav";
            sekyd.Load();
            kvalificatsia.SoundLocation = "music/kvalifikatsia.wav";
            kvalificatsia.Load();
            timetostart.SoundLocation = "music/81980c1a7dcb7cd.wav";
            timetostart.Load();
            stopsound.SoundLocation = "music/noty-do.wav";
            stopsound.Load();
            startsound.SoundLocation = "music/re.wav";
            startsound.Load();
            finishsound.SoundLocation = "music/aplodismenty_s_krikami_bravo.wav";
            finishsound.Load();
            record.SoundLocation = "music/00508.wav";
            record.Load();
            start_to_pause.SoundLocation = "music/start_to_stop.wav";
            start_to_pause.Load();


            String[] strPortName = SerialPort.GetPortNames();
            foreach (string n in strPortName)
            {
                comboBox1.Items.Add(n);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label50.Text == "0:17")
            {
                
                sekyd.Play();
            }


            if (label50.Text == "0:4")
            {
                panel9.BackColor = Color.Red;
                timer7.Enabled = true;
                timetostart.Play();
            }

            if (label56.Text == "")
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                label101.Text = "<<Кваліфікацію завершено!>>";
                serialPort1.Close();
                kvalificatsia.Play();
                SaveTable_laptime(dataGridView2);

            }



            psec--;
            label50.Text = Convert.ToInt32(pmin) + ":" + Convert.ToInt32(psec);                         // таймер для переходу на лайп таймі
            if (psec > 60)
            {
                pmin++;
                psec = psec - 60;
            }

            if (psec == 0)

            {
                pmin--;
                psec = 60;

            }

            if (pmin == -1 || psec == 0)
            {
                serialPort1.Open();
               serialPort1.WriteLine("4");
                timer2.Enabled = false;
                min = Convert.ToInt32(textBox106.Text);
                sec = 1;
                label101.Text = "<<Кваліфікація>>";
                timer1.Enabled = true;
                label55.Text = "999";
                label103.Text = "00,00";
                label51.Text = "00,00";
                label52.Text = "00,00";
                label53.Text = "00,00";
                label54.Text = "00,00";
                label100.Text = "0";

                timer11.Enabled = false;
                Time = 0;
                label102.Text = "0";


                button5.Visible = true;
                button5.Enabled = true;
                button5.Focus();
            }

        
    }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            panel5.BackColor = Color.WhiteSmoke;
            label55.BackColor = Color.WhiteSmoke;


            ////алгоритм кращого результату
            //if (Convert.ToDouble(label55.Text) < Convert.ToDouble(label15.Text) && Convert.ToDouble(label55.Text) > Convert.ToDouble(label14.Text) && Convert.ToDouble(label55.Text) > Convert.ToDouble(label13.Text))
            //{

                

            //    label15.Text = label55.Text;
            //    label12.Text = label56.Text;


            //}
            //else
            //{
            //    if (Convert.ToDouble(label55.Text) < Convert.ToDouble(label15.Text) && Convert.ToDouble(label55.Text) < Convert.ToDouble(label14.Text) && Convert.ToDouble(label55.Text) > Convert.ToDouble(label13.Text))
            //    {
            //        label15.Text = label14.Text;
            //        label12.Text = label11.Text;

            //        label14.Text = label55.Text;
            //        label11.Text = label56.Text;
            //    }
            //    else
            //    {
            //        if (Convert.ToDouble(label55.Text) < Convert.ToDouble(label15.Text) && Convert.ToDouble(label55.Text) < Convert.ToDouble(label14.Text) && Convert.ToDouble(label55.Text) < Convert.ToDouble(label13.Text))
            //        {
            //            label15.Text = label14.Text;
            //            label12.Text = label11.Text;


            //            label14.Text = label13.Text;
            //            label11.Text = label10.Text;

            //            label13.Text = label55.Text;
            //            label10.Text = label56.Text;

            //        }
            //    }

            //}

            ////підтягування кращого часу

            //if(label1.Text == "PR24")
            //{
            //    Settings.Default.best_time_name1pr24 = label10.Text;
            //    Settings.Default.best_time_name2pr24 = label11.Text;
            //    Settings.Default.best_time_name3pr24 = label12.Text;
            //    Settings.Default.best_time_result1Pr24 = label13.Text;
            //    Settings.Default.best_time_result2Pr24 = label14.Text;
            //    Settings.Default.best_time_result3Pr24 = label15.Text;
            //    Settings.Default.Save();


            //}
            //else
            //{
            //    if (label1.Text == "Ретро")
            //    {
            //        Settings.Default.best_time_name1retro = label10.Text;
            //        Settings.Default.best_time_name2retro = label11.Text;
            //        Settings.Default.best_time_name3retro = label12.Text;
            //        Settings.Default.best_time_result1retro = label13.Text;
            //        Settings.Default.best_time_result2retro = label14.Text;
            //        Settings.Default.best_time_result3retro = label15.Text;
            //        Settings.Default.Save();
            //    }
            //    else
            //    {
            //        if (label1.Text == "Вантажівка")
            //        {
            //            Settings.Default.best_time_name1vantagivka = label10.Text;
            //            Settings.Default.best_time_name2vantagivka = label11.Text;
            //            Settings.Default.best_time_name3vantagivka = label12.Text;
            //            Settings.Default.best_time_result1vantagivka = label13.Text;
            //            Settings.Default.best_time_result2vantagivka = label14.Text;
            //            Settings.Default.best_time_result3vantagivka = label15.Text;
            //            Settings.Default.Save();
            //        }
            //        else
            //        {
            //            if (label1.Text == "ES-стандарт")
            //            {
            //                Settings.Default.best_time_name1Es_s = label10.Text;
            //                Settings.Default.best_time_name2Es_s = label11.Text;
            //                Settings.Default.best_time_name3Es_s = label12.Text;
            //                Settings.Default.best_time_result1Es_s = label13.Text;
            //                Settings.Default.best_time_result2Es_s = label14.Text;
            //                Settings.Default.best_time_result3Es_s = label15.Text;
            //                Settings.Default.Save();
            //            }
            //            else
            //            {
            //                if (label1.Text == "G-33")
            //                {
            //                    Settings.Default.best_time_name1g33 = label10.Text;
            //                    Settings.Default.best_time_name2g33 = label11.Text;
            //                    Settings.Default.best_time_name3g33 = label12.Text;
            //                    Settings.Default.best_time_result1g33 = label13.Text;
            //                    Settings.Default.best_time_result2g33 = label14.Text;
            //                    Settings.Default.best_time_result3g33 = label15.Text;
            //                    Settings.Default.Save();
            //                }
            //                else
            //                {
            //                    if (label1.Text == "F1-24")
            //                    {
            //                        Settings.Default.best_time_name1f124 = label10.Text;
            //                        Settings.Default.best_time_name2f124 = label11.Text;
            //                        Settings.Default.best_time_name3f124 = label12.Text;
            //                        Settings.Default.best_time_result1f124 = label13.Text;
            //                        Settings.Default.best_time_result2f124 = label14.Text;
            //                        Settings.Default.best_time_result3f124 = label15.Text;
            //                        Settings.Default.Save();
            //                    }
            //                    else
            //                    {
            //                        if (label1.Text == "G12")
            //                        {
            //                            Settings.Default.best_time_name1g12 = label10.Text;
            //                            Settings.Default.best_time_name2g12 = label11.Text;
            //                            Settings.Default.best_time_name3g12 = label12.Text;
            //                            Settings.Default.best_time_result1g12 = label13.Text;
            //                            Settings.Default.best_time_result2g12 = label14.Text;
            //                            Settings.Default.best_time_result3g12 = label15.Text;
            //                            Settings.Default.Save();
            //                        }
            //                        else
            //                        {
            //                            if (label1.Text == "ES-24")
            //                            {
            //                                Settings.Default.best_time_name1es24 = label10.Text;
            //                                Settings.Default.best_time_name2es24 = label11.Text;
            //                                Settings.Default.best_time_name3es24 = label12.Text;
            //                                Settings.Default.best_time_result1es24 = label13.Text;
            //                                Settings.Default.best_time_result2es24 = label14.Text;
            //                                Settings.Default.best_time_result3es24 = label15.Text;
            //                                Settings.Default.Save();
            //                            }
            //                            else
            //                            {
            //                                if (label1.Text == "ES-32")
            //                                {
            //                                    Settings.Default.best_time_name1es32 = label10.Text;
            //                                    Settings.Default.best_time_name2es32 = label11.Text;
            //                                    Settings.Default.best_time_name3es32 = label12.Text;
            //                                    Settings.Default.best_time_result1es32 = label13.Text;
            //                                    Settings.Default.best_time_result2es32 = label14.Text;
            //                                    Settings.Default.best_time_result3es32 = label15.Text;
            //                                    Settings.Default.Save();
            //                                }
            //                                else
            //                                {
            //                                    if (label1.Text == "F1")
            //                                    {
            //                                        Settings.Default.best_time_name1f1 = label10.Text;
            //                                        Settings.Default.best_time_name2f1 = label11.Text;
            //                                        Settings.Default.best_time_name3f1 = label12.Text;
            //                                        Settings.Default.best_time_result1f1 = label13.Text;
            //                                        Settings.Default.best_time_result2f1 = label14.Text;
            //                                        Settings.Default.best_time_result3f1 = label15.Text;
            //                                        Settings.Default.Save();
            //                                    }
            //                                    else
            //                                    {
            //                                        if (label1.Text == "G15")
            //                                        {
            //                                            Settings.Default.best_time_name1g15 = label10.Text;
            //                                            Settings.Default.best_time_name2g15 = label11.Text;
            //                                            Settings.Default.best_time_name3g15 = label12.Text;
            //                                            Settings.Default.best_time_result1g15 = label13.Text;
            //                                            Settings.Default.best_time_result2g15 = label14.Text;
            //                                            Settings.Default.best_time_result3g15 = label15.Text;
            //                                            Settings.Default.Save();
            //                                        }
            //                                        else
            //                                        {
            //                                            if (label1.Text == "Open-G12")
            //                                            {
            //                                                Settings.Default.best_time_name1g12open = label10.Text;
            //                                                Settings.Default.best_time_name2g12open = label11.Text;
            //                                                Settings.Default.best_time_name3g12open = label12.Text;
            //                                                Settings.Default.best_time_result1g12open = label13.Text;
            //                                                Settings.Default.best_time_result2g12open = label14.Text;
            //                                                Settings.Default.best_time_result3g12open = label15.Text;
            //                                                Settings.Default.Save();
            //                                            }
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}


            timer5.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings.Default.lapTIme_comPort = comboBox1.Text;
            Settings.Default.Save();
            label2.Visible = false;
            dataGridView1.Visible = true;
            button2.Visible = true;
           
            button10.Visible = true;
            button1.Focus();
            //serialPort1.BaudRate = 9600;
            serialPort1.PortName = comboBox1.Text;
            serialPort1.Open();
            serialPort1.WriteLine("3");
            serialPort1.Close();
            button4.Visible = false;
            button9.Visible = true;
            comboBox1.Visible = false;
            label4.Visible = true;
          


            
         
          
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            label50.Text = "3";
            panel9.BackColor = Color.Red;
            timer7.Enabled = true;
            timetostart.Play();
            
            //Thread.Sleep(3000);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            serialPort1.WriteLine("4");
            startsound.Play();
            timer1.Enabled = true;
            button6.Enabled = false;
            button6.Visible = false;
            button5.Enabled = true;
            button5.Visible = true;
            button5.Focus();
            timer11.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer_svitofor2 = 5;
            timer8.Enabled = true;
            start_to_pause.Play();
            panel9.BackColor = Color.Red;
            
            
           
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            label101.Text = "<<Пауза>>";
            serialPort1.WriteLine("3");
            
            panel11.BackColor = Color.Orange;
            panel9.BackColor = Color.Orange;
            panel10.BackColor = Color.Orange;
            panel12.BackColor = Color.Orange;
            stopsound.Play();
            timer1.Enabled = false;
            button5.Enabled = false;
            button5.Visible = false;
            button6.Enabled = true;
            button6.Visible = true;
            button6.Focus();
            timer11.Enabled = false;
           serialPort1.Close();

          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (label101.Text == "<<Кваліфікація>>")
            {
                sec = 3;
            }

            if (label101.Text == "<<Заміна пілота>>")
            {
                psec = 3;
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }

       

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button2.Visible = false;
            button3.Enabled = true;
            button4.Visible = false;
            button10.Visible = false;
            label4.Visible = false;
            button3.Focus();
            button3.Visible = true;
        }

        private void timer7_Tick(object sender, EventArgs e)
        {

           
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            button7.Visible = false;
            button8.Visible = true;
            textBox1.Visible = true;
            label16.Visible = true;
          
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "alabamba")
            {
                label16.Text = "Обнулено!";
                label13.Text = "999";
                label14.Text = "999";
                label15.Text = "999";
                label10.Text = "Рекорд1";
                label11.Text = "Рекорд2";
                label12.Text = "Рекорд3";
                textBox1.Text = "";
            }
            else
            {
                label16.Text = "не вірний пароль!";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button7.Visible = true;
            label16.Visible = false;
            textBox1.Visible = false;
        }

        private void database1DataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void database1DataSetBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void form4BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            timer_svitofor2 = timer_svitofor2 + 1;
            if (timer_svitofor2 == 6)
            {
                
                panel10.BackColor = Color.Yellow;
                timer8.Enabled = false;

            }
            else
            {
                if (timer_svitofor2 == 7)
                {
                    panel11.BackColor = Color.Yellow;
                    timer8.Enabled = false;

                }
                else
                {
                    if (timer_svitofor2 == 8)
                    {
                        panel9.BackColor = Color.Lime;
                        panel10.BackColor = Color.Lime;
                        panel11.BackColor = Color.Lime;
                        panel12.BackColor = Color.Lime;
                        
                        serialPort1.WriteLine("4");

                        label101.Text = "<<Кваліфікація>>";
                        timer1.Enabled = true;
                        button6.Enabled = false;
                        button6.Visible = false;
                        button5.Enabled = true;
                        button5.Visible = true;
                        button5.Focus();
                        timer11.Enabled = true;
                        timer_svitofor2 = 0;
                        timer8.Enabled = false;

                    }
                }
            }
           
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                 "Вийти з програми?",
                 "Завершення роботи",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
                ) ;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer7_Tick_1(object sender, EventArgs e)
        {
            timer_svitofor = timer_svitofor + 1;

            int timer_tostart = 0;


            if (timer_svitofor == 5)
            {

            }
            else
            {
                if (timer_svitofor == 1)
                {
                    panel10.BackColor = Color.Yellow;
                    label50.Text = "2";
                    timer7.Enabled = false;

                }
                else
                {
                    if (timer_svitofor == 2)
                    {
                        panel11.BackColor = Color.Yellow;
                        label50.Text = "1";
                        timer7.Enabled = false;
                    }
                    else
                    {
                        if (timer_svitofor == 3)
                        {
                            panel11.BackColor = Color.Lime;
                            panel9.BackColor = Color.Lime;
                            panel10.BackColor = Color.Lime;
                            panel12.BackColor = Color.Lime;
                            timer_svitofor = 0;
                            label50.Text = "0";


                            timer1.Enabled = true;

                            min = Convert.ToInt32(textBox106.Text);
                            button1.Visible = false;
                            label101.Visible = true;
                         
                            button5.Visible = true;
                            button1.Enabled = false;
                            button5.Focus();
                            button6.Focus();
                            serialPort1.WriteLine("4");
                            timer7.Enabled = false;

                        }
                    }
                }
            }
           
        }
            
        

        private void timer6_Tick(object sender, EventArgs e)
        {
            dataGridView2.Sort(dataGridViewTextBoxColumn2, ListSortDirection.Descending);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           
        }

        private void timer21_Tick(object sender, EventArgs e)
        {
            


          
               
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button2.Visible = false;
            button3.Enabled = true;
            button4.Visible = false;
            button10.Visible = false;
            label4.Visible = false;
            button3.Focus();
            button3.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            

            sec--;                                                                                          //таймер для лаптайму
            label50.Text = Convert.ToInt32(min) + ":" + Convert.ToInt32(sec);                                 //таймер для лаптайму
            if (sec == 0)
            {
                sec = 60;
                min--;
            }

            if (min == -1 || sec == 0)
            {
                serialPort1.WriteLine("3");

                //алгоритм кращого результату
                if (Convert.ToDouble(label55.Text) < Convert.ToDouble(label15.Text) && Convert.ToDouble(label55.Text) > Convert.ToDouble(label14.Text) && Convert.ToDouble(label55.Text) > Convert.ToDouble(label13.Text))
                {



                    label15.Text = label55.Text;
                    label12.Text = label56.Text;


                }
                else
                {
                    if (Convert.ToDouble(label55.Text) < Convert.ToDouble(label15.Text) && Convert.ToDouble(label55.Text) < Convert.ToDouble(label14.Text) && Convert.ToDouble(label55.Text) > Convert.ToDouble(label13.Text))
                    {
                        label15.Text = label14.Text;
                        label12.Text = label11.Text;

                        label14.Text = label55.Text;
                        label11.Text = label56.Text;
                    }
                    else
                    {
                        if (Convert.ToDouble(label55.Text) < Convert.ToDouble(label15.Text) && Convert.ToDouble(label55.Text) < Convert.ToDouble(label14.Text) && Convert.ToDouble(label55.Text) < Convert.ToDouble(label13.Text))
                        {
                            label15.Text = label14.Text;
                            label12.Text = label11.Text;


                            label14.Text = label13.Text;
                            label11.Text = label10.Text;

                            label13.Text = label55.Text;
                            label10.Text = label56.Text;

                        }
                    }

                }

                //підтягування кращого часу

                if (label1.Text == "PR24")
                {
                    Settings.Default.best_time_name1pr24 = label10.Text;
                    Settings.Default.best_time_name2pr24 = label11.Text;
                    Settings.Default.best_time_name3pr24 = label12.Text;
                    Settings.Default.best_time_result1Pr24 = label13.Text;
                    Settings.Default.best_time_result2Pr24 = label14.Text;
                    Settings.Default.best_time_result3Pr24 = label15.Text;
                    Settings.Default.Save();


                }
                else
                {
                    if (label1.Text == "Ретро")
                    {
                        Settings.Default.best_time_name1retro = label10.Text;
                        Settings.Default.best_time_name2retro = label11.Text;
                        Settings.Default.best_time_name3retro = label12.Text;
                        Settings.Default.best_time_result1retro = label13.Text;
                        Settings.Default.best_time_result2retro = label14.Text;
                        Settings.Default.best_time_result3retro = label15.Text;
                        Settings.Default.Save();
                    }
                    else
                    {
                        if (label1.Text == "Вантажівка")
                        {
                            Settings.Default.best_time_name1vantagivka = label10.Text;
                            Settings.Default.best_time_name2vantagivka = label11.Text;
                            Settings.Default.best_time_name3vantagivka = label12.Text;
                            Settings.Default.best_time_result1vantagivka = label13.Text;
                            Settings.Default.best_time_result2vantagivka = label14.Text;
                            Settings.Default.best_time_result3vantagivka = label15.Text;
                            Settings.Default.Save();
                        }
                        else
                        {
                            if (label1.Text == "ES-стандарт")
                            {
                                Settings.Default.best_time_name1Es_s = label10.Text;
                                Settings.Default.best_time_name2Es_s = label11.Text;
                                Settings.Default.best_time_name3Es_s = label12.Text;
                                Settings.Default.best_time_result1Es_s = label13.Text;
                                Settings.Default.best_time_result2Es_s = label14.Text;
                                Settings.Default.best_time_result3Es_s = label15.Text;
                                Settings.Default.Save();
                            }
                            else
                            {
                                if (label1.Text == "G-33")
                                {
                                    Settings.Default.best_time_name1g33 = label10.Text;
                                    Settings.Default.best_time_name2g33 = label11.Text;
                                    Settings.Default.best_time_name3g33 = label12.Text;
                                    Settings.Default.best_time_result1g33 = label13.Text;
                                    Settings.Default.best_time_result2g33 = label14.Text;
                                    Settings.Default.best_time_result3g33 = label15.Text;
                                    Settings.Default.Save();
                                }
                                else
                                {
                                    if (label1.Text == "F1-24")
                                    {
                                        Settings.Default.best_time_name1f124 = label10.Text;
                                        Settings.Default.best_time_name2f124 = label11.Text;
                                        Settings.Default.best_time_name3f124 = label12.Text;
                                        Settings.Default.best_time_result1f124 = label13.Text;
                                        Settings.Default.best_time_result2f124 = label14.Text;
                                        Settings.Default.best_time_result3f124 = label15.Text;
                                        Settings.Default.Save();
                                    }
                                    else
                                    {
                                        if (label1.Text == "G12")
                                        {
                                            Settings.Default.best_time_name1g12 = label10.Text;
                                            Settings.Default.best_time_name2g12 = label11.Text;
                                            Settings.Default.best_time_name3g12 = label12.Text;
                                            Settings.Default.best_time_result1g12 = label13.Text;
                                            Settings.Default.best_time_result2g12 = label14.Text;
                                            Settings.Default.best_time_result3g12 = label15.Text;
                                            Settings.Default.Save();
                                        }
                                        else
                                        {
                                            if (label1.Text == "ES-24")
                                            {
                                                Settings.Default.best_time_name1es24 = label10.Text;
                                                Settings.Default.best_time_name2es24 = label11.Text;
                                                Settings.Default.best_time_name3es24 = label12.Text;
                                                Settings.Default.best_time_result1es24 = label13.Text;
                                                Settings.Default.best_time_result2es24 = label14.Text;
                                                Settings.Default.best_time_result3es24 = label15.Text;
                                                Settings.Default.Save();
                                            }
                                            else
                                            {
                                                if (label1.Text == "ES-32")
                                                {
                                                    Settings.Default.best_time_name1es32 = label10.Text;
                                                    Settings.Default.best_time_name2es32 = label11.Text;
                                                    Settings.Default.best_time_name3es32 = label12.Text;
                                                    Settings.Default.best_time_result1es32 = label13.Text;
                                                    Settings.Default.best_time_result2es32 = label14.Text;
                                                    Settings.Default.best_time_result3es32 = label15.Text;
                                                    Settings.Default.Save();
                                                }
                                                else
                                                {
                                                    if (label1.Text == "F1")
                                                    {
                                                        Settings.Default.best_time_name1f1 = label10.Text;
                                                        Settings.Default.best_time_name2f1 = label11.Text;
                                                        Settings.Default.best_time_name3f1 = label12.Text;
                                                        Settings.Default.best_time_result1f1 = label13.Text;
                                                        Settings.Default.best_time_result2f1 = label14.Text;
                                                        Settings.Default.best_time_result3f1 = label15.Text;
                                                        Settings.Default.Save();
                                                    }
                                                    else
                                                    {
                                                        if (label1.Text == "G15")
                                                        {
                                                            Settings.Default.best_time_name1g15 = label10.Text;
                                                            Settings.Default.best_time_name2g15 = label11.Text;
                                                            Settings.Default.best_time_name3g15 = label12.Text;
                                                            Settings.Default.best_time_result1g15 = label13.Text;
                                                            Settings.Default.best_time_result2g15 = label14.Text;
                                                            Settings.Default.best_time_result3g15 = label15.Text;
                                                            Settings.Default.Save();
                                                        }
                                                        else
                                                        {
                                                            if (label1.Text == "Open-G12")
                                                            {
                                                                Settings.Default.best_time_name1g12open = label10.Text;
                                                                Settings.Default.best_time_name2g12open = label11.Text;
                                                                Settings.Default.best_time_name3g12open = label12.Text;
                                                                Settings.Default.best_time_result1g12open = label13.Text;
                                                                Settings.Default.best_time_result2g12open = label14.Text;
                                                                Settings.Default.best_time_result3g12open = label15.Text;
                                                                Settings.Default.Save();
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



                





                number_pilot = number_pilot + 1;

                dataGridView2.Rows.Add(number_pilot, label56.Text,label55.Text);
                

                
                dataGridView2.Sort(dataGridViewTextBoxColumn3, ListSortDirection.Ascending);
               
                
                
                


                
                //laptime++;
                serialPort1.Close();
                laptime = Convert.ToInt32(label104.Text);
                timer1.Enabled = false;
                psec = Convert.ToInt32(textBox107.Text);
                pmin = 0;
                timer2.Enabled = true;
                label101.Text = "<<Заміна пілота>>";
                panel9.BackColor = Color.Orange;
                panel10.BackColor = Color.Orange;
                panel11.BackColor = Color.Orange;
                panel12.BackColor = Color.Orange;
                //заміна пілота
                label56.Text = textBox65.Text;
                laptime--;
                if (laptime != 0)
                {
                    textBox65.Text = Convert.ToString(listBox1.Items[laptime - 1]);

                    label104.Text = Convert.ToString(laptime);


                    //
                    button5.Visible = false;
                    button6.Visible = false;
                    button5.Enabled = false;
                    button6.Enabled = false;

                    if (textBox65.Text != "")
                    {
                        zaminapilota.Play();
                    }
                }
                else
                {
                    textBox65.Text = "";
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveTable(dataGridView1);
            dataGridView1.Visible = false;
            button3.Enabled = true;
            button2.Visible = false;
            button10.Visible = false;
            button3.Visible = true;



        }







         


        
    }


}