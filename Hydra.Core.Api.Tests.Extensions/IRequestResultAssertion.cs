using System.Collections.Generic;

namespace Hydra.Core.Api.Tests.Extensions
{
    public interface IRequestResultAssertion
    {
         public int ErrorCode { get; set; }
         public List<string> ErrorMessages { get; set; }
    }
}