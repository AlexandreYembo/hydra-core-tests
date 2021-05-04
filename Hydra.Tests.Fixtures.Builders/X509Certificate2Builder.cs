using System;
using System.Security.Cryptography.X509Certificates;
using AutoFixture.Kernel;
using Hydra.Tests.Fixtures.Builders.Extensions;

namespace Hydra.Tests.Fixtures.Builders
{
    public class X509Certificate2Builder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            //It will create a valid certificate
            if (request.HasPropertyType<X509Certificate2>() || request.HasParameterType<X509Certificate2>())
                return new X509Certificate2(Convert.FromBase64String(ConstantsFixture.CERTIFICATE_ENCODED));

            return new NoSpecimen();
        }
    }
}
