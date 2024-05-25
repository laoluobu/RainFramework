using HandyControl.Controls;
using HandyControl.Data;
using Stocker.Helper.Notification;

namespace RainWPF.Core
{
    public class NotificationService : INotificationService
    {
        public void ErrorGlobal(string message, int waitTime = 6)
        {
            Growl.ErrorGlobal(new GrowlInfo()
            {
                Message = message,
                StaysOpen = false,
                WaitTime = waitTime,
                IsCustom = true
            });
        }

        public void Error(string message, int waitTime = 6)
        {
            Growl.Error(new GrowlInfo()
            {
                Message = message,
                StaysOpen = false,
                WaitTime = waitTime,
                IsCustom = true
            });
        }

        public void WarningGlobal(string message)
        {
            Growl.WarningGlobal(message);
        }

        public void Warning(string message)
        {
            Growl.Warning(message);
        }

        public void InfoGlobal(string message)
        {
            Growl.InfoGlobal(message);
        }

        public void Info(string message)
        {
            Growl.Info(message);
        }

        public void SuccessGlobal(string message)
        {
            Growl.SuccessGlobal(message);
        }

        public void Success(string message)
        {
            Growl.Success(message);
        }
    }
}