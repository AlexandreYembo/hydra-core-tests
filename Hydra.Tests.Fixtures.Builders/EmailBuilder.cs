using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture.Kernel;
using Hydra.Tests.Fixtures.Builders.Extensions;
using Hydra.Tests.Fixtures.Builders.Models;

namespace Hydra.Tests.Fixtures.Builders
{
    public class EmailBuilder: ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request.HasPropertyType<AutoMoqDataValidFixtures>() || request.HasParameterType<AutoMoqDataValidFixtures>())
                return new AutoMoqDataValidFixtures()
                {
                    Email = $"{Guid.NewGuid()}@hydratest.com"
                };

            return new NoSpecimen();
        }
    }
}
