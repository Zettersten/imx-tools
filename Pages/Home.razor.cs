using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace ImxTools.Pages;

public partial class Home : ComponentBase, IAsyncDisposable
{
    private IJSObjectReference? module;

    [Inject]
    private IJSRuntime JsRuntime { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    private TransferDetailsForm TransferDetails { get; set; } = new();

    public async ValueTask DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        this.module = await JsRuntime.InvokeAsync<IJSObjectReference>(
            "import",
            "./Pages/Transfer.razor.js"
        );
    }

    private async Task OnRegister()
    {
        if (module is not null)
        {
            await module.InvokeVoidAsync("setup");
        }
    }

    private void OnValidSubmit(EditContext _)
    {
        StateHasChanged();

        if (
            string.IsNullOrEmpty(TransferDetails.FromAddress)
            || string.IsNullOrEmpty(TransferDetails.ToAddress)
        )
        {
            return;
        }

        var route =
            $"{TransferDetails.FromAddress!.ToLower()}/to/{TransferDetails.ToAddress!.ToLower()}";
        var beta = "?beta=true";

        if (TransferDetails.IsSandbox)
        {
            route += beta;
        }

        Navigation.NavigateTo(route);
    }
}

public class TransferDetailsForm
{
    [Required]
    public string? FromAddress { get; set; }

    [Required]
    public string? ToAddress { get; set; } = "0x0000000000000000000000000000000000000000";

    [Required]
    public bool IsSandbox { get; set; } = false;
}
