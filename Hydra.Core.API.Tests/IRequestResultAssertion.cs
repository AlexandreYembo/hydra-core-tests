using System.Collections.Generic;

namespace Hydra.Core.API.Tests
{
    public interface IRequestResultAssertion
    {
        public int ErrorCode { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}