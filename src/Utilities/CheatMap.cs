namespace RFGR.SaveEditor.Utilities;

public static class CheatMap
{
    public static readonly Dictionary<string, int> Cheats = new()
    {
        { "Super Hammer", 1 },
        { "Super Debris", 2 },
        { "Super Toughness", 3 },
        { "Super Sprinting", 4 },
        { "Super Jetpack", 5 },
        { "Unlimited Ammo", 6 },
        { "Cool Turrets", 7 },
        { "Free Upgrades", 8 },
        { "Max Morale", 9 },
        { "Max Technology", 10 },
        { "No Green Alert", 11 },
    };

    public static readonly List<string> BaseCheats =
    [
        "Super Hammer",
        "Super Debris",
        "Super Toughness",
        "Super Sprinting",
        "Super Jetpack",
        "Unlimited Ammo",
        "Cool Turrets",
        "Free Upgrades",
        "Max Morale",
        "Max Technology",
        "No Green Alert"
    ];
    
    public static readonly List<string> DlcCheats =
    [
        "Super Hammer",
        "Super Debris",
        "Super Toughness",
        "Super Sprinting",
        "Super Jetpack",
        "Unlimited Ammo",
        "Cool Turrets",
        "Max Technology",
        "No Green Alert"
    ];
}