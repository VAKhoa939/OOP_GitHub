using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RentalPropertyManagement
{
    class LeaseContract : Contract
    {

        public LeaseContract(List<Room> roomList, Renter renter) : base(roomList, renter)
        {
            owner.ContractList.Add(new RentalContract(
                roomList,
                renter,
                brocker,
                startDate,
                expiryDate,
                compensationInfo,
                depositAmount
            ));
        }

        public LeaseContract(List<Room> roomList, Renter renter, Brocker brocker, DateTime startDate, DateTime expiryDate, string compensationInfo, double depositAmount) : base(roomList, renter, brocker, startDate, expiryDate, compensationInfo, depositAmount)
        {
        }

        public void SendNotification(Notification notification)
        {
            notification.SrcName = renter.Name;
            owner.Notifications.Add(notification);
        }

        public void PrintMonthlyPayment()
        {
            Console.WriteLine($"Your monthly payment: $ {CalTotalMoney()}");
        }

        public void MakeMonthlyPayment(double monthlyRent, DateTime paymentDate)
        {
            renter.FinRecord.AddPayment("Rent Payment", monthlyRent, paymentDate);
            owner.FinRecord.AddPayment("Received Payment", monthlyRent, paymentDate);
        }

        public void LeaveReview(string x)
        {

            Console.WriteLine(x);
        }

        public void StarReview()
        {
            owner.StarRating -= 5;
        }
    }
}
