public static partial class ValidationFilterLoggings
{
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Trace,
        Message = "Fluent validation for {targetType} is successful.")]
    public static partial void LogValidationCompleted(
        this ILogger<AsyncFluentValidationFilter<T>> logger,
        string targetType);
}