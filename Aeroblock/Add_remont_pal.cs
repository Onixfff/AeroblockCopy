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
    public partial class Add_remont_pal : Form
    {
        MySqlConnection mCon;
        string conn;
        string id_name, id_cars, id_user;

        private void textBox_name_Click(object sender, EventArgs e)
        {
            Libr ada_data = new Libr(305, conn);
          
            if (ada_data.ShowDialog() == DialogResult.OK)
            {
                textBox_name.Text = ada_data.dataGridView_libr.SelectedRows[0].Cells[1].Value.ToString();
                id_name = ada_data.dataGridView_libr.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //if (textBox_pal_1.Text=="")
            string data = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
            Dictionary<string, string> str = new Dictionary<string, string>();
            str.Add("`date`", data);
            str.Add("`id_oper`", "0");
            str.Add("`id_worker`", id_name);
            str.Add("`sum`", textBox_pal_1.Text);
          
            str.Add("`comments`", textBox_comments.Text);

            string keys, values;
            DataUpdater.MySQLData.ConvertInsertData(str, out keys, out values);
            string strSQL = "insert into remont_pal (" + keys + ") values (" + values + ");";

            bool isok = false;
            while (!isok)
            {
                DataUpdater.MySQLData.GetScalar.Result wres = DataUpdater.MySQLData.GetScalar.NoResponse(strSQL, conn);
                if (wres.HasError == true)
                { isok = false; Thread.Sleep(500); }
                else
                {
                    isok = true;
                    DialogResult = DialogResult.OK;
                    this.Close();
                    
                    //MessageBox.Show("Запись добавлена");


                }
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_comments_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_pal_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        public Add_remont_pal(string con)
        {
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
