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
using System.Threading;

namespace Aeroblock
{
    public partial class Libr : Form
    {
        MySqlConnection mCon;
        string  conn;
        int args;


        public Libr(int args, string con)
        {
            this.args = args;
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }
        public Libr( string con)
        {
            //this.args = args;()
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }

        private void update_seller()
        {
            mCon.Open();
            string sql = ("SELECT * FROM seller");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_libr.DataSource = ds.Tables[0];

            dataGridView_libr.Columns["name"].HeaderText = "ФИО/Компания";
            //dataGridView_company.Columns["short_name"].HeaderText = "Сокращенное наименование";
            //dataGridView_company.Columns["adress"].HeaderText = "Адрес компании";
            //dataGridView_company.Columns["tel"].HeaderText = "Контактный телефон";
            //dataGridView_company.Columns["e-mail"].HeaderText = "Электронная почта";
            dataGridView_libr.Columns["id"].Visible = false;
            dataGridView_libr.AutoResizeColumns();
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mCon.Close();
        }

        private void update_cars()
        {
            mCon.Open();
            string sql = ("SELECT * FROM cars");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_libr.DataSource = ds.Tables[0];

            dataGridView_libr.Columns["nom"].HeaderText = "Номер авто";
            //dataGridView_company.Columns["short_name"].HeaderText = "Сокращенное наименование";
            //dataGridView_company.Columns["adress"].HeaderText = "Адрес компании";
            //dataGridView_company.Columns["tel"].HeaderText = "Контактный телефон";
            //dataGridView_company.Columns["e-mail"].HeaderText = "Электронная почта";
            dataGridView_libr.Columns["id"].Visible = false;
            dataGridView_libr.AutoResizeColumns();
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mCon.Close();
        }
        private void update_user()
        {
            mCon.Open();
            string sql = ("SELECT * FROM user");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_libr.DataSource = ds.Tables[0];

            dataGridView_libr.Columns["name"].HeaderText = "ФИО ответственного";
            dataGridView_libr.Columns["id"].Visible = false; 
            dataGridView_libr.Columns["pass"].Visible = false;
            dataGridView_libr.Columns["previl"].Visible = false;
            dataGridView_libr.Columns["status"].Visible = false;
            dataGridView_libr.AutoResizeColumns();
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mCon.Close();
        }

        private void update_worker()
        {
            mCon.Open();
            string sql = ("SELECT * FROM worker");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_libr.DataSource = ds.Tables[0];

            dataGridView_libr.Columns["name"].HeaderText = "ФИО ответственного";
            dataGridView_libr.Columns["id"].Visible = false;
          
            dataGridView_libr.AutoResizeColumns();
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mCon.Close();
        }

