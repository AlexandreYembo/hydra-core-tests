using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Hydra.Core.Tests.Extensions
{
    public static class AssertExtensions
    {
        /// <summary>
        /// Method that create assert for invalid request
        /// E.g. Error Message should return as "Invalid request"
        /// Error code should always be equal 400
        /// </summary>
        /// <param name="actionResult"></param>
        /// <typeparam name="T"></typeparam>
        public static void IsInvalidRequest<T>(this T actionResult) where T: IRequestResult
        {
            ReturnFourHundredCode(actionResult);
            Assert.True(actionResult.ErrorMessages.Count > 0);
            Assert.True(actionResult.ErrorMessages.Any(error => error == "Invalid request"));
        }

        public static void IsInvalidRequest<T>(this T actionResult, List<string> expectedErrors) where T : IRequestResult
        {
            ReturnFourHundredCode(actionResult);
            Assert.True(actionResult.ErrorMessages.Count > 0);
            Assert.Equal(actionResult.ErrorMessages, expectedErrors);
        }

        private static void ReturnFourHundredCode<T>(T actionResult) where T : IRequestResult =>
            Assert.Equal(400, actionResult.ErrorCode);
    }
}