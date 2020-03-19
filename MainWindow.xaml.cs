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

        private void WriteNewNumber(string number)
        {
            
        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (lblCalculation.Content.ToString() == "0")
            {
                lblCalculation.Content = "";
            }
            lblCalculation.Content += (sender as Button).Content.ToString();
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (this.lblCalculation.HasContent && !this.lblCalculation.Content.Equals("0"))
            {
                String calculation = this.lblCalculation.Content.ToString();
                String result = resultCalc(calculation);

                calculation = String.Concat(calculation, "=", result);

                setPreviousCalc(calculation);
                addCalcToHistory(calculation);
            }
        }

        private String resultCalc(String calc)
        {
            // TODO : calculer le résultat de l'équation et le renvoyer sous forme de chaine
            return "?";
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
        }
    }
}
