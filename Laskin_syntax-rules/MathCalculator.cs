using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Laskin_omatyö.terms
{
    public class MathCalculator
    {
        public bool calculated;
        List<string> chars = new List<string>();
        TextBox textBox = new TextBox();
        Label answer = new Label();

        // Get information using the constructor
        public MathCalculator(TextBox textBox, Label answer, List<string> chars) 
        {
            this.textBox = textBox;
            this.answer = answer;
            this.chars = chars;
        }

        // This method joins the list into a single string and gives the data to the Calculate method, which handle the invoice calculation.
        public void Calculator()
        {
            string joined = string.Join("", chars).Replace(",", ".");

            answer.Content = textBox.Text;

            object teksti = Calculate(joined);
            if (teksti != null)
            {
                textBox.Text = Calculate(joined).ToString();
            }
        }

        // This method Clears all input
        public void ClearInput()
        {
            chars.Clear();
            textBox.Text = string.Empty;
            answer.Content = string.Empty;
        }

        // This method handles the calculation and checks for division by zero
        public object Calculate(string expression)
        {
            if (expression.Contains("/0"))
            {
                answer.Content = "Ei voi jakaa nollalla";
                return null;
            }

            DataTable table = new DataTable();
            calculated = true;
            return table.Compute(expression, string.Empty);
        }

        // Return calculated Value (True or false)
        public bool Calculated()
        {
            return calculated;
        }

        // Set calculated value to false
        public void SetCalculatedFalse()
        {
            calculated = false;
        }

        // Check if last letter is Math operation or %
        public bool CheckSumma()
        {
            if (textBox.Text.Last() == '+' || textBox.Text.Last() == '-' || textBox.Text.Last() == '*' || textBox.Text.Last() == '/')
            {
                answer.Content = "Ilmaisuvirhe";
                return true;
            }

            else if (textBox.Text.Last() == '%')
            {
                string text = textBox.Text;
                calculated = true;
                textBox.Text = chars[0].ToString();
                answer.Content = text;


            }
            else if (textBox.Text.Contains('+') || textBox.Text.Contains('-') || textBox.Text.Contains('/') || textBox.Text.Contains('*'))
            {
                return false;
            }

            return true;
        }

    }
}
