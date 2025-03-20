using RFGR.SaveEditor.Services;

namespace RFGR.SaveEditor.Components.Pages;

public partial class IOOpen
{
    protected override void OnInitialized()
    {
        base.OnInitialized();
        SaveFileHandler.LocatePlatforms();
    }
}