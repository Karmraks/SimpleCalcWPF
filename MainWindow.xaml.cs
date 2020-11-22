using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace SimpleWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement elements in MainRoot.Children)
            {
                if (elements is Button button)
                {
                    button.Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = ((Button)e.OriginalSource).Content.ToString();

            if (str == "AC")
            {
                textLabel.Text = string.Empty;
            }
            else if (str == "=")
            {
                int number;
                var value = new DataTable().Compute(textLabel.Text, null);

                bool success = Int32.TryParse(value.ToString(), out number);

                if (success)
                {
                    textLabel.Text = value.ToString();
                }
                else
                {
                    textLabel.Text = string.Empty;
                }
            }
            else
            {
                textLabel.Text += str;
            }
        }
    }
}
