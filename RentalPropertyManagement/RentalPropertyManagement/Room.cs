using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Room
    {
        protected double area;
        protected double price;
        protected string furniture;
        protected string address;
        protected string genderPreference;
        protected bool petFriendly;
        protected bool privateEntrance;
        protected bool isOccupied;
        protected Owner owner;

        public Room()
        {
            area = 0;
            price = 0;
            furniture = String.Empty;
            address = String.Empty;
            genderPreference = String.Empty;
            petFriendly = false;
            privateEntrance = false;
            isOccupied = false;
            owner = new Owner();
        }

        public Room(double area, string furniture, double price, string address, string genderPreference, Owner owner)
        {
            this.area = area;
            this.furniture = furniture;
            this.price = price;
            this.address = address;
            this.genderPreference = genderPreference;
            this.owner = owner;
            this.owner.AddRoom(this);
        }
        public double Area
        {
            get { return area; }
        }
        public double Price
        {
            get { return price; }
        }
        public string Address
        {
            get { return address; }
        }
        public string GenderPreference
        {
            get { return genderPreference; }
        }
        public Owner Owner
        {
            get { return owner; }
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"- Area: {area} m2\n- Furniture: {furniture}\n- Price: $ {price}\n- Address: {address}\n- Gender Preference: {genderPreference}");
            if (petFriendly) Console.WriteLine("- Pet Friendly\n");
            else Console.WriteLine("- No pet allow\n");
        }

        public bool MatchSearchCriteria(int minArea, int maxArea, double minPrice, double maxPrice)
        {
            // Check if the room matches the search criteria
            return Area >= minArea && Area <= maxArea && Price >= minPrice && Price <= maxPrice;
        }

        public static void PrintRoomList(List<Room> roomList)
        {
            int count = 1;
            foreach (Room room in roomList)
            {
                Console.WriteLine($"Room #{count++}: Area = {room.Area} m2, Price = $ {room.Price}, Owner: {room.Owner.Name}");
            }
        }
    }
}
