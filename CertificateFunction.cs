using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

{
    {

        {
            _certificateService = certificateService;
        }

        [FunctionName("GetCertificateFunction")]
        public async Task<IActionResult> Run(
            ILogger log)
        {



        }
    }
}