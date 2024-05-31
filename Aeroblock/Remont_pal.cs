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
    public partial class Remont_pal : Form
    {
        MySqlConnection mCon;
        string conn;
        public Remont_pal(string con)
        {
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }

        private void update()
        {
            mCon.Open();
            string sql = ("SELECT p.*, n.name 'Сотрудник' FROM remont_pal p left join worker n on p.id_worker=n.id  ");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_remont_pal.DataSource = ds.Tables[0];

            //dataGridView_remont_pal.Columns["name"].Visible = false;
            dataGridView_remont_pal.Columns["id_oper"].Visible = false;
            dataGridView_remont_pal.Columns["id_worker"].Visible = false;
            dataGridView_remont_pal.Columns["id"].Visible = false;
            dataGridView_remont_pal.Columns["date"].HeaderText = "Дата ремонта";
            dataGridView_remont_pal.Columns["sum"].HeaderText = "Кол-во ремонт";
         
            dataGridView_remont_pal.Columns["comments"].HeaderText = "Комментарии";
            //dataGridView_company.Columns["e-mail"].HeaderText = "Электронная почта";
            
            dataGridView_remont_pal.Columns["comments"].DisplayIndex = 6;
            dataGridView_remont_pal.AutoResizeColumns();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mCon.Close();
        }

        private void Remont_pal_Load(object sender, EventArgs e)
        {
            update();
        }

        private void ts_add_Click(object sender, EventArgs e)
        {
            Add_remont_pal ada_data = new Add_remont_pal(conn);
            if (ada_data.ShowDialog() == DialogResult.OK)
            {
                update();
            }
        }

        private void Ts_list_Click(object sender, EventArgs e)
        {

        }

        private void Ts_edit_Click(object sender, EventArgs e)
        {

        }
    }
}
