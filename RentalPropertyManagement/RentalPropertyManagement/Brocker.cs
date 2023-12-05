using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Brocker : Human
    {
        List<Owner> ownerList = new List<Owner>();
        BrockerageCompany company = new BrockerageCompany();

        public Brocker() : base()
        {
        }

        public Brocker(string name, int id, string gender, string address, int phoneNo, string job, BrockerageCompany company) : base(name, id, gender, address, phoneNo, job)
        {
            this.company = company;
            company.AddBrocker(this);
        }

        public List<Owner> OwnerList
        {
            get { return ownerList; }
        }

        public override void PrintInfo()
        {
            Console.Write("Brocker ");
            base.PrintInfo();
            Console.WriteLine($"- From company: {company.Name}");
        }

        public void AddOwner(Owner owner) 
        {
            ownerList.Add(owner);
        }

        public bool RemoveOwner(Owner owner)
        {
            return ownerList.Remove(owner);
        }
    }
}
