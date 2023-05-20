namespace Application.Common.Interfaces;

public interface IAccountHubService
{
    // yeni bir account çıkarılınca frontend kısmını bilgilendirme
    // çıkarılan id account
    Task RemovedAsync(Guid id, CancellationToken cancellationToken);
}