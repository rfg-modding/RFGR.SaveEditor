using Microsoft.AspNetCore.Components;
using RFGM.Formats.Saves;
using RFGR.SaveEditor.Services;

namespace RFGR.SaveEditor.Components.Shared;

public class SaveFileComponent : ComponentBase, IDisposable
{
    [Inject] protected Sotsera.Blazor.Toaster.IToaster Toaster { get; set; }
    [Inject] protected SaveFileService SaveFileHandler { get; set; }

    protected SaveSlot Slot => SaveFileHandler.SelectedSlot;
    protected SaveSlot.GameSaveInfo Info => SaveFileHandler.SelectedSlot.Info;
    protected SaveWorld World => SaveFileHandler.SelectedSlot.World;
    protected SaveProfile Profile => SaveFileHandler.SaveFile.Profile;
    
    protected override void OnInitialized()
    {
        SaveFileHandler.OnSelectedSlotChanged += StateHasChanged;
    }

    public void Dispose()
    {
        SaveFileHandler.OnSelectedSlotChanged -= StateHasChanged;
        SaveFileHandler = null!;
        Toaster = null!;
    }
}