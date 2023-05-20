using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.City.Queries.GetAll;

public class CityGetAllQueryHandler:IRequestHandler<CityGetAllQuery,List<CityGetAllDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions _cacheOptions;
    private const string CITIES_KEY = "CitiesList";

    public CityGetAllQueryHandler(IApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
    {
        _applicationDbContext = applicationDbContext;
        _memoryCache = memoryCache;
        _cacheOptions = new MemoryCacheEntryOptions()
        {
            //cache 6 saatte bir yenileniyor
            Priority = CacheItemPriority.Normal,
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(6)
        };
    }

    public async Task<List<CityGetAllDto>> Handle(CityGetAllQuery request, CancellationToken cancellationToken)
    {
        if (_memoryCache.TryGetValue(CITIES_KEY, out List<CityGetAllDto> cachedCities))
        {
            return cachedCities;
        }
        var dbQuery = _applicationDbContext.Cities.AsQueryable();

        //dbQuery = dbQuery.Where(x => x.CountryId == request.CountryId);

        if (request.IsDeleted.HasValue)
        {
            dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);
        }

        dbQuery = dbQuery.Include(x => x.Country);

        var cities = await dbQuery
            .Select(x=>MaptoDto(x))
            .ToListAsync(cancellationToken);
        
        _memoryCache.Set(CITIES_KEY, cities);

        return cities.ToList();
    }
    
    private static CityGetAllDto MaptoDto(Domain.Entities.City city)
    {
        return new CityGetAllDto()
        {
            Id = city.Id,
            CountryId = city.CountryId,
            CountryName = city?.Country?.Name,
            Name = city.Name,
            IsDeleted = city.IsDeleted,
            Longitude = city.Longitude,
            Latitude = city.Latitude
        };
    }
    private static IEnumerable<CityGetAllDto> MapCitiesToGetAllDtos(List<Domain.Entities.City> cities)
    {
        List<CityGetAllDto> cityGetAllDtos = new List<CityGetAllDto>();
        
        foreach (var city in cities)
        {
            yield return new CityGetAllDto()
            {
                Id = city.Id,
                CountryId = city.CountryId,
                CountryName = city.Country.Name,
                Name = city.Name,
                IsDeleted = city.IsDeleted,
                Longitude = city.Longitude,
                Latitude = city.Latitude
            };
        }
    }


    
}