using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace quality
{
    public partial class AddDryMix : Form, IUpdateTable
    {
        private string _table, _dataBase;

        private bool _update;

        private BaseAddTable _baseAddTable;

        private List<object> _nameInfo = new List<object>();

        public AddDryMix(string conn, string table, string dataBase, Dictionary<string, string> arrayId)
        {
            _update = false;

            this._dataBase = dataBase;
            this._table = table;

            InitializeComponent();

            _baseAddTable = new BaseAddTable(conn, table, dataBase, arrayId);
        }

        public AddDryMix(string conn, string table, string dataBase, List<string> lineInfo, List<object> nameInfo, Dictionary<string, string> arrayId)
        {
            _update = true;

            this._nameInfo = nameInfo;
            this._dataBase = dataBase;
            this._table = table;

            InitializeComponent();
            _baseAddTable = new BaseAddTable(conn, table, dataBase, arrayId);
            _baseAddTable.InputData(lineInfo, TextBoxsText(), nameInfo, Date(), RichTextBoxes());
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
            List<TextBox> textBoxs = new List<TextBox>() { glueType, sampleNumber, weight_gram, water_ml, waterPercent, sieveResidue_100gram, sieve_residue, idLaborant};
            return textBoxs;
        }

        private void TextBox_laborant_Click(object sender, EventArgs e)
        {
            _baseAddTable.Form_Click(sender, e, idLaborant);
        }

        private void Button_submit_Click(object sender, EventArgs e)
        {
            Message message = new Message();

            bool check = _baseAddTable.CheckInput(RichTextBoxes(), TextBoxsText(), Date());
            if (check == true)
            {
                if (_update == false)
                {
                    Dictionary<string, string> dictionaryInput = new Dictionary<string, string>() { { idLaborant.Name, idLaborant.Text }, { data.Name, _baseAddTable.ConvertDate(Date(), "data")}, { glueType.Name, glueType.Text},
                    { sampleNumber.Name, sampleNumber.Text }, { weight_gram.Name, weight_gram.Text }, { water_ml.Name, water_ml.Text }, {waterPercent.Name, waterPercent.Text },
                    {sieveResidue_100gram.Name, sieveResidue_100gram.Text }, {sieve_residue.Name, sieve_residue.Text},{comment.Name, comment.Text} };
                    _baseAddTable.Insert(dictionaryInput);

                    //Листы для отключения кнопок.
                    //List<DateTimePicker> dateEnabled = new List<DateTimePicker>() {  };
                    List<TextBox> textBoxesEnabled = new List<TextBox>() { };
                    //List<ComboBox> comboBoxesEnabled = new List<ComboBox>() { };
                    //List<RichTextBox> richTextBoxesEnabled = new List<RichTextBox>() { };
                    //Их вкл. только если надо что-то добавить

                    message.InputReturn(textBoxesEnabled, Date());
                }
                else
                {
                    _baseAddTable.Update(TextBoxsText(), Date(), RichTextBoxes(), _nameInfo);

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
