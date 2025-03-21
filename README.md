# <img alt="icon" width="30" height="30" align="center" src="src/wwwroot/images/icon.ico"/> RFG:R Save Editor

A save editor for Red Faction: Guerrilla Re-Mars-tered. Compatible with [GOG](https://www.gog.com/en/game/red_faction_guerrilla_remarstered) and [Steam](https://store.steampowered.com/app/667720/Red_Faction_Guerrilla_ReMarstered/).

Download the latest version from the [releases] page.

[releases]: https://github.com/arrowsv/RFGR.SaveEditor/releases

<img src="docs/images/Page_Missions.png" width="40%"/>

## How to use
1. Download and extract the latest version from the [releases] page.

2. Run `RFGR.SaveEditor.exe`.
   * .NET Desktop Runtime 8.0.14 is required for the program to run. If the runtime is not installed, the program should show a prompt for installation. If this does not appear, download and install the runtime manually [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

3. Open a save file.
   * To manually browse for a `.sav` file, click the `Open save` button. The save file should be named `keen_savegame_0_0.sav`.
   * If the program successfully detected either a GOG and/or Steam `.sav` file, the `Open GOG save` or `Open Steam save` buttons can be clicked.
      * Auto-detection will typically fail if the registry keys are empty or cannot be found. Steam detection can also fail if Steam is not running.
   * If you wish to open a different save file after opening, click the `X` button on the left side of the screen.

4. Edit data.
   * To change the selected slot, click the book icon in the top left and select a slot in the dropdown. These will appear in the same order shown in-game.
   * To modify a value, click on the white text at the right of the screen.
      * A value with an arrow button on its right is a dropdown for preset values, such as weapons and vehicles. Not all values in the game files were added as a preset.
      * Some values are read-only and can only be modified via the dropdown, such as for team dispositions and soundtrack progression.

5. Save file.
   * Click the save file icon in the tab list on the left of the screen.
   * To overwrite the currently opened save file with the new changes, click the `Save current file` button.
   * If the program successfully detected either a GOG and/or Steam save file directory, the `Write to GOG save file` or `Write to Steam save file` buttons can be clicked.
      * These buttons are only here to satisfy a specific use case in which you would only want the save file to be updated for a specific platform. The `Save current file` button is perfectly fine for common users.
   * The original save file will be copied and renamed to `keen_savegame_0_0-{year}-{month}-{day}_{hour}-{minute}-{second}.sav`.

## Features

### File opening / saving
* Open `.sav` files, either via platform auto-detect or manual browsing
* Save `.sav` file by overwriting currently opened file or by optionally saving it to a specific platform's directory 
* Automatically backs up file upon saving

### Data viewing / editing

#### Slots
* View up to 12 total slots
* Toggle autosave status
* View both base game and DLC slots in one list

#### Player
* Modify position
* Set statistics
* Add or remove weapons to inventory
* Last driven vehicle
* Toggle cheats

#### World
* Set time of day
* Toggle walker spawning
* Set soundtrack progression
* Reset or clear fog of war
* Modify sector control, morale, and liberation status

#### Missions
* Set to locked, unlocked, or completed

#### Weapon cabinet
* Add or remove weapons

#### Teams
* Set technology level
* Modify team dispositions

#### Raw data (experimental)
* View inner values of save file
* Modify multiplayer statistics

## Known issues
* Certain save files may have a cheat that is unlocked in-game but not shown in the `Cheats` list on the `Player` tab. This may be an artifact of having a Steam Edition save file that had previously been converted to be compatible with Re-Mars-tered.
* Certain weapons shown in the `Inventory` section on the `Player` tab may have large magazine sizes that don't reflect in-game values. Unsure of the cause.
* Not all values have strict validation outside enforcing a minimum / maximum and making sure non-text values aren't empty. There may be undiscovered limits that are enforced in-game.

## Screenshots
<details>
<summary>Open</summary>
<img src="docs/images/Page_Open.png" width="40%" />
</details>

<details>
<summary>Player</summary>
<img src="docs/images/Page_Player.png" width="40%" />
</details>

<details>
<summary>World</summary>
<img src="docs/images/Page_World.png" width="40%" />
</details>

<details>
<summary>Missions</summary>
<img src="docs/images/Page_Missions.png" width="40%" />
</details>

<details>
<summary>Weapon Cabinet</summary>
<img src="docs/images/Page_WeaponCabinet.png" width="40%" />
</details>

<details>
<summary>Teams</summary>
<img src="docs/images/Page_Teams.png" width="40%" />
</details>

<details>
<summary>Raw</summary>
<img src="docs/images/Page_Raw.png" width="40%" />
</details>

<details>
<summary>Save</summary>
<img src="docs/images/Page_Save.png" width="40%" />
</details>

## Credits
* [Rast1234](https://github.com/Rast1234) - testing and feature suggestions