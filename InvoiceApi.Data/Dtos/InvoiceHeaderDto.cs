using InvoiceApi.Data.Enums;
using InvoiceApi.Data.Models;

namespace InvoiceApi.Data.Dtos
{
    public class InvoiceHeaderDto
    {
        public string InvoiceId { get; set; }
        public string? SenderTitle { get; set; }
        public string? ReceiverTitle { get; set; }
        public DateTime Date { get; set; }
        public string? Email { get; set; }
        public List<InvoiceLineDto> InvoiceLines { get; set; } = new();
    }
}