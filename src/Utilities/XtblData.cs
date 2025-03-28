namespace RFGR.SaveEditor.Utilities;

public static class XtblData
{
    public record VehicleInfo(string DisplayName, bool Dlc = false);

    public static readonly Dictionary<string, VehicleInfo> Vehicles = new()
    {
        { "EDF_APC_noturret", new VehicleInfo("EDF APC") },
        { "EDF_APC-A_1", new VehicleInfo("EDF APC (Turret)") },
        { "EDF_APC-A_Gauss", new VehicleInfo("EDF APC (Gauss)") },
        { "EDF_ScoutNoTurret", new VehicleInfo("EDF Scout") },
        { "EDF_Scout_1", new VehicleInfo("EDF Scout (Turret)") },
        { "EDF_Scout_Gauss", new VehicleInfo("EDF Scout (Gauss)") },
        { "EDF_Scout_Rocket", new VehicleInfo("EDF Scout (Rocket)") },
        { "EDF_StaffCar_NoTurret", new VehicleInfo("EDF Staff") },
        { "EDF_StaffCar_1", new VehicleInfo("EDF Staff (Turret)") },
        { "EDF_StaffCar_Gauss", new VehicleInfo("EDF Staff (Gauss)") },
        { "EDF_Supplytruck_NoTurret", new VehicleInfo("EDF Supply Truck") },
        { "EDF_Supplytruck_1", new VehicleInfo("EDF Supply Truck (Turret)") },
        { "EDF_Supplytruck_Gauss", new VehicleInfo("EDF Supply Truck (Gauss)") },
        { "Col_Mini_Hauler_1", new VehicleInfo("Civilian Mini Hauler") },
        { "Min_LightPickup_1", new VehicleInfo("Civilian Pickup") },
        { "Min_LightPickup_MG1", new VehicleInfo("Civilian Pickup (Turret)") },
        { "Min_ATV_1", new VehicleInfo("Civilian Mining ATV") },
        { "Min_ATV_MG1", new VehicleInfo("Civilian Mining ATV (Turret)") },
        { "Min_Rover-A_1", new VehicleInfo("Civilian Rover") },
        { "Min_Rover-A_MG1", new VehicleInfo("Civilian Rover (Turret)") },
        { "Min_Emergency_1", new VehicleInfo("Civilian Emergency Rover") },
        { "Col_TrashTruck_1", new VehicleInfo("Civilian Garbage Truck") },
        { "Col_TrashTruck_MG1", new VehicleInfo("Civilian Garbage Truck (Turret)") },
        { "Min_SupplyTruck_1", new VehicleInfo("Civilian Supply Truck") },
        { "Min_SupplyTruck_MG1", new VehicleInfo("Civilian Supply Truck (Turret)") },
        { "Min_DumpTruck_1", new VehicleInfo("Civilian Dump Truck") },
        { "Col_FuelTanker_1", new VehicleInfo("Civilian Fuel Tanker") },
        { "Col_FixedFlatbed", new VehicleInfo("Civilian Flatbed") },
        { "Civ_ResRunner_1", new VehicleInfo("Civilian Supercar") },
        { "Civ_ResRunner-C_1", new VehicleInfo("Civilian Luxury Coupé") },
        { "Civ_ResLuxury-C_1", new VehicleInfo("Civilian Luxury SUV") },
        { "Col_Taxi_1", new VehicleInfo("Civilian Luxury Taxi") },
        { "Col_Caravan_1", new VehicleInfo("Civilian Luxury Bus") },
        { "EDF_MediumTank-A_1", new VehicleInfo("Medium Tank") },
        { "EDF_HeavyTank-A_1", new VehicleInfo("Heavy Tank") },
        { "EDF_ArtTank_1", new VehicleInfo("Artillery Tank") },
        { "EDF_ArtTank_2", new VehicleInfo("Heavy Artillery Tank") },
        { "Walker_Min", new VehicleInfo("Light Walker") },
        { "Walker_Flamer", new VehicleInfo("Combat Walker") },
        { "Walker_Civilian", new VehicleInfo("Heavy Walker") },
        { "Min_Bulldozer_1", new VehicleInfo("Bulldozer") },
        { "Mar_Jetter_1", new VehicleInfo("Marauder Jetter") },
        { "Mar_Raider_1", new VehicleInfo("Marauder Raider") },
        { "Mar_chomper", new VehicleInfo("Marauder Chomper", true) },
        { "Mar_chomper_MG", new VehicleInfo("Marauder Chomper (Turret)", true) },
        { "Mar_chomper_Harp", new VehicleInfo("Marauder Chomper (Harpoon)", true) },
        { "Mar_stomper_MG", new VehicleInfo("Marauder Stomper", true) },
        { "Mar_Walker", new VehicleInfo("Marauder Punisher", true) }
    };

