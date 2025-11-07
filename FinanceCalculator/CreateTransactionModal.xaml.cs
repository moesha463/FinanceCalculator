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
    public partial class CreateTransactionModal : Window
    {
        private MainWindow _mainWindow;
        public CreateTransactionModal(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void createTransactionModalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = transactionNameTextBox.Text;
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("the transaction name field is empty.");
                double amount;
                if (double.TryParse(sumTextBox.Text, out double _amount) && _amount >= 0)
                    amount = _amount;
                else
                    throw new Exception("the amount input is incorrect.");
                string? type = transactionTypePanel.Children.OfType<RadioButton>()
                    .FirstOrDefault(c => c.IsChecked == true)?.Content.ToString();
                if (type == null)
                    throw new Exception("the transaction type field is empty");
                _mainWindow.CreateNewTransaction(name, type!, amount);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
