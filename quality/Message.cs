using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quality
{
    class Message
    {
        //Сообщение об ошибки
        public void InputError(string text ,string tag = "Ошибка")
        {
            MessageBox.Show(text, tag);
        }

        //Сообщение о продолжении заполнения таблиц.
        public void InputReturn(List<TextBox> textBoxes = null, List<DateTimePicker> dates = null, List<ComboBox> comboBoxes = null, List<RichTextBox> richTextBoxes = null, string text = "Продолжить заполнение", string tag = "Уведомление")
        {
            DialogResult dialogResult = MessageBox.Show("Продолжить заполнение", "Сообщение", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (textBoxes != null)
                {
                    foreach (var item in textBoxes)
                    {
                        item.Enabled = false;
                    }
                }
                if (dates != null)
                {
                    if(dates.Count() > 0)
                    foreach (var item in dates)
                    {
                        item.Enabled = false;
                    }
                }
                if (comboBoxes != null)
                {
                    foreach (var item in comboBoxes)
                    {
                        item.Enabled = false;
                    }
                }
                if (richTextBoxes != null)
                {
                    foreach (var item in richTextBoxes)
                    {
                        item.Enabled = false;
                    }
                }
            }
            else
            {
                Form ifrm = Application.OpenForms[2];
                ifrm.Dispose();
            }
        }

        public void sentMessage(string text = "Опереция прошла успешно", string tag = "Уведомление")
        {
            MessageBox.Show(text, tag);
        }

        //Помощник 
        public void Helper(string text, string tag = "Помощник")
        {
            //var result = MessageBox.Show(text, tag,MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            MessageBox.Show(text, tag);
        }
    }
}
