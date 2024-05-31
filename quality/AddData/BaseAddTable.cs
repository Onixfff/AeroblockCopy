using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace quality
{
    internal class BaseAddTable
    {
        private MySqlConnection mCon;

        private string _conn, _idTable, _table, _dataBase;

        private Dictionary<string, string> _dateDictionary = new Dictionary<string, string>();//Библиотека всех dategridv...
        private Dictionary<string, string> _textBoxsDictionary = new Dictionary<string, string>();//Библиотека всех textBoxs
        private Dictionary<string, string> _richDictionary = new Dictionary<string, string>();//Библиотека всех rich

        private Dictionary<string, string> _dictionaryId = new Dictionary<string, string>(); // Библиотека id елементов и id значений

        private Dictionary<string, string> idFullName = new Dictionary<string, string>();//Заглавные колонок соединяющихся по id с этой.

        private string _idForm;//id данной формы

        public BaseAddTable(string conn, string table, string dataBase, Dictionary<string, string> arrayId)
        {
            this._conn = conn;
            this._table = table;
            this._dataBase = dataBase;

            _dictionaryId = CreateDictionaryId(arrayId, ref idFullName);

            mCon = new MySqlConnection(conn);
        }

        private Dictionary<string, string> CreateDictionaryId(Dictionary<string,string> arrayId, ref Dictionary<string, string> idFullName)
        {
            Dictionary<string, string> dictionaryId = new Dictionary<string, string>();

            foreach (var item in arrayId)
            {
                dictionaryId.Add(item.Key,""); // Пример key - idLaborant ; value "";
                idFullName.Add(item.Key, item.Value); //Пример key - fam; value - "";
            }
            return dictionaryId;
        }

        public void Form_Click(object sender, EventArgs e, TextBox textBox)
        {
     
            if(textBox.Name == "idLaborant")
            {
                Laborant form = new Laborant(_conn);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = form.dataGridView_laborant.SelectedRows[0].Cells[3].Value.ToString();
                    _idForm = form.dataGridView_laborant.SelectedRows[0].Cells[0].Value.ToString();
                }
            }

            else if (textBox.Name == "idDensity")
            {
                Density form = new Density(_conn);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = form.dataGridView_density.SelectedRows[0].Cells[1].Value.ToString();
                    _idForm = form.dataGridView_density.SelectedRows[0].Cells[0].Value.ToString();
                }
            }
            _dictionaryId[textBox.Name] = _idForm;
        }

        private void changeTheValueDictionary(ref Dictionary<string, string> dictionary, List<TextBox> textBoxs, List<string> lineInfo, List<object> nameInfo)
        {
            Dictionary<string, string> newArray = new Dictionary<string, string>();
            for (int i = 0; i < nameInfo.Count(); i++)
            {
                for (int j = 0; j < textBoxs.Count(); j++)
                {
                    foreach (var item in dictionary)
                    {
                        if (item.Value == (string)nameInfo[i])
                        {
                            if (item.Key == textBoxs[j].Name)
                            {
                                textBoxs[j].Text = lineInfo[i];
                            }
                        }
                    }
                }
            }
        }

        public void InputData(List<string> lineInfo, List<TextBox> textBoxs, List<object> nameInfo, List<DateTimePicker> dateList, List<RichTextBox> richTextBoxes, List<ComboBox> comboBoxes)
        {
            string dateTime = "";

            for (int meaningOrAnswer = 0; meaningOrAnswer <= nameInfo.Count() - 1; meaningOrAnswer++)
            {
                bool found = _dictionaryId.ContainsKey((string)nameInfo[meaningOrAnswer]);

                if (found == true)
                {
                    _dictionaryId[(string)nameInfo[meaningOrAnswer]] = lineInfo[meaningOrAnswer];

                }

                for (int numberElement = 0; numberElement <= textBoxs.Count() - 1; numberElement++)
                {
                    if (textBoxs[numberElement].Name == (string)nameInfo[meaningOrAnswer])

                        textBoxs[numberElement].Text = lineInfo[meaningOrAnswer];

                    else if ((string)nameInfo[meaningOrAnswer] == "id")

                        _idTable = lineInfo[meaningOrAnswer];

                    changeTheValueDictionary(ref idFullName, textBoxs, lineInfo, nameInfo);
                }

                for (int j = 0; j <= dateList.Count() - 1; j++)
                {
                    if (dateList[j].Name == (string)nameInfo[meaningOrAnswer])
                    {
                        DateTime dat = Convert.ToDateTime(lineInfo[meaningOrAnswer]);
                        dateList[j].Value = dat;

                        if (_table == "technology")
                        {
                            DateTimePicker dat2 = new DateTimePicker();
                            dat2.Value = Convert.ToDateTime(lineInfo[meaningOrAnswer]);

                            dateTime = dat2.Value.ToString("HH: mm");
                        }
                    }
                }

                for (int j = 0; j <= richTextBoxes.Count() - 1; j++)
                {
                    if (richTextBoxes[j].Name == (string)nameInfo[meaningOrAnswer])
                    {
                        richTextBoxes[j].Text = lineInfo[meaningOrAnswer];
                    }
                }

                for (int i = 0; i < comboBoxes.Count(); i++)
                {
                    if ((string)nameInfo[meaningOrAnswer] == comboBoxes[i].Name)
                    {
                        comboBoxes[i].Text = lineInfo[meaningOrAnswer];
                    }
                    else if(_table == "technology")
                    {
                        comboBoxes[i].Text = dateTime;
                    }
                }

            }
        }

        public void InputData(List<string> lineInfo, List<TextBox> textBoxs, List<object> nameInfo, List<DateTimePicker> dateList, List<RichTextBox> richTextBoxes)
        {
            for (int meaningOrAnswer = 0; meaningOrAnswer <= nameInfo.Count() - 1; meaningOrAnswer++)
            {
                bool found = _dictionaryId.ContainsKey((string)nameInfo[meaningOrAnswer]);

                if (found == true)
                {
                    _dictionaryId[(string)nameInfo[meaningOrAnswer]] = lineInfo[meaningOrAnswer];

                }

                for (int numberElement = 0; numberElement <= textBoxs.Count() - 1; numberElement++)
                {
                    if (textBoxs[numberElement].Name == (string)nameInfo[meaningOrAnswer])

                        textBoxs[numberElement].Text = lineInfo[meaningOrAnswer];

                    else if ((string)nameInfo[meaningOrAnswer] == "id")

                        _idTable = lineInfo[meaningOrAnswer];

                    changeTheValueDictionary(ref idFullName, textBoxs, lineInfo, nameInfo);
                }

                for (int j = 0; j <= dateList.Count() - 1; j++)
                {
                    if (dateList[j].Name == (string)nameInfo[meaningOrAnswer])
                    {        
                        DateTime dat = Convert.ToDateTime(lineInfo[meaningOrAnswer]);
                        dateList[j].Value = dat;   
                    }
                }

                for (int j = 0; j <= richTextBoxes.Count() - 1; j++)
                {
                    if (richTextBoxes[j].Name == (string)nameInfo[meaningOrAnswer])
                    {
                        richTextBoxes[j].Text = lineInfo[meaningOrAnswer];
                    }
                }

            }
        }

        public void Update(List<TextBox> textBoxs, List<DateTimePicker> dateList, List<RichTextBox> richTextBoxes, List<object> nameInfo, List<ComboBox> comboBoxes = null)
        {
            for (int i = 0; i < nameInfo.Count(); i++)
            {
                for (int j = 0; j < dateList.Count(); j++)
                {
                    if (dateList[j].Name == (string)nameInfo[i])
                    {
                        if (_table != "technology")
                        {
                            string date = dateList[j].Value.ToString("yyyy-MM-dd");
                            _dateDictionary.Add(dateList[j].Name, Convert.ToString(date));
                        }
                        else
                        {
                            foreach(var item in comboBoxes)
                            {
                                string date2 = dateList[j].Value.ToString("yyyy-MM-dd");
                                //_dateDictionary.Add(dateList[j].Name, Convert.ToString(date2));
                                //string date = dateList[j].Value.ToString("yyyy-MM-dd");
                                DateTime date = Convert.ToDateTime(item.Text);
                                string dataTime = $"{date.ToString($"{date2} HH-mm-ss")}";
                                _dateDictionary.Add(dateList[j].Name, Convert.ToString(dataTime));
                            }
                        }
                    }
                }

                for (int j = 0; j < textBoxs.Count(); j++)
                {
                    if(textBoxs[j].Name == (string)nameInfo[i])
                    { 
                        foreach (var item in _dictionaryId)
                        {
                            if (textBoxs[j].Name == item.Key)
                            {
                                _textBoxsDictionary.Add((string)nameInfo[i], item.Value);
                            }
                            else
                            {
                                _textBoxsDictionary.Add((string)nameInfo[i], textBoxs[j].Text);
                            }
                        }
                    }
                }

                for (int j = 0; j < richTextBoxes.Count(); j++)
                {
                    if (richTextBoxes[j].Name == (string)nameInfo[i])
                    {
                        _richDictionary.Add(richTextBoxes[j].Name, richTextBoxes[j].Text);
                    }
                }
            }

            string query = $"Update {_dataBase}.{_table} set";

            foreach (var item in _textBoxsDictionary)
            {
                query += $" `{item.Key}` = '{item.Value}',";
            }

            foreach (var item in _dateDictionary)
            {
                query += $" `{item.Key}` = '{item.Value}',";
            }

            foreach (var item in _richDictionary)
            {
                query += $" `{item.Key}` = '{item.Value}'";
            }

            query += $" where id = {_idTable}";
            Query(query);
        }
        //Не ставить id элементы последними в словарь !!!!!
        public void Insert(Dictionary<string,string> arrayInsert)
        {
            string query = $"insert into {_dataBase}.{_table} (";
            int i = 0;
            bool finish = false;

            while(finish == false)
            {
                foreach (var name in arrayInsert.Keys)
                {
                    i++;
                    if(i < arrayInsert.Count())
                    {
                        query += $"`{name}`, ";
                    }
                    else
                    {
                        query += $"`{name}` )  value (";
                    }
                }
                i = 0;
                bool found;
                foreach (var text in arrayInsert)
                {
                    found = _dictionaryId.ContainsKey(text.Key);

                    i++;

                    if (found == false)
                    {
                        if (i < arrayInsert.Count())
                        {
                            query += $"'{text.Value}', ";
                        }
                        else
                        {
                            query += $"'{text.Value}')";
                            finish = true;
                        }
                    }
                    else
                    {
                        foreach(var item in _dictionaryId)
                        {
                            if(text.Key == item.Key)
                            {
                                query += $"'{item.Value}', ";
                            }
                        }
                    }
                }
            }
            Query(query);
        }

        public void Query(string query)
        {
            try
            {
                mCon.Open();

                MySqlCommand command = new MySqlCommand(query, mCon);

                command.ExecuteNonQuery();

                mCon.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка запроса", ex);
            }
        }

        public string ConvertDate(List<DateTimePicker> dates, String nameDate)
        {
            string time = "";
            foreach (var item in dates)
            {
                if (item.Name == nameDate)
                    time = item.Value.ToString("yyyy-MM-dd");
            }
            return time;
        }
        public bool CheckInput(List<RichTextBox> RichTextBoxes, List<TextBox> TextBoxsText, List<DateTimePicker> Date, List<ComboBox> comboBoxes = null)
        {
            int i;
            int step = 0;
            bool cheker = false;
            bool finish = false;
            while (finish == false)
            {
                switch (step)
                {
                    case 0:
                        i = 0;
                        foreach (RichTextBox item in RichTextBoxes)
                        {
                            if (item.Text.Trim() != null)
                                i++;
                            else
                                i--;
                        }
                        if (cheker == true)
                        {
                            step++;
                            cheker = false;
                        }
                        if (i == RichTextBoxes.Count())
                            step++;
                        else
                            finish = true;
                        break;
                    case 1:
                        i = 0;
                        foreach (var item in TextBoxsText)
                        {
                            if (item.Text.Trim() != null)
                                i++;
                            else
                                i--;
                        }
                        if (i == TextBoxsText.Count())
                            step++;
                        else
                            finish = true;
                        break;
                    case 2:                             //Надо поставить условия нормальные я дал пример типо должно равно только этому дню или дата заливки не равна дате чего-то там
                        int method = Date.Count();
                        switch (method)
                        {
                            case 1:
                                foreach (var item in Date)
                                {
                                    DateTimePicker nowDate = new DateTimePicker();

                                    if (ConvertData(item) == ConvertData(nowDate))
                                        step++;
                                    else
                                        finish = true;
                                }
                                break;
                            case 2:
                                for (int j = 0; j < Date.Count(); j++)
                                {
                                    if (ConvertData(Date[j]) != ConvertData(Date[j + 1]))
                                    {
                                        step++;
                                    }
                                    else
                                    {
                                        finish = true;
                                    }
                                    break;
                                }
                                break;
                            default:
                                Console.WriteLine("С таким количеством Дат я работать не умею");
                                finish = true;
                                cheker = false;
                                break;
                        }
                        break;
                    case 3:
                        i = 0;
                        if(comboBoxes != null)
                        {
                            foreach (var item in comboBoxes)
                            {
                                if (item.Text.Trim() != null)
                                    i++;
                                else
                                    i--;
                            }
                            if (i == comboBoxes.Count())
                                cheker = true;
                            else
                                cheker = false;
                        }
                        else
                        {
                            cheker = true;
                        }
                        finish = true;
                        break;
                    default:
                        MessageBox.Show("Ошибка перехода на проверки заполнения");
                        finish = true;
                        cheker = false;
                        break;
                }
            }

            if (cheker == true)
                return true;
            else
                return false;
        }

        private string ConvertData(DateTimePicker date)
        {
            string time = date.Value.ToString("yyyy-MM-dd");
            return time;
        }
    }
}