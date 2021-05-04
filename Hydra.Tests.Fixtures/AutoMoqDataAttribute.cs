using AutoFixture;
using AutoFixture.Xunit2;

namespace Hydra.Tests.Fixtures
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() =>
        {
            var fixture = new Fixture();
            return fixture;
        })
        {

        }
    }
}
