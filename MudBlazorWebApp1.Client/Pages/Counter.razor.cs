using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Globalization;

namespace MudBlazorWebApp1.Client.Pages
{
    public partial class Counter
    {
        [Inject]
        private IOptions<AppOptions> _options { set; get; } = null!;
        [Inject]
        private IJSRuntime _js { set; get; } = null!;

        private CultureInfo[]? data;

        private string[] data2 = new string[0];


        protected override async Task OnInitializedAsync()
        {
            data = _options.Value.SupportedCultures.Select(culture => new CultureInfo(culture)).ToArray();
       

            data2 = new List<string>() { "hello", "world", "again" }.ToArray();
          
            Console.WriteLine("total culture: {0}", data.Length);


            await base.OnInitializedAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cultures"></param>
        /// <returns></returns>
        private async Task LanguageChanged(IEnumerable<CultureInfo> cultures)
        {
            CultureInfo? culture = cultures.FirstOrDefault();

            Console.WriteLine("1");

            if (culture is null)
            {
                return;
            }

            Console.WriteLine("2");

            if (CultureInfo.CurrentCulture.Equals(culture))
            {
                return;
            }
            Console.WriteLine("3");

            var cultureInfo = culture;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            Console.WriteLine("3.5 {0}", culture);

            await _js.InvokeVoidAsync("cookieManager.setCookie", ".AspNetCore.Culture", $"c={culture}|uic={culture}", 7);

            Console.WriteLine("4");
        }
    }
}
