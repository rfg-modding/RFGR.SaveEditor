using RFGM.Formats.Saves;
using RFGR.SaveEditor.Utilities;
using Sotsera.Blazor.Toaster;

namespace RFGR.SaveEditor.Services;

public class SaveFileService(LocatorService locator, IToaster toaster) : IDisposable
{
    public event Action? OnSelectedSlotChanged;
    public event Action? OnSaveFileLoaded;
    
    public SaveFile SaveFile { get; private set; }
    public List<SaveSlot> Slots { get; private set; }

    private bool _saveLoaded;
    public bool SaveLoaded
    {
        get => _saveLoaded;
        private set { _saveLoaded = value; OnSaveFileLoaded?.Invoke(); }
    }

    private SaveSlot _selectedSlot;
    public SaveSlot SelectedSlot
    {
        get => _selectedSlot;
        set { _selectedSlot = value; OnSelectedSlotChanged?.Invoke(); }
    }

    private string _gogSavePath = string.Empty;
    private string _steamSavePath = string.Empty;
    private string _currentSavePath = string.Empty;

    private void SortSlots()
    {
        var baseSlots = SaveFile.Slots
            .Where(slot => slot.Exists && !SlotHelpers.IsDlc(slot))
            .OrderByDescending(slot => slot.Info.IsAutoSave)
            .ThenByDescending(SlotHelpers.GetCreationDate)
            .ToList();

        var dlcSlots = SaveFile.Slots
            .Where(slot => slot.Exists && SlotHelpers.IsDlc(slot))
            .OrderByDescending(slot => slot.Info.IsAutoSave)
            .ThenByDescending(SlotHelpers.GetCreationDate)
            .ToList();

        Slots = baseSlots.Concat(dlcSlots).ToList();
    }

    public bool GogFoundFile { get; private set; }
    public bool GogFoundDirectory { get; private set; }
    public bool SteamFoundFile { get; private set; }
    public bool SteamFoundDirectory { get; private set; }
    
    public void LocatePlatforms()
    {
        var gogSavePath = locator.DetectGogSaveLocation();
        var steamSavePath = locator.DetectSteamSaveLocation();

        if (!string.IsNullOrEmpty(gogSavePath))
        {
            GogFoundFile = File.Exists(gogSavePath);
            GogFoundDirectory = Directory.Exists(Path.GetDirectoryName(gogSavePath));
            _gogSavePath = gogSavePath;
        }
        else
        {
            GogFoundFile = false; GogFoundDirectory = false;
        }
        
        if (!string.IsNullOrEmpty(steamSavePath))
        {
            SteamFoundFile = File.Exists(steamSavePath);
            SteamFoundDirectory = Directory.Exists(Path.GetDirectoryName(steamSavePath));
            _steamSavePath = steamSavePath;
        }
        else
        {
            SteamFoundFile = false; SteamFoundDirectory = false;
        }
    }

    public async Task OpenGog() => await Open(_gogSavePath);
    public async Task OpenSteam() => await Open(_steamSavePath);
    public async Task OpenDialog()
    {
        var importPath = await Program.MainWindow.ShowOpenFileAsync(
            title: "Import file", 
            multiSelect: false, 
            filters: [("Save file", ["*.sav"]), ("All files", ["*.*"])]);
        if (importPath.Length == 0) return;
        await Open(importPath[0]);
    }
    
    private async Task Open(string file)
    {
        try
        {
            _currentSavePath = file;
            await using var fileStream = File.OpenRead(file);
            SaveFile = new SaveFile();
            SaveFile.Read(fileStream);

            if (!SaveFile.Slots[0].Exists)
            {
                SaveLoaded = false;
                toaster.Error("Failed to load save file. Save file contains no slots.");
                return;
            }

            SortSlots();
            SelectedSlot = Slots[0];
            SaveLoaded = true;
            toaster.Success($"Successfully loaded save file: {file}");
        }
        catch (Exception ex)
        {
            SaveLoaded = false;
            toaster.Error($"Failed to load save file. {ex}");
        }
    }
    
    public async Task SaveGog() => await Save(_gogSavePath);
    public async Task SaveSteam() => await Save(_steamSavePath);
    public async Task SaveCurrent()
    {
        await Save(_currentSavePath);
    }
    
    private async Task Save(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                var currentTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                var directory = Path.GetDirectoryName(file);
                var fileName = Path.GetFileNameWithoutExtension(file);
                var extension = Path.GetExtension(file);
                var backupPath = Path.Combine(directory, $"{fileName}-{currentTime}{extension}");
                File.Copy(file, backupPath, overwrite: false);
            }
            
            await using var fileStream = File.Create(file);
            SaveFile.Write(fileStream);
            toaster.Success($"Successfully saved to {file}");
        }
        catch (Exception ex)
        {
            toaster.Error($"Failed to save file. {ex}");
        }
    }

    public void Close()
    {
        SaveLoaded = false;
        SaveFile = null!;
        SelectedSlot = null!;
        Slots = null!;
    }
    
    public void Dispose()
    {
        OnSelectedSlotChanged = null;
        OnSaveFileLoaded = null;
        Close();
    }
}