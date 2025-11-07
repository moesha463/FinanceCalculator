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
        private MainWindow.Transaction transaction;
        public EditTransactionModal(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            transaction = (MainWindow.Transaction)mainWindow.transactionsDataGrid.SelectedItem;
            transactionNameTextBox.Text = transaction.transactionName;
            sumTextBox.Text = transaction.transactionSum.ToString();
            if (transaction.transactionType == "Profit")
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
            int transactionId = transaction.transactionId;
            string transactionName = transactionNameTextBox.Text;
            double transactionSum = double.Parse(sumTextBox.Text);
            string? transactionType = null;
            foreach (RadioButton radioButton in transactionTypePanel.Children) 
            {
                if (radioButton.IsChecked == true)
                {
                    transactionType = radioButton.Content.ToString();
                    break;
                }
            }
            _mainWindow.UpdateTransaction(transactionId, transactionName, transactionType!, transactionSum);

            Close();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
