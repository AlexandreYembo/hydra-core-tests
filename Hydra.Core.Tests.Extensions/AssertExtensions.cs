using System.Linq;
using Xunit;

namespace Hydra.Core.Tests.Extensions
{
    public static class AssertExtensions
    {
        /// <summary>
        /// Method that create assert for invalid request
        /// E.g.<!-- Error Message should return as "Invalid request"-->
        /// Error code should always be equal 400
        /// </summary>
        /// <param name="actionResult"></param>
        /// <typeparam name="T"></typeparam>
        public static void IsInvalidRequest<T>(this T actionResult) where T: IRequestResult
        {
            Assert.Equal(400, actionResult.ErrorCode);
            Assert.True(actionResult.ErrorMessages.Count > 0);
            Assert.True(actionResult.ErrorMessages.Any(error => error == "Invalid request"));
        }
    }
}