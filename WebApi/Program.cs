using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Options
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(opt =>
{
    var serializerOptions = opt.SerializerOptions;
    serializerOptions.WriteIndented = true;
    serializerOptions.IncludeFields = true;
    serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    serializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
    serializerOptions.PropertyNameCaseInsensitive = true;
});

// Services
builder.Services.AddHttpClient();
builder.Services.AddScoped<IMarketStore, MarketStore>();
builder.Services.AddScoped<IMarketService, MarketService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Routes
app.MapGet("/longestdownwardtrend", async (IMarketService service, string fromDate, string toDate) =>
{
    return await service.GetLongestDownwardTrend(fromDate, toDate);
});

app.MapGet("/highestradingvolume", async (IMarketService service, string fromDate, string toDate) =>
{
    return await service.GetHighestTradingVolume(fromDate, toDate);
});


app.MapGet("/buyandsell", async (IMarketService service, string fromDate, string toDate) =>
{
    return await service.GetBestBuyAndSellDates(fromDate, toDate);
});

app.Run();