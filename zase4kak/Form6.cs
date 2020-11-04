using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Exel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace zase4kak
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

       public void SaveTable(DataGridView What_save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Lap_Time.xlsx";

            Exel.Application excelapp = new Exel.Application();
            Exel.Workbook workbook = excelapp.Workbooks.Add();
            Exel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 1; i < What_save.RowCount + 1; i++)
            {
                for (int j = 1; j < What_save.ColumnCount +1; j++)
                {
                    worksheet.Rows[i].Columns[j] = What_save.Rows[i - 1].Cells[j - 1].Value;

                }
            }
            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Visible = true;
         
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            SaveTable(dataGridView1);

        }
        private void button2_Click(object sender, EventArgs e)
        {
                Form4 f4 = new Form4();
            dataGridView1.Rows.Add(textBox1.Text, textBox33.Text);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            dataGridView1.Rows.Add("1" , textBox1.Text, textBox33.Text, "A");
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("2" , textBox2.Text, textBox35.Text, "A");
            dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("3", textBox3.Text, textBox34.Text, "A");
            dataGridView1.Rows[2].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("4", textBox4.Text, textBox36.Text, "A");
            dataGridView1.Rows[3].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("5", textBox5.Text, textBox37.Text, "B");
            dataGridView1.Rows[4].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("6", textBox6.Text, textBox38.Text, "B");
            dataGridView1.Rows[5].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("7", textBox7.Text, textBox39.Text, "B");
            dataGridView1.Rows[6].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("8", textBox8.Text, textBox40.Text, "B");
            dataGridView1.Rows[7].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("9", textBox9.Text, textBox41.Text, "C");
            dataGridView1.Rows[8].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("10", textBox10.Text, textBox42.Text, "C");
            dataGridView1.Rows[9].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("11", textBox11.Text, textBox43.Text, "C");
            dataGridView1.Rows[10].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("12", textBox12.Text, textBox44.Text, "C");
            dataGridView1.Rows[11].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("13", textBox13.Text, textBox45.Text, "D");
            dataGridView1.Rows[12].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("14", textBox14.Text, textBox46.Text, "D");
            dataGridView1.Rows[13].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("15", textBox15.Text, textBox47.Text, "D");
            dataGridView1.Rows[14].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("16", textBox16.Text, textBox48.Text, "D");
            dataGridView1.Rows[15].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("17", textBox17.Text, textBox49.Text, "E");
            dataGridView1.Rows[16].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("18", textBox18.Text, textBox50.Text, "E");
            dataGridView1.Rows[17].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("19", textBox19.Text, textBox51.Text, "E");
            dataGridView1.Rows[18].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("20", textBox20.Text, textBox52.Text, "E");
            dataGridView1.Rows[19].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("21", textBox21.Text, textBox53.Text, "F");
            dataGridView1.Rows[20].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("22", textBox22.Text, textBox54.Text, "F");
            dataGridView1.Rows[21].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("23", textBox23.Text, textBox55.Text, "F");
            dataGridView1.Rows[22].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("24", textBox24.Text, textBox56.Text, "F");
            dataGridView1.Rows[23].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("25", textBox25.Text, textBox57.Text, "G");
            dataGridView1.Rows[24].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("26", textBox26.Text, textBox58.Text, "G");
            dataGridView1.Rows[25].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("27", textBox27.Text, textBox59.Text, "G");
            dataGridView1.Rows[26].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("28", textBox28.Text, textBox60.Text, "G");
            dataGridView1.Rows[27].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("29", textBox29.Text, textBox61.Text, "H");
            dataGridView1.Rows[28].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("30", textBox30.Text, textBox62.Text, "H");
            dataGridView1.Rows[29].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("31", textBox31.Text, textBox63.Text, "H");
            dataGridView1.Rows[30].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("32", textBox32.Text, textBox64.Text, "H");
            dataGridView1.Rows[31].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("33", textBox171.Text, textBox172.Text, "I");
            dataGridView1.Rows[32].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("34", textBox178.Text, textBox177.Text, "I");
            dataGridView1.Rows[33].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("35", textBox182.Text, textBox181.Text, "I");
            dataGridView1.Rows[34].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("36", textBox186.Text, textBox185.Text, "I");
            dataGridView1.Rows[35].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("37", textBox190.Text, textBox189.Text, "J");
            dataGridView1.Rows[36].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("38", textBox194.Text, textBox193.Text, "J");
            dataGridView1.Rows[37].DefaultCellStyle.BackColor = Color.MediumTurquoise;

            dataGridView1.Rows.Add("39", textBox198.Text, textBox197.Text, "J");
            dataGridView1.Rows[38].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            dataGridView1.Rows.Add("40", textBox202.Text, textBox201.Text, "J");
            dataGridView1.Rows[39].DefaultCellStyle.BackColor = Color.MediumTurquoise;
            dataGridView1.Rows[40].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            timer1.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
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
               
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
