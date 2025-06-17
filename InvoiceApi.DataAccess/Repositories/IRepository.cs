using InvoiceApi.Data.Models;

namespace InvoiceApi.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<InvoiceHeader> GetByIdAsync(string id);
        Task UploadFile(T entity);
        Task<List<InvoiceHeader>> GetUnprocessAsync();
        Task<bool> MarkAsProcessedAsync(InvoiceHeader invoice);
    }
}
