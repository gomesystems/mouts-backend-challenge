using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

    public class SalesRecordsRepository : ISalesRecordsRepository
    {
        private readonly DefaultContext _context;
        public SalesRecordsRepository(DefaultContext context)
        {
            _context = context;
        }
        public async Task<ISalesRecords> CreateAsync(ISalesRecords salesRecords, CancellationToken cancellationToken = default)
        {
            await _context.SalesRecords.AddAsync((SalesRecords)salesRecords, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return salesRecords;
        }

        public async Task<ISalesRecords?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.SalesRecords.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var salesRecord = await _context.SalesRecords.FindAsync(new object[] { id }, cancellationToken);
            if (salesRecord == null)
            {
                return false;
            }
            _context.SalesRecords.Remove(salesRecord);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<ISalesRecords>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SalesRecords.ToListAsync(cancellationToken);
        }
      
}



