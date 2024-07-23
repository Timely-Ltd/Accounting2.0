using Microsoft.Extensions.Caching.Memory;

public class ReportService
{
    private readonly IMemoryCache _memoryCache;

    public ReportService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public string GetReport(string accountId, string reportType)
    {
        string cacheKey = $"{accountId}_{reportType}";
        if (!_memoryCache.TryGetValue(cacheKey, out string report))
        {
            report = GenerateReport(accountId, reportType);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(1));

            _memoryCache.Set(cacheKey, report, cacheEntryOptions);
        }

        return report;
    }

    // This is a placeholder for the actual report generation logic
    private string GenerateReport(string accountId, string reportType)
    {
        return $"{reportType} report for account {accountId} generated at {DateTime.Now}";
    }
}