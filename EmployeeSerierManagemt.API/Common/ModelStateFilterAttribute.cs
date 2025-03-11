using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeSerierManagemt.API.Common
{
    public class ModelStateFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context){}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //Using 422 instead of 400 - For cleaner validation messages compared to bad request for ModelState validations
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
