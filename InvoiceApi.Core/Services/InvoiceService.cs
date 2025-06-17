using AutoMapper;
using InvoiceApi.Core.Responses;
using InvoiceApi.Data.Dtos;
using InvoiceApi.Data.Enums;
using InvoiceApi.Data.Models;
using InvoiceApi.DataAccess.Context;
using InvoiceApi.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InvoiceApi.Core.Services
{
    public class InvoiceService : IInvoiceService
    {

        private readonly ILogger<InvoiceService> _logger;
        private readonly AppDbContext _context;
        private readonly IRepository<InvoiceHeader> _repository;
        private readonly IMapper _mapper;

        public InvoiceService(AppDbContext context, IRepository<InvoiceHeader> repository, ILogger<InvoiceService> logger, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<InvoiceHeaderDto>> GetFileByIdAsync(string invoiceId)
        {
            try
            {
                var invoice = await _repository.GetByIdAsync(invoiceId);
                if (invoice == null) return new ServiceResponse<InvoiceHeaderDto> { Success = false, Message = "Fatura bulunamadı" }; ;

                var returnData = _mapper.Map<InvoiceHeaderDto>(invoice);

                return new ServiceResponse<InvoiceHeaderDto> { Data = returnData, Message = "Başarılı" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<InvoiceHeaderDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<List<InvoiceHeaderDto>>> GetAllFilesListAsync()
        {
            try
            {
                var invoices = await _repository.GetAllAsync();

                var returnData = _mapper.Map<List<InvoiceHeaderDto>>(invoices);
                return new ServiceResponse<List<InvoiceHeaderDto>> { Data = returnData, Message = "Başarılı" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<List<InvoiceHeaderDto>> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<bool>> UploadNewFileAsync(Stream file)
        {
            try
            {
                using var reader = new StreamReader(file);
                var json = await reader.ReadToEndAsync();

                var invoiceDto = JsonSerializer.Deserialize<InvoiceDto>(json);

                if (invoiceDto == null)
                    return new ServiceResponse<bool> { Success = false, Message = "Json parse edilemedi" };

                var header = _mapper.Map<InvoiceHeader>(invoiceDto.InvoiceHeader);
                var lines = _mapper.Map<List<InvoiceLine>>(invoiceDto.InvoiceLine);

                foreach (var line in lines)
                {
                    line.Id = 0;
                    line.InvoiceId = header.InvoiceId;
                }

                header.InvoiceLines = lines;

                await _repository.UploadFile(header);


                return new ServiceResponse<bool> { Data = true, Message = "Başarılı" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ServiceResponse<bool> { Success = false, Message = ex.Message };
            }
        }

        public async Task<List<InvoiceHeader>> GetUnprocessedInvoicesAsync()
        {
            try
            {
                return await _repository.GetUnprocessAsync();
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<bool> MarkInvoiceAsProcessed(string invoiceId)
        {
            try
            {
                var invoice = await _repository.GetByIdAsync(invoiceId);

                if (invoice == null)
                    return false;

                return await _repository.MarkAsProcessedAsync(invoice);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}