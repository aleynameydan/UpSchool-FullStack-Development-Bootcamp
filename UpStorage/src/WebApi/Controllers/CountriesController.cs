using Application.Features.Countries.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[Controller]")]
[ApiController]
[Authorize] //sadece giriş yapanlar kullanabilir

public class CountriesController : ApiControllerBase
{
    [AllowAnonymous] // anonim isteklere izin verir bu method için
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAllAsync(CountriesGetAllQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}