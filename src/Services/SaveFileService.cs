using System.Runtime.InteropServices;
using RFGM.Formats.Saves;
using RFGR.SaveEditor.Utilities;
using Sotsera.Blazor.Toaster;

namespace RFGR.SaveEditor.Services;

public class SaveFileService(LocatorService locator, IToaster toaster) : IDisposable
{
    public event Action? OnSelectedSlotChanged;
    public event Action? OnSaveFileLoaded;

    public SaveFile? SaveFile { get; private set; }
    public List<SaveSlot> Slots { get; private set; } = new();

    private bool _saveLoaded;
    public bool SaveLoaded
    {
        get => _saveLoaded;
        private set
        {
            if (_saveLoaded == value) return;
            _saveLoaded = value;
            OnSaveFileLoaded?.Invoke();
        }
    }

    private SaveSlot? _selectedSlot;
    public SaveSlot? SelectedSlot
    {
        get => _selectedSlot;
        set
        {
            if (_selectedSlot == value) return;
            _selectedSlot = value; 
            OnSelectedSlotChanged?.Invoke();
        }
    }
    
    public bool GogFoundFile { get; private set; }
    public bool GogFoundDirectory { get; private set; }
    public bool SteamFoundFile { get; private set; }
    public bool SteamFoundDirectory { get; private set; }
    
    private string _gogSavePath = string.Empty;
    private string _steamSavePath = string.Empty;
    private string _currentSavePath = string.Empty;

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
        if (SaveFile is null) return;
        
        try
        {
            if (File.Exists(file))
            {
                var backupPath = Path.Combine(
                    Path.GetDirectoryName(file)!,
                    $"{Path.GetFileNameWithoutExtension(file)}-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}{Path.GetExtension(file)}"
                );
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
    
    private (bool fileFound, bool dirFound, string path) CheckPlatform(string path)
    {
        if (string.IsNullOrEmpty(path)) return (false, false, string.Empty);
        return (
            File.Exists(path),
            Directory.Exists(Path.GetDirectoryName(path)!),
            path
        );
    }

    public void LocatePlatforms()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;

        (GogFoundFile, GogFoundDirectory, _gogSavePath) = CheckPlatform(locator.DetectGogSaveLocation());
        (SteamFoundFile, SteamFoundDirectory, _steamSavePath) = CheckPlatform(locator.DetectSteamSaveLocation());
    }
    
    private void SortSlots()
    {
        if (SaveFile is null) return;
        
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

    public void Close()
    {
        SaveLoaded = false;
        SaveFile = null;
        SelectedSlot = null;
        Slots = new List<SaveSlot>();
    }
    
    public void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }
}