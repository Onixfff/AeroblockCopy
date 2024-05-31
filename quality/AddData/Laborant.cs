using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quality
{
    public partial class Laborant : Form
    {
        MySqlConnection mCon;
        private string _conn, _dataBase = "users", _table = "users";

        List<string> rename = new List<string>();
        List<string> namesVisibl = new List<string>() {"id"};

        public Laborant(string conn)
        {
            this._conn = conn;

            mCon = new MySqlConnection(conn);
            InitializeComponent();
            Renewal();
        }

        private void AddList()
        {
            rename.Add("Имя");
            rename.Add("Фамилия");
            rename.Add("Отчество");
            //rename.Add("Сокращение");
            //rename.Add("Комментарий");
        }

        private void RenameAndVisibl(DataSet ds)
        {
            foreach (DataGridViewColumn item in dataGridView_laborant.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            dataGridView_laborant.Columns["name"].HeaderText = rename[0];
            dataGridView_laborant.Columns["sur"].HeaderText = rename[1];
            dataGridView_laborant.Columns["fam"].HeaderText = rename[2];
        }

        private void Renewal()
        {
            mCon.Open();
            string sql = ("select id, name, sur, fam from " + _dataBase + "." + _table + "");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_laborant.DataSource = ds.Tables[0];

            AddList();
            RenameAndVisibl(ds);

            mCon.Close();
        }

        private void DataGridView_laborant_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
