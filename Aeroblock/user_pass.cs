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
using DataUpdater;

namespace Aeroblock
{
    public partial class user_pass : Form
    {
        MySqlConnection mCon;
        string conn;
        public string user;
        public string previl;
        public user_pass( string con)
        {
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_user_TextChanged(object sender, EventArgs e)
        {
            label_err.Visible = false;
            if (textBox_user.Text.Length > 3)
                buttonOK.Visible = true;
            else buttonOK.Visible = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //Проверка наличия пользователя в системе
            //MySQLData.GetScalar.Result res = MySQLData.GetScalar.Scalar("select `name` from `users.users` where upper(`name`)='" + textBox_user.Text + "';", conn);
            MySQLData.GetScalar.Result res = MySQLData.GetScalar.Scalar($"SELECT name FROM users.users where upper(`name`) = '{textBox_user.Text}';", conn);
            if (res.HasError)
            {
                label_err.Text = "пользователь с таким именем не существует";
                label_err.Visible = true;
                return;
            }
            else
            {

                user = res.ResultText;
                //MySQLData.GetScalar.Result pass = MySQLData.GetScalar.Scalar("select `pass` from `users` where upper(`name`)='" + textBox_user.Text + "';", conn);
                MySQLData.GetScalar.Result pass = MySQLData.GetScalar.Scalar($"select pass from users.users where name = '{textBox_user.Text}';", conn);
                //if(textBox_pass.Text != pass.ResultText)
                if("System.Byte[]" != pass.ResultText)
                {
                    label_err.Text = "неверный пароль";
                    label_err.Visible = true;
                }
                else
                {
                    MySQLData.GetScalar.Result prev = MySQLData.GetScalar.Scalar("select `previl` from `users` where upper(`name`)='" + textBox_user.Text + "';", conn);
                    previl = prev.ResultText;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
        }

        private void textBox_pass_TextChanged(object sender, EventArgs e)
        {
            label_err.Visible = false;
        }
    }
    
}
