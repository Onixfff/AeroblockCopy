using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Aeroblock
{
    public partial class Pallet : Form
    {
        MySqlConnection mCon;
        string conn;
        public Pallet(string con)
        {
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }
        private void update()
        {
           mCon.Open();
            string sql = ("SELECT p.*, n.name 'ФИО/Компания', c.nom 'Номер авто', u.name 'Ответственный' " +
                "FROM palet p left join seller n on p.name=n.id left join cars c on p.car=c.id left join user u on p.face=u.id ");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_company.DataSource = ds.Tables[0];

            dataGridView_company.Columns["name"].Visible = false;
            dataGridView_company.Columns["car"].Visible = false;
            dataGridView_company.Columns["face"].Visible = false;
            dataGridView_company.Columns["pal_1"].HeaderText = "Кол-во стандарт";
            dataGridView_company.Columns["pal_2"].HeaderText = "Кол-во ремонт";
            dataGridView_company.Columns["pal_3"].HeaderText = "Кол-во утиль";
            dataGridView_company.Columns["pal_euro"].HeaderText = "Кол-во европаллет";
            dataGridView_company.Columns["pal_1_pay"].HeaderText = "оплата стандарт";
            dataGridView_company.Columns["pal_2_pay"].HeaderText = "оплата ремонт";
            dataGridView_company.Columns["pal_3_pay"].HeaderText = "оплата утиль";
            dataGridView_company.Columns["pal_euro_pay"].HeaderText = "оплата европаллет";

            dataGridView_company.Columns["date"].HeaderText = "Дата приемки";
            dataGridView_company.Columns["comment"].HeaderText = "Комментарии";
            //dataGridView_company.Columns["e-mail"].HeaderText = "Электронная почта";
            dataGridView_company.Columns["id"].Visible = false;
            dataGridView_company.AutoResizeColumns();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mCon.Close();
        }

        private void Pallet_Load(object sender, EventArgs e)
        {
            update();

        }

        private void ts_add_Click(object sender, EventArgs e)
        {


            Add_pallet ada_data = new Add_pallet(conn);
            if (ada_data.ShowDialog() == DialogResult.OK)
            {
                update();
            }
        }
    }
}
