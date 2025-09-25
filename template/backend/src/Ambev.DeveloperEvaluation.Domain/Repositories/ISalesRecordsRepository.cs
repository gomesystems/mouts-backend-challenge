using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISalesRecordsRepository
{
    Task<ISalesRecords> CreateAsync(ISalesRecords salesRecords, CancellationToken cancellationToken = default);
    Task<ISalesRecords?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ISalesRecords>> GetAllAsync(CancellationToken cancellationToken = default);
    //Task<IEnumerable<ISalesRecords>> GetByProductAsync(string productName, CancellationToken cancellationToken = default);
   
}