        private void Libr_Load(object sender, EventArgs e)
        {
            if (args==128)// клиент
            {
                update_seller();
            }

            if (args == 256)// клиент
            {
                update_cars();
            }
            if (args == 300)// клиент
            {
                toolStripTextBox1.Visible = false;
                ts_add.Enabled = false;
                update_user();               
            }
            if (args == 305)// клиент
            {
                //toolStripTextBox1.Visible = false;
                //ts_add.Enabled = false;
                update_worker();

            }


        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Length >= 3)
            {
                if (args == 128)// клиент
                {
                    mCon.Open();
                    string sql = ("SELECT * FROM seller  where `name` like '%" + toolStripTextBox1.Text + "%'" );
                    MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                    DataSet ds = new DataSet();
                    ds.Reset();
                    dD.Fill(ds, sql);
                    dataGridView_libr.DataSource = ds.Tables[0];

                    dataGridView_libr.Columns["name"].HeaderText = "ФИО/Компания";
                    //dataGridView_company.Columns["short_name"].HeaderText = "Сокращенное наименование";
                    //dataGridView_company.Columns["adress"].HeaderText = "Адрес компании";
                    //dataGridView_company.Columns["tel"].HeaderText = "Контактный телефон";
                    //dataGridView_company.Columns["e-mail"].HeaderText = "Электронная почта";
                    dataGridView_libr.Columns["id"].Visible = false;
                    dataGridView_libr.AutoResizeColumns();
                    //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    mCon.Close();
                }

                if (args == 256)// клиент
                {
                    mCon.Open();
                    string sql = ("SELECT * FROM cars where `nom` like '%" + toolStripTextBox1.Text + "%'");
                    MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                    DataSet ds = new DataSet();
                    ds.Reset();
                    dD.Fill(ds, sql);
                    dataGridView_libr.DataSource = ds.Tables[0];

                    dataGridView_libr.Columns["nom"].HeaderText = "Номер авто";
                    //dataGridView_company.Columns["short_name"].HeaderText = "Сокращенное наименование";
                    //dataGridView_company.Columns["adress"].HeaderText = "Адрес компании";
                    //dataGridView_company.Columns["tel"].HeaderText = "Контактный телефон";
                    //dataGridView_company.Columns["e-mail"].HeaderText = "Электронная почта";
                    dataGridView_libr.Columns["id"].Visible = false;
                    dataGridView_libr.AutoResizeColumns();
                    //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    mCon.Close();
                }
                if (args == 305)// клиент
                {
                    mCon.Open();
                    string sql = ("SELECT * FROM worker where `name` like '%" + toolStripTextBox1.Text + "%'");
                    MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                    DataSet ds = new DataSet();
                    ds.Reset();
                    dD.Fill(ds, sql);
                    dataGridView_libr.DataSource = ds.Tables[0];

                    dataGridView_libr.Columns["name"].HeaderText = "ФИО ответственного";
                    //dataGridView_company.Columns["short_name"].HeaderText = "Сокращенное наименование";
                    //dataGridView_company.Columns["adress"].HeaderText = "Адрес компании";
                    //dataGridView_company.Columns["tel"].HeaderText = "Контактный телефон";
                    //dataGridView_company.Columns["e-mail"].HeaderText = "Электронная почта";
                    dataGridView_libr.Columns["id"].Visible = false;
                    dataGridView_libr.AutoResizeColumns();
                    //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    mCon.Close();
                }
            }
        }

        private void ts_add_Click(object sender, EventArgs e)
        {

            if (toolStripTextBox1.Text.Length >= 3)
            {
                if (args == 128)// клиент
                {
                    string sql = ("INSERT INTO `aeroblock_2`.`seller` (`name`) VALUES ('" + toolStripTextBox1.Text + "')");
                    bool isok = false;
                    while (!isok)
                    {
                        DataUpdater.MySQLData.GetScalar.Result wres = DataUpdater.MySQLData.GetScalar.NoResponse(sql, conn);
                        if (wres.HasError == true)
                        { isok = false; Thread.Sleep(500); }
                        else
                        {
                            isok = true;
                            toolStripTextBox1.Text = "";
                            update_seller();
                            MessageBox.Show("Запись добавлена");
                        }
                    }
                }
                if (args == 256)// клиент
                {
                    string sql = ("INSERT INTO `aeroblock_2`.`cars` (`nom`) VALUES ('" + toolStripTextBox1.Text + "')");
                    bool isok = false;
                    while (!isok)
                    {
                        DataUpdater.MySQLData.GetScalar.Result wres = DataUpdater.MySQLData.GetScalar.NoResponse(sql, conn);
                        if (wres.HasError == true)
                        { isok = false; Thread.Sleep(500); }
                        else
                        {
                            isok = true;
                            toolStripTextBox1.Text = "";
                            update_cars();
                            MessageBox.Show("Запись добавлена");
                        }
                    }
                }
                if (args == 305)// клиент
                {
                    string sql = ("INSERT INTO `aeroblock_2`.`worker` (`name`) VALUES ('" + toolStripTextBox1.Text + "')");
                    bool isok = false;
                    while (!isok)
                    {
                        DataUpdater.MySQLData.GetScalar.Result wres = DataUpdater.MySQLData.GetScalar.NoResponse(sql, conn);
                        if (wres.HasError == true)
                        { isok = false; Thread.Sleep(500); }
                        else
                        {
                            isok = true;
                            toolStripTextBox1.Text = "";
                            update_worker();
                            MessageBox.Show("Запись добавлена");
                        }
                    }
                }
            }
        }

        private void dataGridView_libr_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
    
}
