using FunctionCertificate.Entity;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FunctionCertificate.Service
{
    public class CertificateService
    {
        public async Task<CertificateEntity> GetServerCertificateAsync(string url)
        {
            X509Certificate2 certificate = null!;

            using var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (requestMessage, cert, chain, sslErrors) =>
            {
                if (sslErrors == SslPolicyErrors.None && cert is X509Certificate2 cert2)
                {
                    certificate = new X509Certificate2(cert2);
                }
                return true;
            };

            using var client = new HttpClient(handler);
            await client.GetAsync(url);

            return new CertificateEntity(
                title: certificate.Subject,
                signatureAlgorithm: certificate.SignatureAlgorithm.Value!,
                type: certificate.SignatureAlgorithm.FriendlyName!,
                link: url,
                dateIssue: certificate.NotBefore,
                renewalDate: certificate.NotAfter
            ); ;
        }
    }
}
