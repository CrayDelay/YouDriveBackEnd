using Destructurama;
using Serilog;
using Hangfire;
using Hellang.Middleware.ProblemDetails;
using DriversManagement.Extensions.Application;
using DriversManagement.Extensions.Services;
using DriversManagement.Databases;
using DriversManagement.Resources.HangfireUtilities;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.WithProperty("ApplicationName", builder.Environment.ApplicationName)
    .Destructure.UsingAttributes()
    .CreateLogger();

builder.Host.UseSerilog();

builder.ConfigureServices();

var app = builder.Build();

using var scope = app.Services.CreateScope();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseProblemDetails();

// For elevated security, it is recommended to remove this middleware and set your server to only listen on https.
// A slightly less secure option would be to redirect http to 400, 505, etc.
app.UseHttpsRedirection();

app.UseCors("DriversManagementCorsPolicy");

app.MapHealthChecks("api/health");
app.UseSerilogRequestLogging();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    AsyncAuthorization = new[] { new HangfireAuthorizationFilter(scope.ServiceProvider) },
    IgnoreAntiforgeryToken = true
});

app.UseSwaggerExtension(builder.Configuration, builder.Environment);

try
{
    Log.Information("Starting application");
    await app.RunAsync();
}
catch (Exception e)
{
    Log.Error(e, "The application failed to start correctly");
    throw;
}
finally
{
    Log.Information("Shutting down application");
    Log.CloseAndFlush();
}

// Make the implicit Program class public so the functional test project can access it
public partial class Program { }