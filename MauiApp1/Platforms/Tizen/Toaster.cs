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
