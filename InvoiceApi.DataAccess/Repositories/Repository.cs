using InvoiceApi.Data.Models;
using InvoiceApi.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<InvoiceHeader> GetByIdAsync(string id)
        {
            return await _context.InvoiceHeaders
                         .Include(i => i.InvoiceLines)
                         .FirstOrDefaultAsync(i => i.InvoiceId == id);
        }

        public async Task UploadFile(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<List<InvoiceHeader>> GetUnprocessAsync()
        {
            return await _context.InvoiceHeaders
                         .Where(i => i.ProcessStatus == Data.Enums.ProcessStatus.UNPROCESSED)
                         .Include(i => i.InvoiceLines)
                         .ToListAsync();
        }

        public async Task<bool> MarkAsProcessedAsync(InvoiceHeader invoice)
        {
            invoice.ProcessStatus = Data.Enums.ProcessStatus.PROCESSED;
            _context.InvoiceHeaders.Update(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
