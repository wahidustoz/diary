public static partial class ValidationFilterLoggings
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Trace,
        Message = "Fluent validation started for type {targetType}.")]
    public static partial void LogValidationStarted(
        this ILogger logger,
        string targetType);
}