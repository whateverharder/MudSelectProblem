using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;
using System.Globalization;

namespace MudBlazorWebApp1.Client.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject]
        private IOptions<AppOptions> _options { set; get; } = null!;
        [Inject]
        private IJSRuntime _js { set; get; } = null!;

        private CultureInfo[]? data;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _theme = new()
            {
                PaletteLight = _lightPalette,
                PaletteDark = _darkPalette,
                LayoutProperties = new LayoutProperties()
            };

            data = _options.Value.SupportedCultures.Select(culture => new CultureInfo(culture)).ToArray();
            Console.WriteLine("total culture: {0}", data.Length);
        }

      

    }
}
