using InvoiceApi.Core.Responses;
using InvoiceApi.Data.Dtos;
using InvoiceApi.Data.Models;

namespace InvoiceApi.Core.Services
{
    public interface IInvoiceService
    {
        Task<ServiceResponse<InvoiceHeaderDto>> GetFileByIdAsync(string invoiceId);
        Task<ServiceResponse<List<InvoiceHeaderDto>>> GetAllFilesListAsync();
        Task<ServiceResponse<bool>> UploadNewFileAsync(Stream file);
        Task<List<InvoiceHeader>> GetUnprocessedInvoicesAsync();
        Task<bool> MarkInvoiceAsProcessed(string invoiceId);
    }
}
