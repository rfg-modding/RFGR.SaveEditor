using System.Globalization;
using RFGM.Formats.Saves;

namespace RFGR.SaveEditor.Utilities;

public static class SlotHelpers
{
    public static DateTime GetCreationDate(SaveSlot slot)
    {
        var info = slot.Info;
        var date = $"{info.Day}/{info.Month}/{info.Year} {info.Hours}:{info.Minutes}:{info.Seconds}";
        return DateTime.ParseExact(date, "d/M/y H:m:s", CultureInfo.InvariantCulture);
    }

    public static bool IsDlc(SaveSlot slot) => slot.Info.DlcId == 1;
}