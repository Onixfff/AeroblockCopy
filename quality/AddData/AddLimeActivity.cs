using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace quality
{
    public partial class AddLimeActivity : Form, IUpdateTable
    {
        private bool _update;

        private string _table, _dataBase;

        private List<object> _nameInfo;

        private BaseAddTable _baseAddTable;

        public AddLimeActivity(string conn, string table, string dataBase, Dictionary<string, string> arrayId)
        {
            _update = false;

            this._dataBase = dataBase;
            this._table = table;

            InitializeComponent();

            _baseAddTable = new BaseAddTable(conn, table, dataBase, arrayId);
        }

        public AddLimeActivity(string conn, string table, string dataBase, List<string> lineInfo, List<object> nameInfo, Dictionary<string, string> arrayId)
        {
            _update = true;

            this._dataBase = dataBase;
            this._table = table;
            this._nameInfo = nameInfo;

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
            List<TextBox> textBoxs = new List<TextBox>() { placeSelection, sampleNumber, sampleWeight_gram, hydrochloricАcid, hydrochloricAcidMedium, TCao_gram, A, Acp, sampleWeight_rotationTime, idLaborant};
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
                    Dictionary<string, string> dictionaryInput = new Dictionary<string, string>() { {idLaborant.Name, idLaborant.Text }, {data.Name, _baseAddTable.ConvertDate(Date(), "data")}, { placeSelection.Name, placeSelection.Text},
                    {sampleNumber.Name, sampleNumber.Text}, {sampleWeight_gram.Name, sampleWeight_gram.Text}, {hydrochloricАcid.Name, hydrochloricАcid.Text},
                    {hydrochloricAcidMedium.Name, hydrochloricAcidMedium.Text}, {TCao_gram.Name, TCao_gram.Text}, {A.Name, A.Text}, {Acp.Name, Acp.Text},
                    {sampleWeight_rotationTime.Name, sampleWeight_rotationTime.Text}, {comment.Name, comment.Text }};

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
