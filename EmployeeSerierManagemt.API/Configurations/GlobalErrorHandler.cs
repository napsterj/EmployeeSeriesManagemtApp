namespace EmployeeSerierManagemt.API.Configurations
{
    public static class GlobalErrorHandler
    {
        public static WebApplicationBuilder AddGlobalErrorHandling(this WebApplicationBuilder builder)
        {
            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
            return builder;
        }
    }
}
