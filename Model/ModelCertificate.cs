using System;

namespace CertificateFunction.Model
{
    public class ModelCertificate
    {
        public string Title { get; private set; } = string.Empty;

        public string SignatureAlgorithm { get; private set; } = string.Empty;

        public string Type { get; private set; } = string.Empty;

        public string Link { get; private set; } = string.Empty;

        public DateTime DateIssue { get; private set; }

        public DateTime RenewalDate { get; private set; }


        public ModelCertificate(string title, string signatureAlgorithm, string type, string link, DateTime dateIssue, DateTime renewalDate)
        {
            Title = title;
            SignatureAlgorithm = signatureAlgorithm;
            Type = type;
            Link = link;
            DateIssue = dateIssue;
            RenewalDate = renewalDate;
        }
    }
}
