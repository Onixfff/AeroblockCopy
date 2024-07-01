using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Report_Silikat
{
    public partial class Report_press : Form
    {
        String connectio_silikat = "Database=silikat; datasource=192.168.100.100; port=3306; username=D_user; password=Aeroblock12345%; charset=utf8";
        MySqlConnection mCon;

        private int _FirstOpen = 0;
        private Press _pressEnum;

        public Report_press()
        {
            InitializeComponent();
        }
        private void picker()
        {
            var mounth = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var date = new DateTime(year, mounth, 1);
            int days = DateTime.DaysInMonth(year, mounth);
            var date2 = new DateTime(year, mounth, days);
            dateTimePicker_start.Text = date.ToString();
            dateTimePicker_finish.Text = date2.ToString();
        }
        private void picker(int mounth)
        {
            var year = DateTime.Now.Year;
            var date = new DateTime(year, mounth, 1);
            int days = DateTime.DaysInMonth(year, mounth);
            var date2 = new DateTime(year, mounth, days);

            dateTimePicker_start.Text = date.ToString();
            dateTimePicker_finish.Text = date2.ToString();
        }
        private void update_report_su()
        {
            ReturnSqlCodeDataGridView1(out string sql, out string sql3);

            mCon = new MySqlConnection(connectio_silikat);
            MySqlDataAdapter dD = new MySqlDataAdapter(sql3, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns["df"].HeaderText = "Дата производства";
            dataGridView1.Columns["press"].HeaderText = "№ Пресса";
            dataGridView1.Columns["shift"].HeaderText = "Смена";
            dataGridView1.Columns["rec"].HeaderText = "Рецепт";
            dataGridView1.Columns["col"].HeaderText = "Количество кирпича, шт";

            dataGridView1.Columns["shift"].DisplayIndex = 2;
        }

        private void update_report_gdw2()
        {
            ReturnSqlCodeDataGridView2(out string sql, out string sql3);

            mCon = new MySqlConnection(connectio_silikat);
            MySqlDataAdapter dD = new MySqlDataAdapter(sql3, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns["df"].HeaderText = "Дата производства";
            dataGridView1.Columns["press"].HeaderText = "№ Пресса";
            dataGridView2.Columns["shift"].HeaderText = "Смена";
            dataGridView2.Columns["rec"].HeaderText = "Рецепт";
            dataGridView2.Columns["col"].HeaderText = "Количество кирпича, шт";
            dataGridView2.Columns["nom_vagon"].HeaderText = "Номер вагонетки";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            update_report_su();
            update_report_gdw2();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            picker(7);
            update_report_su();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            picker(1);
            update_report_su();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            picker(2);
            update_report_su();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            picker(3);
            update_report_su();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            picker(4);
            update_report_su();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            picker(5);
            update_report_su();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            picker(6);
            update_report_su();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            picker(6);
            update_report_su();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            picker(8);
            update_report_su();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            picker(9);
            update_report_su();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            picker(10);
            update_report_su();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            picker(11);
            update_report_su();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            picker(12);
            update_report_su();
        }

        private void Report_press_Load(object sender, EventArgs e)
        {
            picker();
            update_report_su();
            update_report_gdw2();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;

            switch (comboBox.SelectedIndex)
            {
                case 0://Все

                    _pressEnum = Press.All;

                    break;
                case 1://Первый

                    _pressEnum = Press.First;

                    break;
                case 2://Второй

                    _pressEnum = Press.Second;

                    break;
                default:
                    _pressEnum = Press.All;
                    break;
            }

            update_report_su();
            update_report_gdw2();
        }

        private void ChangerColors(DataGridView dataGridView)
        {

            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                DataGridViewCell cell = item.Cells[1]; // Выбор ячейки по индексу

                if (cell.Value != null && cell.Value.ToString() == "Первый")
                    cell.Style.BackColor = Color.LightCyan;
                else if (cell.Value != null && cell.Value.ToString() == "Второй")
                    cell.Style.BackColor = Color.LightGray;

                if (cell.Value != null && item.Cells[2].Value.ToString() == "ночь")
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                else
                    item.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void ReturnSqlCodeDataGridView1(out string sql, out string sql3)
        {
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");

            switch (_pressEnum)
            {
                case Press.All:
                    sql = $"SELECT \r\n    IF (TIME(report.id) < '08:00:00', DATE_FORMAT(DATE_SUB(report.id, INTERVAL 1 DAY), \"%d %M %Y\"), DATE_FORMAT(report.id, \"%d %M %Y\")) AS 'Дата',\r\n    'Первый' AS press,  \r\n    IF (TIME(report.id) <= '20:00:00' AND TIME(report.id)>= '08:00:00', 'день', 'ночь') AS 'Смена',\r\n    recept.name AS 'Наименование рецепта',\r\n    (SELECT material.name FROM material_costumer_manufactur.material WHERE material.id = silikat.report.id_name_lime) AS 'Марка извести',\r\n    ROUND(SUM(actual_lime1), 2) AS 'Расход извести, кг',\r\n    (SELECT material.name FROM material_costumer_manufactur.material WHERE material.id = silikat.report.idname_sand1) AS 'Песок 1',\r\n    ROUND(SUM(actual_sand1), 2) AS 'Расход песка1, кг',\r\n    (SELECT material.name FROM material_costumer_manufactur.material WHERE material.id = silikat.report.idname_sand2) AS 'Песок 2',\r\n    ROUND(SUM(actual_sand2), 2) AS 'Расход песка2, кг'\r\nFROM \r\n    silikat.report\r\nLEFT JOIN \r\n    silikat.recept ON report.id_name_lime = recept.id\r\nLEFT JOIN \r\n    material_costumer_manufactur.material ON material.id = report.id_name_lime\r\nWHERE \r\n    report.id >= '" + start + " 08:00:00' AND report.id < CONCAT(DATE_ADD('" + finish + "', INTERVAL 1 DAY), ' 08:00:00')\r\nGROUP BY \r\n    'Дата'\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    IF (TIME(report2.id) < '08:00:00', DATE_FORMAT(DATE_SUB(report2.id, INTERVAL\r\n";
                    sql3 = $"SELECT IF (TIME(id) < '08:00:00', DATE_FORMAT(DATE_SUB(id, INTERVAL 1 DAY), \"%d %M %Y\"), DATE_FORMAT(id, \"%d %M %Y\")) AS df,\r\n    'Первый' AS press,\r\n    IF (TIME(id) <= '20:00:00' AND TIME(id) >= '08:00:00', 'день', 'ночь') AS shift, \r\n    (SELECT nomenklatura.name FROM silikat.nomenklatura WHERE nomenklatura.id = silikat.report_press.id_nomenklatura) AS rec,\r\n    ROUND(COUNT(id), 2) * (SELECT nomenklatura.col FROM silikat.nomenklatura WHERE nomenklatura.id = silikat.report_press.id_nomenklatura) AS col\r\nFROM \r\n    silikat.report_press \r\nWHERE \r\n    report_press.id >= '" + start + " 08:00:00' AND report_press.id < CONCAT(DATE_ADD('" + finish + "', INTERVAL 1 DAY), ' 08:00:00')\r\nGROUP BY \r\n    df, shift, rec\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    IF (TIME(id) < '08:00:00', DATE_FORMAT(DATE_SUB(id, INTERVAL 1 DAY), \"%d %M %Y\"), DATE_FORMAT(id, \"%d %M %Y\")) AS df,\r\n    'Второй' AS press,\r\n    IF (TIME(id) <= '20:00:00' AND TIME(id) >= '08:00:00', 'день', 'ночь') AS shift, \r\n    (SELECT nomenklatura.name FROM silikat.nomenklatura WHERE nomenklatura.id = silikat.report_press2.id_nomenklatura) AS rec,\r\n    ROUND(COUNT(id), 2) * (SELECT nomenklatura.col FROM silikat.nomenklatura WHERE nomenklatura.id = silikat.report_press2.id_nomenklatura) AS col\r\nFROM \r\n    silikat.report_press2 \r\nWHERE \r\n    report_press2.id >= '" + start + " 08:00:00' AND report_press2.id < CONCAT(DATE_ADD('" + finish + "', INTERVAL 1 DAY), ' 08:00:00')\r\nGROUP BY \r\n    df, shift, rec;\r\n";
                    break;
                case Press.First:

                    sql = "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(report.id, \"%d %M %Y\")) as 'Дата', 'Первый' as 'press',  if (time(report.id) <= '20:00:00' and time(report.id)>= '08:00:00','день','ночь') as 'Смена'," +
                            "recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id=silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                            "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                            " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                            "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'";

                    sql3 = "select if (time(id) < '08:00:00',date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(id, \"%d %M %Y\")) as df," +
                            "'Первый' as 'press'," +
                            "if (time(id) <= '20:00:00' and time(id)>= '08:00:00','день','ночь') as shift, " +
                            "(select nomenklatura.name from silikat.nomenklatura where nomenklatura.id = silikat.report_press.id_nomenklatura) as rec," +

                            "round(count(id), 2)*(select nomenklatura.col from silikat.nomenklatura where nomenklatura.id = silikat.report_press.id_nomenklatura) as col" +
                            " from silikat.report_press where report_press.id >= '" + start + " 08:00:00' and report_press.id < concat(date_add('" + finish + "', interval 1 day), ' 08:00:00')" +
                            " group by df,shift,rec";
                    break;
                case Press.Second:

                    sql = "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(report.id, \"%d %M %Y\")) as 'Дата', 'Первый' as 'press',  if (time(report.id) <= '20:00:00' and time(report.id)>= '08:00:00','день','ночь') as 'Смена'," +
                            "recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id=silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                            "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                            " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                            "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'";

                    sql3 = "select if (time(id) < '08:00:00',date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(id, \"%d %M %Y\")) as df," +
                            "'Второй' as 'press'," +
                            "if (time(id) <= '20:00:00' and time(id)>= '08:00:00','день','ночь') as shift, " +
                            "(select nomenklatura.name from silikat.nomenklatura where nomenklatura.id = silikat.report_press2.id_nomenklatura) as rec," +

                            "round(count(id), 2)*(select nomenklatura.col from silikat.nomenklatura where nomenklatura.id = silikat.report_press2.id_nomenklatura) as col" +
                            " from silikat.report_press2 where report_press2.id >= '" + start + " 08:00:00' and report_press2.id < concat(date_add('" + finish + "', interval 1 day), ' 08:00:00')" +
                            " group by df,shift,rec";
                    break;

                default:
                    sql = $"SELECT \r\n    IF (TIME(report.id) < '08:00:00', DATE_FORMAT(DATE_SUB(report.id, INTERVAL 1 DAY), \"%d %M %Y\"), DATE_FORMAT(report.id, \"%d %M %Y\")) AS 'Дата',\r\n    'Первый' AS press,  \r\n    IF (TIME(report.id) <= '20:00:00' AND TIME(report.id)>= '08:00:00', 'день', 'ночь') AS 'Смена',\r\n    recept.name AS 'Наименование рецепта',\r\n    (SELECT material.name FROM material_costumer_manufactur.material WHERE material.id = silikat.report.id_name_lime) AS 'Марка извести',\r\n    ROUND(SUM(actual_lime1), 2) AS 'Расход извести, кг',\r\n    (SELECT material.name FROM material_costumer_manufactur.material WHERE material.id = silikat.report.idname_sand1) AS 'Песок 1',\r\n    ROUND(SUM(actual_sand1), 2) AS 'Расход песка1, кг',\r\n    (SELECT material.name FROM material_costumer_manufactur.material WHERE material.id = silikat.report.idname_sand2) AS 'Песок 2',\r\n    ROUND(SUM(actual_sand2), 2) AS 'Расход песка2, кг'\r\nFROM \r\n    silikat.report\r\nLEFT JOIN \r\n    silikat.recept ON report.id_name_lime = recept.id\r\nLEFT JOIN \r\n    material_costumer_manufactur.material ON material.id = report.id_name_lime\r\nWHERE \r\n    report.id >= '" + start + " 08:00:00' AND report.id < CONCAT(DATE_ADD('" + finish + "', INTERVAL 1 DAY), ' 08:00:00')\r\nGROUP BY \r\n    'Дата'\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    IF (TIME(report2.id) < '08:00:00', DATE_FORMAT(DATE_SUB(report2.id, INTERVAL\r\n";
                    sql3 = $"SELECT IF (TIME(id) < '08:00:00', DATE_FORMAT(DATE_SUB(id, INTERVAL 1 DAY), \"%d %M %Y\"), DATE_FORMAT(id, \"%d %M %Y\")) AS df,\r\n    'Первый' AS press,\r\n    IF (TIME(id) <= '20:00:00' AND TIME(id) >= '08:00:00', 'день', 'ночь') AS shift, \r\n    (SELECT nomenklatura.name FROM silikat.nomenklatura WHERE nomenklatura.id = silikat.report_press.id_nomenklatura) AS rec,\r\n    ROUND(COUNT(id), 2) * (SELECT nomenklatura.col FROM silikat.nomenklatura WHERE nomenklatura.id = silikat.report_press.id_nomenklatura) AS col\r\nFROM \r\n    silikat.report_press \r\nWHERE \r\n    report_press.id >= '" + start + " 08:00:00' AND report_press.id < CONCAT(DATE_ADD('" + finish + "', INTERVAL 1 DAY), ' 08:00:00')\r\nGROUP BY \r\n    df, shift, rec\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    IF (TIME(id) < '08:00:00', DATE_FORMAT(DATE_SUB(id, INTERVAL 1 DAY), \"%d %M %Y\"), DATE_FORMAT(id, \"%d %M %Y\")) AS df,\r\n    'Второй' AS press,\r\n    IF (TIME(id) <= '20:00:00' AND TIME(id) >= '08:00:00', 'день', 'ночь') AS shift, \r\n    (SELECT nomenklatura.name FROM silikat.nomenklatura WHERE nomenklatura.id = silikat.report_press2.id_nomenklatura) AS rec,\r\n    ROUND(COUNT(id), 2) * (SELECT nomenklatura.col FROM silikat.nomenklatura WHERE nomenklatura.id = silikat.report_press2.id_nomenklatura) AS col\r\nFROM \r\n    silikat.report_press2 \r\nWHERE \r\n    report_press2.id >= '" + start + " 08:00:00' AND report_press2.id < CONCAT(DATE_ADD('" + finish + "', INTERVAL 1 DAY), ' 08:00:00')\r\nGROUP BY \r\n    df, shift, rec;\r\n";

                    break;
            }
        }

        private void ReturnSqlCodeDataGridView2(out string sql, out string sql3)
        {
            string finish = dateTimePicker_finish.Value.ToString("yyyy-MM-dd");
            string start = dateTimePicker_start.Value.ToString("yyyy-MM-dd");
            string tek = DateTime.Now.ToString("yyyy-MM-dd");

            switch (_pressEnum)
            {
                case Press.All:

                    sql = "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id = silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                            "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                            " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                            "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'" +
                            " UNION ALL " +
                            "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id = silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                           "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                           " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                           "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'";

                    sql3 = "select \r\n    if (time(id) < '08:00:00', date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"), date_format(id, \"%d %M %Y\")) as df,\r\n    'Первый' as press,\r\n    if (time(id) <= '20:00:00' and time(id)>= '08:00:00', 'день', 'ночь') as shift, \r\n    (select nomenklatura.name from silikat.nomenklatura where nomenklatura.id = silikat.report_press.id_nomenklatura) as rec,\r\n    round(count(id), 2) as col,\r\n    nom_vagon\r\nfrom silikat.report_press \r\nwhere report_press.id >= '" + tek + " 08:00:00' \r\nand report_press.id < concat(date_add('" + tek + "', interval 1 day), ' 08:00:00')\r\ngroup by df, shift, rec, nom_vagon\r\n\r\nUNION ALL\r\n\r\nselect \r\n    if (time(id) < '08:00:00', date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"), date_format(id, \"%d %M %Y\")) as df,\r\n    'Второй' as press,\r\n    if (time(id) <= '20:00:00' and time(id)>= '08:00:00', 'день', 'ночь') as shift, \r\n    (select nomenklatura.name from silikat.nomenklatura where nomenklatura.id = silikat.report_press2.id_nomenklatura) as rec,\r\n    round(count(id), 2) as col,\r\n    nom_vagon\r\nfrom silikat.report_press2 \r\nwhere report_press2.id >= '" + tek + " 08:00:00' \r\nand report_press2.id < concat(date_add('" + tek + "', interval 1 day), ' 08:00:00')\r\ngroup by df, shift, rec, nom_vagon;\r\n";
                    
                    break;
                case Press.First:

                     sql = "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(report.id, \"%d %M %Y\")) as 'Дата','Первый' as 'press', if (time(report.id) <= '20:00:00' and time(report.id)>= '08:00:00','день','ночь') as 'Смена'," +
                            "recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id=silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                            "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                            " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                            "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'";

                     sql3 = "select if (time(id) < '08:00:00',date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(id, \"%d %M %Y\")) as df," +
                            "'Первый' as 'press'," +
                            "if (time(id) <= '20:00:00' and time(id)>= '08:00:00','день','ночь') as shift, " +
                            "(select nomenklatura.name from silikat.nomenklatura where nomenklatura.id = silikat.report_press.id_nomenklatura) as rec," +

                            "round(count(id), 2) as col, nom_vagon" +
                            " from silikat.report_press where report_press.id >= '" + tek + " 08:00:00' and report_press.id < concat(date_add('" + tek + "', interval 1 day), ' 08:00:00')" +
                            " group by df,shift,rec, nom_vagon";
                    break;
                case Press.Second:

                    sql = "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(report.id, \"%d %M %Y\")) as 'Дата', 'Второй' as 'press', if (time(report.id) <= '20:00:00' and time(report.id)>= '08:00:00','день','ночь') as 'Смена'," +
                           "recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id=silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                           "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                           " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                           "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'";

                    sql3 = "select if (time(id) < '08:00:00',date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"),date_format(id, \"%d %M %Y\")) as df," +
                            "'Второй' as 'press'," +
                           "if (time(id) <= '20:00:00' and time(id)>= '08:00:00','день','ночь') as shift, " +
                           "(select nomenklatura.name from silikat.nomenklatura where nomenklatura.id = silikat.report_press2.id_nomenklatura) as rec," +

                           "round(count(id), 2) as col, nom_vagon" +
                           " from silikat.report_press2 where report_press2.id >= '" + tek + " 08:00:00' and report_press2.id < concat(date_add('" + tek + "', interval 1 day), ' 08:00:00')" +
                           " group by df,shift,rec, nom_vagon";
                    break;

                default:

                    sql = "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id = silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                            "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                            " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                            "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'" +
                            " UNION ALL " +
                            "SELECT if (time(report.id) < '08:00:00',date_format(date_sub(report.id, INTERVAL 1 DAY), recept.name as 'Наименование рецепта', (select material.name from material_costumer_manufactur.material where material.id = silikat.report.id_name_lime) as 'Марка извести', round(sum(actual_lime1), 2) as 'Расход извести, кг', " +
                           "(select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand1) as 'Песок 1',round(sum(actual_sand1), 2) as 'Расход песка1, кг'," +
                           " (select material.name from material_costumer_manufactur.material where material.id=silikat.report.idname_sand2) as 'Песок 2', round(sum(actual_sand2), 2) as 'Расход песка2, кг'  FROM silikat.report  left join silikat.recept on report.id_name_lime = recept.id  left join material_costumer_manufactur.material on material.id = report.id_name_lime " +
                           "where report.id >= '" + start + " 08:00:00' and report.id < concat( date_add('" + finish + "', interval 1 day), ' 08:00:00')  group by 'Дата'";

                    sql3 = "select \r\n    if (time(id) < '08:00:00', date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"), date_format(id, \"%d %M %Y\")) as df,\r\n    'Первый' as press,\r\n    if (time(id) <= '20:00:00' and time(id)>= '08:00:00', 'день', 'ночь') as shift, \r\n    (select nomenklatura.name from silikat.nomenklatura where nomenklatura.id = silikat.report_press.id_nomenklatura) as rec,\r\n    round(count(id), 2) as col,\r\n    nom_vagon\r\nfrom silikat.report_press \r\nwhere report_press.id >= '" + tek + " 08:00:00' \r\nand report_press.id < concat(date_add('" + tek + "', interval 1 day), ' 08:00:00')\r\ngroup by df, shift, rec, nom_vagon\r\n\r\nUNION ALL\r\n\r\nselect \r\n    if (time(id) < '08:00:00', date_format(date_sub(id, INTERVAL 1 DAY), \"%d %M %Y\"), date_format(id, \"%d %M %Y\")) as df,\r\n    'Второй' as press,\r\n    if (time(id) <= '20:00:00' and time(id)>= '08:00:00', 'день', 'ночь') as shift, \r\n    (select nomenklatura.name from silikat.nomenklatura where nomenklatura.id = silikat.report_press2.id_nomenklatura) as rec,\r\n    round(count(id), 2) as col,\r\n    nom_vagon\r\nfrom silikat.report_press2 \r\nwhere report_press2.id >= '" + tek + " 08:00:00' \r\nand report_press2.id < concat(date_add('" + tek + "', interval 1 day), ' 08:00:00')\r\ngroup by df, shift, rec, nom_vagon;\r\n";

                    break;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_FirstOpen == 0)
            {
                _FirstOpen++;
                return;
            }

            ChangerColors(dataGridView1);
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ChangerColors(dataGridView2);
        }
    }
}

