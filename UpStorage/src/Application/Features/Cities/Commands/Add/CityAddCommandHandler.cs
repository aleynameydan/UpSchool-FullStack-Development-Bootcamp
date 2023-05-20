using Application.Common.Interfaces;
using Application.Common.Localizations;
using Application.Features.City.Commands.Add;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Application.Features.Cities.Commands.Add;

public class CityAddCommandHandler:IRequestHandler<CityAddCommand,Response<int>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IStringLocalizer<CommonLocalizationKeys> _localizer;

    public CityAddCommandHandler(IApplicationDbContext applicationDbContext, IStringLocalizer<CommonLocalizationKeys> localizer)
    {
        _applicationDbContext = applicationDbContext;
        _localizer = localizer;
    }

    public async Task<Response<int>> Handle(CityAddCommand request, CancellationToken cancellationToken)
    {
        var city = new Domain.Entities.City()
        {
            Name = request.Name,
            CountryId = request.CountryId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            CreatedOn = DateTimeOffset.Now,
            CreatedByUserId = null,
            IsDeleted = false
        };

        await _applicationDbContext.Cities.AddAsync(city, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new Response<int>(_localizer[CommonLocalizationKeys.City.Added,city.Name], city.Id);
    }
}