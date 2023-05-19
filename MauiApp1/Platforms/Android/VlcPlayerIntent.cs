using Android.Content;
using MauiApp1.Helpers;

namespace MauiApp1.PlatformsShared
{
	public class VlcPlayerIntent : IIntentHandler
	{
		public void LauncherApplication(string url, string name)
		{
			Intent intent = new Intent(Intent.ActionView);
			intent.SetDataAndType(Android.Net.Uri.Parse(url), "video/*");
			intent.SetPackage("org.videolan.vlc");
			intent.PutExtra("title", name);
			intent.PutExtra("from_start", false);
			intent.PutExtra("position", 900001);
			intent.AddFlags(ActivityFlags.NewTask);
			Android.App.Application.Context.StartActivity(intent);
		}
	}
}
