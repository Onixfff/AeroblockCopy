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
    public partial class Add_pallet : Form
    {
        MySqlConnection mCon;
        string conn;
        string id_name, id_cars, id_user;
        public Add_pallet(string con)
        {
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Libr ada_data = new Libr(128, conn);
            if (ada_data.ShowDialog() == DialogResult.OK)
            {
              textBox_name.Text=ada_data.dataGridView_libr.SelectedRows[0].Cells[1].Value.ToString();
                id_name= ada_data.dataGridView_libr.SelectedRows[0].Cells[0].Value.ToString();
            }
        }
        public string GetCheckState(CheckBox c)
        {
            string value;
            if (c.Checked)
                value = "1";
            else
                value = "0";
            return value;

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text=="")
            {
                MessageBox.Show("Введите фамилию или компанию");
                return;
            }
            if (textBox_cars.Text == "")
            {
                MessageBox.Show("Введите номер автомобиля");
                return;
            }
            if (textBox_user.Text == "")
            {
                MessageBox.Show("Введите ответственного");
                return;
            }
            else
            {

                //if (textBox_pal_1.Text=="")
                string data = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
                Dictionary<string, string> str = new Dictionary<string, string>();
                str.Add("`date`", data);
                str.Add("`name`", id_name);
                str.Add("`car`", id_cars);
                str.Add("`pal_1`", textBox_pal_1.Text);
                str.Add("`pal_1_pay`", GetCheckState(checkBox_pal_1));
                str.Add("`pal_2`", textBox_pal_2.Text);
                str.Add("`pal_2_pay`", GetCheckState(checkBox_pal_2));
                str.Add("`pal_3`", textBox_pal_3.Text);
                str.Add("`pal_3_pay`", GetCheckState(checkBox_pal_3));
                str.Add("`pal_euro`", textBox_pal_4.Text);
                str.Add("`pal_euro_pay`", GetCheckState(checkBox_pal_4));
                str.Add("`face`", id_user);
                str.Add("`comment`", textBox_comments.Text);

                string keys, values;
                DataUpdater.MySQLData.ConvertInsertData(str, out keys, out values);
                string strSQL = "insert into palet (" + keys + ") values (" + values + ");";

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
        }

        private void Add_pallet_Load(object sender, EventArgs e)
        {
            textBox_pal_1.Text = "0";
            textBox_pal_2.Text = "0";
            textBox_pal_3.Text = "0";
            textBox_pal_4.Text = "0";
            //id_cars = "3";
            //id_user = "4";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            Libr ada_data = new Libr(256, conn);
            if (ada_data.ShowDialog() == DialogResult.OK)
            {
                textBox_cars.Text = ada_data.dataGridView_libr.SelectedRows[0].Cells[1].Value.ToString();
                id_cars = ada_data.dataGridView_libr.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void textBox_user_Click(object sender, EventArgs e)
        {
            Libr ada_data = new Libr(300, conn);
            if (ada_data.ShowDialog() == DialogResult.OK)
            {
                textBox_user.Text = ada_data.dataGridView_libr.SelectedRows[0].Cells[1].Value.ToString();
                id_user = ada_data.dataGridView_libr.SelectedRows[0].Cells[0].Value.ToString();
            }
        }
    }
}
