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
{    public partial class Order_GB : Form
    {
        MySqlConnection mCon;
        string conn;
        public Order_GB(string con)
        {
            this.conn = con;
            mCon = new MySqlConnection(con);
            InitializeComponent();
        }
        private void update()
        {
            mCon.Open();
            string sql = ("Select a.`name` 'Наименование продукции', b.`name` 'Паз/гребень', c.`name` 'Захаваты для рук', d.`name` 'Марка по плотности', v.real_density 'Реальная плотность', " +
                "e.`name` 'Марка по прочности кгс/см2', f.`name` 'Тип паллета', g.`name` 'Тип пленки', v.count 'Количество, м3', v.comments 'Комментарии к заказу'" +
                "from order_aeroblock.order v left join `name` a on v.id_name= a.id " +
                "left join tongue_groove b on v.id_tongue= b.id " +
                "left join handl_bag c on v.id_handl= c.id " +
                "left join density d on v.id_density= d.id" +
                " left join strength e on v.id_strenght= e.id" +
                " left join pallet f on v.id_pallet=f.id" +
                " left join film g on v.id_film=g.id");
               
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_order.DataSource = ds.Tables[0];

            //dataGridView_order.Columns["name"].Visible = false;
            //dataGridView_order.Columns["car"].Visible = false;
            //dataGridView_order.Columns["face"].Visible = false;
            //dataGridView_order.Columns["pal_1"].HeaderText = "Кол-во стандарт";
            //dataGridView_order.Columns["pal_2"].HeaderText = "Кол-во ремонт";
            //dataGridView_order.Columns["pal_3"].HeaderText = "Кол-во утиль";
            //dataGridView_order.Columns["pal_euro"].HeaderText = "Кол-во европаллет";
            //dataGridView_order.Columns["pal_1_pay"].HeaderText = "оплата стандарт";
            //dataGridView_order.Columns["pal_2_pay"].HeaderText = "оплата ремонт";
            //dataGridView_order.Columns["pal_3_pay"].HeaderText = "оплата утиль";
            //dataGridView_order.Columns["pal_euro_pay"].HeaderText = "оплата европаллет";

            //dataGridView_order.Columns["date"].HeaderText = "Дата приемки";
            //dataGridView_order.Columns["comment"].HeaderText = "Комментарии";
            //dataGridView_order.Columns["e-mail"].HeaderText = "Электронная почта";
            //dataGridView_order.Columns["id"].Visible = false;
            dataGridView_order.AutoResizeColumns();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mCon.Close();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            update();
        }
    }
}
