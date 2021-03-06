using System.Collections.Generic;
using Newtonsoft.Json;
namespace Tarzi_Backend.Helpers
{
    public class NotificationHelper
    {
        // public static string RenderNotification()
        // {
        //     if (HttpContext.Current.Session["Notifications"] == null) return null;
        //     string jsBodyOpen = "<script>";
        //     string jsBody = "";
        //     string jsBodyClose = "</script>";
        //     var notifications = JsonConvert.DeserializeObject<List<Notification>>(HttpContext.Current.Session["Notifications"].ToString());
        //     foreach (var note in notifications)
        //     {
        //         if (note.NotificationType == NotificationType.Error)
        //         {
        //             jsBody += $"toastr.error('{note.Message}','{note.Title}')";
        //         }
        //         else if (note.NotificationType == NotificationType.Success)
        //         {
        //             jsBody += $"toastr.success('{note.Message}','{note.Title}')";

        //         }
        //     }
        //     Clear();
        //     return string.Join(" ", new string[] { jsBodyOpen, jsBody, jsBodyClose });
        // }

        // public static void Clear()
        // {
        //     HttpContext.Current.Session["Notifications"] = null;
        // }
        // public static void AddNotification(Notification notification)
        // {
        //     var note = new Notification()
        //     {
        //         Message = notification.Message,
        //         NotificationType = notification.NotificationType,
        //         Title = notification.Title
        //     };
        //     var notifications = new List<Notification>();

        //     if (HttpContext.Current.Session["Notifications"] != null)
        //     {
        //         notifications = JsonConvert.DeserializeObject<List<NotificationHelper>>(HttpContext.Current.Session["Notifications"].ToString());
        //     }
        //     notifications.Add(note);
        //     HttpContext.Current.Session["Notifications"] = JsonConvert.SerializeObject(notification);
        // }
    }
    public enum NotificationType
    {
        Success,
        Error,
        Warning,
        Notice
    }
    public class Notification
    {
        public string Message { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
    }
}