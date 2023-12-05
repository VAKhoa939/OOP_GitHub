using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class FinancialRecord
    {
        private List<Payment> payments;
        private double balance;
        public FinancialRecord()
        {
            payments = new List<Payment>();
            balance = 0;
        }

        public FinancialRecord(double balance)
        {
            this.balance = balance;
            payments = new List<Payment>();
        }

        public List<Payment> Payments
        { get { return payments; } }

        public double Balance
        { get { return balance; } }

        public void AddPayment(string type, double amount, DateTime date)
        {
            Payment newPayment = new Payment(type, amount, date);
            payments.Add(newPayment);
            balance -= amount;
            Console.WriteLine($"Payment added: {newPayment.Type} - ${newPayment.Amount} on {newPayment.Date}");
            Console.WriteLine($"Remaining balance: ${balance}");
        }

        public void DisplayPayments()
        {
            Console.WriteLine("Financial Transactions:");
            foreach (var payment in payments)
            {
                Console.WriteLine($"{payment.Date:f}: {payment.Type} - ${payment.Amount}");
            }
            Console.WriteLine($"Current Balance: ${balance}");
        }
    }
}
