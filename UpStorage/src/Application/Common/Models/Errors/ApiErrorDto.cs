namespace Application.Common.Models.Errors;

public class ApiErrorDto
{
    public string Message { get; set; } // Ex: There are one or more errors occured.
    
    public List<ErrorDto> Errors { get; set; } // Ex: Hangi errorlerin döndüğü bu kısımda kaydedilir.

    public ApiErrorDto()
    {
        Errors = new List<ErrorDto>();
    }

    public ApiErrorDto(string message)
    {
        Message = message;
    }
    
    public ApiErrorDto(string message, List<ErrorDto> errors)
    {
        Message = message;
        Errors = errors;
    }
}