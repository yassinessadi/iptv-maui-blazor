using System.Text.RegularExpressions;
using MauiApp1.Data;
using MauiApp1.Helpers;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace MauiApp1.Services
{
	public class ParserSerivce : IParserSerivce
	{
		private List<EntrieChannel> Channels;
		public string URLP = Constants.UrlPattern;
		public string LogoP = Constants.LogoPattern;
		public string TitleP = Constants.TitlePattern;

		HttpClient _client;
        public ParserSerivce()
        {
			_client = new HttpClient();
		}
        public async Task<string> LoadFromFileAsync(string URL)
		{
			using StreamReader reader = File.OpenText(URL);
			var result = await reader.ReadToEndAsync();
			Channels = new List<EntrieChannel>();
			foreach (Match item in Regex.Matches(result, URLP))
			{
				var All = item.Groups[0].Value;
				var Title = Regex.Match(All, TitleP);
				var Img = Regex.Match(All, LogoP);
				//using group-title
				var GroupTitle = Title.Groups[1].Value;

				//List of tv
				var Logo = Img.Groups[1].Value;
				var Name = item.Groups[1].Value;
				var Link = item.Groups[2].Value;
				Channels.Add(new EntrieChannel
				{
					ImageUrl = Logo,
					Name = Name,
					Url = Link,
					GroupTitle = GroupTitle
				});
			}
			//var channel = Channels.Skip(PageSize * (PageNumber - 1)).Take(PageSize);
			// ( 3 * (1 - 1 ) ) = 3
			return JsonConvert.SerializeObject(Channels);
		}

		public async Task<string> LoadFromUrlAsync(string URL)
		{
			HttpResponseMessage response = await _client.GetAsync(URL);
			if (!response.IsSuccessStatusCode)
			{
				return string.Empty;
			}
			string data = await response.Content.ReadAsStringAsync();
			Parser(data,URLP);
			return JsonConvert.SerializeObject(Channels);
		}

		public void Parser(string DATA, string URLP)
		{
			Channels = new List<EntrieChannel>();
			foreach (Match item in Regex.Matches(DATA, URLP))
			{
				var All = item.Groups[0].Value;
				var Title = Regex.Match(All, TitleP);
				var Img = Regex.Match(All, LogoP);

				//using group-title
				var GroupTitle = Title.Groups[1].Value;


				//List of tv
				var Logo = Img.Groups[1].Value;
				var Name = item.Groups[1].Value;
				var Link = item.Groups[2].Value;
				Channels.Add(new EntrieChannel
				{
					ImageUrl = Logo,
					Name = Name,
					Url = Link,
					GroupTitle = GroupTitle
				});
			}
		}
	}
}
