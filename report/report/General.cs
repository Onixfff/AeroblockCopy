﻿//#define OLD
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace report
{
    public partial class General : Form
    {
        //MySqlConnection mCon = new MySqlConnection("Database=spslogger; Server=192.168.37.101; port=3306; username=%user_1; password=20112004; charset=utf8 ");
        private MySqlConnection _mCon = new MySqlConnection(ConfigurationManager.ConnectionStrings["localPc"].ConnectionString);
        //MySqlConnection mCon = new MySqlConnection("Database=spslogger; Server=localhost; port=3306; username=root; password=20112004; charset=utf8 ");
        //MySqlConnection mCon = new MySqlConnection("Database=spslogger; Server=localhost; port=3306; username=sss_root; password=12345; charset=utf8;SslMode=none;Allow User Variables=True ");
        MySqlCommand msd;
        public General()
        {
            InitializeComponent();
        }
        private void CloseCon()
        {
            if (_mCon.State == ConnectionState.Open)
            {
                _mCon.Close();
            }
        }
        private void OpenCon()
        {
            if (_mCon.State == ConnectionState.Closed)
            {
                try
                {
                    _mCon.Open();
                }
                catch (MySqlException ex)
                {
                    if (_mCon.State != ConnectionState.Open) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Нет соединения с сервером... попробуйте позже");
                    //return;
                }
            }
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

        private void picker(int mounth)
        {
            //var mounth = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var date = new DateTime(year, mounth, 1);
            int days = DateTime.DaysInMonth(year, mounth);
            var date2 = new DateTime(year, mounth, days);
            dateTimePicker_start.Text = date.ToString();
            dateTimePicker_finish.Text = date2.ToString();
        }

        private void update_report()
        {
            string sh = textBox1.Text.ToString();
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");
#if OLD
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and(if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\")," +
 "date_format(Timestamp, \"%d %M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(ms.data_err, \"%d %M %Y\")))" +
"and(if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь'))= (if (time(ms.data_err) <= '20:00:00' and time(ms.data_err)>= '08:00:00','день','ночь'))) as brak";
            string sql = "SELECT if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(Timestamp, \"%d %M %Y\")) as df," +
                "if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь') as shift, data_52," +
                "min(dbid) as min, max(dbid) as max, count(dbid) as count_1, round((count(dbid) * '4.32'), 2) as mas, sum(data_23) as Lime_1," +
"sum(data_25) as Lime_2,  (sum(data_23) + sum(data_25)) as Lime_sum," +
"sum(data_27) as Cement_1, sum(data_29) as Cement_2," +
"(sum(data_27) + sum(data_29)) as Cement_sum," +
"sum(data_116) as Gips, round(sum(data_181), 1) as Sand, round(sum(data_162), 1) as Additive," +
"round((sum(data_193) + sum(data_199)), 2) as alum, round((count(dbid) * '4.32' * '" + sh + "'), 2) as drob, "+sql2+" " +
""+
  "from spslogger.mixreport as mr where Timestamp >= '"+start+ " 08:00:00' and Timestamp < concat( date_add('"+finish+"', interval 1 day), ' 08:00:00')  group by df,shift, data_52";
#else
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and(if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\")," +
             "date_format(Timestamp, \"%d %M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(ms.data_err, \"%d %M %Y\")))" +
            "and(if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь'))= (if (time(ms.data_err) <= '20:00:00' and time(ms.data_err)>= '08:00:00','день','ночь'))) as brak";
            string sql3 = "(select ifnull(sum(sum_er),0) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and(if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\")," +
"date_format(Timestamp, \"%d %M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(ms.data_err, \"%d %M %Y\")))" +
"and(if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь'))= (if (time(ms.data_err) <= '20:00:00' and time(ms.data_err)>= '08:00:00','день','ночь')))";
            string sql = "SELECT if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(Timestamp, \"%d %M %Y\")) as df," +
                "if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь') as shift, data_52," +
                "min(dbid) as min, max(dbid) as max, count(dbid)-" + sql3 + " as count_1, round(((count(dbid)-" + sql3 + ") * '4.32'), 2) as mas, sum(data_23) as Lime_1," +
"sum(data_25) as Lime_2,  (sum(data_23) + sum(data_25)) as Lime_sum," +
"sum(data_27) as Cement_1, sum(data_29) as Cement_2," +
"(sum(data_27) + sum(data_29)) as Cement_sum," +
"sum(data_116) as Gips, round(sum(data_181), 1) as Sand, round(sum(data_162), 1) as Additive," +
"round((sum(data_193) + sum(data_199)), 2) as alum, round((count(dbid) * '4.32' * '" + sh + "'), 2) as drob, " + sql2 + " " +
"" +
  "from spslogger.mixreport as mr where Timestamp >= '" + start + " 08:00:00' and Timestamp < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by df,shift, data_52";
#endif
            // string sql = ("SELECT * FROM spslogger.configtable;");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, _mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.AutoResizeColumns();
            dataGridView1.Columns["df"].HeaderText = "Дата";
            dataGridView1.Columns["Lime_1"].Visible = false;
            dataGridView1.Columns["Lime_2"].Visible = false;
            dataGridView1.Columns["Cement_1"].Visible = false;
            dataGridView1.Columns["Cement_2"].Visible = false;
            dataGridView1.Columns["shift"].HeaderText = "смена";
            dataGridView1.Columns["count_1"].HeaderText = "Кол-во массивов";
            dataGridView1.Columns["mas"].HeaderText = "м.куб";
            dataGridView1.Columns["Lime_sum"].HeaderText = "Известь, кг";
            dataGridView1.Columns["Lime_sum"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Cement_sum"].HeaderText = "Цемент, кг";
            dataGridView1.Columns["Cement_sum"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Gips"].HeaderText = "Гипс, кг";
            dataGridView1.Columns["Sand"].HeaderText = "Песок, кг";
            dataGridView1.Columns["Additive"].HeaderText = "Добавка, кг";
            dataGridView1.Columns["alum"].HeaderText = "Алюминий, кг";
            dataGridView1.Columns["drob"].HeaderText = "Шары мелющие, кг";
            dataGridView1.Columns["brak"].HeaderText = "Шламовые массивы";


            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                if (item.Cells[1].Value.ToString() == "ночь")
                {
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else item.DefaultCellStyle.BackColor = Color.LightYellow;


            }
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void update_report_sm()
        {
            string sh = textBox1.Text.ToString();
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and(if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\")," +
"date_format(Timestamp, \"%d %M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(ms.data_err, \"%d %M %Y\")))" +
"and(if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь'))= (if (time(ms.data_err) <= '20:00:00' and time(ms.data_err)>= '08:00:00','день','ночь'))) as brak";
            string sql = "SELECT if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(Timestamp, \"%d %M %Y\")) as df," +
                "if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь') as shift, " +
                "min(dbid) as min, max(dbid) as max, count(dbid) as count_1, round((count(dbid) * '4.32'), 2) as mas, sum(data_23) as Lime_1," +
"sum(data_25) as Lime_2,  (sum(data_23) + sum(data_25)) as Lime_sum," +
"sum(data_27) as Cement_1, sum(data_29) as Cement_2," +
"(sum(data_27) + sum(data_29)) as Cement_sum," +
"sum(data_116) as Gips, round(sum(data_181), 1) as Sand, round(sum(data_162), 1) as Additive," +
"round((sum(data_193) + sum(data_199)), 2) as alum, round((count(dbid) * '4.32' * '" + sh + "'), 2) as drob, "+sql2+" " +
  "from spslogger.mixreport as mr where Timestamp >= '" + start + " 08:00:00' and Timestamp < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by df,shift ";

            // string sql = ("SELECT * FROM spslogger.configtable;");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, _mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.AutoResizeColumns();
            //dataGridView1.Columns["data_52"].HeaderText = "Наименование рецепта";
            dataGridView1.Columns["df"].HeaderText = "Дата";
            dataGridView1.Columns["Lime_1"].Visible = false;
            dataGridView1.Columns["Lime_2"].Visible = false;
            dataGridView1.Columns["Cement_1"].Visible = false;
            dataGridView1.Columns["Cement_2"].Visible = false;
            dataGridView1.Columns["shift"].HeaderText = "смена";
            dataGridView1.Columns["count_1"].HeaderText = "Кол-во массивов";
            dataGridView1.Columns["mas"].HeaderText = "м.куб";
            dataGridView1.Columns["Lime_sum"].HeaderText = "Известь, кг";
            dataGridView1.Columns["Lime_sum"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Cement_sum"].HeaderText = "Цемент, кг";
            dataGridView1.Columns["Cement_sum"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Gips"].HeaderText = "Гипс, кг";
            dataGridView1.Columns["Sand"].HeaderText = "Песок, кг";
            dataGridView1.Columns["Additive"].HeaderText = "Добавка, кг";
            dataGridView1.Columns["alum"].HeaderText = "Алюминий, кг";
            dataGridView1.Columns["drob"].HeaderText = "Шары мелющие, кг";
            dataGridView1.Columns["brak"].HeaderText = "Шламовые массивы";


            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[1].Value.ToString() == "ночь")
                {
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else item.DefaultCellStyle.BackColor = Color.LightYellow;
            }


            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void update_report_month()
        {
            string sh = textBox1.Text.ToString();
            string finish = dateTimePicker_finish.Value.ToString("yyyy");
            string start = dateTimePicker_start.Value.ToString("yyyy");
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and(if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%M %Y\")," +
"date_format(Timestamp, \"%M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%M %Y\"),date_format(ms.data_err, \"%M %Y\")))" +
"and(if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь'))= (if (time(ms.data_err) <= '20:00:00' and time(ms.data_err)>= '08:00:00','день','ночь'))) as brak";
            string sql = "SELECT if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%M %Y\"),date_format(Timestamp, \"%M %Y\")) as df," +
                " " +
                "min(dbid) as min, max(dbid) as max, count(dbid) as count_1, round((count(dbid) * '4.32'), 2) as mas, sum(data_23) as Lime_1," +
"sum(data_25) as Lime_2,  (sum(data_23) + sum(data_25)) as Lime_sum," +
"sum(data_27) as Cement_1, sum(data_29) as Cement_2," +
"(sum(data_27) + sum(data_29)) as Cement_sum," +
"sum(data_116) as Gips, round(sum(data_181), 1) as Sand, round(sum(data_162), 1) as Additive," +
"round((sum(data_193) + sum(data_199)), 2) as alum, round((count(dbid) * '4.32' * '" + sh + "'), 2) as drob, " + sql2 + " " +
  "from spslogger.mixreport as mr where Timestamp >= '" + start + " 08:00:00'  group by df order by min ";

            // string sql = ("SELECT * FROM spslogger.configtable;");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, _mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.AutoResizeColumns();
            //dataGridView1.Columns["data_52"].HeaderText = "Наименование рецепта";
            dataGridView1.Columns["df"].HeaderText = "Дата";
            dataGridView1.Columns["Lime_1"].Visible = false;
            dataGridView1.Columns["Lime_2"].Visible = false;
            dataGridView1.Columns["Cement_1"].Visible = false;
            dataGridView1.Columns["Cement_2"].Visible = false;
           // dataGridView1.Columns["shift"].HeaderText = "смена";
            dataGridView1.Columns["count_1"].HeaderText = "Кол-во массивов";
            dataGridView1.Columns["mas"].HeaderText = "м.куб";
            dataGridView1.Columns["Lime_sum"].HeaderText = "Известь, кг";
            dataGridView1.Columns["Lime_sum"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Cement_sum"].HeaderText = "Цемент, кг";
            dataGridView1.Columns["Cement_sum"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Gips"].HeaderText = "Гипс, кг";
            dataGridView1.Columns["Sand"].HeaderText = "Песок, кг";
            dataGridView1.Columns["Additive"].HeaderText = "Добавка, кг";
            dataGridView1.Columns["alum"].HeaderText = "Алюминий, кг";
            dataGridView1.Columns["drob"].HeaderText = "Шары мелющие, кг";
            dataGridView1.Columns["brak"].HeaderText = "Шламовые массивы";


            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                if (item.Cells[1].Value.ToString() == "ночь")
                {
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else item.DefaultCellStyle.BackColor = Color.LightYellow;
            }


            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }


        private void update_report_su()
        {
            string sh = textBox1.Text.ToString();
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where (if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\")," +
"date_format(Timestamp, \"%d %M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(ms.data_err, \"%d %M %Y\"))))" +
" as brak";
            //string sql3 = "(select ifnull(sum(sum_er),0) as brak from spslogger.error_mas as ms where (if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\")," +
            //"date_format(Timestamp, \"%d %M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(ms.data_err, \"%d %M %Y\"))))";
            string sql = "SELECT if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(Timestamp, \"%d %M %Y\")) as df," +
                "if (time(Timestamp) <= '20:00:00' and time(Timestamp)>= '08:00:00','день','ночь') as shift, " +
                "min(dbid) as min, max(dbid) as max, count(dbid) as count_1, round((count(dbid) * '4.32'), 2) as mas, sum(data_23) as Lime_1," +
"sum(data_25) as Lime_2,  (sum(data_23) + sum(data_25)) as Lime_sum," +
"sum(data_27) as Cement_1, sum(data_29) as Cement_2," +
"(sum(data_27) + sum(data_29)) as Cement_sum," +
"sum(data_116) as Gips, round(sum(data_181), 1) as Sand, round(sum(data_162), 1) as Additive," +
"round((sum(data_193) + sum(data_199)), 2) as alum, round((count(dbid) * '4.32' * '" + sh + "'), 2) as drob, "+sql2+" " +
  "from spslogger.mixreport as mr where Timestamp >= '" + start + " 08:00:00' and Timestamp < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by df";

            // string sql = ("SELECT * FROM spslogger.configtable;");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, _mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.AutoResizeColumns();
            //dataGridView1.Columns["data_52"].HeaderText = "Наименование рецепта";
            dataGridView1.Columns["df"].HeaderText = "Дата";
            dataGridView1.Columns["Lime_1"].Visible = false;
            dataGridView1.Columns["Lime_2"].Visible = false;
            dataGridView1.Columns["Cement_1"].Visible = false;
            dataGridView1.Columns["Cement_2"].Visible = false;
            dataGridView1.Columns["shift"].HeaderText = "смена";
            dataGridView1.Columns["shift"].Visible = false;
            dataGridView1.Columns["count_1"].HeaderText = "Кол-во массивов";
            dataGridView1.Columns["mas"].HeaderText = "м.куб";
            dataGridView1.Columns["Lime_sum"].HeaderText = "Известь, кг";
            dataGridView1.Columns["Lime_sum"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Cement_sum"].HeaderText = "Цемент, кг";
            dataGridView1.Columns["Cement_sum"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Gips"].HeaderText = "Гипс, кг";
            dataGridView1.Columns["Sand"].HeaderText = "Песок, кг";
            dataGridView1.Columns["Additive"].HeaderText = "Добавка, кг";
            dataGridView1.Columns["alum"].HeaderText = "Алюминий, кг";
            dataGridView1.Columns["drob"].HeaderText = "Шары мелющие, кг";
            dataGridView1.Columns["brak"].HeaderText = "Шламовые массивы";


            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                if (item.Cells[1].Value.ToString() == "ночь")
                {
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else item.DefaultCellStyle.BackColor = Color.LightYellow;
            }


            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void update_sum()

        {
            string sh = textBox1.Text.ToString();
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");
#if OLD
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and  ms.data_err >= '" + start + " 08:00:00' and ms.data_err < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')" +
") as brak";
            string sql_sub = "(select sum(sum_er) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and ms.data_err >= '" + start + " 08:00:00' and ms.data_err < concat(date_add('" + finish + "', interval 1 day), ' 08:00:00')" +
") ";

            string sql = "SELECT data_52, count(dbid) as count_1, round((count(dbid)* '4.32'), 2) as mas," +
  //"concat((sum(data_23) + sum(data_25)),  ' - ', (round((((sum(data_23) + sum(data_25)) / (count(dbid) * '4.32'))), 1))) as Lime_sum," +
  "concat(cast(sum(data_23) + sum(data_25) as char(10)),  ' / ', (round((((sum(data_23) + sum(data_25)) / (count(dbid) * '4.32'))), 1))) as Lime_sum," +
 //"concat((sum(data_27) + sum(data_29)), ' / ', (round((((sum(data_27) + sum(data_29)) / (count(dbid) * '4.32'))), 1))) as Cement_sum,  concat((round(sum(data_116), 1)), ' / ', (round((sum(data_116) / count(dbid) / '4.32'), 1))) as Gips," + 
 "concat(cast(sum(data_27) + sum(data_29) as char(10)), ' / ', (round((((sum(data_27) + sum(data_29)) / (count(dbid) * '4.32'))), 1))) as Cement_sum,  concat(cast(round(sum(data_116), 1) as char(10)), ' / ', (round((sum(data_116) / count(dbid) / '4.32'), 1))) as Gips," +
  //"concat((round(sum(data_181), 1)), ' / ', (round((sum(data_181) / count(dbid) / '4.32'), 1))) as Sand, " +
  "concat(cast(round(sum(data_181), 1) as char(10)), ' / ', (round((sum(data_181) / count(dbid) / '4.32'), 1))) as Sand, " +
//"concat((round(sum(data_162), 3)), ' / ', (round((sum(data_162) / count(dbid) / '4.32'), 1))) as Additive, concat((round((sum(data_193) + sum(data_199)), 2)), ' / ', (round(((sum(data_193) + sum(data_199)) / count(dbid) / '4.32'), 2))) as alum," +
"concat(cast(round(sum(data_162), 3) as char(10)), ' / ', (round((sum(data_162) / count(dbid) / '4.32'), 1))) as Additive, concat(cast(round((sum(data_193) + sum(data_199)), 2) as char(10)), ' / ', (round(((sum(data_193) + sum(data_199)) / count(dbid) / '4.32'), 2))) as alum," +
//"concat((round((count(dbid) * '4.32' * '"+sh+ "'), 2)), ' / ', '" + sh + "') as drob from spslogger.mixreport where  Timestamp >= '" + start + " 08:00:00' and Timestamp < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')   group by data_52";
"concat(cast(round((count(dbid) * '4.32' * '" + sh + "'), 2) as char(10)), ' / ', '" + sh + "') as drob, " + sql2 + " from spslogger.mixreport as mr where  Timestamp >= '" + start + " 08:00:00' and Timestamp < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')   group by data_52"; 
#else
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and ms.data_err >= '" + start + " 08:00:00' and ms.data_err < concat(date_add('" + finish + "', interval 1 day), ' 08:00:00')" +
") as brak";
            string sql3 = "(select ifnull(sum(sum_er),0) as brak from spslogger.error_mas as ms where mr.data_52 = ms.recepte and ms.data_err >= '" + start + " 08:00:00' and ms.data_err < concat(date_add('" + finish + "', interval 1 day), ' 08:00:00')" +
") ";
            string sql = "SELECT data_52, (count(dbid)-" + sql3 + ") as count_1, round((count(dbid-" + sql3 + ")* '4.32'), 2) as mas," +
                 "concat(cast(sum(data_23) + sum(data_25) as char(10)),  ' / ', (round((((sum(data_23) + sum(data_25)) / (count(dbid-" + sql3 + ") * '4.32'))), 1))) as Lime_sum," +
                 "concat(cast(sum(data_27) + sum(data_29) as char(10)), ' / ', (round((((sum(data_27) + sum(data_29)) / (count(dbid-" + sql3 + ") * '4.32'))), 1))) as Cement_sum,  concat(cast(round(sum(data_116), 1) as char(10)), ' / ', (round((sum(data_116) / count(dbid-" + sql3 + ") / '4.32'), 1))) as Gips," +
                 "concat(cast(round(sum(data_181), 1) as char(10)), ' / ', (round((sum(data_181) / count(dbid-" + sql3 + ") / '4.32'), 1))) as Sand, " +
                 "concat(cast(round(sum(data_162), 3) as char(10)), ' / ', (round((sum(data_162) / count(dbid-" + sql3 + ") / '4.32'), 1))) as Additive, concat(cast(round((sum(data_193) + sum(data_199)), 2) as char(10)), ' / ', (round(((sum(data_193) + sum(data_199)) / count(dbid-" + sql3 + ") / '4.32'), 2))) as alum," +
                 "concat(cast(round((count(dbid) * '4.32' * '" + sh + "'), 2) as char(10)), ' / ', '" + sh + "') as drob, " + sql2 + " from spslogger.mixreport as mr where  Timestamp >= '" + start + " 08:00:00' and Timestamp < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')   group by data_52";
#endif

            //string sql = ("call spslogger.new_procedure()");
            try
            {
                if(_mCon.State == ConnectionState.Closed)
                    _mCon.Open();
                
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, _mCon))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    dataGridView2.Columns["data_52"].HeaderText = "Наименование рецепта";
                    dataGridView2.Columns["data_52"].DisplayIndex = 0;
                    dataGridView2.Columns["count_1"].HeaderText = "Кол-во массивов";
                    dataGridView2.Columns["mas"].HeaderText = "м.куб";
                    dataGridView2.Columns["Lime_sum"].HeaderText = "Известь, кг";
                    dataGridView2.Columns["Lime_sum"].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns["Cement_sum"].HeaderText = "Цемент, кг";
                    dataGridView2.Columns["Cement_sum"].DefaultCellStyle.Format = "N2";
                    dataGridView2.Columns["Gips"].HeaderText = "Гипс, кг";
                    dataGridView2.Columns["Sand"].HeaderText = "Песок, кг";
                    dataGridView2.Columns["Additive"].HeaderText = "Добавка, кг";
                    dataGridView2.Columns["alum"].HeaderText = "Алюминий, кг";
                    dataGridView2.Columns["drob"].HeaderText = "Шары мелющие, кг";
                    dataGridView2.Columns["brak"].HeaderText = "Шламовые массивы";
                }
            }
            catch (MySqlException ex)
            {
                // Handle exceptions
                Console.WriteLine(ex.Message);
            }

        }

        private void update_sum_2()
        {
            string sh = textBox1.Text.ToString();
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where ms.data_err >= '" + start + " 08:00:00' and ms.data_err < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')" +
") as brak";
            string sql3 = "(select ifnull(sum(sum_er),0) as brak from spslogger.error_mas as ms where ms.data_err >= '"+start+" 08:00:00' and ms.data_err < concat( date_add('" + finish+"', interval 1 day), ' 08:00:00'))";
            //            string sql = " select count(dbid) as count_1, round((count(dbid) * '4.32'), 1) as mas," +
            //  "concat((sum(data_23) + sum(data_25)), ' / ', (round((((sum(data_23) + sum(data_25)) / (count(dbid) * '4.32'))), 1))) as Lime_sum," +
            //"concat((sum(data_27) + sum(data_29)), ' / ', (round((((sum(data_27) + sum(data_29)) / (count(dbid) * '4.32'))), 1))) as Cement_sum,  concat((round(sum(data_116), 1)), ' / ', (round((sum(data_116) / count(dbid) / '4.32'), 1))) as Gips," +
            // "concat((round(sum(data_181), 1)), ' / ', (round((sum(data_181) / count(dbid) / '4.32'), 1))) as Sand, " +
            //"concat((round(sum(data_162), 3)), ' / ', (round((sum(data_162) / count(dbid) / '4.32'), 1))) as Additive, concat((round((sum(data_193) + sum(data_199)), 2)), ' / ', (round(((sum(data_193) + sum(data_199)) / count(dbid) / '4.32'), 2))) as alum," +
            //"concat((round((count(dbid) * '4.32' * '" + sh + "'), 2)), ' / ', '" + sh + "') as drob from spslogger.mixreport where  Timestamp >= '" + start + " 08:00:00' and Timestamp < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00') "  ;
            string sql = " select (count(dbid)-"+sql3+ ") as count_1, round(((count(dbid)-" + sql3 + ") * '4.32'), 2) as mas," +
  "concat(cast(sum(data_23) + sum(data_25) as char(10)), ' / ', (round((((sum(data_23) + sum(data_25)) / ((count(dbid)-" + sql3 + ") * '4.32'))), 1))) as Lime_sum," +
"concat(cast(sum(data_27) + sum(data_29) as char(10)), ' / ', (round((((sum(data_27) + sum(data_29)) / ((count(dbid)-" + sql3 + ") * '4.32'))), 1))) as Cement_sum, " +
" concat(cast(round(sum(data_116), 1) as char(10)), ' / ', (round((sum(data_116) / (count(dbid)-" + sql3 + ") / '4.32'), 1))) as Gips," +
 "concat(cast(round(sum(data_181), 1) as char(10)), ' / ', (round((sum(data_181) / (count(dbid)-" + sql3 + ") / '4.32'), 1))) as Sand, " +
"concat(cast(round(sum(data_162), 3) as char(10)), ' / ', (round((sum(data_162) / (count(dbid)-" + sql3 + ") / '4.32'), 1))) as Additive, " +
"concat(cast(round((sum(data_193) + sum(data_199)), 2) as char(10)), ' / ', (round(((sum(data_193) + sum(data_199)) / (count(dbid)-" + sql3 + ") / '4.32'), 2))) as alum," +
"concat(cast(round(((count(dbid)-" + sql3 + ") * '4.32' * '" + sh + "'), 2) as char(10)), ' / ', '" + sh + "') as drob, "+sql2+" from spslogger.mixreport as mr where " +
" Timestamp >= '" + start + " 08:00:00' and Timestamp < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00') ";
            // string sql = ("SELECT * FROM spslogger.configtable;");
            try
            {
                if (_mCon.State == ConnectionState.Closed)
                    _mCon.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, _mCon))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView3.DataSource = ds.Tables[0];
                    dataGridView3.Columns["count_1"].HeaderText = "Кол-во массивов";
                    dataGridView3.Columns["mas"].HeaderText = "м.куб";
                    dataGridView3.Columns["Lime_sum"].HeaderText = "Известь, кг";
                    dataGridView3.Columns["Lime_sum"].DefaultCellStyle.Format = "N2";
                    dataGridView3.Columns["Cement_sum"].HeaderText = "Цемент, кг";
                    dataGridView3.Columns["Cement_sum"].DefaultCellStyle.Format = "N2";
                    dataGridView3.Columns["Gips"].HeaderText = "Гипс, кг";
                    dataGridView3.Columns["Sand"].HeaderText = "Песок, кг";
                    dataGridView3.Columns["Additive"].HeaderText = "Добавка, кг";
                    dataGridView3.Columns["alum"].HeaderText = "Алюминий, кг";
                    dataGridView3.Columns["drob"].HeaderText = "Шары мелющие, кг";
                    dataGridView3.Columns["brak"].HeaderText = "Шламовые массивы";
                }
            }
            catch (MySqlException ex)
            {
                // Handle exceptions
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView_Formatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            // Проверка, что это одна из интересующих колонок
            if ((dataGridView.Columns[e.ColumnIndex].Name == "Cement_sum" || dataGridView.Columns[e.ColumnIndex].Name == "Lime_sum" || dataGridView.Columns[e.ColumnIndex].Name == "Sand") && e.Value != null)
            {
                string originalValue = e.Value.ToString(); // Получаем исходное строковое значение
                if (originalValue.Contains('/')) // Проверяем, содержит ли строка символ '/'
                {
                    string[] parts = originalValue.Split('/'); // Разделяем строку по символу '/'
                    if (parts.Length > 1) // Убедимся, что после разделения у нас есть хотя бы две части
                    {
                        try
                        {
                            string firstPart = parts[0].Trim(); // Обрезаем пробелы в первой части
                            string secondPart = parts[1].Trim(); // Обрезаем пробелы во второй части

                            double number; // Для конвертации строки в число
                            if (double.TryParse(firstPart, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                            {
                                // Форматируем первую часть как число с двумя десятичными знаками
                                firstPart = string.Format("{0:N2}", number);
                            }
                            // Собираем строку обратно с отформатированной первой частью
                            e.Value = firstPart + " / " + secondPart;
                            e.FormattingApplied = true; // Указываем, что форматирование было применено
                        }
                        catch (FormatException)
                        {
                            e.FormattingApplied = false; // Если конвертация не удалась, форматирование не применяется
                        }
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = ("SELECT * FROM spslogger.configtable");
            //try
            //{
            picker();
            OpenCon();
            //    msd = new MySqlCommand(sql, mCon);
            //    if (msd.ExecuteNonQuery() >= 1)
            //    {
            update_report();
            update_sum();
            update_sum_2();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                if (item.Cells[1].Value.ToString() == "ночь")
                {
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else item.DefaultCellStyle.BackColor = Color.LightYellow;


            }



        }

        private void Button7_Click(object sender, EventArgs e)
        {
            picker();
            update_sum();
            update_report();
            update_sum_2();
        
    }

        private void DateTimePicker_start_ValueChanged(object sender, EventArgs e)
        {
            //update_sum();
            //update_report();
           
        }

        private void DataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{

            //    if (item.Cells[1].Value.ToString() == "ночь")
            //        item.DefaultCellStyle.BackColor = Color.LightBlue;

            //}
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            picker(1);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            picker(2);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            picker(3);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            picker(4);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            picker(5);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            picker(6);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            picker(7);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            picker(8);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            picker(9);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            picker(10);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            picker(11);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            picker(12);
            update_sum();
            update_report();
            update_sum_2();
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex < 0) return;
            //switch (dataGridView1.CurrentCell.Value.ToString())
            //{
            //    case "В пути": dataGridView1.CurrentCell.Style.BackColor = Color.Red; break;
            //    case "Отказ": dataGridView1.CurrentCell.Style.BackColor = Color.Yellow; break;
            //    default: return;
            //}
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            update_sum();
            update_report();
            update_sum_2();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            update_report_sm();

        }

        private void Button16_Click(object sender, EventArgs e)
        {
            update_report_su();

        }
        private void update_brak()
        {
            //string sh = textBox1.Text.ToString();
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");
            
            string sql = "SELECT *"+

  "from spslogger.error_mas where data_err >= '" + start + " 08:00:00' and data_err < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00') ";

            // string sql = ("SELECT * FROM spslogger.configtable;");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, _mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView1.DataSource = ds.Tables[0];
       
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["data_err"].HeaderText = "Дата";
            dataGridView1.Columns["data_err"].Width = 100;
            dataGridView1.Columns["recepte"].HeaderText = "Наименование рецепта";
            dataGridView1.Columns["recepte"].Width = 200;
            dataGridView1.Columns["sum_er"].HeaderText = "Кол-во массивов";
            dataGridView1.Columns["sum_er"].Width = 50;
            dataGridView1.Columns["comments"].HeaderText = "Причина";
            //dataGridView1.AutoResizeColumns();



            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{

            //    if (item.Cells[1].Value.ToString() == "ночь")
            //    {
            //        item.DefaultCellStyle.BackColor = Color.LightBlue;
            //    }
            //    else item.DefaultCellStyle.BackColor = Color.LightYellow;


            //}
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;




        }

        private void Button17_Click(object sender, EventArgs e)
        {
            update_brak();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            update_report_month();
        }

        private void ChangerColors(DataGridView dataGridView)
        {

            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                DataGridViewCell cell = item.Cells[1]; // Выбор ячейки по индексу
                
                if (cell.Value != null && item.Cells[1].Value.ToString() == "ночь")
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                else
                    item.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ChangerColors(dataGridView1);
        }
    }
}
