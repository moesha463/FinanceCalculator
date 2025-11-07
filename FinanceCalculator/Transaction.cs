using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCalculator
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DateString => Date.ToString("yyyy-MM-dd HH:mm");
        public string Name { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public Transaction()
        {
            Id = 0;
            Date = DateTime.Now;
            Name = "New Sneackers";
            Type = "Description";
            Amount = 150.00;
        }
        public Transaction(int id, string name, string type, double amount)
        {
            this.Id = id;
            Date = DateTime.Now;
            this.Name = name;
            this.Type = type;
            this.Amount = amount;
        }
    }
}
