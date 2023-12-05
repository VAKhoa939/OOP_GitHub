using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Human
    {
        protected string name;
        protected int id;
        protected string gender;
        protected string address;
        protected int phoneNo;
        protected string job;

        public Human()
        {
            Console.Write("\nInput name: ");
            name = Console.ReadLine();
            Console.Write("\nInput id: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nInput gender: ");
            gender = Console.ReadLine();
            Console.Write("\nInput address: ");
            address = Console.ReadLine();
            Console.Write("\nInput phone number: ");
            phoneNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nInput job: ");
            job = Console.ReadLine();
        }

        public Human(string name, int id, string gender, string address, int phoneNo, string job)
        {
            this.name = name;
            this.id = id;
            this.gender = gender;
            this.address = address;
            this.phoneNo = phoneNo;
            this.job = job;
        }

        public string Name
        {
            get { return name; }
        }
        public int Id
        {
            get { return id; }
        }

        public string Gender
        { get { return gender; } }

        public string Address
        { get { return address; } }

        public int PhoneNo
        { get { return phoneNo; } }

        public string Job
        { get { return job; } }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{name}'s info:");
            Console.WriteLine("- Name: " + name);
            Console.WriteLine("- ID: " + id);
            Console.WriteLine("- Gender: " + gender);
            Console.WriteLine("- Address: " + address);
            Console.WriteLine("- Phone number: " + phoneNo);
            Console.WriteLine("- Job: " + job);
        }
    }
}
