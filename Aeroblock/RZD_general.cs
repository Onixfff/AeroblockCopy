using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Aeroblock
{
    public partial class RZD_general : Form
    {
        MySqlConnection mCon;
        string conn;
        public RZD_general(string con)
        {
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }
   
       
        private void picker()
        {
            var mounth = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var date = new DateTime(year, mounth, 1);
            int days = DateTime.DaysInMonth(year, mounth);
            var date2 = new DateTime(year, mounth, days);
            dateTimePicker_start.Text = date.ToString();
            dateTimePicker_finish.Text = date2.ToString();
        }
        private void update()
        {
            string sql = ("SELECT * FROM vagon_vihod where status_stop=0 ORDER BY id DESC");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].HeaderText = "№ п/п";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "№ Заявки";
            dataGridView1.Columns[2].HeaderText = "№ Вагона";
            dataGridView1.Columns[3].HeaderText = "Отправитель";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].HeaderText = "Получатель";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].HeaderText = "Дата отправления";
            dataGridView1.Columns[6].HeaderText = "Материал";
            dataGridView1.Columns[7].HeaderText = "Вес вагона, кг";
            dataGridView1.Columns[8].HeaderText = "Дата прихода на станцию";
            dataGridView1.Columns[9].HeaderText = "Статус прихода на станцию";
            dataGridView1.Columns[9].Width = 60;
            dataGridView1.Columns[10].HeaderText = "Партия разгрузки";
            dataGridView1.Columns[11].HeaderText = "Дата постановки на разгрузку";
            dataGridView1.Columns[13].HeaderText = "Статус постановки на разгрузку";
            dataGridView1.Columns[12].HeaderText = "Дата окончания выгрузки";
            dataGridView1.Columns[14].HeaderText = "Статус окончания выгрузки";
            dataGridView1.Columns[15].HeaderText = "№ силоса";
            dataGridView1.Columns[15].Width = 60;
            dataGridView1.Columns[16].HeaderText = "Время выгрузки партии";
            dataGridView1.Columns[16].Width = 60;
            dataGridView1.Columns[17].HeaderText = "Время выгрузки вагона";

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void CloseCon()
        {
            if (mCon.State == ConnectionState.Open)
            {
                mCon.Close();
            }
        }
        private void OpenCon()
        {
            if (mCon.State == ConnectionState.Closed)
            {
                mCon.Open();
            }
        }
        private void sum()
        {
            //DateTime now = DateTime.Now();
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd HH-mm");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd HH-mm");
            try
            {
                OpenCon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string selectCmd = "SELECT COUNT(*)   FROM vagon_vihod WHERE prihod='0' and status_start='0' and status_stop='0'  ";
            MySqlCommand cmd = new MySqlCommand(selectCmd, mCon);
            string result1 = cmd.ExecuteScalar().ToString();
            label8.Text = ("Вагоны в пути  " + result1);

            string selectCmd2 = "SELECT COUNT(*)   FROM vagon_vihod WHERE prihod='1' and status_start='0' and status_stop='0'  ";
            MySqlCommand cmd2 = new MySqlCommand(selectCmd2, mCon);
            string result2 = cmd2.ExecuteScalar().ToString();
            label9.Text = ("Вагоны на станции  " + result2);

            string selectCmd3 = "SELECT COUNT(*)   FROM vagon_vihod WHERE prihod='1' and status_start='1' and status_stop='0'  ";
            MySqlCommand cmd3 = new MySqlCommand(selectCmd3, mCon);
            string result3 = cmd3.ExecuteScalar().ToString();
            label10.Text = ("Вагоны на разгрузке  " + result3);


            string selectCmd4 = "SELECT COUNT(*)   FROM vagon_vihod WHERE data_finish  >= '" + start + "' and  data_finish <= '" + finish + "'  ";
            MySqlCommand cmd4 = new MySqlCommand(selectCmd4, mCon);
            string result4 = cmd4.ExecuteScalar().ToString();
            label11.Text = ("Разгружено вагонов  " + result4);




            string selectCmd5 = "  SELECT SUM(weight) FROM vagon_vihod WHERE data_finish  >= '" + start + "' and  data_finish <= '" + finish + "'  ";
            MySqlCommand cmd5 = new MySqlCommand(selectCmd5, mCon);
            string result5 = cmd5.ExecuteScalar().ToString();
            double mas;
            double.TryParse(result5, out mas);
            label12.Text = ("Разгружено тонн  " + mas / 1000);
        }

        private void RZD_general_Load(object sender, EventArgs e)
        {
            picker();
            sum();
            comboBox1.Text = "Все";
            //string sql = ("SELECT * FROM vagon_vihod where `date` >= DATE_SUB(now(),Interval 2 MONTH) ORDER BY id DESC");
            update();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex <= dataGridView1.RowCount - 1)
                //вагон на станции            
                if (dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() == "True")//сравнение что вагон на станции
                    if (dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString() == "False")//сравнение вагон на разгрузке
                        if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "False")//сравнение вагон разгружен
                            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            //вагон на разгрузке
            if (dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() == "True")//сравнение что вагон на станции
                if (dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString() == "True")//сравнение вагон на разгрузке
                    if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "False")//сравнение вагон разгружен
                        ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            //вагон разгружен
            if (dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() == "True")//сравнение что вагон на станции
                if (dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString() == "True")//сравнение вагон на разгрузке
                    if (dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString() == "True")//сравнение вагон разгружен
                        ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Method();
        }
        private void Method()
        {
            string rt = comboBox1.SelectedItem.ToString();
            if (rt == "Вагоны на станции")
            {
                string sql = ("SELECT * FROM vagon_vihod WHERE prihod='1' and status_start='0' and status_stop='0' ORDER BY id DESC ");
                MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                DataSet ds = new DataSet();
                ds.Reset();
                dD.Fill(ds, sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (rt == "Вагоны в пути")
            {
                string sql = ("SELECT * FROM vagon_vihod WHERE prihod='0' and status_start='0' and status_stop='0' ORDER BY id DESC  ");
                MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                DataSet ds = new DataSet();
                ds.Reset();
                dD.Fill(ds, sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (rt == "Вагоны на рагзрузке")
            {
                string sql = ("SELECT * FROM vagon_vihod WHERE prihod='1' and status_start='1' and status_stop='0'  ORDER BY id DESC");
                MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                DataSet ds = new DataSet();
                ds.Reset();
                dD.Fill(ds, sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (rt == "Вагоны рагруженные")
            {
                string sql = ("SELECT * FROM vagon_vihod WHERE prihod='1' and status_start='1' and status_stop='1' ORDER BY id DESC  ");
                MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                DataSet ds = new DataSet();
                ds.Reset();
                dD.Fill(ds, sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (rt == "Все")
            {
                string sql = ("SELECT * FROM vagon_vihod  ORDER BY id DESC  ");
                MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                DataSet ds = new DataSet();
                ds.Reset();
                dD.Fill(ds, sql);
                dataGridView1.DataSource = ds.Tables[0];
            }

        }

        private void dateTimePicker_start_ValueChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void dateTimePicker_finish_ValueChanged(object sender, EventArgs e)
        {
            sum();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            picker();
        }
    }
}
