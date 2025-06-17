using InvoiceApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService, ILogger<InvoiceController> logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFileById([FromRoute] string id)
        {
            try
            {
                var response = await _invoiceService.GetFileByIdAsync(id);

                if (!response.Success)
                    return BadRequest(response.Message);

                return Ok(response.Data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFilesList()
        {
            try
            {
                var response = await _invoiceService.GetAllFilesListAsync();

                if (!response.Success)
                    return BadRequest(response.Message);

                return Ok(response.Data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("file")]
        public async Task<ActionResult> UploadNewFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("Dosya seçilmedi veya boş.");

                using var stream = file.OpenReadStream();
                var response = await _invoiceService.UploadNewFileAsync(stream);

                if (!response.Success)
                    return BadRequest(response.Message);

                return Ok(response.Data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
