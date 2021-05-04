using System.Collections.Generic;
using Xunit;

namespace Hydra.Core.Api.Tests.Extensions
{
    public static class RequestResultAssertExtensions
    {
        /// <summary>
        /// Method that create assert for invalid request
        /// Error code should always be equal 400
        /// </summary>
        /// <param name="actionResult"></param>
        /// <param name="expectedErrors"></param>
        /// <typeparam name="T"></typeparam>
        public static void IsInvalidRequest<T>(this T actionResult, List<string> expectedErrors) where T : IRequestResultAssertion
        {
            Return400Code(actionResult);
            Assert.True(actionResult.ErrorMessages.Count > 0);
            Assert.Equal(actionResult.ErrorMessages, expectedErrors);
        }

        private static void Return400Code<T>(T actionResult) where T : IRequestResultAssertion =>
            Assert.Equal(400, actionResult.ErrorCode);
    }
}