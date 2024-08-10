using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CertificateFunction.Services;

namespace CertificateFunction
{
    public class CertificateFunction
    {
        private readonly ServiceCertificate _certificateService;

        public CertificateFunction(ServiceCertificate certificateService)
        {
            _certificateService = certificateService;
        }

        [FunctionName("GetCertificateFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), Route = "certificate/{url}")] HttpRequest req,
            string url,
            ILogger log)
        {
            if (string.IsNullOrEmpty(url))
            {
                return new BadRequestObjectResult("URL is required");
            }

            var certificate = await _certificateService.GetServerCertificateAsync(url);

<<<<<<< HEAD
            if (certificate == null)
            {
                return new NotFoundObjectResult("No certificate found");
            }

=======
>>>>>>> parent of 582fe80 (releases)
            return new OkObjectResult(await _certificateService.GetServerCertificateAsync(url));
        }
    }
}