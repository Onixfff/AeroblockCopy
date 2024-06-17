using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Report_Silikat
{
    public partial class Report_mix : Form
    {
        String connectio_silikat = "Database=material_costumer_manufactur; datasource=192.168.100.100; port=3306; username=D_user; password=Aeroblock12345%; charset=utf8";
        MySqlConnection mCon;
        public Report_mix()
        {
            InitializeComponent();
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
                try
                {
                    mCon.Open();
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
        private void update_report_su()
        {
            
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");
            string sql2 = "(select sum(sum_er) as brak from spslogger.error_mas as ms where (if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\")," +
"date_format(Timestamp, \"%d %M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(ms.data_err, \"%d %M %Y\"))))" +
" as brak";
            //string sql3 = "(select ifnull(sum(sum_er),0) as brak from spslogger.error_mas as ms where (if (time(Timestamp) < '08:00:00',date_format(date_sub(Timestamp, INTERVAL 1 DAY), \"%d %M %Y\")," +
            //"date_format(Timestamp, \"%d %M %Y\")))= ( if (time(ms.data_err) < '08:00:00',date_format(date_sub(ms.data_err, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(ms.data_err, \"%d %M %Y\"))))";
            string sql = "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(report.id, \"%d %M %Y\")) as 'Дата', if (time(report.id) <= '20:00:00' and time(report.id)>= '08:00:00','день','ночь') as 'Смена'," +
                "recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id=silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'";

            string sql3 ="select if (time(id) < '08:00:00',date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(id, \"%d %M %Y\")) as df," +
                "if (time(id) <= '20:00:00' and time(id)>= '08:00:00','день','ночь') as shift, " +
                "(select recept.name from silikat.recept where recept.id = silikat.report.id_recept) as rec," +
                "(select material.name from material_costumer_manufactur.material where material.id = silikat.report.id_name_lime) as l," +
                "round(sum(actual_lime1), 2) as Lime," +
                "(select material.name from material_costumer_manufactur.material where material.id = silikat.report.idname_sand1) as s1," +
                "round(sum(actual_sand1), 2) as Sand1," +
                "(select material.name from material_costumer_manufactur.material where material.id = silikat.report.idname_sand2) as s2," +
                "round(sum(actual_sand2), 2) as Sand2" +
                " from silikat.report where report.id >= '" + start + " 08:00:00' and report.id < concat(date_add('" + finish + "', interval 1 day), ' 08:00:00')" +
                " group by df,shift,rec,l,s1,s2";

            mCon = new MySqlConnection(connectio_silikat);
            // string sql = ("SELECT * FROM spslogger.configtable;");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql3, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.AutoResizeColumns();
            dataGridView1.Columns["df"].HeaderText = "Дата производства";
            dataGridView1.Columns["shift"].HeaderText = "Смена";
            dataGridView1.Columns["rec"].HeaderText = "Рецепт";
            dataGridView1.Columns["l"].HeaderText = "Марка извести";
            dataGridView1.Columns["Lime"].HeaderText = "Расход известь, кг";
            dataGridView1.Columns["s1"].HeaderText = "Марка песка силос 1";
            dataGridView1.Columns["Sand1"].HeaderText = "Расход расход песка силос 1, кг";
            dataGridView1.Columns["s2"].HeaderText = "Марка песка силос 2";
            dataGridView1.Columns["Sand2"].HeaderText = "Расход расход песка силос 2, кг";

            //dataGridView1.Columns["df"].HeaderText = "Дата";
            //dataGridView1.Columns["Lime_1"].Visible = false;
            //dataGridView1.Columns["Lime_2"].Visible = false;
            //dataGridView1.Columns["Cement_1"].Visible = false;
            //dataGridView1.Columns["Cement_2"].Visible = false;
            //dataGridView1.Columns["shift"].HeaderText = "смена";
            //dataGridView1.Columns["shift"].Visible = false;
            //dataGridView1.Columns["count_1"].HeaderText = "Кол-во массивов";
            //dataGridView1.Columns["mas"].HeaderText = "м.куб";
            //dataGridView1.Columns["Lime_sum"].HeaderText = "Известь, кг";
            //dataGridView1.Columns["Cement_sum"].HeaderText = "Цемент, кг";
            //dataGridView1.Columns["Gips"].HeaderText = "Гипс, кг";
            //dataGridView1.Columns["Sand"].HeaderText = "Песок, кг";
            //dataGridView1.Columns["Additive"].HeaderText = "Добавка, кг";
            //dataGridView1.Columns["alum"].HeaderText = "Алюминий, кг";
            //dataGridView1.Columns["drob"].HeaderText = "Шары мелющие, кг";
            //dataGridView1.Columns["brak"].HeaderText = "Шламовые массивы";


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


        private void Report_mix_Load(object sender, EventArgs e)
        {
            picker();
            update_report_su();
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

        private void Button14_Click(object sender, EventArgs e)
        {
            update_report_su();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            picker();
            update_report_su();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            picker(1);
            update_report_su();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            picker(2);
            update_report_su();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            picker(3);
            update_report_su();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            picker(4);
            update_report_su();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            picker(5);
            update_report_su();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            picker(6);
            update_report_su();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            picker(7);
            update_report_su();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            picker(8);
            update_report_su();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            picker(9);
            update_report_su();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            picker(10);
            update_report_su();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            picker(11);
            update_report_su();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            picker(12);
            update_report_su();
        }
    }
}
