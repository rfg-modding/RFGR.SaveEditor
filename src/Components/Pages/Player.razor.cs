using RFGM.Formats.Saves.World.Player;
using RFGR.SaveEditor.Components.Shared;
using RFGR.SaveEditor.Utilities;

namespace RFGR.SaveEditor.Components.Pages;

public partial class Player
{
    private static List<Combobox<string>.SelectOption<string>> VehicleOptions => XtblData.Vehicles.Select(vehicle => new Combobox<string>.SelectOption<string>
    {
        Value = vehicle.Key,
        DisplayText = vehicle.Value.DisplayName,
        Dlc = vehicle.Value.Dlc
    }).ToList();
    
    private static List<Combobox<string>.SelectOption<string>> WeaponOptions => XtblData.Weapons.Select(weapon => new Combobox<string>.SelectOption<string>
    {
        Value = weapon.Key,
        DisplayText = weapon.Value.DisplayName,
        Dlc = weapon.Value.Dlc
    }).ToList();
    
    private readonly int[] _slotOrder = [3, 0, 1, 2];
    
    private void RemoveItem()
    {
        var items = World.PlayerInventoryState.Items;
        for (var i = _slotOrder.Length - 1; i >= 0; i--)
        {
            var slotIndex = _slotOrder[i];
            var item = items.FirstOrDefault(it => it.SelectionSlot == slotIndex);

            if (item == null) continue;
            items.Remove(item);
            break;
        }
    }

    private void AddItem()
    {
        var items = World.PlayerInventoryState.Items;
        foreach (var slot in _slotOrder)
        {
            if (items.Any(i => i.SelectionSlot == slot)) continue;
            items.Add(new PlayerInventoryData.InventoryItem
            {
                SelectionSlot = slot,
                ItemName = "m16",
                Count = 1,
                MagazineSize = 1
            });
            break;
        }
    }
    
    private void SetCheat(int dlcIndex, int cheatIndex, bool unlocked)
    {
        Profile.CheatsUnlocked[dlcIndex, cheatIndex] = unlocked;
    }
}