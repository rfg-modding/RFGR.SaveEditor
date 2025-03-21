using RFGM.Formats.Saves.World.Metadata;
using RFGR.SaveEditor.Components.Shared;

namespace RFGR.SaveEditor.Components.Pages;

public partial class World
{
    private List<Combobox<AudioData.MusicFile>.SelectOption<AudioData.MusicFile>> _audioOptions =
    [
        new() { Value = AudioData.MusicFile.Progression01Day, DisplayText = AudioData.MusicFile.Progression01Day.ToString() },
        new() { Value = AudioData.MusicFile.Progression01Night, DisplayText = AudioData.MusicFile.Progression01Night.ToString() },
        
        new() { Value = AudioData.MusicFile.Progression02Day, DisplayText = AudioData.MusicFile.Progression02Day.ToString() },
        new() { Value = AudioData.MusicFile.Progression02Night, DisplayText = AudioData.MusicFile.Progression02Night.ToString() },
        
        new() { Value = AudioData.MusicFile.Progression03Day, DisplayText = AudioData.MusicFile.Progression03Day.ToString() },
        new() { Value = AudioData.MusicFile.Progression03Night, DisplayText = AudioData.MusicFile.Progression03Night.ToString() },
    ];
    
    private void ResetFogOfWar()
    {
        var bitArray = World.UiState.FogOfWar.BitArray;
        for (var i = 0; i < bitArray.Length; i++)
        {
            bitArray[i] = 255;
        }
        Toaster.Success("Successfully reset Fog Of War to default values.");
    }

    private void ClearFogOfWar()
    {
        var bitArray = World.UiState.FogOfWar.BitArray;
        for (var i = 0; i < bitArray.Length; i++)
        {
            bitArray[i] = 0;
        }
        Toaster.Success("Successfully cleared Fog Of War.");
    }

    private void ResetDestruction()
    {
        var objectList = World.DestroyedObjState.DestroyedObjects;
        objectList.Clear();
    }
}