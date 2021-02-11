using System.Collections.Generic;

namespace Hydra.Core.Tests.Extensions
{
    public interface IRequestResult
    {
         public int ErrorCode { get; set; }
         public List<string> ErrorMessages { get; set; }
    }
}