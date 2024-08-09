using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FunctionCertificate.Service;

namespace FunctionCertificate
{
    public class CertificateFunction : ControllerBase
    {
        private readonly CertificateService _certificateService;

        public CertificateFunction(CertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [FunctionName("GetCertificateFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "certificate")] HttpRequest req,
            ILogger log)
        {
            string url = req.Query["url"];

            if (url is null)
                return BadRequest();

            return new OkObjectResult(await _certificateService.GetServerCertificateAsync(url));
        }
    }
}
