using Laskin_omatyö.terms;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laskin_omatyö
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> chars = new List<string>();
        private char[] operations = new char[] { '+', '-', '*', '/' };

        Procent_operation procent;
        MathCalculator mathCalculator;
        NumberHandler numberHandler;
        ClearData clearData;

        public MainWindow()
        {
            InitializeComponent();
            ClearInput();
        }

        public void ClearInput()
        {
            mathCalculator = new MathCalculator(textBox, answer, chars);
            mathCalculator.ClearInput();
        }

        private void ButtonNumberHandler(object sender, RoutedEventArgs e)
        {
            // If Calculated is true you cannot write anything
            if (mathCalculator.Calculated() != true)
            {
                // The number button which you click comes to textbox
                numberHandler = new NumberHandler(textBox, chars);

                if (sender is Button clickedButton)
                {
                    switch (clickedButton.Name)
                    {
                        case "btn1":
                            numberHandler.AddItems("1");
                            break;
                        case "btn2":
                            numberHandler.AddItems("2");
                            break;
                        case "btn3":
                            numberHandler.AddItems("3");
                            break;
                        case "btn4":
                            numberHandler.AddItems("4");
                            break;
                        case "btn5":
                            numberHandler.AddItems("5");
                            break;
                        case "btn6":
                            numberHandler.AddItems("6");
                            break;
                        case "btn7":
                            numberHandler.AddItems("7");
                            break;
                        case "btn8":
                            numberHandler.AddItems("8");
                            break;
                        case "btn9":
                            numberHandler.AddItems("9");
                            break;
                        case "btn0":
                            numberHandler.AddItems("0");
                            break;
                        case "btn00":
                            numberHandler.AddItems("00");
                            break;
                    }
                }
            } 

            // Information to what to do if calculated is true
            else
            {
                MessageBox.Show("Pääset kirjoittamaan 'C'  nappia painamalla");
            }
        }

        private void ButtonOperationHandler(object sender, RoutedEventArgs e)
        {
            // If Calculated is true you cannot write anything
            if (mathCalculator.Calculated() != true)
            {
                // The char button which you click comes to textbox
                numberHandler = new NumberHandler(textBox, chars);
                procent = new Procent_operation(textBox, answer, chars);

                if (sender is Button clickedButton)
                {
                    switch (clickedButton.Name)
                    {
                        case "btnJako":

                            if (!numberHandler.CheckIn("/") == true)
                            {
                                LastNumber(textBox, chars);
                                numberHandler.AddItems("/");
                            }

                            break;

                        case "btnKerto":

                            if (!numberHandler.CheckIn("*") == true)
                            {
                                LastNumber(textBox, chars);
                                numberHandler.AddItems("*");
                            }
                            break;

                        case "btnMinus":

                            if (!numberHandler.CheckIn("-") == true)
                            {
                                LastNumber(textBox, chars);
                                numberHandler.AddItems("-");
                            }
                            break;

                        case "btnPlus":

                            if (!numberHandler.CheckIn("+") == true)
                            {
                                LastNumber(textBox, chars);
                                numberHandler.AddItems("+");
                            }
                            break;

                        case "btnPoint":

                            numberHandler.PointHandler();
                            break;

                        case "btnPros":
                            procent.AddProsentti();
                            break;
                    }

                }
            }
            // Information to what to do if calculated is true
            else
            {
                MessageBox.Show("Pääset kirjoittamaan 'C'  nappia painamalla");
            }
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            procent = new Procent_operation(textBox, answer, chars);
            clearData = new ClearData(textBox, answer, chars);

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text.EndsWith("%"))
                {
                    procent.RemoveProsentti();
                    clearData.C_system();
                }
                else if (string.IsNullOrEmpty(answer.Content as string))
                {
                    clearData.C_system();
                }

                else if (mathCalculator.Calculated() == true)
                {
                    clearData.SwapText();
                    mathCalculator.SetCalculatedFalse();
                }

                else
                {
                    if (answer.Content != null) 
                    {
                        if (answer.Content.ToString().EndsWith("%"))
                        {
                            clearData.SwapText();
                        }
                    }
                    else
                    {
                        clearData.C_system();
                    }
                }
            }
        }

        private void btnSumma_Click(object sender, RoutedEventArgs e)
        {
            mathCalculator = new MathCalculator(textBox, answer, chars);

            if (mathCalculator.CheckSumma() == false) 
            {
                LastNumber(textBox, chars);
                mathCalculator.Calculator();   
            } 
        }

        // Clears all input from laskin program
        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            ClearInput();
        }

        // Saves lastnumber to chars list if its not %
        public void LastNumber(TextBox textBox, List<string> chars)
        {
            if (!textBox.Text.EndsWith('%'))
            {
                string[] parts = textBox.Text.Split(operations);

                if (chars.Count == 0 || chars[^1] != parts[^1])
                {
                    chars.Add(parts[^1]);
                }
            }
        }
    }
}