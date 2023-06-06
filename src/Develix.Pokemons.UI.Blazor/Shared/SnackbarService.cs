using Develix.Pokemons.State;
using MudBlazor;

namespace Develix.Pokemons.UI.Blazor.Shared;

public class SnackbarService : ISnackbarService
{
    private readonly ISnackbar snackbar;

    public SnackbarService(ISnackbar snackbar)
    {
        this.snackbar = snackbar;
    }

    public void ShowErrorMessage(string message)
    {
        snackbar.Add(message, Severity.Error);
    }
}
