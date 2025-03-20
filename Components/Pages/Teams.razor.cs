using RFGM.Formats.Saves.World;
using RFGM.Formats.Saves.World.Teams;

namespace RFGR.SaveEditor.Components.Pages;

public partial class Teams
{
    private readonly Dictionary<int, string> _teamNames = new()
    {
        { 0, "Guerrilla" },
        { 1, "EDF" },
        { 2, "Civilian" },
        { 3, "Marauder" },
    };
    
    private List<Combobox<TeamDispositionData.TeamDispositions>.SelectOption<TeamDispositionData.TeamDispositions>> _dispositionOptions =
    [
        new() { Value = TeamDispositionData.TeamDispositions.Hostile, DisplayText = TeamDispositionData.TeamDispositions.Hostile.ToString() },
        new() { Value = TeamDispositionData.TeamDispositions.Unfriendly, DisplayText = TeamDispositionData.TeamDispositions.Unfriendly.ToString() },
        new() { Value = TeamDispositionData.TeamDispositions.None, DisplayText = TeamDispositionData.TeamDispositions.None.ToString() },
        new() { Value = TeamDispositionData.TeamDispositions.Friendly, DisplayText = TeamDispositionData.TeamDispositions.Friendly.ToString() },
        new() { Value = TeamDispositionData.TeamDispositions.Allied, DisplayText = TeamDispositionData.TeamDispositions.Allied.ToString() },
    ];
    
    private string GetTeamName(int id)
    {
        _teamNames.TryGetValue(id, out var name);
        return name ?? "Unknown team";
    }

    private void SetDisposition(int rowId, int colId, string disposition)
    {
        Enum.TryParse(disposition, out TeamDispositionData.TeamDispositions newDisposition);
        World.TeamDispositionState.Dispositions[rowId, colId] = newDisposition;
    }
}