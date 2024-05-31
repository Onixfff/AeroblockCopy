using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quality
{
    interface IUpdateTable
    { 
        List<DateTimePicker> Date();
        List<RichTextBox> RichTextBoxes();
        List<TextBox> TextBoxsText();
    }
}
