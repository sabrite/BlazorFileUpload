var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddLogging(options => options.SetMinimumLevel(LogLevel.Trace));

builder.WebHost.UseKestrel(options =>
{
    options.Limits.MaxRequestBodySize = null;
});
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
