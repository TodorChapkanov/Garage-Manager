using GarageManager.Common.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GarageManager.Web.Controllers
{
    public class BaseController : Controller
    {
        protected internal void ShowNotification(
            string message, 
            NotificationType notificationType = NotificationType.Error)
        {
            this.TempData[NotificationConstants.NotificationMessageKey] = message;
            this.TempData[NotificationConstants.NotificationTypeKey] = notificationType.ToString();
        }

      

        protected bool IsValidId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                this.ShowNotification(string.Format(
                    NotificationMessages.InvalidOperation),
                    NotificationType.Error);
                return false;
            }

            return true;
        }
    }
}
