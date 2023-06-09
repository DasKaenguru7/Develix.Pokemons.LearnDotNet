using System.Reflection;
using MudBlazor;

namespace Develix.Pokemons.UI.Blazor.Shared;

public partial class MainLayout
{
    private bool drawerOpen = true;

    private void DrawerToggle() => drawerOpen = !drawerOpen;

    private static string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown version";

    private MudTheme customTheme = new()
    {
        Palette = new PaletteLight()
        {
            Primary = Colors.DeepPurple.Default,
            Secondary = Colors.Red.Accent4,
            AppbarBackground = Colors.Red.Default,
            Background = Colors.Grey.Lighten3,
            DrawerBackground = Colors.Grey.Lighten3,
        },
    };

}
