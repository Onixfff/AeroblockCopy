﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;
//using MySql;
using System.Data.Odbc;
using System.Threading;
using DataUpdater;
//using Microsoft.Office.Interop.Excel;

namespace err
{
    public partial class Form1 : Form
    {
       MySqlConnection mCon = new MySqlConnection("Database=spslogger; Server=192.168.100.7; port=3306; username=%user_2; password=20112004; charset=utf8 ");
        //MySqlConnection mCon = new MySqlConnection("Database=spslogger; Server=localhost; port=3306; username=root; password=6180; charset=utf8 ");
        MySqlCommand msd;
        string conSQL = "Database=spslogger; Server=192.168.100.7; port=3306; username=%user_2; password=20112004; charset=utf8 ";
        //string conSQL = "Database=spslogger; Server=localhost; port=3306; username=root; password=6180; charset=utf8  ";
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenCon()
        {
            if (mCon.State == ConnectionState.Closed)
            {
                mCon.Open();
            }
        }
        private void CloseCon()
        {
            if (mCon.State == ConnectionState.Open)
            {
                mCon.Close();
            }
        }
        public void ExecutQuery(string q)
        {
            try
            {
                OpenCon();
                msd = new MySqlCommand(q, mCon);
                if (msd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Запись добавлена");
                }
                else
                {
                    MessageBox.Show("Ошибка записи");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { mCon.Close(); }
        }

        private async void fill_cb()
        {
            try
            {
                try
                {
                    await mCon.OpenAsync();
                }
                catch(MySqlException ex)
                {
                    goto Select;
                }

                Select:
                string sql = ("SELECT DISTINCT data_52 FROM spslogger.mixreport where date(Timestamp) BETWEEN DATE_SUB(NOW(), INTERVAL 2 day) AND NOW();");
                MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
                DataTable tbl1 = new DataTable();
                await dD.FillAsync(tbl1);

                comboBox1.DataSource = tbl1;
                comboBox1.DisplayMember = "data_52";// столбец для отображения
                comboBox1.ValueMember = "data_52";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await mCon.CloseAsync();
                Console.WriteLine("Закрыто подключение к бд");
            }
        }
        private void fill_tb(string sql)
        {
            
            //MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            //DataTable tbl1 = new DataTable();
            //dD.Fill(tbl1);

            //textBox_comm.DataSource = tbl1;
            //comboBox1.DisplayMember = "data_52";// столбец для отображения
            //comboBox1.ValueMember = "data_52";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fill_cb();

        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> str = new Dictionary<string, string>();
            str.Add("data_err",MySQLData.MysqlTime(DateTime.Now));
            str.Add("recepte", comboBox1.Text.ToString());
            str.Add("sum_er", textBox_num.Text.ToString());
            str.Add("comments", textBox_comm.Text.ToString());



            string keys, values;
            MySQLData.ConvertInsertData(str, out keys, out values);
            string strSQL = "insert into error_mas (" + keys + ") values (" + values + ");";
            bool isok = false;
            int wrescount = 0;
            while (!isok && wrescount < 4)
            {
                MySQLData.GetScalar.Result wres = MySQLData.GetScalar.NoResponse(strSQL, conSQL);
                if (wres.HasError == true)
                { isok = false; Thread.Sleep(500); wrescount++; }
                else
                {
                    isok = true;
                    this.Close();
                }
            }
        }

        private void TextBox_comm_TextChanged(object sender, EventArgs e)
        {
            //string sql = ("SELECT * FROM error_mas where `comments` like '%" + textBox_comm.Text + "%'");
            //dataset(sql);
        }
    }
}
