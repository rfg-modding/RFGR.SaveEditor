namespace RFGR.SaveEditor.Utilities;

public static class MissionMap
{
    public record MissionInfo(string Name, string Sector, string Image);

    public static readonly Dictionary<string, MissionInfo> Missions = new()
    {
        { "Tutorial", new MissionInfo("Welcome To Mars", "Parker", "WelcomeToMars.png") },
        { "Intro 1", new MissionInfo("Better Red Than Dead", "Parker", "BetterRedThanDead.png") },
        { "Intro 2", new MissionInfo("Ambush", "Parker", "Ambush.png") },
        { "We know where you are", new MissionInfo("Start Your Engines", "Parker", "StartYourEngines.png") },
        { "Friends, Martians, Countrymen", new MissionInfo("Rallying Point", "Dust", "RallyingPoint.png") },
        { "Walker, Martian Ranger", new MissionInfo("Industrial Revolution", "Dust", "IndustrialRevolution.png") },
        {  "PartyTime", new MissionInfo("Ultor Echo", "Dust", "UltorEcho.png") },
        { "Death From Above", new MissionInfo("Ashes To Ashes...", "Dust", "AshesToAshes.png") },
        { "Refugee Truck", new MissionInfo("Emergency Response", "Badlands", "EmergencyResponse.png") },
        { "Highway To Hell", new MissionInfo("Catch And Release", "Badlands", "CatchAndRelease.png") },
        { "Start Your Engines", new MissionInfo("Air Traffic Control", "Badlands", "AirTrafficControl.png") },
        { "Traffic Jam", new MissionInfo("Access Denied", "Oasis", "AccessDenied.png")  },
        { "Tank Attack", new MissionInfo("Blitzkrieg", "Oasis", "Blitzkrieg.png") },
        { "Guns of Tharsis", new MissionInfo("The Guns Of Tharsis", "Free Fire Zone", "TheGunsOfTharsis.png") },
        { "Death By Committee", new MissionInfo("Death By Committee", "Eos", "DeathByCommittee.png") },
        { "Sniper Hunter", new MissionInfo("The Dogs Of War", "Eos", "TheDogsOfWar.png") },
        { "Save the Guerrilla Camp", new MissionInfo("Hammer Of The Gods", "Eos", "HammerOfTheGods.png") },
        { "Marauder Temple", new MissionInfo("Marauder Temple", "Eos", "MarauderTemple.jpg") },
        { "Ants Vs Magnifying Glass", new MissionInfo("Manual Override", "Eos", "ManualOverride.png") },
        { "Emergency Broadcast System", new MissionInfo("Emergency Broadcast System", "Eos", "EmergencyBroadcastSystem.png") },
        { "Assault the EDF Central Command", new MissionInfo("Guerrillas At The Gates", "Eos", "GuerrillasAtTheGates.png") },
        { "Final Mission", new MissionInfo("Mars Attacks", "Mount Vogel", "MarsAttacks.png") },
        { "DLC_Mission_1", new MissionInfo("Rescue", "Mariner Valley", "Rescue.jpg") },
        { "DLC_Mission_2", new MissionInfo("Retribution", "Mariner Valley", "Retribution.jpg") },
        { "DLC_Mission_3", new MissionInfo("Redemption", "Mariner Valley", "Redemption.jpg") },
    };

    public static readonly List<string> BaseMissions =
    [
        "Tutorial",
        "Intro 1",
        "Intro 2",
        "We know where you are",
        "Friends, Martians, Countrymen",
        "Walker, Martian Ranger",
        "PartyTime",
        "Death From Above",
        "Refugee Truck",
        "Highway To Hell",
        "Start Your Engines",
        "Traffic Jam",
        "Tank Attack",
        "Guns of Tharsis",
        "Death By Committee",
        "Sniper Hunter",
        "Save the Guerrilla Camp",
        "Marauder Temple",
        "Ants Vs Magnifying Glass",
        "Emergency Broadcast System",
        "Assault the EDF Central Command",
        "Final Mission"
    ];

    public static readonly List<string> DlcMissions =
    [
        "DLC_Mission_1",
        "DLC_Mission_2",
        "DLC_Mission_3"
    ];
}