using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class FileIO
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
        public static List<Renter> renters;
        public static List<Owner> owners;
        public static List<List<Room>> rooms;

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
            renters = new List<Renter>
            {
                renter1,
                renter2
            };
            owners = new List<Owner>
            {
                owner1,
                owner2
            };
            rooms = new List<List<Room>>()
            {
                rooms1,
                rooms2
            };
        }
    }
}
