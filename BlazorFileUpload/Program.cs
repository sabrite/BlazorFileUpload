var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddLogging(options => options.SetMinimumLevel(LogLevel.Trace));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(10);
    options.MaxBufferedUnacknowledgedRenderBatches = 10;
}).AddHubOptions(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromMinutes(10);
    options.EnableDetailedErrors = true;
    options.HandshakeTimeout = TimeSpan.FromSeconds(15);
    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
    options.MaximumParallelInvocationsPerClient = 1;
    options.MaximumReceiveMessageSize = 32 * 1024 * 1024;
    options.StreamBufferCapacity = 33554432;
});

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
