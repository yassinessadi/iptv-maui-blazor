namespace MauiApp1.Services
{
	public interface IParserSerivce
	{
		public Task<string> LoadFromFileAsync(string URL);
		public Task<string> LoadFromUrlAsync(string URL);
	}
}
