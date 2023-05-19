using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using MauiApp1.Helpers;

namespace MauiApp1.PlatformsShared
{
    public class Toaster : IToaster
    {
        public void MakeText(string message)
        {
            Toast.MakeText(Platform.CurrentActivity, message, ToastLength.Short).Show();
        }
    }
}
