using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace quality
{
    public partial class AddAeratedBlock : Form, IUpdateTable
    {

        private bool _update;

        //Главные переменные
        private readonly string _table, _dataBase;

        //id элементов
        private string _idLaborant, _idDensity;
        //Это массив данных из dataGrid берётся
        private List<string> _lineInfo;
        private List<object> _nameInfo = new List<object>();
        //Список TextBoxs
        private List<string> _data = new List<string>();
        //Массив названий labels
        List<string> name = new List<string>();
        // номер партии если идёт дополнительное создание то номер партии не будет изменяться (возможно не реализовал)
        string textDensity = "";

        private Dictionary<string,string> _arrayId;

        private BaseAddTable _baseAddTable;

        //конструктор для добавления
        public AddAeratedBlock(string conn, string table, string dataBase, Dictionary<string, string> arrayId)
        {
            this._dataBase = dataBase;
            this._table = table;
            this._arrayId = arrayId;

            _update = false;

            InitializeComponent();

            nParty.Text = textDensity;
            name = Rename();

            _baseAddTable = new BaseAddTable(conn, table, dataBase, arrayId);
        }
        //конструктор для обновления 
        public AddAeratedBlock(string conn, string table, string dataBase, List<string> lineInfo, List<object> nameInfo, Dictionary<string, string> arrayId)
        {
            this._nameInfo = nameInfo;
            this._arrayId = arrayId;
            this._dataBase = dataBase;
            this._table = table;
            this._lineInfo = lineInfo;

            _update = true;

            InitializeComponent();

            _baseAddTable = new BaseAddTable(conn, table, dataBase, arrayId);

            nParty.Text = textDensity;

            name = Rename();

            _data = ListTextBox();

            _baseAddTable.InputData(lineInfo,TextBoxsText(), nameInfo, Date(), RichTextBoxes(), _ComboBox());
        }

        public List<DateTimePicker> Date()
        {
            List<DateTimePicker> dateTimePickers = new List<DateTimePicker>() { data, dataTest };
            return dateTimePickers;
        }

        public List<RichTextBox> RichTextBoxes()
        {
            List<RichTextBox> richTextBoxes = new List<RichTextBox>() { comment };
            return richTextBoxes;
        }

        public List<TextBox> TextBoxsText()
        {
            List<TextBox> textBoxs = new List<TextBox>() { idDensity, blockSize_mm, idLaborant, drySampleWeight_gram, sampleWetWeight_gram, long_mm, width_mm, height_mm, BreakingLoad_kH, nParty };
            return textBoxs;
        }

        private List<ComboBox> _ComboBox()
        {
            List<ComboBox> comboBoxs = new List<ComboBox>() { day_night };
            return comboBoxs;
        }

        private List<string> ListTextBox()
        {
            List<string> textBoxs = new List<string>()
                { _idDensity, day_night.Text, blockSize_mm.Text, _idLaborant, comment.Text, /*Левый столбик  0-4*/
                drySampleWeight_gram.Text, sampleWetWeight_gram.Text, long_mm.Text, width_mm.Text, height_mm.Text, BreakingLoad_kH.Text, /*Характеристики образца 5-10*/
                nParty.Text, densityGrade.Text, densityClass.Text, humidity.Text, density_mpa.Text }; /*Автозаполнение 11 - 15*/
            return textBoxs;
        }

        private List<string> Rename()
        {
            List<string> name = new List<string>() { "Дата заливки", "Дата испытания", "Номер партии", "Плотность", "Время ( день / ночь )", "Размер блока, мм", "Масса образца сухого, г",
            "Масса образца влажного, г", "Длинна, мм", "Ширина, мм", "Высота, мм", "Разрушающая нагрузка ка, кН", "Лаборант", "Комментарий"};
            return name;
        }

        private void Button_submit_Click(object sender, EventArgs e)
        {
            Message message = new Message();
            /*
            //TODO 
             Итак если перечень полей формы утвержден Владимиром Викторовичем, то будем от него и отталкиваться
            1. Разрушающуюся нагрузку необходимо перенести к характеристикам образца
            2. Влажность определяется по формуле (Мвл-Мсух)/Мвл*100
            3. Для определения плотности образца необходимо предварительно рассчитать объем образца
            по формуле V=ДхШхВх0,001. Плотность равна массе образца деленной на объем.                                                  на какой массу надо сухую или влажную?
            4. По плотности образца определяем Марку по плотности с учетем требуемой плотности
            5. прочность Разружш/(ширина*длина)
             */
            bool check = _baseAddTable.CheckInput(RichTextBoxes(), TextBoxsText(), Date());

            if (check == true)
            {
                if (_update == true)
                {
                    List<string> newData = ListTextBox();
                    _baseAddTable.Update(TextBoxsText(), Date(), RichTextBoxes(), _nameInfo, _ComboBox());

                    //_baseAddTable.Query(query);

                }
                else
                {
                    Dictionary<string, string> arrayInsert = new Dictionary<string, string>() { { data.Name, _baseAddTable.ConvertDate(Date(),"data")}, {dataTest.Name, _baseAddTable.ConvertDate(Date(),"dataTest")}, { idDensity.Name, idDensity.Text }, {day_night.Name, day_night.Text},
                { blockSize_mm.Name, blockSize_mm .Text}, {idLaborant.Name, idLaborant.Text}, {comment.Name,comment.Text}, {drySampleWeight_gram.Name,drySampleWeight_gram.Text},
                {sampleWetWeight_gram.Name, sampleWetWeight_gram.Text }, {long_mm.Name, long_mm.Text }, {width_mm.Name, width_mm.Text}, {height_mm.Name, height_mm.Text}, {BreakingLoad_kH.Name, BreakingLoad_kH.Text }, {nParty.Name, nParty.Text} };

                    _baseAddTable.Insert(arrayInsert);

                    //Листы для отключения кнопок.
                    //List<DateTimePicker> dateEnabled = new List<DateTimePicker>() {  };
                    List<TextBox> textBoxesEnabled = new List<TextBox>() { idDensity };
                    List<ComboBox> comboBoxesEnabled = new List<ComboBox>() { day_night };
                    //List<RichTextBox> richTextBoxesEnabled = new List<RichTextBox>() { };
                    //Их вкл. только если надо что-то добавить

                    message.InputReturn(textBoxesEnabled, Date(), comboBoxesEnabled);
                }
            }
            else
            {
                message.InputError("Ошибка заполнения");
            }
            
        }

        private void textBox_density_Click(object sender, EventArgs e)
        {
          _baseAddTable.Form_Click(sender, e, idDensity);
        }

        private void batchNumber_ValueChanged(object sender, EventArgs e)
        {
            batchNumber(nParty, data, day_night);
        }

        private void batchNumber(TextBox textBox, DateTimePicker dateTimePicker, ComboBox comboBox)
        {
            textBox.Text = $"{dateTimePicker.Value.ToShortDateString()} {comboBox.SelectedItem}";
        }

        private void strength_TextChanged(object sender, EventArgs e)
        {
            Strength();
        }

        private void drySampleWeight_gram_TextChanged(object sender, EventArgs e)
        {
            double hunidity;
            bool check = ChengeHumidity(out hunidity);
            if (hunidity != 0 & check != false)
            {
                humidity.Text = Convert.ToString(hunidity);
            }
        }

        private void sampleWetWeight_gram_TextChanged(object sender, EventArgs e)
        {
            double hunidity;
            bool check = ChengeHumidity(out hunidity);
            if (hunidity != 0 & check != false)
            {
                humidity.Text = Convert.ToString(hunidity);
            }
        }

        private bool ChengeHumidity(out double hunidity)
        {
            double drySample;
            double wetSample;

            if (drySampleWeight_gram.Text != null)
            {
                if (sampleWetWeight_gram.Text != null)
                {
                    bool check = double.TryParse(drySampleWeight_gram.Text, out drySample);
                    if(check == true)
                    {
                        check = double.TryParse(sampleWetWeight_gram.Text, out wetSample);
                        if(check == true)
                        {
                            hunidity = (wetSample - drySample) / wetSample * 100;
                            return true;
                        }
                        hunidity = 0;
                        return false;
                    }
                    hunidity = 0;
                    return false;
                }
                hunidity = 0;
                return false;
            }
            hunidity = 0;
            return false;
        }

        private void Strength()
        {
            float height;
            float width;
            float breakingLoad;
            bool isFinish = false;

            while (isFinish == false)
            {
                bool fff = float.TryParse(this.height_mm.Text, out height);
                if (fff == true)
                {
                    fff = float.TryParse(width_mm.Text, out width);
                    if (fff == true)
                    {
                        fff = float.TryParse(BreakingLoad_kH.Text, out breakingLoad);
                        if(fff == true)
                        {
                            isFinish = true;
                            float sum2 = breakingLoad / (width * height);
                            density_mpa.Text = sum2.ToString();
                        }
                        else
                        {
                            isFinish = true;
                        }
                    }
                    else
                    {
                        isFinish = true;
                    }
                }
                else
                {
                    isFinish = true;
                }
            }
        }

        private void TextBox_laborant_Click(object sender, EventArgs e)
        {
            _baseAddTable.Form_Click(sender, e, idLaborant);
        }
    }
}
