using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class BrockerageCompany
    {
        private string name;
        private string address;
        private string taxId;
        private List<Brocker> brockerList;

        public BrockerageCompany() 
        {
            name = string.Empty;
            address = string.Empty;
            taxId = string.Empty;
            brockerList = new List<Brocker>();
        }

        public BrockerageCompany(string name, string address, string taxId)
        {
            this.name = name;
            this.address = address;
            this.taxId = taxId;
            brockerList = new List<Brocker>();
        }

        public string Name
        {
            get { return name; }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Company Details:\nAddress: {address}\nTax ID: {taxId}");
        }

        public void AddBrocker(Brocker brocker)
        {
            brockerList.Add(brocker);
        }

        public bool RemoveBrocker(Brocker brocker)
        {
            return brockerList.Remove(brocker);
        }

        public List<Room> ChooseRoom()
        {
            Console.Clear();
            int minArea = 0;
            int maxArea = 0;
            double minPrice = 0;
            double maxPrice = 0;

            Console.WriteLine("--------------------------------------------------\n");
            Console.WriteLine("List of information for searching the room:\n"
                + "  1. How big is the room\n"
                + "  2. Price you can affort");

            Console.WriteLine("\n--------------------------------------------------\n");
            Console.Write("1. How big is the room? (in squared meter)\n"
                + "Your input range:\n");
            Console.Write("- Minimum area:");
            minArea = Convert.ToInt32(Console.ReadLine());
            Console.Write("- Maximum area:");
            maxArea = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n--------------------------------------------------\n");
            Console.Write("2. Price you can affort? (in USD)\n"
                + "Your input range:\n");
            Console.Write("- Minimum price:");
            minPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("- Maximum price:");
            maxPrice = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            List<Room> result = SearchRooms(minArea, maxArea, minPrice, maxPrice);
            Console.WriteLine("Search Result:");
            Console.WriteLine("\n--------------------------------------------------\n");
            Room.PrintRoomList(result);
            Console.WriteLine("\n--------------------------------------------------\n");
            
            int roomId;
            List<Room> chosenRooms = new List<Room>();
            Console.Write("Choose a room: ");
            roomId = Convert.ToInt32(Console.ReadLine());
            chosenRooms.Add(result[roomId]);
            return chosenRooms;
        }

        public List<Room> SearchRooms(int minArea, int maxArea, double minPrice, double maxPrice)
        {
            List<Room> matchingRooms = new List<Room>();

            foreach (Brocker brocker in brockerList)
            {
                foreach (Owner owner in brocker.OwnerList)
                {
                    foreach (Room room in owner.RoomList)
                    {
                        if (room.MatchSearchCriteria(minArea, maxArea, minPrice, maxPrice))
                        {
                            matchingRooms.Add(room);
                        }
                    }
                }
            }
            matchingRooms = matchingRooms.OrderBy(room => room.Area).ThenBy(room => room.Price).ToList();
            return matchingRooms;
        }
    }
}
