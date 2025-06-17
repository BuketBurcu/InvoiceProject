
namespace InvoiceApi.Mailing
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string bodyHtml);
    }
}
