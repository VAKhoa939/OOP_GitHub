using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Owner : Human
    {
        private List<Room> roomList = new List<Room>();
        private List<RentalContract> contractList = new List<RentalContract>();
        Brocker brocker;
        private double starRating = 100;
        public List<Notification> notifications = new List<Notification>();
        private FinancialRecord finRecord;

        public Owner()
        {
            Console.Write("\nInput initial balance (in USD): ");
            finRecord = new FinancialRecord(Convert.ToDouble(Console.ReadLine()));
        }

        public Owner(string name, int id, string gender, string address, int phoneNo, string job, double initBalance, Brocker brocker) : base(name, id, gender, address, phoneNo, job)
        {
            finRecord = new FinancialRecord(initBalance);
            this.brocker = brocker;
            this.brocker.AddOwner(this);
        }

        public List<Room> RoomList
        {
            get { return roomList; }
        }

        public Brocker Brocker
        {
            get { return brocker; }
        }

        public List<RentalContract> ContractList
        {
            get { return contractList; }
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

        public double StarRating
        {
            get { return starRating; }
            set { starRating = value; }
        }

        public override void PrintInfo()
        {
            Console.Write("Owner ");
            base.PrintInfo();
            Console.WriteLine($"- Rating Score: {starRating}\n");
            Console.WriteLine($"- Brocker's name: {brocker.Name}\n");
        }

        public void AddRoom(Room room) 
        {
            roomList.Add(room);
        }

        public bool RemoveRoom(Room room) 
        {
            return roomList.Remove(room);
        }

        public void PrintRoomListInfo()
        {
            int count = 1;
            foreach (Room room in roomList)
            {
                Console.WriteLine($"Room #{count++}:");
                room.PrintInfo();
            }
        }

        public void AddContract(List<Room> roomList, Renter renter, Brocker brocker, DateTime startDate, DateTime expiryDate, string compensationInfo, double depositAmount) 
        { 
            contractList.Add(new RentalContract(roomList, renter, brocker, startDate, expiryDate, compensationInfo, depositAmount));
        }

        public bool RemoveContract(RentalContract contract)
        {
            return contractList.Remove(contract);
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

        public static Owner Login(List<Owner> owners)
        {
            Console.WriteLine("----------Login----------");
            Console.Write("\nInput your id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Owner owner in owners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }
            Console.Write("\nThere isn't any owner that has this id");
            Console.WriteLine("---Press any key to continue---");
            Console.ReadKey();

            return null;
        }
    }
}
