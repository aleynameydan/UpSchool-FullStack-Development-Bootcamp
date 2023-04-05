using Domain.Common;
using MediatR;

namespace Application.Features.City.Commands.Add;

public class CityAddCommand:IRequest<Response<int>>
{
    public string Name { get; set; }
    public int CountryId { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
}