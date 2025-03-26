using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laskin_omatyö.terms
{
    public class ClearData
    {
        TextBox textBox = new TextBox();
        Label answer = new Label();
        List<string> chars = new List<string>();
        private char[] operations = new char[] { '+', '-', '*', '/' };

        // Get information using the constructor
        public ClearData(TextBox textBox, Label answer, List<string> chars)
        {
            this.textBox = textBox;
            this.answer = answer;
            this.chars = chars;
        }

        // This method handles the calculator's Clear functions.

        public void C_system()
        {
            LastIndexOperation();
            string[] parts1 = textBox.Text.Split(operations);
            chars.Remove(parts1[^1]);
            textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            answer.Content = null;
        }

        // This checks if the last letter is operation
        public void LastIndexOperation()
        {
            if (textBox.Text.Last() == '+' || textBox.Text.Last() == '-' || textBox.Text.Last() == '*' || textBox.Text.Last() == '/')
            {
                chars.RemoveAt(chars.Count - 1);
            }
        }

        // This swap text between textbox and label
        public void SwapText()
        {
            textBox.Text = answer.Content.ToString();
            answer.Content = string.Empty;
        }
    }
}
