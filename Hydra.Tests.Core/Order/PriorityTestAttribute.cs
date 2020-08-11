using System;

namespace Hydra.Tests.Core.Order
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PriorityTestAttribute : Attribute
    {
        public int Priority { get; }
        public PriorityTestAttribute(int priority)
        {
            Priority = priority;
        }
    }
}