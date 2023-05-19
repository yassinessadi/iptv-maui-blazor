using MauiApp1.Data;
using MauiApp1.Helpers;
using MauiApp1.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Xamarin.Google.Crypto.Tink.Internal;

namespace MauiApp1.Pages
{

    public partial class Index
    {
        //[Inject] Services && Interfaces
        [Inject] IParserSerivce Service { get; set; }
        [Inject] IToaster Toaster { get; set; }
        [Inject] IIntentHandler Intents { get; set; }
        [Inject] IConnectivity Connection { get; set; }


        //Collection && List
        private List<EntrieChannel> entries = new List<EntrieChannel>();
        private List<EntrieChannel> All_entries = new List<EntrieChannel>();

        //Varaibles
        private bool IsBusy { get; set; }
        string filterText;
        private int PageSize = 100;
        private int PageNumber = 1;


        public string Active { get; set; }
        public string Rotate { get; set; }
        public bool IsConnected { get; set; } = true;
        //Methode:

        //init app
        protected override async Task OnInitializedAsync()
        {
            await data();
        }

        protected async void Loading()
        {
            await data();
        }
        private async Task data()
        {
            if (Connection.NetworkAccess != NetworkAccess.Internet)
            {
                IsConnected = false;
                return;
            }
            Active = "block";
            IsBusy = true;
            await Task.Run(async () =>
            {
                //var res = await FilePicker.Default.PickAsync();
                //var result = await Service.GetPlayList("C:\\Users\\Essadi\\Desktop\\playlist_9441681660060_plus.m3u");
                //var result = await Service.LoadFromFileAsync(res.FullPath);
                var result = await Service.LoadFromUrlAsync("http://free.one24tv.com:80/get.php?username=73471684350508&password=73471684350508&type=m3u_plus&output=mpegts");
                App.Current.Dispatcher.Dispatch(() =>
                {
                    All_entries = JsonConvert.DeserializeObject<List<EntrieChannel>>(result);
                    foreach (var item in All_entries.Take(PageSize))
                    {
                        entries.Add(item);
                    }
                });
                IsBusy = false;
            });
        }

        //Get Entry
        private void Get(EntrieChannel entry)
        {
            if (Connection.NetworkAccess != NetworkAccess.Internet)
            {
                IsConnected = false;
                return;
            }
            Intents.LauncherApplication(entry.Url, entry.Name);
		}

		//Filter 
		private void Filter()
        {
            if (Connection.NetworkAccess != NetworkAccess.Internet)
            {
                IsConnected = false;
                return;
            }
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (string.IsNullOrEmpty(filterText) || entries.Count == 0 || entries == null)
                {
                    PageNumber = 1;
                    Active = "block";
                    entries = All_entries.Take(PageSize).ToList();
                }
                else
                {
                    Active = "none";
                    entries = All_entries.Where(x => x.Name.ToLower().Contains(filterText.ToLower())).ToList();
                    if (entries.Count == 0 || entries == null)
                    {
                        PageNumber = 1;
                        Active = "block";
                        entries = All_entries.Take(PageSize).ToList();
                    }
                }
            });
        }
        //Load more
        private async Task LoadMoreAsync()
        {
            if (Connection.NetworkAccess != NetworkAccess.Internet)
            {
                IsConnected = false;
                return;
            }
            Rotate = "rotate-button";
            await Task.Delay(2000);
            Rotate = "";
            if (entries.Count == 0 || entries == null)
                return;
            if(entries.Count >= All_entries.Count)
            {
                Active = "none";
                Toaster.MakeText("End Of File.");
            }
            PageNumber += 1;

            //PageSize * (PageNumber - 1)
            //10 * (3 - 1) = 20 skipe(20) and take(10) : 3 => 30
            var result = All_entries.Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToList();
            if (result == null)
            {
                Active = "none";
                return;
            }
            foreach (var item in result)
            {
                entries.Add(item);
            }
        }
    }
}
