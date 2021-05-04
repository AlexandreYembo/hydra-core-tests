using AutoFixture;
using Hydra.Tests.Fixtures.Builders;

namespace Hydra.Tests.Fixtures
{
    internal class AutoMoqCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Insert(0, new X509Certificate2Builder());
            fixture.Customizations.Insert(1, new EncodedCertificateBuilder());
        }
    }
}
