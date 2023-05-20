using Application.Common.Models.General;
using MediatR;

namespace Application.Features.Countries.Queries.GetAll;

public class CountriesGetAllQuery:IRequest<List<CountriesGetAllDto>>, IRequest<PaginatedList<CountriesGetAllDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; } // kaç tane ürün görmek istediğimiz
    
    
}