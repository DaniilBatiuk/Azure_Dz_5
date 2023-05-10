using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostBuilder builder = new HostBuilder();
builder.ConfigureWebJobs(options => {
    options.AddAzureStorageBlobs();
    options.AddAzureStorageQueues();
});
builder.ConfigureLogging((HostBuilderContext context, ILoggingBuilder logBuilder) => {
    logBuilder.AddConsole();
});
IHost host = builder.Build();
using (host)
    host.Run();