using System.Text.Json;
using Application.Common.Models.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class GlobalExceptionFilter : IAsyncExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        ApiErrorDto apiErrorDto = new ApiErrorDto();
        switch (context.Exception)
        {
            case ValidationException:

                var validationException = context.Exception as ValidationException;

                //hata gösteren propertynameler unique olarak geldi;  5 tane mail hatası varsa bir kez mail döndü
                // ["email", "username", "password]
                var propertyNames = validationException.Errors
                    .Select(x => x.PropertyName)
                    .Distinct();

                
                //bu mail, username gibi propertyname içindekilerde mesela mail ile eşleşenlerin mesajları bir liste içine aktarıldı o listenin adı da propertyFailures
                foreach (var propertyName in propertyNames)
                {
                    var propertyFailures = validationException.Errors
                        .Where(e => e.PropertyName == propertyName)
                        .Select(x => x.ErrorMessage)
                        .ToList();
                    
                    // Password is required,
                    // Password must have at least 5 characters,
                    // Password must have at least 1 speacil characters
                    
                    apiErrorDto.Errors.Add(new ErrorDto(propertyName, propertyFailures));
                }
                
                apiErrorDto.Message = "One or more validation errors were occured."; // dönecek olan hata metni

                context.Result = new BadRequestObjectResult(apiErrorDto);
                break;
            
            default:
                
                _logger.LogError(context.Exception,context.Exception.Message);
                
                apiErrorDto.Message = "An unexcepted error was occured."; // dönecek olan hata metni
                context.Result = new ObjectResult(apiErrorDto)
                {
                    StatusCode = (int)StatusCodes.Status500InternalServerError
                };

                
                break;
        }
        return Task.CompletedTask;
        
        // context.HttpContext.Response.ContentType = "application/json"; //döneceğimiz tipin json olduğunu söyledik
        //
        // var apiErrorDtoJson = JsonSerializer.Serialize(apiErrorDto); //eldeki apierrordtoyu json döndürdük
        //
        //
        //
        // await context.HttpContext.Response.WriteAsync(apiErrorDtoJson); // response olarak bizim verdiğimiz modeli döndürdük


    }
    
}