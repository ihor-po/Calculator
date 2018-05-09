using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string a;
        private float lastRes;
        private string sign;
        private bool isFloat;
        private float result;
        
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            resText.Text = "";
            a = "0";
            sign = "";
            result = 0;
            lastRes = 0;

            inputText.Text = a;

            isFloat = false;

            one.Click += One_Click;
            two.Click += One_Click;
            three.Click += One_Click;
            four.Click += One_Click;
            five.Click += One_Click;
            six.Click += One_Click;
            seven.Click += One_Click;
            eight.Click += One_Click;
            nine.Click += One_Click;
            zero.Click += One_Click;

            res.Click += Res_Click;
            dot.Click += Dot_Click;

            plus.Click += Res_Click;
            minus.Click += Res_Click;
            mult.Click += Res_Click;
            div.Click += Res_Click;

            ce.Click += Ce_Click;
            c.Click += C_Click;
            back.Click += Back_Click;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            int length = a.Length;

            if ( length == 1 && a != "0")
            {
                a = "0";
            }
            else if (a.Length > 1)
            {
                a = a.Substring(0, length - 1);
            }
            else
            {
                a = "0";
            }

            inputText.Text = a;
        }

        /// <summary>
        /// Очистка всех действий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void C_Click(object sender, RoutedEventArgs e)
        {
            a = "0";
            inputText.Text = a;
            resText.Text = "";
            result = 0;
            sign = "";
        }

        /// <summary>
        /// Очитска текущего числа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ce_Click(object sender, RoutedEventArgs e)
        {
            a = "0";
            inputText.Text = a;
        }

        /// <summary>
        /// Добавление запятой (создание дробного числа)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (!isFloat)
            {
                a += ",";
                inputText.Text = a;
                isFloat = true;
            }
        }

        /// <summary>
        /// Обработка математических действий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Res_Click(object sender, RoutedEventArgs e)
        {
            if (resText.Text == "ERROR" || resText.Text == "не число")
            {
                resText.Text = "";
            }

            Button btn = sender as Button;

            float n;

            if (resText.Text.Length == 0)
            {
                result = 0;
            }
            
            if (result != 0 && sign == "")
            {
                lastRes = result;
                resText.Text = "";
            }

            if (isFloat)
            {
                isFloat = false;
            }

            try
            {
               n = float.Parse(a);
            }
            catch (Exception)
            {

                MessageBox.Show(
                    "Этот калькулятор работает с разделителем \",\"\rКалькулятор автоматически заменит разделитель!",
                    this.Title,
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );

                a.Replace(',', '.');

                n = float.Parse(a);
            }

            switch (btn.Content.ToString())
            {
                case "+":
                    if (sign != btn.Content.ToString() && sign != "")
                    {
                        AddNum(sign, n);
                        resText.Text += $"{n.ToString()} + ";
                        n = 0;
                        sign = "+";
                        a = "0";
                        break;
                    }

                    sign = "+";

                    if (result == 0)
                    {
                        result = n;
                    }
                    else
                    {
                        if (n != 0)
                        {
                            AddNum(sign, n);
                        }
                    }

                    if (lastRes == 0)
                    {
                        resText.Text += $"{n.ToString()} + ";
                    }
                    else
                    {
                        resText.Text += $"{lastRes.ToString()} + ";
                        lastRes = 0;
                    }

                    a = "0";

                    break;
                case "-":
                    if (sign != btn.Content.ToString() && sign != "")
                    {
                        AddNum(sign, n);
                        resText.Text += $"{n.ToString()} - ";
                        n = 0;
                        sign = "-";
                        a = "0";
                        break;
                    }
                    sign = "-";

                    if (result == 0)
                    {
                        result = n;
                    }
                    else
                    {
                        if (n != 0)
                        {
                            AddNum(sign, n);
                        }

                    }

                    if (lastRes == 0)
                    {
                        resText.Text += $"{n.ToString()} - ";
                    }
                    else
                    {
                        resText.Text += $"{lastRes.ToString()} - ";
                        lastRes = 0;
                    }

                    a = "0";

                    break;
                case "*":
                    if (sign != btn.Content.ToString() && sign != "")
                    {
                        AddNum(sign, n);
                        resText.Text += $"{n.ToString()} * ";
                        n = 0;
                        sign = "*";
                        a = "0";
                        break;
                    }

                    sign = "*";

                    if (result == 0)
                    {
                        result = n;
                    }
                    else
                    {
                        if (n != 0)
                        {
                            AddNum(sign, n);
                        }
                    }

                    if (lastRes == 0)
                    {
                        resText.Text += $"{n.ToString()} * ";
                    }
                    else
                    {
                        resText.Text += $"{lastRes.ToString()} * ";
                        lastRes = 0;
                    }

                    a = "0";

                    break;
                case "/":
                    if (n == 0 && sign == "/")
                    {
                        if (result != 0)
                        {
                            resText.Text = "ERROR";
                            inputText.Text = "ERROR";
                            a = "0";
                            result = 0;
                            break;
                        }
                        else
                        {
                            AddNum(sign, n);
                        }
                    }

                    if (sign != btn.Content.ToString() && sign != "")
                    {
                        AddNum(sign, n);
                        resText.Text += $"{n.ToString()} / ";
                        n = 0;
                        sign = "/";
                        a = "0";
                        break;
                    }

                    sign = "/";

                    if (result == 0)
                    {
                        result = n;
                    }
                    else
                    {
                        if (n != 0)
                        {
                            AddNum(sign, n);
                        }
                    }

                    if (lastRes == 0)
                    {
                        resText.Text += $"{n.ToString()} / ";
                    }
                    else
                    {
                        resText.Text += $"{lastRes.ToString()} / ";
                        lastRes = 0;
                    }

                    a = "0";
                    break;
                case "=":
                    if (sign != "")
                    {
                        if (n == 0 && sign == "/")
                        {
                            if (result != 0)
                            {
                                resText.Text = "ERROR";
                                inputText.Text = "ERROR";
                                a = "0";
                                result = 0;
                                break;
                            }
                            else
                            {
                                AddNum(sign, n);
                            }
                        }
                        AddNum(sign, n);
                    }

                    resText.Text += $"{n.ToString()} = {result.ToString()}; ";

                    inputText.Text = result.ToString();

                    a = "0";

                    sign = "";
                    break;
            }
        }

        /// <summary>
        /// Набирание числа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void One_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string i = btn.Content.ToString();

            if (result != 0 && sign == "")
            {
                inputText.Text = a;
                result = 0;
                resText.Text = "";
            }

            if (a != "0")
            {
                a += i;
            }
            else
            {
                a = i;
            }

            inputText.Text = a;
        }

        /// <summary>
        /// Вычисление результата
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="n"></param>
        private void AddNum(string sign, float n)
        {
            switch (sign)
            {
                case "+":
                    result += n;
                    break;
                case "-":
                    result -= n;
                    break;
                case "*":
                    result *= n;
                    break;
                case "/":
                    result /= n;
                    break;
            }
        }

    }
}
