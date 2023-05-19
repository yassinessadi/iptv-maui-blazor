using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MauiApp1.Helpers;

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataMimeType = "video/*")]
//[IntentFilter(new[] { Intent.ActionSend }, Categories = new[] { Intent.CategoryDefault }, DataMimeType = "text/plain")]
public class MainActivity : MauiAppCompatActivity
{
	//public void LauncherApplication(string url, string name)
	//{
	//	//int vlcRequestCode = 42;
	//	var uri = Android.Net.Uri.Parse(url);
	//	Intent vlcIntent = new Intent(Intent.ActionView);
	//	vlcIntent.SetPackage("org.videolan.vlc");
	//	vlcIntent.SetDataAndTypeAndNormalize(uri, "video/*");
	//	vlcIntent.PutExtra("title", name);
	//	vlcIntent.PutExtra("from_start", false);
	//	vlcIntent.PutExtra("position", 900001);
	//	//StartActivityForResult(vlcIntent, vlcRequestCode);
	//	this.StartActivity(vlcIntent);
	//}
}
 