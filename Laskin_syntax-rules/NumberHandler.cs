using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laskin_omatyö.terms
{
    public class NumberHandler
    {
        TextBox textBox = new TextBox();
        List<string> chars = new List<string>();

        // Get information using the constructor
        public NumberHandler(TextBox textBox, List<string> chars)
        {
            this.textBox = textBox;
            this.chars = chars;
        }

        public bool CheckIn(string painettuNappi)
        {
            // if textbox is empty
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return true;
            }

            // if textbox last char is - and clicked button is + and then change places

            else if (textBox.Text.Last() == '-' && painettuNappi == "+")
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1) + painettuNappi;
                int index = chars.FindIndex(item => item == "-");
                chars[index] = painettuNappi;
                return true;
            }

            // if textbox last char is + and clicked button is - and then change places

            else if (textBox.Text.Last() == '+' && painettuNappi == "-")
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1) + "-";
                int index = chars.FindIndex(item => item == "+");

                chars[index] = "-";
                return true;
            }

            // if textbox last char is * and clicked button is / or + and then change places

            else if (textBox.Text.Last() == '*' && (painettuNappi == "/" || painettuNappi == "+"))
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1) + painettuNappi;
                int index = chars.FindIndex(item => item == "*");

                chars[index] = painettuNappi;
                return true;
            }

            // if textbox last char is / and clicked button is * or + and then change places

            else if (textBox.Text.Last() == '/' && (painettuNappi == "*" || painettuNappi == "+"))
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1) + painettuNappi;
                int index = chars.FindIndex(item => item == "/");

                chars[index] = painettuNappi;
                return true;
            }

            // if textbox last char is + and clicked button is / or * and then change places

            else if (textBox.Text.Last() == '+' && (painettuNappi == "/" || painettuNappi == "*"))
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1) + painettuNappi;
                int index = chars.FindIndex(item => item == "+");
                chars[index] = painettuNappi;
                return true;
            }

            // if textbox last char is - and clicked button is * or / and then change places

            else if (textBox.Text.Last() == '-' && (painettuNappi == "*" || painettuNappi == "/"))
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1) + painettuNappi;
                int index = chars.FindIndex(item => item == "-");

                chars[index] = painettuNappi;
                return true;
            }

            // if textbox last char and clicked button is same

            else if (textBox.Text.Last().ToString() == painettuNappi.ToString())
            {
                return true;
            }
            return false;
        }

        public void AddItems(string painettunappi) 
        {
            if (painettunappi == "*" || painettunappi == "/" || painettunappi == "+" || painettunappi == "-")
            {
                chars.Add(painettunappi);
                textBox.AppendText(painettunappi);
            }

            else
            {
                textBox.AppendText(painettunappi);
            }
        }

        public void PointHandler()
        {
            if (textBox.Text == "0.")
            {
                return;
            }
            else if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.AppendText("0.");
            }
            else
            {
                textBox.AppendText(".");
            }
        }
    }
}
