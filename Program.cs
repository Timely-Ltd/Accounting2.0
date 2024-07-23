using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ReportService>();

var app = builder.Build();

app.MapGet("/reports/{accountId}/{reportType}", (string accountId, string reportType, ReportService reportService) =>
{
    var validReportTypes = new List<string> { "daily", "weekly", "monthly", "quarterly", "annually" };
    if (!validReportTypes.Contains(reportType.ToLower()))
    {
        return Results.BadRequest("Invalid report type. Valid types are daily, weekly, monthly, quarterly, and annually.");
    }

    var report = reportService.GetReport(accountId, reportType);
    return Results.Ok(report);
});

app.Run();