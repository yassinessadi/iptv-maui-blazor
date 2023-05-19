using MauiApp1.Helpers;
using Microsoft.AspNetCore.Components;

namespace MauiApp1.Pages
{
    public partial class Counter
    {
        [Inject] IToaster Toaster { get; set; }
        private void IncrementCount()
        {
            Toaster.MakeText("Hello in maui");
        }
    }
}
