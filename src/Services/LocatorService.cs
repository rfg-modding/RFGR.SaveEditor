using Microsoft.Win32;

namespace RFGR.SaveEditor.Services;

public class LocatorService
{
    public string DetectGogSaveLocation()
    {
        var appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        if (string.IsNullOrEmpty(appDataLocal))
            return string.Empty;
        
        var saveFilePath = Path.Combine(appDataLocal, "GOG.com", "Galaxy", "Applications", "51153410217180642", "Storage", "Shared", "Files", "autocloud", "save", "keen_savegame_0_0.sav");
        return saveFilePath;
    }

    public string DetectSteamSaveLocation()
    {
        var steamPath = GetSteamInstallPath();
        if (string.IsNullOrEmpty(steamPath))
            return string.Empty;

        var userdataPath = Path.Combine(steamPath, "userdata");

        using var key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam\ActiveProcess", false);
        var userId = key?.GetValue("ActiveUser")?.ToString();

        if (string.IsNullOrEmpty(userId))
            return string.Empty;

        var savePath = Path.Combine(userdataPath, userId, "667720", "remote", "autocloud", "save", "keen_savegame_0_0.sav");
        return savePath;
    }

    private static string GetSteamInstallPath()
    {
        using var key = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Valve\Steam", false);
        return key?.GetValue("InstallPath") as string ?? string.Empty;
    }
}