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
    public partial class EditTransactionModal : Window
    {
        private MainWindow _mainWindow;
        private Transaction transaction;
        public EditTransactionModal(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            transaction = (Transaction)mainWindow.transactionsDataGrid.SelectedItem;
            transactionNameTextBox.Text = transaction.Name;
            sumTextBox.Text = transaction.Amount.ToString();
            if (transaction.Type == "Profit")
            {
                profitRadioButton.IsChecked = true;
            }
            else
            {
                lesionRadioButton.IsChecked = true;
            }
        }
        private void editTransactionModalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = transaction.Id;
                string name = transactionNameTextBox.Text;
                if (string.IsNullOrEmpty(name))
                    throw new Exception("the transaction name field is empty.");
                double amount;
                if (double.TryParse(name, out double _amount) && _amount >= 0)
                    amount = _amount;
                else
                    throw new Exception("the amount input is incorrect.");
                string? type = transactionTypePanel.Children.OfType<RadioButton>()
                    .FirstOrDefault(c => c.IsChecked == true)?.Content.ToString();
                if (transaction.Type == null)
                    throw new Exception("the transaction type field is empty");
                _mainWindow.UpdateTransaction(id, name, type!, amount);

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
