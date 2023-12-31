﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ErpApi.WebAPI.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault();
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Object is null");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
