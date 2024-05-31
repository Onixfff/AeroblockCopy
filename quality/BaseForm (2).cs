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
    public partial class BaseForm : Form
    {
        MySqlConnection mCon;

        private string _dataBase = "mmm"; //база данных

        private string _conn; //Строка подключения

        private int _day;

        private RadioButton _radioClick = new RadioButton();

        private bool updateIt = false;

        public string table { get; private set; }

        public BaseForm(string conn, string table)
        {
            this._conn = conn;
            this.table = table;
            
            mCon = new MySqlConnection(conn);

            InitializeComponent();

            this.Text = table;

            //дата с 1 числа этого месяца
            int year = dateTimePicker_before.Value.Year;
            int month = dateTimePicker_before.Value.Month;

            //инизицализируем дату для updata в начале открытия программы возможно это делать не надо.
            dateTimePicker_from.Value = new DateTime(year, month, 1);

            //Измениние максимальных значений года для программы.
            numericUpDown1.Maximum = 3000;
            numericUpDown1.Minimum = 2020;
            
            //Отслеживает год открытия программы.
            string data3 = dateTimePicker_from.Value.ToString("yyyy");
            numericUpDown1.Value = Convert.ToInt32(data3);
            
            //Находит последний день этого месяца и загружает данные с 1 по последний день месяца.
            _day = LastDay(month);

            Renewal(month, _day);
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        public void Renewal(int month, int day)
        {

            string sql = ("select " + table + ".*,laborant.cutname from " + _dataBase + "." + table + " left join " + _dataBase + ".laborant on idLaborant = laborant.id where (`data` BETWEEN '" + numericUpDown1.Value + "-" + month + "-01' and '" + numericUpDown1.Value + "-" + month + "-" + day + "')");

            if(table == "aerated_block")
            {
                //По какому времени организовывать поимк по дате заливки или испытанию или дать выбрать это владельцу ,но я покак не знаю как.
                //sql = ("SELECT dateFilling, dataTest, nParty, `value`, day_night, blockSize_mm, drySampleWeight_gram, sampleWetWeight_gram, long_mm, width_mm, height, BreakingLoad_kH, cutname, aerated_block.`comment` FROM mmm.aerated_block left join mmm.laborant on idLaborant = laborant.id left join mmm.density on idDensity = density.id where (`dateFilling` BETWEEN '" + numericUpDown1.Value + "-" + month + "-01' and '" + numericUpDown1.Value + "-" + month + "-" + day + "')");
                sql = ("SELECT "+ table + ".id, dateFilling, dataTest, nParty, `value`, day_night, blockSize_mm, drySampleWeight_gram, sampleWetWeight_gram, long_mm, width_mm, height, BreakingLoad_kH, cutname, aerated_block.`comment` FROM " + _dataBase +"."+ table +" left join "+ _dataBase + ".laborant on idLaborant = laborant.id left join " + _dataBase + ".density on idDensity = density.id where (`dateFilling` BETWEEN '" + numericUpDown1.Value + "-" + month + "-01' and '" + numericUpDown1.Value + "-" + month + "-" + day + "')");
            }

            mCon.Open();
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_base.DataSource = ds.Tables[0];
            mCon.Close();
            //Скорее всего есть смысл написать его в начале и просто выводить медот чтобы 2 раза не инициализировать так как зачем мне проверять весь список если я уже знаю что мне надо.
            ListRename list = new ListRename(this);
        }
        private void Search()
        {
            string data = dateTimePicker_from.Value.ToString("yyyy-MM-dd");
            string data2 = dateTimePicker_before.Value.ToString("yyyy-MM-dd");
            mCon.Open();
            string sql = ("select "+ table +".*,laborant.cutname from "+ _dataBase + "."+ table +" left join "+ _dataBase +".laborant on idLaborant = laborant.id where (`data` BETWEEN '" + data + "' and '" + data2 + "')");

            if(table == "aerated_block")
            {
                sql = ("SELECT dateFilling, dataTest, nParty, `value`, day_night, blockSize_mm, drySampleWeight_gram, sampleWetWeight_gram, long_mm, width_mm, height, BreakingLoad_kH, cutname, aerated_block.`comment` FROM mmm.aerated_block left join mmm.laborant on idLaborant = laborant.id left join mmm.density on idDensity = density.id where(dateFilling BETWEEN '" + data + "' and '" + data2 + "')");                
                sql = ("SELECT "+ table +"id, dateFilling, dataTest, nParty, `value`, day_night, blockSize_mm, drySampleWeight_gram, sampleWetWeight_gram, long_mm, width_mm, height, BreakingLoad_kH, cutname, aerated_block.`comment` FROM mmm.aerated_block left join mmm.laborant on idLaborant = laborant.id left join mmm.density on idDensity = density.id where(dateFilling BETWEEN '" + data + "' and '" + data2 + "')");                
            }

            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_base.DataSource = ds.Tables[0];
            ListRename list = new ListRename(this);
            mCon.Close();
        }

        private void button_find_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(_radioClick.Tag))
            {
                case 1:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 2:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 3:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 4:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 5:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 6:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 7:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 8:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 9:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 10:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 11:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
                case 12:
                    Renewal(Convert.ToInt32(((RadioButton)_radioClick).Tag), _day);
                    break;
            }
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            LastDay(sender);
            _radioClick = (RadioButton)sender;
        }

        private void LastDay(object radioButton)
        {
            DateTime day = new DateTime(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(((RadioButton)radioButton).Tag), 1);
            day = day.AddMonths(1).AddDays(-1);
            Renewal(Convert.ToInt32(((RadioButton)radioButton).Tag), day.Day);
        }
        private int LastDay(int month)
        {
            DateTime day = new DateTime(Convert.ToInt32(numericUpDown1.Value), month, 1);
            day = day.AddMonths(1).AddDays(-1);
            return day.Day;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //switch (table)
            //{
            //    case "cement":
            //        AddCement addCement = new AddCement(_conn, table, _dataBase);
            //        addCement.ShowDialog();
            //        break;
            //    case "lime_activity":
            //        AddLimeActivity addLimeActivity = new AddLimeActivity(_conn, table, _dataBase);
            //        addLimeActivity.ShowDialog();
            //        break;
            //    case "lime_blankings":
            //        AddLimeBlankings addLimeBlankings = new AddLimeBlankings(_conn, table, _dataBase);
            //        addLimeBlankings.ShowDialog();
            //        break;
            //    case "aerated_block":
            //        AddAeratedBlock addAeratedBlock = new AddAeratedBlock(_conn, table, _dataBase);
            //        addAeratedBlock.ShowDialog();
            //        break;
            //    case "drymixes":
            //        AddDryMix addDryMix = new AddDryMix(_conn, table, _dataBase);
            //        addDryMix.ShowDialog();
            //        break;
            //    case "technology":
            //        AddTechnology addTechnology = new AddTechnology(_conn, table, _dataBase);
            //        addTechnology.ShowDialog();
            //        break;
            //    case "sludge":
            //        AddSludge addSludge = new AddSludge(_conn, table, _dataBase);
            //        addSludge.ShowDialog();
            //        break;
            //}
            updateIt = false;
            AddForm(updateIt);
        }

        private void dataGridView_base_DoubleClick(object sender, EventArgs e)
        {
            updateIt = true;
            AddForm(updateIt);
        }

        private void AddForm(bool updateIt)
        {
            switch (table)
            {
                case "cement":
                    if(updateIt == false)
                    {
                        AddCement addCement = new AddCement(_conn, table, _dataBase);
                        addCement.ShowDialog();
                    }
                    else
                    {

                    }
                    break;
                case "lime_activity":
                    if(updateIt == false)
                    {
                        AddLimeActivity addLimeActivity = new AddLimeActivity(_conn, table, _dataBase);
                        addLimeActivity.ShowDialog();
                        break;
                    }
                    else
                    {
                        
                    }
                    break;
                case "lime_blankings":
                    if(updateIt == false)
                    {
                        AddLimeBlankings addLimeBlankings = new AddLimeBlankings(_conn, table, _dataBase);
                        addLimeBlankings.ShowDialog();
                    }
                    else
                    {

                    }
                    break;
                case "aerated_block":
                    if (updateIt == false)
                    {
                        AddAeratedBlock addAeratedBlock = new AddAeratedBlock(_conn, table, _dataBase);
                        addAeratedBlock.ShowDialog();
                    }
                    else
                    {
                        List<string> lineInfo = new List<string> 
                        { 
                          dataGridView_base.SelectedRows[0].Cells[0].Value.ToString(),/* 0.id */
                          dataGridView_base.SelectedRows[0].Cells[1].Value.ToString(),/* 1.dataFilling */
                          dataGridView_base.SelectedRows[0].Cells[2].Value.ToString(),/* 2.dataTest */
                          //dataGridView_base.SelectedRows[0].Cells[3].Value.ToString(),/* 3.nParty */
                          dataGridView_base.SelectedRows[0].Cells[4].Value.ToString(),/* 4.idDensity */
                          dataGridView_base.SelectedRows[0].Cells[5].Value.ToString(),/* 5.day_night */
                          dataGridView_base.SelectedRows[0].Cells[6].Value.ToString(),/* 6.blockSize_mm */
                          dataGridView_base.SelectedRows[0].Cells[7].Value.ToString(),/* 7.drySampleWeight_gram */
                          dataGridView_base.SelectedRows[0].Cells[8].Value.ToString(),/* 8.sampleWetWeight_gram */
                          dataGridView_base.SelectedRows[0].Cells[9].Value.ToString(),/* 9.long_mm */
                          dataGridView_base.SelectedRows[0].Cells[10].Value.ToString(),/* 10.width_mm */
                          dataGridView_base.SelectedRows[0].Cells[11].Value.ToString(),/* 11.height */
                          dataGridView_base.SelectedRows[0].Cells[12].Value.ToString(),/* 12.BreakingLoad_kH */
                          dataGridView_base.SelectedRows[0].Cells[13].Value.ToString(),/* 13.idLaborant */
                          dataGridView_base.SelectedRows[0].Cells[14].Value.ToString(),/* 14.comment */
                        };
                        AddAeratedBlock addAeratedBlock = new AddAeratedBlock(_conn, table, _dataBase, lineInfo);
                        addAeratedBlock.ShowDialog();
                    }
                    break;
                case "drymixes":
                    if (updateIt == false)
                    {
                        AddDryMix addDryMix = new AddDryMix(_conn, table, _dataBase);
                        addDryMix.ShowDialog();
                    }
                    else
                    {

                    }
                    break;
                case "technology":
                    if (updateIt == false)
                    {
                        AddTechnology addTechnology = new AddTechnology(_conn, table, _dataBase);
                        addTechnology.ShowDialog();
                    }
                    else
                    {

                    }
                    break;
                case "sludge":
                    if (updateIt == false)
                    {
                        AddSludge addSludge = new AddSludge(_conn, table, _dataBase);
                        addSludge.ShowDialog();
                    }
                    else
                    {

                    }
                    break;
            }
        }
    }

    class ListRename
    {
        private string _nameTable;
        private BaseForm _baseForm;
        public List<string> rename;

        public ListRename(BaseForm baseForm)
        {
            _baseForm = baseForm;
            _nameTable = _baseForm.table;
            this.List(_nameTable, ref rename);
        }

        private void List(string nameTable, ref List<string> rename)
        {
            switch (nameTable)
            {
                case "cement":
                    FormCement(_baseForm);
                    break;
                case "lime_activity":
                    FormLimeActivity(_baseForm);
                    break;
                case "lime_blankings":
                    FormLimeBlankings(_baseForm);
                    break;
                case "aerated_block":
                    FormAerated_block(_baseForm);
                    break;
                case "drymixes":
                    FormDrymixes(_baseForm);
                    break;
                case "technology":
                    FormTechnology(_baseForm);
                    break;
                case "sludge":
                    FormSludge(_baseForm);
                    break;
            }
        }

        private void FormSludge(BaseForm baseForm)
        {
            List<string> namesVisibl = new List<string>() { "id", "idLaborant", "dataCreate" };

            List<string> rename = new List<string>() { "Дата", "Место отбора", "Масса поддона, г", "Масса навески песка, г", "Масса поддона + проход, г", "Проход через сито 0,09, %", 
                "Проход через сито 0,08, %", "Комментарий", "Лаборант"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            baseForm.dataGridView_base.Columns["data"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["placeSelection"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["palletWeight_gram"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["palletWeightAisle_gram"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["palletAndSandWeigth"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["sievePass_0.09_%"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["sievePass_0.08_%"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 11;
            baseForm.dataGridView_base.Columns["cutname"].HeaderText = rename[8];
        }

        private void FormTechnology(BaseForm baseForm)
        {
            List<string> namesVisibl = new List<string>() { "id", "idLaborant", "dataCreate" };

            List<string> rename = new List<string>() { "Дата", "Время созревания", "Темп. мешалки, ° С", "CaO, %", "Сухой вес, кг", "Вода/тв. вещ-ва, %", "Tкон, ° C",
                "№ рецепта ( плотность )", "Расход масла, л", "T камеры, ( max ) ° C", "Комментарий", "Лаборант"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            baseForm.dataGridView_base.Columns["data"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["ripeningTime_min"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["stirrerTemperature"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["CaO_%"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["dryWeight_kg"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["solidWater_%"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["tKon"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["idRecipe"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["oilConsumption_litr"].HeaderText = rename[8];
            baseForm.dataGridView_base.Columns["chamberT"].HeaderText = rename[9];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[10];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 14;
            baseForm.dataGridView_base.Columns["cutname"].HeaderText = rename[11];
        }

        private void FormCement(BaseForm baseForm)
        {
            List<string> namesVisibl = new List<string>() { "id", "idLaborant", "dataCreate" };

            List<string> rename = new List<string>() {"Дата", "Масса пробы, г", "Наименование", "Вода, мл", "Вода, %",
                "Время Движения пестика, мин", "Глубина погружения пестика, мм (6±1)", "Комментарий", "Лаборант"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            baseForm.dataGridView_base.Columns["data"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["sample weight"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["name"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["water_ml"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["water_%"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["pestleMovementTime_min"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["estleImmersionDepth_mm"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 11;
            baseForm.dataGridView_base.Columns["cutname"].HeaderText = rename[8];
        }

        private void FormLimeActivity(BaseForm baseForm)
        {
            List<string> namesVisibl = new List<string>() { "id", "idLaborant", "dataCreate" };

            List<string> rename = new List<string>() {"Дата", "Место отбора", "Номер пробы (вагона)", "Масса навески, г", "Соляная к-та 1 н, мл", "Соляная к-та ср 1 н, мл", "TCaO, г",
            "А, %", "Аср, %", "Масса навески для определения времени гащения, г", "Комментарий", "Лаборант"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            baseForm.dataGridView_base.Columns["data"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["placeSelection"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["sampleNumber"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["sampleWeight_gram"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["hydrochloricАcid"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["hydrochloricAcidMedium"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["TCao_gram"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["A_%"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["Acp_%"].HeaderText = rename[8];
            baseForm.dataGridView_base.Columns["sampleWeight_rotationTime"].HeaderText = rename[9];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[10];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 14;
            baseForm.dataGridView_base.Columns["cutname"].HeaderText = rename[11];
        }

        private void FormLimeBlankings(BaseForm baseForm)
        {
            List<string> namesVisibl = new List<string>() { "id", "idLaborant", "dataCreate" };

            List<string> rename = new List<string>() { "Дата", "Номер вагона", "Время испытания, мин", "Температура, t ° C", "Навеска, г", "Время гашения, мин",
                "Температура гашения, t ° C","Комментарий", "Лаборант"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            baseForm.dataGridView_base.Columns["data"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["numberCar"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["testTime"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["temperature"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["hitch_gram"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["timeBlanking_min"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["quenchingTemperature"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 11;
            baseForm.dataGridView_base.Columns["cutname"].HeaderText = rename[8];
        }

        private void FormDrymixes(BaseForm baseForm)
        {
            List<string> namesVisibl = new List<string>() { "id", "idLaborant", "dataCreate" };

            List<string> rename = new List<string>() {"Дата", "Виде клея(сухой смеси)", "Номер пробы", "Масса, г", "Вода, мл", "Вода, %", 
                "Остаток на сите 0,63, г (на 100г)", "Остаток на сите 0,63, %", "Коммент", "Лаборант"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            baseForm.dataGridView_base.Columns["data"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["glueType"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["sampleNumber"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["weight_gram"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["water_ml"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["water_ %"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["sieveResidue_100gram"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["sieve_residue"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[8];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 12;
            baseForm.dataGridView_base.Columns["cutname"].HeaderText = rename[9];
        }

        private void FormAerated_block(BaseForm baseForm)
        {
            List<string> namesVisibl = new List<string>() { "id"};

            List<string> rename = new List<string>() {"Дата заливки", "Дата испытания", "Номер партии", "Плотность", "Время ( день / ночь )", "Размер блока, мм", "Масса образца сухого, г", "Масса образца влажного, г", "Длинна, мм", "Ширина, мм", "Высота, мм", "Разрушающая нагрузка ка, кН","Лаборант", "Комментарий"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }

            baseForm.dataGridView_base.Columns["dateFilling"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["dataTest"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["nParty"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["value"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["day_night"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["blockSize_mm"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["drySampleWeight_gram"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["sampleWetWeight_gram"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["long_mm"].HeaderText = rename[8];
            baseForm.dataGridView_base.Columns["width_mm"].HeaderText = rename[9];
            baseForm.dataGridView_base.Columns["height"].HeaderText = rename[10];
            baseForm.dataGridView_base.Columns["BreakingLoad_kH"].HeaderText = rename[11];
            baseForm.dataGridView_base.Columns["cutname"].HeaderText = rename[12];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[13];
        }
    }
}
