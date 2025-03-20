namespace RFGR.SaveEditor.Services;

public class TabStateService
{
    private int _activeTab;
    public int ActiveTab
    {
        get => _activeTab;
        private set
        {
            if (_activeTab == value) return;
            _activeTab = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    public void SetActiveTab(int tab)
    {
        ActiveTab = tab;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}