using System.Collections.Generic;
using RFGM.Formats.Saves.World;
using RFGM.Formats.Saves.World.Activities;
using RFGR.SaveEditor.Utilities;

namespace RFGR.SaveEditor.Components.Pages;

public partial class Missions
{
    private static readonly MissionsData.MissionFlags FlagsNone = MissionsData.MissionFlags.None;

    private static readonly MissionsData.MissionFlags FlagsUnlocked =
        MissionsData.MissionFlags.Unlocked | MissionsData.MissionFlags.UnlockNotified;

    private static readonly MissionsData.MissionFlags FlagsComplete = MissionsData.MissionFlags.Complete |
                                                                      MissionsData.MissionFlags.Attempted |
                                                                      MissionsData.MissionFlags.Viewed |
                                                                      MissionsData.MissionFlags.Unlocked |
                                                                      MissionsData.MissionFlags.UnlockNotified;

    private void UpdateMissionFlags(string missionName, MissionsData.MissionFlags newFlags)
    {
        if (World.MissionsState.Missions.TryGetValue(missionName, out _))
        {
            World.MissionsState.Missions[missionName] = newFlags;
        }
    }

    private static bool IsMissionFlagSet(MissionsData.MissionFlags flags, MissionsData.MissionFlags checkFlag)
    {
        return flags.HasFlag(checkFlag);
    }
}