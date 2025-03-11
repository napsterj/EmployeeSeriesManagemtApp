using Microsoft.AspNetCore.Diagnostics;

namespace EmployeeSerierManagemt.API.Configurations
{
    public class ApplicationException : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
                                              Exception exception, 
                                              CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
