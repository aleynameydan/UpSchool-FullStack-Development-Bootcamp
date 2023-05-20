using Application.Common.Models.Auth;

namespace Application.Common.Interfaces;

public interface ITwoFactorService
{
    TwoFactorGeneratedDto Generate(string email);

    //usercode --> 6 haneli gelen kod
    bool Validate(string userCode);
}