using System;
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

namespace calculatriceDotNet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();







        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (lblCalculation.Content.ToString() == "0")
            {
                lblCalculation.Content = "";
            }
            lblCalculation.Content += (sender as Button).Content.ToString();
        }

        private void BtnClearStep_Click(object sender, RoutedEventArgs e)
        {
            lblCalculation.Content = "0";
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            lblCalculation.Content = "0";
            lblCalculationPrev.Content = "";
        }
    }
}
