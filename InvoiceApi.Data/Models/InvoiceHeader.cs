using InvoiceApi.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Data.Models
{
    public class InvoiceHeader
    {
        [Required]
        public string? InvoiceId { get; set; }
        public string? SenderTitle { get; set; }
        public string? ReceiverTitle { get; set; }
        public DateTime Date { get; set; }
        public string? Email { get; set; }
        public MailStatus MailStatus { get; set; }
        public ProcessStatus ProcessStatus { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }
    }
}
