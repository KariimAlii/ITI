using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Lab1.Filters
{
    public class DepricateVersion1Attribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var url = context.HttpContext.Request.Path.Value;
            if (url.Contains("v1"))
            {
                context.Result = new BadRequestObjectResult(new GeneralResponse(HttpStatusCode.BadRequest, "Use Version 2 instead"));
                //context.Result = new BadRequestResult(); // ==> returns a response without body
            }

        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }
    }
}
