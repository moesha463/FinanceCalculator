using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanceCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            transactionsDataGrid.ItemsSource = Transactions;
            Transactions.CollectionChanged += (s, e) => UpdateTotalBalance();
        }

        public class Transaction
        {
            public int id { get; set; }
            public string transactionDate { get; set; }
            public string transactionName { get; set; }
            public string transactionType { get; set; }
            public double transactionSum { get; set; }
            public Transaction()
            {
                id = 0;
                transactionDate = DateTime.Now.ToString();
                transactionName = "New Sneackers";
                transactionType = "Description";
                transactionSum = 150.00;
            }
            public Transaction(int id, string name, string description, double money)
            {
                this.id = id;
                transactionDate = DateTime.Now.ToString();
                this.transactionName = name;
                this.transactionType = description;
                this.transactionSum = money;
            }

        }
        public ObservableCollection<Transaction> Transactions = new ObservableCollection<Transaction>();

        private void newTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTransactionWindow createTransactionWindow = new CreateTransactionWindow(this);
            createTransactionWindow.ShowDialog();
        }
        public void CreateNewTransaction(string name, string description, double money)
        {
            int id;
            if (transactionsDataGrid.Items.Count == 0)
                id = 1;
            else id = Transactions.Last().id+1;

            Transactions.Add(new Transaction(id, name, description, money));
        }
        private void UpdateTotalBalance()
        {
            double totalBalance = Transactions.Sum(t =>
                t.transactionType == "Profit" ? t.transactionSum : -t.transactionSum
            );
            totalBalanceTextBox.Text = $"{totalBalance:F2}";
        }

        private void exportToJsonButton_Click(object sender, RoutedEventArgs e)
        {
            string exportJson = JsonConvert.SerializeObject(Transactions);

            SaveFileDialog saveFileDialog = new SaveFileDialog() 
            {
                Title = "Save as",
                Filter = "JSON files (*.json)|*.json",    
                FileName = "transactions.json",
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, exportJson);
            }

        }
        private void importFromJsonButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() 
            {
                Title = "Open file",
                Filter = "JSON files (*.json)|*.json"
            };

            if(openFileDialog.ShowDialog() == true)
            {
                string importJson = File.ReadAllText(openFileDialog.FileName);

                List<Transaction>? transactionsList = JsonConvert.DeserializeObject<List<Transaction>>(importJson);
                Transactions.Clear();

                foreach (Transaction transaction in transactionsList!) 
                {
                    Transactions.Add(transaction);
                }
            }
        }
    }
}