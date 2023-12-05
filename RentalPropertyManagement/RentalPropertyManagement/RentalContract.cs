using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class RentalContract : Contract
    {
        public RentalContract(List<Room> roomList, Renter renter) : base(roomList, renter)
        { 
        }

        public RentalContract(List<Room> roomList, Renter renter, Brocker brocker, DateTime startDate, DateTime expiryDate, string compensationInfo, double depositAmount) : base(roomList, renter, brocker, startDate, expiryDate, compensationInfo, depositAmount)
        {
        }

        public void SendNotification(Notification notification)
        {
            notification.SrcName = owner.Name;
            renter.Notifications.Add(notification);
        }

        public void Report()
        {
            renter.RepScore -= 5;
        }
    }
}
