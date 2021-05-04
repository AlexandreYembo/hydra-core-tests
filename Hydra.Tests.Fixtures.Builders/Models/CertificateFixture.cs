using System.Security.Cryptography.X509Certificates;

namespace Hydra.Tests.Fixtures.Builders.Models
{
    public class CertificateFixture
    {
        public X509Certificate2 Certificate2 { get; set; }
        public string CertificateEncoded { get; set; }
    }
}
