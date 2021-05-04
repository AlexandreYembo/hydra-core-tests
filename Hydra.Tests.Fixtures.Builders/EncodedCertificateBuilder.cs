using AutoFixture.Kernel;
using Hydra.Tests.Fixtures.Builders.Extensions;
using Hydra.Tests.Fixtures.Builders.Models;

namespace Hydra.Tests.Fixtures.Builders
{
    public class EncodedCertificateBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request.HasPropertyType<CertificateFixture>() || request.HasParameterType<CertificateFixture>())
                return new CertificateFixture()
                {
                    CertificateEncoded = ConstantsFixture.CERTIFICATE_ENCODED
                };

            return new NoSpecimen();
        }
    }
}
