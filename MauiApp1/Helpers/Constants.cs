namespace MauiApp1.Helpers
{
	public static class Constants
	{
		public const string UrlPattern = @"\btvg-name=""([^""]+)"".*\r?\n(https?\S+)";
		public const string LogoPattern = @"\btvg-logo=""([^""]+)"".*\r?\n(https?\S+)";
		public const string TitlePattern = @"\bgroup-title=""([^""]+)"".*\r?\n(https?\S+)";
	}
}
