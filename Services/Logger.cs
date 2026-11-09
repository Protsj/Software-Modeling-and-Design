namespace StoreAutomatization.Services;

using Serilog;
using Serilog.Formatting.Compact;

public static class Logger
{
    public static void Initialize()
    {
        bool isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

        var loggerConfig = new LoggerConfiguration()
            .MinimumLevel.Debug();

        if(isDocker)
            loggerConfig.WriteTo.Console(new CompactJsonFormatter());
        else
        {
            loggerConfig.WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code
            );
        }
        Log.Logger = loggerConfig.CreateLogger();
    }

    public static void LogInfo(string messageTemplate, params object[] propertyValues)
    {
        Log.Information(messageTemplate, propertyValues);
    }

    public static void LogError(string messageTemplate, params object[] propertyValues)
    {
        Log.Error(messageTemplate, propertyValues);
    }

    public static void Close()
    {
        Log.CloseAndFlush();
    }
}
