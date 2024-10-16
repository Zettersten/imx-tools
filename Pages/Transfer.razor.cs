using ImxTools.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace ImxTools.Pages;

public partial class Transfer : ComponentBase
{
    public List<TokenResponseModel> SelectedElements { get; set; } = new();

    private Func<TokenResponseModel, int, string> _rowStyleFunc =>
        (x, i) =>
        {
            var selected = Grid?.SelectedItems;

            if (selected is not null && selected.Contains(x))
            {
                return "font-style: italic; background: #ddf4ff!important";
            }

            return "";
        };

    public void OnRowClickCallback(DataGridRowClickEventArgs<TokenResponseModel> ev)
    {
        return;
    }

    public MudDataGrid<TokenResponseModel>? Grid { get; set; }

    public List<TokenResponseModel> Elements { get; set; } = new();

    [Parameter]
    public string? WalletAddress { get; set; }

    [Parameter]
    public string? ToAddress { get; set; }

    private IJSObjectReference? module;

    protected override async Task OnInitializedAsync()
    {
        module = await jsRuntime.InvokeAsync<IJSObjectReference>(
            "import",
            "./Pages/Transfer.razor.js"
        );

        var items = await module.InvokeAsync<List<TokenResponseModel>>("init", WalletAddress);

        Elements.AddRange(items);
    }

    public async Task OnTransferClick()
    {
        if (module is not null && Grid is not null)
        {
            var selected = Grid?.SelectedItems;

            if (selected is null || selected.Count == 0)
            {
                return;
            }

            await module.InvokeAsync<object>(
                "transfer",
                selected.Select(x => x.TokenId),
                ToAddress?.ToLower()
            );
        }
    }
}
