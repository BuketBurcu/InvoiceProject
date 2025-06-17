
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Data.Models
{
    public class InvoiceLine
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? InvoiceId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? UnitCode { get; set; }
        public decimal UnitPrice { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; }
    }
}
