using RFGM.Formats.Saves.World.UI;
using RFGR.SaveEditor.Components.Shared;
using RFGR.SaveEditor.Utilities;

namespace RFGR.SaveEditor.Components.Pages;

public partial class WeaponCabinet
{
    private static List<Combobox<uint>.SelectOption<uint>> WeaponOptions => XtblData.Weapons.Select(weapon => new Combobox<uint>.SelectOption<uint>
    {
        Value = weapon.Value.Id,
        DisplayText = weapon.Value.DisplayName,
        Dlc = weapon.Value.Dlc
    }).ToList();

    private string GetWeaponFromId(uint id)
    {
        var weapon = XtblData.Weapons.FirstOrDefault(weapon => weapon.Value.Id == id);
        return weapon.Key;
    }
    
    private void AddWeapon()
    {
        World.UiState.WeaponCabinet.Weapons.Add(
            new CabinetData.WeaponListItem()
            {
                Id = 0,
                Unlocked = true
            });
    }

    private void RemoveWeapon(int index)
    {
        if (index >= 0 && index < World.UiState.WeaponCabinet.Weapons.Count)
        {
            World.UiState.WeaponCabinet.Weapons.RemoveAt(index);
        }
    }
}