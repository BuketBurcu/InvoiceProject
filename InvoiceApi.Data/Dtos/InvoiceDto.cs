
namespace InvoiceApi.Data.Dtos
{
    public class InvoiceDto
    {
        public InvoiceHeaderDto InvoiceHeader { get; set; }
        public List<InvoiceLineDto> InvoiceLine { get; set; }
    }
}