    public record WeaponInfo(string DisplayName, uint Id, bool Dlc = false);
    
    public static readonly Dictionary<string, WeaponInfo> Weapons = new()
    {
        { "m16", new WeaponInfo("Assault Rifle", 6) },
        { "enforcer", new WeaponInfo("Enforcer", 8) },
        { "sniper_rifle", new WeaponInfo("Sniper Rifle", 10) },
        { "autoblaster", new WeaponInfo("Shotgun", 7) },
        { "shotgun", new WeaponInfo("Marauder Shotgun", 20) },
        { "rail_driver", new WeaponInfo("Rail Driver", 11) },
        { "gauss_rifle", new WeaponInfo("Gauss Rifle", 9) },
        { "nano_rifle", new WeaponInfo("Nano Rifle", 17) },
        { "singularity_bomb", new WeaponInfo("Singularity Bomb", 12) },
        { "edf_pistol", new WeaponInfo("EDF Pistol", 5) },
        { "arc_welder", new WeaponInfo("Arc Welder", 19) },
        { "thermobaric_rockets", new WeaponInfo("Thermobaric Rockets", 16) },
        { "charge_placer", new WeaponInfo("Remote Charges", 14) },
        { "rpg_launcher", new WeaponInfo("Rocket Launcher", 15) },
        { "mine_placer", new WeaponInfo("Proximity Mine", 13) },
        { "grinder", new WeaponInfo("Grinder", 18) },
        { "gutter", new WeaponInfo("Gutter", 21) },
        { "repair_tool", new WeaponInfo("Reconstructor", 38) },
        { "sledgehammer", new WeaponInfo("Sledgehammer", 69) },
        { "sledge_upgrade_1", new WeaponInfo("Stonebreaker", 70) },
        { "sledge_upgrade_2", new WeaponInfo("Shattermaster", 71) },
        { "sledge_upgrade_3", new WeaponInfo("Facecrusher", 77) },
        { "sledge_upgrade_4", new WeaponInfo("Bronze Crusher", 78) },
        { "sledge_upgrade_5", new WeaponInfo("Silver Master", 79) },
        { "golden_hammer", new WeaponInfo("Gold Breaker", 123) },
        { "sledge_upgrade_6", new WeaponInfo("Gold Breaker Alpha", 80) },
        { "sledge_upgrade_7", new WeaponInfo("Titanium Hammer", 81) },
        { "sledge_upgrade_8", new WeaponInfo("Skulldigger", 82) },
        { "sledge_upgrade_9", new WeaponInfo("War Hammer", 83) },
        { "sledge_upgrade_10", new WeaponInfo("Battle Axe", 84) },
        { "sledge_upgrade_11", new WeaponInfo("Bloody Bat", 85) },
        { "sledge_upgrade_12", new WeaponInfo("Stun Baton", 86) },
        { "sledge_upgrade_13", new WeaponInfo("Plastic", 87) },
        { "sledge_upgrade_14", new WeaponInfo("Ostrich", 88) },
        { "mar_dlc_sledge", new WeaponInfo("Sledgehammer", 96, true) },
        { "mar_charge_placer", new WeaponInfo("Remote Charges", 97, true) },
        { "pickaxe", new WeaponInfo("Pickaxe", 95, true) },
        { "royal_sword", new WeaponInfo("Royal Sword", 98, true) },
        { "spiker", new WeaponInfo("Spiker", 93, true) },
        { "EDF_Super_Gauss", new WeaponInfo("Super Gauss Rifle", 130, true) },
        { "missilepod", new WeaponInfo("Missilepod", 132, true) },
        { "edf_subverter", new WeaponInfo("Subverter", 131, true) },
    };
}