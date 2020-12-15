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
using System.Runtime.CompilerServices;
using System.Media;
using zase4ka.Properties;

namespace zase4kak
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
       
          
        }


        int min, sec = 1, pmin, psec, laptime;

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

       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;
            textBox66.Enabled = false;
            textBox67.Enabled = false;
            textBox68.Enabled = false;
            textBox69.Enabled = false;
            textBox70.Enabled = false;
            textBox71.Enabled = false;
            textBox72.Enabled = false;
            textBox73.Enabled = false;
            textBox74.Enabled = false;
            textBox75.Enabled = false;
            textBox76.Enabled = false;
            textBox77.Enabled = false;
            textBox76.Enabled = false;
            textBox78.Enabled = false;
            textBox79.Enabled = false;
            textBox80.Enabled = false;
            textBox81.Enabled = false;
            textBox82.Enabled = false;
            textBox83.Enabled = false;
            textBox85.Enabled = false;
            textBox84.Enabled = false;
            textBox86.Enabled = false;
            textBox87.Enabled = false;
            textBox88.Enabled = false;
            textBox89.Enabled = false;
            textBox90.Enabled = false;
            textBox91.Enabled = false;
            textBox92.Enabled = false;
            textBox93.Enabled = false;
            textBox94.Enabled = false;
            textBox95.Enabled = false;
            textBox96.Enabled = false;
            textBox97.Enabled = false;
            textBox98.Enabled = false;
            textBox99.Enabled = false;
            textBox100.Enabled = false;
            textBox101.Enabled = false;
            textBox102.Enabled = false;
            textBox103.Enabled = false;
            textBox104.Enabled = false;
            textBox105.Enabled = false;
            button5.Focus();
            button6.Focus();



            if (textBox66.Text == "-")
            {
                textBox66.BackColor = Color.Red;
            }
            if (textBox67.Text == "-")
            {
                textBox67.BackColor = Color.Red;
            }
            if (textBox68.Text == "-")
            {
                textBox68.BackColor = Color.Red;
            }
            if (textBox69.Text == "-")
            {
                textBox69.BackColor = Color.Red;
            }
            if (textBox70.Text == "-")
            {
                textBox70.BackColor = Color.Red;
            }
            if (textBox71.Text == "-")
            {
                textBox71.BackColor = Color.Red;
            }
            if (textBox72.Text == "-")
            {
                textBox72.BackColor = Color.Red;
            }
            if (textBox73.Text == "-")
            {
                textBox73.BackColor = Color.Red;
            }
            if (textBox74.Text == "-")
            {
                textBox74.BackColor = Color.Red;
            }

            if (textBox75.Text == "-")
            {
                textBox75.BackColor = Color.Red;
            }
            if (textBox76.Text == "-")
            {
                textBox76.BackColor = Color.Red;
            }
            if (textBox77.Text == "-")
            {
                textBox77.BackColor = Color.Red;
            }
            if (textBox78.Text == "-")
            {
                textBox78.BackColor = Color.Red;
            }
            if (textBox79.Text == "-")
            {
                textBox79.BackColor = Color.Red;
            }
            if (textBox80.Text == "-")
            {
                textBox80.BackColor = Color.Red;
            }
            if (textBox81.Text == "-")
            {
                textBox81.BackColor = Color.Red;
            }
            if (textBox82.Text == "-")
            {
                textBox82.BackColor = Color.Red;
            }
            if (textBox83.Text == "-")
            {
                textBox83.BackColor = Color.Red;
            }
            if (textBox84.Text == "-")
            {
                textBox84.BackColor = Color.Red;
            }
            if (textBox85.Text == "-")
            {
                textBox85.BackColor = Color.Red;
            }
            if (textBox86.Text == "-")
            {
                textBox86.BackColor = Color.Red;
            }
            if (textBox87.Text == "-")
            {
                textBox87.BackColor = Color.Red;
            }
            if (textBox88.Text == "-")
            {
                textBox88.BackColor = Color.Red;
            }
            if (textBox89.Text == "-")
            {
                textBox89.BackColor = Color.Red;
            }
            if (textBox90.Text == "-")
            {
                textBox90.BackColor = Color.Red;
            }
            if (textBox91.Text == "-")
            {
                textBox91.BackColor = Color.Red;
            }
            if (textBox92.Text == "-")
            {
                textBox92.BackColor = Color.Red;
            }
            if (textBox93.Text == "-")
            {
                textBox93.BackColor = Color.Red;
            }
            if (textBox94.Text == "-")
            {
                textBox94.BackColor = Color.Red;
            }
            if (textBox95.Text == "-")
            {
                textBox95.BackColor = Color.Red;
            }
            if (textBox96.Text == "-")
            {
                textBox96.BackColor = Color.Red;
            }
            if (textBox97.Text == "-")
            {
                textBox97.BackColor = Color.Red;
            }
            if (textBox98.Text == "-")
            {
                textBox98.BackColor = Color.Red;
            }
            if (textBox99.Text == "-")
            {
                textBox99.BackColor = Color.Red;
            }
            if (textBox100.Text == "-")
            {
                textBox100.BackColor = Color.Red;
            }
            if (textBox101.Text == "-")
            {
                textBox101.BackColor = Color.Red;
            }
            if (textBox102.Text == "-")
            {
                textBox102.BackColor = Color.Red;
            }
            if (textBox103.Text == "-")
            {
                textBox103.BackColor = Color.Red;
            }
            if (textBox104.Text == "-")
            {
                textBox104.BackColor = Color.Red;
            }
            if (textBox105.Text == "-")
            {
                textBox105.BackColor = Color.Red;
            }


            label56.Text = textBox75.Text;
            textBox65.Text = textBox74.Text;


        }

        private void timer2_Tick(object sender, EventArgs e)
        {


            if(label50.Text == "0:17")
            {
                sekyd.Play();
            }


            if(label50.Text == "0:4")
            {
                timetostart.Play();
            }

            if (label56.Text == "-")
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                label101.Text = "<<Кваліфікацію завершено!>>";
                serialPort1.Close();
                kvalificatsia.Play();
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

            if(pmin == -1 || psec == 0)
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

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            textBox108.AppendText(serialPort1.ReadLine());
            button5.Focus();
        }
        int i;
        private void timer9_Tick(object sender, EventArgs e)
        {



            

            if (Convert.ToInt32(textBox108.Text) != 0)
            {
                i = Convert.ToInt32(label100.Text);          //червона доріжка
                timer10.Enabled = true;
                timer11.Enabled = false;
                label103.Text = label102.Text;
                Time = 0;
                timer11.Enabled = true;
                label20.Text = label19.Text;
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
                        label55.Text = label103.Text;
                        record.Play();
                    }

                }
            }
        }



        private void Form4_Load(object sender, EventArgs e)
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


            String[] strPortName = SerialPort.GetPortNames();
            foreach (string n in strPortName)
            {
                comboBox1.Items.Add(n);
            }
            comboBox1.SelectedIndex = 0;
        }
        double Time;
        private void timer11_Tick(object sender, EventArgs e)
        {
            Time += 0.001 * 17;                   //timer на час кола
            label102.Text = string.Format("{0:F3}", Time);       //timer на час кола 

        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            i++;                                            //добавляю кола 1 доріці
            label100.Text = Convert.ToString(i);
            timer10.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {


             Settings.Default.lapTIme_comPort = comboBox1.Text;
            Settings.Default.Save();


            button1.Focus();
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = comboBox1.Text;
            serialPort1.Open();
            serialPort1.WriteLine("3");
            serialPort1.Close();
            button4.Visible = false;
            button1.Visible = true;
            comboBox1.Visible = false;
            button3.Enabled = true;

           
            
            
            button1.Visible = true;
            button2.Enabled = false;
            textBox66.Enabled = false;
            textBox67.Enabled = false;
            textBox68.Enabled = false;
            textBox69.Enabled = false;
            textBox70.Enabled = false;
            textBox71.Enabled = false;
            textBox72.Enabled = false;
            textBox73.Enabled = false;
            textBox74.Enabled = false;
            textBox75.Enabled = false;
            textBox76.Enabled = false;
            textBox77.Enabled = false;
            textBox76.Enabled = false;
            textBox78.Enabled = false;
            textBox79.Enabled = false;
            textBox80.Enabled = false;
            textBox81.Enabled = false;
            textBox82.Enabled = false;
            textBox83.Enabled = false;
            textBox85.Enabled = false;
            textBox84.Enabled = false;
            textBox86.Enabled = false;
            textBox87.Enabled = false;
            textBox88.Enabled = false;
            textBox89.Enabled = false;
            textBox90.Enabled = false;
            textBox91.Enabled = false;
            textBox92.Enabled = false;
            textBox93.Enabled = false;
            textBox94.Enabled = false;
            textBox95.Enabled = false;
            textBox96.Enabled = false;
            textBox97.Enabled = false;
            textBox98.Enabled = false;
            textBox99.Enabled = false;
            textBox100.Enabled = false;
            textBox101.Enabled = false;
            textBox102.Enabled = false;
            textBox103.Enabled = false;
            textBox104.Enabled = false;
            textBox105.Enabled = false;
            button1.Focus();



            if (textBox66.Text == "-")
            {
                textBox66.BackColor = Color.Red;
            }
            if (textBox67.Text == "-")
            {
                textBox67.BackColor = Color.Red;
            }
            if (textBox68.Text == "-")
            {
                textBox68.BackColor = Color.Red;
            }
            if (textBox69.Text == "-")
            {
                textBox69.BackColor = Color.Red;
            }
            if (textBox70.Text == "-")
            {
                textBox70.BackColor = Color.Red;
            }
            if (textBox71.Text == "-")
            {
                textBox71.BackColor = Color.Red;
            }
            if (textBox72.Text == "-")
            {
                textBox72.BackColor = Color.Red;
            }
            if (textBox73.Text == "-")
            {
                textBox73.BackColor = Color.Red;
            }
            if (textBox74.Text == "-")
            {
                textBox74.BackColor = Color.Red;
            }

            if (textBox75.Text == "-")
            {
                textBox75.BackColor = Color.Red;
            }
            if (textBox76.Text == "-")
            {
                textBox76.BackColor = Color.Red;
            }
            if (textBox77.Text == "-")
            {
                textBox77.BackColor = Color.Red;
            }
            if (textBox78.Text == "-")
            {
                textBox78.BackColor = Color.Red;
            }
            if (textBox79.Text == "-")
            {
                textBox79.BackColor = Color.Red;
            }
            if (textBox80.Text == "-")
            {
                textBox80.BackColor = Color.Red;
            }
            if (textBox81.Text == "-")
            {
                textBox81.BackColor = Color.Red;
            }
            if (textBox82.Text == "-")
            {
                textBox82.BackColor = Color.Red;
            }
            if (textBox83.Text == "-")
            {
                textBox83.BackColor = Color.Red;
            }
            if (textBox84.Text == "-")
            {
                textBox84.BackColor = Color.Red;
            }
            if (textBox85.Text == "-")
            {
                textBox85.BackColor = Color.Red;
            }
            if (textBox86.Text == "-")
            {
                textBox86.BackColor = Color.Red;
            }
            if (textBox87.Text == "-")
            {
                textBox87.BackColor = Color.Red;
            }
            if (textBox88.Text == "-")
            {
                textBox88.BackColor = Color.Red;
            }
            if (textBox89.Text == "-")
            {
                textBox89.BackColor = Color.Red;
            }
            if (textBox90.Text == "-")
            {
                textBox90.BackColor = Color.Red;
            }
            if (textBox91.Text == "-")
            {
                textBox91.BackColor = Color.Red;
            }
            if (textBox92.Text == "-")
            {
                textBox92.BackColor = Color.Red;
            }
            if (textBox93.Text == "-")
            {
                textBox93.BackColor = Color.Red;
            }
            if (textBox94.Text == "-")
            {
                textBox94.BackColor = Color.Red;
            }
            if (textBox95.Text == "-")
            {
                textBox95.BackColor = Color.Red;
            }
            if (textBox96.Text == "-")
            {
                textBox96.BackColor = Color.Red;
            }
            if (textBox97.Text == "-")
            {
                textBox97.BackColor = Color.Red;
            }
            if (textBox98.Text == "-")
            {
                textBox98.BackColor = Color.Red;
            }
            if (textBox99.Text == "-")
            {
                textBox99.BackColor = Color.Red;
            }
            if (textBox100.Text == "-")
            {
                textBox100.BackColor = Color.Red;
            }
            if (textBox101.Text == "-")
            {
                textBox101.BackColor = Color.Red;
            }
            if (textBox102.Text == "-")
            {
                textBox102.BackColor = Color.Red;
            }
            if (textBox103.Text == "-")
            {
                textBox103.BackColor = Color.Red;
            }
            if (textBox104.Text == "-")
            {
                textBox104.BackColor = Color.Red;
            }
            if (textBox105.Text == "-")
            {
                textBox105.BackColor = Color.Red;
            }


            label56.Text = textBox75.Text;
            textBox65.Text = textBox74.Text;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {


           

            if(serialPort1.IsOpen == true && timer2.Enabled == true)
            {
                serialPort1.Close();
            }

            if (label101.Text == "<<Кваліфікацію завершено!>>")
            {
                button7.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button6.Visible = false;
            }


            if (Convert.ToDouble(textBox35.Text) < Convert.ToDouble(textBox33.Text))
            {
                textBox109.Text = textBox33.Text;
                textBox33.Text = textBox35.Text;
                textBox35.Text = textBox109.Text;
                textBox140.Text = textBox2.Text;
                textBox2.Text = textBox1.Text;
                textBox1.Text = textBox140.Text;

            }


            if (Convert.ToDouble(textBox34.Text) < Convert.ToDouble(textBox35.Text))
            {
                textBox110.Text = textBox35.Text;
                textBox35.Text = textBox34.Text;
                textBox34.Text = textBox110.Text;
                textBox141.Text = textBox3.Text;
                textBox3.Text = textBox2.Text;
                textBox2.Text = textBox141.Text;

            }

            if (Convert.ToDouble(textBox36.Text) < Convert.ToDouble(textBox34.Text))
            {
                textBox111.Text = textBox34.Text;
                textBox34.Text = textBox36.Text;
                textBox36.Text = textBox111.Text;

                textBox142.Text = textBox4.Text;
                textBox4.Text = textBox3.Text;
                textBox3.Text = textBox142.Text;

            }

            if (Convert.ToDouble(textBox37.Text) < Convert.ToDouble(textBox36.Text))
            {
                textBox112.Text = textBox36.Text;
                textBox36.Text = textBox37.Text;
                textBox37.Text = textBox112.Text;

                textBox143.Text = textBox5.Text;
                textBox5.Text = textBox4.Text;
                textBox4.Text = textBox143.Text;
            }

            if (Convert.ToDouble(textBox38.Text) < Convert.ToDouble(textBox37.Text))
            {
                textBox113.Text = textBox37.Text;
                textBox37.Text = textBox38.Text;
                textBox38.Text = textBox113.Text;

                textBox144.Text = textBox6.Text;
                textBox6.Text = textBox5.Text;
                textBox5.Text = textBox144.Text;
            }

            if (Convert.ToDouble(textBox39.Text) < Convert.ToDouble(textBox38.Text))
            {
                textBox114.Text = textBox38.Text;
                textBox38.Text = textBox39.Text;
                textBox39.Text = textBox114.Text;

                textBox145.Text = textBox7.Text;
                textBox7.Text = textBox6.Text;
                textBox6.Text = textBox145.Text;
            }


            if (Convert.ToDouble(textBox40.Text) < Convert.ToDouble(textBox39.Text))
            {
                textBox115.Text = textBox39.Text;
                textBox39.Text = textBox40.Text;
                textBox40.Text = textBox115.Text;

                textBox146.Text = textBox8.Text;
                textBox8.Text = textBox7.Text;
                textBox7.Text = textBox146.Text;

            }

            if (Convert.ToDouble(textBox41.Text) < Convert.ToDouble(textBox40.Text))
            {
                textBox116.Text = textBox40.Text;
                textBox40.Text = textBox41.Text;
                textBox41.Text = textBox116.Text;

                textBox147.Text = textBox9.Text;
                textBox9.Text = textBox8.Text;
                textBox8.Text = textBox147.Text;

            }

            if (Convert.ToDouble(textBox42.Text) < Convert.ToDouble(textBox41.Text))
            {
                textBox117.Text = textBox41.Text;
                textBox41.Text = textBox42.Text;
                textBox42.Text = textBox117.Text;

                textBox148.Text = textBox10.Text;
                textBox10.Text = textBox9.Text;
                textBox9.Text = textBox148.Text;

            }

            if (Convert.ToDouble(textBox43.Text) < Convert.ToDouble(textBox42.Text))
            {
                textBox118.Text = textBox42.Text;
                textBox42.Text = textBox43.Text;
                textBox43.Text = textBox118.Text;

                textBox149.Text = textBox11.Text;
                textBox11.Text = textBox10.Text;
                textBox10.Text = textBox149.Text;
            }

            if (Convert.ToDouble(textBox44.Text) < Convert.ToDouble(textBox43.Text))
            {
                textBox119.Text = textBox43.Text;
                textBox43.Text = textBox44.Text;
                textBox44.Text = textBox119.Text;

                textBox150.Text = textBox12.Text;
                textBox12.Text = textBox11.Text;
                textBox11.Text = textBox150.Text;

            }

            if (Convert.ToDouble(textBox45.Text) < Convert.ToDouble(textBox44.Text))
            {
                textBox120.Text = textBox44.Text;
                textBox44.Text = textBox45.Text;
                textBox45.Text = textBox120.Text;

                textBox151.Text = textBox13.Text;
                textBox13.Text = textBox12.Text;
                textBox12.Text = textBox151.Text;

            }

            if (Convert.ToDouble(textBox46.Text) < Convert.ToDouble(textBox45.Text))
            {
                textBox121.Text = textBox45.Text;
                textBox45.Text = textBox46.Text;
                textBox46.Text = textBox121.Text;

                textBox152.Text = textBox14.Text;
                textBox14.Text = textBox13.Text;
                textBox13.Text = textBox152.Text;

            }

            if (Convert.ToDouble(textBox47.Text) < Convert.ToDouble(textBox46.Text))
            {
                textBox122.Text = textBox46.Text;
                textBox46.Text = textBox47.Text;
                textBox47.Text = textBox122.Text;

                textBox153.Text = textBox15.Text;
                textBox15.Text = textBox14.Text;
                textBox14.Text = textBox153.Text;

            }

            if (Convert.ToDouble(textBox48.Text) < Convert.ToDouble(textBox47.Text))
            {
                textBox123.Text = textBox47.Text;
                textBox47.Text = textBox48.Text;
                textBox48.Text = textBox123.Text;

                textBox154.Text = textBox16.Text;
                textBox16.Text = textBox15.Text;
                textBox15.Text = textBox154.Text;
            }

            if (Convert.ToDouble(textBox49.Text) < Convert.ToDouble(textBox48.Text))
            {
                textBox124.Text = textBox48.Text;
                textBox48.Text = textBox49.Text;
                textBox49.Text = textBox124.Text;

                textBox155.Text = textBox17.Text;
                textBox17.Text = textBox16.Text;
                textBox16.Text = textBox155.Text;

            }

            if (Convert.ToDouble(textBox50.Text) < Convert.ToDouble(textBox49.Text))
            {
                textBox125.Text = textBox49.Text;
                textBox49.Text = textBox50.Text;
                textBox50.Text = textBox125.Text;

                textBox156.Text = textBox18.Text;
                textBox18.Text = textBox17.Text;
                textBox17.Text = textBox156.Text;

            }

            if (Convert.ToDouble(textBox51.Text) < Convert.ToDouble(textBox50.Text))
            {
                textBox126.Text = textBox50.Text;
                textBox50.Text = textBox51.Text;
                textBox51.Text = textBox126.Text;

                textBox157.Text = textBox19.Text;
                textBox19.Text = textBox18.Text;
                textBox18.Text = textBox157.Text;
            }

            if (Convert.ToDouble(textBox52.Text) < Convert.ToDouble(textBox51.Text))
            {
                textBox127.Text = textBox51.Text;
                textBox51.Text = textBox52.Text;
                textBox52.Text = textBox127.Text;

                textBox158.Text = textBox20.Text;
                textBox20.Text = textBox19.Text;
                textBox19.Text = textBox158.Text;

            }

            if (Convert.ToDouble(textBox53.Text) < Convert.ToDouble(textBox52.Text))
            {
                textBox128.Text = textBox52.Text;
                textBox52.Text = textBox53.Text;
                textBox53.Text = textBox128.Text;

                textBox159.Text = textBox21.Text;
                textBox21.Text = textBox20.Text;
                textBox20.Text = textBox159.Text;

            }

            if (Convert.ToDouble(textBox54.Text) < Convert.ToDouble(textBox53.Text))
            {
                textBox129.Text = textBox53.Text;
                textBox53.Text = textBox54.Text;
                textBox54.Text = textBox129.Text;

                textBox160.Text = textBox22.Text;
                textBox22.Text = textBox21.Text;
                textBox21.Text = textBox160.Text;
            }

            if (Convert.ToDouble(textBox55.Text) < Convert.ToDouble(textBox54.Text))
            {
                textBox130.Text = textBox54.Text;
                textBox54.Text = textBox55.Text;
                textBox55.Text = textBox130.Text;

                textBox161.Text = textBox23.Text;
                textBox23.Text = textBox22.Text;
                textBox22.Text = textBox161.Text;
            }

            if (Convert.ToDouble(textBox56.Text) < Convert.ToDouble(textBox55.Text))
            {
                textBox131.Text = textBox55.Text;
                textBox55.Text = textBox56.Text;
                textBox56.Text = textBox131.Text;

                textBox162.Text = textBox24.Text;
                textBox24.Text = textBox23.Text;
                textBox23.Text = textBox162.Text;
            }

            if (Convert.ToDouble(textBox57.Text) < Convert.ToDouble(textBox56.Text))
            {
                textBox132.Text = textBox56.Text;
                textBox56.Text = textBox57.Text;
                textBox57.Text = textBox132.Text;

                textBox163.Text = textBox25.Text;
                textBox25.Text = textBox24.Text;
                textBox24.Text = textBox163.Text;
            }

            if (Convert.ToDouble(textBox58.Text) < Convert.ToDouble(textBox57.Text))
            {
                textBox133.Text = textBox57.Text;
                textBox57.Text = textBox58.Text;
                textBox58.Text = textBox133.Text;

                textBox164.Text = textBox26.Text;
                textBox26.Text = textBox25.Text;
                textBox25.Text = textBox164.Text;

            }

            if (Convert.ToDouble(textBox59.Text) < Convert.ToDouble(textBox58.Text))
            {
                textBox134.Text = textBox58.Text;
                textBox58.Text = textBox59.Text;
                textBox59.Text = textBox134.Text;

                textBox165.Text = textBox27.Text;
                textBox27.Text = textBox26.Text;
                textBox26.Text = textBox165.Text;
            }

            if (Convert.ToDouble(textBox60.Text) < Convert.ToDouble(textBox59.Text))
            {
                textBox135.Text = textBox59.Text;
                textBox59.Text = textBox60.Text;
                textBox60.Text = textBox135.Text;

                textBox166.Text = textBox28.Text;
                textBox28.Text = textBox27.Text;
                textBox27.Text = textBox166.Text;
            }

            if (Convert.ToDouble(textBox61.Text) < Convert.ToDouble(textBox60.Text))
            {
                textBox136.Text = textBox60.Text;
                textBox60.Text = textBox61.Text;
                textBox61.Text = textBox136.Text;

                textBox167.Text = textBox29.Text;
                textBox29.Text = textBox28.Text;
                textBox28.Text = textBox167.Text;

            }

            if (Convert.ToDouble(textBox62.Text) < Convert.ToDouble(textBox61.Text))
            {
                textBox137.Text = textBox61.Text;
                textBox61.Text = textBox62.Text;
                textBox62.Text = textBox137.Text;

                textBox168.Text = textBox30.Text;
                textBox30.Text = textBox29.Text;
                textBox29.Text = textBox168.Text;

            }

            if (Convert.ToDouble(textBox63.Text) < Convert.ToDouble(textBox62.Text))
            {
                textBox138.Text = textBox62.Text;
                textBox62.Text = textBox63.Text;
                textBox63.Text = textBox138.Text;

                textBox169.Text = textBox31.Text;
                textBox31.Text = textBox30.Text;
                textBox30.Text = textBox169.Text;
            }

            if (Convert.ToDouble(textBox64.Text) < Convert.ToDouble(textBox63.Text))
            {
                textBox139.Text = textBox63.Text;
                textBox63.Text = textBox64.Text;
                textBox64.Text = textBox139.Text;

                textBox170.Text = textBox32.Text;
                textBox32.Text = textBox31.Text;
                textBox31.Text = textBox170.Text;
            }

            if (Convert.ToDouble(textBox172.Text) < Convert.ToDouble(textBox64.Text))
            {
                textBox173.Text = textBox64.Text;
                textBox64.Text = textBox172.Text;
                textBox172.Text = textBox173.Text;

                textBox174.Text = textBox171.Text;
                textBox171.Text = textBox32.Text;
                textBox32.Text = textBox174.Text;
            }

            if (Convert.ToDouble(textBox177.Text) < Convert.ToDouble(textBox172.Text))
            {
                textBox176.Text = textBox172.Text;
                textBox172.Text = textBox177.Text;
                textBox177.Text = textBox176.Text;

                textBox175.Text = textBox178.Text;
                textBox178.Text = textBox171.Text;
                textBox171.Text = textBox175.Text;
            }

            if (Convert.ToDouble(textBox181.Text) < Convert.ToDouble(textBox177.Text))
            {
                textBox180.Text = textBox177.Text;
                textBox177.Text = textBox181.Text;
                textBox181.Text = textBox180.Text;

                textBox179.Text = textBox182.Text;
                textBox182.Text = textBox178.Text;
                textBox178.Text = textBox179.Text;
            }

            if (Convert.ToDouble(textBox185.Text) < Convert.ToDouble(textBox181.Text))
            {
                textBox184.Text = textBox181.Text;
                textBox181.Text = textBox185.Text;
                textBox185.Text = textBox184.Text;

                textBox183.Text = textBox186.Text;
                textBox186.Text = textBox182.Text;
                textBox182.Text = textBox183.Text;
            }

            if (Convert.ToDouble(textBox189.Text) < Convert.ToDouble(textBox185.Text))
            {
                textBox188.Text = textBox185.Text;
                textBox185.Text = textBox189.Text;
                textBox189.Text = textBox188.Text;

                textBox187.Text = textBox190.Text;
                textBox190.Text = textBox186.Text;
                textBox186.Text = textBox187.Text;
            }

            if (Convert.ToDouble(textBox193.Text) < Convert.ToDouble(textBox189.Text))
            {
                textBox192.Text = textBox189.Text;
                textBox189.Text = textBox193.Text;
                textBox193.Text = textBox192.Text;

                textBox191.Text = textBox194.Text;
                textBox194.Text = textBox190.Text;
                textBox190.Text = textBox191.Text;
            }

            if (Convert.ToDouble(textBox197.Text) < Convert.ToDouble(textBox193.Text))
            {
                textBox196.Text = textBox193.Text;
                textBox193.Text = textBox197.Text;
                textBox197.Text = textBox196.Text;

                textBox195.Text = textBox198.Text;
                textBox198.Text = textBox194.Text;
                textBox194.Text = textBox195.Text;
            }

            if (Convert.ToDouble(textBox201.Text) < Convert.ToDouble(textBox197.Text))
            {
                textBox200.Text = textBox197.Text;
                textBox197.Text = textBox201.Text;
                textBox201.Text = textBox200.Text;

                textBox199.Text = textBox202.Text;
                textBox202.Text = textBox198.Text;
                textBox198.Text = textBox199.Text;
            }

           
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox133_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button5_KeyPress(object sender, KeyPressEventArgs e)
        {
           

          
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
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
        }
        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
               
                serialPort1.WriteLine("3");
                stopsound.Play();
                timer1.Enabled = false;
                button5.Enabled = false;
                button5.Visible = false;
                button6.Enabled = true;
                button6.Visible = true;
                button6.Focus();
                timer11.Enabled = false;

                if (serialPort1.IsOpen == true && timer1.Enabled == false)
                {
                    serialPort1.Close();

                }
                else
                {
                    serialPort1.Open();
                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("3");
            stopsound.Play();
            timer1.Enabled = false;
            button5.Enabled = false;
            button5.Visible = false;
            button6.Enabled = true;
            button6.Visible = true;
            button6.Focus();
            timer11.Enabled = false;

            if (serialPort1.IsOpen == true && timer1.Enabled == false)
            {
                serialPort1.Close();

            }
            else
            {
                serialPort1.Open();
            }
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

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void timer4_Tick_1(object sender, EventArgs e)
        {
            comboBox1.Text = Settings.Default.lapTIme_comPort;
            timer4.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();

            f6.label2.Text = label1.Text;
            
            f6.textBox1.Text = textBox1.Text;
            f6.textBox33.Text = textBox33.Text;

            f6.textBox2.Text = textBox2.Text;
            f6.textBox35.Text = textBox35.Text;

            f6.textBox3.Text = textBox3.Text;
            f6.textBox34.Text = textBox34.Text;

            f6.textBox4.Text = textBox4.Text;
            f6.textBox36.Text = textBox36.Text;

            f6.textBox5.Text = textBox5.Text;
            f6.textBox37.Text = textBox37.Text;

            f6.textBox6.Text = textBox6.Text;
            f6.textBox38.Text = textBox38.Text;

            f6.textBox7.Text = textBox7.Text;
            f6.textBox39.Text = textBox39.Text;

            f6.textBox8.Text = textBox8.Text;
            f6.textBox40.Text = textBox40.Text;

            f6.textBox9.Text = textBox9.Text;
            f6.textBox41.Text = textBox41.Text;

            f6.textBox10.Text = textBox10.Text;
            f6.textBox42.Text = textBox42.Text;

            f6.textBox11.Text = textBox11.Text;
            f6.textBox43.Text = textBox43.Text;

            f6.textBox12.Text = textBox12.Text;
            f6.textBox44.Text = textBox44.Text;

            f6.textBox13.Text = textBox13.Text;
            f6.textBox45.Text = textBox45.Text;

            f6.textBox14.Text = textBox14.Text;
            f6.textBox46.Text = textBox46.Text;

            f6.textBox15.Text = textBox15.Text;
            f6.textBox47.Text = textBox47.Text;

            f6.textBox16.Text = textBox16.Text;
            f6.textBox48.Text = textBox48.Text;

            f6.textBox17.Text = textBox17.Text;
            f6.textBox49.Text = textBox49.Text;

            f6.textBox18.Text = textBox18.Text;
            f6.textBox50.Text = textBox50.Text;

            f6.textBox19.Text = textBox19.Text;
            f6.textBox51.Text = textBox51.Text;

            f6.textBox20.Text = textBox20.Text;
            f6.textBox52.Text = textBox52.Text;

            f6.textBox21.Text = textBox21.Text;
            f6.textBox53.Text = textBox53.Text;

            f6.textBox22.Text = textBox22.Text;
            f6.textBox54.Text = textBox54.Text;

            f6.textBox23.Text = textBox23.Text;
            f6.textBox55.Text = textBox55.Text;

            f6.textBox24.Text = textBox24.Text;
            f6.textBox56.Text = textBox56.Text;

            f6.textBox25.Text = textBox25.Text;
            f6.textBox57.Text = textBox57.Text;

            f6.textBox26.Text = textBox26.Text;
            f6.textBox58.Text = textBox58.Text;

            f6.textBox27.Text = textBox27.Text;
            f6.textBox59.Text = textBox59.Text;

            f6.textBox28.Text = textBox28.Text;
            f6.textBox60.Text = textBox60.Text;

            f6.textBox29.Text = textBox29.Text;
            f6.textBox61.Text = textBox61.Text;

            f6.textBox30.Text = textBox30.Text;
            f6.textBox62.Text = textBox62.Text;

            f6.textBox31.Text = textBox31.Text;
            f6.textBox63.Text = textBox63.Text;

            f6.textBox32.Text = textBox32.Text;
            f6.textBox64.Text = textBox64.Text;

            f6.textBox171.Text = textBox171.Text;
            f6.textBox172.Text = textBox172.Text;

            f6.textBox178.Text = textBox178.Text;
            f6.textBox177.Text = textBox177.Text;

            f6.textBox182.Text = textBox182.Text;
            f6.textBox181.Text = textBox181.Text;

            f6.textBox186.Text = textBox186.Text;
            f6.textBox185.Text = textBox185.Text;

            f6.textBox190.Text = textBox190.Text;
            f6.textBox189.Text = textBox189.Text;

            f6.textBox193.Text = textBox193.Text;
            f6.textBox192.Text = textBox192.Text;

            f6.textBox198.Text = textBox198.Text;
            f6.textBox197.Text = textBox197.Text;

            f6.textBox202.Text = textBox202.Text;
            f6.textBox201.Text = textBox201.Text;

            f6.timer1.Enabled = true;


            f6.Show();
            //this.Enabled = false;
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Enabled = true;
            button3.Enabled = false;
            textBox66.Enabled = true;
            textBox67.Enabled = true;
            textBox68.Enabled = true;
            textBox69.Enabled = true;
            textBox70.Enabled = true;
            textBox71.Enabled = true;
            textBox72.Enabled = true;
            textBox73.Enabled = true;
            textBox74.Enabled = true;
            textBox75.Enabled = true;
            textBox76.Enabled = true;
            textBox77.Enabled = true;
            textBox78.Enabled = true;
            textBox79.Enabled = true;
            textBox80.Enabled = true;
            textBox81.Enabled = true;
            textBox82.Enabled = true;
            textBox83.Enabled = true;
            textBox84.Enabled = true;
            textBox85.Enabled = true;
            textBox86.Enabled = true;
            textBox87.Enabled = true;
            textBox88.Enabled = true;
            textBox89.Enabled = true;
            textBox90.Enabled = true;
            textBox91.Enabled = true;
            textBox92.Enabled = true;
            textBox93.Enabled = true;
            textBox94.Enabled = true;
            textBox95.Enabled = true;
            textBox96.Enabled = true;
            textBox97.Enabled = true;
            textBox98.Enabled = true;
            textBox99.Enabled = true;
            textBox100.Enabled = true;
            textBox101.Enabled = true;
            textBox102.Enabled = true;
            textBox103.Enabled = true;
            textBox104.Enabled = true;
            textBox105.Enabled = true;

            button5.Focus();
            button6.Focus();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec--;                                                                                          //таймер для лаптайму
            label50.Text = Convert.ToInt32(min) +":"+ Convert.ToInt32(sec);                                 //таймер для лаптайму
            if (sec == 0)
            {
                sec = 60;
                min--;
            }

            if (min == -1 || sec == 0)
            {

                serialPort1.WriteLine("3");
                laptime++;
                label104.Text = Convert.ToString(laptime);
                timer1.Enabled = false;
                psec = Convert.ToInt32(textBox107.Text);
                pmin = 0;
                timer2.Enabled = true;
                label101.Text = "<<Заміна пілота>>";
                
                button5.Visible = false;
                button6.Visible = false;
                button5.Enabled = false;
                button6.Enabled = false;

                if(textBox65.Text != "-")
                {
                    zaminapilota.Play();
                }
              


                  laptime =Convert.ToInt32( label104.Text);

                switch(laptime)
                {
                    case 0:
                        label56.Text = textBox75.Text;
                        textBox65.Text = textBox74.Text;
                        
                        break;

                    case 1:
                        
                     
                        textBox75.BackColor = Color.Lime;
                        label56.Text = textBox74.Text;
                        textBox65.Text = textBox73.Text;
                        textBox1.Text = textBox75.Text;
                        textBox33.Text = label55.Text;
                        arr[0] = Convert.ToDouble(textBox33.Text);


                        






                        
                        break;

                    case 2:
                        
                     
                   
                        textBox74.BackColor = Color.Lime;
                        textBox2.Text = label56.Text;
                        textBox35.Text = label55.Text;
                        label56.Text = textBox73.Text;
                        textBox65.Text = textBox72.Text;
                        arr[1] = Convert.ToDouble(textBox35.Text);
                       
                        


                       

                        break;

                    case 3:
                  
                        
                        textBox73.BackColor = Color.Lime;
                        textBox3.Text = label56.Text;
                        textBox34.Text = label55.Text;
                        label56.Text = textBox72.Text;
                        textBox65.Text = textBox71.Text;
                        arr[2] = Convert.ToDouble(textBox34.Text);


                        

                        break;

                    case 4:
                        textBox72.BackColor = Color.Lime;
                        textBox4.Text = label56.Text;
                        textBox36.Text = label55.Text;
                        label56.Text = textBox71.Text;
                        textBox65.Text = textBox70.Text;
                        arr[3] = Convert.ToDouble(textBox36.Text);
                        timer3.Enabled = true;

                            



                       

                        break;

                    case 5:
                        textBox71.BackColor = Color.Lime;
                        textBox5.Text = label56.Text;
                        textBox37.Text = label55.Text;
                        label56.Text = textBox70.Text;
                        textBox65.Text = textBox69.Text;
                        arr[4] = Convert.ToDouble(textBox37.Text);


                       

                        
                        break;

                    case 6:
                        textBox70.BackColor = Color.Lime;
                        textBox6.Text = label56.Text;
                        textBox38.Text = label55.Text;
                        label56.Text = textBox69.Text;
                        textBox65.Text = textBox68.Text;
                        arr[5] = Convert.ToDouble(textBox38.Text);


                       
                        
                        break;
                    case 7:

                        textBox69.BackColor = Color.Lime;
                        textBox7.Text = label56.Text;
                        textBox39.Text = label55.Text;
                        label56.Text = textBox68.Text;
                        textBox65.Text = textBox67.Text;
                        arr[6] = Convert.ToDouble(textBox39.Text);

                       
                       
                        break;

                    case 8:
                        textBox68.BackColor = Color.Lime;
                        textBox8.Text = label56.Text;
                        textBox40.Text = label55.Text;
                        label56.Text = textBox67.Text;
                        textBox65.Text = textBox66.Text;
                        arr[7] = Convert.ToDouble(textBox40.Text);
                      

                        break;
                       

                    case 9:
                        textBox67.BackColor = Color.Lime;
                        textBox9.Text = label56.Text;
                        textBox41.Text = label55.Text;
                        label56.Text = textBox66.Text;
                        textBox65.Text = textBox85.Text;
                        arr[8] = Convert.ToDouble(textBox41.Text);
                       
                        break;
                       

                    case 10:
                        textBox66.BackColor = Color.Lime;
                        textBox10.Text = label56.Text;
                        textBox42.Text = label55.Text;
                        label56.Text = textBox85.Text;
                        textBox65.Text = textBox84.Text;
                        arr[9] = Convert.ToDouble(textBox42.Text);
                        
                        break;

                    case 11:
                        textBox85.BackColor = Color.Lime;
                        textBox11.Text = label56.Text;
                        textBox43.Text = label55.Text;
                        label56.Text = textBox84.Text;
                        textBox65.Text = textBox83.Text;
                        arr[10] = Convert.ToDouble(textBox43.Text);
                        
                        break;

                    case 12:
                        textBox84.BackColor = Color.Lime;
                        textBox12.Text = label56.Text;
                        textBox44.Text = label55.Text;
                        label56.Text = textBox83.Text;
                        textBox65.Text = textBox82.Text;
                        arr[11] = Convert.ToDouble(textBox44.Text);
                        
                        break;
                    case 13:

                        textBox83.BackColor = Color.Lime;
                        textBox13.Text = label56.Text;
                        textBox45.Text = label55.Text;
                        label56.Text = textBox82.Text;
                        textBox65.Text = textBox81.Text;
                        arr[12] = Convert.ToDouble(textBox45.Text);
                        
                        break;

                    case 14:
                        textBox82.BackColor = Color.Lime;
                        textBox14.Text = label56.Text;
                        textBox46.Text = label55.Text;
                        label56.Text = textBox81.Text;
                        textBox65.Text = textBox80.Text;
                        arr[13] = Convert.ToDouble(textBox46.Text);
                        
                        break;

                    case 15:
                        textBox81.BackColor = Color.Lime;
                        textBox15.Text = label56.Text;
                        textBox47.Text = label55.Text;
                        label56.Text = textBox80.Text;
                        textBox65.Text = textBox79.Text;
                        arr[14] = Convert.ToDouble(textBox47.Text);
                        
                        break;

                    case 16:
                        textBox80.BackColor = Color.Lime;
                        textBox16.Text = label56.Text;
                        textBox48.Text = label55.Text;
                        label56.Text = textBox79.Text;
                        textBox65.Text = textBox78.Text;
                        arr[15] = Convert.ToDouble(textBox48.Text);
                        
                        break;

                    case 17:
                        textBox79.BackColor = Color.Lime;
                        textBox17.Text = label56.Text;
                        textBox49.Text = label55.Text;
                        label56.Text = textBox78.Text;
                        textBox65.Text = textBox77.Text;
                        arr[16] = Convert.ToDouble(textBox49.Text);
                        
                        break;

                    case 18:
                        textBox78.BackColor = Color.Lime;
                        textBox18.Text = label56.Text;
                        textBox50.Text = label55.Text;
                        label56.Text = textBox77.Text;
                        textBox65.Text = textBox76.Text;
                        arr[17] = Convert.ToDouble(textBox50.Text);
                        
                        break;
                    case 19:

                        textBox77.BackColor = Color.Lime;
                        textBox19.Text = label56.Text;
                        textBox51.Text = label55.Text;
                        label56.Text = textBox76.Text;
                        textBox65.Text = textBox95.Text;
                        arr[18] = Convert.ToDouble(textBox51.Text);
                        
                        break;

                    case 20:
                        textBox76.BackColor = Color.Lime;
                        textBox20.Text = label56.Text;
                        textBox52.Text = label55.Text;
                        label56.Text = textBox95.Text;
                        textBox65.Text = textBox94.Text;
                        arr[19] = Convert.ToDouble(textBox52.Text);
                        
                        break;

                    case 21:
                        textBox95.BackColor = Color.Lime;
                        textBox21.Text = label56.Text;
                        textBox53.Text = label55.Text;
                        label56.Text = textBox94.Text;
                        textBox65.Text = textBox93.Text;
                        arr[20] = Convert.ToDouble(textBox53.Text);
                        
                        break;

                    case 22:
                        textBox94.BackColor = Color.Lime;
                        textBox22.Text = label56.Text;
                        textBox54.Text = label55.Text;
                        label56.Text = textBox93.Text;
                        textBox65.Text = textBox92.Text;
                        arr[21] = Convert.ToDouble(textBox54.Text);
                        
                        break;

                    case 23:
                        textBox93.BackColor = Color.Lime;
                        textBox23.Text = label56.Text;
                        textBox55.Text = label55.Text;
                        label56.Text = textBox92.Text;
                        textBox65.Text = textBox91.Text;
                        arr[22] = Convert.ToDouble(textBox55.Text);
                        
                        break;

                    case 24:
                        textBox92.BackColor = Color.Lime;
                        textBox24.Text = label56.Text;
                        textBox56.Text = label55.Text;
                        label56.Text = textBox91.Text;
                        textBox65.Text = textBox90.Text;
                        arr[23] = Convert.ToDouble(textBox56.Text);
                        
                        break;
                    case 25:

                        textBox91.BackColor = Color.Lime;
                        textBox25.Text = label56.Text;
                        textBox57.Text = label55.Text;
                        label56.Text = textBox90.Text;
                        textBox65.Text = textBox89.Text;
                        arr[24] = Convert.ToDouble(textBox57.Text);
                        
                        break;

                    case 26:
                        textBox90.BackColor = Color.Lime;
                        textBox26.Text = label56.Text;
                        textBox58.Text = label55.Text;
                        label56.Text = textBox89.Text;
                        textBox65.Text = textBox88.Text;
                        arr[25] = Convert.ToDouble(textBox58.Text);
                        
                        break;

                    case 27:
                        textBox89.BackColor = Color.Lime;
                        textBox27.Text = label56.Text;
                        textBox59.Text = label55.Text;
                        label56.Text = textBox88.Text;
                        textBox65.Text = textBox87.Text;
                        arr[26] = Convert.ToDouble(textBox59.Text);
                        
                        break;

                    case 28:
                        textBox88.BackColor = Color.Lime;
                        textBox28.Text = label56.Text;
                        textBox60.Text = label55.Text;
                        label56.Text = textBox87.Text;
                        textBox65.Text = textBox86.Text;
                        arr[27] = Convert.ToDouble(textBox60.Text);
                        
                        break;

                    case 29:
                        textBox87.BackColor = Color.Lime;
                        textBox29.Text = label56.Text;
                        textBox61.Text = label55.Text;
                        label56.Text = textBox86.Text;
                        textBox65.Text = textBox105.Text;
                        arr[28] = Convert.ToDouble(textBox61.Text);
                        
                        break;

                    case 30:
                        textBox86.BackColor = Color.Lime;
                        textBox30.Text = label56.Text;
                        textBox62.Text = label55.Text;
                        label56.Text = textBox105.Text;
                        textBox65.Text = textBox104.Text;
                        arr[29] = Convert.ToDouble(textBox62.Text);
                        
                        break;
                    case 31:

                        textBox105.BackColor = Color.Lime;
                        textBox31.Text = label56.Text;
                        textBox63.Text = label55.Text;
                        label56.Text = textBox104.Text;
                        textBox65.Text = textBox103.Text;
                        arr[30] = Convert.ToDouble(textBox63.Text);
                        
                        break;

                    case 32:
                        textBox104.BackColor = Color.Lime;
                        textBox32.Text = label56.Text;
                        textBox64.Text = label55.Text;
                        label56.Text = textBox103.Text;
                        textBox65.Text = textBox102.Text;
                        arr[31] = Convert.ToDouble(textBox64.Text);
                        
                        break;

                    case 33:
                        textBox103.BackColor = Color.Lime;
                        textBox171.Text = label56.Text;
                        textBox172.Text = label55.Text;
                        label56.Text = textBox102.Text;
                        textBox65.Text = textBox101.Text;
                        arr[32] = Convert.ToDouble(textBox172.Text);
                        
                        break;

                    case 34:
                        textBox102.BackColor = Color.Lime;
                        textBox178.Text = label56.Text;
                        textBox177.Text = label55.Text;
                        label56.Text = textBox101.Text;
                        textBox65.Text = textBox100.Text;
                        arr[33] = Convert.ToDouble(textBox177.Text);
                        
                        break;

                    case 35:
                        textBox101.BackColor = Color.Lime;
                        textBox182.Text = label56.Text;
                        textBox181.Text = label55.Text;
                        label56.Text = textBox100.Text;
                        textBox65.Text = textBox99.Text;
                        arr[34] = Convert.ToDouble(textBox181.Text);
                       
                        break;

                    case 36:
                        textBox100.BackColor = Color.Lime;
                        textBox186.Text = label56.Text;
                        textBox185.Text = label55.Text;
                        label56.Text = textBox99.Text;
                        textBox65.Text = textBox98.Text;
                        arr[35] = Convert.ToDouble(textBox185.Text);
                        
                        break;
                    case 37:

                        textBox99.BackColor = Color.Lime;
                        textBox190.Text = label56.Text;
                        textBox189.Text = label55.Text;
                        label56.Text = textBox98.Text;
                        textBox65.Text = textBox97.Text;
                        arr[36] = Convert.ToDouble(textBox189.Text);
                       
                        break;

                    case 38:
                        textBox98.BackColor = Color.Lime;
                        textBox194.Text = label56.Text;
                        textBox193.Text = label55.Text;
                        label56.Text = textBox97.Text;
                        textBox65.Text = textBox96.Text;
                        arr[37] = Convert.ToDouble(textBox193.Text);
                       
                        break;

                    case 39:
                        textBox97.BackColor = Color.Lime;
                        textBox198.Text = label56.Text;
                        textBox197.Text = label55.Text;
                        label56.Text = textBox96.Text;
                        textBox65.Text = "-";
                        arr[38] = Convert.ToDouble(textBox197.Text);
                   
                        break;

                    case 40:


                        textBox96.BackColor = Color.Lime;
                        textBox202.Text = label56.Text;
                        textBox201.Text = label55.Text;
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        
                        break;

                    
                }



            }


        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            
            startsound.Play();
            timer1.Enabled = true;
            min = Convert.ToInt32(textBox106.Text);
            button1.Visible = false;
            label101.Visible = true;
            serialPort1.Open();
            button5.Visible = true;
            button1.Enabled = false;
            button5.Focus();
            button6.Focus();
            serialPort1.WriteLine("4");
        }
    }
}
