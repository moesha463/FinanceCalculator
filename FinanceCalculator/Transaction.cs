using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCalculator
{
    public class Transaction
    {
        public int transactionId { get; set; }
        public string transactionDate { get; set; }
        public string transactionName { get; set; }
        public string transactionType { get; set; }
        public double transactionSum { get; set; }
        public Transaction()
        {
            transactionId = 0;
            transactionDate = DateTime.Now.ToString();
            transactionName = "New Sneackers";
            transactionType = "Description";
            transactionSum = 150.00;
        }
        public Transaction(int id, string name, string description, double money)
        {
            this.transactionId = id;
            transactionDate = DateTime.Now.ToString();
            this.transactionName = name;
            this.transactionType = description;
            this.transactionSum = money;
        }
    }
}
