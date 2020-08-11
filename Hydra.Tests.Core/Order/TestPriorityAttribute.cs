using System;

namespace Hydra.Tests.Core.Order
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestPriorityAttribute : Attribute
    {
        public int Priority { get; }
        public TestPriorityAttribute(int priority)
        {
            Priority = priority;
        }
    }
}