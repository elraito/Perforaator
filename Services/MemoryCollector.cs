using System.Diagnostics;

namespace Perforaator.Services;

public class MemoryCollector : BackgroundService
{
    private EventService eventService;

    public MemoryCollector(EventService eventService)
    {
        this.eventService = eventService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            eventService.CallUiUpdate(DoMeasure());
            await Task.Delay(250, stoppingToken);
        }
    }

    private List<MemoryData> DoMeasure()
    {
        var data = new List<MemoryData>();
        Process[] list = Process.GetProcesses();
        foreach (Process process in list)
        {
            data.Add(new MemoryData
            {
                Name = process.ProcessName,
                Used = process.WorkingSet64
            });
        }
        return data;
    }
}