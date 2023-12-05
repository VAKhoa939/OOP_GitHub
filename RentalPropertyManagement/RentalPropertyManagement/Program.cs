namespace RentalPropertyManagement
{
    enum EUser
    {
        renter = 1,
        owner = 2,
        brocker = 3,
        unknown = 0
    }
    class Program
    {
        private static EUser currentUser;
        private static Renter currentRenter;
        private static Owner currentOwner;
        private static Brocker currentBrocker;

        static void Main(string[] args)
        {
            //Test.NoUITestCase();
            FileIO.InitializeProgram();
            PrintMainMenu();
        }

        public static string PrintMenu(string title, List<string> menu)
        {
            int count = 1;
            Console.WriteLine($"{title}:");
            foreach (string item in menu) 
            {
                Console.WriteLine($"  {count++}. {item}");
            }
            Console.WriteLine($"  0. Return");
            Console.Write("\nYour choice: ");
            return Console.ReadLine();
        }

        private static void PrintMainMenu()
        {
            string input;
            while (true)
            {
                input = PrintMenu("Choose user", new List<string> { "Renter", "Owner", "Brocker" });
                switch (input)
                {
                    case "1":
                        currentUser = EUser.renter;
                        //RenterChooseFunction1();
                        break;
                    case "2":
                        currentUser = EUser.owner;
                        //OwnerChooseFunction1();
                        break;
                    case "3":
                        currentUser = EUser.brocker;
                        break;
                    default:
                        Console.WriteLine("Program terminated.");
                        return;
                }
                ChooseFunction1();
                Console.Clear();
            }
        }

        private static void ChooseFunction1()
        {
            Console.Clear();
            switch (currentUser)
            {
                case EUser.renter:
                    if (currentRenter != null)
                    {
                        if (!currentRenter.HasContract)
                            MakeContract();
                        else
                            RenterChooseFunction2();
                        return;
                    }
                    break;
                case EUser.owner:
                    if (currentOwner != null)
                    {
                        OwnerChooseFunction2();
                        return;
                    }
                    break;
                case EUser.brocker:
                    break;

            }

            string input = PrintMenu("Choose function", new List<string> { "Login", "Register" });
            switch (input)
            {
                case "1":
                    RenterLogin();
                    break;
                case "2":
                    RenterRegister();
                    break;
                default:
                    break;
            }
        }

        private static void RenterChooseFunction1()
        {
            Console.Clear();
            if (currentRenter != null)
            {
                if (!currentRenter.HasContract)
                    MakeContract();
                else
                    RenterChooseFunction2();
            }

            string input = PrintMenu("Choose function", new List<string> { "Login", "Register" });
            switch (input)
            {
                case "1":
                    RenterLogin();
                    break;
                case "2":
                    RenterRegister();
                    break;
                default:
                    break;
            }
        }

        private static void RenterLogin()
        {
            Console.Clear();
            currentRenter = Renter.Login(FileIO.renters);
            if (currentRenter != null)
            {
                if (!currentRenter.HasContract)
                    MakeContract();
                else
                    RenterChooseFunction2();
            }
        }

        private static void RenterRegister()
        {
            Console.Clear();
            Console.WriteLine("----------Register----------");
            currentRenter = new Renter();
            MakeContract();
        }

        private static void MakeContract()
        {
            Console.Clear();
            Console.WriteLine("----------Making Contract----------");
            Console.WriteLine("\n1. Choosing room");
            List<Room> chosenRooms = FileIO.company.ChooseRoom();
            Console.Clear();
            Console.WriteLine("----------Making Contract----------");
            Console.WriteLine("\n2. Make a lease contract");
            currentRenter.Contract = new LeaseContract(chosenRooms, currentRenter);
            RenterChooseFunction2();
        }

        private static void RenterChooseFunction2()
        {
            string input;
            while (true)
            {
                Console.Clear();
                input = PrintMenu("Choose function", new List<string>
                {
                    "Print account's information",
                    "Print lease contract's information", 
                    "Print maintenance schedule",
                    "Terminate contract"
                });
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        currentRenter.PrintInfo();
                        Console.WriteLine("---Press any key to continue---");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        currentRenter.Contract.PrintInfo();
                        Console.WriteLine("---Press any key to continue---");
                        Console.ReadKey(); ;
                        break;
                    case "3":
                        Console.Clear();
                        currentRenter.Contract.PrintMainSchedule();
                        Console.WriteLine("---Press any key to continue---");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("---Press any key to continue---");
                        Console.ReadKey();
                        break;
                    default:
                        return;
                }
            }
        }

        private static void OwnerChooseFunction1()
        {
            Console.Clear();
            if (currentOwner != null) OwnerChooseFunction2();

            string input = PrintMenu("Choose function", new List<string> { "Login", "Register" });
            switch (input)
            {
                case "1":
                    OwnerLogin();
                    break;
                case "2":
                    OwnerRegister();
                    break;
                default:
                    break;
            }
        }

        private static void OwnerLogin()
        {
            Console.Clear();
            currentOwner = Owner.Login(FileIO.owners);
            if (currentOwner != null) OwnerChooseFunction2();
        }

        private static void OwnerRegister()
        {
            Console.Clear();
            Console.WriteLine("----------Register----------");
            currentOwner = new Owner();
            OwnerChooseFunction2();
        }

        private static void OwnerChooseFunction2()
        {
            string input;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------In Contract----------");
                input = PrintMenu("Choose function", new List<string>
                {
                    "Print account's information",
                    "Print a list of rooms' information",
                    "Print a rental contract",
                    "Terminate contract"
                });
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        currentOwner.PrintInfo();
                        Console.WriteLine("---Press any key to continue---");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        currentOwner.PrintRoomListInfo();
                        Console.WriteLine("---Press any key to continue---");
                        Console.ReadKey(); ;
                        break;
                    case "3":
                        Console.Clear();
                        currentOwner.ContractList[0].PrintInfo();
                        Console.WriteLine("---Press any key to continue---");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("---Press any key to continue---");
                        Console.ReadKey();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}