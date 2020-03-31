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
using System.Windows.Media.TextFormatting;
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
            switch ((sender as Button).Content.ToString())
            {
                case ".":
                    if (!lblCalculation.Content.ToString().Contains("."))
                    {
                        if (lblCalculation.Content.ToString() == "")
                        {
                            lblCalculation.Content = "0";
                        }
                        lblCalculation.Content += (sender as Button).Content.ToString();
                    }
                    break;
                default:
                    lblCalculation.Content += (sender as Button).Content.ToString();
                    break;
            }
        }

        private void BtnClearStep_Click(object sender, RoutedEventArgs e)
        {
            clearCalcContent();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            clearCalcContent();
            lblCalculationPrev.Content = "";
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (lblCalculation.HasContent && !lblCalculation.Content.Equals("0"))
            {
                string calculation = lblCalculation.Content.ToString();
                string result = resultCalc(calculation);
                clearCalcContent();

                calculation = string.Concat(calculation, "=", result);

                setPreviousCalc(calculation);
                addCalcToHistory(calculation);
            }
        }

        private String resultCalc(String calc)
        {
            // TODO : calculer le résultat de l'équation et le renvoyer sous forme de chaine
            return "?";
        }

        private void clearCalcContent()
        {
            lblCalculation.Content = "0";
        }

        private void setPreviousCalc(String calc)
        {
            this.lblCalculationPrev.Content = calc;
        }
        private void addCalcToHistory(String calc)
        {
            lstBoxHistory.Items.Add(calc);
        }

        private void btnClearHistory_Click(object sender, RoutedEventArgs e)
        {
            lstBoxHistory.Items.Clear();
            lblCalculationPrev.Content = "";
        }
    }
}
