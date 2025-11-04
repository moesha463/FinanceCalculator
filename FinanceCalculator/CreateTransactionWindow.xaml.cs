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
using System.Windows.Shapes;

namespace FinanceCalculator
{
    public partial class CreateTransactionWindow : Window
    {
        private MainWindow _mainWindow;
        public CreateTransactionWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void createTransactionModalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string transactionName = transactionNameTextBox.Text;
                string? transactionType = null;
                foreach (RadioButton radioButton in transactionTypePanel.Children)
                {
                    if (radioButton.IsChecked == true)
                    {
                        transactionType = radioButton.Content.ToString();
                        break;
                    }
                }
                double transactionSum = Double.Parse(sumTextBox.Text);
                _mainWindow.CreateNewTransaction(transactionName, transactionType!, transactionSum);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
