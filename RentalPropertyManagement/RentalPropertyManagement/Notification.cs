using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPropertyManagement
{
    class Notification
    {
        protected string message;
        protected DateTime timestamp;
        protected string srcName;

        public Notification()
        {
            message = string.Empty;
            timestamp = new DateTime();
        }

        public Notification(string message)
        {
            this.message = message;
            timestamp = DateTime.Now;
        }

        public string Message
        { 
            get { return message; } 
        }

        public DateTime Timestamp
        { 
            get { return timestamp; }
        }

        public string SrcName
        {
            get { return srcName; }
            set { srcName = value; }
        }

        public void Display()
        {
            Console.WriteLine($"{timestamp}:{srcName}: {message}");
        }

        public static void DisplayNotifications(List<Notification> notifications)
        {
            Console.WriteLine("Notifications:");
            foreach (Notification notification in notifications)
            {
                notification.Display();
            }
            Console.WriteLine();
        }
    }
}
