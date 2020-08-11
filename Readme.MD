### Hydra Tests Core

1- How to use Priority Orderer: class used to sort the test by priority. Main focus in Integrated tests.

Create the attribute for the class
```c#
     [TestCaseOrderer("Hydra.Tests.Core.Order.PriorityOrderer", "Hydra.Tests.Core.Order")]
```

The n Define for each method the priority, by setting a value:
```c#
    [Fact(DisplayName = "Method"), TestPriority(1)]
    public void Method()
    {
        ...
    }
```
