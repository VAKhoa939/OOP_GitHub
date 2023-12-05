using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Renter : Human
    {
        private LeaseContract contract;
        private int repScore = 100;
        public List<Notification> notifications = new List<Notification>();
        private FinancialRecord finRecord;
        private bool hasContract = false;

        public Renter()
        {
            Console.Write("\nInput initial balance (in USD): ");
            finRecord = new FinancialRecord(Convert.ToDouble(Console.ReadLine()));
        }

        public Renter(string name, int id, string gender, string address, int phoneNo, string job, double initBalance) : base(name, id, gender, address, phoneNo, job)
        {
            finRecord = new FinancialRecord(initBalance);
        }

        public List<Notification> Notifications
        {
            get { return notifications; }
        }

        public FinancialRecord FinRecord 
        { 
            get { return finRecord; } 
            set { finRecord = value; }
        }

        public LeaseContract Contract
        {
            get { return contract; }
            set {  contract = value; }
        }

        public bool HasContract
        {
            get { return hasContract; }
        }

        public int RepScore
        {
            get { return repScore; }
            set { repScore = value; }
        }

        public override void PrintInfo()
        {
            Console.Write("Renter ");
            base.PrintInfo();
            Console.WriteLine($"- Reputation Score: {repScore}\n");
        }

        public void MakeContract(List<Room> roomList, Brocker brocker, DateTime startDate, DateTime expiryDate, string compensationInfo, double depositAmount)
        {
            hasContract = true;
            this.contract = new LeaseContract(roomList, this, brocker, startDate, expiryDate, compensationInfo, depositAmount);
            this.contract.Owner.AddContract(roomList, this, brocker, startDate, expiryDate, compensationInfo, depositAmount);
        }

        public void DisplayNotifications()
        {
            Notification.DisplayNotifications(Notifications);
        }

        public void DisplayFinancialRecord()
        {
            Console.WriteLine("Your financial record:");
            finRecord.DisplayPayments();
        }

        public static Renter Login(List<Renter> renters)
        {
            Console.WriteLine("----------Login----------");
            Console.Write("\nInput your id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Renter renter in renters)
            {
                if (renter.Id == id)
                {
                    return renter;
                }
            }
            Console.Write("\nThere isn't any renter that has this id");
            Console.WriteLine("---Press any key to continue---");
            Console.ReadKey();
            return null;
        }
    }
}
