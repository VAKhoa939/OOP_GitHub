using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Test
    {
        public static Renter currentRenter;
        public static Renter renter1;
        public static Renter renter2;
        public static BrockerageCompany company;
        public static Brocker brocker;
        public static Owner owner1;
        public static Owner owner2;
        public static List<Room> rooms1;
        public static List<Room> rooms2;
        public static List<List<Room>> rooms;

        public static void NoUITestCase()
        {
            InitializeProgram();

            renter1.Contract.PrintInfo();
            Console.WriteLine("\n");
            renter2.Contract.PrintInfo();

            List<Room> searchResults = company.SearchRooms(200, 300, 500, 700);
            Console.WriteLine("Search Results:");

            owner2.ContractList[0].SendNotification(new Notification("Your property inspection is due next week."));
            renter2.Contract.SendNotification(new Notification("Rent payment reminder: Due in 3 days."));

            // Display notifications for each user
            owner2.DisplayNotifications();
            renter2.DisplayNotifications();

            // Example for Tenant's Financial Record
            for (int month = 1; month <= 12; month++)
            {
                double monthlyRent = 1200; // Adjust the monthly rent amount as needed
                DateTime paymentDate = new DateTime(2023, month, 1);

                renter1.Contract.MakeMonthlyPayment(monthlyRent, paymentDate);
            }

            // Display renter's financial record
            renter1.DisplayFinancialRecord();

            // Display owner's financial record
            owner1.DisplayFinancialRecord();
        }

        public static void InitializeProgram()
        {
            renter1 = new Renter(
                "Jane Smith",
                001,
                "Woman",
                "6874 Low Street",
                8000,
                "Cook",
                150000
            );
            renter2 = new Renter(
                "Joel Murach",
                002,
                "Man",
                "87 Main Street",
                8000,
                "Programmer",
                120000
            );
            company = new BrockerageCompany(
                "Vanguard",
                "12 Bell Street",
                "E022"
            );
            brocker = new Brocker(
                "John Cena",
                003,
                "Man",
                "64 High Street",
                2000,
                "Wresler",
                company
            );
            owner1 = new Owner(
                "John Doe",
                004,
                "Man",
                "256 Street",
                5000,
                "Driver",
                100000,
                brocker
            );
            owner2 = new Owner(
                "Sasha Lynx",
                005,
                "Woman",
                "900 Low Street",
                7000,
                "Cook",
                250000,
                brocker
            );
            rooms1 = new List<Room>()
            {
                new Room(
                    200,
                    "Fully furnished",
                    500,
                    "123 Main Street",
                    "Any",
                    owner1
                ),
                new Room(
                    300,
                    "Not fully furnished",
                    700,
                    "456 Main Street",
                    "Male",
                    owner1
                )
            };
            rooms2 = new List<Room>()
            {
                new Room(
                    400,
                    "Fully furnished",
                    500,
                    "123 Main Street",
                    "Any",
                    owner2
                ),
                new Room(
                    200,
                    "Not fully furnished",
                    700,
                    "456 Main Street",
                    "Male",
                    owner2
                )
            };

            renter1.MakeContract(
                rooms1,
                brocker,
                DateTime.Now,
                DateTime.Now.AddMonths(6),
                "No compensation for early termination",
                300
            );
            renter1.Contract.CalUtilityBills(70, 80);

            renter2.MakeContract(
                rooms2,
                brocker,
                DateTime.Now,
                DateTime.Now.AddMonths(6),
                "No compensation for early termination",
                300
            );
            renter2.Contract.CalUtilityBills(50, 80);
            rooms = new List<List<Room>>()
            {
                rooms1,
                rooms2
            };
        }
    }
}
