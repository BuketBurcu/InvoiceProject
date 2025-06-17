using InvoiceApi.Core.Services;
using InvoiceApi.Jobs.Helpers;
using InvoiceApi.Mailing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InvoiceApi.Jobs
{
    public class MailJob : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<MailJob> _logger;

        public MailJob(ILogger<MailJob> logger)
        {
            _logger = logger;
        }
        public MailJob(IServiceScopeFactory scopeFactory, ILogger<MailJob> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Mail job başladı.");
                    using var scope = _scopeFactory.CreateScope();
                    var invoiceService = scope.ServiceProvider.GetRequiredService<IInvoiceService>();
                    var mailService = scope.ServiceProvider.GetRequiredService<IMailService>();


                    var unprocessedInvoices = await invoiceService.GetUnprocessedInvoicesAsync();

                    foreach (var invoice in unprocessedInvoices)
                    {
                        var itemCount = invoice.InvoiceLines.Count;
                        var email = invoice.Email;
                        var message = MailContentBuilder.BuildInvoiceProcessedMail(invoice);

                        if (!string.IsNullOrEmpty(email))
                        {
                            await mailService.SendMailAsync(email, "Fatura İşleme Bilgilendirme", message);
                        }

                        await invoiceService.MarkInvoiceAsProcessed(invoice.InvoiceId);
                    }

                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
