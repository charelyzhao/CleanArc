using System.Reflection;
using CleanArc.Infrastructure.Data;
using Serilog;
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.AddSerilog();

    Log.Information("Starting up the application...");
    // Add services to the container.
    builder.Services.AddKeyVaultIfConfigured(builder.Configuration);
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddWebServices();

    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        await app.InitialiseDatabaseAsync();
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHealthChecks("/health");
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseSwaggerUi(settings =>
    {
        settings.Path = "/api";
        settings.DocumentPath = "/api/specification.json";
    });

    // 在 app.MapEndpoints(); 前添加自动注册逻辑
    var endpointGroupTypes = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.IsSubclassOf(typeof(EndpointGroupBase)) && !t.IsAbstract);

    foreach (var type in endpointGroupTypes)
    {
        if (Activator.CreateInstance(type) is EndpointGroupBase instance)
        {
            instance.Map(app);
        }
    }

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapRazorPages();

    app.MapFallbackToFile("index.html");

    app.UseExceptionHandler(options => { });

    app.Map("/", () => Results.Redirect("/api"));
    Log.Information("Started up the application...");
    app.Run();
}
catch
{
    Log.Information("Fail Startup the application...");
}
public partial class Program { }
