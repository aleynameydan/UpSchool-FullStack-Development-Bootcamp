using Application.Common.Interfaces;
using Application.Features.City.Commands.Add;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Commands.Add;

public class CityAddCommandValidator : AbstractValidator<CityAddCommand> //CityAddCommand validate ediliyor
{
    private readonly IApplicationDbContext _applicationDbContext;
        
        public CityAddCommandValidator(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        RuleFor(x => x.Name)
            .NotEmpty() // name kısmı boş geçilemez demek
            .MaximumLength(150);

        RuleFor(x => x.CountryId)
            .NotEmpty();

        RuleFor(x => x.CountryId).MustAsync(DoesCountryExistAsync)
            .WithMessage("The selected country does not exist.");

        // RuleFor(x => x.CountryIds).Must(IsCountryIdsListValid)
        //     .WithMessage("Please select at least two countries.");

        RuleFor(x => x.Name)
            .MustAsync((command, name, cancellationToken) =>
            {
                return _applicationDbContext.Cities.AnyAsync(x => command.Name.ToLower() == name.ToLower(),
                    cancellationToken);
            });
    }

        private Task<bool> DoesCountryExistAsync(int countryId, CancellationToken cancellationToken)
        {
            return _applicationDbContext.Countries.AnyAsync(x => x.Id == countryId, cancellationToken);

        }

        // private bool IsCountryIdsListValid(List<Guid> countryIds)
        // {
        //     if (countryIds is null || countryIds.Any() || countryIds.Count < 2)
        //         return false;
        //
        //     return true;
        // }
        
        
}