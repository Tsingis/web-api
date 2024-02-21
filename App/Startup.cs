using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup(IConfigurationRoot configuration)
{
    public IConfigurationRoot Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<JsonOptions>(opt =>
        {
            var serializerOptions = opt.SerializerOptions;
            serializerOptions.WriteIndented = true;
            serializerOptions.IncludeFields = true;
            serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            serializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
            serializerOptions.PropertyNameCaseInsensitive = true;
            serializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        services.Configure<KestrelServerOptions>(opt => { opt.AddServerHeader = false; });

        services.AddHttpClient();
        services.AddDependencies();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        if (env.IsProduction())
        {
            app.UseHttpsRedirection();
        }
    }
}