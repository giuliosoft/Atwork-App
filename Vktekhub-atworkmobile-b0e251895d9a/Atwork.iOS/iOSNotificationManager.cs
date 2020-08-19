using System;
using Atwork.Notifications;
using UserNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(Atwork.iOS.iOSNotificationManager))]
namespace Atwork.iOS
{
    public class iOSNotificationManager : INotificationManager
    {
        int messageId = -1;

        bool hasNotificationsPermission;

        public event EventHandler NotificationReceived;

        public void Initialize()
        {
            //request permission to use local notifications
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) =>
            {
                hasNotificationsPermission = approved;
            });
        }

        public iOSNotificationManager()
        {
        }

        event EventHandler INotificationManager.NotificationReceived
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void INotificationManager.Initialize()
        {
            throw new NotImplementedException();
        }

        void INotificationManager.ReceiveNotification(string title, string message)
        {
            var args = new NotificationEventArgs()
            {
                Title = title,
                Message = message
            };
            //NotificationReceived?.Invoke(null, args);
        }

        int INotificationManager.ScheduleNotification(string title, string message)
        {
            if(!hasNotificationsPermission)
            {
                return -1;
            }

            messageId++;

            var content = new UNMutableNotificationContent()
            {
                Title = title,
                Subtitle = "",
                Body = message,
                Badge = 1
            };

            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(0.25, false);

            var request = UNNotificationRequest.FromIdentifier(messageId.ToString(), content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            {
                if(err != null)
                {
                    throw new Exception($"Failed to schedule notification: {err}");
                }
            });

            return messageId;
        }
    }

    internal class NotificationEventArgs
    {
        public NotificationEventArgs()
        {
        }

        public string Title { get; set; }
        public string Message { get; set; }
    }
}
