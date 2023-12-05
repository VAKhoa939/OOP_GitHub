using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Payment
    {
        public string type;
        public double amount;
        public DateTime date;

        public Payment(string type, double amount, DateTime date)
        {
            this.type = type;
            this.amount = amount;
            this.date = date;
        }

        public string Type 
        {
            get { return type; } 
            set {  type = value; } 
        }

        public double Amount 
        { 
            get { return amount; }
            set {  amount = value; }
        }

        public DateTime Date 
        { 
            get { return date; }
            set {  date = value; }
        }
    }
}
