using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace quality
{
    public partial class AddTechnology : Form, IUpdateTable
    {
        private string _table, _dataBase;

        private int _hours;
        
        private bool _update;

        private BaseAddTable _baseAddTable;

        private List<object> _nameInfo;

        public AddTechnology(string conn, string table, string dataBase, Dictionary<string, string> arrayId)
        {
            _update = false;

            this._dataBase = dataBase;
            this._table = table;

            InitializeComponent();

            _baseAddTable = new BaseAddTable(conn, table, dataBase, arrayId);
        }

        public AddTechnology(string conn, string table, string dataBase, List<string> lineInfo, List<object> nameInfo, Dictionary<string, string> arrayId)
        {
            _update = true;

            this._nameInfo = nameInfo;
            this._dataBase = dataBase;
            this._table = table;

            InitializeComponent();

            _baseAddTable = new BaseAddTable(conn, table, dataBase, arrayId);
            _baseAddTable.InputData(lineInfo, TextBoxsText(), nameInfo, Date(), RichTextBoxes(), comboBoxes());
        }

        private List<ComboBox> comboBoxes()
        {
            List<ComboBox> comboBoxes = new List<ComboBox>() { comboBox_hourMin };
            return comboBoxes;
        }

        public List<DateTimePicker> Date()
        {
            List<DateTimePicker> dateTimePickers = new List<DateTimePicker>() { data };
            return dateTimePickers;
        }

        public List<RichTextBox> RichTextBoxes()
        {
            List<RichTextBox> richTextBoxes = new List<RichTextBox>() { comment };
            return richTextBoxes;
        }

        public List<TextBox> TextBoxsText()
        {
            List<TextBox> textBoxs = new List<TextBox>() { ripeningTime_min, stirrerTemperature, CaO_Percent, dryWeight_kg, solidWaterPercent, tKon, idRecipe, oilConsumption_litr, chamberT, idLaborant };
            return textBoxs;
        }

        private void TextBox_laborant_Click(object sender, EventArgs e)
        {
            _baseAddTable.Form_Click(sender, e, idLaborant);
        }

        private void Button_submit_Click(object sender, EventArgs e)
        {
            switch (comboBox_hourMin.SelectedIndex)
            {
                case 0:
                    _hours = 10;
                    break;
                case 1:
                    _hours = 12;
                    break;
                case 2:
                    _hours = 14;
                    break;
                case 3:
                    _hours = 16;
                    break;
                case 4:
                    _hours = 18;
                    break;
                default:
                    _hours = 00;
                    break;
            }

            Message message = new Message();

            var date1 = DateTime.Now.Date.Add(new TimeSpan(_hours, 00, 00));

            string date = data.Value.ToString("yyyy-MM-dd") + " " + date1.ToString("HH:mm:ss");

            bool check = _baseAddTable.CheckInput(RichTextBoxes(), TextBoxsText(), Date());
            if (check == true)
            {
                if (_update == false)
                {
                    Dictionary<string, string> dictionaryInput = new Dictionary<string, string>() { {idLaborant.Name, idLaborant.Text }, { data.Name, date }, {ripeningTime_min.Name, ripeningTime_min.Text},
                    {stirrerTemperature.Name, stirrerTemperature.Text}, {CaO_Percent.Name, CaO_Percent.Text}, {dryWeight_kg.Name, dryWeight_kg.Text}, {solidWaterPercent.Name, solidWaterPercent.Text},
                    {tKon.Name, tKon.Text}, {idRecipe.Name, idRecipe.Text}, {oilConsumption_litr.Name, oilConsumption_litr.Text}, {chamberT.Name, chamberT.Text}, {comment.Name, comment.Text }};

                    _baseAddTable.Insert(dictionaryInput);

                    //Листы для отключения кнопок.
                    //List<DateTimePicker> dateEnabled = new List<DateTimePicker>() {  };
                    List<TextBox> textBoxesEnabled = new List<TextBox>() {  };
                    List<ComboBox> comboBoxesEnabled = new List<ComboBox>() { comboBox_hourMin };
                    //List<RichTextBox> richTextBoxesEnabled = new List<RichTextBox>() { };
                    //Их вкл. только если надо что-то добавить

                    message.InputReturn(textBoxesEnabled, Date(), comboBoxesEnabled);
                }
                else
                {
                    _baseAddTable.Update(TextBoxsText(), Date(), RichTextBoxes(), _nameInfo, comboBoxes());

                    this.Dispose();

                    message.sentMessage();
                }
            }
            else
            {
                message.InputError("Ошибка заполнения");
            }
        }
    }
}
