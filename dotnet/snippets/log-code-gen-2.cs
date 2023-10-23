public class AsyncFluentValidationFilter<T> : IEndpointFilter where T : class
{
    private readonly ILogger<AsyncFluentValidationFilter<T>> logger;

    public AsyncFluentValidationFilter(ILogger<AsyncFluentValidationFilter<T>> logger)
        => this.logger = logger;

    public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        ...
        logger.LogValidationStarted(nameof(T));
        ...
    }
}