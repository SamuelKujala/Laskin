using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laskin_omatyö.terms
{
    public class Procent_operation
    {
        public string procentNumber = string.Empty;
        private char[] operations = new char[] { '+', '-', '*', '/' };

        List<string> chars = new List<string>();
        TextBox textBox = new TextBox();
        Label answer = new Label();

        // Get information using the constructor
        public Procent_operation(TextBox textBox, Label answer, List<string> chars) 
        { 
            this.chars = chars;
            this.textBox = textBox;
            this.answer = answer;
        }

        // This method converts the last value in the information list from a decimal to a percentage like. 0.25 -> 25
        public void RemoveProsentti()
        {
            float floatparse = float.Parse(chars[^1]);
            chars[^1] = (floatparse * 100).ToString();
            answer.Content = string.Empty;
            chars.RemoveAt(chars.Count - 1);
        }

        // This method add % value to list without % char like 25 -> 0.25
        public void AddProsentti()
        {
            // Check if last input is not empty and last char is not mathematical operators
            if (!string.IsNullOrEmpty(textBox.Text) && (textBox.Text.Last() != '*' && textBox.Text.Last() != '-' && textBox.Text.Last() != '/' && textBox.Text.Last() != '+' && textBox.Text.Last() != '.'))
            {
                // Checks if the textbox contains any mathematical operators (+, -, /, *)
                if (textBox.Text.Contains('+') || textBox.Text.Contains('-') || textBox.Text.Contains('/') || textBox.Text.Contains('*'))
                {
                    string[] parts = textBox.Text.Split(operations);
                    float luku = float.Parse(parts[^1]);

                    procentNumber = (luku / 100).ToString();

                    string indexof = (float.Parse(procentNumber) * 100).ToString();
                    int indeksi = chars.FindIndex(t => t == indexof);
                    textBox.AppendText("%");
                    
                    if (indeksi != -1)
                    {
                        chars[indeksi] = procentNumber;
                    }
                    else
                    {
                        chars.Add(procentNumber);
                    }

                }

                else
                {
                    float luku = float.Parse(textBox.Text);

                    procentNumber = (luku / 100).ToString();
                    string indexof = (float.Parse(procentNumber) * 100).ToString();
                    int indeksi = chars.FindIndex(t => t == indexof);
                    textBox.AppendText("%");

                    if (indeksi != -1)
                    {
                        chars[indeksi] = procentNumber;
                    }
                    else
                    {
                        chars.Add(procentNumber);
                    }
                }
            }
            
        }
    }
}
