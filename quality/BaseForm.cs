using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quality
{
    public partial class BaseForm : Form
    {
        MySqlConnection mCon;

        private string _dataBase = "mmm"; //база данных.

        private string _conn; //Строка подключения.

        private int _elementTable;//Сколько строк в выбранной таблице (для update)

        private int _day; //День для поиска.

        private RadioButton _radioClick = new RadioButton();//проверяет нажатый месяц.

        private bool updateIt = false;//Проверка нажатия update.

        public List<object> nameInfo = new List<object>();//Для кое чего

        //Класс с сообщениями об ошибке и помощи.
        private Message _message = new Message();

        public string table { get; private set; }//Таблица базы.

        public Dictionary<string, string> _idElement = new Dictionary<string, string>() { { "idLaborant", "fam"} };
        private Dictionary<string, string> _tableName = new Dictionary<string, string>() { {"users", "users"} }; 

        public BaseForm(string conn, string table)
        {
            this._conn = conn;
            this.table = table;
            
            mCon = new MySqlConnection(conn);

            InitializeComponent();

            this.Text = table;

            //дата с 1 числа этого месяца.
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
            Table(ref _idElement, ref _tableName);
            Renewal(month, _day);
        }
        
        //начальный размер
        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Table(ref Dictionary<string,string> idElement, ref Dictionary<string,string> tableName)
        {
            //idElement (как называется элемент от которого надо брать id, как называется элемент из какой таблице брать)
            //tableName (база данных от куда брать значение, как называется таблица из которой брать элемент)
            switch (table)
            {
                case "cement":
                    break;
                case "lime_activity":
                    break;
                case "lime_blankings":
                    break;
                case "aerated_block":
                    idElement.Add("idDensity", "value");
                    tableName.Add("mmm", "density");
                    break;
                case "drymixes":
                    break;
                case "technology":
                    break;
                case "sludge":
                    break;
            }
        }

        public string SqlCode()
        {
            int i = 0;

            string sql = $"SELECT {_dataBase}.{table}.*";

            foreach (var item in _idElement)
            {
                int j = 0;
                foreach (var element in _tableName)
                {
                    if (i == j)
                    {
                        sql += $", {element.Key}.{element.Value}.{item.Value}";
                    }
                    j++;
                }
                i++;
            }

            sql += $" from {_dataBase}.{table} ";

            i = 0;
            foreach (var item in _idElement)
            {
                int j = 0;
                foreach (var element in _tableName)
                {
                    if (i == j)
                    {
                        sql += $" left join {element.Key}.{element.Value} on {item.Key} = {element.Value}.id";
                    }
                    j++;
                }
                i++;
            }
            return sql;
        }

        private void Renewal(int month, int day)
        {
            string sql = SqlCode();

            sql = sql + $" where (`data` BETWEEN '{numericUpDown1.Value}-{month}-01' and '{numericUpDown1.Value}-{month}-{day}')";

            mCon.Open();
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_base.DataSource = ds.Tables[0];
            mCon.Close();

            //Скорее всего есть смысл написать его в начале и просто выводить медот чтобы 2 раза не инициализировать так как зачем мне проверять весь список если я уже знаю что мне надо.
            ListRename list = new ListRename(this);

            _elementTable = list.elementTable;
        }

        private void Search()
        {
            string data = dateTimePicker_from.Value.ToString("yyyy-MM-dd");
            string data2 = dateTimePicker_before.Value.ToString("yyyy-MM-dd");

            string sql = SqlCode();
            
            sql = sql + $"where (`data` BETWEEN '{data}' and '{data2}')";

            mCon.Open();
            MySqlDataAdapter dD = new MySqlDataAdapter(sql, mCon);
            DataSet ds = new DataSet();
            ds.Reset();
            dD.Fill(ds, sql);
            dataGridView_base.DataSource = ds.Tables[0];
            mCon.Close();

            ListRename list = new ListRename(this);

            _elementTable = list.elementTable;
        }

        //Нажатия кнопки поиска
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

        //Показывает какая месяц выбран
        private void radioButton_Click(object sender, EventArgs e)
        {
            LastDay(sender);
            _radioClick = (RadioButton)sender;
        }

        //Находит последний день месяца в зависимости от нажатого месяца
        private void LastDay(object radioButton)
        {
            DateTime day = new DateTime(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(((RadioButton)radioButton).Tag), 1);
            day = day.AddMonths(1).AddDays(-1);
            Renewal(Convert.ToInt32(((RadioButton)radioButton).Tag), day.Day);
        }

        //Находит последний день этого месяца
        private int LastDay(int month)
        {
            DateTime day = new DateTime(Convert.ToInt32(numericUpDown1.Value), month, 1);
            day = day.AddMonths(1).AddDays(-1);
            return day.Day;
        }

        //Добавить данные в таблицу
        private void button_add_Click(object sender, EventArgs e)
        {
            updateIt = false;
            AddForm(updateIt);
        }

        //Обновить данные таблицы
        private void dataGridView_base_DoubleClick(object sender, EventArgs e)
        {
            if(updateIt == true) 
            {
                AddForm(updateIt);
            }
        }

        private List<string> AddListData()
        {
            List<string> lineInfo = new List<string>();

            for (int i = 0; i <= _elementTable; i++)
            {
                lineInfo.Add(dataGridView_base.SelectedCells[i].Value.ToString());
            }
            return lineInfo;
        }

        private void AddForm(bool updateIt)
        {
            switch (table)
            {
                case "cement":
                    if(updateIt == false)
                    {
                        AddCement addCement = new AddCement(_conn, table, _dataBase, _idElement);
                        addCement.ShowDialog();
                    }
                    else
                    {
                        List<string> lineInfo = AddListData();

                        AddCement addCement = new AddCement(_conn, table, _dataBase, lineInfo, nameInfo, _idElement);
                        addCement.Text = "Изменение данных";
                        addCement.ShowDialog();
                    }
                    break;
                case "lime_activity":
                    if(updateIt == false)
                    {
                        AddLimeActivity addLimeActivity = new AddLimeActivity(_conn, table, _dataBase, _idElement);
                        addLimeActivity.ShowDialog();
                        break;
                    }
                    else
                    {
                        List<string> lineInfo = AddListData();

                        AddLimeActivity addLimeActivity = new AddLimeActivity(_conn, table, _dataBase, lineInfo, nameInfo, _idElement);
                        addLimeActivity.Text = "Изменение данных";
                        addLimeActivity.ShowDialog();
                    }
                    break;
                case "lime_blankings":
                    if(updateIt == false)
                    {
                        AddLimeBlankings addLimeBlankings = new AddLimeBlankings(_conn, table, _dataBase, _idElement);
                        addLimeBlankings.ShowDialog();
                    }
                    else
                    {
                        List<string> lineInfo = AddListData();

                        AddLimeBlankings addLimeBlankings = new AddLimeBlankings(_conn, table, _dataBase, lineInfo, nameInfo, _idElement);
                        addLimeBlankings.Text = "Изменение данных";
                        addLimeBlankings.ShowDialog();
                    }
                    break;
                case "aerated_block":
                    if (updateIt == false)
                    {
                        AddAeratedBlock addAeratedBlock = new AddAeratedBlock(_conn, table, _dataBase, _idElement);
                        addAeratedBlock.ShowDialog();
                    }
                    else
                    {
                        List<string> lineInfo =  AddListData();

                        AddAeratedBlock addAeratedBlock = new AddAeratedBlock(_conn, table, _dataBase, lineInfo, nameInfo, _idElement);
                        addAeratedBlock.Text = "Изменение данных";
                        addAeratedBlock.ShowDialog();
                    }
                    break;
                case "drymixes":
                    if (updateIt == false)
                    {
                        AddDryMix addDryMix = new AddDryMix(_conn, table, _dataBase, _idElement);
                        addDryMix.ShowDialog();
                    }
                    else
                    {
                        List<string> lineInfo = AddListData();

                        AddDryMix addDryMix = new AddDryMix(_conn, table, _dataBase, lineInfo, nameInfo, _idElement);
                        addDryMix.Text = "Изменение данных";
                        addDryMix.ShowDialog();
                    }
                    break;
                case "technology":
                    if (updateIt == false)
                    {
                        AddTechnology addTechnology = new AddTechnology(_conn, table, _dataBase, _idElement);
                        addTechnology.ShowDialog();
                    }
                    else
                    {
                        List<string> lineInfo = AddListData();

                        AddTechnology addTechnology = new AddTechnology(_conn, table, _dataBase, lineInfo, nameInfo, _idElement);
                        addTechnology.Text = "Изменение данных";
                        addTechnology.ShowDialog();
                    }
                    break;
                case "sludge":
                    if (updateIt == false)
                    {
                        AddSludge addSludge = new AddSludge(_conn, table, _dataBase, _idElement);
                        addSludge.ShowDialog();
                    }
                    else
                    {
                        List<string> lineInfo = AddListData();

                        AddSludge addSludge = new AddSludge(_conn, table, _dataBase, lineInfo, nameInfo, _idElement);
                        addSludge.Text = "Изменение данных";
                        addSludge.ShowDialog();
                    }
                    break;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(updateIt == false)
            {
                updateIt = true;
            }
            else
            {
                updateIt = false;
            }
        }
    }

    //Class для переименования и избавление от лишних элементов в dataGrid
    class ListRename
    {
        private string _nameTable;
        private BaseForm _baseForm;
        public List<string> rename;

        public int elementTable { get; private set; }

        public ListRename(BaseForm baseForm)
        {
            _baseForm = baseForm;
            _nameTable = _baseForm.table;
            this.List(_nameTable, ref rename);
        }

        private List<object> AddListDataName(BaseForm baseForm)
        {
            if((int)baseForm.nameInfo.Count() - 1 != elementTable)
            {
                for (int i = 0; i <= elementTable; i++)
                {
                    baseForm.nameInfo.Add(baseForm.dataGridView_base.Columns[i].HeaderText.ToString());
                }
            }
            return baseForm.nameInfo;
        }

        //В зависимости от таблице будет вызвать свою форму вида
        private void List(string nameTable, ref List<string> rename)
        {
            switch (nameTable)
            {
                case "cement":
                    elementTable = FormCement(_baseForm);
                    break;
                case "lime_activity":
                    elementTable = FormLimeActivity(_baseForm);
                    break;
                case "lime_blankings":
                    elementTable = FormLimeBlankings(_baseForm);
                    break;
                case "aerated_block":
                    elementTable = FormAerated_block(_baseForm);
                    break;
                case "drymixes":
                    elementTable = FormDrymixes(_baseForm);
                    break;
                case "technology":
                    elementTable = FormTechnology(_baseForm);
                    break;
                case "sludge":
                    elementTable = FormSludge(_baseForm);
                    break;
            }
        }

        private int FormSludge(BaseForm baseForm)
        {
            elementTable = baseForm.dataGridView_base.ColumnCount - 1;

            baseForm.nameInfo = AddListDataName(baseForm);

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
            baseForm.dataGridView_base.Columns["sievePassPercent_0_09"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["sievePassPercent_0_08"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 11;
            baseForm.dataGridView_base.Columns["fam"].HeaderText = rename[8];

            elementTable = baseForm.dataGridView_base.ColumnCount - 1;
            return elementTable;
        }

        private int FormTechnology(BaseForm baseForm)
        {
            elementTable = baseForm.dataGridView_base.ColumnCount - 1;

            baseForm.nameInfo = AddListDataName(baseForm);

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
            baseForm.dataGridView_base.Columns["CaO_Percent"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["dryWeight_kg"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["solidWaterPercent"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["tKon"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["idRecipe"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["oilConsumption_litr"].HeaderText = rename[8];
            baseForm.dataGridView_base.Columns["chamberT"].HeaderText = rename[9];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[10];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 14;
            baseForm.dataGridView_base.Columns["fam"].HeaderText = rename[11];

            elementTable = baseForm.dataGridView_base.ColumnCount - 1;
            return elementTable;
        }

        private int FormCement(BaseForm baseForm)
        {
            elementTable = baseForm.dataGridView_base.ColumnCount - 1;

            baseForm.nameInfo = AddListDataName(baseForm);

            List<string> namesVisibl = new List<string>() { "id", "idLaborant", "dataCreate" };

            List<string> rename = new List<string>() {"Дата", "Масса пробы, г", "Наименование", "Вода, мл", "Вода, %",
                "Время Движения пестика, мин", "Глубина погружения пестика, мм (6±1)", "Комментарий", "Лаборант"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }
            baseForm.dataGridView_base.Columns["data"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["sampleWeight"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["denomination"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["water_ml"].HeaderText = rename[3];
            baseForm.dataGridView_base.Columns["waterPercent"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["pestleMovementTime_min"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["estleImmersionDepth_mm"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 11;
            baseForm.dataGridView_base.Columns["fam"].HeaderText = rename[8];

            return elementTable;
        }

        private int FormLimeActivity(BaseForm baseForm)
        {
            elementTable = baseForm.dataGridView_base.ColumnCount - 1;

            baseForm.nameInfo = AddListDataName(baseForm);

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
            baseForm.dataGridView_base.Columns["A"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["Acp"].HeaderText = rename[8];
            baseForm.dataGridView_base.Columns["sampleWeight_rotationTime"].HeaderText = rename[9];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[10];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 14;
            baseForm.dataGridView_base.Columns["fam"].HeaderText = rename[11];

            elementTable = baseForm.dataGridView_base.ColumnCount - 1;
            return elementTable;
        }

        private int FormLimeBlankings(BaseForm baseForm)
        {
            elementTable = baseForm.dataGridView_base.ColumnCount - 1;

            baseForm.nameInfo = AddListDataName(baseForm);

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
            baseForm.dataGridView_base.Columns["fam"].HeaderText = rename[8];

            elementTable = baseForm.dataGridView_base.ColumnCount - 1;
            return elementTable;
        }

        private int FormDrymixes(BaseForm baseForm)
        {
            elementTable = baseForm.dataGridView_base.ColumnCount - 1;

            baseForm.nameInfo = AddListDataName(baseForm);

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
            baseForm.dataGridView_base.Columns["waterPercent"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["sieveResidue_100gram"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["sieve_residue"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[8];
            baseForm.dataGridView_base.Columns["comment"].DisplayIndex = 12;
            baseForm.dataGridView_base.Columns["fam"].HeaderText = rename[9];

            elementTable = baseForm.dataGridView_base.ColumnCount - 1;
            return elementTable;
        }

        private int FormAerated_block(BaseForm baseForm)
        {
            elementTable = baseForm.dataGridView_base.ColumnCount - 1;

            baseForm.nameInfo = AddListDataName(baseForm);

            List<string> namesVisibl = new List<string>() { "id", "idDensity", "idLaborant", "dataCreate" };

            List<string> rename = new List<string>() {"Дата заливки", "Дата испытания", "Номер партии", "Плотность", "Время ( день / ночь )", "Размер блока, мм", "Масса образца сухого, г", "Масса образца влажного, г", "Длинна, мм", "Ширина, мм", "Высота, мм", "Разрушающая нагрузка ка, кН","Лаборант", "Комментарий"};

            foreach (DataGridViewColumn item in baseForm.dataGridView_base.Columns)
            {
                if (namesVisibl.Contains(item.Name)) item.Visible = false;
            }

            baseForm.dataGridView_base.Columns["data"].HeaderText = rename[0];
            baseForm.dataGridView_base.Columns["dataTest"].HeaderText = rename[1];
            baseForm.dataGridView_base.Columns["nParty"].HeaderText = rename[2];
            baseForm.dataGridView_base.Columns["value"].HeaderText = rename[3];//из другой таблице
            baseForm.dataGridView_base.Columns["day_night"].HeaderText = rename[4];
            baseForm.dataGridView_base.Columns["blockSize_mm"].HeaderText = rename[5];
            baseForm.dataGridView_base.Columns["drySampleWeight_gram"].HeaderText = rename[6];
            baseForm.dataGridView_base.Columns["sampleWetWeight_gram"].HeaderText = rename[7];
            baseForm.dataGridView_base.Columns["long_mm"].HeaderText = rename[8];
            baseForm.dataGridView_base.Columns["width_mm"].HeaderText = rename[9];
            baseForm.dataGridView_base.Columns["height_mm"].HeaderText = rename[10];
            baseForm.dataGridView_base.Columns["breakingLoad_kH"].HeaderText = rename[11];
            baseForm.dataGridView_base.Columns["fam"].HeaderText = rename[12];//из другой таблице
            baseForm.dataGridView_base.Columns["comment"].HeaderText = rename[13];

            elementTable = baseForm.dataGridView_base.ColumnCount - 1;
            return elementTable;
        }
    }
}
