using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Text;

namespace calculatriceDotNet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<String> expression;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ActualizeLbl()
        {
            lblCalculation.Content = expression.ToString();
        }
        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString()==".")
            {
                if (!expression[expression.Count-1].ToString().Contains("."))
                {
                    expression[expression.Count - 1] += (sender as Button).Content.ToString();
                }
            }
            else
            {
                expression[expression.Count - 1] += (sender as Button).Content.ToString();
            }
        }

        private void BtnOperator_Click(object sender, RoutedEventArgs e)
        {
            {
                if (lblCalculation.Content.ToString() == "0")
                    lblCalculation.Content = "";
                switch ((sender as Button).Content.ToString())
                {
                    case ")":
                        if (lblCalculation.Content.ToString().Length - lblCalculation.Content.ToString().Replace("(", "").Length > lblCalculation.Content.ToString().Length - lblCalculation.Content.ToString().Replace(")", "").Length)
                        {
                            lblCalculation.Content += (sender as Button).Content.ToString();
                        }
                        break;
                    case "←":
                        lblCalculation.Content = lblCalculation.Content.ToString().Remove(lblCalculation.Content.ToString().Length - 1);
                        break;
                    case ".":
                        if (!lblCalculation.Content.ToString().Contains(".") && !lblCalculation.Content.ToString().EndsWith("(") && !lblCalculation.Content.ToString().EndsWith(")"))
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

        private string resultCalc(string calc)
        {
            DataTable dt = new DataTable();
            string v = "";
            try
            {
                v = string.Concat((int)dt.Compute(calc, ""));
            }
            catch (Exception ex)
            {
                v = "ERR";
            }
            return v;
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
