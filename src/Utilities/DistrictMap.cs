using RFGM.Formats.Saves;

namespace RFGR.SaveEditor.Utilities;

public static class DistrictMap
{
    public record DistrictInfo(string Name, string ImageFileName);
    
    public static DistrictInfo? GetDistrictInfo(SaveSlot slot)
    {
        var info = slot.Info;
        return GetDistrictInfo(info.TerritoryIndex, info.DistrictIndex);
    }
    
    public static DistrictInfo? GetDistrictInfo(int territoryIndex, int districtIndex)
    {
        return Districts.GetValueOrDefault((territoryIndex, districtIndex));
    }

    private static readonly Dictionary<(int, int), DistrictInfo> Districts = new()
    {
        { (1, 1), new DistrictInfo("Parker", "images/sectors/Parker.jpg") },
        { (1, 2), new DistrictInfo("Dust", "images/sectors/Dust.jpg") },
        { (1, 3), new DistrictInfo("Badlands", "images/sectors/Badlands.jpg") },
        { (1, 4), new DistrictInfo("Oasis", "images/sectors/Oasis.jpg") },
        { (1, 5), new DistrictInfo("Free Fire Zone", "images/sectors/FreeFireZone.jpg") },
        { (1, 6), new DistrictInfo("Eos", "images/sectors/Eos.jpg") },
        { (1, 7), new DistrictInfo("Mount Vogel", "images/sectors/MountVogel.jpg") },
        { (2, 1), new DistrictInfo("Mariner Valley", "images/sectors/MarinerValley.jpg") },
    };
}