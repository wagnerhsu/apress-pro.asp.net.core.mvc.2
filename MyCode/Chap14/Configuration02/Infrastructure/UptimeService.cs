using System.Diagnostics;

public class UptimeService
{
    private Stopwatch timer;
    public UptimeService()
    {
        timer = Stopwatch.StartNew();
    }
    public long Uptime => timer.ElapsedMilliseconds;
}