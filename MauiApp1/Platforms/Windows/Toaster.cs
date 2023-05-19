using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Helpers;
using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using Windows.UI.Notifications;

namespace MauiApp1.PlatformsShared
{
    public class Toaster : IToaster
    {
        public void MakeText(string message)
        {
            var builder = new AppNotificationBuilder()
                .AddText(message);
            AppNotificationManager.Default.Show(builder.BuildNotification());
        }
    }
}
