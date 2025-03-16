namespace EmployeeSerierManagemt.API.Configurations
{
    public static class GlobalErrorHandler
    {
        public static WebApplicationBuilder AddGlobalErrorHandling(this WebApplicationBuilder builder)
        {
            //For displaying proper API error messages
            builder.Services.AddProblemDetails();
            
            //Handling exceptions globally.
            builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();
            return builder;
        }
    }
}
