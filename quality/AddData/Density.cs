using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace quality
{
    public partial class Density : Form
    {
        MySqlConnection mCon;
        private string _conn, _table = "density", _dataBase = "mmm";
        List<string> rename = new List<string>();
        List<string> namesVisibl = new List<string>() { "id" };
        public Density(string conn)
        {
            this._conn = conn;

            mCon = new MySqlConnection(conn);

            InitializeComponent();
            Renewal();
        }

        private void AddList()
        {
            rename.Add("Плотность");
            rename.Add("Комментарий");
        }

        private void RenameAndVisibl(DataSet ds)
        {
            foreach (DataGridViewColumn item in dataGridView_density.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            dataGridView_density.Columns["value"].HeaderText = rename[0];
            dataGridView_density.Columns["comment"].HeaderText = rename[1];
        }

        private void Renewal()
        {
            mCon.Open();
            string sql = ("select * from "+_dataBase+".`" + _table + "`");
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_density.DataSource = ds.Tables[0];

            AddList();
            RenameAndVisibl(ds);

            mCon.Close();
        }

        private void dataGridView_density_DoubleClick_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
