### Hydra Tests Core

#### 1- How to use Priority Orderer: class used to sort the test by priority. Main focus in Integrated tests.

Create the attribute for the class
```c#
     [TestCaseOrderer("Hydra.Tests.Core.Order.PriorityOrderer", "Hydra.Tests.Core.Order")]
```

Then define for each method the priority, by setting a value:
```c#
    [Fact(DisplayName = "Method"), TestPriority(1)]
    public void Method()
    {
        ...
    }
```

#### 2- Selenium

###### Packages

- Selenium.Support

- Selenium.WebDriver

- DotNetSeleniumExtras.WaitHelpers (Helpers used to configure the render component time)

- Microsoft.Extensions.Configuration.Json