namespace Perforaator.Services;

public class EventService
{
    public event EventHandler<List<MemoryData>>? UiUpdater = null!;

    public void CallUiUpdate(List<MemoryData> memoryData)
    {
        OnUiUpdater(memoryData);
    }

    protected virtual void OnUiUpdater(List<MemoryData> e)
    {
        UiUpdater?.Invoke(this, e);
    }
}