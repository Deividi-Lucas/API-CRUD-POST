using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_api.src.Models.Filter
{
    public class NotificationContext
    {
        public List<Notification> notifications { get; private set; }

        public bool HasNotification => notifications.Any();
        public NotificationContext()
        {
            notifications = new List<Notification>();
        }

        public void AddNotificaiton(string key, string message)
        {
            notifications.Add(new Notification(key, message));
        }

        public void AddNotificaiton(Notification notification)
        {
            notifications.Add(notification);
        }
    }
}