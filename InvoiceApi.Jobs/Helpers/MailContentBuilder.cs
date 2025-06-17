using InvoiceApi.Data.Models;

namespace InvoiceApi.Jobs.Helpers
{
    public static class MailContentBuilder
    {
        public static string BuildInvoiceProcessedMail(InvoiceHeader invoice)
        {
            return $"{invoice.InvoiceLines.Count} kalem ürün içeren {invoice.InvoiceId} nolu faturanız başarıyla işlenmiştir.";
        }
    }
}
