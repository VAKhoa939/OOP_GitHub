using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Contract
    {
        protected List<Room> roomList = new List<Room>();
        protected Owner owner;
        protected Renter renter;
        protected Brocker brocker;
        protected DateTime expiryDate;
        protected string compensationInfo;
        protected double depositAmount;
        protected double elecBill;
        protected double waterBill;
        protected double extra = 0;
        protected double total = 0;
        protected double ultiCost = 0;
        protected DateTime startDate;
        protected bool isTerminated = true;

        public Contract(List<Room> roomList, Renter renter)
        {
            this.roomList = roomList;
            owner = roomList[0].Owner;
            this.renter = renter;
            brocker = owner.Brocker;
            startDate = DateTime.Now;
            Console.Write("\nInput contract's duration (in months): ");
            expiryDate = startDate.AddMonths(Convert.ToInt32(Console.ReadLine()));
            Console.Write("\nInput compensation info: ");
            compensationInfo = Console.ReadLine();
            Console.Write("\nInput deposit amount: ");
            depositAmount = Convert.ToDouble(Console.ReadLine());
        }

        public Contract(List<Room> roomList, Renter renter, Brocker brocker, DateTime startDate, DateTime expiryDate, string compensationInfo, double depositAmount)
        {
            this.roomList = roomList;
            owner = roomList[0].Owner;
            this.renter = renter;
            this.brocker = brocker;
            this.startDate = startDate;
            this.expiryDate = expiryDate;
            this.compensationInfo = compensationInfo;
            this.depositAmount = depositAmount;
        }

        public Owner Owner 
        { 
            get { return owner; } 
        }

        public Renter Renter 
        { 
            get { return renter; } 
        }

        public double CalRefund()
        {
            return depositAmount;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Contract Details:\nDeposit Amount: ${depositAmount}\nStart Date: {startDate}\nExpiry Date: {expiryDate}\nCompensation Info: {compensationInfo}\n");
            int count = 1;
            foreach (Room room in roomList)
            {
                Console.WriteLine($"Room {count++}'s info: \n");
                room.PrintInfo();
            }
            owner.PrintInfo();
            renter.PrintInfo();
            brocker.PrintInfo();
            PrintMainSchedule();
        }

        public void ReNewLease(int x)
        {
            expiryDate.AddMonths(x);
        }

        public double AdditionalCosts(string x, double y)
        {
            Console.WriteLine($"Charge for: {x}\n");
            Console.WriteLine($"Amount: $ {y}\n");
            extra = y;
            return extra;
        }

        public double CalTotalMoney()
        {
            foreach (Room room in roomList)
            {
                total += room.Price;
            }
            return total + ultiCost + extra;
        }

        public void PrintMainSchedule()
        {
            Console.WriteLine("Your maintenance schedule every two months: ");
            for (int i = 2; i < (((expiryDate.Year - startDate.Year) * 12) + expiryDate.Month - startDate.Month); i += 2)
            {
                Console.WriteLine(startDate.AddMonths(i));
            }
        }

        public void CalUtilityBills(double elecBill, double waterBill)
        {
            this.elecBill = elecBill * roomList.Count;
            this.waterBill = waterBill * roomList.Count;
            ultiCost += elecBill + waterBill;
        }

        public void PrintUtilityBills()
        {
            Console.WriteLine($"- Electric bill: {elecBill}");
            Console.WriteLine($"- Water bill: {elecBill}");
        }
    }
}
