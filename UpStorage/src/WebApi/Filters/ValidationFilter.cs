using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class ValidationFilter : ActionFilterAttribute
{
    
    // action çalıştırılırken filtreden geçer.
    // context işlemi kullandığımız yeri temsil eder. --> add işlemi olabilir, getall olabilir her türlü işleme özel kullanılır
    public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Select(x => x.Value.Errors)
                .Where(y=>y.Count>0)
                .ToList();
            
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
        return base.OnActionExecutionAsync(context, next);
    }
}