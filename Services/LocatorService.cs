using System.Runtime.Versioning;
using Microsoft.Win32;

namespace RFGR.SaveEditor.Services;

public class LocatorService
{
    public string DetectGogSaveLocation()
    {
        var appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var saveFileLocation = Path.Combine(appDataLocal, @"GOG.com\Galaxy\Applications\51153410217180642\Storage\Shared\Files\autocloud\save\keen_savegame_0_0.sav");
        return saveFileLocation;
    }
    
    public string DetectSteamSaveLocation()
    {
        var steamLocation = GetSteamInstallPath();

        var userdata = Path.Combine(steamLocation, "userdata");
        var key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam\ActiveProcess", false);
        var userId = key.GetValue("ActiveUser")?.ToString();
        
        return Path.Join(userdata, userId, @"\667720\remote\autocloud\save\keen_savegame_0_0.sav");
    }

    private static string GetSteamInstallPath()
    {
        using var key = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Valve\Steam", false);
        var steamLocation = key?.GetValue(@"InstallPath") as string;

        return steamLocation;
    }
}