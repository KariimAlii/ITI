using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab1.Filters
{
    public class ValidateCarTypeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Car car = context.ActionArguments["car"] as Car;

            string[] allowedTypes =  { "Electric", "Gas", "Diesel", "Hybrid" };

            if ( car is null || !allowedTypes.Contains(car.Type) )
            {
                context.ModelState.AddModelError("Type", "Type is not covered");
                context.Result = new BadRequestObjectResult(context.ModelState); // ==> Equivalent to Returning a BadRequest Response
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
