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
    public partial class AddSludge : Form, IUpdateTable
    {
        private bool _update;

        private string _table, _dataBase;

        private BaseAddTable _baseAddTable;

        private List<object> _nameInfo = new List<object>();

        public AddSludge(string conn, string table, string dataBase, Dictionary<string, string> arrayId)
        {
            _update = false;

            this._dataBase = dataBase;
            this._table = table;

            InitializeComponent();

            _baseAddTable = new BaseAddTable(conn, table, dataBase, arrayId);
        }

        public AddSludge(string conn, string table, string dataBase, List<string> lineInfo, List<object> nameInfo, Dictionary<string, string> arrayId)
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
            List<TextBox> textBoxs = new List<TextBox>() { placeSelection, palletWeight_gram, palletWeightAisle_gram, palletAndSandWeigth, sievePassPercent_0_09, sievePassPercent_0_08, idLaborant };
            return textBoxs;
        }

        private void Button_post_Click(object sender, EventArgs e)
        {
            Message message = new Message();

            bool check = _baseAddTable.CheckInput(RichTextBoxes(), TextBoxsText(), Date());
            if (check == true)
            {
                if (_update == false)
                {
                    Dictionary<string, string> dictionaryInput = new Dictionary<string, string>() { {idLaborant.Name, idLaborant.Text }, { data.Name, _baseAddTable.ConvertDate(Date(), "data") }, {placeSelection.Name, placeSelection.Text},
                    {palletWeight_gram.Name, palletWeight_gram.Text}, {palletWeightAisle_gram.Name, palletWeightAisle_gram.Text}, {palletAndSandWeigth.Name, palletAndSandWeigth.Text},
                    {sievePassPercent_0_09.Name, sievePassPercent_0_09.Text}, {sievePassPercent_0_08.Name, sievePassPercent_0_08.Text}, {comment.Name, comment.Text }};

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

        private void TextBox_laborant_Click(object sender, EventArgs e)
        {
            _baseAddTable.Form_Click(sender, e, idLaborant);
        }
    }
}
